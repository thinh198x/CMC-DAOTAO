<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_tluong_dvi.aspx.cs" Inherits="f_ns_hdns_tluong_dvi"
    Title="ns_hdns_tluong_dvi" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thiết lập hệ thống thang bảng lương cho các công ty" />
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
                                        <div>
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="10" cotAn="so_id,ma_tl,ma_nl,cty" hamRow="ns_hdns_tluong_dvi_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Công ty" DataField="ten_cty" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:BoundField HeaderText="Thang lương" DataField="ten_tl" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:BoundField HeaderText="Ngạch lương" DataField="ten_nl" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:BoundField HeaderText="Tổng bậc lương" DataField="tong_bl" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma_r" />
                                                    <asp:BoundField HeaderText="Ngày áp dụng" DataField="ngay_hl" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma_c" />
                                                    <asp:BoundField DataField="so_id" />
                                                    <asp:BoundField DataField="ma_tl" />
                                                    <asp:BoundField DataField="ma_nl" />
                                                    <asp:BoundField DataField="cty" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" gridId="GR_lke" ham="ns_hdns_tluong_dvi_P_LKE()" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="height: 30px; padding-top: 20px">
                                        <Cthuvien:nhap ID="excel" runat="server" Width="90px" Text="Xuất excel" OnClick="return ns_hdns_tluong_dvi_P_IN();form_P_LOI();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right" valign="top">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1" style="width: 680px;">
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="2">
                                            <tr style="display: none;">
                                                <td align="left" style="width: 143px"></td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="so_id" runat="server" kt_xoa="X" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 143px">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Công ty" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="CTY" runat="server" ten="Công ty" ToolTip="Công ty" kt_xoa="G" ktra="DT_MA_DVI" Width="200px" CssClass="css_list" onchange="ns_hdns_tluong_dvi_P_KTRA('MA_NL')" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 143px">
                                                    <Cthuvien:bbuoc ID="Label5" runat="server" CssClass="css_gchu" Text="Thang lương" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="MA_TL" runat="server" ten="Thang lương" ToolTip="Thang lương" kt_xoa="G" ktra="DT_MA_TL" Width="200px" CssClass="css_list" onchange="ns_hdns_tluong_dvi_P_KTRA('MA_TL')" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Ngạch lương" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="MA_NL" runat="server" ten="Ngạch lương" ToolTip="Ngạch lương" MaxLength="30" kt_xoa="G" ktra="DT_MA_NL" Width="200px" CssClass="css_list" onchange="ns_hdns_tluong_dvi_P_KTRA('MA_NL')" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label4" runat="server" CssClass="css_gchu" Text="Ngày áp dụng" />
                                                </td>
                                                <td align="left">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <div class="ip-group date" style="margin-left: -4px;">
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_HL" ten="Ngày hiệu lực" runat="server" Width="170px" CssClass="css_form_c" kt_xoa="G" kieu_luu="I" BackColor="#f6f7f7" onfocusout="ns_hdns_tluong_dvi_P_KTRA('MA_NL')" />
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-top: 10px">
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left" valign="top" style="padding-bottom: 2px">
                                                                <div class="css_divb">
                                                                    <div class="css_divCn">
                                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="N"
                                                                            cot="bacluong,tongluong,luong_cb,thuong_dg,trang_thai,so_id,so_id_bl" cotAn="so_id,so_id_bl" hangKt="5" hamUp="ns_hdns_tluong_dvi_GR_Update">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                <asp:TemplateField HeaderText="Bậc lương(*)" HeaderStyle-Width="100px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:ma ID="bacluong" runat="server" CssClass="css_Gma" kt_xoa="X" MaxLength="100" Width="100px" Enabled="false" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Tổng lương(*)" HeaderStyle-Width="100px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:so ID="tongluong" runat="server" MaxLength="15" Width="100px" CssClass="css_Gso" kt_xoa="X" co_dau="K" Enabled="false" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Lương cơ bản" HeaderStyle-Width="100px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:so ID="luong_cb" runat="server" MaxLength="15" Width="100px" CssClass="css_Gso" kt_xoa="X" co_dau="K" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Thưởng đánh giá tháng" HeaderStyle-Width="165px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:so ID="thuong_dg" runat="server" Width="165px" CssClass="css_Gso" MaxLength="15" BackColor="#f6f7f7" kt_xoa="X" co_dau="K" Enabled="false" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Trạng thái" HeaderStyle-Width="120px">
                                                                                    <ItemTemplate>
                                                                                        <Cthuvien:kieu ID="trang_thai" lke=",Áp dụng,Ngừng áp dụng" tra=",A,N" CssClass="css_Gma" runat="server" Width="120px" ten="Trạng thái" ToolTip="Trạng thái" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="so_id" />
                                                                                <asp:BoundField DataField="so_id_bl" />
                                                                            </Columns>
                                                                        </Cthuvien:GridX>
                                                                    </div>
                                                                    <ctr_khud_divC:ctr_khud_divC ID="GR_ct_slide" runat="server" gridId="GR_ct" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="padding-top: 5px;">
                                                                <table id="UPa_nhap_grd_dd" border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_hdns_tluong_dvi_HangLen(1);" />
                                                                        </td>
                                                                        <td>
                                                                            <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_hdns_tluong_dvi_HangXuong(1);" />
                                                                        </td>
                                                                        <td>
                                                                            <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_hdns_tluong_dvi_CatDong(1);" />
                                                                        </td>
                                                                        <td>
                                                                            <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_hdns_tluong_dvi_ChenDong('C');" />
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
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" CssClass="css_button" OnClick="return ns_hdns_tluong_dvi_P_MOI();form_P_LOI();" Width="100px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" CssClass="css_button" OnClick="return ns_hdns_tluong_dvi_P_NH();form_P_LOI();" Width="70px" />
                                                </td>
                                                <%--<td>
                                                    <Cthuvien:nhap ID="Export" runat="server" Text="File mẫu" CssClass="css_button" OnClick="return ns_hdns_tluong_dvi_P_MAU();form_P_LOI();" Width="70px" />
                                                </td>--%>
                                                <td>
                                                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" CssClass="css_button" OnClick="return form_P_TRA_CHON('');form_P_LOI();" Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_hdns_tluong_dvi_P_XOA();form_P_LOI();" Width="70px" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="btn_excel_mau" runat="server" Text="Mẫu excel" Width="70px" OnServerClick="btn_excel_mau_Click" />
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
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1380,550" />
    </div>
</asp:Content>
