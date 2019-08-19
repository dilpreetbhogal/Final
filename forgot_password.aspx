<%@ Page Title="" Language="C#" MasterPageFile="guestmaster.master" AutoEventWireup="true" CodeFile="forgot_password.aspx.cs" Inherits="forgot_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div class ="main">
    <asp:Panel ID="Panel1" runat="server">
    <div class="row">
    <div class="heading">Forgot Password</div>
    <div class="c1">Enter Email Id</div>
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
      <div class="c1"></div>
      <div class="c2">
          <asp:Button ID="btnid" runat="server" Text="SUBMIT" ValidationGroup="p1" />
      </div>
      <div class="c3">
      </div>
       </div>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server">
    <div class="row">
    <div class="c1">Enter Phone no</div>
    <div class="c2">
        <asp:TextBox ID="txtpn" runat="server">
        </asp:TextBox>
        </div>
<div class="c3">
<asp:RequiredFieldValidator ID="rfvpn" runat="server" ControlToValidate="txtpn" ValidationGroup="p2" ErrorMessage="Text Must Not B e Empty">
</asp:RequiredFieldValidator>
</div>
<div class="row">
<div class="c1"></div>
      <div class="c2">
          <asp:Button ID="btnpn" runat="server" Text="SUBMIT" ValidationGroup="p2" />
      </div>
      <div class="c3">
      </div>
</div>
    </div>
    </asp:Panel>

    <asp:Panel ID="Panel3" runat="server">
    <div class="row">
    <div class="c1">Security Question</div>
    <div class="c2">
      <asp:Label ID ="lblquestion" runat="server"></asp:Label>
        </div>
<div class="c3">
</div>
</div>
<div class="row">
<div class="c1">Security Answer</div>
      <div class="c2">
          <asp:TextBox ID="txtanswer" runat="server">
          </asp:TextBox>
      </div>
      <div class="c3">
      <asp:RequiredFieldValidator ID="rfvanswer" runat="server" ControlToValidate="txtanswer" ValidationGroup="p3" ErrorMessage="Text Must Not Be Empty">
</asp:RequiredFieldValidator>
 </div>
</div>

    <div class="row">
<div class="c1"></div>
      <div class="c2">
          <asp:Button ID="btnsecruity" runat="server" Text="SUBMIT" ValidationGroup="p3" />
      </div>
      <div class="c3">
      </div>
</div>
 </asp:Panel>
    <asp:Panel ID="Panel4" runat="server">
    <div class="row">
    <div class="c1">New Password</div>
    <div class="c2">
        <asp:TextBox ID="txtnewpass" runat="server"></asp:TextBox>
        </div>
<div class="c3">
</div>
</div>
<div class="row">
    <div class="c1">Compre new password</div>
    <div class="c2">
        <asp:TextBox ID="txtcomparepass" runat="server"></asp:TextBox>

        <asp:CompareValidator ID="cmppass" runat="server" ControlToValidate="txtcomparepass" ControlToCompare="txtnewpass" ValidationGroup="p4">
        </asp:CompareValidator>
        <asp:RequiredFieldValidator ID="rfvpass" runat="server" ControlToValidate="txtcomparepass" ValidationGroup="p4">
        </asp:RequiredFieldValidator>
        </div>
<div class="c3">
</div>
</div>
  <div class="row">
<div class="c1"></div>
      <div class="c2">
          <asp:Button ID="btnpass" runat="server" Text="Change Password" ValidationGroup="p4" />
      </div>
      <div class="c3">
      </div>
</div>
 </asp:Panel>
 </div>
</asp:Content>

