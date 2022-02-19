<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row hight">
        <div class="col-md-12">
            <h3><strong>City Add Edit Page</strong></h3>
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
                <h4>State :</h4>
            </div>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlStateID" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>City Name :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCityName" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>STD Code :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtSTDCode" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>Pin Code :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPinCode" />
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12" style="text-align: center">
            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn-btn-sm" OnClick="btnSave_Click" Font-Bold="False" Font-Size="Large" />
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn-btn-sm" Font-Bold="False" Font-Size="Large" OnClick="btnCancel_Click" />
        </div>
    </div><br />
</asp:Content>