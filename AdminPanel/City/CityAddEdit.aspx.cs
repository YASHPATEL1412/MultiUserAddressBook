﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();

            if (RouteData.Values["CityID"] != null)
            {
                lblAddEdit.Text = "Edit City";

                FillControls(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["CityID"].ToString().Trim())));
            }
            else
            {
                lblAddEdit.Text = "Add City";
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 strStateID = SqlInt32.Null;
        SqlString strCityName = SqlString.Null;
        SqlString strSTDCode = SqlString.Null;
        SqlString strPinCode = SqlString.Null;
        #endregion Local Variables

        try
        {
            #region Server Side Validation
            //Server Side Validation
            String strErrorMessage = "";

            if (ddlStateID.SelectedIndex == 0)
                strErrorMessage += "Select State <br />";

            if (txtCityName.Text.Trim() == "")
                strErrorMessage += "Enter City Name <br />";

            if (txtSTDCode.Text.Trim() == "")
                strErrorMessage += "Enter STD Code <br />";

            if (txtPinCode.Text.Trim() == "")
                strErrorMessage += "Enter Pin Code";

            if (strErrorMessage.Trim() != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Gather Informaction
            //Gather the Informaction
            if (ddlStateID.SelectedIndex > 0)
                strStateID = Convert.ToInt32(ddlStateID.SelectedValue);

            if (txtCityName.Text.Trim() != "")
                strCityName = txtCityName.Text.Trim();

            if (txtSTDCode.Text.Trim() != "")
                strSTDCode = txtSTDCode.Text.Trim();

            if (txtPinCode.Text.Trim() != "")
                strPinCode = txtPinCode.Text.Trim();

            #endregion Gather Informaction

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityName", strCityName);
            objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);
            objCmd.Parameters.AddWithValue("@PinCode", strPinCode);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            #endregion Set Connection & Command Object

            if (RouteData.Values["CityID"] != null)
            {
                #region Update Record
                //Edit Mode
                objCmd.Parameters.AddWithValue("CityID", (EncryptDecrypt.Base64Decode(RouteData.Values["CityID"].ToString().Trim())));
                objCmd.CommandText = "[dbo].[PR_City_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Updated Successfully";

                Response.Redirect("~/AdminPanel/City/List", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                //Add Mode
                objCmd.CommandText = "[dbo].[PR_City_Insert]";
                objCmd.ExecuteNonQuery();

                txtCityName.Text = "";
                txtSTDCode.Text = "";
                txtPinCode.Text = "";
                ddlStateID.SelectedIndex = 0;
                ddlStateID.Focus();

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
        Response.Redirect("~/AdminPanel/City/List", true);
    }
    #endregion Button : Cancel

    #region Fill DropDownList
    private void FillDropDownList()
    {
        CommonDropDownFillMethods.FillDropDownListState(ddlStateID, Convert.ToInt32(Session["UserId"]));
    }
    #endregion Fill DropDownList

    #region FillControls
    private void FillControls(SqlInt32 CityID)
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
            objCmd.CommandText = "PR_City_SelectByUserID";
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CityName"].Equals(DBNull.Value))
                    {
                        txtCityName.Text = objSDR["CityName"].ToString().Trim();
                    }
                    if (!objSDR["STDCode"].Equals(DBNull.Value))
                    {
                        txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                    }
                    if (!objSDR["PinCode"].Equals(DBNull.Value))
                    {
                        txtPinCode.Text = objSDR["PinCode"].ToString().Trim();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data Available for the CityID = " + CityID.ToString();
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