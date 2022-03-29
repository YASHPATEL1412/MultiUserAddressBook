<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="AdminPanel_State_StateAddEdit" %>

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
            <div class="col-md-2">
                <h4>Country :</h4>
            </div>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlCountryID" AutoPostBack="True" />
                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountryID" Display="Dynamic" ErrorMessage="Select Country" Font-Size="Medium" ForeColor="Red" InitialValue="-1" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>State Name :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtStateName" />
                <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ControlToValidate="txtStateName" Display="Dynamic" ErrorMessage="Enter State Name" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>State Code :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtStateCode" />
                <asp:RequiredFieldValidator ID="rfvStateCode" runat="server" ControlToValidate="txtStateCode" Display="Dynamic" ErrorMessage="Enter State Code" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div><br />
    <div class="row">
        <div class="col-md-12" style="text-align: center">
            <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Save" CssClass="btn-btn-sm" Font-Bold="False" Font-Size="Large" ValidationGroup="Save" />
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn-btn-sm" Font-Bold="False" Font-Size="Large" OnClick="btnCancel_Click" />
        </div>
    </div><br />
</asp:Content>