<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="add city.aspx.cs" Inherits="add_city" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="main">
<div class="row">
<div class="heading">MANAGE CITY</div>
<div class="c1"> Select country</div>
<div class="c2">
    <asp:DropDownList ID="ddcountry" runat="server" DataValueField="Countryid" 
        DataTextField="Countryname" AutoPostBack="True" onselectedindexchanged="ddcountry_SelectedIndexChanged">
  
    
    </asp:DropDownList>
</div>
<div class="c3"> 
  </div>
 </div>


<div class="row">
<div class="c1">Select state</div>
<div class="c2">
    <asp:DropDownList ID="ddstate" runat="server" DataValueField="Stateid" 
        DataTextField="Statename">
    
    </asp:DropDownList>
</div>
<div class="c3"> 
  </div>
 </div>


 <div class="row">
<div class="c1">Add New City</div>
<div class="c2">
    <asp:TextBox ID="txtanc" runat="server"></asp:TextBox>
</div>
<div class="c3"> 
 
  </div>
 </div>

<div class="row">
<div class="c1"></div>
<div class="c2">
      <asp:Button ID="Button2" runat="server" Text="Add City" 
          onclick="Button2_Click" />
</div>
<div class="c3"> 
  </div>
 </div>
<div class="error"><asp:Label ID="lblerror" runat="server"></asp:Label>
</div>

<asp:Repeater ID="cityrep" runat="server" onitemcommand="cityrep_ItemCommand">
<HeaderTemplate>
<table style="width:100%">
<tr style="background-color:Black;color:Red">
<td style="width:30%">Countryname</td> 
<td style="width:30%">Statename</td>
<td style="width:30%">Cityid</td>
<td style="width:30%">Cityname</td>
<td style="width:10%">Action</td>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td style="width:40%">
<asp:Label ID="lblcountryname" runat="server" Text='<%#Eval("Countryname") %>'></asp:Label>
</td>
<td style="width:40%">
<asp:Label ID="lblstatename" runat="server" Text='<%#Eval("Statename") %>'></asp:Label>
</td>
<td style="width:40%">
<asp:Label ID="lblcityid" runat="server" Text='<%#Eval("Cityid") %>'></asp:Label>
</td>
<td style="width:40%">
<asp:Label ID="lblcityname" runat="server" Text='<%#Eval("Cityname") %>'></asp:Label>
<asp:TextBox ID="txtcityname" runat="server" visible="false" EnableViewState="true" Text='<%#Eval("Cityname") %>'></asp:TextBox>
</td>
<td style="width:20%">
<asp:LinkButton ID="linkedit" runat="server" CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("Cityid")%>'>Edit</asp:LinkButton>
<asp:LinkButton ID="linkdelete" runat="server" CausesValidation="false" CommandName="delete" CommandArgument='<%#Eval("Cityid")%>'>Delete</asp:LinkButton>
<asp:LinkButton ID="linkupdate" runat="server" CausesValidation="false" CommandName="update" Visible="false" CommandArgument='<%#Eval("Cityid")%>'>Update</asp:LinkButton>
<asp:LinkButton ID="linkcancel" runat="server" CausesValidation="false" CommandName="cancel" Visible="false" CommandArgument='<%#Eval("Cityid")%>'>Cancel</asp:LinkButton>
</td>
</tr>
</ItemTemplate>
<FooterTemplate></table></FooterTemplate>
</asp:Repeater>

</div>
 </asp:Content>

 