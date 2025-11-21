using System.Web;

namespace ImageAdd.Models
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public HttpPostedFileBase File { get; set; }
        public string FilePath { get; set; }
    }
}