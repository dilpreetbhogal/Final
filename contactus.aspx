<%@ Page Title="" Language="C#" MasterPageFile="guestmaster.master" AutoEventWireup="true" CodeFile="contactus.aspx.cs" Inherits="contactus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="contact-form">

<div class="heading">CONTACT US</div>
<div class="form">
First Name
<div class="input">
    <asp:TextBox ID="txtfn" runat="server">
    </asp:TextBox>
</div>
    <asp:RequiredFieldValidator ID="rfvfn" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtfn" ValidationGroup="feedback" Display="Dynamic">
    </asp:RequiredFieldValidator>
   </div>
 <div class="form">
 Email
<div class="input">
    <asp:TextBox ID="txtmail" runat="server">
    </asp:TextBox>
</div>
    <asp:RegularExpressionValidator ID="revmail" runat="server" 
        ErrorMessage="Mismatch Expression" ControlToValidate="txtmail" 
        ValidationGroup="feedback" Display="Dynamic" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
  </div>
  <div class="form">
  Phone no.
<div class="input">
    <asp:TextBox ID="txtpn" runat="server">
    </asp:TextBox>
</div>
    <asp:RequiredFieldValidator ID="rfvpn" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtpn" ValidationGroup="feedback" Display="Dynamic">
    </asp:RequiredFieldValidator>
  
 </div>


   <div class="form">
   Message
<div class="input">
    <asp:TextBox ID="txtmessage" runat="server" TextMode="MultiLine">
    </asp:TextBox>
</div>
    <asp:RequiredFieldValidator ID="rfvmessage" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtpn" ValidationGroup="feedback" Display="Dynamic">
    </asp:RequiredFieldValidator>
  </div>
 <div class="form2">
 
     <asp:Button ID="btncontact" runat="server" Text="Contact Us" 
        ValidationGroup="feedback" onclick="btncontact_Click" />
</div>
</div>
 <div class="error"><asp:Label ID="lblerror" runat="server"></asp:Label>
</div>
</asp:Content>

