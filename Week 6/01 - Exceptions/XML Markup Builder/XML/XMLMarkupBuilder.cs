using System;
using System.Collections.Generic;
using System.Text;

// If the indentation has to be changed/modified -> reconfigure the indentation string in OpenTag(), AddText() and CloseTag()

namespace XML
{
    public class XMLMarkupBuilder
    {
        private List<StringBuilder> result = new List<StringBuilder>();
        public Stack<string> tags = new Stack<string>();
        public Stack<int> tagLines = new Stack<int>();

        public bool IsFinilized { get; private set; } = false;

        public XMLMarkupBuilder OpenTag(string tagName)
        {
            if (IsFinilized)
                throw new XMLFileAlreadyFinalizedException();

            if (result.Count != 0 && !result[result.Count - 1].ToString().Contains("<"))
                throw new ApplicationException("Cannot nest a tag inside of a tag with text already added to it!");

            string indentation = new string(' ', 3 * tags.Count);
            result.Add(new StringBuilder().Append(indentation + "<" + tagName + ">"));
            tags.Push(tagName);
            tagLines.Push(result.Count - 1);

            return this;
        }

        public XMLMarkupBuilder AddAttr(string attrName, string attrValue)
        {
            if (result.Count == 0)
                throw new XMLAddAttributeException();
            else if (IsFinilized)
                throw new XMLFileAlreadyFinalizedException();

            string attribute = " " + attrName + "=\"" + attrValue + "\"";
            result[tagLines.Peek()].Replace(">", attribute + ">");

            return this;
        }

        public XMLMarkupBuilder AddText(string text)
        {
            if (result.Count == 0)
                throw new XMLAddTextException();
            else if (IsFinilized)
                throw new XMLFileAlreadyFinalizedException();

            if (text.Contains("<"))
                throw new FormatException("An XML element cannot contain the symbol \"<\"!");

            string indentation = new string(' ', 3 * tags.Count);
            result.Add(new StringBuilder().Append(indentation + text));
            return this;
        }

        public XMLMarkupBuilder CloseTag()
        {
            if (result.Count == 0)
                throw new XMLNoTagOpenedException();
            else if (IsFinilized)
                throw new XMLFileAlreadyFinalizedException();

            string indentation = new string(' ', 3 * (tags.Count - 1));
            result.Add(new StringBuilder().Append(indentation + "</" + tags.Pop() + ">"));
            tagLines.Pop();

            if (tags.Count == 0)
            {
                ReplaceEntityReferences();
                IsFinilized = true;
            }
            return this;
        }

        public XMLMarkupBuilder Finish()
        {
            if (IsFinilized)
                throw new XMLFileAlreadyFinalizedException();

            while(tags.Count != 0)
                CloseTag();

            ReplaceEntityReferences();
            IsFinilized = true;      
            return this;
        }
        
        private void ReplaceEntityReferences()
        {
            for (int i = 0; i < result.Count; i++)
            {
                result[i].Replace("&lt;", "<");
                result[i].Replace("&gt;", ">");
                result[i].Replace("&amp;", "&");
                result[i].Replace("&apos;", "'");
                result[i].Replace("&quot;", "\"");
            }
        }

        public string GetResult()
        {
            StringBuilder xmlFile = new StringBuilder();
            xmlFile.AppendLine("<?xml version=\"1.0\" encoding=\"UTF - 8\"?>");

            foreach (var line in result)
                xmlFile.AppendLine(line.ToString());

            return xmlFile.ToString();
        }

    }
}