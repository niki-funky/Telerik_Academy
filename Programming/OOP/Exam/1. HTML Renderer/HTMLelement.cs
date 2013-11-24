using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
    public class HTMLelement : IElement
    {
        public string Name { get; protected set; }
        public string TextContent { get; set; }
        private IEnumerable<IElement> childElements;

        public HTMLelement(string name = null, string content = null)
        {
            this.Name = name;
            this.TextContent = content;
        }

        public IEnumerable<IElement> ChildElements
        {
            get
            {
                return this.childElements;
            }
        }

        public void AddElement(IElement element)
        {
            (childElements as List<IElement>).Add(element);
        }

        public void Render(StringBuilder output)
        {
            output.Append("<" + this.Name + ">");
            output.Append(this.TextContent);
            output.Append("<" + this.Name + ">");
        }

        public override string ToString()
        {
            return this.ToString();
        }
    }
}
