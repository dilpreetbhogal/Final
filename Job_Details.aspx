<%@ Page Title="" Language="C#" MasterPageFile="~/guestmaster.master" AutoEventWireup="true" CodeFile="Job_Details.aspx.cs" Inherits="Job_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
     <div class="main-content">
          <asp:Repeater ID="repbind" runat="server"><ItemTemplate> 
     <div class="column-two-third single">
           <h4 class="title"><%# Eval("jobtitle") %></h4>
                          	<div class="flexslider">
                            <ul class="slides">
                                <li>
                                    <img src='<%# Eval("image") %>' runat="server" alt="MyPassion" />
                                </li>
                                
                            </ul>
                        </div>
                        
                        <h6 class="title"><%# Eval("jobtitle") %> 

                            <a href='<%#GenerateMain2(Eval("jobid"))%>' class="button" style="float:right;"> Apply For Job </a>
                        </h6>
                      Last Date to apply:  <span class="meta"><%# Eval("lastdate") %></span>
                        <p> <strong>Description: </strong><%# Eval("description") %></p>
             <p><strong>Key Skills: </strong><%# Eval("keyskills") %>
                 <br /><br />
                 <strong>Eligibility: </strong><%# Eval("qualification") %>
                 <br /><br />
                 <strong>Salary Offered: </strong><%# Eval("salary") %>
               <br /><br /><strong>Designation:</strong>  <%# Eval("designation") %>
                <br /><br /><strong>Total No of Vacancies:</strong>  <%# Eval("numberofposts") %> Post(s).
                 <br /><br /><strong>Company Name:</strong>  <%# Eval("companyname") %>


             </p></div>
               </ItemTemplate></asp:Repeater>
              </div>
                    
  <div class="column-one-third">
                	<div class="sidebar">
                    	<h5 class="line"><span>Latest Jobs.</span></h5>
                        <ul >
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                        	<li>
                                    	<a href='<%#GenerateMain(Eval("jobid"))%>' class="title"><%#Eval("jobtitle") %></a>
                                        <span class="meta">last Date: <%#Eval("lastdate") %>   </span>
                                        
                                    </li></ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    
        
        
        

              </div>
              
</asp:Content>

