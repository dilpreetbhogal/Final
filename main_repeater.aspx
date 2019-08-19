<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="main_repeater.aspx.cs" Inherits="main_repeater" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <asp:Repeater ID="mainrep" runat="server">
<HeaderTemplate>
<table style="width:100%">
<tr style="background-color:Black;color:Red">
<td style="width:30%">first name</td> 
<td style="width:30%">last name</td>
<td style="width:30%">father name</td>
<td style="width:30%">qualification</td>
<td style="width:30%">gender</td>
<td style="width:30%">security question</td>
<td style="width:30%">security answer</td>
<td style="width:30%">country</td>
<td style="width:30%">state</td>
<td style="width:30%">city</td>
<td style="width:30%">address</td>
<td style="width:30%">phone no</td>
<td style="width:30%">email</td>
<td style="width:30%">pin code</td>
<td style="width:30%">resume</td>
<td style="width:30%">registeration</td>            
<td style="width:10%">Action</td>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td style="width:40%">
<asp:Label ID="lblfn" runat="server" Text='<%#Eval("fn") %>'></asp:Label>
</td>
<td style="width:40%">
<asp:Label ID="lblln" runat="server" Text='<%#Eval("ln") %>'></asp:Label>
</td>
<td style="width:40%">
<asp:Label ID="lblftn" runat="server" Text='<%#Eval("fathersname") %>'></asp:Label>
<td style="width:40%">
<asp:Label ID="lblqul" runat="server" Text='<%#Eval("qual") %>'></asp:Label>
<td style="width:40%">
<asp:Label ID="lblgender" runat="server" Text='<%#Eval("gender") %>'></asp:Label>
<td style="width:40%">
<asp:Label ID="lblquestion" runat="server" Text='<%#Eval("securityquestion") %>'></asp:Label>
<td style="width:40%">
<asp:Label ID="lblanswer" runat="server" Text='<%#Eval("securityanswer") %>'></asp:Label>
<td style="width:40%">
<asp:Label ID="lblcountry" runat="server" Text='<%#Eval("countryname") %>'></asp:Label>
<td style="width:40%">
<asp:Label ID="lblstate" runat="server" Text='<%#Eval("statename") %>'></asp:Label>
<td style="width:40%">
<asp:Label ID="lblcity" runat="server" Text='<%#Eval("cityname") %>'></asp:Label>
<td style="width:40%">
<asp:Label ID="lbladdress" runat="server" Text='<%#Eval("address") %>'></asp:Label>
<td style="width:40%">
<asp:Label ID="lblpn" runat="server" Text='<%#Eval("pn") %>'></asp:Label>
<td style="width:40%">
<asp:Label ID="lblemail" runat="server" Text='<%#Eval("email") %>'></asp:Label>
<td style="width:40%">
<asp:Label ID="lblpass" runat="server" Text='<%#Eval("password") %>'></asp:Label>
<td style="width:40%">
<asp:Label ID="lblpc" runat="server" Text='<%#Eval("pin") %>'></asp:Label>
<td style="width:40%">
<asp:Label ID="lblresume" runat="server" Text='<%#Eval("resume") %>'></asp:Label>
 
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

