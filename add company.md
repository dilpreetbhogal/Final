 Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Add_Company.aspx.cs" Inherits="Add_Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main">
<div class="heading">Add Company</div>
<div class="row">
<div class="c1"> Company Name</div>
<div class="c2">
 <asp:TextBox ID="txtcompanyname" runat="server"></asp:TextBox>
</div>
<div class="c3"> 
    <asp:RequiredFieldValidator ID="rfvcompanyname" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtcompanyname" ValidationGroup="addcompany" Display="Dynamic">
    </asp:RequiredFieldValidator>
  </div>
 </div>

 <div class="row">
<div class="c1"> Address</div>
<div class="c2">
 <asp:TextBox ID="txtaddress" runat="server" TextMode="MultiLine"></asp:TextBox>
</div>
<div class="c3"> 
    <asp:RequiredFieldValidator ID="rfvaddress" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtaddress" ValidationGroup="addcompany" Display="Dynamic">
    </asp:RequiredFieldValidator>
  </div>
 </div>
 <div class="row">
<div class="c1"> Phone no</div>
<div class="c2">
 <asp:TextBox ID="txtpn" runat="server"></asp:TextBox>
</div>
<div class="c3"> 
    <asp:RequiredFieldValidator ID="rfvpn" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtpn" ValidationGroup="addcompany" Display="Dynamic">
    </asp:RequiredFieldValidator>
  </div>
 </div>
 <div class="row">
<div class="c1"> Country</div>
<div class="c2">
 <asp:DropDownList ID="ddcountry" runat="server" DataValueField="Countryid" DataTextField="Countryname" 
 AutoPostBack="true" onselectedindexchanged="ddcountry_SelectedIndexChanged1"></asp:DropDownList>
</div>
<div class="c3"> 
 </div>
 </div>
 <div class="row">
<div class="c1"> State</div>
<div class="c2">
 <asp:DropDownList ID="ddstate" runat="server" DataValueField="Stateid" DataTextField="Statename" 
 AutoPostBack="true" onselectedindexchanged="ddstate_SelectedIndexChanged1"></asp:DropDownList>
</div>
