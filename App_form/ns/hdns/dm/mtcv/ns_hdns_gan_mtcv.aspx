<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_gan_mtcv.aspx.cs" Inherits="f_ns_hdns_gan_mtcv"
    Title="ns_hdns_gan_mtcv" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Gán vị trí MTCV sử dụng cho mỗi đơn vị" />
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
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false"
                                                CssClass="table gridX" loai="X" hangKt="10" cot="ma_ts,ten_phong,ngay_hl,ma_phong,so_id,nsd" cotAn="ma_phong,so_id,ma,nsd" hamRow="ns_hdns_gan_mtcvdvi_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Mã phòng ban" DataField="ma_ts" HeaderStyle-Width="150px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Tên phòng ban" DataField="ten_phong" HeaderStyle-Width="150px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Ngày áp dụng" DataField="ngay_hl" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gma_c" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ma_phong" />
                                                    <asp:BoundField DataField="so_id" />
                                                    <asp:BoundField DataField="nsd" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" gridId="GR_lke" ham="ns_hdns_gan_mtcvdvi_P_LKE()" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top: 10px">
                                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" hoi="3" Width="100px" OnClick="return ns_hdns_gan_mtcvdvi_P_EXCEL();form_P_LOI();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right" valign="top">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr style="display: none">
                                                <td>
                                                    <Cthuvien:ma ID="so_id" runat="server" kt_xoa="X" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Phòng" Width="80px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="PHONG" ten="Phòng" runat="server" Width="367px" ktra="DT_PH" onchange="ns_hdns_gan_mtcvdvi_P_MA_KTRA();" kt_xoa="G" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Ngày áp dụng" />
                                                </td>
                                                <td align="left">
                                                    <div class="ip-group date">
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_HL" runat="server" CssClass="css_form_c" ten="Ngày áp dụng" kt_xoa="G" onchange="ns_hdns_gan_mtcvdvi_P_MA_KTRA();" Width="340px" />
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                    </div>
                                                </td>
                                            </tr>

                                            <tr style="display: none">
                                                <td align="left" colspan="2">
                                                    <Cthuvien:so ID="so_id_mtcv" runat="server" kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="css_divb">
                                            <div class="css_divCn">
                                                <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                    CssClass="table gridX" loai="N" cot="ten_nnn,ten_cd,SO_ID_MTCV,so_id" cotAn="SO_ID_MTCV,so_id" hangKt="5" gchuId="gchu" ctrT="so_tt" ctrS="nhap" hamRow="ns_hdns_gan_mtcvdvi_CT_P_CHUYEN_HANG()">
                                                    <Columns>
                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                        <asp:TemplateField HeaderText="Ngạch ngành nghề" HeaderStyle-Width="200px">
                                                            <ItemTemplate>
                                                                <Cthuvien:ma ID="ten_nnn" runat="server" ReadOnly="true" CssClass="css_Gma" kt_xoa="X" f_tkhao="~/App_form/ns/hdns/dm/mtcv/hdns_mota_cv.aspx" Width="200px" placeholder="Nhấn (F1)" BackColor="#f6f7f7" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tên chức danh" HeaderStyle-Width="200px">
                                                            <ItemTemplate>
                                                                <Cthuvien:ma ID="ten_cd" Enabled="false" runat="server" Width="200px" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="SO_ID_MTCV" />
                                                        <asp:BoundField DataField="so_id" />
                                                    </Columns>
                                                </Cthuvien:GridX>
                                            </div>
                                            <ctr_khud_divC:ctr_khud_divC ID="GR_ct_slide" runat="server" gridId="GR_ct" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_hdns_gan_mtcvdvi_CatDong();" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" hoi="4" Width="100px" OnClick="return ns_hdns_gan_mtcvdvi_P_MOI();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="100px" OnClick="return ns_hdns_gan_mtcvdvi_P_NH();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="mau" runat="server" Text="File mẫu" Width="100px" OnClick="return ns_hdns_gan_mtcvdvi_P_MAU();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="import" runat="server" Text="Nhập từ Excel" hoi="12" Width="100px" OnClick="return ns_hdns_gan_mtcvdvi_FILE_IMPORT();form_P_LOI();" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="XuatExcel" runat="server" Width="100px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="InExcel" runat="server" Width="100px" Text="In" OnServerClick="In_Click" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="FileMau" runat="server" Text="File mẫu" Width="100px" OnServerClick="FileMau_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="7" align="center">
                                                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" OnClick="return form_P_TRA_CHON_GRID('GR_ct:ma,GR_ct:ten');form_P_LOI();" />
                                                    <Cthuvien:nhap ID="in" runat="server" Text="In" Width="100px" OnClick="return ns_hdns_gan_mtcvdvi_P_IN();form_P_LOI();" />
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" OnClick="return ns_hdns_gan_mtcvdvi_P_XOA();form_P_LOI();" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="1030,550" />
</asp:Content>
