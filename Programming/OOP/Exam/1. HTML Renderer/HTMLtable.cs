using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
    public class HTMLtable : ITable
    {
        //properties
        public string Name { get; private set; }
        public string TextContent { get; set; }
        public IEnumerable<IElement> ChildElements
        {
            get
            {
                // TODO: Implement this property getter
                throw new NotImplementedException();
            }
        }
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        private IElement[,] listOfElements;

        //constructors
        public HTMLtable(int rows, int cols)
        {
            //listOfElements = new IElement[Rows, Cols]();
            this.Rows = rows;
            this.Cols = cols;
        }

        public HTMLtable(string name = null, string content = null)
        {
            this.Name = name;
            this.TextContent = content;
        }

        //indexer
        public IElement this[int row, int col]
        {
            get
            {
                return listOfElements[row, col];
            }
            set
            {

                listOfElements[row, col] = value;
            }
        }

        //methods
        public void AddElement(IElement element)
        {
            //listOfElements
        }

        public void Render(StringBuilder output)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
