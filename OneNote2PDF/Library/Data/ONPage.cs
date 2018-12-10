
using System.Xml.Linq;

namespace OneNote2PDF.Library.Data
{
    public class ONPage : ONBasedType
    {
        public string PDFFilePath { get; set; }
        public bool? IsSubPage { get; internal set; }
    }
}
