<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Job_apply.aspx.cs" Inherits="Job_apply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="main">
<div class="heading">Job Apply FORM</div>
<div class="row">
<div class="c1"> First Name</div>
<div class="c2">
    <asp:Label ID="lblfn" runat="server">
    </asp:Label>
</div>
<div class="c3"> 
   </div>
 </div>

  <div class="row">
<div class="c1"> Last Name</div>
<div class="c2">
    <asp:Label ID="lblln" runat="server">
    </asp:Label>
</div>
<div class="c3"> 
  
  </div>
 </div>

 <div class="row">
<div class="c1"> Father's Name</div>
<div class="c2">
   <asp:Label ID="lblftn" runat="server">
   </asp:Label>
</div>
<div class="c3"> 
    </div>
 </div>

 <div class="row">
<div class="c1"> Qualification</div>
<div class="c2">
   <asp:Label ID="lblqul" runat="server">
   </asp:Label>
</div>
<div class="c3"> 
   </div>
 </div>
 <div class="row">
 <div class="c1"> Gender</div>
 <div class="c2">
 <asp:Label ID="lblgender" runat="server">
 </asp:Label>
 </div>
 <div class="c3">
  </div>
 </div>

<div class="row">
<div class="c1">Country</div>
<div class="c2">
    <asp:Label ID="lblcountry" runat="server">
    </asp:Label>
</div>
<div class="c3"> 
  </div>
 </div>

<div class="row">
<div class="c1"> state</div>
<div class="c2">
   <asp:Label ID="lblstate" runat="server"></asp:Label>
</div>
<div class="c3"> 
    
  </div>
 </div>


  <div class="row">
<div class="c1"> city</div>
<div class="c2">
   <asp:Label ID="lblcity" runat="server">
   </asp:Label>
</div>
<div class="c3">
  </div>
 </div>

<div class="row">
<div class="c1"> Address</div>
<div class="c2">
   <asp:Label ID="lbladdress" runat="server">
   </asp:Label>
</div>
<div class="c3"> 
     </div>
 </div>

 <div class="row">
<div class="c1"> Phone No.</div>
<div class="c2">
    <asp:Label ID="lblpn" runat="server">
    </asp:Label>
</div>
<div class="c3"> 
   
  </div>
 </div>

 <div class="row">
<div class="c1"> E-mail</div>
<div class="c2">
<asp:Label ID="lblemail" runat="server">
</asp:Label>
</div>
<div class="c3">
</div>
 </div>

<div class="row">
<div class="c1"> Pin code</div>
<div class="c2">
   <asp:Label ID="lblpincode" runat="server">
   </asp:Label>
</div>
<div class="c3"> 
  
  </div>
 </div>
  <div class="row">
    <div class="c1">Security Question</div>
    <div class="c2">
      <asp:Label ID="lblquestion" runat="server">
      </asp:Label>
        </div>
<div class="c3">
</div>
</div>
<div class="row">
<div class="c1">Security Answer</div>
      <div class="c2">
         <asp:Label ID="lblanswer" runat="server">
         </asp:Label>
      </div>
      <div class="c3">
     
 </div>
</div>

<div class="row">
<div class="c1"> Resume</div>
<div class="c2">
  <asp:Label ID="lblresume" runat="server">
  </asp:Label>
</div>
<div class="c3"> 
  </div>
  </div>
   
   <div class="row">
<div class="c1"> Main Category</div>
<div class="c2">
    <asp:Label ID="lblcategory" runat="server">
    </asp:Label>
</div>
<div class="c3"> 
     </div>
 </div>

        <div class="row">
        <div class="c1">Sub category</div>
      <asp:Label ID="lblsubcategory" runat="server">
      </asp:Label> 
        </div>
         <div class="c3"> 
         </div>
          
                     <div class="row">
                      <div class="c1">Child category</div>
                    <div class="c2">
                   <asp:Label ID="lblchildcategory" runat="server">
                   </asp:Label>
                    </div>
                    <div class="c3">
                    </div>
                     </div>

       <div class="row">
<div class="c1">Job Tittle</div>
<div class="c2">
   <asp:Label ID="lbltittle" runat="server"></asp:Label>
</div>
<div class="c3"> 
   
  </div>
 </div>
 <div class="row">
 <div class="c1">Description</div>
 <div class="c2">
 <asp:Label ID="lbldescription" runat="server">
 </asp:Label>
 </div>
 <div class="c3">
 </div>
</div>

<div class="row">
<div class="c1">Salary </div>
<div class="c2">
 <asp:Label ID="lblsalary" runat="server"></asp:Label>
</div>
<div class="c3"> 
    </div>
 </div>
<div class="row">
<div class="c1"> Designation</div>
<div class="c2">
  <asp:Label ID="lbldesignation" runat="server">
  </asp:Label>
</div>
<div class="c3">
  </div>
 </div>

<div class="row">
<div class="c1"> Company Name</div>
<div class="c2">
   <asp:Label ID="lblcompanyname" runat="server">
   </asp:Label>
</div>
<div class="c3"> 
     </div>
 </div>

 <div class="row">
<div class="c1">Number Of Posts</div>
<div class="c2">
    <asp:Label ID="lblposts" runat="server">
    </asp:Label>
</div>
<div class="c3"> 
   </div>
 </div>

 <div class="row">
<div class="c1"> Keys Skills</div>
<div class="c2">
   <asp:Label ID="lblkeyskills" runat="server"></asp:Label>
</div>
<div class="c3">

</div>
 </div>
 
 <div class="row">
 <div class="c1">Last Date To Apply</div>
 <div class="c2">
 <asp:Label ID="lbldate" runat="server">
 </asp:Label>
 </div>
 <div class="c3">
  
 </div>
 
 </div>
<asp:Button ID="btnapply" runat="server" Text="Apply" />
     <div class="error"><asp:Label ID="lblerror" runat="server"></asp:Label>
</div>

</div>

</asp:Content>

