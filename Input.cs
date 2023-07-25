using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class Input
{
    private readonly string path = @"C:\Users\cgame\source\repos\Task-HtmlParser\HtmlParser\Input.html";
    private string input;
    private string tagList;
    private List<string> tags;

    public void SetTagsList()
    {
        this.tagList = File.ReadAllText("C:\\Users\\cgame\\source\\repos\\Task-HtmlParser\\HtmlParser\\DoubleTags.txt");
        this.tags = tagList?.Split(',').Select(tag => tag.Trim()).ToList();
    }

    public void SetInput()
    {
        this.input = File.ReadAllText(path);
    }

    public string GetInput()
    {
        return this.input;
    }

    public void CleanSpaces()
    {
        this.input = Regex.Replace(this.input, @"[^\S\r\n]+", " ");
    }

    public void CleanLines()
    {
        this.input = Regex.Replace(this.input, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
    }

    public class TagFormatter
    {
        public string FormatOpeningTag(string tag)
        {
            return "<" + tag.Trim() + ">";
        }

        public string FormatClosingTag(string tag)
        {
            return "</" + tag.Trim() + ">";
        }
    }
}