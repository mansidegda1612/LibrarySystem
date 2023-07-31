using LibrarySystem.Models;
using System.Text.Json;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Reflection;

namespace LibrarySystem.BLClass
{
    /// <summary>
    /// BLClass of Account Controller
    /// </summary>
    public class BLAccount
    {
        #region Public Members
        public static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString;
        OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(ConnectionString, MySqlDialect.Provider);

        #endregion

        #region Public Methods
        BLLogin BLLogin = new BLLogin();
        /// <summary>
        /// Request To Issue Book by User
        /// </summary>
        /// <param name="objlib04"></param>
        /// <returns></returns>
        public bool RequestToIssue(lib04 objlib04)
        {
            if (!BLLogin.cache.Contains("ValidUser"))
                return false;
            using (var db = dbFactory.Open())
            {
                try
                {
                    var ans = db.Insert(objlib04);
                    if (ans > 0)
                        return true;
                    else
                        return false;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
               
            }
        }

        /// <summary>
        /// approveIssueBook
        /// </summary>
        /// <param name="bookid"></param>
        /// <param name="dataOfIssue"></param>
        /// <param name="dataOfReturn"></param>
        /// <returns></returns>
        public bool approveIssueBook(int accountID, int issuerID, DateTime dataOfIssue, DateTime dataOfReturn)
        {
            if (!BLLogin.cache.Contains("ValidLibrarian"))
                return false;
            using (var db = dbFactory.Open())
            {
                try
                { 
                    var ans = db.UpdateOnly(() => new lib04 { b04f04 = issuerID, b04f05 = dataOfIssue, b04f06 = dataOfReturn }, x => x.b04f01 == accountID);
                    if (ans > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        /// <summary>
        /// GetOnlyUnApprovedBooks
        /// </summary>
        /// <returns>List<lob04></lob04></returns>
        public List<object> GetOnlyUnApprovedBooks()
        {
            if (!BLLogin.cache.Contains("ValidLibrarian"))
                return null;
            using (var db = dbFactory.Open())
            {
                try
                {
                    var query = db.From<lib04>().Join<lib04, lib01>((x, y) => x.b04f02 == y.b01f01)
                        .Join<lib04, lib03>((x, z) => x.b04f03 == z.b03f01)
                        .Where(x => x.b04f04 == 0);
                    var ans = db.SelectMulti<lib04, lib01, lib03>(query);
                    List<object> list = new List<object>();
                    foreach (var item in ans)
                    {
                        object objItem = new
                        {
                            item.Item1.b04f01,
                            item.Item2.b01f02,
                            item.Item3.b03f02,
                        };
                        list.Add(objItem);
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// GetAccountData
        /// </summary>
        /// <returns>List<object></returns>
        public List<object> GetAccountData()
        {
            if (!BLLogin.cache.Contains("ValidLibrarian"))
                return null;
            CalculateFine();
            using (var db = dbFactory.Open())
            {
                try
                {
                    var query = db.From<lib04>().Join<lib04, lib01>((x, y) => x.b04f02 == y.b01f01)
                        .Join<lib04, lib03>((x, z) => x.b04f03 == z.b03f01)
                        .Join<lib04, lib02>((x, p) => x.b04f03 == p.b02f01);
                    var ans = db.SelectMulti<lib04, lib01, lib03, lib02>(query);
                    List<object> list = new List<object>();
                    foreach (var item in ans)
                    {
                        object objItem = new
                        {
                            item.Item1.b04f01,
                            item.Item2.b01f02,
                            item.Item3.b03f02,
                            item.Item4.b02f02,
                            item.Item1.b04f05,
                            item.Item1.b04f06,
                            item.Item1.b04f07
                        };
                        list.Add(objItem);
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }
        /// <summary>
        /// CalculateFine
        /// </summary>
        public void CalculateFine()
        {
            using (var db = dbFactory.Open())
            {
                try
                {
                    var data = db.Select<lib04>();
                    foreach (var item in data)
                    {
                        if (item.b04f06 < DateTime.Now)
                        {
                            int diff = (int)(DateTime.Now - item.b04f06).TotalDays;
                            double fine = diff * 10;
                            db.UpdateOnly(() => new lib04 { b04f07 = fine }, x => x.b04f01 == item.b04f01);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        /// <summary>
        /// GetByIssuerID
        /// </summary>
        /// <param name="issuerID"></param>
        /// <returns>List<object></returns>
        public List<object> GetByIssuerID(int issuerID)
        {
            if (!BLLogin.cache.Contains("ValidLibrarian"))
                return null;
            CalculateFine();
            using (var db = dbFactory.Open())
            {
                try
                {
                    var query = db.From<lib04>().Join<lib04, lib01>((x, y) => x.b04f02 == y.b01f01)
                        .Join<lib04, lib03>((x, z) => x.b04f03 == z.b03f01)
                        .Join<lib04, lib02>((x, p) => x.b04f03 == p.b02f01)
                        .Where(x => x.b04f04 == issuerID);
                    var ans = db.SelectMulti<lib04, lib01, lib03, lib02>(query);
                    List<object> list = new List<object>();
                    foreach (var item in ans)
                    {
                        object objItem = new
                        {
                            item.Item1.b04f01,
                            item.Item2.b01f02,
                            item.Item3.b03f02,
                            item.Item4.b02f02,
                            item.Item1.b04f05,
                            item.Item1.b04f06,
                            item.Item1.b04f07
                        };
                        list.Add(objItem);
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// GetByBorrowerID
        /// </summary>
        /// <param name="BorrowerID"></param>
        /// <returns>List<object></returns>
        public List<object> GetByBorrowerID(int BorrowerID)
        {
            if (!BLLogin.cache.Contains("ValidUser"))
                return null;
            CalculateFine();

            using (var db = dbFactory.Open())
            {
                try
                {
                    var query = db.From<lib04>().Join<lib04, lib01>((x, y) => x.b04f02 == y.b01f01)
                        .Join<lib04, lib03>((x, z) => x.b04f03 == z.b03f01)
                        .Join<lib04, lib02>((x, p) => x.b04f03 == p.b02f01)
                        .Where(x => x.b04f03 == BorrowerID);
                    var ans = db.SelectMulti<lib04, lib01, lib03, lib02>(query);
                    List<object> list = new List<object>();
                    foreach (var item in ans)
                    {
                        object objItem = new
                        {
                            item.Item1.b04f01,
                            item.Item2.b01f02,
                            item.Item3.b03f02,
                            item.Item4.b02f02,
                            item.Item1.b04f05,
                            item.Item1.b04f06,
                            item.Item1.b04f07
                        };
                        list.Add(objItem);
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }
        /// <summary>
        /// ReturnBook
        /// </summary>
        /// <returns>double</returns>
        public double ReturnBook(int accountID)
        {
            if (!BLLogin.cache.Contains("ValidUser"))
                return -1;
            CalculateFine();
            using (var db= dbFactory.Open())
            {
                try
                {
                    db.UpdateOnly(() => new lib04 { b04f06 = DateTime.Now }, x => x.b04f01 == accountID);
                    lib04 ans = db.Single<lib04>(x => x.b04f01 == accountID);
                    //Serializ data
                    string jsonString = JsonSerializer.Serialize(ans);
                    string path = "D:\\placemant\\RKIT training\\advance training\\LibrarySystem\\JsonData.txt";
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(jsonString);
                    }

                    db.DeleteById<lib04>(accountID);

                    return ans.b04f07;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return -1;
                }
            }
        }
        #endregion
    }
}