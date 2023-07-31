using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Model for Login details
    /// </summary>
    public class LoginModel
    {
        #region Public Proerties
        [Required(ErrorMessage ="Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Enter Password")]
        public string Password { get; set; }
        #endregion
    }
}