using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

public class Input
{
    private readonly string path = @"C:\Users\cgame\source\repos\Task-HtmlParser\HtmlParser\Input.html";
    private string input;
    string taglist = File.ReadAllText(@"C:\Users\cgame\source\repos\Task-HtmlParser\HtmlParser\Tags.txt");
    public List<string> tags;
    public void SetTagsList()
    {
        this.tags = taglist?.Split(',').ToList(); 
    }
    public void SetInput()
    {
        this.input = File.ReadAllText(path);
    }
    public string GetInput()
    { return this.input; }
    public void CleanSpaces(string input)
    {
       
       this.input = Regex.Replace(input, @"[^\S\r\n]+", " ");
      
    }
    public void CleanLines(string input)
    { this.input = Regex.Replace(input, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline); 
    }
    public void CleanTags(string input)
    {
        for(int i=0; i< this.input.Length; i++) 
        {
            if (this.input[i] == '<' && this.input[i + 1] == ' ')
             this.input = this.input.Remove(i + 1, 1);
            if (this.input[i] == '<' && this.input[i + 1] == '/' && this.input[i + 2] == ' ')
                this.input = this.input.Remove(i + 2, 1);
            if (this.input[i] == ' ' && this.input[i + 1] == '>')
                this.input = this.input.Remove(i, 1);
        }
    }
}
