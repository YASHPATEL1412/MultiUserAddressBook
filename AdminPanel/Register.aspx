<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="AdminPanel_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../Content/Login/StyleSheet.css" rel="stylesheet" />

    <link href="~/Content/css/bootstrap-grid.css" rel="stylesheet" />
    <link href="~/Content/css/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="~/Content/css/bootstrap-reboot.css" rel="stylesheet" />
    <link href="~/Content/css/bootstrap-reboot.min.css" rel="stylesheet" />
    <link href="~/Content/css/bootstrap.css" rel="stylesheet" />
    <link href="~/Content/css/bootstrap.min.css" rel="stylesheet" />

    <script src="~/Content/js/bootstrap.bundle.js"></script>
    <script src="~/Content/js/bootstrap.bundle.min.js"></script>
    <script src="~/Content/js/bootstrap.js"></script>
    <script src="~/Content/js/bootstrap.min.js"></script>

</head>
<body style="background: rgb(16,61,156);
background: linear-gradient(180deg, rgba(16,61,156,1) 0%, rgba(86,186,237,1) 76%);">
    <form id="form1" runat="server">
        <div class="wrapper fadeInDown">
            <div id="formContent">
                <!-- Tabs Titles -->
                <asp:HyperLink runat="server" class="h2 inactive underlineHover" ID="hlLogin" Text="Sign In" NavigateUrl="~/AdminPanel/Login.aspx" />
                <h2 class="active">Sign Up </h2>

                <%--<!-- Icon -->
                <div class="fadeIn first">
                    <img src="http://danielzawadzki.com/codepen/01/icon.svg" id="icon" alt="User Icon" />
                </div>

                <!-- Login Form -->--%>
                <asp:TextBox runat="server" ID="txtUserNameRegister" CssClass="fadeIn first" placeholder="User Name"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtPasswordRegister" CssClass="fadeIn second" placeholder="Password"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDisplayName" CssClass="fadeIn third" placeholder="DisplayName"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtMobileNo" CssClass="fadeIn fourth" placeholder="MobileNo"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="fadeIn five" placeholder="Email"></asp:TextBox>
                <br />
                <asp:Button runat="server" ID="btnRegister" Text="Submit" class="fadeIn six" OnClick="btnRegister_Click" /><br />
                <asp:Label runat="server" ID="lblMessage" EnableViewState="false" />
                
                <!-- Remind Passowrd -->
                <%--<div id="formFooter">
                    <a class="underlineHover" href="#">Forgot Password?</a>
                </div>--%>

                <div id="formFooter">
                    <a>
                        <h4>New User? Register to Address Book </h4>
                    </a>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
