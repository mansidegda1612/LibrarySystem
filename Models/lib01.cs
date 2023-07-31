
using ServiceStack.DataAnnotations;
using Newtonsoft.Json;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Book
    /// </summary>
    public class lib01
    {
        #region Public Properties
        /// <summary>
        /// BookID
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        [JsonProperty("BookID")]
        public int b01f01 { get; set; }

        /// <summary>
        /// BookName
        /// </summary>
        [Required(ErrorMessage = "Enter BookName")]
        [JsonProperty("BookName")]
        public string b01f02 { get; set; }

        /// <summary>
        /// Discription
        /// </summary>
        [JsonProperty("Discription")]
        public string b01f03 { get; set; }

        /// <summary>
        /// AuthorName
        /// </summary>
        [JsonProperty("AuthorName")]
        public string b01f04 { get; set; }

        /// <summary>
        /// ImagePath
        /// </summary>
        [JsonProperty("ImagePath")]
        public string b01f05 { get; set; }

        #endregion
    }
}