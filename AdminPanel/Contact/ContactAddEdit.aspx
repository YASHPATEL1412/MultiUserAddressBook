<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row hight">
        <div class="col-md-12">
            <h3><strong>Conatact Add Edit Page</strong></h3>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12" style="text-align: center">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="False" />
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-2">
                <h4>Country :</h4>
            </div>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlCountryID"  OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged" AutoPostBack="True" />
                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountryID" Display="Dynamic" ErrorMessage="Select Country" Font-Size="Medium" ForeColor="Red" InitialValue="-1" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>State :</h4>
            </div>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlStateID" OnSelectedIndexChanged="ddlStateID_SelectedIndexChanged" AutoPostBack="True" />
                <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ControlToValidate="ddlStateID" Display="Dynamic" ErrorMessage="Select State" Font-Size="Medium" ForeColor="Red" InitialValue="-1" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>City :</h4>
            </div>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlCityID" />
                <asp:RequiredFieldValidator ID="rfvCityName" runat="server" ControlToValidate="ddlCityID" Display="Dynamic" ErrorMessage="Select City" Font-Size="Medium" ForeColor="Red" InitialValue="-1" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>ContactCategory:</h4>
            </div>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlContactCategoryID" />
                <asp:RequiredFieldValidator ID="rfvContactCategoryName" runat="server" ControlToValidate="ddlContactCategoryID" Display="Dynamic" ErrorMessage="Select Contact Category" Font-Size="Medium" ForeColor="Red" InitialValue="-1" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>Contact Name :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtContactName" />
                <asp:RequiredFieldValidator ID="rfvContactName" runat="server" ControlToValidate="txtContactName" Display="Dynamic" ErrorMessage="Enter Contact Name" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>ContactNo :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtContactNo" />
                <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ControlToValidate="txtContactNo" Display="Dynamic" ErrorMessage="Enter Contact No" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revContactNo" runat="server" ControlToValidate="txtContactNo" Display="Dynamic" ErrorMessage="Enter Valid Contact No" Font-Size="Medium" ForeColor="Red" ValidationExpression="^[7-9][0-9]{9}$" ValidationGroup="Save"></asp:RegularExpressionValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>WhatsAppNo :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtWhatsAppNo" />
                <asp:RegularExpressionValidator ID="revWhatsAppNo" runat="server" ControlToValidate="txtWhatsAppNo" Display="Dynamic" ErrorMessage="Enter Valid WhatsApp No" Font-Size="Medium" ForeColor="Red" ValidationExpression="^[7-9][0-9]{9}$" ValidationGroup="Save"></asp:RegularExpressionValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>BirthDate :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtBirthDate" TextMode="Date" />
                <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" ControlToValidate="txtBirthDate" Display="Dynamic" ErrorMessage="Enter BirthDate" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>Email :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEmail" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter Valid Email Address" Font-Size="Medium" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Save"></asp:RegularExpressionValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>Age :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAge" />
                <asp:RequiredFieldValidator ID="rfvAge" runat="server" ControlToValidate="txtAge" Display="Dynamic" ErrorMessage="Enter Age" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>Address :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAddress" />
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Enter Address" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>BloodGroup :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtBloodGroup" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>FacebookID :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtFacebookID" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>LinkedInID :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtLinkedInID" />
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12" style="text-align: center">
            <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" CssClass="btn-btn-sm" Font-Bold="False" Font-Size="Large" ValidationGroup="Save" />
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn-btn-sm" Font-Bold="False" Font-Size="Large" OnClick="btnCancel_Click" />
        </div>
    </div><br />
</asp:Content>