﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_tbl.aspx.cs" Inherits="f_ns_ma_tbl"
    Title="ns_ma_tbl" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thiết lập thang lương" />
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
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="10" cotAn="nsd" hamRow="ns_ma_tbl_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="80px">
                                                    <ItemStyle CssClass="css_Gma" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="150px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Trạng thái" DataField="tt" HeaderStyle-Width="80px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Ghi chú" DataField="note" HeaderStyle-Width="200px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="nsd" DataField="nsd">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" rong="70" loai="X" gridId="GR_lke"
                                            ham="ns_ma_tbl_P_LKE()" />
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
                                                    <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Text="Mã" />
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="MA" runat="server" CssClass="css_form" kieu_chu="True" ten="Mã thang lương"
                                                                    kt_xoa="G" onchange="ns_ma_tbl_P_KTRA('MA')" Width="150px" />
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
                                                    <asp:Label ID="Label3" runat="server" CssClass="css_gchu">Tên</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" ten="Tên thang lương"
                                                        Width="270px"></Cthuvien:ma>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="css_gchu">Trạng thái</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:kieu ID="tt" runat="server" lke="A,N" Width="30px" ToolTip="A - Áp dụng, N - Ngừng áp dụng" CssClass="css_form_c" Text="A" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu">Ghi chú</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="note" runat="server" TextMode="MultiLine" CssClass="css_form" kt_xoa="X" Height="50px"
                                                        Width="270px"></Cthuvien:nd>
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
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_ma_tbl_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_ma_tbl_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                        <a href="#" onclick="return ns_ma_tbl_P_IN();form_P_LOI();" class="bt bt-grey"><i class="fa fa-excel"></i><span class="txUnderline">X</span>uất excel</a>
                                                    </div>
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="1023,500" />
</asp:Content>
