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

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            /* | CountryID = " + EncryptDecrypt.Base64Decode(RouteData.Values["CountryID"].ToString().Trim()"*/
            if (RouteData.Values["CountryID"] != null)
            {
                lblAddEdit.Text = "Edit Country";

                FillControls(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["CountryID"].ToString().Trim())));
            }
            else
            {
                lblAddEdit.Text = "Add Country";
            }

            /*if (RouteData.Values["CountryID"] != null)
            {
                lblMessage.Text = "Edit Mode | CountryID = " + EncryptDecrypt.Base64Decode(RouteData.Values["CountryID"].ToString().Trim();

                FillControls(Convert.ToInt32(RouteData.Values["CountryID"]));
            }
            else
            {
                lblMessage.Text = "Add Mode";
            }*/
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        //Declare Local varibles to Insert the date
        SqlString strCountryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;
        #endregion Local Variables

        try
        {
            #region Server Side Validation
            //Validate the Data | Server side Validation
            String strErrorMessage = "";

            if (txtCountryName.Text.Trim() == "")
                strErrorMessage += "Enter Country Name <br />";

            if (txtCountryCode.Text.Trim() == "")
                strErrorMessage += "Enter Country Code ";

            if (strErrorMessage.Trim() != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Gather Informaction
            //Gather the Informaction           
            if (txtCountryName.Text.Trim() != "")
                strCountryName = txtCountryName.Text.Trim();

            if (txtCountryCode.Text.Trim() != "")
                strCountryCode = txtCountryCode.Text.Trim();
            #endregion Gather Informaction

            #region Set Connection & Command Object
            //Save the Country Data
            //Establish the Connaction
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            //Prepare the Command
            //SqlCommand sqlCmd = new SqlCommand();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
            objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            #endregion Set Connection & Command Object

            if (Page.RouteData.Values["CountryID"] != null)
            {
                #region Update Record
                //Edit Mode
                objCmd.Parameters.AddWithValue("@CountryID", EncryptDecrypt.Base64Decode(RouteData.Values["CountryID"].ToString().Trim()));
                objCmd.CommandText = "[dbo].[PR_Country_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Country/List", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                //Add Mode
                objCmd.CommandText = "[dbo].[PR_Country_Insert]";
                objCmd.ExecuteNonQuery();
                txtCountryName.Text = "";
                txtCountryCode.Text = "";
                txtCountryName.Focus();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Data Inserted Successfully";
                #endregion Insert Record
            }

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/List", true);
    }
    #endregion Button : Cancel

    #region FillControls
    private void FillControls(SqlInt32 CountryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectByUserID";

            objCmd.Parameters.AddWithValue("@CountryID" , CountryID.ToString().Trim());

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CountryName"].Equals(DBNull.Value))
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                    }
                    if (!objSDR["CountryCode"].Equals(DBNull.Value))
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data Available for the CountryID = " + CountryID.ToString();
            }
            #endregion Read the value and set the controls
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion FillControls
}