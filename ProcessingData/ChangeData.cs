using System;
using System.Collections.Generic;
using System.Linq;

namespace ProcessingData
{
    class ChangeData
    {
        private Dictionary<int, IDescriptionData> _dictionary = new Dictionary<int, IDescriptionData>();

        public void AddData(IDescriptionData data)
        {
            CheckData(data);
            _dictionary.Add(data.Id, data);
        }

        public void CheckData(IDescriptionData data)
        {
            if (_dictionary
                 .Where(c => c.Value.ReadPackageId == data.ReadPackageId &
                 (
                     (data.ReadOffset <= c.Value.ReadOffset & c.Value.ReadOffset <= (data.ReadOffset + data.ReadLenght)) ||
                     (data.ReadOffset <= (c.Value.ReadOffset + c.Value.ReadLenght) & (c.Value.ReadOffset + c.Value.ReadLenght) <= (data.ReadOffset + data.ReadLenght)) ||
                     ((data.ReadOffset + data.ReadLenght) <= (c.Value.ReadOffset + c.Value.ReadLenght) & c.Value.ReadOffset <= data.ReadOffset) ||
                     ((c.Value.ReadOffset + c.Value.ReadLenght) <= (data.ReadOffset + data.ReadLenght) & data.ReadOffset <= c.Value.ReadOffset)
                 )
                ).Count() > 0)
            {
                throw new ArgumentException("Произошло наложение диапазонов в пакете на чтение");
            }

            if (_dictionary
                .Where(c => c.Value.WritePackageId == data.WritePackageId &
                (
                    (data.WriteOffset <= c.Value.WriteOffset & c.Value.WriteOffset <= (data.WriteOffset + data.WriteLenght)) ||
                    (data.WriteOffset <= (c.Value.WriteOffset + c.Value.WriteLenght) & (c.Value.WriteOffset + c.Value.WriteLenght) <= (data.WriteOffset + data.WriteLenght)) ||
                    ((data.WriteOffset + data.WriteLenght) <= (c.Value.WriteOffset + c.Value.WriteLenght) & c.Value.WriteOffset <= data.WriteOffset) ||
                    ((c.Value.WriteOffset + c.Value.WriteLenght) <= (data.WriteOffset + data.WriteLenght) & data.WriteOffset <= c.Value.WriteOffset)
                )
               ).Count() > 0)
            {
                throw new ArgumentException("Произошло наложение диапазонов в пакете на запись");
            }
        }

        public IDescriptionData ReadData(int Id)
        {
            return _dictionary[Id];
        }

        public void DeleteData(int Id)
        {
            _dictionary.Remove(Id);
        }

        public void EditData(IDescriptionData data)
        {
            CheckData(data);
            _dictionary[data.Id] = data;
        }
    }
}
