namespace ProcessingData
{
    internal interface IDescriptionData
    {
        string Description { get; set; }
        int Id { get; set; }
        int ReadLenght { get; set; }
        int ReadOffset { get; set; }
        byte ReadPackageId { get; set; }
        int WriteLenght { get; set; }
        int WriteOffset { get; set; }
        byte WritePackageId { get; set; }
    }
}
