using System;

namespace OrganizerClassLibrary
{
    public class OrganizerException : ApplicationException
    {
        //constructors
        public OrganizerException() {}

        public OrganizerException(string message)
            : base(Utilities.RedMessage(message))
        {
        }

        public OrganizerException(string message, Exception ex)
            : base(Utilities.RedMessage(message), ex)
        {
        }
    }
}
