using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
namespace HtmlParser
{
    public class HtmlParse
    {
        private Tree tree;
        private List<string> validTags;

        public HtmlParse(List<string> validTags)
        {
            tree = new Tree();
            this.validTags = validTags;
        }


        public void ParseHtml(string html)
        {
          
            bool isDocTypeDeclared = html.TrimStart().StartsWith("<!DOCTYPEhtml>");
            html = html.Replace("<!DOCTYPEhtml>", "");
            if (!isDocTypeDeclared)
            {
                Console.WriteLine("Invalid HTML format. Missing DOCTYPE declaration.");
                return;
            }

            html = html.Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();

          
            int i = 0;
            while (i < html.Length)
            {
                char currentChar = html[i];

                if (currentChar == '<')
                {
                    i++;
                    int closingBracket = html.IndexOf('>', i + 1);

                    if (closingBracket != -1)
                    {
                        StringBuilder tagBuilder = new StringBuilder();
                        StringBuilder attributeBuilder = new StringBuilder();
                        
                        while (i < html.Length && html[i] != '>')
                        {

                            tagBuilder.Append(html[i]);
                            if (tagBuilder.ToString().StartsWith("/"))
                            {                             
                                if (IsValidTag(tagBuilder.ToString().Substring(1)))
                                {
                                    tree.MoveToParent();
                                    break;
                                }
                            }
                            if (IsValidTag(tagBuilder.ToString()))
                            {
                                if (tagBuilder.ToString() == "head" && html[i + 1] == 'e' && html[i + 2] == 'r')
                                {
                                    tree.AddTag("header");
                                    i=i + 3;
                                }
                                if (tagBuilder.ToString() == "meta")
                                {
                                    tree.AddSingularTag("meta");
                                    i++;
                                }
                                if (tagBuilder.ToString() == "li" && html[i + 1] == 'n' && html[i + 2] == 'k')
                                {
                                    tree.AddSingularTag("link");
                                    i = i + 3;
                                }
                                else
                                {
                                    string tagContent = tagBuilder.ToString();
                                    tree.AddTag(tagContent);
                                    i++;
                                    while (i < html.Length && html[i] != '>')
                                    {
                                        attributeBuilder.Append(html[i]);

                                        i++;
                                    }
                                    string attributeContent = attributeBuilder.ToString();
                                    tree.AddAttribute(attributeContent);
                                    break;

                                }
                            }
                            else if (html[i + 1] == '<')
                            {
                                string textContent = tagBuilder.ToString();
                                tree.AddText(textContent);
                            }
                                i++;
                            
                        }
                        i = closingBracket ;
                    }

                }
                else if (!char.IsWhiteSpace(currentChar))
                {
                    StringBuilder textBuilder = new StringBuilder();
          
                    while (i < html.Length && html[i] != '<')
                    {
                        textBuilder.Append(html[i]);
                        i++;                                                                     
                    }
                    i--;
                        string textContent = textBuilder.ToString();
                        tree.AddText(textContent);
                   
                }
                i++;
            }
        }
        private bool IsValidTag(string tagContent)
        {
        return validTags.Any(validTag => string.Equals(validTag, tagContent, StringComparison.OrdinalIgnoreCase));
        }
        private string GetTagName(string tagContent)
        {
            return tree.CurrentNode.Tag;
        }

        private string GetTagAttributes()
        {
            return tree.CurrentNode.Attribute;
        }

        public string GetOutput()
        {
            return tree.GetOutput();
        }
    }
}