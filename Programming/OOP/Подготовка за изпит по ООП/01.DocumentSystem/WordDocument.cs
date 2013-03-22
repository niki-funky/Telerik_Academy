using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public class WordDocument : OfficeDocuments, IEditable
    {
        //properties
        public string Chars { get; set; }

        //methods
        public void ChangeContent(string content)
        {
            this.Content = content;
        }

        //overriding methods
        public override void LoadProperty(string key, string value)
        {
            if (key == "chars")
            {
                this.Chars = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("chars", this.Chars));
        }
    }
}
