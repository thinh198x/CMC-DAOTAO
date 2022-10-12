<%@ Page Title="ns_tk_ma_thongkect" Language="C#" MasterPageFile="~/trangnen.master"
    AutoEventWireup="true" CodeFile="ns_tk_ma_thongkect.aspx.cs" Inherits="f_ns_tk_ma_thongkect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Mã chỉ tiêu thống kê " />
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
                        <td>
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label6" runat="server" Text="MÃ" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="MA" runat="server" CssClass="css_form" kieu_chu="true" Width="100px" onchange="ns_tk_ma_thongkect_P_KTRA('MA')"
                                                        ten="Mã thống kê" kt_xoa="G" />
                                                </td>
                                                <td>
                                                    <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" CssClass="css_gchu2" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" CssClass="css_gchu" Text="TT" Width="50px" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="TT" ten="TT" runat="server" kt_xoa="X" CssClass="css_form_r" Width="50px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" CssClass="css_gchu" Text="Bảng" Width="50px" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="BANG" runat="server" CssClass="css_form" kieu_chu="true" Width="100px"
                                            ten="Bảng thống kê" kt_xoa="X" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Text="Cột" Width="50px" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="COT" ten="cột" runat="server" CssClass="css_form" kt_xoa="X" Width="100px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" CssClass="css_gchu" Text="Giá trị" Width="50px" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="giatri" ten="cột" runat="server" CssClass="css_form" kt_xoa="X" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Text="Tên" Width="50px" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="TEN" ten="tên" runat="server" CssClass="css_form" kieu_unicode="True"
                                            kt_xoa="X" Width="190px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" runat="server" class="tableButton">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_tk_ma_thongkect_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_tk_ma_thongkect_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                    </div>
                                                </td>
                                                <%--<td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_tk_ma_thongkect_P_NH();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_tk_ma_thongkect_P_XOA();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" CssClass="css_button" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();"
                                            Width="70px" />
                                    </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="C_out">
                            <div id="UPa_lke">
                                <%--<Cthuvien:GridX ID="GR_lke" runat="server" mauten="#9fc54e,#3a3a3a,#ffffff" ctr_sott="sott"
                        DisplayLayout-ClientSideEvents-AfterRowActivateHandler="ns_tk_ma_thongkect_GR_lke_ActiveRowChange">
                      <%--  <Bands>
                            <igtbl:UltraGridBand AllowAdd="Yes">
                                <Columns>
                                    <igtbl:UltraGridColumn BaseColumnName="tt" Width="30px">
                                        <Header Caption="TT" />
                                        <CellStyle CssClass="css_grid_ma" />
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="ma" Width="60px">
                                        <Header Caption="Mã" />
                                        <CellStyle CssClass="css_grid_ma" />
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="bang" Hidden="true">
                                        <Header Caption="Bảng" />
                                        <CellStyle CssClass="css_grid_ma" />
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="cot" Hidden="true">
                                        <Header Caption="Cột" />
                                        <CellStyle CssClass="css_grid_ma" />
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="giatri" Width="100px">
                                        <Header Caption="Giá trị" />
                                        <CellStyle CssClass="css_grid_ma" />
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="ten" Width="180px">
                                        <Header Caption="Tên" />
                                        <CellStyle CssClass="css_grid_nd" />
                                    </igtbl:UltraGridColumn>
                                </Columns>
                            </igtbl:UltraGridBand>
                        </Bands>
                        <DisplayLayout Name="GRxlke1" ScrollBar="Always" ScrollBarView="Vertical" Version="4.00"
                            AutoGenerateColumns="False" RowHeightDefault="18px">
                            <FrameStyle Height="140px" />
                            <Pager PageSize="7" />
                        </DisplayLayout>
                    </Cthuvien:GridX>--%>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="800,350" />
    </div>
    <%-- KTRA--%>
    <script language="javascript" type="text/javascript">
        function ns_tk_ma_thongkect_P_KTRA(b_maTen) {
            try {
                var b_maId = "";
                b_maTen = b_maTen.toUpperCase();
                switch (b_maTen) {
                    case "MA": b_maId = '<%=MA.ClientID%>'; break;
                }
                var b_ma = $get(b_maId),
                    b_ma_value = C_NVL(b_ma.value);
                if (b_ma == null || b_ma_value == "") return;
                if (b_maTen == "MA") {
                    var b_gridId = '',
                        b_hang = Grid_Fi_TimHang(b_gridId, "ma", b_ma_value);
                    if (b_hang > -1) {
                        GridX_datA(b_gridId, b_hang);
                        ns_tk_ma_thongkect_P_CHUYEN_HANG(b_ma_value);
                        $get('<%=TT.ClientID%>').focus();
                    }
                    else { Grid_ThoiActive(b_gridId); form_P_MOI("", "X"); }
                }
            }
            catch (err) { form_P_LOI(err); }
        }
        
    </script>

    <%--Nhap--%>
    <script language="javascript" type="text/javascript">
        function ns_tk_ma_thongkect_P_NH() {
            try {
                var b_vungId = '<%=UPa_ct.ClientID%>';
                var b_loi = form_Fs_TEXT_KTRA(b_vungId);
                if (b_loi != "") { alert(b_loi); return true; }
                var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
                sti_ch.Fs_NS_TK_MA_THONGKECT_NH(a_dt_ct, ns_tk_ma_thongkect_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                return false;
            }
            catch (err) { throw (err); }
        }
        function ns_tk_ma_thongkect_NH_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var b_gridId = '',
                b_ma = $get('<%=MA.ClientID %>').value,
                b_tt = $get('<%=TT.ClientID %>').value,
                b_bang = $get('<%=BANG.ClientID %>').value,
                b_cot = $get('<%=COT.ClientID %>').value,
                b_giatri = $get('<%=giatri.ClientID %>').value,
                b_ten = $get('<%=TEN.ClientID%>').value;
            var b_hang = Grid_Fi_TimHang(b_gridId, "ma", b_ma),
                b_soDong = Grid_Fi_soDong(b_gridId);
            if (b_hang < 0) {
                b_hang = Grid_Fi_TimHangD(b_gridId, "ma", b_ma, ">");
                if (b_hang >= 0) Grid_ChenTai(b_gridId, b_hang);
                else {
                    b_hang = Grid_Fi_HangTrang(b_gridId);
                    if (b_hang < 0) { b_hang = b_soDong; Grid_ThemCuoi(b_gridId); }
                }
            }
            GridX_datA(b_gridId, b_hang);
            Grid_P_DatGtriN(b_gridId, b_hang, ["tt", "ma", "bang", "cot", "giatri", "ten"], [b_tt, b_ma, b_bang, b_cot, b_giatri, b_ten]);
            $get('<%=giatri.ClientID%>').focus();
            return false;
        }

        function ns_tk_ma_thongkect_GR_lke_ActiveRowChange(gridId, rowId) {
            if (ns_tk_ma_thongkect_choAct != 0) { clearTimeout(ns_tk_ma_thongkect_choAct); ns_tk_ma_thongkect_choAct = 0; }
            ns_tk_ma_thongkect_choAct = setTimeout("ns_tk_ma_thongkect_GR_lke_P_CHO()", 300);
            return true;
        }
        var ns_tk_ma_thongkect_choAct = 0;
        function ns_tk_ma_thongkect_GR_lke_P_CHO() {
            <%--var b_ma = Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "ma");--%>------------------------------------/* son comment */
            if (b_ma == null || b_ma == "") form_P_MOI("", "GXL");
        else ns_tk_ma_thongkect_P_CHUYEN_HANG(b_ma);
        }
        function ns_tk_ma_thongkect_P_MOI() {
            form_P_MOI('<%=UPa_ct.ClientID%>', "GXL");
            $get('<%=giatri.ClientID%>').focus();
        }

        function ns_tk_ma_thongkect_P_XOA() {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            var b_loi = form_Fs_TEXT_KTRA(b_vungId);
            if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
            var message = confirm("Bạn có chắc chắn xóa không?");
            if (message == false) { return false; }
            try {
                <%--var b_ma = C_NVL(Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "ma"));--%>   /* son comment */
                if (b_ma == "") ns_tk_ma_thongkect_P_MOI();
                else {
                    sti_ch.Fs_NS_TK_MA_THONGKECT_XOA(b_ma, ns_tk_ma_thongkect_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                }
                return true;
            }
            catch (err) { throw (err); }
        }
        function ns_tk_ma_thongkect_P_XOA_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            <%--var b_gridId = '<%=GR_lke.ClientID%>';--%>    /* son comment */
            Grid_cutRowAct(b_gridId);
            var b_ma = C_NVL(Grid_Fobj_LayGtri_Act(b_gridId, "ma"));
            if (b_ma == "") ns_tk_ma_thongkect_P_MOI();
            else ns_tk_ma_thongkect_P_CHUYEN_HANG(b_ma);
        }

        function ns_tk_ma_thongkect_P_CHUYEN_HANG(b_ma) {
            if (b_ma == null || b_ma == "") form_P_MOI("", "XGL");
            else {
                sti_ch.Fs_NS_TK_MA_THONGKECT_CT(b_ma, ns_tk_ma_thongkect_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }

        function ns_tk_ma_thongkect_P_CHUYEN_HANG_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            if (b_kq == "") { form_P_MOI("", "X"); return; }
            form_P_CH_TEXT('<%=UPa_ct.ClientID%>', b_kq);
            <%--var b_gridId = '<%=GR_lke.ClientID%>',--%> b_ma = $get('<%=MA.ClientID%>').value;    /* son comment */
            var b_hang = Grid_Fi_TimHang(b_gridId, "ma", b_ma);
            if (b_hang >= 0) GridX_datA(b_gridId, b_hang);
        }
          
        function form_dong() {
            location.reload(false);
        }
    </script>
</asp:Content>
