using NUnit.Framework;
using System.Collections.Generic;

namespace ProcessingData.Tests
{
    public class Tests
    {
        [Test]
        public void AddData_Test()
        {
            //Arrange
            var changeData = new ChangeData();
            var savedData = new DescriptionData()
            {
                Id = 1,
                Description = "text",
                ReadLenght = 1,
                ReadOffset = 1,
                ReadPackageId = 1,
                WriteLenght = 1,
                WriteOffset = 1,
                WritePackageId = 1
            };

            // Act
            changeData.AddData(savedData);
            var resultData = changeData.ReadData(savedData.Id);

            // Assert
            Assert.AreEqual(resultData.Id, savedData.Id);
            Assert.AreEqual(resultData.Description, savedData.Description);
            Assert.AreEqual(resultData.ReadLenght, savedData.ReadLenght);
            Assert.AreEqual(resultData.ReadOffset, savedData.ReadOffset);
            Assert.AreEqual(resultData.ReadPackageId, savedData.ReadPackageId);
            Assert.AreEqual(resultData.WriteLenght, savedData.WriteLenght);
            Assert.AreEqual(resultData.WriteOffset, savedData.WriteOffset);
            Assert.AreEqual(resultData.WritePackageId, savedData.WritePackageId);
        }

        [Test]
        public void DeleteData_Test()
        {
            //Arrange
            var changeData = new ChangeData();
            var savedData = new DescriptionData()
            {
                Id = 1,
                Description = "text",
                ReadLenght = 1,
                ReadOffset = 1,
                ReadPackageId = 1,
                WriteLenght = 1,
                WriteOffset = 1,
                WritePackageId = 1
            };

            // Act
            changeData.AddData(savedData);
            changeData.DeleteData(savedData.Id);

            // Assert
            Assert.Throws<KeyNotFoundException>(() => { changeData.ReadData(savedData.Id); });
        }

        [Test]
        public void EditData_Test()
        {
            //Arrange
            var changeData = new ChangeData();
            var savedData = new DescriptionData()
            {
                Id = 1,
                Description = "text",
                ReadLenght = 1,
                ReadOffset = 1,
                ReadPackageId = 1,
                WriteLenght = 1,
                WriteOffset = 1,
                WritePackageId = 1
            };

            var savedData2 = new DescriptionData()
            {
                Id = 1,
                Description = "text2",
                ReadLenght = 2,
                ReadOffset = 2,
                ReadPackageId = 2,
                WriteLenght = 2,
                WriteOffset = 2,
                WritePackageId = 2
            };

            // Act
            changeData.AddData(savedData);
            changeData.EditData(savedData2);
            var resultData = changeData.ReadData(savedData2.Id);

            // Assert
            Assert.AreEqual(resultData.Id, savedData2.Id);
            Assert.AreEqual(resultData.Description, savedData2.Description);
            Assert.AreEqual(resultData.ReadLenght, savedData2.ReadLenght);
            Assert.AreEqual(resultData.ReadOffset, savedData2.ReadOffset);
            Assert.AreEqual(resultData.ReadPackageId, savedData2.ReadPackageId);
            Assert.AreEqual(resultData.WriteLenght, savedData2.WriteLenght);
            Assert.AreEqual(resultData.WriteOffset, savedData2.WriteOffset);
            Assert.AreEqual(resultData.WritePackageId, savedData2.WritePackageId);
        }


        [Test]
        public void CheckData_Test()
        {
            // Arrange

            var changeData = new ChangeData();
            var savedData = new DescriptionData()
            {
                Id = 1,
                Description = "text",
                ReadLenght = 5,
                ReadOffset = 0,
                ReadPackageId = 1,
                WriteLenght = 3,
                WriteOffset = 0,
                WritePackageId = 1
            };

            var savedData2 = new DescriptionData()
            {
                Id = 1,
                Description = "text2",
                ReadLenght = 5,
                ReadOffset = 0,
                ReadPackageId = 1,
                WriteLenght = 4,
                WriteOffset = 4,
                WritePackageId = 1
            };

            changeData.CheckData(savedData);


        }
    }
}
