using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public class PDFDocument : Encrypted
    {
        //properties
        private string Pages { get; set; }

        //overriding methods
        public override void LoadProperty(string key, string value)
        {
            if (key == "pages")
            {
                this.Pages = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("pages", this.Pages));
        }
    }
}
