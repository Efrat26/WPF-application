using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logs.Commands
{
    /// <summary>
    /// closing specific handler command
    /// </summary>
    /// <seealso cref="Logs.Commands.ICommand" />
    class ColseHandlerComamnd : ICommand
    {

        string[] args;
        public string Execute(string[] args, out bool result)
        {
            this.args = args;
            result = true;
            return null;
        }
        public string[] getArgs()
        {
            return this.args;
        }
    }

}
