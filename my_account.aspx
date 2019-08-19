<%@ Page Title="" Language="C#" MasterPageFile="guestmaster.master" AutoEventWireup="true" CodeFile="my_account.aspx.cs" Inherits="my_account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class ="main">
    <div class="row">
  <div class="heading">MY ACCCOUNT</div>
  </div>

      <div class="row">
      <div class="d1">
          <asp:Button ID="btnprofile" runat="server" Text="View Proile" 
              onclick="btnprofile_Click" />
          <asp:Button ID="btnedit" runat="server" Text="Edit Profile" 
              onclick="btnedit_Click" />
          <asp:Button ID="btnpassword" runat="server" Text="Change Password" 
              onclick="btnpassword_Click" />
          <asp:Button ID="btnimage" runat="server" Text="Change Image" 
              onclick="btnimage_Click" />
      </div>
      </div>
     
      
   <div class="main2">
 <asp:panel ID="panel1" runat="server">
 
  <div class="row">
  <div class="heading">View Proile</div>
  <div class="c1">First name</div>
  <div class="c2">
  <asp:Label ID="lblfn" runat="server"></asp:Label>
  </div>
  <div class="c3"></div>
  <div class="img" style="margin-left:70%">
     <asp:Image ID="image" runat="server" Height="200px" Width="200px"/>
     </div>
  </div>
           <div class="row">
           <div class="c1">country</div>
           <div class="c2">
         <asp:Label ID="lblcountry" runat="server"></asp:Label>
         </div>
           <div class="c3"></div>
           </div>

       <div class="row">
      <div class="c1">State</div>
      <div class="c2">
      <asp:Label ID="lblstate" runat="server"></asp:Label>
      </div>
      <div class="c3"></div>
      </div>
               <div class="row">
               <div class="c1">City</div>
               <div class="c2">
              <asp:Label ID="lblcity" runat="server"></asp:Label>
               </div>
               <div class="c3"></div>
               </div>
        <div class="row">
        <div class="c1">Phone no</div>
        <div class="c2">
        <asp:Label ID="lblpn" runat="server"></asp:Label>
        </div>
        <div class="c3"> </div>
        </div>
<div class="row">
<div class="c1">Email</div>
<div class="c2">
<asp:Label ID="lblemail" runat="server"></asp:Label>
</div>
<div class="c3">
</div>
</div>

     <div class="row">
     <div class="c1">Resume</div>
     <div class="c2">
     <asp:Label ID="lblresume" runat="server"></asp:Label>
     </div>
     <div class="c3"></div>
    </div>
    
 </asp:panel>
 </div> 
 
      <div class="main3">
    <asp:Panel ID="panel2" runat="server">
      <div class="row">
      <div class="heading">Edit Profile</div>
      </div>
      <div class="row">
      <div class="c1">First name</div>
      <div class="c2">
          <asp:TextBox ID="txtfn" runat="server"></asp:TextBox>
      </div>
      <div class="c3">
      <asp:RequiredFieldValidator ID="rfvfn" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtfn" ValidationGroup="p2" Display="Dynamic">
    </asp:RequiredFieldValidator>
     
      </div>
     </div>
<div class="row">
<div class="c1">Country</div>
<div class="c2">
<asp:DropDownList ID="ddcountry" runat="server" DataValueField="Countryid" DataTextField="Countryname" 
AutoPostBack="true" onselectedindexchanged="ddcountry_SelectedIndexChanged1">
    </asp:DropDownList>
    </div>
<div class="c3"></div>
</div>
     <div class="row">
     <div class="c1">State</div>
     <div class="c2">
     <asp:DropDownList ID="ddstate" runat="server" DataValueField="Stateid" DataTextField="Statename"
      AutoPostBack="true" onselectedindexchanged="ddstate_SelectedIndexChanged1">
    </asp:DropDownList>
     </div>
     <div class="c3"></div>
     </div>
        <div class="row">
        <div class="c1">City</div>
        <div class="c2">
        <asp:DropDownList ID="ddcity" runat="server" DataValueField="Cityid" DataTextField="Cityname" 
        AutoPostBack="true">
         </asp:DropDownList>
         </div>
        <div class="c3"></div>
        </div>

<div class="row">
<div class="c1">Phone no</div>
<div class="c2">
<asp:TextBox ID="txtpn" runat="server">
    </asp:TextBox>
</div>
<div class="c3">
<asp:RequiredFieldValidator ID="rfvpn" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtpn" ValidationGroup="p2" Display="Dynamic">
    </asp:RequiredFieldValidator>
    </div>
    </div>
           <div class="row">
           <div class="c1">Email</div>
           <div class="c2">
           <asp:TextBox ID="txtmail" runat="server" ReadOnly="true">
           </asp:TextBox>
           </div>
           <div class="c3">
           <asp:RegularExpressionValidator ID="revmail" runat="server" 
        ErrorMessage="Mismatch Expression" ControlToValidate="txtmail" 
        ValidationGroup="p2" Display="Dynamic" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
           </div>
           </div>
    
     <div class="row">
     <div class="c1">Resume</div>
     <div class="c2">
     <asp:TextBox ID="txtresume" runat="server">
     </asp:TextBox>
     </div>
     <div class="c3">
     <asp:RequiredFieldValidator ID="rfvresume" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtresume" ValidationGroup="p2" Display="Dynamic">
    </asp:RequiredFieldValidator>
     </div>
     </div>
      <asp:Button ID="btnupdate" runat="server" Text="UPDATE" 
            onclick="btnupdate_Click"/>
      
      </asp:Panel>
      </div>
             <div class="main4">
             <asp:Panel ID="panel3" runat="server">
             <div class="row">
             <div class="heading">Change Password</div>
             </div>
            <div class="row">
            <div class="c1">Old Password</div>
            <div class="c2">
            <asp:TextBox ID="txtoldpass" runat="server"></asp:TextBox>
            </div>
            <div class="c3">
              <asp:RequiredFieldValidator ID="rfvoldpas" runat="server" ErrorMessage="Text Must Not Be Empty" ControlToValidate="txtoldpass" ValidationGroup="p3" Display="Dynamic">
              </asp:RequiredFieldValidator>
            </div>
            </div>
            <div class="row">
            <div class="c1">New Password</div>
            <div class="c2">
            <asp:TextBox ID="txtnewpass" runat="server"></asp:TextBox>
            </div>
            <div class="c3">
              <asp:RequiredFieldValidator ID="rfvoldpass" runat="server" ErrorMessage="Text Must Not Be Empty" ControlToValidate="txtnewpass" ValidationGroup="p3" Display="Dynamic">
              </asp:RequiredFieldValidator>
             </div>
             </div>
             <div class="row">
             <div class="c1">Confirm Password</div>
             <div class="c2">
             <asp:TextBox ID="txtconfirmpass" runat="server"></asp:TextBox>
             </div>
             <div class="c3">
              <asp:CompareValidator ID="cmppass" runat="server" ControlToValidate="txtconfirmpass" ControlToCompare="txtnewpass" ValidationGroup="p3">
        </asp:CompareValidator>
        <asp:RequiredFieldValidator ID="rfvnewpass" runat="server" ControlToValidate="txtconfirmpass" ValidationGroup="p3">
        </asp:RequiredFieldValidator>
         </div>
         </div>
  <div class="row">
<div class="c1"></div>
      <div class="c2">
          <asp:Button ID="btnpass" runat="server" Text="UPDATE" ValidationGroup="p4" 
              onclick="btnpass_Click" />
      </div>
      <div class="c3">
      </div>
      </div>
      </asp:Panel>
      </div>
            
   <div class="main5">
   <asp:Panel ID="panel4" runat="server">
   <div class="row">
   <div class="heading">Change Image</div>
   </div>
   <div class="row">
   <div class="c1"> Choose Image</div>
   <div class="c2">
       <asp:FileUpload ID="FileUpload1" runat="server" /></div>
   <div class="c3">
   <asp:Image ID="image1" runat="server" Height="200px" Width="200px"/>
   </div>
   </div>
   
   
   <div class="row">
   <div class="c1"></div>
   <div class="c2">
   <asp:Button ID="buttonupdates" runat="server" Text="UPDATE" ValidationGroup="p4" 
           onclick="buttonupdates_Click" />
   </div>
   
   </div>
 </asp:Panel>     
</div>
</div>

 <div class="error"><asp:Label ID="lblerror" runat="server"></asp:Label>
</div>
</asp:Content>

