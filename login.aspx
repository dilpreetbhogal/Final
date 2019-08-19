<%@ Page Title="" Language="C#" MasterPageFile="guestmaster.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="contact-form">
        <h4>User Login</h4>
                         <div class="form">
                                <label>Email</label>
                                <div class="input">
                                    <span class="name"></span>
                                    <asp:TextBox ID="txtmail" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="revmail" runat="server" 
        ErrorMessage="Mismatch Expression" ControlToValidate="txtmail" 
        ValidationGroup="feedback" Display="Dynamic" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                            </div>
        <div class="form">
                                <label>password</label>
                                <div class="input">
                                    <span class="name"></span>
                                    <asp:TextBox ID="txtpass" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvpass" runat="server" ErrorMessage="Text must not be empty" ControlToValidate="txtpass" ValidationGroup="feedback" Display="Dynamic">
    </asp:RequiredFieldValidator>
                                </div>
                            </div>
    <div class="form2">
                                <asp:Button ID="Button1" runat="server" Text="Login" CssClass="send" OnClick="Button1_Click"  />
                            </div>    
    </div>

    <div class="alertMessage">

        <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

