<%@ Page Title="" Language="C#" MasterPageFile="guestmaster.master" AutoEventWireup="true" CodeFile="feedback.aspx.cs" Inherits="feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="contact-form">
    
<div class="heading">FEEDBACK</div>
     <div class="form">
First Name
          <div class="input">
    <asp:TextBox ID="txtfn" runat="server"  CssClass="name">
    </asp:TextBox>
</div>

    <asp:RequiredFieldValidator ID="rfvfn" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtfn" ValidationGroup="feedback" Display="Dynamic">
    </asp:RequiredFieldValidator>
  </div>
     <div class="form">
E-mail
<div class="input">
    <asp:TextBox ID="txtmail" runat="server" CssClass="name">
    </asp:TextBox>
</div>

    <asp:RegularExpressionValidator ID="revmail" runat="server" 
        ErrorMessage="Mismatch Expression" ControlToValidate="txtmail" 
        ValidationGroup="feedback" Display="Dynamic" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
  </div>

  <div class="form">
  Subject

<div class="input"> 
    <asp:DropDownList ID="ddsubject" runat="server">
    <asp:ListItem>About Website</asp:ListItem>
  </asp:DropDownList>
    
  </div>
 </div>

 <div class="form">
 Phone No.
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

     <asp:Button ID="btngive" runat="server" Text="Give Feedback" 
        ValidationGroup="feedback"/>
</div>
</div>

 
 <div class="error"><asp:Label ID="lblerror" runat="server"></asp:Label>
</div>

</asp:Content>

