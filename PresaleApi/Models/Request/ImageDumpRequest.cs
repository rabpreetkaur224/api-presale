namespace PresaleApi.Models
{
    public class ImageDumpRequest
    {
        public int ImageId { get; set; }
        public string ImageFileName { get; set; }
        public string ImageActualFileName { get; set; }
        public string FolderName { get; set; }
        public string FilePath { get; set; }
        public int Type { get; set; }
        public int? MaterId { get; set; }
        public bool IsPrimary { get; set; }
        public bool? IsDeleted { get; set; }
        public bool IsVideoImage { get; set; }
        public bool IsVideo { get; set; }
    }
}
