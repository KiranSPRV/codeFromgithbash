using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AngularJSWithAPI.Models;

namespace AngularJSWithAPI.ADODAL
{
    public class DAL_User
    {
        string SQLconString = string.Empty;
        public DAL_User()
        {
            SQLconString = ConfigurationManager.ConnectionStrings["SQLDBConnString"].ToString();
        }
        public List<User> GetAllUsers()
        {
            List<User> lstUser = new List<User>();
            try
            {
                using (SqlConnection sqlconn_obj = new SqlConnection(SQLconString))
                {
                    using (SqlCommand sqlcmd_obj = new SqlCommand("ANGJSAPI_PROC_GetAllUsers", sqlconn_obj))
                    {
                        sqlcmd_obj.CommandType = CommandType.StoredProcedure;
                        sqlconn_obj.Open();
                        SqlDataAdapter sqldap = new SqlDataAdapter(sqlcmd_obj);
                        DataTable resultdt = new DataTable();
                        sqldap.Fill(resultdt);
                        if (resultdt.Rows.Count > 0)
                        {
                            for (var items = 0; items < resultdt.Rows.Count; items++)
                            {
                                lstUser.Add(new User()
                                {
                                    UserID = resultdt.Rows[items]["UserID"] == DBNull.Value ? 0 : Convert.ToInt32(resultdt.Rows[items]["UserID"])
                                                         ,
                                    UserName = Convert.ToString(resultdt.Rows[items]["UserName"])
                                                         ,
                                    Age = resultdt.Rows[items]["Age"] == DBNull.Value ? 0 : Convert.ToInt32(resultdt.Rows[items]["Age"])
                                                         ,
                                    City = Convert.ToString(resultdt.Rows[items]["City"])
                                });
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstUser;
        }
        public string Insert_UpdateUser(User objUser)
        {
            string resltmsg = string.Empty;
            try
            {
                using (SqlConnection sqlconn_obj = new SqlConnection(SQLconString))
                {
                    using (SqlCommand sqlcmd_obj = new SqlCommand("ANGJSAPI_PROC_INSERT_UPDATE_USER", sqlconn_obj))
                    {
                        sqlcmd_obj.CommandType = CommandType.StoredProcedure;
                        sqlcmd_obj.Parameters.AddWithValue("@USERID", ((objUser.UserID == null || objUser.UserID == 0) ? (object)DBNull.Value : Convert.ToInt32(objUser.UserID)));
                        sqlcmd_obj.Parameters.AddWithValue("@UserName", objUser.UserName);
                        sqlcmd_obj.Parameters.AddWithValue("@City", objUser.City);
                        sqlcmd_obj.Parameters.AddWithValue("@Age", objUser.Age);
                        sqlconn_obj.Open();
                        int resultrows = sqlcmd_obj.ExecuteNonQuery();
                        if (resultrows > 0)
                        {
                            resltmsg = "Success";
                        }
                        else
                        {
                            resltmsg = "Fail";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                resltmsg = ex.Message;
            }
            return resltmsg;
        }
        public string Delete_User(User objUser) // Delete user from database using id
        {
            string resltmsg = string.Empty;
            try
            {
                using (SqlConnection sqlconn_obj = new SqlConnection(SQLconString))
                {
                    using (SqlCommand sqlcmd_obj = new SqlCommand("ANGJSAPI_PROC_DELETE_USER", sqlconn_obj))
                    {
                        sqlcmd_obj.CommandType = CommandType.StoredProcedure;
                        sqlcmd_obj.Parameters.AddWithValue("@USERID", ((objUser.UserID == null || objUser.UserID == 0) ? (object)DBNull.Value : Convert.ToInt32(objUser.UserID)));
                        sqlconn_obj.Open();
                        int resultrows = sqlcmd_obj.ExecuteNonQuery();
                        if (resultrows > 0)
                        {
                            resltmsg = "Success";
                        }
                        else
                        {
                            resltmsg = "Fail";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                resltmsg = ex.Message;
            }
            return resltmsg;
        }
    }
}