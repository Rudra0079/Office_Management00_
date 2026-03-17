<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="HolidayList.aspx.cs" Inherits="Orient.HolidayList" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MedPart">

        <div id="page-wrapper" style="background-color:White;">

            <div class="container-fluid">

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                           <small>List of Holidays</small>
                        </h1>
                      <asp:Label ID="lblmsg" runat="server"></asp:Label>
                          
                                    <div class="divOverflow" >
                            <div class="p1">
                              
                                        <asp:GridView ID="grdHolidayDetail" runat="server" GridLines="None" CssClass="table table-bordered table-striped table-hover"
                                            AutoGenerateColumns="false"
                                            EmptyDataText="No More Record">
                                            <Columns>
                                            <asp:TemplateField HeaderText="S.No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProject" runat="server" Text='<%# bind("SNo") %>' CssClass="tdstyle1"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Month">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProject" runat="server" Text='<%# bind("Month") %>' CssClass="tdstyle1"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Purpose">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProject" runat="server" Text='<%# bind("Purpose") %>' CssClass="tdstyle1"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProject" runat="server" Text='<%# bind("Date") %>' CssClass="tdstyle1"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerSettings PageButtonCount="5" Position="Bottom" Mode="NumericFirstLast" FirstPageText="First"
                                                LastPageText="Last" />
                                            <PagerStyle CssClass="gridviewPager"></PagerStyle>
                                        </asp:GridView>
                                   
                            </div>
                        </div>


                                   
                               
                     
                     </div>
                    </div>
                </div>
                <!-- /.row -->

            </div>
        </asp:Content>