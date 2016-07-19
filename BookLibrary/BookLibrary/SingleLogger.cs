using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace BookLibrary
{
    /// <summary>
    /// This is common class for writting messages to log.
    /// </summary>
    public static class SingleLogger
    {
        /// <summary>
        /// This is common log for application.
        /// </summary>
        public static readonly Logger log = LogManager.GetCurrentClassLogger();
    }
}
