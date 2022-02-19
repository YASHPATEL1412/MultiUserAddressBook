﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row hight">
        <div class="col-md-12">
            <span class="span1">Contact List</span>
            <asp:HyperLink runat="server" ID="hlAddContact" Text="Add New Contact" NavigateUrl="~/AdminPanel/Contact/ContactAddEdit.aspx" CssClass="btn btn-info addbtn"> <i class='fa fa-plus'></i> Add New Contact</asp:HyperLink>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12" style="text-align: center">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="False" Font-Bold="True" Font-Size="Large" ForeColor="Red"/>
        </div>
    </div>
    <div class="scroll">
        <asp:GridView ID="gvContact" runat="server" OnRowCommand="gvContact_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-outline-success btn-sm editbtn" NavigateUrl='<%# "~/AdminPanel/Contact/ContactAddEdit.aspx?ContactID=" + Eval("ContactID").ToString().Trim() %>' ><i class="fa fa-edit"></i> Edit </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-outline-danger btn-sm deletebtn" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString().Trim() %>' > <i class="fa fa-trash"></i> Delete </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
               <%-- <asp:BoundField DataField="ContactID" HeaderText="ID" />--%>
                <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                <asp:BoundField DataField="StateName" HeaderText="State Name" />
                <asp:BoundField DataField="CityName" HeaderText="City Name" />
                <asp:BoundField DataField="ContactCategoryName" HeaderText="ContactCategory Name" />
                <asp:BoundField DataField="ContactName" HeaderText="Contact Name" />
                <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                <asp:BoundField DataField="WhatsappNo" HeaderText="Whatsapp No" />
                <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Age" HeaderText="Age" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="BloodGroup" HeaderText="BloodGroup" />
                <asp:BoundField DataField="FacebookID" HeaderText="Facebook ID" />
                <asp:BoundField DataField="LinkedInID" HeaderText="LinkedInID" />
                <asp:BoundField DataField="CreationDate" HeaderText="Creation Date" />
                <asp:BoundField DataField="ModificationDate" HeaderText="Modification Date" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>