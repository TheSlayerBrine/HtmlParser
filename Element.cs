using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser
{
    internal class Element
    {
        public struct StartTag
        {
            public string FirstDelimiter;
            public string TagName;
            public string LastDelimiter;
            public List<string> Attributes;

            public StartTag(string tagName)
            {

                FirstDelimiter = "<";
                TagName = tagName;
                LastDelimiter = ">";
            } }
        public struct EndTag
        {
            public string FirstDelimiter;
            public string TagName;
            public string LastDelimiter;
        }
        public struct SingularTag
        {
            public string FirstDelimiter;
            public string TagName;
            public string LastDelimiter;
        }

        public string? Content;
        public string[][] WholeElement;
        public List<Element> Elements;
        public Element( StartTag startTag,  EndTag endTag) { }
        public Element(SingularTag singularTag) { }
        public Element(StartTag startTag,string Content, EndTag endTag) { }


    }
}
