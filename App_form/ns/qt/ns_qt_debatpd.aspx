<%@ Page Title="ns_qt_debatpd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_qt_debatpd.aspx.cs" Inherits="f_ns_qt_debatpd" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td>
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Phê duyệt danh sách nâng lương" />
                                    </td>
                                    <td align="right">
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
                        <td valign="middle" class="form_right">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Tình trạng" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_nhap ID="tinhtrang" ten="Tình trạng" runat="server" DataTextField="ten" DataValueField="ma"
                                            CssClass="css_form" kieu="S" Width="376px" onchange="ns_qt_debatpd_P_KTRA('tinhtrang')">
                                            <asp:ListItem Text="Chưa phê duyệt" Value="0" />
                                            <asp:ListItem Text="Đã phê duyệt" Value="1" />
                                        </Cthuvien:DR_nhap>
                                    </td>
                                </tr>

                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="12" cotAn="nam">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Đơn vị" DataField="ma_dvi" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Phòng" DataField="phong" HeaderStyle-Width="350px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Ngày đề xuất" DataField="ngay_lap" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Số lượng" DataField="so_luong" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="120" gridId="GR_lke"
                                            ham="ns_qt_debatpd_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" align="center">
                            <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <div class="box3 txRight">
                                            <a href="#" onclick="return ns_qt_debatpd_P_PHEDUYET('1');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">P</span>hê duyệt</a>
                                            <a href="#" onclick="return ns_qt_debatpd_P_PHEDUYET('2');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">K</span>hông phê duyệt</a>
                                        </div>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="920,640" />
    </div>
    <script language="javascript" type="text/javascript">
        var ns_qt_debatpd_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId;
        function ns_qt_debatpd_P_KD() {
            ns_qt_debatpd_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
                b_gocId = form_Fs_TEN_ID(b_vungId, 'tinhtrang');
            b_slideId = b_grlkeId + '_slide';
            ns_qt_debatpd_lkeCho = setInterval('ns_qt_debatpd_P_LKE_CHO()', 200);

        }
        function ns_qt_debatpd_P_KTRA(b_maTen) {
            var b_maId = "";
            b_maTen = b_maTen.toUpperCase();
            switch (b_maTen) {
                case "TINHTRANG": b_maId = b_gocId; break;
            }
            if (b_maTen == "TINHTRANG") { ns_qt_debatpd_P_LKE(); }
        }

        function ns_qt_debatpd_P_LKE_CHO() {
            if ($get(b_grlkeId) != null) { clearTimeout(ns_qt_debatpd_lkeCho); ns_qt_debatpd_P_LKE(); }
        }
        function ns_qt_debatpd_P_LKE() {
            try {
                var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
                    a_tinhtrang = $get(b_gocId).value;
                sns_qt.Fs_NS_QT_DEBATPD_LKE(a_tinhtrang, a_tso, a_cot, ns_qt_debatpd_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            catch (err) { form_P_LOI(err); }
        }
        function ns_qt_debatpd_P_LKE_KQ(b_kq) {
            try {
                if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
                var a_kq = Fas_ChMang(b_kq, '#');
                slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
                GridX_datBang(b_grlkeId, a_kq[1]);
            } catch (err) { form_P_LOI(err); }
        }

        function ns_qt_debatpd_P_PHEDUYET(b_thamso) {
            var a_tinhtrang = $get(b_gocId).value;
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            sns_qt.Fs_NS_QT_DEBATPD_PHEDUYET(b_thamso, a_tinhtrang, a_tso, a_cot, ns_qt_debatpd_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        function ns_qt_debatpd_P_PHEDUYET_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
            ns_qt_debatpd_P_LKE();
        }

        function ns_qt_debatpd_P_XEM() {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang < 1) return;
            var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma")),
                b_phong = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "phong")),
                b_lan = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "lan")),
                b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nam"));
            form_P_MO("ns_dt_dxuat.aspx", null, ["KQ", [b_ma, b_phong, b_lan, b_nam]]);
        }

        function form_dong() {
            location.reload(false);
        }
    </script>
</asp:Content>
