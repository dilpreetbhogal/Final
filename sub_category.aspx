<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="sub_category.aspx.cs" Inherits="sub_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="main">
<div class="row">
<div class="heading">SUB CATEGORY</div>
<div class="c1"> Select Main Category</div>
<div class="c2">
    <asp:DropDownList ID="ddmain" runat="server" AutoPostBack="true" DataTextField="maincategoryname" DataValueField="maincategoryid">
    </asp:DropDownList>
</div>
<div class="c3">
</div>
 </div>


<div class="row">
<div class="c1">Sub Category</div>
<div class="c2">
    <asp:TextBox ID="txtsub" runat="server"></asp:TextBox>
</div>
<div class="c3"> 
<asp:RequiredFieldValidator ID="rfvsub" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtsub" Display="Dynamic">
    </asp:RequiredFieldValidator>

</div>
 </div>
 <div class="row">
<div class="c1">

    <asp:Button ID="btnsub1" runat="server" Text="Add Category" 
        onclick="btnsub1_Click" /></div>
<div class="c2">
    <asp:Button ID="btnsub2" runat="server" Text="Reset" />
</div>
<div class="c3"> 
  </div>
 </div>
 
 <div class="error"><asp:Label ID="lblerror" runat="server"></asp:Label>
</div>

 <asp:Repeater ID="subrep" runat="server" onitemcommand="subrep_ItemCommand">
<HeaderTemplate>
<table style="width:100%">
<tr style="background-color:Black;color:Red">
<td style="width:30%">maincategoryname</td> 
<td style="width:30%">subcategoryid</td>
<td style="width:30%">subcategoryname</td>
<td style="width:10%">Action</td>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td style="width:40%">
<asp:Label ID="lblmainname" runat="server" Text='<%#Eval("maincategoryname") %>'></asp:Label>
</td>
<td style="width:40%">
<asp:Label ID="lblsubid" runat="server" Text='<%#Eval("subcategoryid") %>'></asp:Label>
</td>
<td style="width:40%">
<asp:Label ID="lblsubname" runat="server" Text='<%#Eval("subcategoryname") %>'></asp:Label>
 <asp:TextBox ID="txtsubname" runat="server" visible="false" EnableViewState="true" Text='<%#Eval("subcategoryid") %>'></asp:TextBox>
</td>
<td style="width:20%">
<asp:LinkButton ID="linkedit" runat="server" CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("subcategoryid")%>'>Edit</asp:LinkButton>
<asp:LinkButton ID="linkdelete" runat="server" CausesValidation="false" CommandName="delete" CommandArgument='<%#Eval("subcategoryid")%>'>Delete</asp:LinkButton>
<asp:LinkButton ID="linkupdate" runat="server" CausesValidation="false" CommandName="update" Visible="false" CommandArgument='<%#Eval("subcategoryid")%>'>Update</asp:LinkButton>
<asp:LinkButton ID="linkcancel" runat="server" CausesValidation="false" CommandName="cancel" Visible="false" CommandArgument='<%#Eval("subcategoryid")%>'>Cancel</asp:LinkButton>
</td>
</tr>
</ItemTemplate>
<FooterTemplate></table></FooterTemplate>
</asp:Repeater>

</div>
</asp:Content>

