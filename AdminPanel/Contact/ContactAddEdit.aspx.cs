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

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownCountryList();
            FillDropDownContactCategoryList();

            if (Request.QueryString["ContactID"] != null)
            {
                lblMessage.Text = "Edit Mode | ContactID = " + Request.QueryString["ContactID"].ToString();

                FillControls(Convert.ToInt32(Request.QueryString["ContactID"]));
                FillDropDownStateList();
                FillDropDownCityList();
            }
            else
            {
                lblMessage.Text = "Add Mode";
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
        SqlInt32 strStateID = SqlInt32.Null;
        SqlInt32 strCityID = SqlInt32.Null;
        SqlInt32 strContactCategoryID = SqlInt32.Null;
        SqlString strContactName = SqlString.Null;
        SqlString strContactNo = SqlString.Null;
        SqlString strWhatsAppNo = SqlString.Null;
        SqlString strBirthDate = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strAge = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strBloodGroup = SqlString.Null;
        SqlString strFacebookID = SqlString.Null;
        SqlString strLinkedInID = SqlString.Null;
        #endregion Local Variables

        try
        {
            #region Server Side Validation
            //Server Side Validation
            String strErrorMessage = "";

            if (ddlCountryID.SelectedIndex == 0)
                strErrorMessage += "Select Country <br />";

            if (ddlStateID.SelectedIndex == 0)
                strErrorMessage += "Select State <br />";

            if (ddlCityID.SelectedIndex == 0)
                strErrorMessage += "Select City <br />";

            if (ddlContactCategoryID.SelectedIndex == 0)
                strErrorMessage += "Select ContactCategory <br />";

            if (txtContactName.Text.Trim() == "")
                strErrorMessage += "Enter ConatctName <br />";

            if (txtContactNo.Text.Trim() == "")
                strErrorMessage += "Enter ConatctNo <br />";

            //if (txtWhatsAppNo.Text.Trim() == "")
            //    strErrorMessage += "Enter WhatsAppNo <br />";

            if (txtBirthDate.Text.Trim() == "")
                strErrorMessage += "Enter BirthDate <br />";

            //if (txtEmail.Text.Trim() == "")
            //    strErrorMessage += "Enter Email <br />";

            if (txtAge.Text.Trim() == "")
                strErrorMessage += "Enter Age <br />";

            if (txtAddress.Text.Trim() == "")
                strErrorMessage += "Enter Address <br />";

            //if (txtBloodGroup.Text.Trim() == "")
            //    strErrorMessage += "Enter BloodGroup <br />";

            //if (txtFacebookID.Text.Trim() == "")
            //    strErrorMessage += "Enter FacebookID <br />";

            //if (txtLinkedInID.Text.Trim() == "")
            //    strErrorMessage += "Enter LinkedInID <br />";

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

            if (ddlStateID.SelectedIndex > 0)
                strStateID = Convert.ToInt32(ddlStateID.SelectedValue);

            if (ddlCityID.SelectedIndex > 0)
                strCityID = Convert.ToInt32(ddlCityID.SelectedValue);

            if (ddlContactCategoryID.SelectedIndex > 0)
                strContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);

            if (txtContactName.Text.Trim() != "")
                strContactName = txtContactName.Text.Trim();

            if (txtContactNo.Text.Trim() != "")
                strContactNo = txtContactNo.Text.Trim();

            //if (txtWhatsAppNo.Text.Trim() != "")
            //    strWhatsAppNo = txtWhatsAppNo.Text.Trim();

            if (txtBirthDate.Text.Trim() != "")
                strBirthDate = txtBirthDate.Text.Trim();

            //if (txtEmail.Text.Trim() != "")
            //    strEmail = txtEmail.Text.Trim();

            if (txtAge.Text.Trim() != "")
                strAge = txtAge.Text.Trim();

            if (txtAddress.Text.Trim() != "")
                strAddress = txtAddress.Text.Trim();

            //if (txtBloodGroup.Text.Trim() != "")
            //    strBloodGroup = txtBloodGroup.Text.Trim();

            //if (txtFacebookID.Text.Trim() != "")
            //    strFacebookID = txtFacebookID.Text.Trim();

            //if (txtLinkedInID.Text.Trim() != "")
            //    strLinkedInID = txtLinkedInID.Text.Trim();
            #endregion Gather Informaction

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityID", strCityID);
            objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);
            objCmd.Parameters.AddWithValue("@ContactName", strContactName);
            objCmd.Parameters.AddWithValue("@ContactNo", strContactNo);
            objCmd.Parameters.AddWithValue("@WhatsappNo", strWhatsAppNo);
            objCmd.Parameters.AddWithValue("@BirthDate", strBirthDate);
            objCmd.Parameters.AddWithValue("@Email", strEmail);
            objCmd.Parameters.AddWithValue("@Age", strAge);
            objCmd.Parameters.AddWithValue("@Address", strAddress);
            objCmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);
            objCmd.Parameters.AddWithValue("@FacebookID", strFacebookID);
            objCmd.Parameters.AddWithValue("@LinkedINID", strLinkedInID);

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            #endregion Set Connection & Command Object

            if (Request.QueryString["ContactID"] != null)
            {
                #region Update Record               
                //Edit Mode
                objCmd.Parameters.AddWithValue("@ContactID", Request.QueryString["ContactID"].ToString().Trim());
                objCmd.CommandText = "[dbo].[PR_Contact_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Contact/ContactList.aspx", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                //Add Mode
                objCmd.CommandText = "[dbo].[PR_Contact_Insert]";
                objCmd.ExecuteNonQuery();
                ClearControls();
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
        Response.Redirect("~/AdminPanel/Contact/ContactList.aspx", true);
    }
    #endregion Button : Cancel

    #region Fill DropDownCountryList
    private void FillDropDownCountryList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Command Object

            if (objSDR.HasRows == true)
            {
                ddlCountryID.DataSource = objSDR;
                ddlCountryID.DataValueField = "CountryID";
                ddlCountryID.DataTextField = "CountryName";
                ddlCountryID.DataBind();
            }

            ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));

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
    #endregion Fill DropDownCountryList

    #region Fill DropDownStateList
    private void FillDropDownStateList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {
            SqlInt32 strCountryID = SqlInt32.Null;

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_State_SelectByCountryID]";

            objCmd.Parameters.AddWithValue("CountryID", strCountryID);

            #endregion Set Connection & Command Object
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                ddlStateID.DataSource = objSDR;
                ddlStateID.DataValueField = "StateID";
                ddlStateID.DataTextField = "StateName";
                ddlStateID.DataBind();
            }

            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));

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
    #endregion Fill DropDownStateList

    #region Fill DropDownCityList
    private void FillDropDownCityList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {
            SqlInt32 strStateID = SqlInt32.Null;

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            strStateID = Convert.ToInt32(ddlStateID.SelectedValue);

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectByStateID";

            objCmd.Parameters.AddWithValue("@StateID", strStateID);

            #endregion Set Connection & Command Object
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                ddlCityID.DataSource = objSDR;
                ddlCityID.DataValueField = "CityID";
                ddlCityID.DataTextField = "CityName";
                ddlCityID.DataBind();
            }

            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));

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
    #endregion Fill DropDownCityList

    #region Fill DropDownContactCategoryList
    private void FillDropDownContactCategoryList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_ContactCategory_SelectForDropDownList]";
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Command Object

            if (objSDR.HasRows == true)
            {
                ddlContactCategoryID.DataSource = objSDR;
                ddlContactCategoryID.DataValueField = "ContactCategoryID";
                ddlContactCategoryID.DataTextField = "ContactCategoryName";
                ddlContactCategoryID.DataBind();
            }

            ddlContactCategoryID.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));

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
    #endregion Fill DropDownContactCategoryList

    #region FillControl
    private void FillControls(SqlInt32 ContactID)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Variables
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand("PR_Contact_SelectByUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@ContactID", ContactID);

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    if (!objSDR["CityID"].Equals(DBNull.Value))
                    {
                        ddlCityID.SelectedValue = objSDR["CityID"].ToString().Trim();
                    }
                    if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                    {
                        ddlContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                    }
                    if (!objSDR["ContactName"].Equals(DBNull.Value))
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                    }
                    if (!objSDR["ContactNo"].Equals(DBNull.Value))
                    {
                        txtContactNo.Text = objSDR["ContactNo"].ToString().Trim();
                    }
                    if (!objSDR["WhatsAppNo"].Equals(DBNull.Value))
                    {
                        txtWhatsAppNo.Text = objSDR["WhatsAppNo"].ToString().Trim();
                    }
                    if (!objSDR["BirthDate"].Equals(DBNull.Value))
                    {
                        txtBirthDate.Text = objSDR["BirthDate"].ToString().Trim();
                    }
                    if (!objSDR["Email"].Equals(DBNull.Value))
                    {
                        txtEmail.Text = objSDR["Email"].ToString().Trim();
                    }
                    if (!objSDR["Age"].Equals(DBNull.Value))
                    {
                        txtAge.Text = objSDR["Age"].ToString().Trim();
                    }
                    if (!objSDR["Address"].Equals(DBNull.Value))
                    {
                        txtAddress.Text = objSDR["Address"].ToString().Trim();
                    }
                    if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                    {
                        txtBloodGroup.Text = objSDR["BloodGroup"].ToString().Trim();
                    }
                    if (!objSDR["FacebookID"].Equals(DBNull.Value))
                    {
                        txtFacebookID.Text = objSDR["FacebookID"].ToString().Trim();
                    }
                    if (!objSDR["LinkedInID"].Equals(DBNull.Value))
                    {
                        txtLinkedInID.Text = objSDR["LinkedInID"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data Available for the ContactID = " + ContactID.ToString();
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

    #region Country SelectedIndexChanged
    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountryID.SelectedIndex != -1)
        {
            ddlCityID.Items.Clear();
            ddlStateID.Items.Clear();
            FillDropDownStateList();
        }
        else
        {
            ddlStateID.Items.Clear();
            ddlCityID.Items.Clear();
        }
    }
    #endregion Country SelectedIndexChanged

    #region State SelectedIndexChanged
    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStateID.SelectedIndex != -1)
        {
            ddlCityID.Items.Clear();
            FillDropDownCityList();
        }
        else
        {
            ddlCityID.Items.Clear();
        }
    }
    #endregion State SelectedIndexChanged

    #region ClearControls
    private void ClearControls()
    {
        txtContactName.Text = "";
        txtContactNo.Text = "";
        txtWhatsAppNo.Text = "";
        txtBirthDate.Text = "";
        txtEmail.Text = "";
        txtAge.Text = "";
        txtAddress.Text = "";
        txtBloodGroup.Text = "";
        txtFacebookID.Text = "";
        txtLinkedInID.Text = "";
        ddlCountryID.SelectedIndex = 0;
        ddlStateID.SelectedIndex = 0;
        ddlCityID.SelectedIndex = 0;
        ddlContactCategoryID.SelectedIndex = 0;
        ddlCountryID.Focus();
        lblMessage.Text = "Data Inserted Successfully";
    }
    #endregion

}