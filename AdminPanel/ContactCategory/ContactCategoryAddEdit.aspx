<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryAddEdit.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row hight">
        <div class="col-md-12">
            <h3><strong><asp:Label runat="server" ID="lblAddEdit"/></strong></h3>
        </div>
    </div><hr class="hrr" />
    <div class="row">
        <div class="col-md-12" style="text-align: center">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="False" Font-Bold="True" Font-Size="Large" ForeColor="Red" />
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-3">
                <h4>ContactCategory Name :</h4>
            </div>
            <div class="col-md-9">
                <asp:TextBox runat="server" ID="txtContactCategoryName" />
                <asp:RequiredFieldValidator ID="rfvContactCategoryName" runat="server" ControlToValidate="txtContactCategoryName" Display="Dynamic" ErrorMessage="Enter Contact Category Name" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
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