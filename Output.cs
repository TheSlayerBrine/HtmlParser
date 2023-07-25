using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser
{
    public class Output
    {
        private string filePath;

        public Output(string filePath)
        {
            this.filePath = filePath;
        }

        public void WriteToFile(string content)
        {
            File.AppendAllText(this.filePath, content);
        }
    }
}
