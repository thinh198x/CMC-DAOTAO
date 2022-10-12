<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_tk_ma_thongke.aspx.cs" Inherits="f_ns_tk_ma_thongke"
    Title="ns_tk_ma_thongke" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Mã nhóm thống kê " />
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
                        <td align="left" valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="5" cotAn="nsd" hamRow="ns_tk_ma_thongke_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="120px">
                                                    <ItemStyle CssClass="css_Gma" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="250px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="nsd" DataField="nsd"></asp:BoundField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="150" gridId="GR_lke"
                                            ham="ns_tk_ma_thongke_P_LKE()" />
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
                                                    <asp:Label ID="Label2" runat="server" CssClass="css_gchu">Mã</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="MA" ten="Mã" runat="server" CssClass="css_form" kieu_chu="True" kt_xoa="G"
                                                                    onchange="ns_tk_ma_thongke_P_KTRA('MA')" Width="120px" />
                                                            </td>
                                                            <td style="width: 100px">
                                                                <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu" kt_xoa="X" />
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
                                                    <Cthuvien:ma ID="ten" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X"
                                                        Width="180px" ten="Tên" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-left: 20px">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_tk_ma_thongke_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_tk_ma_thongke_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                    </div>
                                                </td>
                                                <%--<td align="center">
                                                    <Cthuvien:nhap ID="nhap" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return ns_tk_ma_thongke_P_NH();form_P_LOI();"
                                                        Text="Nhập" Width="70px" />
                                                </td>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="xoa" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return ns_tk_ma_thongke_P_XOA();form_P_LOI();"
                                                        Text="Xóa" Width="70px" />
                                                </td>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="chon" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();"
                                                        Text="Chọn" Width="70px" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="755,375" />
    <script language="javascript" type="text/javascript">

        var ns_tk_ma_thongke_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId;
        function ns_tk_ma_thongke_P_KD() {
            ns_tk_ma_thongke_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
                b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
            b_slideId = b_grlkeId + '_slide';
            ns_tk_ma_thongke_lkeCho = setInterval('ns_tk_ma_thongke_P_LKE_CHO()', 200);

        }

        function ns_tk_ma_thongke_P_KTRA(b_maTen) {
            try {
                var b_maId = "";
                b_maTen = b_maTen.toUpperCase();
                switch (b_maTen) {
                    case "MA": b_maId = b_gocId; break;
                }
                var b_ma = $get(b_maId);
                if (C_NVL(b_ma.value) == "") return;
                if (b_maTen == "MA") {
                    var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
                    b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
                    if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_tk_ma_thongke_P_MA_KTRA(); }
                    else { GridX_datA(b_grlkeId, b_hang); ns_tk_ma_thongke_P_CHUYEN_HANG(); }
                    b_ten.focus();
                }
            }
            catch (err) { form_P_LOI(err); }
        }
        function ns_tk_ma_thongke_P_MA_KTRA() {
            try {
                var b_ma = C_NVL($get(b_gocId).value);
                if (b_ma != "") {
                    var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
                    sti_ch.Fs_NS_TK_MA_THONGKE_MA(b_ma, b_TrangKt, a_cot, ns_tk_ma_thongke_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                }
            }
            catch (err) { form_P_LOI(err); }
        }
        function ns_tk_ma_thongke_P_MA_KTRA_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var a_kq = Fas_ChMang(b_kq, '#');
            var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
            GridX_datBang(b_grlkeId, a_kq[3]);
            slide_P_MOI(b_slideId, b_trang, b_soDong);
            if (b_hang < 1) form_P_MOI(b_vungId, "X");
            else { GridX_datA(b_grlkeId, b_hang); ns_tk_ma_thongke_P_CHUYEN_HANG(); }
        }

        var ns_tk_ma_thongke_choAct = 0;
        function ns_tk_ma_thongke_GR_lke_RowChange() {
            if (ns_tk_ma_thongke_choAct != 0) clearTimeout(ns_tk_ma_thongke_choAct);
            ns_tk_ma_thongke_choAct = setTimeout("ns_tk_ma_thongke_P_CHUYEN_HANG()", 300);
            return false;
        }

        function ns_tk_ma_thongke_P_LKE_CHO() {
            if ($get(b_grlkeId) != null) { clearTimeout(ns_tk_ma_thongke_lkeCho); ns_tk_ma_thongke_P_LKE(); }
        }

        function ns_tk_ma_thongke_P_NH() {
            var b_loi = form_Fs_TEXT_KTRA(b_vungId);
            if (b_loi != "") { form_P_LOI(b_loi); return false; }
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sti_ch.Fs_NS_TK_MA_THONGKE_NH(b_TrangKt, a_dt_ct, a_cot, ns_tk_ma_thongke_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        function ns_tk_ma_thongke_P_NH_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
            else {
                var a_kq = Fas_ChMang(b_kq, '#');
                var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
                slide_P_MOI(b_slideId, b_trang, b_soDong);
                GridX_datBang(b_grlkeId, a_kq[3]);
                if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
                $get(b_gocId).focus();
            }
            return false;
        }
        function ns_tk_ma_thongke_P_MOI() {
            form_P_MOI(b_vungId, "GXL");
            $get(b_gocId).focus();
        }

        function ns_tk_ma_thongke_P_XOA() {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            var b_loi = form_Fs_TEXT_KTRA(b_vungId);
            if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
            var message = confirm("Bạn có chắc chắn xóa không?");
            if (message == false) { return false; }
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang < 1) return;
            var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
            if (b_ma == "") ns_tk_ma_thongke_P_MOI();
            else {
                var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
                sti_ch.Fs_NS_TK_MA_THONGKE_XOA(b_ma, a_tso, a_cot, ns_tk_ma_thongke_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            return false;
        }
        function ns_tk_ma_thongke_P_XOA_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
            else {
                var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
                if (b_hang > 1) b_hang--;
                else b_hang = GridX_Fi_hangSo(b_grlkeId);
                slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
                if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_tk_ma_thongke_P_MOI();
                else { GridX_datA(b_grlkeId, b_hang); ns_tk_ma_thongke_P_CHUYEN_HANG(); }
            }
        }

        function ns_tk_ma_thongke_P_CHUYEN_HANG() {
            try {
                var b_hang = GridX_Fi_timHangA(b_grlkeId);
                if (b_hang < 1) return;
                var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
                if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
            }
            catch (err) { form_P_LOI(err); }
        }

        function ns_tk_ma_thongke_P_LKE() {
            try {
                var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
                sti_ch.Fs_NS_TK_MA_THONGKE_LKE(a_tso, a_cot, ns_tk_ma_thongke_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            catch (err) { form_P_LOI(err); }
        }

        function ns_tk_ma_thongke_P_LKE_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var a_kq = Fas_ChMang(b_kq, '#');
            slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
            GridX_datBang(b_grlkeId, a_kq[1]);
        }

        function form_dong() {
            location.reload(false);
        }
    </script>
</asp:Content>

