using System;
using System.Windows;
using System.Xml;

namespace LookThroughXmlDocument
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ghostStories = @"C:\Users\dfontes\Documents\training-projects\beginnigCsharp\csharp-practices\Chapter19\XML and Schemas\GhostStories.xml";
        private const string elements = @"C:\Users\dfontes\Documents\training-projects\beginnigCsharp\csharp-practices\Chapter19\XML and Schemas\Elements.xml";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonLoop_Click(object sender, RoutedEventArgs e)
        {
            textBlockResults.Text = string.Empty;
            XmlDocument document = new XmlDocument();
            document.Load(ghostStories);
            textBlockResults.Text = FormatText(document.DocumentElement as XmlNode, "", "");
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

        private void buttonCreateNode_Click(object sender, RoutedEventArgs e)
        {
            // Load the XML document.
            XmlDocument document = new XmlDocument();
            document.Load(ghostStories);

            // Get the root element
            XmlElement root = document.DocumentElement;

            // Create the new nodes.
            XmlElement newStory = document.CreateElement("story");
            XmlElement newTitle = document.CreateElement("title");
            XmlElement newAuthor = document.CreateElement("author");
            XmlElement newAuthorName = document.CreateElement("name");
            XmlElement newAuthorNationality = document.CreateElement("nationality");
            XmlElement newRating = document.CreateElement("rating");

            XmlText title = document.CreateTextNode("The Haunting of Hill House");
            XmlText name = document.CreateTextNode("Shirley Jackson");
            XmlText nationality = document.CreateTextNode("American");
            XmlText rating = document.CreateTextNode("gothic horror");

            XmlComment comment = document.CreateComment("3.8/5 · Goodreads");

            // Insert the elements
            newStory.AppendChild(comment);
            newStory.AppendChild(newTitle);
            newTitle.AppendChild(title);
            newStory.AppendChild(newAuthor);
            newAuthor.AppendChild(newAuthorName);
            newAuthorName.AppendChild(name);
            newAuthor.AppendChild(newAuthorNationality);
            newAuthorNationality.AppendChild(nationality);
            newStory.AppendChild(newRating);
            newRating.AppendChild(rating);
            root.InsertAfter(newStory, root.LastChild);
            document.Save(ghostStories);

        }

        private void buttonDeleteNode_Click(object sender, RoutedEventArgs e)
        {
            // Load the XML document
            XmlDocument document = new XmlDocument();
            document.Load(ghostStories);

            // Get the root element
            XmlElement root = document.DocumentElement;

            // Find the node. root is the <stories> tag, so its last child 
            if (root.HasChildNodes)
            {
                XmlNode story = root.LastChild;

                // Delete the child
                root.RemoveChild(story);

                // Save the document back to disk
                document.Save(ghostStories);
            }
        }

        private void buttonXMLtoJSON_Click(object sender, RoutedEventArgs e)
        {
            // Load the XML document
            XmlDocument document = new XmlDocument();
            document.Load(ghostStories);

            string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(document);
            textBlockResults.Text = json;
        }
    }
}
