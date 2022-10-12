<%@ Page Title="tl_danhgia_dvi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_danhgia_dvi.aspx.cs" Inherits="f_tl_danhgia_dvi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width ="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Đánh giá Phòng" />
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
            <td valign="middle">
                <table id="UPa_ct" runat="server" border="0" cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <table cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Phòng" CssClass="css_gchu" Width="50px" />
                                    </td>
                                    <td>
                                        <table border="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="MA_DVI" runat="server" CssClass="css_ma" kieu_chu="true" Width="100px" ten="Mã Phòng" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Tháng" Width="50px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:thang  placeholder='MM/yyyy' ID="THANG" runat="server" Width="100px" CssClass="css_ma_c" kt_xoa="X"
                                                        kieu_luu="I" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <Cthuvien:GridX ID="GR_ct" runat="server" mauten="#9fc54e,#3a3a3a,#ffffff">
                               <%-- <Bands>
                                    <igtbl:UltraGridBand AllowAdd="Yes">
                                        <Columns>
                                            <igtbl:UltraGridColumn BaseColumnName="ma_phong" AllowUpdate="No" Hidden="true">
                                                <CellStyle CssClass="css_grid_ma" />
                                                <Header Caption="Mã phòng" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="ten_phong" AllowUpdate="No" Width="130px">
                                                <CellStyle CssClass="css_grid_nd" />
                                                <Header Caption="Tên phòng" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="diem" AllowUpdate="Yes" IsBound="true" Type="Custom"
                                                EditorControlID="wdiem" Width="80px">
                                                <CellStyle CssClass="css_grid_so" />
                                                <Header Caption="Điểm" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="note" AllowUpdate="Yes" Width="140px">
                                                <CellStyle CssClass="css_grid_nd" />
                                                <Header Caption="Ghi chú" />
                                            </igtbl:UltraGridColumn>
                                        </Columns>
                                    </igtbl:UltraGridBand>
                                </Bands>
                                <DisplayLayout Name="GRxlke1" ScrollBar="Always" ScrollBarView="Vertical" Version="4.00"
                                    AutoGenerateColumns="False" RowHeightDefault="18px">
                                    <FrameStyle Height="200px" />
                                    <Pager PageSize="10" />
                                </DisplayLayout>--%>
                            </Cthuvien:GridX>
                            <%--<Cthuvien:soW ID="wdiem" runat="server" CssClass="css_so_r" Width="40px" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return tl_danhgia_dvi_P_NH();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return tl_danhgia_dvi_P_MOI();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return tl_danhgia_dvi_P_XOA();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" class="css_border">
                <div id="UPa_lke">
                    <Cthuvien:GridX ID="GR_lke" runat="server" ctr_sott="sott" mauten="#9fc54e,#3a3a3a,#ffffff"
                        DisplayLayout-ClientSideEvents-AfterRowActivateHandler="tl_danhgia_dvi_GR_lke_ActiveRowChange">
                       <%-- <Bands>
                            <igtbl:UltraGridBand AllowAdd="Yes">
                                <Columns>
                                    <igtbl:UltraGridColumn BaseColumnName="thang" Width="100px">
                                        <CellStyle CssClass="css_ma_grid_c" />
                                        <Header Caption="Tháng đánh giá" />
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="so_id" Hidden="true">
                                    </igtbl:UltraGridColumn>
                                </Columns>
                            </igtbl:UltraGridBand>
                        </Bands>
                        <DisplayLayout Name="GRxlke1" ScrollBar="Always" ScrollBarView="Vertical" Version="4.00"
                            AutoGenerateColumns="False" RowHeightDefault="18px">
                            <FrameStyle Height="280px" />
                            <Pager PageSize="14" />
                        </DisplayLayout>--%>
                    </Cthuvien:GridX>
                </div>
            </td>
        </tr>
                    </table>
                </td>
            </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="610,400" />
    </div>
    <%-- KTRA--%>
    <script language="javascript" type="text/javascript">
        function tl_danhgia_dvi_P_KTRA(b_maTen) {
            try {
                if (b_maTen == "THANG") {
                    var b_vungId = '<%=UPa_ct.ClientID%>',
                        giatri = form_Faa_TEXT_ROW(b_vungId),
                        b_thang = giatri[1][2];
                    var b_i = b_thang.indexOf("/");
                    if (b_i < 0) {
                        b_thang = b_thang.substring(0, 2) + "/" + b_thang.substring(2);
                    }
                    var b_hang = Grid_Fi_TimHang('<%=GR_lke.ClientID%>', "thang", b_thang);
                    if (b_hang > -1) {
                        GridX_datA('<%=GR_lke.ClientID%>', b_hang);
                        var b_so_id = Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "so_id");
                        $get('<%=so_id.ClientID%>').value = b_so_id;
                        tl_danhgia_dvi_P_CHUYEN_HANG(b_so_id);
                    }
                }
            }
            catch (err) { form_P_LOI(err); }
        }
        function tl_danhgia_dvi_P_LKE_PHONG() {
            try {
                var a_cot = Grid_Fas_TenCot('<%=GR_ct.ClientID%>');
                stl_cc.Fs_TL_DANHGIA_DVI_LKE_PHONG(a_cot, tl_danhgia_dvi_P_LKE_PHONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            catch (err) { form_P_LOI(err); }
        }
        function tl_danhgia_dvi_P_LKE_PHONG_KQ(b_kq) {
            var b_gridId = '<%=GR_ct.ClientID%>';
            if (b_kq == "") Grid_DatTrangCa(b_gridId);
            else {
                Grid_P_DatBangCH(b_gridId, b_kq);
            }
        }
    </script>
    <%-- Nhap --%>
    <script language="javascript" type="text/javascript">
        function tl_danhgia_dvi_GR_lke_ActiveRowChange(gridId, rowId) {
            if (tl_danhgia_dvi_choAct != 0) { clearTimeout(tl_danhgia_dvi_choAct); tl_danhgia_dvi_choAct = 0; }
            tl_danhgia_dvi_choAct = setTimeout("tl_danhgia_dvi_GR_lke_P_CHO()", 300);
            return true;
        }
        var tl_danhgia_dvi_choAct = 0;
        function tl_danhgia_dvi_GR_lke_P_CHO() {
            var b_so_id = Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "so_id");
            $get('<%=so_id.ClientID%>').value = b_so_id;
            tl_danhgia_dvi_P_CHUYEN_HANG(b_so_id);
        }
        function tl_danhgia_dvi_P_MOI() {
            form_P_MOI('<%=UPa_ct.ClientID%>', "GXL");
            Grid_ThoiActive('<%=GR_lke.ClientID%>');
            Grid_DatTrangCa('<%=GR_ct.ClientID%>');
            tl_danhgia_dvi_P_LKE_PHONG();
            $get('<%=so_id.ClientID%>').value = "";
        }
        function tl_danhgia_dvi_P_NH() {
            try {
                var b_vungId = '<%=UPa_ct.ClientID%>';
                var b_loi = form_Fs_TEXT_KTRA(b_vungId);
                if (b_loi != "") { alert(b_loi); return true; }
                var b_so_id = $get('<%=so_id.ClientID%>').value;
                var a_dt = form_Faa_TEXT_ROW(b_vungId),
                    a_dt_ct = Grid_Fdt_CotGtri('<%=GR_ct.ClientID%>');
                stl_cc.Fs_TL_DANHGIA_DVI_NH(b_so_id, a_dt, a_dt_ct, tl_danhgia_dvi_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                return false;
            }
            catch (err) { throw (err); }
        }
        function tl_danhgia_dvi_NH_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var b_gridId = '<%=GR_lke.ClientID%>',
                b_thang = $get('<%=THANG.ClientID%>').value,
                b_so_id = b_kq;
            if (b_thang.indexOf("/") == -1) {
                b_thang = b_thang.substring(0, 2) + "/" + b_thang.substring(2);
            }
            $get('<%=so_id.ClientID%>').value = b_so_id;
            var b_hang = Grid_Fi_TimHang(b_gridId, "so_id", b_so_id);
            if (b_hang < 0) {
                b_hang = Grid_Fi_HangTrang(b_gridId);
                if (b_hang < 0) {
                    Grid_ThemCuoi(b_gridId);
                    b_hang = Grid_Fi_HangTrang(b_gridId);
                }
            }
            GridX_datA(b_gridId, b_hang);
            Grid_P_DatGtriN(b_gridId, b_hang, ["thang", "so_id"], [b_thang, b_so_id]);
            return false;
        }
        function tl_danhgia_dvi_P_CHUYEN_HANG(b_so_id) {
            if (b_so_id == null || b_so_id == "") { tl_danhgia_dvi_P_MOI(); }
            else {
                var a_cot = Grid_Fas_TenCot('<%=GR_ct.ClientID%>');
                stl_cc.Fs_TL_DANHGIA_DVI_CT(b_so_id, a_cot, tl_danhgia_dvi_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        function tl_danhgia_dvi_P_CHUYEN_HANG_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var b_gridId = '<%=GR_ct.ClientID%>';
            if (b_kq == "") Grid_DatTrangCa(b_gridId);
            else Grid_P_DatBangCH(b_gridId, b_kq);
            $get('<%=THANG.ClientID%>').value = Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "thang");
        }
        function tl_danhgia_dvi_P_XOA() {
            try {
                var b_so_id = Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "so_id");
                if (b_so_id != "")
                    stl_cc.Fs_TL_DANHGIA_DVI_XOA(b_so_id, tl_danhgia_dvi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                return true;
            }
            catch (err) { throw (err); }
        }
        function tl_danhgia_dvi_P_XOA_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var b_gridId = '<%=GR_lke.ClientID%>';
            Grid_cutRowAct(b_gridId);
            var b_so_id = Grid_Fobj_LayGtri_Act(b_gridId, "so_id");
            $get('<%=so_id.ClientID%>').value = b_so_id;
            tl_danhgia_dvi_P_CHUYEN_HANG(b_so_id);
        }
        function tl_danhgia_dvi_P_LKE() {
            try {
                var a_cot = Grid_Fas_TenCot('<%=GR_lke.ClientID%>');
                stl_cc.Fs_TL_DANHGIA_DVI_LKE(a_cot, tl_danhgia_dvi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            catch (err) { form_P_LOI(err); }
        }
        function tl_danhgia_dvi_P_LKE_KQ(b_kq) {
            var b_gridId = '<%=GR_lke.ClientID%>';
            if (b_kq == "") Grid_DatTrangCa(b_gridId);
            else Grid_P_DatBangCH(b_gridId, b_kq);
        }
    </script>
</asp:Content>
