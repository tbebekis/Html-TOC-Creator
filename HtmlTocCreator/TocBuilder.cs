using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
 
using System.Threading.Tasks;
//using System.Windows.Forms;

using HtmlAgilityPack;
using AngleSharp;
using AngleSharp.Html;
using AngleSharp.Html.Parser;
 

namespace HtmlTocCreator
{
    /// <summary>
    /// Html TOC Generator
    /// </summary>
    class TocBuilder
    {
        /* private */
        HtmlAgilityPack.HtmlDocument Doc;
        Node Root;
        List<HtmlNode> HeaderList;
        string[] HeaderNames = { "h1", "h2", "h3", "h4", "h5", "h6" };

        /// <summary>
        /// Returns the first header element, if any, else null.
        /// </summary>
        HtmlNode GetFirstHeader()
        {
            HtmlNode Result = null;
            string[] XPaths = { "//h1", "//h2", "//h3", "//h4", "//h5" };

            foreach (var Item in XPaths)
            {
                Result = Doc.DocumentNode.SelectSingleNode(Item);
                if (Result != null)
                    break;
            }

            return Result;
        }
        /// <summary>
        /// Returns the next header element, if any, else null.
        /// </summary>
        HtmlNode GetNextHeader(HtmlNode HtmlNode)
        {
            string Name;
            HtmlNode sibling = HtmlNode.NextSibling;
            int Index;
            while (sibling != null)
            {
                if (sibling.NodeType == HtmlNodeType.Element)
                {
                    Name = sibling.Name.ToLowerInvariant();
                    Index = Array.FindIndex(HeaderNames, item => item == Name);
                    if (Index >= 0)
                    {
                        return sibling;
                    }
                }

                sibling = sibling.NextSibling;
            }

            return null;
        }
        /// <summary>
        /// This function creates an indented format of HTML with new lines for all elements and text.  Errors result in the original text being returned.
        /// <para>FROM: https://stackoverflow.com/questions/18077026/format-html-code-from-a-string </para>
        /// </summary>
        static string FormatHtml(string content)
        {
            string original = content;
            string open = "<";
            string slash = "/";
            string close = ">";

            int depth = 0; // the indentation
            int adjustment = 0; //adjustment to depth, done after writing text

            int o = 0; // open      <   index of this character
            int c = 0; // close     >   index of this character
            int s = 0; // slash     /   index of this character
            int n = 0; // next      where to start looking for characters in the next iteration
            int b = 0; // begin     resolved start of usable text
            int e = 0; // end       resolved   end of usable test

            string snippet;

            try
            {
                using (StringWriter writer = new StringWriter())
                {
                    while (b > -1 && n > -1)
                    {
                        o = content.IndexOf(open, n);
                        s = content.IndexOf(slash, n);
                        c = content.IndexOf(close, n);
                        adjustment = 0;

                        b = n; // begin where we left off in the last iteration
                        if (o > -1 && o < c && o == n)
                        {
                            // starts with "<tag>text"
                            e = c; // end at the next closing tag
                            adjustment = 2; //for after this node
                        }
                        else
                        {
                            // starts with "text<tag>"
                            e = o - 1; // end at the next opening tag
                        }

                        if (b == o && b + 1 == s) // ?Is the 2nd character a slash, this the a closing tag: </div>
                        {
                            depth -= 2;//adjust immediately, not afterward ...for closing tag
                            adjustment = 0;
                        }

                        if ((s + 1) == c && c == e) // don't adjust depth for singletons:  <br/>
                        {
                            adjustment = 0;
                        }



                        //string traceStart = content.Substring(0, b);
                        int length = (e - b + 1);
                        if (length < 0)
                        {
                            snippet = content.Substring(b); // happens on the final iteration
                        }
                        else
                        {
                            snippet = content.Substring(b, (e - b + 1));
                        }
                        //string traceEnd = content.Substring(b);


                        if (snippet == "<br>" || snippet == "<hr>") // don't adjust depth for singletons which lack slashes: <br>
                        {
                            adjustment = 0;
                        }

                        //Write the text
                        if (!string.IsNullOrEmpty(snippet.Trim()))
                        {
                            //Debug.WriteLine(snippet);
                            writer.Write(Environment.NewLine);
                            if (depth > 0) writer.Write(new String(' ', depth)); // add the indentation 
                            writer.Write(snippet);
                        }

                        depth += adjustment; //adjust for the next line which is likely nested

                        n = e + 1; // the next iteration start at the end of this one.

                    }

                    return writer.ToString();
                }
            }
            catch
            {
                // Log("Unable to format html. " + ex.Message);
                return original;
            }



        }
        string ListTag()
        {
            return UnorderedLists ? @"<ul></ul>" : @"<ol></ol>";
        }
        /// <summary>
        /// Adds a specified node to TOC
        /// </summary>
        void AddToToc(HtmlNode OL, Node Node)
        {
            HtmlNode LI = HtmlNode.CreateNode("<li></li>");
            OL.AppendChild(LI);

            string S = string.Format(@"<a href='#section{0}' >{1}</a>", Node.GetName(), Node.Text);
            HtmlNode Link = HtmlNode.CreateNode(S);
            LI.AppendChild(Link);

            if (Node.Items.Count > 0)
            {
                HtmlNode OL2 = HtmlNode.CreateNode(ListTag());
                LI.AppendChild(OL2);

                foreach (Node Child in Node.Items)
                {
                    AddToToc(OL2, Child);
                }
            }
        }
        /// <summary>
        /// Generates the TOC
        /// </summary>
        void GenerateToc()
        {
            HtmlText = "";

            string sXPath = @"//*[@id='TOC']";
            HtmlNode TocNode = Doc.DocumentNode.SelectSingleNode(sXPath);

            if (TocNode == null)
                throw new ApplicationException("Element with Id = TOC not found.");

            TocNode.InnerHtml = "";

            HtmlNode OL = HtmlNode.CreateNode(ListTag());
            TocNode.AppendChild(OL);


            foreach (Node Child in Root.Items)
            {
                AddToToc(OL, Child);
            }

            // <h2> <a name = "A first application" ></a> A first application </h2>

            string InnerHtml;
            string Format = @"<a name='section{0}'></a>{1}";
            foreach (var Node in Root.FlatList)
            {
                InnerHtml = string.Format(Format, Node.GetName(), Node.Text);
                Node.HtmlNode.InnerHtml = InnerHtml;
            }


            HtmlText = Doc.DocumentNode.OuterHtml;

            bool Error = false;
            try
            {
                HtmlText = System.Xml.Linq.XElement.Parse(HtmlText).ToString();
            }
            catch // isn't well-formed xml
            {
                Error = true;
            }

            if (Error)
            {
                try
                {
                    var parser = new HtmlParser();
                    var document = parser.ParseDocument(HtmlText);
                    using (var writer = new StringWriter())
                    {
                        document.ToHtml(writer, new PrettyMarkupFormatter
                        {
                            Indentation = "    ", //"\t",
                            NewLine = Environment.NewLine
                        });
                        HtmlText = writer.ToString();
                        Error = false;
                    }
                }
                catch
                {
                }
            }

            if (Error)
            {
                try
                {
                    HtmlText = FormatHtml(HtmlText);
                }
                catch // isn't well-formed xml
                {
                }
            }



        }

        /* construction */
        /// <summary>
        /// Constructor
        /// </summary>
        public TocBuilder()
        {
        }
 
        /* public */
        /// <summary>
        /// Loads builder from Html text.
        /// </summary>
        public void LoadFromText(string HtmlText)
        {
            this.HtmlText = HtmlText;
            Doc = new HtmlAgilityPack.HtmlDocument();
            Doc.LoadHtml(HtmlText);
            //Doc.OptionFixNestedTags = true;
        }
        /// <summary>
        /// Loads builder from an Html file. Returns the content of the file.
        /// </summary>
        public string LoadFromFile(string FilePath)
        {
            string HtmlText = File.ReadAllText(FilePath);
            LoadFromText(HtmlText);
            return HtmlText;
        }
        /// <summary>
        /// Saves the generated Html text to an Html file.
        /// </summary>
        public void SaveToFile(string FilePath)
        {
            File.WriteAllText(FilePath, HtmlText);
        }

        /// <summary>
        /// Generates the TOC and returns the root node
        /// </summary>
        public Node Build()
        {     
            Root = new Node(null, null);
            HeaderList = new List<HtmlNode>();
           

            HtmlNode FirstHeader = GetFirstHeader();

            if (FirstHeader == null)
                throw new ApplicationException("No suitable top header node found.");

            HeaderList.Add(FirstHeader);
            HtmlNode Header = GetNextHeader(FirstHeader);

            while (Header != null)
            {
                HeaderList.Add(Header);
                Header = GetNextHeader(Header);
            }

            Node FirstNode = new Node(Root, FirstHeader);
            if (HeaderList.Count > 1)
            {
                FirstNode.AddChildren(HeaderList, HeaderList[1], 1);
            }

            GenerateToc();

            return Root;
        }
 
        /* properties */
        /// <summary>
        /// The Html text.
        /// </summary>
        public string HtmlText { get; private set; }
        /// <summary>
        /// Controls the TOC list mode
        /// </summary>
        public bool UnorderedLists { get; set; }
    }
}
