<%@ Page Title="" Language="C#" MasterPageFile="guestmaster.master" AutoEventWireup="true" CodeFile="main form.aspx.cs" Inherits="main_form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="main">
<div class="heading">REGISTER FORM</div>
<div class="row">
<div class="c1"> First Name</div>
<div class="c2">
    <asp:TextBox ID="txtfn" runat="server">
    </asp:TextBox>
</div>
<div class="c3"> 
    <asp:RequiredFieldValidator ID="rfvfn" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtfn" ValidationGroup="register form" Display="Dynamic">
    </asp:RequiredFieldValidator>
  </div>
 </div>

 <div class="row">
<div class="c1"> Last Name</div>
<div class="c2">
    <asp:TextBox ID="txtln" runat="server">
    </asp:TextBox>
</div>
<div class="c3"> 
    <asp:RequiredFieldValidator ID="rfvln" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtln" ValidationGroup="register form" Display="Dynamic">
    </asp:RequiredFieldValidator>
  </div>
 </div>

 <div class="row">
<div class="c1"> Father's Name</div>
<div class="c2">
    <asp:TextBox ID="txtftn" runat="server">
    </asp:TextBox>
</div>
<div class="c3"> 
    <asp:RequiredFieldValidator ID="rfvftn" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtftn" ValidationGroup="register form" Display="Dynamic">
    </asp:RequiredFieldValidator>
  </div>
 </div>



 <div class="row">
<div class="c1"> Qualification</div>
<div class="c2">
    <asp:TextBox ID="txtqul" runat="server">
    </asp:TextBox>
</div>
<div class="c3"> 
    <asp:RequiredFieldValidator ID="rfvqul" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtqul" ValidationGroup="register form" Display="Dynamic">
    </asp:RequiredFieldValidator>
  </div>
 </div>
 <div class="row">
 <div class="c1"> Gender</div>
 <div class="c2">
  <asp:RadioButtonList ID="radiobtngender" runat="server" 
            RepeatDirection="Horizontal">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
 </div>
 <div class="c3">
  <asp:RequiredFieldValidator ID="rfvgender" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="radiobtngender" ValidationGroup="register form" Display="Dynamic">
    </asp:RequiredFieldValidator>
 </div>
 </div>



<div class="row">
<div class="c1">Country</div>
<div class="c2">
    <asp:DropDownList ID="ddcountry" runat="server" DataValueField="Countryid" DataTextField="Countryname" 
    AutoPostBack="true" onselectedindexchanged="ddcountry_SelectedIndexChanged" >
    </asp:DropDownList>
</div>
<div class="c3"> 
  </div>
 </div>


<div class="row">
<div class="c1"> state</div>
<div class="c2">
    <asp:DropDownList ID="ddstate" runat="server" DataValueField="Stateid" DataTextField="Statename" 
    AutoPostBack="true" onselectedindexchanged="ddstate_SelectedIndexChanged">
    </asp:DropDownList>
</div>
<div class="c3"> 
    
  </div>
 </div>


  <div class="row">
<div class="c1"> city</div>
<div class="c2">
    <asp:DropDownList ID="ddcity" runat="server" DataValueField="Cityid" DataTextField="Cityname"
     AutoPostBack="true">
    </asp:DropDownList>
</div>
<div class="c3">
  </div>
 </div>

<div class="row">
<div class="c1"> Address</div>
<div class="c2">
    <asp:TextBox ID="txtaddress" runat="server">
    </asp:TextBox>
</div>
<div class="c3"> 
    <asp:RequiredFieldValidator ID="rfvaddress" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtaddress" ValidationGroup="register form" Display="Dynamic">
    </asp:RequiredFieldValidator>
  </div>
 </div>

 <div class="row">
<div class="c1"> Phone No.</div>
<div class="c2">
    <asp:TextBox ID="txtpn" runat="server">
    </asp:TextBox>
</div>
<div class="c3"> 
    <asp:RequiredFieldValidator ID="rfvpn" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtpn" ValidationGroup="register form" Display="Dynamic">
    </asp:RequiredFieldValidator>
  </div>
 </div>

 <div class="row">
<div class="c1"> E-mail</div>
<div class="c2">
    <asp:TextBox ID="txtemail" runat="server">
    </asp:TextBox>
</div>
<div class="c3">
<asp:RegularExpressionValidator ID="revemail" runat="server" 
        ErrorMessage="Mismatch Expression" ControlToValidate="txtemail" 
        ValidationGroup="register form" Display="Dynamic" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

  </div>
 </div>
 <div class="row">
 <div class="c1">Password</div>
 <div class="c2">
        <asp:TextBox ID="txtpass" runat="server" TextMode="Password" ValidationGroup=" register form"></asp:TextBox>
       </div>
<div class="c3"></div>
</div>
<div class="row">
<div class="c1">Compare password</div>
<div class="c2">
<asp:TextBox ID="Txtcpass"  runat="server" TextMode="Password" ValidationGroup="register form"></asp:TextBox>
</div>
<div class="c3">
            <asp:CompareValidator ID="Cvpass" runat="server" ControlToCompare="Txtpass" 
                ControlToValidate="Txtcpass" Display="Dynamic" 
                ErrorMessage="incorrect password" SetFocusOnError="True" ValidationGroup="form"></asp:CompareValidator>
</div>
</div>

<div class="row">
<div class="c1"> Pin code</div>
<div class="c2">
    <asp:TextBox ID="txtpc" runat="server">
    </asp:TextBox>
</div>
<div class="c3"> 
    <asp:RequiredFieldValidator ID="rfvpc" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtpc" ValidationGroup="register form" Display="Dynamic">
    </asp:RequiredFieldValidator>
  </div>
 </div>
  <div class="row">
    <div class="c1">Security Question</div>
    <div class="c2">
        <asp:DropDownList ID="ddquestion" runat="server">
        <asp:ListItem>What is  your pet name?</asp:ListItem>
        <asp:ListItem>Who is your favorite teacher?</asp:ListItem>
        <asp:ListItem>What is your nickname?</asp:ListItem>
        <asp:ListItem>Who is your favorite actor?</asp:ListItem>
        </asp:DropDownList>
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
      <asp:RequiredFieldValidator ID="rfvanswer" runat="server" ControlToValidate="txtanswer" ErrorMessage="Text Must Not Be Empty">
</asp:RequiredFieldValidator>
 </div>
</div>

<div class="row">
<div class="c1"> Resume</div>
<div class="c2">
    <asp:TextBox ID="txtresume" runat="server">
    </asp:TextBox>
</div>
<div class="c3"> 
    <asp:RequiredFieldValidator ID="rfvresume" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtresume" ValidationGroup="register form" Display="Dynamic">
    </asp:RequiredFieldValidator>
  </div>
  </div>
    <asp:Button ID="Button1" runat="server" Text="SUBMIT" 
        ValidationGroup="register form" onclick="Button1_Click" />
     <div class="error"><asp:Label ID="lblerror" runat="server"></asp:Label>
</div>
</div>
</asp:Content>
