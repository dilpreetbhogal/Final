<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="job_repeater.aspx.cs" Inherits="job_repeater" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Repeater ID="jobrep" runat="server" onitemcommand="jobrep_ItemCommand">
<HeaderTemplate>
<table style="width:100%">
<tr style="background-color:Black;color:Red">
<td style="width:10%">jobid</td> 
<td style="width:10%">jobtitle</td>
<td style="width:10%">maincategoryname</td>
<td style="width:10%">subcategoryname</td>
<td style="width:10%">childcategoryname</td>
<td style="width:10%">description</td>
<td style="width:10%">qualification</td>
<td style="width:10%">salary</td>
<td style="width:10%">designation</td>
<td style="width:10%">companyid</td>
<td style="width:10%">numberofposts</td>
<td style="width:10%">keyskills</td>
<td style="width:10%">countryname</td>
<td style="width:10%">statename</td>
<td style="width:10%">cityname</td>  
<td style="width:10%">lastdate</td>          
<td style="width:10%">Action</td>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td style="width:20%">
<asp:Label ID="lbljobid" runat="server" Text='<%#Eval("jobid") %>'></asp:Label>
</td>
<td style="width:20%">
<asp:Label ID="lbljobtitle" runat="server" Text='<%#Eval("jobtitle") %>'></asp:Label>
<asp:TextBox ID="txtjobtitle" runat="server" Visible="false" EnableViewState="true" Text='<%#Eval("jobtitle") %>'></asp:TextBox>
</td>
<td style="width:20%">
<asp:Label ID="lblmaincategory" runat="server" Text='<%#Eval("maincategoryname") %>'></asp:Label>
</td>
<td style="width:20%">
<asp:Label ID="lblsubcategory" runat="server" Text='<%#Eval("subcategoryname") %>'></asp:Label>
</td>
<td style="width:20%">
<asp:Label ID="lblchildcategory" runat="server" Text='<%#Eval("childcategoryname") %>'></asp:Label>

<td style="width:20%">
<asp:Label ID="lbldescription" runat="server" Text='<%#Eval("description") %>'></asp:Label>
<td style="width:20%">
<asp:Label ID="lblqualification" runat="server" Text='<%#Eval("qualification") %>'></asp:Label>
<td style="width:20%">
<asp:Label ID="lblsalary" runat="server" Text='<%#Eval("salary") %>'></asp:Label>
<td style="width:20%">
<asp:Label ID="lbldesignation" runat="server" Text='<%#Eval("designation") %>'></asp:Label>
<td style="width:20%">
<asp:Label ID="lblcompanynae" runat="server" Text='<%#Eval("companyid") %>'></asp:Label>
<td style="width:20%">
<asp:Label ID="lblnumberofposts" runat="server" Text='<%#Eval("numberofposts") %>'></asp:Label>
<td style="width:20%">
<asp:Label ID="lblkeyskills" runat="server" Text='<%#Eval("keyskills") %>'></asp:Label>
<td style="width:20%">
<asp:Label ID="lblcountry" runat="server" Text='<%#Eval("countryname") %>'></asp:Label>
<td style="width:20%">
<asp:Label ID="lblstate" runat="server" Text='<%#Eval("statename") %>'></asp:Label>
<td style="width:20%">
<asp:Label ID="lblcity" runat="server" Text='<%#Eval("cityname") %>'></asp:Label>
<td style="width:20%">
<asp:Label ID="lbllastdate" runat="server" Text='<%#Eval("lastdate") %>'></asp:Label>
</td>
<td style="width:20%">
<asp:LinkButton ID="linkedit" runat="server" CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("jobid")%>'>Edit</asp:LinkButton>
<asp:LinkButton ID="linkdelete" runat="server" CausesValidation="false" CommandName="delete" CommandArgument='<%#Eval("jobid")%>'>Delete</asp:LinkButton>
<asp:LinkButton ID="linkupdate" runat="server" CausesValidation="false" CommandName="update" Visible="false" CommandArgument='<%#Eval("jobid")%>'>Update</asp:LinkButton>
<asp:LinkButton ID="linkcancel" runat="server" CausesValidation="false" CommandName="cancel" Visible="false" CommandArgument='<%#Eval("jobid")%>'>Cancel</asp:LinkButton>
</td>
</tr>
</ItemTemplate>
<FooterTemplate></table></FooterTemplate>
</asp:Repeater>

 <div class="error"><asp:Label ID="lblerror" runat="server"></asp:Label>
</div>
</asp:Content>

