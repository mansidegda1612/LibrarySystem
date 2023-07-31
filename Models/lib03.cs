using ServiceStack.DataAnnotations;
using Newtonsoft.Json;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
using StringLengthAttribute = System.ComponentModel.DataAnnotations.StringLengthAttribute;

namespace LibrarySystem.Models
{
    /// <summary>
    /// User
    /// </summary>
    public class lib03
    {
        #region Public Properties
        /// <summary>
        /// UserID
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        [JsonProperty("UserID")]
        public int b03f01 { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        [Required(ErrorMessage = "Enter LibrarianName")]
        [JsonProperty("UserName")]
        public string b03f02 { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        [JsonProperty("Gender")]
        public string b03f03 { get; set; }

        /// <summary>
        /// MobileNumber
        /// </summary>
        [JsonProperty("MobileNumber")]
        [Required(ErrorMessage = "Enter Mobile Number")]
        [StringLength(10,ErrorMessage = "Enter Valid Mobile Number")]
        public string b03f04 { get; set; }


        /// <summary>
        /// Address
        /// </summary>
        [JsonProperty("Address")]
        public string b03f05 { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Enter Email")]
        [JsonProperty("Email")]
        public string b03f06 { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = "Enter Password")]
        [JsonProperty("Password")]
        public string b03f07 { get; set; }

        #endregion
    }
}