<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="add state.aspx.cs" Inherits="add_state" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="main">
<div class="row">
<div class="heading">MANAGE STATE</div>
<div class="c1">Select Country</div>
<div class="c2">
    <asp:DropDownList ID="ddcountry" runat="server" DataTextField="CountryName" DataValueField="CountryId" AutoPostBack="true">
    
    </asp:DropDownList>
</div>
<div class="c3"> 
  </div>
 </div>

 <div class="row">
<div class="c1">Add New state</div>
<div class="c2">
    <asp:TextBox ID="txtans" runat="server"></asp:TextBox>
</div>
<div class="c3"> 
  </div>
 </div>
      
 <div class="row">
<div class="c1"></div>
<div class="c2">
    <asp:Button ID="btnas" runat="server" Text="Add State" OnClick="Button_Click" />
</div>
<div class="c3"> 
  </div>
 </div>
 
 <div class="error"><asp:Label ID="lblerror" runat="server"></asp:Label>
</div>


 <asp:Repeater ID="staterep" runat="server" onitemcommand="staterep_ItemCommand">
<HeaderTemplate>
<table style="width:100%">
<tr style="background-color:Black;color:Red">
<td style="width:30%">countrynme</td> 
<td style="width:30%">stateid</td>
<td style="width:30%">statename</td>
<td style="width:10%">Action</td>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td style="width:40%">
<asp:Label ID="lblcountryname" runat="server" Text='<%#Eval("Countryname") %>'></asp:Label>
</td>
<td style="width:40%">
<asp:Label ID="lblstateid" runat="server" Text='<%#Eval("Stateid") %>'></asp:Label>
</td>
<td style="width:40%">
<asp:Label ID="lblstatename" runat="server" Text='<%#Eval("Statename") %>'></asp:Label>
<asp:TextBox ID="txtstatename" runat="server" visible="false" EnableViewState="true" Text='<%#Eval("Stateid") %>'></asp:TextBox>
</td>
<td style="width:20%">
<asp:LinkButton ID="linkedit" runat="server" CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("Stateid")%>'>Edit</asp:LinkButton>
<asp:LinkButton ID="linkdelete" runat="server" CausesValidation="false" CommandName="delete" CommandArgument='<%#Eval("Stateid")%>'>Delete</asp:LinkButton>
<asp:LinkButton ID="linkupdate" runat="server" CausesValidation="false" CommandName="update" Visible="false" CommandArgument='<%#Eval("Stateid")%>'>Update</asp:LinkButton>
<asp:LinkButton ID="linkcancel" runat="server" CausesValidation="false" CommandName="cancel" Visible="false" CommandArgument='<%#Eval("Stateid")%>'>Cancel</asp:LinkButton>
</td>
</tr>
</ItemTemplate>
<FooterTemplate></table></FooterTemplate>
</asp:Repeater>
</div>
</asp:Content>

