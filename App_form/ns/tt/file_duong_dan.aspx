﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="file_duong_dan.aspx.cs" Inherits="f_file_duong_dan"
    Title="file_duong_dan" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục ngành nghề" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <div class="acc">
                                            <ul>
                                                <li><a href="#" onclick="return form_dong();"><i class="fa fa-sign-out"></i></a></li>
                                                <li><a href="#" onclick="return form_GOP();"><i class="fa fa-envelope-o"></i></a></li>
                                                <li><a href="#" onclick="return form_HELP();"><i class="fa fa-question"></i></a></li>
                                            </ul>
                                            <div class="clear"></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="form_left" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false"
                                            CssClass="table gridX" loai="X" hangKt="10" cotAn="tt,ghichu,nsd" hamRow="file_duong_dan_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã ngành nghề" DataField="ma" HeaderStyle-Width="120px">
                                                    <ItemStyle CssClass="css_Gma" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tên ngành nghề" DataField="ten" HeaderStyle-Width="150px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField> 
                                                <asp:BoundField HeaderText="Trạng thái" DataField="tthai" HeaderStyle-Width="100px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>                                               
                                                <asp:BoundField DataField="tt" /> 
                                                <asp:BoundField DataField="ghichu" /> 
                                                <asp:BoundField DataField="nsd" />                                                
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" rong="70" loai="X" gridId="GR_lke"
                                            ham="file_duong_dan_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu" Text="Tên ngành nghề" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="K" ten="Tên ngành nghề"
                                                        Width="270px"></Cthuvien:ma>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Mã ngành nghề" />
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="MA" runat="server" CssClass="css_form" kieu_chu="True" ten="Mã ngành nghề"
                                                                    kt_xoa="G" MaxLength="3" onchange="file_duong_dan_P_KTRA('MA')" Width="150px" />
                                                            </td>
                                                            <td style="width: 100px">
                                                                <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu2" kt_xoa="X" Font-Bold="true" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Trạng thái" Width="70px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_nhap ID="TT" ten="Trạng thái" runat="server" DataTextField="ten" DataValueField="ma"
                                                        CssClass="css_form" kieu="S" Width="270px">
                                                        <asp:ListItem Selected="True" Text="Áp dụng" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="Ngừng áp dụng" Value="N"></asp:ListItem>
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                            </tr>   
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu">Ghi chú</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:FileUpload ID="chon_file" runat="server" Width="250px" ForeColor="White" CssClass="css_form" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td align="center">
                                                    <div class="box3 txCenter">
                                                        <a href="#" onclick="return file_duong_dan_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return file_duong_dan_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON_P('TEN,TEN');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                    </div>
                                                    
                                                </td>
                                                
                                                
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                                                </td>

                                            </tr>
                                            <tr>
                                                <td align="center">
                                                     <div  class="box3 txRight">    
                                                        <a href="#" onclick="return file_duong_dan_P_IN();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">X</span>uất excel</a>
                                                        <a href="#" onclick="return file_duong_dan_P_MAU();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">E</span>xcel mẫu</a>
                                                        <a href="#" onclick="return file_duong_dan_FILE_Import();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">Nh</span>ập excel</a>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="ten_form" runat="server" Value="" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="900,500" />
   <Cthuvien:an ID="luu_day" runat="server" Value="" />
</asp:Content>
