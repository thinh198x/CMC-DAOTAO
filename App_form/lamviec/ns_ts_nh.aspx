<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ts_nh.aspx.cs" Inherits="f_ns_ts_nh"
    Title="ns_ts_nh" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table>
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Nhập TimeSheet " />
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
                        <td valign="top" align="left" class="form_left">
                            <table>
                                <tr>
                                    <td align="left" id="Upa_tk" runat="server">
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label12" runat="server" CssClass="css_gchu" Text="Từ ngày" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="tu_ngay_ts" runat="server" CssClass="css_form_c" Width="90px" kt_xoa="Z"
                                                            ten="ngày khám" kieu_luu="I" kieu_date="true" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" CssClass="css_gchu_c" Text="Đến ngày" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="den_ngay_ts" runat="server" CssClass="css_form_c" Width="90px" kt_xoa="Z"
                                                            ten="ngày khám" kieu_luu="I" kieu_date="true" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight" style="padding-bottom: 5px;">
                                                        <a href="#" onclick="return ns_ts_nh_P_LKE();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">T</span>ìm kiếm</a>
                                                    </div>
                                                </td>
                                                <%--<td colspan="3">
                                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" Width="120px" OnClick="ns_ts_nh_P_LKE();" />
                                    </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" cot="ngay,so_phut,so_id" cotAn="so_id" CssClass="table gridX" loai="X" hangKt="10" hamRow="ns_ts_nh_P_CT()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="18px" />
                                                <asp:BoundField HeaderText="Ngày" DataField="ngay" HeaderStyle-Width="150px" ItemStyle-CssClass="css_ma_c" />
                                                <asp:BoundField HeaderText="Số phút" DataField="so_phut" HeaderStyle-Width="150px" ItemStyle-CssClass="css_ma_c" />
                                                <asp:BoundField HeaderText="" DataField="so_id" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" id="GR_lke_td" runat="server">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_ts_nh_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="right" valign="middle" class="form_right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu" Width="50px" Text="Việc" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_nhap ID="cv" runat="server" CssClass="css_form" Width="201px"
                                                        DataTextField="ten" DataValueField="ma" onchange="ns_ts_nh_P_LKE()" />
                                                </td>

                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label1" runat="server" CssClass="css_gchu" Text="Ngày" />
                                                </td>
                                                <td align="left">
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay" runat="server" CssClass="css_form" Width="200px" kt_xoa="Z"
                                                            ten="Ngày" kieu_luu="I" kieu_date="true" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label11" runat="server" CssClass="css_gchu" Text="Từ" />
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:so ID="TU_GIO" ten="Từ giờ" runat="server" CssClass="css_form_c" Width="50px" co_dau="K" so_tp="0" ToolTip="" MaxLength="2" kt_xoa="X" onfocusout="return ns_ts_nh_P_KTRA('GIO')" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:so ID="tu_phut" runat="server" CssClass="css_form_c" Width="50px" co_dau="K" so_tp="0" ToolTip="" MaxLength="2" kt_xoa="X" onfocusout="return ns_ts_nh_P_KTRA('GIO')" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label10" runat="server" CssClass="css_gchu" Text="Đến" />
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:so ID="DEN_GIO" ten="Đến giờ" runat="server" CssClass="css_form_c" Width="50px" co_dau="K" so_tp="0" ToolTip="" MaxLength="2" kt_xoa="X" onfocusout="return ns_ts_nh_P_KTRA('GIO')" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:so ID="den_phut" runat="server" CssClass="css_form_c" Width="50px" co_dau="K" so_tp="0" ToolTip="" MaxLength="2" kt_xoa="X" onfocusout="return ns_ts_nh_P_KTRA('GIO')" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label13" runat="server" CssClass="css_gchu" Text="Số phút" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:so ID="so_phut" runat="server" CssClass="css_form_c" Width="50px" co_dau="K" so_tp="0" ToolTip="" MaxLength="3" kt_xoa="X" Enabled="false" />
                                                            </td>
                                                            <td style="display: none">
                                                                <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Text="Hoàn thành(%)" />
                                                            </td>
                                                            <td align="left" style="display: none">
                                                                <Cthuvien:so ID="phan_tram_xong" runat="server" CssClass="css_form_c" Width="50px" co_dau="K" so_tp="0" ToolTip="" MaxLength="3" kt_xoa="X" Enabled="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="display: none">
                                                <td align="left">
                                                    <asp:Label ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Hoàn thành(%)" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:so ID="phan_tram" runat="server" CssClass="css_form_c" Width="50px" co_dau="K" so_tp="0" ToolTip="" MaxLength="2" kt_xoa="X" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Ghi Chú" />

                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="GHI_CHU" MaxLength="100" runat="server" CssClass="css_form" Width="200px" kieu_unicode="true" TextMode="MultiLine" Height="80px" kt_xoa="X" ten="Ghi Chú" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_ts_nh_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_ts_nh_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return ns_ts_nh_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                    </div>
                                                </td>
                                                <%-- <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" Text="Nhập" OnClick="return ns_ts_nh_P_NH();" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="70px" OnClick="return ns_ts_nh_P_XOA();" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" Width="70px" OnClick="return ns_ts_nh_P_MOI();" />
                                    </td>--%>
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="650,450" />
</asp:Content>
