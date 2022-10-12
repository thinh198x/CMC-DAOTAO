<%@ Page Title="tl_ht" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_ht.aspx.cs" Inherits="f_tl_ht" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width ="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Hồi tố lương" />
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
                                    <td align = "left">
                                        <asp:Label ID="Label6" runat="server" CssClass="css_gchu" Text="Tháng" Width="80px" />
                                    </td>
                                    <td>
                                        <table border="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:thang  placeholder='MM/yyyy' ID="THANG" ten="Tháng" runat="server" kieu_luu="I" CssClass="css_ma_c" Width="100px"
                                                        kt_xoa="X" onchange = "tl_ht_P_KTRA('thang')"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align = "left">
                                        <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Text="Ghi chú" Width="80px" />
                                    </td>
                                    <td>
                                        <table border="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nd ID="note" ten="Ghi chú" runat="server" kieu_luu="I" CssClass="css_nd" Width="536px" Height="50px"
                                                        kt_xoa="X" onchange = "tl_ht_P_KTRA('note')"/>
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
                                            <igtbl:UltraGridColumn BaseColumnName="so_the" AllowUpdate="Yes" IsBound="true" Type="Custom"
                                                EditorControlID="wso_the" Width="100px">
                                                <CellStyle CssClass="css_grid_ma" />
                                                <Header Caption="Mã cán bộ" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="ten" AllowUpdate="No" Width="130px">
                                                <CellStyle CssClass="css_grid_nd" />
                                                <Header Caption="Tên cán bộ" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="phong" AllowUpdate="No" Width="120px">
                                                <CellStyle CssClass="css_grid_ma" />
                                                <Header Caption="Phòng ban" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="giatri" AllowUpdate="Yes" IsBound="true" Type="Custom"
                                                EditorControlID="wgiatri" Width="120px">
                                                <CellStyle CssClass="css_ma_grid" />
                                                <Header Caption="Giá trị" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="ghichu" AllowUpdate="Yes" Width="140px">
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
                           <%-- <Cthuvien:maW ID="wso_the" runat="server" CssClass="css_ma" kieu_chu="true" ten="Mã cán bộ"
                                ktra="ns_cb,so_the,ten" gchu="gchu" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" Width="100px"
                                onblur = "tl_ht_P_KTRA('wso_the')" />
                            <Cthuvien:soW ID="wgiatri" runat="server" CssClass="css_so_r" Width="40px" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table id = "UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return tl_ht_P_NH();form_P_LOI();" Width="70px"/>
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return tl_ht_P_MOI();form_P_LOI();" Width="70px"/>
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return tl_ht_P_XOA();form_P_LOI();" Width="70px"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" class="css_border">
                <div id = "UPa_lke">
                <Cthuvien:GridX ID="GR_lke" runat="server" ctr_sott="sott" mauten="#9fc54e,#3a3a3a,#ffffff"
                    DisplayLayout-ClientSideEvents-AfterRowActivateHandler="tl_ht_GR_lke_ActiveRowChange">
                  <%--  <Bands>
                        <igtbl:UltraGridBand AllowAdd="Yes">
                            <Columns>
                                <igtbl:UltraGridColumn BaseColumnName="thang" Width="80px">
                                    <CellStyle CssClass="css_ma_grid_c" />
                                    <Header Caption="Tháng" />
                                </igtbl:UltraGridColumn>
                                <igtbl:UltraGridColumn BaseColumnName="note" Hidden="true">
                                </igtbl:UltraGridColumn>
                                <igtbl:UltraGridColumn BaseColumnName="so_id" Hidden="true">
                                </igtbl:UltraGridColumn>
                            </Columns>
                        </igtbl:UltraGridBand>
                    </Bands>
                    <DisplayLayout Name="GRxlke1" ScrollBar="Always" ScrollBarView="Vertical" Version="4.00"
                            AutoGenerateColumns="False" RowHeightDefault="18px">
                            <FrameStyle Height="285px" />
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
    <div id ="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="860,415" />
    </div>

    <%-- Ket qua--%>
    <script language="javascript" type="text/javascript">
        function P_KET_QUA(b_dtuong, a_tso) {
            try {
                if (b_dtuong == null || b_dtuong == "") return;
                b_dtuong = b_dtuong.toUpperCase();
                var b_kq = a_tso[0];
                if (b_dtuong.indexOf("WSO_THE") >= 0) {
                    var b_gridId = '<%=GR_ct.ClientID%>';
                    var b_hang = Grid_Fi_HangActive(b_gridId);
                    if (b_hang > -1) {
                        Grid_P_DatGtri(b_gridId, b_hang, "so_the", b_kq);
                        Grid_P_DatGtri(b_gridId, b_hang, "ten", a_tso[1]);
                        Grid_P_DatGtri(b_gridId, b_hang, "phong", a_tso[2]);
                        Grid_DatActiveCell(b_gridId, b_hang, "giatri");
                    }
                }
            }
            catch (err) { form_P_LOI(err); }
        }
    </script>

    <%-- KTRA--%>


    <%-- Nhap --%>
    <script language="javascript" type="text/javascript">
        function tl_ht_GR_lke_ActiveRowChange(gridId, rowId) {
            if (tl_ht_choAct != 0) { clearTimeout(tl_ht_choAct); tl_ht_choAct = 0; }
            tl_ht_choAct = setTimeout("tl_ht_GR_lke_P_CHO()", 300);
            return true;
        }
        var tl_ht_choAct = 0;
        function tl_ht_GR_lke_P_CHO() {
            var b_so_id = Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "so_id");
            $get('<%=so_id.ClientID%>').value = b_so_id;
            tl_ht_P_CHUYEN_HANG(b_so_id);
        }
        function tl_ht_P_MOI() {
            form_P_MOI('<%=UPa_ct.ClientID%>', "GXL");
            Grid_ThoiActive('<%=GR_lke.ClientID%>');
            Grid_DatTrangCa('<%=GR_ct.ClientID%>');
            $get('<%=so_id.ClientID%>').value = "";
        }
        function tl_ht_P_NH() {
            try {
                var b_vungId = '<%=UPa_ct.ClientID%>';
                var b_loi = form_Fs_TEXT_KTRA(b_vungId);
                if (b_loi != "") { alert(b_loi); return true; }
                var b_thang = $get('<%=THANG.ClientID%>').value,
                    b_note = $get('<%=note.ClientID%>').value,
                    b_so_id = $get('<%=so_id.ClientID%>').value;
                var a_dt_ct = Grid_Fdt_CotGtri('<%=GR_ct.ClientID%>');
                if (b_thang.indexOf("/") == -1)
                    b_thang = b_thang.substring(0, 2) + "/" + b_thang.substring(2);
                stl_ch.Fs_TL_HT_NH(b_so_id, b_thang, b_note, a_dt_ct, tl_ht_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                return false;
            }
            catch (err) { throw (err); }
        }
        function tl_ht_NH_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var b_gridId = '<%=GR_lke.ClientID%>',
                b_thang = $get('<%=THANG.ClientID%>').value,
                b_note = $get('<%=note.ClientID%>').value,
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
            Grid_P_DatGtriN(b_gridId, b_hang, ["thang", "so_id", "note"], [b_thang, b_so_id, b_note]);
            return false;
        }
        function tl_ht_P_CHUYEN_HANG(b_so_id) {
            if (b_so_id == null || b_so_id == "") { form_P_MOI("", "XGL"); Grid_DatTrangCa('<%=GR_ct.ClientID%>'); }
            else {
                var a_cot = Grid_Fas_TenCot('<%=GR_ct.ClientID%>');
                stl_ch.Fs_TL_HT_CT(b_so_id, a_cot, tl_ht_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        function tl_ht_P_CHUYEN_HANG_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var b_gridId = '<%=GR_ct.ClientID%>';
            if (b_kq == "") Grid_DatTrangCa(b_gridId);
            else Grid_P_DatBangCH(b_gridId, b_kq);
            $get('<%=THANG.ClientID%>').value = Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "thang");
            $get('<%=note.ClientID%>').value = Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "note");
        }
        function tl_ht_P_XOA() {
            try {
                var b_so_id = Grid_Fobj_LayGtri_Act('<%=GR_lke.ClientID%>', "so_id");
                if (b_so_id != "")
                    stl_ch.Fs_TL_HT_XOA(b_so_id, tl_ht_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                return true;
            }
            catch (err) { throw (err); }
        }
        function tl_ht_P_XOA_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var b_gridId = '<%=GR_lke.ClientID%>';
            Grid_cutRowAct(b_gridId);
            var b_so_id = Grid_Fobj_LayGtri_Act(b_gridId, "so_id");
            $get('<%=so_id.ClientID%>').value = b_so_id;
            tl_ht_P_CHUYEN_HANG(b_so_id);
        }
    </script>
</asp:Content>
