using Infrastructure.Enums;
using Logs.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logs.Commands
{
    //not in use!
    class ChangePropertyInAppConfig : ICommand
    {
        /// <summary>
        /// The modal that does the operation
        /// </summary>
        private IImageServiceModal modal;

        /// <param name="m">The modal.</param>
        public ChangePropertyInAppConfig(IImageServiceModal m)
        {
            modal = m;
        }
        /// <summary>
        /// Executes the specified command (by command ID).
        /// </summary>
        /// <param name="args">The arguments for the command.</param>
        /// <param name="result">if set to true if the execution was successful
        /// and false otherwise.</param>
        /// <returns>
        /// string that contains the error message or a success message
        /// </returns>
        public string Execute(string[] args, out bool result)
        {
            // The String Will Return the New Path if result = true, and will return the error message
            result = true;
            string res = null;
            //string res = this.modal.UpdateConfiguration(args);
            if (res.Equals(ResultMessgeEnum.Success))
            {
                result = true;
                return res;
            }
            else
            {
                result = false;
                return res;
            }
        }

        public string[] getArgs()
        {
            return null;
        }
    }
}
