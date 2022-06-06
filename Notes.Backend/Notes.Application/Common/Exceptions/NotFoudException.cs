using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Common.Exceptions
{
    public class NotFoudException : Exception
    {
        public NotFoudException(string name, object key) : base($"Entity \"{name}\" ({key}) not found.") { }
    }
}
