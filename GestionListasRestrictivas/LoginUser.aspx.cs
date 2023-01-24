using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace GestionListasRestrictivas
{
    public partial class LoginUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ErrorLabel.Text = string.Empty;

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {


            string username = LoginTextBox.Value;
            string password = PasswordTextBox.Value;
            int userId = 0;
            string roles = string.Empty;

            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            if (string.IsNullOrEmpty(LoginTextBox.Value))
                ErrorLabel.Text = "Please insert login.";
            else if (string.IsNullOrEmpty(PasswordTextBox.Value))
                ErrorLabel.Text = "Please insert password.";
            else
            {

                try
                {


                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("Validate_User"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Username", username);
                            cmd.Parameters.AddWithValue("@Password", password);
                            cmd.Connection = con;
                            con.Open();
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            userId = Convert.ToInt32(reader["UserId"]);
                            roles = reader["Roles"].ToString();
                            con.Close();
                        }
                        switch (userId)
                        {
                            case -1:
                                ErrorLabel.Text = "Username and/or password is incorrect.";
                                break;
                            case -2:
                                ErrorLabel.Text = "Account has not been activated.";
                                break;
                            default:
                                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(2880), true, roles, FormsAuthentication.FormsCookiePath);
                                string hash = FormsAuthentication.Encrypt(ticket);
                                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                                if (ticket.IsPersistent)
                                {
                                    cookie.Expires = ticket.Expiration;
                                }
                                Response.Cookies.Add(cookie);
                                Response.Redirect(FormsAuthentication.GetRedirectUrl(username, true));
                                break;
                        }
                    }

                }
                catch (Exception ex)
                {

                    throw;
                }

            }

        }


        //protected void ValidateUser(object sender, EventArgs e)
        //{
        //    int userId = 0;
        //    string roles = string.Empty;
        //    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("Validate_User"))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Username", Login1.UserName);
        //            cmd.Parameters.AddWithValue("@Password", Login1.Password);
        //            cmd.Connection = con;
        //            con.Open();
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            reader.Read();
        //            userId = Convert.ToInt32(reader["UserId"]);
        //            roles = reader["Roles"].ToString();
        //            con.Close();
        //        }
        //        switch (userId)
        //        {
        //            case -1:
        //                Login1.FailureText = "Username and/or password is incorrect.";
        //                break;
        //            case -2:
        //                Login1.FailureText = "Account has not been activated.";
        //                break;
        //            default:
        //                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Login1.UserName, DateTime.Now, DateTime.Now.AddMinutes(2880), Login1.RememberMeSet, roles, FormsAuthentication.FormsCookiePath);
        //                string hash = FormsAuthentication.Encrypt(ticket);
        //                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

        //                if (ticket.IsPersistent)
        //                {
        //                    cookie.Expires = ticket.Expiration;
        //                }
        //                Response.Cookies.Add(cookie);
        //                Response.Redirect(FormsAuthentication.GetRedirectUrl(Login1.UserName, Login1.RememberMeSet));
        //                break;
        //        }
        //    }
        //}
    }
}