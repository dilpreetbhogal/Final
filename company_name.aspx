<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="company_name.aspx.cs" Inherits="company_name" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="main">
<div class="row">
<div class="heading">Company Name   </div>
<div class="c1"> Select Main Category</div>
<div class="c2">
    <asp:DropDownList ID="ddmain" runat="server" 
        onselectedindexchanged="ddmain_SelectedIndexChanged" DataTextField="maincategoryname" DataValueField="maincategoryid" AutoPostBack="true">
    </asp:DropDownList>
</div>
<div class="c3">
</div>
 </div>


<div class="row">
<div class="c1">Select Sub Category</div>
<div class="c2">
   <asp:DropDownList ID="ddsub" runat="server" DataTextField="subcategoryname" 
        DataValueField="subcategoryid" AutoPostBack="true" 
        onselectedindexchanged="ddsub_SelectedIndexChanged1">
    </asp:DropDownList> 
</div>
<div class="c3"> 
</div>
 </div>

 <div class="row">
<div class="c1">Child Category</div>
<div class="c2">
  <asp:DropDownList ID="ddchild" runat="server" DataTextField="childcategoryname"
  DataValueField="childcategoryid" AutoPostBack="true">
  </asp:DropDownList>
</div>
<div class="c3"> 
  
</div>
 </div>


<div class="row">
<div class="c1">Add New Company</div>
<div class="c2">
    <asp:TextBox ID="txtcompanyname" runat="server">
    </asp:TextBox>
</div>
<div class="c3"> 
    
  </div>
 </div>
 <div class="row">
<div class="c1"></div>
<div class="c2">
 <asp:Button ID="btnaddcompany" runat="server" Text="Add Company" 
        onclick="btnaddcompany_Click"/>
   </div>
<div class="c3"> 
  </div>
 </div>

<div class="error"><asp:Label ID="lblerror" runat="server"></asp:Label>
</div>

<asp:Repeater ID="companyrep" runat="server" onitemcommand="companyrep_ItemCommand">
<HeaderTemplate>
<table style="width:100%">
<tr style="background-color:Black;color:Red">
<td style="width:40%">companyid</td> 
<td style="width:40%">MCN</td>
<td style="width:20%">Action</td>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td style="width:40%">
<asp:Label ID="lblcompanyid" runat="server" Text='<%#Eval("companyid") %>'></asp:Label>
</td>
<td style="width:40%">
<asp:Label ID="lblcompanyname" runat="server" text='<%#Eval("companyname") %>'></asp:Label>
 <asp:TextBox ID="txtcompanyname" runat="server" visible="false" EnableViewState="true" Text='<%#Eval("companyid") %>'></asp:TextBox>
</td>
<td style="width:20%">
<asp:LinkButton ID="linkedit" runat="server" CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("companyid")%>'>Edit</asp:LinkButton>
<asp:LinkButton ID="linkdelete" runat="server" CausesValidation="false" CommandName="delete" CommandArgument='<%#Eval("companyid")%>'>Delete</asp:LinkButton>
<asp:LinkButton ID="linkupdate" runat="server" CausesValidation="false" CommandName="update" Visible="false" CommandArgument='<%#Eval("companyid")%>'>Update</asp:LinkButton>
<asp:LinkButton ID="linkcancel" runat="server" CausesValidation="false" CommandName="cancel" Visible="false" CommandArgument='<%#Eval("companyid")%>'>Cancel</asp:LinkButton>
</td>
</tr>
</ItemTemplate>
<FooterTemplate></table></FooterTemplate>
</asp:Repeater>
</div>

</asp:Content>

