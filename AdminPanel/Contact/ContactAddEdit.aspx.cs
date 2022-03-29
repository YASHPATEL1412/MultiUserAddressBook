using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
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
            FillCBLContactCategoryID();
            /*FillDropDownContactCategoryList();*/
            if (RouteData.Values["ContactID"] != null)
            {
                lblAddEdit.Text = "Edit Contact";

                FillControls(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactID"].ToString().Trim())));
                FillDropDownStateList();
                FillDropDownCityList();
            }
            else
            {
                lblAddEdit.Text = "Add Contact";
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        SqlInt32 ContactID = SqlInt32.Null;
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

            if (cblContactCategoryID.SelectedValue == "")
                strErrorMessage += "Select ContactCategory <br />";

            if (txtContactName.Text.Trim() == "")
                strErrorMessage += "Enter ConatctName <br />";

            if (txtContactNo.Text.Trim() == "")
                strErrorMessage += "Enter ConatctNo <br />";

            //if (txtWhatsAppNo.Text.Trim() == "")
            //    strErrorMessage += "Enter WhatsAppNo <br />";

            //if (txtBirthDate.Text.Trim() == "")
            //    strErrorMessage += "Enter BirthDate <br />";

            //if (txtEmail.Text.Trim() == "")
            //    strErrorMessage += "Enter Email <br />";

            //if (txtAge.Text.Trim() == "")
            //    strErrorMessage += "Enter Age <br />";

            if (txtAddress.Text.Trim() == "")
                strErrorMessage += "Enter Address <br />";

            //if (txtBloodGroup.Text.Trim() == "")
            //    strErrorMessage += "Enter BloodGroup <br />";

            //if (txtFacebookID.Text.Trim() == "")
            //    strErrorMessage += "Enter FacebookID <br />";

            //if (txtLinkedInID.Text.Trim() == "")
            //    strErrorMessage += "Enter LinkedInID <br />";

            //if (!fuFile.HasFile)
            //    strErrorMessage += "You have not selected a File ";

            if (strErrorMessage.Trim() != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Gather Information
            //Gather the Information
            if (ddlCountryID.SelectedIndex > 0)
                strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);

            if (ddlStateID.SelectedIndex > 0)
                strStateID = Convert.ToInt32(ddlStateID.SelectedValue);

            if (ddlCityID.SelectedIndex > 0)
                strCityID = Convert.ToInt32(ddlCityID.SelectedValue);

            /*if (ddlContactCategoryID.SelectedIndex > 0)
                strContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);*/

            //if (cblContactCategoryID.SelectedItem > 0)
                strContactCategoryID = Convert.ToInt32(cblContactCategoryID.SelectedValue);

            if (txtContactName.Text.Trim() != "")
                strContactName = txtContactName.Text.Trim();

            if (txtContactNo.Text.Trim() != "")
                strContactNo = txtContactNo.Text.Trim();

            //if (txtWhatsAppNo.Text.Trim() != "")
            strWhatsAppNo = txtWhatsAppNo.Text.Trim();

            //if (txtBirthDate.Text.Trim() != "")
            strBirthDate = txtBirthDate.Text.Trim();

            //if (txtEmail.Text.Trim() != "")
            strEmail = txtEmail.Text.Trim();

            //if (txtAge.Text.Trim() != "")
            strAge = txtAge.Text.Trim();

            if (txtAddress.Text.Trim() != "")
                strAddress = txtAddress.Text.Trim();

            //if (txtBloodGroup.Text.Trim() != "")
            strBloodGroup = txtBloodGroup.Text.Trim();

            //if (txtFacebookID.Text.Trim() != "")
            strFacebookID = txtFacebookID.Text.Trim();

            //if (txtLinkedInID.Text.Trim() != "")
            strLinkedInID = txtLinkedInID.Text.Trim();

            #endregion Gather Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityID", strCityID);
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

           
            if (RouteData.Values["ContactID"] != null)
            {
                #region Update Record               
                //Edit Mode

                objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);

                objCmd.CommandText = "[dbo].[PR_Contact_UpdateByPK]";
                objCmd.Parameters.AddWithValue("@ContactID", (Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactID"].ToString().Trim()))));

                objCmd.ExecuteNonQuery();

                string FileType = Path.GetExtension(fuFile.FileName).ToLower();
                if (fuFile.HasFile)
                {
                    if (FileType == ".jpge" || FileType == ".jpg" || FileType == ".png" || FileType == ".gif")
                    {
                        UploadImage(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactID"].ToString())), "Image");
                    }
                    else
                    {
                        lblMessage.Text = "Please Upload Valid File(File must have .jpg or .jpge or .png or .gif extention).";
                        return;
                    }
                }

                DeleteContactCategory(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactID"].ToString())));
                AddContactCategory(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactID"].ToString())));

                Response.Redirect("~/AdminPanel/Contact/ContactList.aspx", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                //Add Mode

                objCmd.CommandText = "[PR_Contact_Insert]";

                //Out Parameter
                objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                objCmd.ExecuteNonQuery();

                ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);

                string FileType = Path.GetExtension(fuFile.FileName).ToLower();

                if (fuFile.HasFile)
                {
                    if (FileType == ".jpge" || FileType == ".jpg" || FileType == ".png" || FileType == ".gif")
                    {
                        UploadImage(ContactID, "Image");
                    }
                    else
                    {
                        lblMessage.Text = "Please Upload Valid File(File must have .jpg or .jpge or .png or .gif extention).";
                        return;
                    }
                }

                //We need ContactID (PK) after insertion of the record
                //It is needed to insert record in the table ContactWiseContactCategory

                AddContactCategory(ContactID);

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

    #region Add ContactCategory
    private void AddContactCategory(SqlInt32 ID)
    {
        #region Set Connection 
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            foreach (ListItem liContactCategoryID in cblContactCategoryID.Items)
            {
                if (liContactCategoryID.Selected)
                {
                    SqlCommand objCmdConactCategory = objConn.CreateCommand();
                    objCmdConactCategory.CommandType = CommandType.StoredProcedure;
                    objCmdConactCategory.CommandText = "[PR_ContactWiseContactCategory_Insert]";
                    if (Session["UserID"] != null)
                        objCmdConactCategory.Parameters.AddWithValue("@UserID", Session["UserID"]);
                    objCmdConactCategory.Parameters.AddWithValue("@ContactID", ID);
                    objCmdConactCategory.Parameters.AddWithValue("@ContactCategoryID", liContactCategoryID.Value.ToString());                    
                    objCmdConactCategory.ExecuteNonQuery();
                }
            }

            //lblMessage.Text = "Contact Added Successfully";

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Add ContactCategory

    #region Delete Contact Category
    private void DeleteContactCategory(SqlInt32 Id)
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Set Connection
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Set Parameter
            SqlCommand objCmd = new SqlCommand("PR_ContactWiseContactCategory_DeleteByContactID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactId", Id);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            objCmd.ExecuteNonQuery();
            #endregion Create Command and Set Parameter

            //lblMessage.Text = "Contact Deleted Successfully!";

            if (objConn.State == ConnectionState.Open)
                objConn.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message + ex;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Delete Contact Category

    #region Fill ContactCategory CheckBoxsList
    private void FillContactCategoryCheckBoxs(SqlInt32 ID)
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_ContactCategory_SelectOrNot]";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            objCmd.Parameters.AddWithValue("@ContactID", ID);
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if(objSDR.HasRows)
            {
                while(objSDR.Read())
                {
                    if(objSDR["SelectOrNot"].ToString() == "Selected")
                    {
                        cblContactCategoryID.Items.FindByValue(objSDR["ContactCategoryID"].ToString()).Selected = true;
                    }
                }
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
    #endregion Fill ContactCategory CheckBoxsList

    #region Upload Image
    private void UploadImage(SqlInt32 ID, string FileExtention)
    {
        SqlString strFilePath = SqlString.Null;

        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Image Upload

            strFilePath = "~/Content/UserPhoto/" + ID + ".jpg";

            if (!Directory.Exists(Server.MapPath("~/Content/UserPhoto/")))
            {
                Directory.CreateDirectory(Server.MapPath("~/Content/UserPhoto/"));
            }

            fuFile.SaveAs(Server.MapPath("~/Content/UserPhoto/" + ID + ".jpg"));
            long length = new FileInfo(Server.MapPath(strFilePath.ToString())).Length;

            #endregion Image Upload

            #region Create Command and Set Parameters

            SqlCommand objCmd = new SqlCommand("PR_Contact_UpdateImagePathByPKUserID", objConn);            
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@ContactID", ID);
            objCmd.Parameters.AddWithValue("@ContactPhotoPath", strFilePath);
            objCmd.Parameters.AddWithValue("@FileType", Convert.ToString(FileExtention));
            objCmd.Parameters.AddWithValue("@FileSize", Convert.ToString(length));
            
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));

            objCmd.ExecuteNonQuery();
            #endregion Create Command and Set Parameters

            if (objConn.State == ConnectionState.Open)
                objConn.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Upload Image

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contact/List", true);
    }
    #endregion Button : Cancel

    #region Fill DropDownCountryList
    private void FillDropDownCountryList()
    {
        CommonDropDownFillMethods.FillDropDownListCountry(ddlCountryID, Convert.ToInt32(Session["UserId"]));
    }
    #endregion Fill DropDownCountryList

    #region Fill DropDownStateList
    private void FillDropDownStateList()
    {
        CommonDropDownFillMethods.FillDropDownListStateByCountryID(ddlStateID,ddlCountryID, Convert.ToInt32(Session["UserId"]));       
    }
    #endregion Fill DropDownStateList

    #region Fill DropDownCityList
    private void FillDropDownCityList()
    {
        CommonDropDownFillMethods.FillDropDownListCitySelectByStateID(ddlStateID,ddlCityID, Convert.ToInt32(Session["UserId"]));
    }
    #endregion Fill DropDownCityList

    /*#region FillDropDownContactCategoryList
    private void FillDropDownContactCategoryList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            //strContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";

            //objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);

            #endregion Set Connection & Command Object
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
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
    #endregion FillDropDownContactCategoryList*/

    #region Fill CBLContactCategoryList
    private void FillCBLContactCategoryID()
    {
        CommonDropDownFillMethods.FillCBLContactCategoryList(cblContactCategoryID, Convert.ToInt32(Session["UserId"]));
    }
    #endregion Fill CBLContactCategoryList

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

                    /*if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                    {
                        cblContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                        //ddlContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                    }*/

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
                        txtBirthDate.Text = Convert.ToDateTime(objSDR["BirthDate"].ToString().Trim()).ToString("yyyy/MM/dd");
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
                    if (!objSDR["ContactPhotoPath"].Equals(DBNull.Value))
                    {
                        imgImage.ImageUrl = objSDR["ContactPhotoPath"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data Available for the ContactID = " + ContactID.ToString();
            }
            #endregion Read the value and set the controls

            FillContactCategoryCheckBoxs(ContactID);

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
        //ddlContactCategoryID.SelectedIndex = 0;
        cblContactCategoryID.ClearSelection();
        ddlCountryID.Focus();
        lblMessage.ForeColor = System.Drawing.Color.Green;
        lblMessage.Text = "Data Inserted Successfully";
    }
    #endregion

}