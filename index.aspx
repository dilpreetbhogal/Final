<%@ Page Title="" Language="C#" MasterPageFile="~/guestmaster.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main-content">
    <div class="column-one-third">
       
                    	<h5 class="line"><span>Govt. jobs</span></h5>
         <asp:Repeater ID="Repeater1" runat="server">
              <ItemTemplate>
                        <div class="outertight">
                        	<ul class="block">

                                <li>
                                   
                                    <p>
                                        <span>Last Date: <%# Eval("lastdate") %></span>
                                        <a href='<%#GenerateMain(Eval("jobid"))%>'><%# Eval("jobtitle") %></a>
                                         <span class="salary"></span>
                                       Salary: <a href="#"><%# Eval("salary") %> </a>
                                       <span class="companyname"></span>
                                        Company Name: <a href='<%#GenerateMain(Eval("companyid"))%>'><%# Eval("companyname") %></a>
                                    </p>
                                    <span class="rating"><span style="width:80%;"></span></span>
                                </li>
                                
                            </ul>
                        </div></ItemTemplate>
                       </asp:Repeater>
                    </div>
         <div class="column-one-third">
       
                    	<h5 class="line"><span>Private jobs</span></h5>
         <asp:Repeater ID="Repeater2" runat="server">
              <ItemTemplate>
                        <div class="outertight">
                        	<ul class="block">

                                <li>
                                   
                                    <p>
                                        <span>Last Date: <%# Eval("lastdate") %></span>
                                        <a href='<%#GenerateMain(Eval("jobid"))%>'><%# Eval("jobtitle") %></a>
                                          <span class="salary"></span>
                                       Salary: <a href="#"><%# Eval("salary") %> </a>
                                       <span class="companyname"></span>
                                        Company Name: <a href='<%#GenerateMain(Eval("companyid"))%>'><%# Eval("companyname") %></a>
                                  
                                    </p>
                                    <span class="rating"><span style="width:80%;"></span></span>
                                </li>
                                
                            </ul>
                        </div></ItemTemplate>
                       </asp:Repeater>
                    </div>
        </div>
        <div class="column-one-third">
       <div class="sidebar">
                    	<h5 class="line"><span>International jobs</span></h5>
         <asp:Repeater ID="Repeater3" runat="server">
              <ItemTemplate>
                        <div class="outertight">
                        	<ul class="block">

                                <li>
                                   
                                    <p>
                                        <span>Last Date: <%# Eval("lastdate") %></span>
                                        <a href='<%#GenerateMain(Eval("jobid"))%>'><%# Eval("jobtitle") %></a>
                                          <span class="salary"></span>
                                        Salary:<a href="#"><%# Eval("salary") %> </a>
                                       <span class="companyname"></span>
                                        Company Name: <a href='<%#GenerateMain(Eval("companyid"))%>'><%# Eval("companyname") %></a>
                                  

                                    </p>
                                    <span class="rating"><span style="width:80%;"></span></span>
                                </li>
                                
                            </ul>
                        </div></ItemTemplate>
                       </asp:Repeater>
                    </div>
            </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<section id="slider">
            <div class="container">s
                <div class="main-slider">
                	<div class="badg">
                    	<p><a href="#">Popular.</a></p>
                    </div>
                	<div class="flexslider">
                        <ul class="slides">
                            <li>
                                <img src="slider/slider1.jpg" alt="MyPassion" />
                                <p class="flex-caption"><a href="#"> Orison Swett Marden. </a>  When a man feels throbbing within him the power to do what he undertakes as well as it can possibly be done, this is happiness, this is Success./p>
                            </li>
                            <li>
                                <img src="slider/slider5.jpg" alt="MyPassion" />
                                <p class="flex-caption"><a href="#">Small Businesses Surge against all expectations.</a> Making money is an art and working is art and good business is the best art.</p>
                            </li>
                            <li>
                                <img src="slider/slider3.jpg" alt="MyPassion" />
                                <p class="flex-caption"><a href="#">Andy Warhol: Future of disaster response?</a> If you cann't do great things, do small things in great way. </p>
                            </li>
                            <li>
                                <img src="slider/slider4.jpg" alt="MyPassion" />
                                <p class="flex-caption"><a href="#">Harold S. Geneen. </a>In the business world ,everyone is paid in two coins:cash and experience.Take the experience first;the cash will come later. </p>
                            </li>
                           
                        </ul>
                    </div>
                </div>
                
                <div class="slider2">
                	<div class="badg">
                    	<p><a href="#">Latest.</a></p>
                    </div>
                    <a href="#"><img src="slider/slider2.jpg" alt="MyPassion" /></a>
                    <p class="caption"><a href="#">We Are News.</a> A consultant is someone who saves his client almost enough to pay his fee. </p>
                </div>
                
                <div class="slider3">
                	<a href="#"><img src="slider/slider3.jpg" alt="MyPassion" /></a>
                    <p class="caption"><a href="#">Time is the scarcest resources and unless it is managed nothing else can be managed. </a></p>
                </div>
                
                <div class="slider3">
                	<a href="#"><img src="slider/slider6.jpg" alt="MyPassion" /></a>
                    <p class="caption"><a href="#">The first responsibility of a leader is to define reality.In between the leader is a servant.</a></p>
                </div>
                
            </div>    
        </section>
</asp:Content>
