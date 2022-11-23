using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWpfAppTest.ViewModel
{
    public class CustomBitmap
    {
        public Bitmap ImageSource { get; set; }
        public string Uri { get; set; }

        public CustomBitmap(string uri)
        {
            ImageSource = new Bitmap(uri);
            Uri = uri;
        }
    }
}
