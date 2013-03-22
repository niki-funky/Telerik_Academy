using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public class AudioDocument : MultimediaDocuments
    {
        //properties
        public string SampleRate { get; set; }

        //overriding methods
        public override void LoadProperty(string key, string value)
        {
            if (key == "samplerate")
            {
                this.SampleRate = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
        }
    }
}
