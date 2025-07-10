using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBancoCLI.Util.Exceptions {
    public class ExistingUserException : Exception{

        public ExistingUserException(string message) : base(message) { }

    }
}
