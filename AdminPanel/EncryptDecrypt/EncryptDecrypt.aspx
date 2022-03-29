<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EncryptDecrypt.aspx.cs" Inherits="AdminPanel_EncryptDecrypt_EncryptDecrypt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../../Content/css/all.css" rel="stylesheet" />
    <link href="../../Content/css/all.min.css" rel="stylesheet" />
    <link href="../../Content/css/bootstrap-grid.css" rel="stylesheet" />
    <link href="../../Content/css/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="../../Content/css/bootstrap-reboot.css" rel="stylesheet" />
    <link href="../../Content/css/bootstrap-reboot.min.css" rel="stylesheet" />
    <link href="../../Content/css/bootstrap.css" rel="stylesheet" />
    <link href="../../Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/css/EditBtn.css" rel="stylesheet" />


    <script src="../../Content/js/all.js"></script>
    <script src="../../Content/js/all.min.js"></script>
    <script src="../../Content/js/bootstrap.bundle.js"></script>
    <script src="../../Content/js/bootstrap.bundle.min.js"></script>
    <script src="../../Content/js/bootstrap.js"></script>
    <script src="../../Content/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <br /><br />
        <div class="container" style="border-style: solid; border-width: 2px; background-color: lightblue; font-family: Verdana">
            <br />
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-9">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEncrypt"></asp:TextBox>
                </div>
                <div class="col-md-2" style="text-align: left">
                    <asp:Button runat="server" ID="btnEncrypt" CssClass="btn-dark btn-sm" Font-Bold="False" Font-Size="Large" Text="Encrypt" OnClick="btnEncrypt_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <asp:Label ID="lblEncrypt" runat="server" Font-Bold="true" Font-Size="Larger"></asp:Label>
                </div>
                <div class="col-md-1"></div>
            </div>
            <hr class="hr" />

            <br />
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-9">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtDecrypt"></asp:TextBox>
                </div>
                <div class="col-md-2" style="text-align: left">
                    <asp:Button runat="server" ID="btnDecrypt" CssClass="btn-dark btn-sm" Font-Bold="False" Font-Size="Large" Text="Decrypt" OnClick="btnDecrypt_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <asp:Label ID="lblDecrypt" runat="server" Font-Bold="true" Font-Size="Larger"></asp:Label>
                </div>
                <div class="col-md-1"></div>
            </div>
            <br />
        </div>
    </form>
</body>
</html>
