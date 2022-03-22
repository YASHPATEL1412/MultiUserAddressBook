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
            if (Request.QueryString["ContactID"] != null)
            {
                lblMessage.Text = "Edit Mode | ContactID = " + Request.QueryString["ContactID"];

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

            /*if (ddlContactCategoryID.SelectedIndex == 0)
                strErrorMessage += "Select ContactCategory <br />";*/

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
                objCmd.CommandText = "[dbo].[PR_Contact_UpdateByPK]";
                objCmd.Parameters.AddWithValue("@ContactID", Convert.ToInt32(Request.QueryString["ContactID"]));

                objCmd.ExecuteNonQuery();

                string FileType = Path.GetExtension(fuFile.FileName).ToLower();
                if (fuFile.HasFile)
                {
                    if (FileType == ".jpge" || FileType == ".jpg" || FileType == ".png" || FileType == ".gif")
                    {
                        UploadImage(Convert.ToInt32(Request.QueryString["ContactID"]), "Image");
                    }
                    else
                    {
                        lblMessage.Text = "Please Upload Valid File(File must have .jpg or .jpge or .png or .gif extention).";
                        return;
                    }
                }
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

 
                foreach (ListItem liContactCategoryID in cblContactCategoryID.Items)
                {
                    if(liContactCategoryID.Selected)
                    {
                        SqlCommand objCmdConactCategory = objConn.CreateCommand();
                        objCmdConactCategory.CommandType = CommandType.StoredProcedure;
                        objCmdConactCategory.CommandText = "[PR_ContactWiseContactCategory_Insert]";
                        objCmdConactCategory.Parameters.AddWithValue("@ContactID", ContactID.ToString());
                        objCmdConactCategory.Parameters.AddWithValue("@ContactCategoryID", liContactCategoryID.Value.ToString());
                        objCmdConactCategory.ExecuteNonQuery();
                    }
                }

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

    /*protected void btnDeleteImg_Click(object sender, EventArgs e, SqlInt32 Id)
    {
        FileInfo file = new FileInfo(Server.MapPath("~/Content/UserPhoto/" + Id.ToString() + ".jpg"));

        if (file.Exists)
        {
            file.Delete();
            lblMessage.Text = "Image Deleted Successfully!";
        }
        else
        {
            lblMessage.Text = "Image dosen't upload!";
        }
    }

    protected void DeleteImg(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "DeleteImage")
        {
            if (e.CommandArgument != null)
            {
                DeleteContactImage(Convert.ToInt32(e.CommandArgument.ToString()));
            }
        }
        DeleteContactImage(Convert.ToInt32(e.ToString()));
    }

    #region Delete Image
    private void DeleteContactImage(SqlInt32 Id)
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Set Parameters
            SqlCommand objCmd = new SqlCommand("PR_Contact_DeleteImageByPKUserID", objConn);

            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactID", Id);

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));

            objCmd.ExecuteNonQuery();
            FileInfo file = new FileInfo(Server.MapPath("~/Content/UserPhoto/" + Id.ToString() + ".jpg"));

            if (file.Exists)
            {
                file.Delete();
                lblMessage.Text = "Image Deleted Successfully!";
            }
            else
            {
                lblMessage.Text = "Image dosen't upload!";
            }


            #endregion Create Command and Set Parameters

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
    #endregion Delete Image*/

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

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

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

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

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

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

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

    #region Fill DropDownContactCategoryList
    private void FillCBLContactCategoryID()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            objCmd.CommandText = "[PR_ContactCategory_SelectForDropDownList]";

            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Command Object

            if (objSDR.HasRows)
            {
                cblContactCategoryID.DataValueField = "ContactCategoryID";
                cblContactCategoryID.DataTextField = "ContactCategoryName";
                cblContactCategoryID.DataSource = objSDR;
                cblContactCategoryID.DataBind();
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
                        cblContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                        //ddlContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
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
        ddlCountryID.Focus();
        lblMessage.Text = "Data Inserted Successfully";
    }
    #endregion

}