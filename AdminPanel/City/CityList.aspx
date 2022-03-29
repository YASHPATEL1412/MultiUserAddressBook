<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row hightlist">
        <div class="col-md-12">
            <span class="span1">City List</span>
            <asp:HyperLink runat="server" ID="hlAddCity" Text="Add New City" NavigateUrl="~/AdminPanel/City/Add" CssClass="btn btn-info addbtn"><i class='fa fa-plus'></i> Add New City</asp:HyperLink>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12" style="text-align: center">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="False" Font-Bold="True" Font-Size="Large" ForeColor="Red" />
        </div>
    </div>
    <div class="scroll">
        <asp:GridView ID="gvCity" runat="server" OnRowCommand="gvCity_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-outline-success btn-sm editbtn" NavigateUrl='<%# "~/AdminPanel/City/Edit/" + (EncryptDecrypt.Base64Encode(Eval("CityID").ToString().Trim())) %>'><i class="fa fa-edit"></i> Edit </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnDelete" CssClass="btn btn-outline-danger btn-sm deletebtn"  OnClientClick="return confirm('Are you sure want to delete?')" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID").ToString().Trim() %>'><i class="fa fa-trash"></i> Delete </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="CityID" HeaderText="Id" />--%>
                <asp:BoundField DataField="StateName" HeaderText="State Name" />
                <asp:BoundField DataField="CityName" HeaderText="City Name" />
                <asp:BoundField DataField="STDCode" HeaderText="STD Code" />
                <asp:BoundField DataField="PinCode" HeaderText="Pin Code" />
                <%--<asp:BoundField DataField="CreationDate" HeaderText="Creation Date" />
                <asp:BoundField DataField="ModificationDate" HeaderText="Modification Date" />--%>                
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>