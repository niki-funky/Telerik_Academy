using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public abstract class Documents : IDocument
    {
        //properties
        public string Name { get; private set; }
        public string Content { get; protected set; }

        //methods
        public virtual void LoadProperty(string key, string value)
        {
            if (key == "name")
            {
                this.Name = value;
            }
            if (key == "content")
            {
                this.Content = value;
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("name", this.Name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        //overriding methods
        public override string ToString()
        {
            List<KeyValuePair<string, object>> properties =
                new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(properties);
            properties.Sort((x, y) => x.Key.CompareTo(y.Key));
            StringBuilder sb = new StringBuilder();
            sb.Append(this.GetType().Name);
            sb.Append("[");
            bool first = true;
            if (!Utilities.isEncrypted(this))
            {
                foreach (var item in properties)
                {
                    if (item.Value != null)
                    {
                        if (!first)
                        {
                            sb.Append(";");
                        }
                        sb.Append(item.Key + "=" + item.Value);
                        first = false;
                    }
                }
            }
            else
            {
                sb.Append("encrypted");
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
