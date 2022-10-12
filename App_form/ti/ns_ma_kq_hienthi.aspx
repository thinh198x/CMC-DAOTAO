<%@ Page Title="ns_ma_kq_hienthi" Language="C#" MasterPageFile="~/trangnen.master"
    AutoEventWireup="true" CodeFile="ns_ma_kq_hienthi.aspx.cs" Inherits="f_ns_ma_kq_hienthi" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Mã kết quả hiển thị" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_64">
                <div class="b_left col_60 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                            CssClass="table gridX" loai="X" hangKt="15" cotAn="nsd,tt,dkthem,cot,kieu" hamRow="ns_ma_kq_hienthi_GR_lke_RowChange()">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:BoundField HeaderText="Bảng" DataField="nhom" HeaderStyle-Width="120px">
                                    <ItemStyle CssClass="css_Gma" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="120px">
                                    <ItemStyle CssClass="css_Gma" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="250px">
                                    <ItemStyle CssClass="css_Gnd" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="TT" DataField="tt"></asp:BoundField>
                                <asp:BoundField HeaderText="Điều kiện thêm" DataField="dkthem">
                                    <ItemStyle CssClass="css_Gnd" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Điều kiện thêm" DataField="cot">
                                    <ItemStyle CssClass="css_Gnd" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Điều kiện thêm" DataField="kieu">
                                    <ItemStyle CssClass="css_Gnd" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="nsd" DataField="nsd">
                                    <ItemStyle CssClass="css_Gnd" />
                                </asp:BoundField>
                            </Columns>
                        </Cthuvien:GridX>
                        <div id="GR_lke_td" runat="server" align="center">
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_ma_kq_hienthi_P_LKE('K')" />
                        </div>
                    </div>
                </div>
                <div class="b_right col_40 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Loại</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="LOAI" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                f_tkhao="~/App_form/ti/ns_tk_ma_nhtk.aspx" gchu="gchu" onchange="ns_ma_kq_hienthi_P_KTRA('LOAI')"
                                ktra="ns_tk_ma_nhtk,ma,ten" ten="Nhóm tìm kiếm" kt_xoa="K" placeholder="Nhấn F1" />
                            <div style="display: none;">
                                <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" CssClass="css_gchu2" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Bảng</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="NHOM" runat="server" CssClass="form-control css_ma" kieu_chu="true"
                                gchu="gchu" ten="Nhóm tìm kiếm" kt_xoa="K" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="Mã" runat="server" CssClass="form-control css_ma" kt_xoa="G" onchange="ns_ma_kq_hienthi_P_KTRA('MA')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Thứ tự</span>
                        <div class="input-group">
                            <Cthuvien:so ID="TT" ten="TT" runat="server" kt_xoa="X" CssClass="form-control css_so" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Tên</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" ten="tên" runat="server" CssClass="form-control css_ma" kieu_unicode="True"
                                kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Cột</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="cot" ten="tên" runat="server" CssClass="form-control css_ma" kieu_unicode="True"
                                kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Kiểu</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="kieu" ten="tên" runat="server" CssClass="form-control css_ma" kieu_unicode="True"
                                kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Điều kiện thêm</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="dkthem" ten="Điều kiện thêm" runat="server" CssClass="form-control css_ma"
                                kt_xoa="X" TextMode="MultiLine" Rows="5" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <button onclick="return ns_ma_kq_hienthi_P_NH();form_P_LOI();" class="bt_action"><span class="txUnderline">N</span>hập</button>
                        <button class="bt_action" onclick="return ns_ma_kq_hienthi_P_XOA();form_P_LOI();"><span class="txUnderline">X</span>óa</button>
                        <button onclick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" class="bt_action"><span class="txUnderline">C</span>họn</button>
                    </div>
                    <div id="UPa_gchu" class="css_border" align="left" style="margin-top: 130px;">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <Cthuvien:an ID="kthuoc" runat="server" Value="915,681" />
    <script language="javascript" type="text/javascript">

        var ns_ma_kq_hienthi_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_nhomId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
        function ns_ma_kq_hienthi_P_KD() {
            ns_ma_kq_hienthi_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
            b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); b_nhomId = form_Fs_TEN_ID(b_vungId, 'NHOM'); b_loaiId = form_Fs_TEN_ID(b_vungId, 'LOAI');
            b_slideId = $get(b_grlkeId).getAttribute('slideId');
        }
<%-- Ket qua--%>
        function P_KET_QUA(b_dtuong, a_tso) {
            try {
                if (b_dtuong == null || b_dtuong == "") return;
                b_dtuong = b_dtuong.toUpperCase();
                b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
                if (b_fcho == 'X') P_KET_QUA_KQ();
                else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
                var b_kq = a_tso[0];
                if (b_dtuong.indexOf("LOAI") >= 0) {
                    $get(b_loaiId).value = b_kq;
                    ns_ma_kq_hienthi_P_LKE('K'); form_P_MOI(b_vungId, "GX");
                    $get('<%=gchu.ClientID%>').innerHTML = a_tso[1];
                    $get(b_nhomId).focus();
                }
            }
            catch (err) { form_P_LOI(err); }
        }
        function P_KET_QUA_KQ() {
            if (b_fcho != 'X') return;
            b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
            clearInterval(b_choAct);
        }
 <%-- KTRA--%>
        function ns_ma_kq_hienthi_P_KTRA(b_maTen) {
            try {
                var b_maId = "";
                b_maTen = b_maTen.toUpperCase();
                switch (b_maTen) {
                    case "MA": b_maId = b_gocId; break;
                    case "LOAI": b_maId = b_nhomId; break;
                }
                var b_ma = $get(b_maId);
                if (C_NVL(b_ma.value) == "") return;
                if (b_maTen == "MA") {
                    var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
                    b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
                    if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_ma_kq_hienthi_P_MA_KTRA(); }
                    else { GridX_datA(b_grlkeId, b_hang); ns_ma_kq_hienthi_P_CHUYEN_HANG(); }
                }
                if (b_maTen == "LOAI") {
                    skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ma_kq_hienthi_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                    ns_ma_kq_hienthi_P_LKE('K');
                }
            }
            catch (err) { form_P_LOI(err); }
        }
        function ns_ma_kq_hienthi_P_MA_KTRA() {
            try {
                var b_ma = C_NVL($get(b_gocId).value);
                if (b_ma != "") {
                    var b_nhom = $get(b_nhomId).value;
                    var b_loai = $get(b_loaiId).value;
                    var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
                    sti_ch.Fs_NS_MA_KQ_HIENTHI_MA(b_loai, b_nhom, b_ma, b_TrangKt, a_cot, ns_ma_kq_hienthi_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                }
            }
            catch (err) { form_P_LOI(err); }
        }
        function ns_ma_kq_hienthi_P_MA_KTRA_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var a_kq = Fas_ChMang(b_kq, '#');
            var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
            GridX_datBang(b_grlkeId, a_kq[3]);
            slide_P_MOI(b_slideId, b_trang, b_soDong);
            if (b_hang < 1) form_P_MOI(b_vungId, "X");
            else { GridX_datA(b_grlkeId, b_hang); ns_ma_kq_hienthi_P_CHUYEN_HANG(); }
        }

        function ns_ma_kq_hienthi_P_DatGchu(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            $get('<%=gchu.ClientID%>').innerHTML = b_kq;
            form_P_MOI(b_vungId, "GX");
            $get(b_nhomId).focus();
        }


        var ns_ma_kq_hienthi_choAct = 0;
        function ns_ma_kq_hienthi_GR_lke_RowChange() {
            if (ns_ma_kq_hienthi_choAct != 0) clearTimeout(ns_ma_kq_hienthi_choAct);
            ns_ma_kq_hienthi_choAct = setTimeout("ns_ma_kq_hienthi_P_CHUYEN_HANG()", 300);
            return false;
        }

        function ns_ma_kq_hienthi_P_LKE_CHO() {
            if (document.readyState == 'complete') {
                if (ns_ma_kq_hienthi_lkeCho != 0) clearTimeout(ns_ma_kq_hienthi_lkeCho);
                b_slideId = $get(b_grlkeId).getAttribute('slideId');
                ns_ma_kq_hienthi_P_LKE('K');
            }
        }

        function ns_ma_kq_hienthi_P_NH() {
            var b_loi = form_Fs_TEXT_KTRA(b_vungId);
            if (b_loi != "") { form_P_LOI(b_loi); return false; }
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sti_ch.Fs_NS_MA_KQ_HIENTHI_NH(b_TrangKt, a_dt_ct, a_cot, ns_ma_kq_hienthi_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        function ns_ma_kq_hienthi_P_NH_KQ(b_kq) {
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
        function ns_ma_kq_hienthi_P_MOI() {
            form_P_MOI(b_vungId, "GXL");
            $get(b_gocId).focus();
        }
        function ns_ma_kq_hienthi_P_XOA() {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            var b_loi = form_Fs_TEXT_KTRA(b_vungId);
            if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
            var message = confirm("Bạn có chắc chắn xóa không?");
            if (message == false) { return false; }
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang < 1) return;
            var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
            if (b_ma == "") ns_ma_kq_hienthi_P_MOI();
            else {
                var b_nhom = $get(b_nhomId).value;
                var b_loai = $get(b_loaiId).value;
                var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
                sti_ch.Fs_NS_MA_KQ_HIENTHI_XOA(b_loai, b_nhom, b_ma, a_tso, a_cot, ns_ma_kq_hienthi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            return false;
        }
        function ns_ma_kq_hienthi_P_XOA_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
            else {
                var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
                if (b_hang > 1) b_hang--;
                else b_hang = GridX_Fi_hangSo(b_grlkeId);
                slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
                if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ma_kq_hienthi_P_MOI();
                else { GridX_datA(b_grlkeId, b_hang); ns_ma_kq_hienthi_P_CHUYEN_HANG(); }
            }
        }

        function ns_ma_kq_hienthi_P_CHUYEN_HANG() {
            try {
                var b_hang = GridX_Fi_timHangA(b_grlkeId);
                if (b_hang < 1) return;
                var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
                if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
            }
            catch (err) { form_P_LOI(err); }
        }

        function ns_ma_kq_hienthi_P_LKE(b_dk) {
            try {
                if (b_dk == 'C') slide_P_MOI(b_slideId);
                var b_loai = $get(b_loaiId).value, a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
                sti_ch.Fs_NS_MA_KQ_HIENTHI_LKE(b_loai, a_tso, a_cot, ns_ma_kq_hienthi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            catch (err) { form_P_LOI(err); }
        }

        function ns_ma_kq_hienthi_P_LKE_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var a_kq = Fas_ChMang(b_kq, '#');
            slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
            GridX_datBang(b_grlkeId, a_kq[1]);
            b_fcho = 'X';
        }

        function form_dong() {
            location.reload(false);
        }
    </script>
</asp:Content>
