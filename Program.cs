using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlParser
{
    class Program
    {
        public static void Main(string[] args)
        {
            Input I = new Input();
            
            I.SetInput();
            I.SetTagsList();
            I.CleanSpaces();
            I.CleanLines();
            Console.Write(I.GetInput());

            var html = I.GetInput().ToString();
            var validTags = new List<string> { "html", "head", "title", "body", "h1", "h2", "p",  "title","li","a","header","main","p","h3","article","aside","ul","footer", "div", "nav" };
            var validSingTags = new List<string> { "meta", "link"  };
            string formattedHtml = HtmlFormatter.FormatTags(html);


              var parser = new HtmlParse(validTags);
              parser.ParseHtml(formattedHtml);
              var output = parser.GetOutput();
              var filePath = "C:\\Users\\cgame\\source\\repos\\Task-HtmlParser\\HtmlParser\\output.txt";
              var fileWriter = new Output(filePath);
              fileWriter.WriteToFile(output);
              fileWriter.WriteToFile("test");
            Console.WriteLine(output);
            Console.WriteLine("Output written to file: " + filePath);

            /* var tree = new Tree();

             tree.AddTag("html", "1");
             tree.AddTag("head", "2");
             tree.AddTag("title", "3");
             tree.AddTag("body", "4");
             tree.AddTag("h1", "5");                                          
             Console.Write(tree.GetOutput());*/



        }
    }
}