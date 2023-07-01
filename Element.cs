using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
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
       public List<StartTag> startTags = new List<StartTag>();

        public struct EndTag
        {
            public string FirstDelimiter;
            public string TagName;
            public string LastDelimiter;
            public EndTag(string tagName)
            {

                FirstDelimiter = "</";
                TagName = tagName;
                LastDelimiter = ">";
            }
        }
       public  List<EndTag> endTags;
        public struct SingularTag
        {
            public string FirstDelimiter;
            public string TagName;
            public string LastDelimiter;
            public SingularTag(string tagName)
            {

                FirstDelimiter = "<";
                TagName = tagName;
                LastDelimiter = ">";
            }
        }
        public List<SingularTag> singularTags;
        public void CreateExistingTags()
        {

            string DT = File.ReadAllText(@"C:\Users\cgame\source\repos\Task-HtmlParser\HtmlParser\DoubleTags.txt");
            List<string> dtTagNames = DT.Split(',').ToList();

            foreach (string tagName in dtTagNames)
            {
                startTags.Add(new StartTag(tagName));
            }
            foreach (string tagName in dtTagNames)
            {
                endTags.Add(new EndTag(tagName));
            }
            string ST = File.ReadAllText(@"C:\Users\cgame\source\repos\Task-HtmlParser\HtmlParser\SingularTags.txt");
            List<string> stTagNames = ST.Split(',').ToList();
            foreach (string tagName in stTagNames)
            {
                singularTags.Add(new SingularTag(tagName));
            }
        }
        public Element( StartTag startTag,  EndTag endTag) { }
        public Element(SingularTag singularTag) { }
        public Element(StartTag startTag,string Content, EndTag endTag) { }


    }
}
