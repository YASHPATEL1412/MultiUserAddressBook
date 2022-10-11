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

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();

            if (RouteData.Values["StateID"] != null)
            {
                lblAddEdit.Text = "Edit State";

                FillControls(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["StateID"].ToString().Trim())));
            }
            else
            {
                lblAddEdit.Text = "Add State";
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlString strStateName = SqlString.Null;
        SqlString strStateCode = SqlString.Null;
        #endregion Local Variables

        try
        {
            #region Server Side Validation
            //Server Side Validation
            String strErrorMessage = "";
            if (ddlCountryID.SelectedIndex == 0)
                strErrorMessage += "Select Country <br />";

            if (txtStateName.Text.Trim() == "")
                strErrorMessage += "Enter State Name <br />";

            if (txtStateCode.Text.Trim() == "")
                strErrorMessage += "Enter State Code ";

            if (strErrorMessage.Trim() != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Gather Informaction
            //Gather the Informaction
            if (ddlCountryID.SelectedIndex > 0)
                strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);

            if (txtStateName.Text.Trim() != "")
                strStateName = txtStateName.Text.Trim();

            if (txtStateCode.Text.Trim() != "")
                strStateCode = txtStateCode.Text.Trim();
            #endregion Gather Informaction

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@StateName", strStateName);
            objCmd.Parameters.AddWithValue("@StateCode", strStateCode);

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            #endregion Set Connection & Command Object

            if (RouteData.Values["StateID"] != null)
            {
                #region Update Record               
                //Edit Mode
                objCmd.Parameters.AddWithValue("@StateID", (EncryptDecrypt.Base64Decode(RouteData.Values["StateID"].ToString().Trim())));
                objCmd.CommandText = "[dbo].[PR_State_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/State/List", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                //Add Mode
                objCmd.CommandText = "[dbo].[PR_State_Insert]";
                objCmd.ExecuteNonQuery();
                txtStateName.Text = "";
                txtStateCode.Text = "";
                ddlCountryID.SelectedIndex = 0;
                ddlCountryID.Focus();
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
        Response.Redirect("~/AdminPanel/State/List", true);
    }
    #endregion Button : Cancel

    #region Fill DropDownList
    private void FillDropDownList()
    {
        CommonDropDownFillMethods.FillDropDownListCountry(ddlCountryID, Convert.ToInt32(Session["UserId"]));
    }
    #endregion Fill DropDownList

    #region FillControls
    private void FillControls(SqlInt32 StateID)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Variables
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectByUserID";

            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    //if(objSDR["StateName"].Equals(DBNull.Value) != true)
                    if (!objSDR["StateName"].Equals(DBNull.Value))
                    {
                        txtStateName.Text = objSDR["StateName"].ToString().Trim();
                    }
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    if (!objSDR["StateCode"].Equals(DBNull.Value))
                    {
                        txtStateCode.Text = objSDR["StateCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data Available for the StateID = " + StateID.ToString();
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