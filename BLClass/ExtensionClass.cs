using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystem.BLClass
{
    /// <summary>
    /// ststic Class for extension methods
    /// </summary>
    public static class ExtensionClass
    {
        #region Public Methods
        /// <summary>
        /// Extension method Print of class BLCURD
        /// </summary>
        /// <param name="objBLAccount"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static string Print(this BLCURD objBLCURD,bool result)
        {
            if (result == true)
                return "Sucsessfull";
            else
                return "fail";
        }

        /// <summary>
        /// Extension method Print of class BLAccount
        /// </summary>
        /// <param name="objBLAccount"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static string Print(this BLAccount objBLAccount, bool result)
        {
            if (result == true)
                return "Sucsessfull";
            else
                return "fail";
        }

        /// <summary>
        /// Extension method Print of class BLLogin
        /// </summary>
        /// <param name="objBLLogin"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static string Print(this BLLogin objBLLogin, bool result)
        {
            if (result == true)
                return "Sucsessfull";
            else
                return "fail";
        }
        #endregion
    }
}