using ServiceStack.DataAnnotations;
using Newtonsoft.Json;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
using StringLengthAttribute = System.ComponentModel.DataAnnotations.StringLengthAttribute;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Librarian
    /// </summary>
    public class lib02
    {
        #region Public Properties
        /// <summary>
        /// LibrarianID
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        [JsonProperty("LibrarianID")]
        public int b02f01 { get; set; }

        /// <summary>
        /// LibrarianName
        /// </summary>
        [Required(ErrorMessage = "Enter LibrarianName")]
        [JsonProperty("LibrarianName")]
        public string b02f02 { get; set; }

        /// <summary>
        /// MobileNumber
        /// </summary>
        [JsonProperty("MobileNumber")]
        [Required(ErrorMessage = "Enter Mobile Number")]
        [StringLength(10,ErrorMessage="Enter Valid Mobile Number")]
        public string b02f03 { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Enter Email")]
        [JsonProperty("Email")]
        public string b02f04 { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        [JsonProperty("Gender")]
        public string b02f05 { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = "Enter Password")]
        [JsonProperty("Password")]
        public string b02f06 { get; set; }

        #endregion
    }
}