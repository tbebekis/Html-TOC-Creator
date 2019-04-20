using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
//using System.Windows.Forms;

using HtmlAgilityPack;

namespace HtmlTocCreator
{
    /// <summary>
    /// Represents a TOC node
    /// </summary>
    class Node
    {
        /* construction */
        public Node(Node Parent, HtmlNode HtmlNode)
        {
            this.Parent = Parent;
            this.HtmlNode = HtmlNode;

            if (Parent != null)
                Parent.Items.Add(this);

            if (HtmlNode != null)
            {
                this.HeaderLevel = GetHeaderLevel(HtmlNode);
                this.Text = HtmlNode.InnerText;
            }

            if (IsRoot)
                this.FlatList = new List<Node>();

            if (Root != null && !IsRoot)
                Root.FlatList.Add(this);
        }

        /* overrides */
        public override string ToString()
        {  
            return IsRoot? "TOC": string.Format("{0}. {1}", Level, HtmlNode.InnerHtml);
        }

        /* public */
        static public int GetHeaderLevel(HtmlNode HtmlNode)
        {
            int Result = 0;

            if (HtmlNode != null)
            {
                if (HtmlNode.Name.Length == 2 && HtmlNode.Name.ToLowerInvariant().StartsWith("h"))
                {
                    Result = Convert.ToInt32(HtmlNode.Name[1].ToString());
                }
                else
                {
                    throw new ApplicationException("Can not get header level");
                }
            }

            return Result;
        }
        public string GetName()
        {
            if (IsRoot)
                return "TOC";

            string S = Parent.IsRoot? "": Parent.GetName() + "."; 
            S = string.Format("{0}{1}", S, Parent.Items.IndexOf(this) + 1);
            return S;
        }
        public void AddChildren(List<HtmlNode> FlatList, HtmlNode CurrentNode, int CurrentIndex)
        {
            Node Node;
            int CurrentLevel = GetHeaderLevel(CurrentNode);
            if (CurrentLevel > HeaderLevel)
            {
                Node = new Node(this, CurrentNode); 

                if (CurrentIndex >= FlatList.Count - 1)
                {
                    return;
                }

                CurrentIndex++;
                CurrentNode = FlatList[CurrentIndex];
                Node.AddChildren(FlatList, CurrentNode, CurrentIndex);
            }
            else if (CurrentLevel <= this.HeaderLevel)
            {
                if (Parent == null)
                    throw new ApplicationException("No parent");

                Parent.AddChildren(FlatList, CurrentNode, CurrentIndex);
            }
        }

        /* properties */
        public bool IsRoot { get { return Level == 0; } }
        public Node Root
        {
            get
            {
                Node Current = this;
                Node CurrentParent = Parent;

                while (CurrentParent != null)
                {
                    Current = CurrentParent;
                    CurrentParent = Current.Parent;
                }

                return Current;
            }
        }
        public Node Parent { get; private set; }
        public HtmlNode HtmlNode { get; private set; }
        public List<Node> Items { get; } = new List<Node>();
        public int Level { get { return Parent == null ? 0 : Parent.Level + 1; } }
        public int HeaderLevel { get; private set; } = 0;
        public string Text { get; private set; }
        public List<Node> FlatList { get; }
    }
}
