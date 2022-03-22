using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
{
    #region Load Evant
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #endregion Load Evant

    #region FillGridView
    private void FillGridView()
    {
        #region Local Variables
        //Establish the Connection
        //Create empty Connection object 
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        //data source=LAPTOP-62TMUUC5\SQLEXPRESS; This is the source of the Data/Server Name
        //initial catalog=AddressBook; This is the name of the database
        //Integrated Security=True; if it is True consider as Windows Authentication. in the case of false SQL Authentication
        //User ID=abc
        //Password=abc
        #endregion Local Variables
        try
        {
            #region Set Connection & Command Object

            if (objConn.State != ConnectionState.Open)  //Open the Connection
                objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;

            //objCmd.CommandType = CommandType.Text;
            //objCmd.CommandType = CommandType.TableDirect;

            objCmd.CommandText = "PR_Contact_SelectAllUserID";

            //objCmd.ExecuteNonQuery(); //Insert/Update/Delete
            //objCmd.ExecuteReader(); //Select
            //objCmd.ExecuteScalar(); //Only one schalar value is being return 
            //objCmd.ExecuteXmlReader(); //XML Type of data

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            SqlDataReader objSDR = objCmd.ExecuteReader();
            gvContact.DataSource = objSDR;
            gvContact.DataBind();

            if (objConn.State == ConnectionState.Open) //Close the Connection
                objConn.Close();
            #endregion Set Connection & Command Object

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
    #endregion FillGridView

    #region gvContact : RowCommand
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        
            if (e.CommandName == "DeleteRecord")
            {
                if (e.CommandArgument != null)
                {
                    DeleteContact(Convert.ToInt32(e.CommandArgument.ToString()));
                    FillGridView();
                }
            }
            else if (e.CommandName == "DeleteImage")
            {
                if (e.CommandArgument != null)
                {
                    DeleteContactImage(Convert.ToInt32(e.CommandArgument.ToString()));
                    FillGridView();
                }
            }
        #endregion Delete Record    
    }
    #endregion gvContact : RowCommand

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
    #endregion Delete Image

    #region DeleteContact Record
    private void DeleteContact(SqlInt32 ContactID )  /*string FilePath*/
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {

            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Delete Image
            FileInfo file = new FileInfo(Server.MapPath("~/Content/UserPhoto/" + ID.ToString() + ".jpg"));

            if (file.Exists)
            {
                file.Delete();
            }
            #endregion Delete Image

            
            #region Set Connection & Command Object
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_DeleteByPK";

            objCmd.Parameters.AddWithValue("ContactID", ContactID.ToString());

            /*DeletePhoto(FilePath);*/

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            objCmd.ExecuteNonQuery();

            if (objConn.State == ConnectionState.Open)
                objConn.Close();

            FillGridView();
            #endregion Set Connection & Command Object

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
    #endregion DeleteContact Record

}
