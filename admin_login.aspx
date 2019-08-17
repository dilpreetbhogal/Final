<%@ Page Title="" Language="C#" MasterPageFile="guestmaster.master" AutoEventWireup="true" CodeFile="admin_login.aspx.cs" Inherits="admin_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="main">
<div class="heading">ADMIN LOGIN</div>
 <div class="row">
<div class="c1"> E-mail</div>
<div class="c2">
    <asp:TextBox ID="txtmail" runat="server">
    </asp:TextBox>
</div>
<div class="c3"> 
    <asp:RegularExpressionValidator ID="revmail" runat="server" 
        ErrorMessage="Mismatch Expression" ControlToValidate="txtmail" 
        ValidationGroup="feedback" Display="Dynamic" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
  </div>
 </div>

 
  <div class="row">
<div class="c1"> password</div>
<div class="c2">
    <asp:TextBox ID="txtpass" runat="server" TextMode="Password">
    </asp:TextBox>
</div>
<div class="c3"> 
    <asp:RequiredFieldValidator ID="rfvpass" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtpass" ValidationGroup="feedback" Display="Dynamic">
    </asp:RequiredFieldValidator>
  </div>
 </div>
  
 <div class="error"><asp:Label ID="lblerror" runat="server"></asp:Label>
</div>

<div class="row">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/main form.aspx">If not yet registered? Click Here</asp:HyperLink><br />
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/forgot_password.aspx">Forgot Your Password? Click Here</asp:HyperLink>

</div>
<div class="row">
<div class="c1"></div>
<div class="c2"> 
    <asp:Button ID="btnlogin" runat="server" Text="LOGIN" 
        ValidationGroup="feedback" onclick="btnlogin_Click"  />
</div>
<div class="c3"></div></div>
</div>
</asp:Content>

