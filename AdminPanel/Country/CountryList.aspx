<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">

    <div class="row hight">
        <div class="col-md-12">
            <span class="span1">Country List</span>
            <asp:HyperLink runat="server" ID="hlAddCountry" Text="Add New Country" NavigateUrl="~/AdminPanel/Country/CountryAddEdit.aspx" CssClass="btn btn-info addbtn"> <i class='fa fa-plus'></i> Add New Country</asp:HyperLink>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12" style="text-align: center">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="False" Font-Bold="True" Font-Size="Large" ForeColor="Red" />
        </div>
    </div>
    <div class="scroll">
        <asp:GridView ID="gvCountry" runat="server" OnRowCommand="gvCountry_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-outline-success btn-sm editbtn" NavigateUrl='<%# "~/AdminPanel/Country/CountryAddEdit.aspx?CountryID= " + Eval("CountryID").ToString().Trim() %>' ><i class="fa fa-edit"></i> Edit </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnDelete" CssClass="btn btn-outline-danger btn-sm deletebtn" CommandName="DeleteRecord" CommandArgument='<%# Eval("CountryID").ToString().Trim() %>' > <i class="fa fa-trash"></i> Delete </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="CountryID" HeaderText="ID" />--%>
                <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                <asp:BoundField DataField="CountryCode" HeaderText="Country Code" />
                <asp:BoundField DataField="CreationDate" HeaderText="Creation Date" />
                <asp:BoundField DataField="ModificationDate" HeaderText="Modification Date" />
            </Columns>           
        </asp:GridView>
    </div>
</asp:Content>