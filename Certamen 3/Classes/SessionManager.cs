using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certamen_3.Classes
{
    internal class SessionManager
    {
        public static string CurrentUserId { get; set; }
        public static string CurrentUsername { get; set; }

        public static void ClearSession()
        {
            CurrentUserId = null;
            CurrentUsername = null;
        }
    }
}
