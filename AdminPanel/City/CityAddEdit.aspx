<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

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
                <h4>State :</h4>
            </div>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlStateID" />
                <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlStateID" Display="Dynamic" ErrorMessage="Select State" Font-Size="Medium" ForeColor="Red" InitialValue="-1" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>City Name :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCityName" />
                <asp:RequiredFieldValidator ID="rfvCityName" runat="server" ControlToValidate="txtCityName" Display="Dynamic" ErrorMessage="Enter City Name" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>STD Code :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtSTDCode" />
                <asp:RequiredFieldValidator ID="rfvSTDCode" runat="server" ControlToValidate="txtSTDCode" Display="Dynamic" ErrorMessage="Enter STD Code" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>Pin Code :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPinCode" />
                <asp:RequiredFieldValidator ID="rfvPinCode" runat="server" ControlToValidate="txtPinCode" Display="Dynamic" ErrorMessage="Enter Pin Code" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12" style="text-align: center">
            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn-btn-sm" OnClick="btnSave_Click" Font-Bold="False" Font-Size="Large" ValidationGroup="Save" />
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn-btn-sm" Font-Bold="False" Font-Size="Large" OnClick="btnCancel_Click" />
        </div>
    </div><br />
</asp:Content>