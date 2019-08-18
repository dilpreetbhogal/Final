<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Add_job.aspx.cs" Inherits="Add_job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="main">
<div class="heading">Add Job</div>
<div class="row">
<div class="c1"> Main Category</div>
<div class="c2">
    <asp:DropDownList ID="ddcategory" runat="server" 
        DataValueField="maincategoryid" DataTextField="maincategoryname" 
    AutoPostBack="true" onselectedindexchanged="ddcategory_SelectedIndexChanged"></asp:DropDownList>
</div>
<div class="c3"> 
   
  </div>
 </div>

        <div class="row">
        <div class="c1">Sub category</div>
       <div class="c2">
        <asp:DropDownList ID="ddsubcategory" runat="server" DataValueField="subcategoryid" DataTextField="subcategoryname" 
        AutoPostBack="true" onselectedindexchanged="ddsubcategory_SelectedIndexChanged"></asp:DropDownList>
        </div>
         <div class="c3"> 
         </div>
          </div>


                        <div class="row">
                      <div class="c1">Child category</div>
                    <div class="c2">
                    <asp:DropDownList ID="ddchildcategory" runat="server" DataValueField="childcategoryid" DataTextField="childcategoryname" 
                    AutoPostBack="true" ></asp:DropDownList>
                    </div>
                    <div class="c3">
                    </div>
                     </div>

      

 <div class="row">
<div class="c1">Job Tittle</div>
<div class="c2">
    <asp:TextBox ID="txttittle" runat="server">
    </asp:TextBox>
</div>
<div class="c3"> 
    <asp:RequiredFieldValidator ID="rfvtittle" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txttittle" ValidationGroup="addjob" Display="Dynamic">
    </asp:RequiredFieldValidator>
  </div>
 </div>
 <div class="row">
 <div class="c1">Description</div>
 <div class="c2">
  <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine"> </asp:TextBox>
 </div>
 <div class="c3">
  <asp:RequiredFieldValidator ID="rfvdescription" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtdescription" ValidationGroup="addjob" Display="Dynamic">
    </asp:RequiredFieldValidator>
 </div>
 </div>
<div class="row">
<div class="c1">Qualification</div>
<div class="c2">
  <asp:TextBox ID="txtqul" runat="server"></asp:TextBox>
</div>
<div class="c3"> 
<asp:RequiredFieldValidator ID="rfvqul" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtqul" ValidationGroup="addjob" Display="Dynamic">
    </asp:RequiredFieldValidator>
  </div>
 </div>
<div class="row">
<div class="c1">Salary </div>
<div class="c2">
    <asp:TextBox ID="txtsalary" runat="server"></asp:TextBox>
  <asp:Label ID="lblsalary" runat="server" Text="(Per Annum)"></asp:Label>
</div>
<div class="c3"> 
   
  </div>
 </div>
<div class="row">
<div class="c1"> Designation</div>
<div class="c2">
    <asp:TextBox ID="txtdesignation" runat="server" TextMode="MultiLine"></asp:TextBox>
</div>
<div class="c3">
<asp:RequiredFieldValidator ID="rfvdesignation" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtdesignation" ValidationGroup="addjob" Display="Dynamic">
    </asp:RequiredFieldValidator> 
 </div>
 </div>

<div class="row">
<div class="c1"> Company Name</div>
<div class="c2">
    <asp:DropDownList ID="ddcompanyname" runat="server" DataValueField="Companyid" DataTextField="Companyname" AutoPostBack="true">
    </asp:DropDownList>
</div>
<div class="c3"> 
    
  </div>
 </div>

 <div class="row">
<div class="c1">Number Of Posts</div>
<div class="c2">
    <asp:TextBox ID="txtposts" runat="server">
    </asp:TextBox>
</div>
<div class="c3"> 
    <asp:RequiredFieldValidator ID="rfvposts" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtposts" ValidationGroup="addjob" Display="Dynamic">
    </asp:RequiredFieldValidator>
  </div>
 </div>

 <div class="row">
<div class="c1"> Keys Skills</div>
<div class="c2">
    <asp:TextBox ID="txtkeyskills" runat="server" TextMode="MultiLine">
    </asp:TextBox>
</div>
<div class="c3">
<asp:RequiredFieldValidator ID="rfvkeyskills" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtkeyskills" ValidationGroup="addjob" Display="Dynamic">
    </asp:RequiredFieldValidator>
</div>
 </div>
 <div class="row">
<div class="c1">Country</div>
<div class="c2">
    <asp:DropDownList ID="ddcountry" runat="server" DataValueField="Countryid" DataTextField="Countryname" 
    AutoPostBack="true" onselectedindexchanged="ddcountry_SelectedIndexChanged">
    </asp:DropDownList>
</div>
<div class="c3"> 
  </div>
 </div>
<div class="row">
<div class="c1"> State</div>
<div class="c2">
    <asp:DropDownList ID="ddstate" runat="server" DataValueField="Stateid" DataTextField="Statename" 
    AutoPostBack="true" onselectedindexchanged="ddstate_SelectedIndexChanged">
    </asp:DropDownList>
</div>
<div class="c3"> 
    
  </div>
 </div>
  <div class="row">
<div class="c1"> City</div>
<div class="c2">
    <asp:DropDownList ID="ddcity" runat="server" DataValueField="Cityid" DataTextField="Cityname" 
    AutoPostBack="true">
    </asp:DropDownList>
</div>
<div class="c3">
  </div>
 </div>
 <div class="row">
 <div class="c1">Last Date To Apply</div>
 <div class="c2">
 <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
 </div>
 <div class="c3">
   <asp:RequiredFieldValidator ID="rfvdate" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtdate" ValidationGroup="addjob" Display="Dynamic">
    </asp:RequiredFieldValidator>
 </div>
 
 </div>
 <asp:Button ID="btnaddjob" runat="server" Text="Add Job" ValidationGroup="addjob" 
        onclick="btnaddjob_Click"/>
 <asp:Button ID="btnreset" runat="server" Text="Reset" ValidationGroup="addjob" />
 <div class="error"><asp:Label ID="lblerror" runat="server"></asp:Label>
</div>
</div>
</asp:Content>

