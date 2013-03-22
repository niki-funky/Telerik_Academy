using System;
using System.Linq;

namespace DocumentSystem
{
    public abstract class Encrypted : BinaryDocuments, IEncryptable
    {
        //properties
        public bool IsEncrypted { get; private set; }

        //methods
        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }
    }
}
