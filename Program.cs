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
            Parse p = new Parse();
            I.SetInput();
            I.SetTagsList();
            I.CleanSpaces(I.GetInput());
            I.CleanLines(I.GetInput());
            I.CleanTags(I.GetInput());
            p.SplitString(I.GetInput());
            foreach (object o in p.Objects)
            { Console.WriteLine(o); }
            Console.Write(I.GetInput());

            Console.WriteLine("test");


        }
    }
}