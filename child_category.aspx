<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="child_category.aspx.cs" Inherits="child_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="main">
<div class="row">
<div class="heading">CHILD CATEGORY</div>
<div class="c1"> Select Main Category</div>
<div class="c2">
    <asp:DropDownList ID="ddmain" runat="server" 
        onselectedindexchanged="ddmain_SelectedIndexChanged" DataTextField="maincategoryname" DataValueField="maincategoryid" AutoPostBack="true">
    </asp:DropDownList>
</div>
<div class="c3">
</div>
 </div>


<div class="row">
<div class="c1">Select Sub Category</div>
<div class="c2">
   <asp:DropDownList ID="ddsub" runat="server" DataTextField="subcategoryname" DataValueField="subcategoryid" AutoPostBack="true">
    </asp:DropDownList> 
</div>
<div class="c3"> 
</div>
 </div>

 <div class="row">
<div class="c1">Child Category</div>
<div class="c2">
    <asp:TextBox ID="txtchild" runat="server"></asp:TextBox>
</div>
<div class="c3"> 
<asp:RequiredFieldValidator ID="rfvchild" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtchild" Display="Dynamic">
    </asp:RequiredFieldValidator>

</div>
 </div>

<div class="row">
<div class="c1">

    <asp:Button ID="btnchild1" runat="server" Text="Add Category" 
        onclick="btnchild1_Click" /></div>
<div class="c2">
    <asp:Button ID="btnchild2" runat="server" Text="Reset" />
</div>
<div class="c3"> 
  </div>
 </div>
<div class="error"><asp:Label ID="lblerror" runat="server"></asp:Label>
</div>

<asp:Repeater ID="childrep" runat="server" onitemcommand="childrep_ItemCommand">
<HeaderTemplate>
<table style="width:100%">
<tr style="background-color:Black;color:Red">
<td style="width:30%">maincategoryname</td> 
<td style="width:30%">subcategoryname</td>
<td style="width:30%">childcategoryid</td>
<td style="width:30%">childcategoryname</td>
<td style="width:10%">Action</td>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td style="width:40%">
<asp:Label ID="lblmainname" runat="server" Text='<%#Eval("maincategoryname") %>'></asp:Label>
</td>
<td style="width:40%">
<asp:Label ID="lblsubname" runat="server" Text='<%#Eval("subcategoryname") %>'></asp:Label>
</td>
<td style="width:40%">
<asp:Label ID="lblchildid" runat="server" Text='<%#Eval("childcategoryid") %>'></asp:Label>
</td>
<td style="width:40%">
<asp:Label ID="lblchildname" runat="server" Text='<%#Eval("childcategoryname") %>'></asp:Label>
<asp:TextBox ID="txtchildname" runat="server" visible="false" EnableViewState="true" Text='<%#Eval("childcategoryid") %>'></asp:TextBox>
</td>
<td style="width:20%">
<asp:LinkButton ID="linkedit" runat="server" CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("childcategoryid")%>'>Edit</asp:LinkButton>
<asp:LinkButton ID="linkdelete" runat="server" CausesValidation="false" CommandName="delete" CommandArgument='<%#Eval("childcategoryid")%>'>Delete</asp:LinkButton>
<asp:LinkButton ID="linkupdate" runat="server" CausesValidation="false" CommandName="update" Visible="false" CommandArgument='<%#Eval("childcategoryid")%>'>Update</asp:LinkButton>
<asp:LinkButton ID="linkcancel" runat="server" CausesValidation="false" CommandName="cancel" Visible="false" CommandArgument='<%#Eval("childcategoryid")%>'>Cancel</asp:LinkButton>
</td>
</tr>
</ItemTemplate>
<FooterTemplate></table></FooterTemplate>
</asp:Repeater>
 </div>
</asp:Content>

