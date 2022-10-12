<%@ Page Title="tl_ktru_bh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_ktru_bh.aspx.cs" Inherits="f_tl_ktru_bh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width ="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Khấu trừ bảo hiểm" />
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
                                                    <Cthuvien:DR_nhap ID="PHONG" runat="server" kieu="U" Width="250px" CssClass="css_drop"
                                                        onchange="tl_ktru_bh_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Tháng" Width="50px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:thang  placeholder='MM/yyyy' ID="THANG" runat="server" Width="100px" CssClass="css_ma_c" kt_xoa="X"
                                                        kieu_luu="I" onblur ="tl_ktru_bh_P_KTRA('THANG')" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="" Width="10px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="tinh_bh" runat="server" Text="Tính bảo hiểm" CssClass="css_button"
                                                        OnClick="return tl_ktru_bh_P_TINH_BH();form_P_LOI();" Width="140px" />
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
                                <%--<Bands>
                                    <igtbl:UltraGridBand AllowAdd="Yes">
                                        <Columns>
                                            <igtbl:UltraGridColumn BaseColumnName="so_the" AllowUpdate="No" Width="100px">
                                                <Header Caption="Mã cán bộ" />
                                                <Footer Caption="Tổng" />
                                                <CellStyle CssClass="css_grid_ma" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="ten" AllowUpdate="No" Width="130px">
                                                <CellStyle CssClass="css_grid_nd" />
                                                <Header Caption="Tên cán bộ" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="hso" AllowUpdate="Yes" IsBound="true" Type="Custom"
                                                EditorControlID="whso" Width="80px">
                                                <CellStyle CssClass="css_grid_so" />
                                                <Header Caption="Hệ số" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="hspc" AllowUpdate="Yes" IsBound="true" Type="Custom"
                                                EditorControlID="whspc" Width="80px">
                                                <CellStyle CssClass="css_grid_so" />
                                                <Header Caption="Phụ cấp" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="bhxh" AllowUpdate="Yes" IsBound="true" Type="Custom"
                                                EditorControlID="wbhxh" Width="80px">
                                                <CellStyle CssClass="css_grid_so" />
                                                <Header Caption="BHXH" />
                                                <Footer Total="Sum" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="bhyt" AllowUpdate="Yes" IsBound="true" Type="Custom"
                                                EditorControlID="wbhyt" Width="80px">
                                                <CellStyle CssClass="css_grid_so" />
                                                <Header Caption="BHYT" />
                                                <Footer Total="Sum" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="bhtn" AllowUpdate="Yes" IsBound="true" Type="Custom"
                                                EditorControlID="wbhtn" Width="80px">
                                                <CellStyle CssClass="css_grid_so" />
                                                <Header Caption="BHTN" />
                                                <Footer Total="Sum" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="pcd" AllowUpdate="Yes" IsBound="true" DataType="System.Double"
                                                EditorControlID="wpcd" Width="80px">
                                                <CellStyle CssClass="css_grid_so" />
                                                <Header Caption="Công Đoàn" />
                                                <Footer Total="Sum" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="note" AllowUpdate="Yes" Width="140px">
                                                <CellStyle CssClass="css_grid_nd" />
                                                <Header Caption="Ghi chú" />
                                            </igtbl:UltraGridColumn>
                                        </Columns>
                                    </igtbl:UltraGridBand>
                                </Bands>
                                <DisplayLayout Name="GRxlke1" ScrollBar="Always" ScrollBarView="Vertical" UseFixedHeaders="true"
                                    Version="4.00" AutoGenerateColumns="False" RowHeightDefault="18px" ColFootersVisibleDefault="Yes">
                                    <FrameStyle Height="200px" />
                                    <Pager PageSize="9" />
                                </DisplayLayout>--%>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return tl_ktru_bh_P_NH();form_P_LOI();"
                                            Width="50px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return tl_ktru_bh_P_MOI();form_P_LOI();"
                                            Width="50px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return tl_ktru_bh_P_XOA();form_P_LOI();"
                                            Width="50px" />
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
                        DisplayLayout-ClientSideEvents-AfterRowActivateHandler="tl_ktru_bh_GR_lke_ActiveRowChange">
                      <%--  <Bands>
                            <igtbl:UltraGridBand AllowAdd="Yes">
                                <Columns>
                                    <igtbl:UltraGridColumn BaseColumnName="thang" Width="100px">
                                        <CellStyle CssClass="css_ma_grid_c" />
                                        <Header Caption="Tháng" />
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="so_id" Hidden="true">
                                    </igtbl:UltraGridColumn>
                                </Columns>
                            </igtbl:UltraGridBand>
                        </Bands>
                        <DisplayLayout Name="GRxlke1" ScrollBar="Always" ScrollBarView="Vertical" Version="4.00"
                            AutoGenerateColumns="False" RowHeightDefault="18px">
                            <FrameStyle Height="260px" />
                            <Pager PageSize="13" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1125,385" />
    </div>
    
    <%-- KTRA--%>
    <script language="javascript" type="text/javascript">
        function tl_ktru_bh_P_KTRA(b_maTen) {
            try {
                var b_maId = "";
                b_maTen = b_maTen.toUpperCase();
                switch (b_maTen) {
                    case "PHONG": b_maId = '<%=PHONG.ClientID%>'; break;
                    case "THANG": b_maId = '<%=THANG.ClientID%>'; break;
                }
                var b_ma = $get(b_maId);
                if (b_ma == null || C_NVL(b_ma.value) == "") return;
                if (b_maTen == "PHONG") {
                    tl_ktru_bh_P_MOI();
                    tl_ktru_bh_P_LKE();
                }
                else if (b_maTen == "THANG") {
                    var b_gridId = '<%=GR_lke.ClientID%>',
                    b_thang = $get('<%=THANG.ClientID%>').value;
                    if (b_thang.indexOf("/") == -1)
                        b_thang = b_thang.substring(0, 2) + "/" + b_thang.substring(2);
                    $get('<%=so_id.ClientID%>').value = b_so_id;
                    var b_hang = Grid_Fi_TimHang(b_gridId, "thang", b_thang);
                    if (b_hang < 0) {
                        b_hang = Grid_Fi_HangTrang(b_gridId);
                        if (b_hang < 0) {
                            Grid_ThemCuoi(b_gridId);
                            b_hang = Grid_Fi_HangTrang(b_gridId);
                        }
                    }
                    GridX_datA(b_gridId, b_hang);
                    var b_so_id = Grid_Fobj_LayGtri_Act(gridId, "so_id");
                    tl_ktru_bh_P_CHUYEN_HANG(b_so_id);
                }
            }
            catch (err) { form_P_LOI(err); }
        }
        function tl_ktru_bh_P_LKE_CB(b_phong) {
            try {
                var a_cot = Grid_Fas_TenCot('<%=GR_ct.ClientID%>');
                stl_ch.Fs_TL_KTRU_BH_LKE_CB(b_phong, a_cot, tl_ktru_bh_P_LKE_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            catch (err) { form_P_LOI(err); }
        }
        function tl_ktru_bh_P_LKE_CB_KQ(b_kq) {
            var b_gridId = '<%=GR_ct.ClientID%>';
            if (b_kq == "") Grid_DatTrangCa(b_gridId);
            else {
                Grid_P_DatBangCH(b_gridId, b_kq);
            }
        }
        function tl_ktru_bh_P_TINH_BH() {
            var b_gridId = '<%=GR_ct.ClientID%>',
                b_thang = $get('<%=THANG.ClientID%>').value,
                b_phong = $get('<%=PHONG.ClientID%>').value,
                a_cot = Grid_Fas_TenCot('<%=GR_ct.ClientID%>');
            if (b_thang.indexOf("/") == -1)
                b_thang = b_thang.substring(0, 2) + "/" + b_thang.substring(2);
            stl_ch.Fs_TL_KTRU_BH_LKE_BH(b_thang, b_phong, a_cot, tl_ktru_bh_P_TINH_BH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        function tl_ktru_bh_P_TINH_BH_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var b_gridId = '<%=GR_ct.ClientID%>';
            var b_so_dong = Grid_Fi_soDong(b_gridId),
                a_kq_c = b_kq.split(";"),
                b_i = 0, b_j = 0, b_so_the;
            var b_dt_bh = new Array();
            for (b_i = 0; b_i < a_kq_c.length; b_i++)
                b_dt_bh[b_i] = a_kq_c[b_i].split("|");
            for (b_i = 0; b_i < b_so_dong; b_i++) {
                b_so_the = Grid_Fobj_LayGtri(b_gridId, b_i, "so_the");
                if (b_so_the != "") {
                    for (b_j = 0; b_j < b_dt_bh.length; b_j++)
                        if (b_dt_bh[b_j][0] == b_so_the) {
                            Grid_P_DatGtriN(b_gridId, b_i, ["hso", "hspc", "bhxh", "bhyt", "bhtn","pcd"],
                                [b_dt_bh[b_j][2], b_dt_bh[b_j][3], b_dt_bh[b_j][4], b_dt_bh[b_j][5], b_dt_bh[b_j][6], b_dt_bh[b_j][7]]);
                            break;
                        }
                }
                else break;
            }
        }
    </script>
    <%-- Nhap --%>
    <script language="javascript" type="text/javascript">
        function tl_ktru_bh_GR_lke_ActiveRowChange(gridId, rowId) {
            if (tl_ktru_bh_choAct != 0) { clearTimeout(tl_ktru_bh_choAct); tl_ktru_bh_choAct = 0; }
            tl_ktru_bh_choAct = setTimeout("tl_ktru_bh_GR_lke_P_CHO()", 300);
            return true;
        }
        var tl_ktru_bh_choAct = 0;
        function tl_ktru_bh_GR_lke_P_CHO() {
            var b_so_id = Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "so_id");
            $get('<%=so_id.ClientID%>').value = b_so_id;
            tl_ktru_bh_P_CHUYEN_HANG(b_so_id);
        }
        function tl_ktru_bh_P_MOI() {
            form_P_MOI('<%=UPa_ct.ClientID%>', "GXL");
            Grid_ThoiActive('<%=GR_lke.ClientID%>');
            Grid_DatTrangCa('<%=GR_ct.ClientID%>');
            var b_phong = $get('<%=PHONG.ClientID%>').value;
            tl_ktru_bh_P_LKE_CB(b_phong);
            $get('<%=so_id.ClientID%>').value = "";
        }
        function tl_ktru_bh_P_NH() {
            try {
                var b_vungId = '<%=UPa_ct.ClientID%>';
                var b_loi = form_Fs_TEXT_KTRA(b_vungId);
                if (b_loi != "") { alert(b_loi); return true; }
                var b_so_id = $get('<%=so_id.ClientID%>').value;
                var a_dt = form_Faa_TEXT_ROW(b_vungId),
                    a_dt_ct = Grid_Fdt_CotGtri('<%=GR_ct.ClientID%>');
                stl_ch.Fs_TL_KTRU_BH_NH(b_so_id, a_dt, a_dt_ct, tl_ktru_bh_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                return false;
            }
            catch (err) { throw (err); }
        }
        function tl_ktru_bh_NH_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var b_gridId = '<%=GR_lke.ClientID%>',
                b_thang = $get('<%=THANG.ClientID%>').value,
                b_so_id = b_kq;
            if (b_thang.indexOf("/") == -1)
                b_thang = b_thang.substring(0, 2) + "/" + b_thang.substring(2);
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
        function tl_ktru_bh_P_CHUYEN_HANG(b_so_id) {
            if (b_so_id == null || b_so_id == "") { tl_ktru_bh_P_MOI(); }
            else {
                var a_cot = Grid_Fas_TenCot('<%=GR_ct.ClientID%>');
                stl_ch.Fs_TL_KTRU_BH_CT(b_so_id, a_cot, tl_ktru_bh_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        function tl_ktru_bh_P_CHUYEN_HANG_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var b_gridId = '<%=GR_ct.ClientID%>';
            if (b_kq == "") Grid_DatTrangCa(b_gridId);
            else Grid_P_DatBangCH(b_gridId, b_kq);
            $get('<%=THANG.ClientID%>').value = Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "thang");
        }
        function tl_ktru_bh_P_XOA() {
            try {
                var b_so_id = Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "so_id");
                if (b_so_id != "")
                    stl_ch.Fs_TL_KTRU_BH_XOA(b_so_id, tl_ktru_bh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                return true;
            }
            catch (err) { throw (err); }
        }
        function tl_ktru_bh_P_XOA_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var b_gridId = '<%=GR_lke.ClientID%>';
            Grid_cutRowAct(b_gridId);
            var b_so_id = Grid_Fobj_LayGtri_Act(b_gridId, "so_id");
            $get('<%=so_id.ClientID%>').value = b_so_id;
            tl_ktru_bh_P_CHUYEN_HANG(b_so_id);
        }
        function tl_ktru_bh_P_LKE() {
            try {
                var a_cot = Grid_Fas_TenCot('<%=GR_lke.ClientID%>'),
                    b_phong = $get('<%=PHONG.ClientID%>').value;
                stl_ch.Fs_TL_KTRU_BH_LKE(b_phong, a_cot, tl_ktru_bh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            catch (err) { form_P_LOI(err); }
        }
        function tl_ktru_bh_P_LKE_KQ(b_kq) {
            var b_gridId = '<%=GR_lke.ClientID%>';
            if (b_kq == "") Grid_DatTrangCa(b_gridId);
            else Grid_P_DatBangCH(b_gridId, b_kq);
        }
    </script>
</asp:Content>
