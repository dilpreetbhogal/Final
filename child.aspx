 <%@ Page Title="" Language="C#" MasterPageFile="guestmaster.master" AutoEventWireup="true" CodeFile="child.aspx.cs" Inherits="Mainpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblerror" runat="server"></asp:Label>
 
 <div class="clear"></div>
        <div class="heading-l">
          <h2> Available Jobs </h2>
        </div>
        <div class="main-content">
                	
                    <!-- Popular News -->
                	         <div class="column-three-third">
                    	<h5 class="line">
                        	<span><asp:Label runat="server" ID="mainlbl"></asp:Label></span>
                           
                        </h5>
                        
        <asp:Repeater ID="repbind" runat="server" OnItemDataBound="repbindData">
        <ItemTemplate>
       
                        <div class="outertight">
                        	
                            <h3 class="regular"><a href="#"><%#Eval("jobtitle") %></a></h3>
							<span class="meta"><%#DataBinder.Eval(Container.DataItem, "lastdate", "{0:M/d/yy}")%>   //   
                                 <asp:Label runat="server" ID="maincatlbl"></asp:Label> </span>
                            <p>
<%#Eval("description") %>
                            </p>
                             <p><a href='<%#GenerateMain(Eval("jobid"))%>' class="button">View Details</a></p>
                        </div>
                        
                 

                        
     
                        
        </ItemTemplate>
        
        
        </asp:Repeater>
  </div>
                    <!-- /Popular News -->
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