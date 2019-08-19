<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="main_category.aspx.cs" Inherits="main_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="main">
<div class="row">
<div class="heading">MAIN CATEGORY</div>
<div class="c1"> Main category</div>
<div class="c2">
    <asp:TextBox ID="txtmain" runat="server"></asp:TextBox>
</div>
<div class="c3"> 
<asp:RequiredFieldValidator ID="rfvmain" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtmain" Display="Dynamic">
    </asp:RequiredFieldValidator>


  </div>
 </div>


<div class="row">
<div class="c1">

    <asp:Button ID="btnmain1" runat="server" Text="Add Category" 
        onclick="btnmain1_Click" /></div>
<div class="c2">
    <asp:Button ID="btnmain2" runat="server" Text="Reset" />
</div>
<div class="c3"> 
  </div>
 </div>
 <div class="error"><asp:Label ID="lblerror" runat="server"></asp:Label>
</div>

<asp:Repeater ID="mainrep" runat="server" onitemcommand="mainrep_ItemCommand">
<HeaderTemplate>
<table style="width:100%">
<tr style="background-color:Black;color:Red">
<td style="width:40%">Mainid</td> 
<td style="width:40%">MCN</td>
<td style="width:20%">Action</td>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td style="width:40%">
<asp:Label ID="lblmainid" runat="server" Text='<%#Eval("maincategoryid") %>'></asp:Label>
</td>
<td style="width:40%">
<asp:Label ID="lblmainname" runat="server" text='<%#Eval("maincategoryname") %>'></asp:Label>
    <asp:TextBox ID="txtmainname" runat="server" visible="false" EnableViewState="true" Text='<%#Eval("maincategoryid") %>'></asp:TextBox>
</td>
<td style="width:20%">
<asp:LinkButton ID="linkedit" runat="server" CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("maincategoryid")%>'>Edit</asp:LinkButton>
<asp:LinkButton ID="linkdelete" runat="server" CausesValidation="false" CommandName="delete" CommandArgument='<%#Eval("maincategoryid")%>'>Delete</asp:LinkButton>
<asp:LinkButton ID="linkupdate" runat="server" CausesValidation="false" CommandName="update" Visible="false" CommandArgument='<%#Eval("maincategoryid")%>'>Update</asp:LinkButton>
<asp:LinkButton ID="linkcancel" runat="server" CausesValidation="false" CommandName="cancel" Visible="false" CommandArgument='<%#Eval("maincategoryid")%>'>Cancel</asp:LinkButton>
</td>
</tr>
</ItemTemplate>
<FooterTemplate></table></FooterTemplate>
</asp:Repeater>

</div>

</asp:Content>

