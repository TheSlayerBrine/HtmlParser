using HtmlParser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace HtmlParser
{
    public class TreeNode
    {
        public string Tag { get; set; }
        public string Attribute { get; set; }
        public string Text { get; set; }
        public TreeNode Parent { get; set; }
        public List<TreeNode> Children { get; set; }

        public TreeNode(string tag, string text)
        {
            Tag = tag;
            Text = text;
            Parent = null;
            Children = new List<TreeNode>();
        }
        public TreeNode(string tag)
        {
            Tag = tag;
            Parent = null;
            Children = new List<TreeNode>();
        }
        public void AddChild(TreeNode child)
        {
            child.Parent = this;
            Children.Add(child);
        }
    }

    public class Tree
    {
        public TreeNode? Root { get; set; }
        public TreeNode? CurrentNode { get; set; }

        public Tree()
        {
            Root = new TreeNode("", "");
            CurrentNode = Root;
            CurrentNode.Parent = null;
            Root.Parent = null;
        }
        public void AddAttribute(string attributeName)
        {
            CurrentNode.Attribute = attributeName;
        }
        public void AddTag(string tag)
        {
          

            var newNode = new TreeNode(tag);
           
                CurrentNode.Children.Add(newNode);
            var child = CurrentNode.Children.Last();
            child.Parent = CurrentNode;
            CurrentNode = child;

        }
        public void AddSingularTag(string tag)
        {
            var newNode = new TreeNode(tag);
            CurrentNode.Children.Add(newNode);
        }
        public void AddText(string text)
        {
            CurrentNode.Text += text;
        }
        public void MoveToParent()
        {
            if (CurrentNode != Root)
            {
                CurrentNode = CurrentNode.Parent;
            }
        }

        public string GetOutput()
        {
            var output = "";
            CurrentNode = Root;

            Stack<TreeNode> s = new Stack<TreeNode>();
            s.Push(CurrentNode);
            s.Reverse();
            while (s.Count != 0)
            {
                
                TreeNode Current = s.Pop();
                output += Current.Text;
                output += "\n";
            var ListOfChildren = (from  child in Current.Children where child != null select child).ToList();
                ListOfChildren.Reverse();
                foreach (var child in ListOfChildren)
                {
                    if (child != null)
                        s.Push(child);                  
                }
            }
            return output;
        }
    }
}