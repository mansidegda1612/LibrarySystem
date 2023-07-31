using System.Web.Http;
using System.Web.Http.Cors;
using LibrarySystem.BLClass;
using LibrarySystem.Models;

namespace LibrarySystem.Controllers
{
    /// <summary>
    /// Contoller for login
    /// </summary>
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        #region Public Methods
        BLLogin ObjBLLogin = new BLLogin();
        /// <summary>
        /// Login for user or Librarian
        /// </summary>
        /// <param name="person">person</param>
        /// <param name="objLoginModel"></param>
        /// <returns>string</returns>
        public string Login(string person, LoginModel objLoginModel)
        {
            if (person == "Librarian")
            {
                return ObjBLLogin.LoginLibrarian(objLoginModel);
            }
            else if(person=="User")
            {
                return ObjBLLogin.LoginUser(objLoginModel);
            }
            else
            {
                return "Select Librarian/User";
            }

        }
        /// <summary>
        /// SignUp for Librarian
        /// </summary>
        /// <param name="objlib02"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string SignUpLibrarian(lib02 objlib02)
        {
            return ObjBLLogin.Print(ObjBLLogin.SignUpLibrarian(objlib02));
        }
        /// <summary>
        /// SignUp for User
        /// </summary>
        /// <param name="objlib03"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string SignUpUser(lib03 objlib03)
        {
            return ObjBLLogin.Print(ObjBLLogin.SignUpUser(objlib03));
        }

        #endregion
    }
}
