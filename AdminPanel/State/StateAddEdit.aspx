<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="AdminPanel_State_StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row hight">
        <div class="col-md-12">
            <h3><strong>State Add Edit Page</strong></h3>
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
                <asp:DropDownList runat="server" ID="ddlCountryID" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>State Name :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtStateName" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>State Code :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtStateCode" />
            </div>
        </div>
    </div><br />
    <div class="row">
        <div class="col-md-12" style="text-align: center">
            <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Save" CssClass="btn-btn-sm" Font-Bold="False" Font-Size="Large" />
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn-btn-sm" Font-Bold="False" Font-Size="Large" OnClick="btnCancel_Click" />
        </div>
    </div><br />
</asp:Content>