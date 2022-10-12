<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_gan_nl_cdanh.aspx.cs" Inherits="f_ns_hdns_gan_nl_cdanh"
    Title="ns_hdns_gan_nl_cdanh" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Gán năng lực cho chức danh" />
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
                        <td class="form_left" valign="top" align="left">
                            <div class="css_divb">
                                <div>
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" CssClass="table gridX"
                                        hangKt="10" cotAn="so_id,nnnghiep,cdanh" hamRow="ns_hdns_gan_nl_cdanh_GR_lke_RowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="so_id" />
                                            <asp:BoundField DataField="nnnghiep" />
                                            <asp:BoundField DataField="ten_nnnghiep" HeaderText="Ngạch nghề nghiệp" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="cdanh" />
                                            <asp:BoundField DataField="ten_cdanh" HeaderText="Tên chức danh" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="ngay_hl" HeaderText="Ngày áp dụng" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField DataField="tong_n_nl" HeaderText="Tổng nhóm năng lực" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField DataField="tong_nl" HeaderText="Tổng năng lực" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                    ham="ns_hdns_gan_nl_cdanh_P_LKE()" />
                            </div>
                            <div style="margin-top: 15px; text-align: center;">
                                <Cthuvien:nhap ID="XuatExcel" runat="server" Text="Xuất excel" Width="90px" OnClick="return ns_hdns_gan_nl_cdanh_P_IN();form_P_LOI();" />
                            </div>
                        </td>
                        <td class="form_right" valign="top" align="left">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="0">
                                            <tr style="display: none">
                                                <td>
                                                    <Cthuvien:ma ID="so_id" runat="server" kt_xoa="X" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Ngạch nghề nghiệp" Width="120px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="NNNGHIEP" ten="Ngạch nghề nghiệp" runat="server" Width="270px" ktra="DT_NNN" onchange="ns_hdns_gan_nl_cdanh_P_KTRA('NNNGHIEP')" kt_xoa="G" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Chức danh" Width="120px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="CDANH" ten="Chức danh" runat="server" Width="270px" ktra="DT_CD" kt_xoa="X" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Ngày áp dụng" Width="120px" />
                                                </td>
                                                <td align="left">
                                                    <div class="ip-group date">
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_HL" runat="server" CssClass="css_form_c" ten="Ngày áp dụng" kt_xoa="G"
                                                            onchange="ns_hdns_gan_nl_cdanh_P_MA_KTRA('NGAY_HL')" Width="243px" />
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="1" cellspacing="1" style="width: 100%">
                                            <tr>
                                                <td colspan="2">
                                                    <div class="css_divb" style="margin-right: 20px;">
                                                        <div class="css_divCn">
                                                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                CssClass="table gridX" loai="N" cot="so_id_ct,so_id_nl_cd,so_id_nl,so_id_nl_ct,nhom_nl,ma_nl,ten_nhom_nl,ten_nl,muc_nl,mota"
                                                                cotAn="so_id_nl_cd,so_id_ct,so_id_nl,so_id_nl_ct,nhom_nl,ma_nl" hangKt="9" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                                <Columns>
                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                    <asp:BoundField DataField="so_id_nl_cd" />
                                                                    <asp:BoundField DataField="so_id_ct" />
                                                                    <asp:BoundField DataField="so_id_nl" />
                                                                    <asp:BoundField DataField="so_id_nl_ct" />
                                                                    <asp:BoundField DataField="nhom_nl" />
                                                                    <asp:BoundField DataField="ma_nl" />
                                                                    <asp:TemplateField HeaderText="Nhóm năng lực" HeaderStyle-Width="120px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="ten_nhom_nl" runat="server" CssClass="css_Gma"
                                                                                kieu_unicode="true" BorderStyle="None" Width="100%"
                                                                                MaxLength="100" Enabled="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Tên năng lực" HeaderStyle-Width="120px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="ten_nl" runat="server" CssClass="css_Gma"
                                                                                kieu_unicode="true" BorderStyle="None" Width="100%"
                                                                                MaxLength="100" Enabled="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Mức năng lực" HeaderStyle-Width="120px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="muc_nl" runat="server" CssClass="css_Gma" placeholder="Nhấn (F1)"
                                                                                kieu_unicode="true" BorderStyle="None" Width="100%" MaxLength="100"
                                                                                f_tkhao="~/App_form/ns/hdns/dm/ns_hdns_ma_nl.aspx" ReadOnly="true" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Mô tả" HeaderStyle-Width="120px">
                                                                        <ItemTemplate>
                                                                            <Cthuvien:ma ID="mota" Enabled="false" runat="server" Width="100%" CssClass="css_Gma" kieu_chu="true" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </Cthuvien:GridX>
                                                        </div>
                                                        <ctr_khud_divC:ctr_khud_divC ID="GR_ct_slide" runat="server" gridId="GR_ct" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_hdns_gan_nl_cdanh_HangLen();" />
                                                            </td>
                                                            <td>
                                                                <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_hdns_gan_nl_cdanh_HangXuong();" />
                                                            </td>
                                                            <td>
                                                                <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_hdns_gan_nl_cdanh_CatDong();" />
                                                            </td>
                                                            <td>
                                                                <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_hdns_gan_nl_cdanh_ChenDong('C');" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" Width="90px" OnClick="return ns_hdns_gan_nl_cdanh_P_MOI();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" OnClick="return ns_hdns_gan_nl_cdanh_P_NH();form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return form_P_TRA_CHON_GRID('GR_ct:phong,GR_ct:so_id_cd,GR_ct:ten');form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" OnClick="return ns_hdns_gan_nl_cdanh_P_XOA();form_P_LOI();" />
                                                            </td>
                                                            <td style="display: none">
                                                                <Cthuvien:nhap ID="Nhap2" runat="server" Width="90px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
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
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1230,540" />
</asp:Content>
