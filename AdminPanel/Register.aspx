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
<body style="background: linear-gradient(180deg, rgba(16,61,156,1) 0%, rgba(86,186,237,1) 76%);">
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
                <br />                                
                <asp:RequiredFieldValidator ID="rfvUserNameRegister" runat="server" ControlToValidate="txtUserNameRegister" Display="Dynamic" ErrorMessage="Enter User Name" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox runat="server" ID="txtPasswordRegister" CssClass="fadeIn second" placeholder="Password"></asp:TextBox>                
                <br />                                
                <asp:RequiredFieldValidator ID="rfvPasswordRegister" runat="server" ControlToValidate="txtPasswordRegister" Display="Dynamic" ErrorMessage="Enter Password" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>                
                <asp:TextBox runat="server" ID="txtDisplayName" CssClass="fadeIn third" placeholder="DisplayName"></asp:TextBox>                
                <br />                                
                <asp:RequiredFieldValidator ID="rfvDisplayName" runat="server" ControlToValidate="txtDisplayName" Display="Dynamic" ErrorMessage="Enter DisplayName" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>                                
                <asp:TextBox runat="server" ID="txtMobileNo" CssClass="fadeIn fourth" placeholder="MobileNo"></asp:TextBox>
                <br />                                
                <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter MobileNo" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>                                                
                <asp:TextBox runat="server" ID="txtEmail" CssClass="fadeIn five" placeholder="Email"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter Email" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>                                                
                <br />
                <asp:Button runat="server" ID="btnRegister" Text="Create account" class="fadeIn six" OnClick="btnRegister_Click" /><br />
                <asp:Label runat="server" ID="lblMessage" EnableViewState="false" />
                
                <!-- Remind Passowrd -->
                <%--<div id="formFooter">
                    <a class="underlineHover" href="#">Forgot Password?</a>
                </div>--%>

                <div id="formFooter">
                    <a>
                        <h4>New User? Sign Up to Address Book </h4>
                    </a>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
