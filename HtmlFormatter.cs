using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser
{
    public class HtmlFormatter
    {
        public static string FormatTags(string html)
        {
            StringBuilder formattedHtml = new StringBuilder();
            bool insideTag = false;
            bool insideAttributeName = false;
            foreach (char currentChar in html)
            {
                if (currentChar == '<')
                {
                    insideTag = true;
                    insideAttributeName = false;
                    formattedHtml.Append(currentChar);
                }
                else if (currentChar == '>')
                {
                    insideTag = false;
                    insideAttributeName = false;
                    formattedHtml.Append(currentChar);
                }
                else if (insideTag)
                {
                    if (Char.IsLetter(currentChar)==true && currentChar+1==' ')
                    {
                        insideAttributeName = true;
                    }

                    if (!char.IsWhiteSpace(currentChar) || insideAttributeName)
                    {
                        formattedHtml.Append(currentChar);
                    }
                }
                else
                {
                    formattedHtml.Append(currentChar);
                }
            }

            return formattedHtml.ToString();
        }
    }
}
