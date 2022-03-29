<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row hightlist">
        <div class="col-md-12">
            <span class="span1">ContactCategory List</span>
              <asp:HyperLink runat="server" ID="hlContactCategory" Text="Add New ContactCategory" NavigateUrl="~/AdminPanel/ContactCategory/Add" CssClass="btn btn-info addbtn"> <i class='fa fa-plus'></i> Add New ContactCategory</asp:HyperLink>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12" style="text-align: center">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="False" Font-Bold="True" Font-Size="Large" ForeColor="Red" />
        </div>
    </div>
    <div class="scroll">
            <asp:GridView ID="gvContactCategory" runat="server" OnRowCommand="gvContactCategory_RowCommand" >
                <Columns>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlContactCategory" CssClass="btn btn-outline-success btn-sm editbtn" NavigateUrl='<%# "~/AdminPanel/ContactCategory/Edit/" + (EncryptDecrypt.Base64Encode(Eval("ContactCategoryID").ToString().Trim())) %>' ><i class="fa fa-edit"></i> Edit </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnContactCategory" CssClass="btn btn-outline-danger btn-sm deletebtn"  OnClientClick="return confirm('Are you sure want to delete?')" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactCategoryID").ToString().Trim() %>' ><i class="fa fa-trash"></i> Delete </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="ContactCategoryID" HeaderText="ID" />--%>
                    <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category Name" />
                    <%--<asp:BoundField DataField="CreationDate" HeaderText="Creation Date" />--%>
                    <%--<asp:BoundField DataField="ModificationDate" HeaderText="Modification Date" />--%>                   
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>