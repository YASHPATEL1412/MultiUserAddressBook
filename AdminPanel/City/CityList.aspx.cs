using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_CityList : System.Web.UI.Page
{
    #region Load Evant
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
            lblMessage.Text = "";
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

            objCmd.CommandText = "PR_City_SelectAllUserID";

            //objCmd.ExecuteNonQuery(); //Insert/Update/Delete
            //objCmd.ExecuteReader(); //Select
            //objCmd.ExecuteScalar(); //Only one schalar value is being return 
            //objCmd.ExecuteXmlReader(); //XML Type of data

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            SqlDataReader objSDR = objCmd.ExecuteReader();
            gvCity.DataSource = objSDR;
            gvCity.DataBind();

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

    #region gvCity : RowCommand
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteCity(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
        #endregion Delete Record
    }
    #endregion gvCity : RowCommand

    #region DeleteCity Record
    private void DeleteCity(SqlInt32 CityID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object

            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_DeleteByPK";
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString());

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            objCmd.ExecuteNonQuery();

            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "Data Delete Successfully!";

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
    #endregion DeleteCity Record
}