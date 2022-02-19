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

public partial class AdminPanel_State_StateList : System.Web.UI.Page
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
        #endregion
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

            objCmd.CommandText = "PR_State_SelectAllUserID";

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            //objCmd.ExecuteNonQuery(); //Insert/Update/Delete
            //objCmd.ExecuteReader(); //Select
            //objCmd.ExecuteScalar(); //Only one schalar value is being return 
            //objCmd.ExecuteXmlReader(); //XML Type of data

            SqlDataReader objSDR = objCmd.ExecuteReader();
            gvState.DataSource = objSDR;
            gvState.DataBind();

            if (objConn.State == ConnectionState.Open) //Close the Connection
                objConn.Close();
            #endregion
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

    #region gvState : RowCommand
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Which command button is clicked | e.CommandName
        //Which row is clicked | get the ID of the row | e.CommandArgument

        #region Delete Record
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteState(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
        #endregion Delete Record
    }
    #endregion gvState : RowCommand

    #region DeleteState Record
    private void DeleteState(SqlInt32 StateID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_DeleteByPK";

            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString());

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            objCmd.ExecuteNonQuery();

            if (objConn.State == ConnectionState.Open)
                objConn.Close();

            FillGridView();
            #endregion
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
    #endregion DeleteState Record
}