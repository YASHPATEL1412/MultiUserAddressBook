using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Login : System.Web.UI.Page
{
    #region Load Evant
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Load Evant

    #region Login Button
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //Valid user or not valid User
        //UserName, Password

        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlString strUserName = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        #endregion Local Variable

        #region Server Side Validation
        String strErrorMessage = "";
        
        if(txtUserNameLogin.Text.Trim() == "")
        {
            strErrorMessage += "Enter UserName <br/>"; 
        }
        if(txtPasswordLogin.Text.Trim() == "")
        {
            strErrorMessage += "Enter Password <br/>";
        }
        if(strErrorMessage != "")
        {
            lblMessage.Text = "Kindly Solve the following Errors <br/>" + strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Assign the Value
        if(txtUserNameLogin.Text.Trim() != "")
            strUserName = txtUserNameLogin.Text.Trim();

        if(txtPasswordLogin.Text.Trim() != "")
            strPassword = txtPasswordLogin.Text.Trim();
        #endregion Assign the Value

        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_SelectByNamePassword";

            objCmd.Parameters.AddWithValue("@UserName",strUserName);
            objCmd.Parameters.AddWithValue("@Password",strPassword);

            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Command Object
            if (objSDR.HasRows)
            {
                //Valid User
                lblMessage.Text = "Valid User";

                while(objSDR.Read())
                {
                    if(!objSDR["UserID"].Equals(DBNull.Value))
                    {
                        Session["UserID"] = objSDR["UserID"].ToString().Trim();
                    }
                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                    {
                        Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
                    }
                    break;
                }
                Response.Redirect("~/AdminPanel/Default.aspx",true);
            }
            else
            {
                lblMessage.Text = "Username or Password is not valid";
            }

            if(objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
    }
    #endregion Login Button
}