using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibrarySystem.Models;
using LibrarySystem.BLClass;
using System.Web.Http.Cors;

namespace LibrarySystem.Controllers
{
    /// <summary>
    /// Controller for Keep Track of Book
    /// </summary>
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountController : ApiController
    {
        #region Public Methods

        BLAccount objBLAccount = new BLAccount();
        /// <summary>
        /// Request To Issue Book by User
        /// </summary>
        /// <param name="objlib04"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string RequestToIssue(lib04 objlib04)
        {
            return objBLAccount.Print(objBLAccount.RequestToIssue(objlib04));
        }

        /// <summary>
        /// approveIssueBook
        /// </summary>
        /// <param name="bookid"></param>
        /// <param name="dataOfIssue"></param>
        /// <param name="dataOfReturn"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string approveIssueBook(int accountID,int isserID , DateTime dataOfIssue, DateTime dataOfReturn)
        {
            return objBLAccount.Print( objBLAccount.approveIssueBook(accountID, isserID, dataOfIssue, dataOfReturn));
        }

        /// <summary>
        /// GetOnlyUnApprovedBooks
        /// </summary>
        /// <returns>List<dynamic></returns>
        public List<object> GetOnlyUnApprovedBooks()
        {
            return objBLAccount.GetOnlyUnApprovedBooks();
        }

        /// <summary>
        /// GetAccountData
        /// </summary>
        /// <returns>List<object></returns>
        public List<object> GetAccountData()
        {
            return objBLAccount.GetAccountData();
        }

        /// <summary>
        /// GetByIssuerID
        /// </summary>
        /// <param name="issuerID"></param>
        /// <returns>List<object></returns>
        public List<object> GetByIssuerID(int issuerID)
        {
            return objBLAccount.GetByIssuerID(issuerID);
        }

        /// <summary>
        /// GetByBorrowerID
        /// </summary>
        /// <param name="BorrowerID"></param>
        /// <returns>List<object></returns>
        public List<object> GetByBorrowerID(int BorrowerID)
        {
            return objBLAccount.GetByBorrowerID(BorrowerID);
        }

        /// <summary>
        /// ReturnBook
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns>string</returns>
        [HttpPost]
        public string ReturnBook(int accountID)
        {
            
            double fine = objBLAccount.ReturnBook(accountID);
            if (fine >=0)
            {
                return "pay rs "+ fine+" Fine";
            }
            else
            {
                return "Fail";
            }
        }
        #endregion
    }
}
