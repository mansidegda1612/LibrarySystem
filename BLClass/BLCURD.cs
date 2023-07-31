using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibrarySystem.Models;

namespace LibrarySystem.BLClass
{
    /// <summary>
    /// BL Class For CURD opration
    /// </summary>
    public class BLCURD
    {
        #region Public Members
        public static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString;
        OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(ConnectionString, MySqlDialect.Provider);

        #endregion

        #region public Methods
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="obj"></param>
        /// <returns> List<lib01></returns>
        public List<lib01> SelectAll()
        {
            using(var db = dbFactory.Open())
            {
                return db.Select<lib01>();
            }
        }

        /// <summary>
        /// SelectByID
        /// </summary>
        /// <param name="id">BookID</param>
        /// <returns></returns>
        public List<lib01> SelectById(int id)
        {
            using (var db = dbFactory.Open())
            {
                return db.Select<lib01>(x=>x.b01f01==id);
            }
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="obj">Object of Model</param>
        /// <returns>bool</returns>
        public bool Insert(lib01 objlib01)
        {   
            
            using (var db = dbFactory.Open())
            {
                try
                {
                    var ans = db.Insert(objlib01);
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
        /// Update
        /// </summary>
        /// <param name="obj">Object of Model</param>
        /// <returns></returns>
        public bool Update(lib01 objlib01)
        {
            using (var db = dbFactory.Open())
            {
                try
                {
                    var ans = db.Update(objlib01);
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
        /// Delete
        /// </summary>
        /// <param name="id">BookId</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            using (var db = dbFactory.Open())
            {
                try
                {
                    var ans = db.DeleteById<lib01>(id);
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
        #endregion
    }
}