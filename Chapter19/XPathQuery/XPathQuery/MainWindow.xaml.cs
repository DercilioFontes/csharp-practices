using System;
using System.Windows;
using System.Xml;

namespace XPathQuery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private XmlDocument document;
        public MainWindow()
        {
            InitializeComponent();
            document = new XmlDocument();
            document.Load(@"C:\Users\dfontes\Documents\training-projects\beginnigCsharp\csharp-practices\Chapter19\XML and Schemas\Elements.xml");       
            Update(document.DocumentElement.SelectNodes("."));
        }

        private void Update(XmlNodeList nodes)
        {
            if(nodes == null || nodes.Count == 0)
            {
                textBlockResult.Text = "The query yielded no results";
                return;
            }

            string text = "";
            foreach(XmlNode node in nodes)
            {
                text = FormatText(node, text, "") + "\r\n";
            }

            textBlockResult.Text = text;
        }

        private string FormatText(XmlNode node, string text, string indent)
        {
            if (node is XmlText)
            {
                text += node.Value;
                return text;
            }

            if (string.IsNullOrEmpty(indent))
            {
                indent = "";
            }
            else
            {
                text += Environment.NewLine + indent;
            }

            if (node is XmlComment)
            {
                text += node.OuterXml;
                return text;
            }

            text += "<" + node.Name;

            if (node.Attributes.Count > 0)
            {
                AddAttributes(node, ref text);
            }

            if (node.HasChildNodes)
            {
                text += ">";
                foreach (XmlNode child in node.ChildNodes)
                {
                    text = FormatText(child, text, indent + "    ");
                }

                if (node.ChildNodes.Count == 1 && (node.FirstChild is XmlText || node.FirstChild is XmlComment))
                {
                    text += "</" + node.Name + ">";
                }
                else
                {
                    text += Environment.NewLine + indent + "</" + node.Name + ">";
                }
            }
            else
            {
                text += "/>";
            }

            return text;
        }

        private void AddAttributes(XmlNode node, ref string text)
        {
            foreach (XmlAttribute xa in node.Attributes)
            {
                text += " " + xa.Name + "= " + xa.Value + "'";
            }
        }

        private void buttonExecute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlNodeList nodes = document.DocumentElement.SelectNodes(textBoxQuery.Text);
                Update(nodes);
            }
            catch (Exception ex)
            {
                textBlockResult.Text = ex.Message;
            }
        }
    }
}
