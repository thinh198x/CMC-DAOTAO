<%@ Page Title="ns_td_hinhthuc" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_hinhthuc.aspx.cs" Inherits="f_ns_td_hinhthuc" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Đề xuất hình thức tuyển dụng" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width:50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
                                        <img id="Img2" runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
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
                <table cellpadding="1" cellspacing="1">
        <tr>
            <td align="left" valign="top">
                <table cellpadding="1" cellspacing="1" >
                    <tr>
                        <td align="left">
                            <table id="UPa_ct" runat="server" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Ngày lập" Width="60px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay" ten="Ngày lập" runat="server" CssClass="css_ma_c" />
                                    </td>
                                </tr>

                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" hangKt="15" gchuId="gchu" ctrT="so_tt" ctrS="nhap"
                                cot="phong,tenphong,nhom_cdanh,ten_ncdanh,cdanh,ten_cdanh,soluong,tuyenmoi,thuyenchuyen,kinhphi,gchu"
                                cotAn="phong,nhom_cdanh,cdanh">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã phòng" DataField="phong" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="tenphong" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Mã nhóm chức danh" DataField="nhom_cdanh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Nhóm chức danh" DataField="ten_ncdanh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã chức danh" DataField="cdanh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số lượng" DataField="soluong" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                    <asp:TemplateField HeaderText="Tuyển mới" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tuyenmoi" runat="server" Width="50px" CssClass="css_Gso" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Thuyên chuyển" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="thuyenchuyen" runat="server" Width="50px" CssClass="css_Gso" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Kinh phí dự tính" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="kinhphi" runat="server" Width="100px" CssClass="css_Gso" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="gchu" runat="server" Width="150px" CssClass="css_Gma" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_td_hinhthuc_P_XEM();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_td_hinhthuc_P_PHEDUYET();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_td_hinhthuc_P_XOA();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="pheduyet" runat="server" Text="Phê duyệt" CssClass="css_button" OnClick="return ns_td_hinhthuc_P_XOA();form_P_LOI();"
                                            Width="90px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="kopheduyet" runat="server" Text="Ko Phê duyệt" CssClass="css_button" OnClick="return ns_td_hinhthuc_P_XOA();form_P_LOI();"
                                            Width="100px" />
                                    </td>
                                    <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                        <img runat="server" alt = "" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_td_hinhthuc_HangLen();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_td_hinhthuc_HangXuong();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_td_hinhthuc_CatDong();" />
                                    </td>
                                    <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img runat="server" alt = "" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_td_hinhthuc_ChenDong('C');" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <Cthuvien:GridX ID="GridX1" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="16" hamRow="ns_td_hinhthuc_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Ngày lập" DataField="ngay" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tình trạng" DataField="tinhtrang" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Người phê duyệt" DataField="nguoi_pd" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                        <td id="GR_lke_td" runat="server" align="center">
                            <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="120" gridId="GR_lke"
                                ham="ns_td_hinhthuc_P_LKE()" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="css_border" align="left">
                <div id="UPa_gchu">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                </div>
            </td>
        </tr>
                    </table>
                </td>
            </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,560" />
    </div>
    <script language="javascript" type="text/javascript">
        var ns_td_hinhthuc_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId;
        function ns_td_hinhthuc_P_KD() {
            ns_td_hinhthuc_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
                b_gocId = form_Fs_TEN_ID(b_vungId, 'ngay');
            b_slideId = b_grlkeId + '_slide';
            ns_td_hinhthuc_lkeCho = setInterval('ns_td_hinhthuc_P_LKE_CHO()', 200);

        }
        function ns_td_hinhthuc_P_KTRA(b_maTen) {
            var b_maId = "";
            b_maTen = b_maTen.toUpperCase();
            switch (b_maTen) {
                case "TINHTRANG": b_maId = b_gocId; break;
            }
            if (b_maTen == "TINHTRANG") { ns_td_hinhthuc_P_LKE(); }
        }

        function ns_td_hinhthuc_P_LKE_CHO() {
            if ($get(b_grlkeId) != null) { clearTimeout(ns_td_hinhthuc_lkeCho); }
        }
        function ns_td_hinhthuc_P_LKE() {
            try {
                var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
                    a_tinhtrang = $get(b_gocId).value;
                sns_dt.Fs_ns_td_hinhthuc_LKE(a_tinhtrang, a_tso, a_cot, ns_td_hinhthuc_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            catch (err) { form_P_LOI(err); }
        }
        function ns_td_hinhthuc_P_LKE_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var a_kq = Fas_ChMang(b_kq, '#');
            slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
            GridX_datBang(b_grlkeId, a_kq[1]);
        }

        function ns_td_hinhthuc_P_PHEDUYET() {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang < 1) return;
            var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma")),
                b_phong = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "phong")),
                b_lan = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "lan")),
                b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nam"));
            sns_dt.Fs_ns_td_hinhthuc_PHEDUYET(b_nam, b_phong, b_ma, b_lan, ns_td_hinhthuc_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        function ns_td_hinhthuc_P_PHEDUYET_KQ(b_kq) {
            ns_td_hinhthuc_P_LKE();
        }

        function ns_td_hinhthuc_P_XEM() {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang < 1) return;
            var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma")),
                b_phong = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "phong")),
                b_lan = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "lan")),
                b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nam"));
            form_P_MO("ns_dt_dxuat.aspx", null, ["KQ", [b_ma, b_phong, b_lan, b_nam]]);
        }

    </script>
</asp:Content>
