using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public class ExcelDocument : OfficeDocuments
    {
        //properties
        private string Rows { get; set; }
        private string Columns { get; set; }

        //overriding methods
        public override void LoadProperty(string key, string value)
        {
            if (key == "rows")
            {
                this.Rows = value;
            }
            else if (key == "columns")
            {
                this.Columns = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("rows", this.Rows));
            output.Add(new KeyValuePair<string, object>("columns", this.Columns));
        }
    }
}
