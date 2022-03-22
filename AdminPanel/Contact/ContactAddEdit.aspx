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
            <asp:Label runat="server" ID="lblMessage" EnableViewState="False" Font-Bold="True" Font-Size="Large" ForeColor="Red" />
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>Country :</h4>           
            </div>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlCountryID" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged" AutoPostBack="True" />
                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountryID" Display="Dynamic" ErrorMessage="Select Country" Font-Size="Medium" ForeColor="Red" InitialValue="-1" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>State :</h4>
            </div>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlStateID" OnSelectedIndexChanged="ddlStateID_SelectedIndexChanged" AutoPostBack="True" />
                <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ControlToValidate="ddlStateID" Display="Dynamic" ErrorMessage="Select State" Font-Size="Medium" ForeColor="Red" InitialValue="-1" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>City :</h4>
            </div>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlCityID" />
                <asp:RequiredFieldValidator ID="rfvCityName" runat="server" ControlToValidate="ddlCityID" Display="Dynamic" ErrorMessage="Select City" Font-Size="Medium" ForeColor="Red" InitialValue="-1" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>ContactCategory:</h4>
            </div>
            <div class="col-md-10">
                <asp:CheckBoxList runat="server" ID="cblContactCategoryID" RepeatDirection="Horizontal" Font-Size="Large" TextAlign="Left" />
                <%--<asp:DropDownList runat="server" ID="ddlContactCategoryID" />--%>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>Contact Name :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtContactName" placeholder="Enter Contact Name" />
                <asp:RequiredFieldValidator ID="rfvContactName" runat="server" ControlToValidate="txtContactName" Display="Dynamic" ErrorMessage="Enter Contact Name" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>ContactNo :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtContactNo" placeholder="Enter ContactNo" />
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
                <asp:TextBox runat="server" ID="txtWhatsAppNo" placeholder="Enter WhatsAppNo" />
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
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>Email :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEmail" placeholder="Enter Email" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter Valid Email Address" Font-Size="Medium" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Save"></asp:RegularExpressionValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>Age :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAge" placeholder="Enter Age" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>Address :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAddress" placeholder="Enter Address" />
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Enter Address" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>BloodGroup :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtBloodGroup" placeholder="Enter BloodGroup" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>FacebookID :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtFacebookID" placeholder="Enter FacebookID" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>LinkedInID :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtLinkedInID" placeholder="Enter LinkedInID" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>Contact Photo :</h4>
            </div>
            <div class="col-md-10">
                <asp:FileUpload ID="fuFile" runat="server" />
                <asp:Image runat="server" ID="imgImage" Width="100" AlternateText="Image dosen't upload!"  ImageUrl='<%# Eval("ContactPhotoPath") %>' />
                <%--<asp:LinkButton runat="server" ID="btnDeleteImg" CssClass="btn btn-outline-danger btn-sm deletebtn" CommandName="DeleteImage" CommandArgument='<%# Eval("ContactID").ToString() %>' OnClick="btnDeleteImg_Click"> <i class="fa fa-trash"></i></asp:LinkButton>--%>                            
            </div>
        </div>
        <br />
    </div>
    <br />
    <div class="row">
        <div class="col-md-12" style="text-align: center">
            <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" CssClass="btn-btn-sm" Font-Bold="False" Font-Size="Large" ValidationGroup="Save" />
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn-btn-sm" Font-Bold="False" Font-Size="Large" OnClick="btnCancel_Click" />
        </div>
    </div>
    <br />
</asp:Content>
