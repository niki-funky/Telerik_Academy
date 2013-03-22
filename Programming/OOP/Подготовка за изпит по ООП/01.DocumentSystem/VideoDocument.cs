using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public class VideoDocument : MultimediaDocuments
    {
        //properties
        public string FrameRate { get; private set; }

        //overriding methods
        public override void LoadProperty(string key, string value)
        {
            if (key == "framerate")
            {
                this.FrameRate = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
        }
    }
}
