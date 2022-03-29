using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_EncryptDecrypt_EncryptDecrypt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            ClearControls();
        }
    }

    public static string Base64Encode(string plainText)
    {
        try
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }

    public static string Base64Decode(string base64EnCodeData)
    {
        try
        {
            var base64EncodeBytes = System.Convert.FromBase64String(base64EnCodeData);
            return System.Text.Encoding.UTF8.GetString(base64EncodeBytes);
        }
        catch(Exception ex)
        {
            return ex.Message.ToString();
        }
    }

    protected void btnEncrypt_Click(object sender, EventArgs e)
    {
        lblEncrypt.Text = Base64Encode(txtEncrypt.Text.Trim());
    }

    protected void btnDecrypt_Click(object sender, EventArgs e)
    {
        lblDecrypt.Text = Base64Decode(txtDecrypt.Text.Trim());
    }

    private void ClearControls()
    {
        lblDecrypt.Text = "";
        lblEncrypt.Text = "";
        txtDecrypt.Text = "";
        txtEncrypt.Text = "";
    }
}