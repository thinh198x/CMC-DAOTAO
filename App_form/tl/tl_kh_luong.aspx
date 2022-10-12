<%@ Page Title="tl_kh_luong" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_kh_luong.aspx.cs" Inherits="f_tl_kh_luong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width ="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Kế hoạch lương" />
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
                <table id="UPa_ct" runat="server" border="0" cellpadding="1" cellspacing="1" >
                    <tr>
                        <td align="left">
                            <table cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Năm" Width="60px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table border="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="NAM" ten="Năm kế hoạch" runat="server" CCssClass="css_so" ToolTip="Năm kế hoạch" 
                                                        kieu_so="true" Width="100px" onchange="tl_kh_luong_P_KTRA('nam')" gchu="gchu" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Quỹ lương kế hoạch" CssClass="css_gchu" Width="120px" />
                                    </td>
                                    <td>
                                       <Cthuvien:so ID="ql_khoach" ten="Quỹ lương kế hoạch" runat="server" CssClass="css_so" ToolTip="Quỹ lương kế hoạch" 
                                                        Width="200px" kt_xoa="X" gchu="gchu" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Quỹ lương chi trả" CssClass="css_gchu" Width="120px" />
                                    </td>
                                    <td>
                                       <Cthuvien:so ID="ql_chitra" ten="Quỹ lương chi trả" runat="server" CssClass="css_so" ToolTip="Quỹ lương chi trả" 
                                                        Width="200px" kt_xoa="X" gchu="gchu" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Quỹ lương dự phòng" CssClass="css_gchu" Width="120px" />
                                    </td>
                                    <td>
                                       <Cthuvien:so ID="ql_duphong" ten="Quỹ lương dự phòng" runat="server" CssClass="css_so" ToolTip="Quỹ lương dự phòng" 
                                                        Width="200px" kt_xoa="X" gchu="gchu" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Quỹ lương khen thưởng" CssClass="css_gchu" Width="130px" />
                                    </td>
                                    <td>
                                       <Cthuvien:so ID="ql_khenthuong" ten="Quỹ lương khen thưởng" runat="server" CssClass="css_so" ToolTip="Quỹ lương khen thưởng" 
                                                        Width="200px" kt_xoa="X" gchu="gchu" />
                                    </td>
                                </tr>
                            
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Ghi chú" Width="100px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:nd ID="note" runat="server" Width="300px" CssClass="css_ma" kt_xoa="X"
                                            kieu_unicode="true" TextMode="MultiLine" Height="50px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return tl_kh_luong_P_NH();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return tl_kh_luong_P_MOI();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return tl_kh_luong_P_XOA();form_P_LOI();"
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
                        DisplayLayout-ClientSideEvents-AfterRowActivateHandler="tl_kh_luong_GR_lke_ActiveRowChange">
                        <%--<Bands>
                            <igtbl:UltraGridBand AllowAdd="Yes">
                                <Columns>
                                    <igtbl:UltraGridColumn BaseColumnName="nam" Width="80px">
                                        <CellStyle CssClass="css_ma_grid_c" />
                                        <Header Caption="Năm" />
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
                </div>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="680,330" />
    </div>

    <%-- KTRA--%>
    <script language="javascript" type="text/javascript">
        var b_mt = "";
        function tl_kh_luong_P_KTRA(b_maTen) {
            try {
                var b_maId = "";
                b_maTen = b_maTen.toUpperCase();
                b_mt = b_maTen;
                switch (b_maTen) {
                    case "NAM": b_maId = '<%=NAM.ClientID%>'; form_P_MOI("", "XGL"); break;
                }
                var b_ma = $get(b_maId);
                if (b_ma == null || C_NVL(b_ma.value) == "") return;
                if (b_maTen == "NAM") {
                    var b_gridId = '<%=GR_lke.ClientID%>',
                        b_nam = $get('<%=NAM.ClientID%>').value;
                    var b_hang = Grid_Fi_TimHang(b_gridId, "nam", b_nam);
                    if (b_hang > -1) {
                        GridX_datA(b_gridId, b_hang);
                        tl_kh_luong_P_CHUYEN_HANG(b_nam);
                    }
                }
            }
            catch (err) { form_P_LOI(err); }
        }
    </script>

    <%--Nhap--%>
    <script language="javascript" type="text/javascript">
        function tl_kh_luong_P_NH() {
            try {
                var b_vungId = '<%=UPa_ct.ClientID%>';
                var b_loi = form_Fs_TEXT_KTRA(b_vungId);
                if (b_loi != "") { alert(b_loi); return true; }
                var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
                stl_ch.Fs_TL_KH_LUONG_NH(a_dt_ct, tl_kh_luong_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                return false;
            }
            catch (err) { throw (err); }
        }
        function tl_kh_luong_NH_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var b_gridId = '<%=GR_lke.ClientID%>',
                b_nam = $get('<%=NAM.ClientID%>').value;
            var b_hang = Grid_Fi_TimHang(b_gridId, "nam", b_nam);
            if (b_hang < 0) b_hang = Grid_Fi_HangTrang(b_gridId);
            if (b_hang < 0) { Grid_ThemCuoi(b_gridId); b_hang = Grid_Fi_HangTrang(b_gridId); }
            GridX_datA(b_gridId, b_hang);
            Grid_P_DatGtri(b_gridId, b_hang, "nam", b_nam);
            $get('<%=moi.ClientID%>').focus();
            return false;
        }
        function tl_kh_luong_GR_lke_ActiveRowChange(gridId, rowId) {
            if (tl_kh_luong_choAct != 0) { clearTimeout(tl_kh_luong_choAct); tl_kh_luong_choAct = 0; }
            tl_kh_luong_choAct = setTimeout("tl_kh_luong_GR_lke_P_CHO()", 300);
            return true;
        }
        var tl_kh_luong_choAct = 0;
        function tl_kh_luong_GR_lke_P_CHO() {
            var b_nam = Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "nam");
            tl_kh_luong_P_CHUYEN_HANG(b_nam);
        }
        function tl_kh_luong_P_MOI() {
            form_P_MOI('<%=UPa_ct.ClientID%>', "GXL");
            Grid_ThoiActive('<%=GR_lke.ClientID%>');
            $get('<%=NAM.ClientID%>').focus();
        }
        function tl_kh_luong_P_XOA() {
            try {
                var b_nam = Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "nam");
                if (b_nam == "") tl_kh_luong_P_MOI();
                else stl_ch.Fs_TL_KH_LUONG_XOA(b_nam, tl_kh_luong_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                return true;
            }
            catch (err) { throw (err); }
        }
        function tl_kh_luong_P_XOA_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var b_gridId = '<%=GR_lke.ClientID%>';
            Grid_cutRowAct(b_gridId);
            var b_nam = Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "nam");
            tl_kh_luong_P_CHUYEN_HANG(b_nam);
        }
        function tl_kh_luong_P_CHUYEN_HANG(b_nam) {
            if (b_nam == null || b_nam == "") form_P_MOI("", "XGL");
            else stl_ch.Fs_TL_KH_LUONG_CT(b_nam, tl_kh_luong_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        function tl_kh_luong_P_CHUYEN_HANG_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            if (b_kq == "") { form_P_MOI("", "X"); return; }
            form_P_CH_TEXT('<%=UPa_ct.ClientID%>', b_kq);
            var b_gridId = '<%=GR_lke.ClientID%>',
                b_nam = $get('<%=NAM.ClientID%>').value;
            var b_hang = Grid_Fi_TimHang(b_gridId, "nam", b_nam);
            if (b_hang >= 0) GridX_datA(b_gridId, b_hang);
        }
    </script>
</asp:Content>
