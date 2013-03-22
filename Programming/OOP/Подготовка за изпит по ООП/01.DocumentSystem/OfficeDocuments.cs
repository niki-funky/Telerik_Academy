using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public abstract class OfficeDocuments : Encrypted
    {
        //properties
        public string Version { get; set; }

        //overriding methods
        public override void LoadProperty(string key, string value)
        {
            if (key == "version")
            {
                this.Version = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("version", this.Version));
        }
    }
}
