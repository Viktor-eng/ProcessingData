namespace ProcessingData
{
    internal class DescriptionData : IDescriptionData
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte ReadPackageId { get; set; }
        public int ReadOffset { get; set; }
        public int ReadLenght { get; set; }
        public byte WritePackageId { get; set; }
        public int WriteOffset { get; set; }
        public int WriteLenght { get; set; }
    }
}
