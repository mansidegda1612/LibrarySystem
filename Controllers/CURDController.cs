using LibrarySystem.BLClass;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LibrarySystem.Controllers
{
    /// <summary>
    /// Controller for CURD opration
    /// </summary>
    [Authorize(Roles = "Librarian")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CURDController : ApiController
    {
        #region Public Methods

        BLCURD objBLCURD = new BLCURD();

        /// <summary>
        /// SelectAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public List<lib01> SelectAll()
        {
            return objBLCURD.SelectAll();
        }

        /// <summary>
        /// SelectById
        /// </summary>
        /// <param name="id">BookID</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public List<lib01> SelectById(int id)
        {
            return objBLCURD.SelectById(id);
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="obj">Object of Model</param>
        /// <returns>string</returns>
        [HttpPost]
        public string Insert([FromBody] lib01 objlib01)
        {
            return objBLCURD.Print(objBLCURD.Insert(objlib01));
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="obj">Object of Model</param>
        /// <returns>string</returns>
        [HttpPost]
        public string Update([FromBody] lib01 objlib01)
        {
            return objBLCURD.Print(objBLCURD.Update(objlib01));
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">BookId</param>
        /// <returns>string</returns>
        [HttpDelete]
        public string Delete(int id)
        {
            return objBLCURD.Print(objBLCURD.Delete(id));
        }
        #endregion

    }
}
