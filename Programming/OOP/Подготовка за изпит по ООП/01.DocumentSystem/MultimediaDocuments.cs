using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public abstract class MultimediaDocuments : BinaryDocuments
    {
        //properties
        public string Length { get; set; }

        //overriding methods
        public override void LoadProperty(string key, string value)
        {
            if (key == "length")
            {
                this.Length = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("length", this.Length));
        }
    }
}
