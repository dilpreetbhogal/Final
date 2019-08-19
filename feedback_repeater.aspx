<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="feedback_repeater.aspx.cs" Inherits="feedback_repeater" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <asp:Repeater ID="feedbackrep" runat="server">
<HeaderTemplate>
<table style="width:100%">
<tr style="background-color:Black;color:Red">
<td style="width:30%">first name</td> 
<td style="width:30%">email</td>
<td style="width:30%">phone no</td>
<td style="width:30%">subject</td>
<td style="width:30%">message</td>            
<td style="width:10%">Action</td>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td style="width:40%">
<asp:Label ID="lblfn" runat="server" Text='<%#Eval("fn") %>'></asp:Label>
</td>
<td style="width:40%">
<asp:Label ID="lblemail" runat="server" Text='<%#Eval("email") %>'></asp:Label>
<td style="width:40%">
<asp:Label ID="lblsubject" runat="server" Text='<%#Eval("subject") %>'></asp:Label>

<td style="width:40%">
<asp:Label ID="lblpn" runat="server" Text='<%#Eval("pn") %>'></asp:Label>
<td style="width:40%">
<asp:Label ID="lblmessage" runat="server" Text='<%#Eval("message") %>'></asp:Label>
 </td>
<td style="width:20%">
</td>
</tr>
</ItemTemplate>
<FooterTemplate></table></FooterTemplate>
</asp:Repeater>

 <div class="error"><asp:Label ID="lblerror" runat="server"></asp:Label>
</div>




</asp:Content>

