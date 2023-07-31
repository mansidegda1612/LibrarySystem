using ServiceStack.DataAnnotations;
using Newtonsoft.Json;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
using System;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Account
    /// </summary>
    public class lib04
    {
        #region Public Properties
        /// <summary>
        /// AccountID
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        [JsonProperty("AccountID")]
        public int b04f01 { get; set; }

        /// <summary>
        /// BookID
        /// </summary>
        [JsonProperty("BookID")]
        [Required(ErrorMessage="Enter BookID")]
        public int b04f02 { get; set; }

        /// <summary>
        /// BorrowerID
        /// </summary>
        [JsonProperty("BorrowerID")]
        [Required(ErrorMessage = "Enter BorrowerID")]
        public int b04f03 { get; set; }

        /// <summary>
        /// IssuerID
        /// </summary>
        [JsonProperty("IssuerID")]
        [Default(null)]
        public int b04f04 { get; set; }

        /// <summary>
        /// DataOfIssue
        /// </summary>
        [JsonProperty("DataOfIssue")]
        public DateTime b04f05 { get; set; }

        /// <summary>
        /// DateOfReturn
        /// </summary>
        [JsonProperty("DateOfReturn")]
        public DateTime b04f06 { get; set; }

        /// <summary>
        /// Fine
        /// </summary>
        [JsonProperty("Fine")]
        public double b04f07 { get; set; }

        #endregion
    }
}