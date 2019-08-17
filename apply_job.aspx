<%@ Page Title="" Language="C#" MasterPageFile="~/guestmaster.master" AutoEventWireup="true" CodeFile="apply_job.aspx.cs" Inherits="apply_job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="contact-form">
        <h4>Job Details</h4>
                         <div class="form">
                                <label>Job Title</label>
                                <div class="input">
                                    <span class="name"></span>
                                    <asp:TextBox ID="j_title" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form">
                                <label>Last Date to Apply</label>
                                <div class="input">
                                    <span class="email"></span>
                                     <asp:TextBox ID="TextBox6" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form">
                                <label>No. Of Posts</label>
                                <div class="input">
                                    <span class="website"></span>
                                     <asp:TextBox ID="TextBox7" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            
        </div><div class="contact-form">
            <h4>Applicant's Details</h4>
                            <div class="form">
                                <label>Name*</label>
                                <div class="input">
                                    <span class="name"></span>
                                    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form">
                                <label>Email*</label>
                                <div class="input">
                                    <span class="email"></span>
                                     <asp:TextBox ID="TextBox2" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                           
                            <div class="form">
                                <label>Message*</label>
                                 <div class="input">
                                 <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
                                     </div>
                            </div>
        <div class="form">
                                <label>Expected time to Join</label>
             <div class="input" >
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="input" style="border:1px solid #808080; ">
                <asp:ListItem>Within a Week</asp:ListItem>
                <asp:ListItem>15 Days</asp:ListItem>
                <asp:ListItem>1 Month</asp:ListItem>
                <asp:ListItem>More Than a Month</asp:ListItem>


            </asp:DropDownList>
                 </div>
                            </div>
                            <div class="form2">
                                <asp:Button ID="Button1" runat="server" Text="Button" CssClass="send" OnClick="Button1_Click" />
                            </div>
                            
                        
                        
                        <div class="alertMessage">

                            <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
</asp:Content>

