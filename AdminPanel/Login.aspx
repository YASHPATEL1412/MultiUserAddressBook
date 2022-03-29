<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminPanel_Login" %>

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
                <h2 class="active">Sign In </h2>
                <asp:HyperLink runat="server" class="h2 inactive underlineHover" ID="hlLogin" Text="Sign Up" NavigateUrl="~/AdminPanel/Register.aspx" />

                <%--<!-- Icon -->
                <div class="fadeIn first">
                    <img src="http://danielzawadzki.com/codepen/01/icon.svg" id="icon" alt="User Icon" />
                </div>

                <!-- Login Form -->--%>
                <asp:TextBox runat="server" ID="txtUserNameLogin" CssClass="fadeIn first" placeholder="User Name"></asp:TextBox>
                <br />                                
                <asp:RequiredFieldValidator ID="rfvEnterUserName" runat="server" ControlToValidate="txtUserNameLogin" Display="Dynamic" ErrorMessage="Enter User Name" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>                
                <asp:TextBox runat="server" ID="txtPasswordLogin" CssClass="fadeIn second" placeholder="Password"></asp:TextBox>
                <br />                                
                <asp:RequiredFieldValidator ID="rfvPasswordLogin" runat="server" ControlToValidate="txtPasswordLogin" Display="Dynamic" ErrorMessage="Enter Password" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:Button runat="server" ID="btnLogin" Text="Sign in" class="fadeIn third" OnClick="btnLogin_Click" /><br />
                <asp:Label runat="server" ID="lblMessage" EnableViewState="False" Font-Bold="True" Font-Size="Large" ForeColor="Red" />
                <!-- Remind Passowrd -->
                <%--<div id="formFooter">
                    <a class="underlineHover" href="#">Forgot Password?</a>
                </div>--%>

                <div id="formFooter">
                    <a>
                        <h4>Existing User! Sign in to Address Book </h4>
                    </a>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
