<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="add country.aspx.cs" Inherits="add_country" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="main">
<div class="row">
<div class="heading">MANAGE COUNTRY</div>
<div class="c1">Add New Country</div>
<div class="c2">
    <asp:TextBox ID="txtcountry" runat="server">
    </asp:TextBox>
</div>
<div class="c3"> 
    
  </div>
 </div>


 <div class="row">
<div class="c1"></div>
<div class="c2">
 <asp:Button ID="Button1" runat="server" Text="Add Country" 
        onclick="Button1_Click" />
   </div>
<div class="c3"> 
  </div>
 </div>

<div class="error"><asp:Label ID="lblerror" runat="server"></asp:Label>
</div>

<asp:Repeater ID="countryrep" runat="server" onitemcommand="countryrep_ItemCommand">
<HeaderTemplate>
<table style="width:100%">
<tr style="background-color:Black;color:Red">
<td style="width:40%">Countryid</td> 
<td style="width:40%">MCN</td>
<td style="width:20%">Action</td>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td style="width:40%">
<asp:Label ID="lblcountryid" runat="server" Text='<%#Eval("Countryid") %>'></asp:Label>
</td>
<td style="width:40%">
<asp:Label ID="lblcountryname" runat="server" text='<%#Eval("Countryname") %>'></asp:Label>
 <asp:TextBox ID="txtcountryname" runat="server" visible="false" EnableViewState="true" Text='<%#Eval("Countryid") %>'></asp:TextBox>
</td>
<td style="width:20%">
<asp:LinkButton ID="linkedit" runat="server" CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("Countryid")%>'>Edit</asp:LinkButton>
<asp:LinkButton ID="linkdelete" runat="server" CausesValidation="false" CommandName="delete" CommandArgument='<%#Eval("Countryid")%>'>Delete</asp:LinkButton>
<asp:LinkButton ID="linkupdate" runat="server" CausesValidation="false" CommandName="update" Visible="false" CommandArgument='<%#Eval("Countryid")%>'>Update</asp:LinkButton>
<asp:LinkButton ID="linkcancel" runat="server" CausesValidation="false" CommandName="cancel" Visible="false" CommandArgument='<%#Eval("Countryid")%>'>Cancel</asp:LinkButton>
</td>
</tr>
</ItemTemplate>
<FooterTemplate></table></FooterTemplate>
</asp:Repeater>

</div>

</asp:Content>

