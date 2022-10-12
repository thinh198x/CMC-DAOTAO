<%@ Page Title="ns_sct" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_sct.aspx.cs" Inherits="f_ns_sct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
    <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Số ngày cư trú người nước ngoài" />
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
            <td>
                <table ID = "UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" CssClass="css_gchu" Text="Mã số cán bộ" Width="75px" />
                                    </td>
                                    <td>
                                        <table border="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="SO_THE" runat="server" CssClass="css_ma" kt_xoa="G" Width="120px"
                                                        BackColor="#f6f7f7" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" xuly_Enter="true" 
                                                        gchu="gchu" kieu_chu="true" ktra="ns_cb,so_the,ten" ten="Số thẻ cán bộ" 
                                                        onchange="ns_sct_P_KTRA('SO_THE')" />
                                                </td>
                                                <td>
                                                    <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id = "UPa_lke">
                            <Cthuvien:GridX ID="gr_lke" runat="server" mauten="#9fc54e,#3a3a3a,#ffffff">
                               <%-- <Bands>
                                    <igtbl:UltraGridBand AllowAdd="Yes">
                                        <Columns>
                                            <igtbl:UltraGridColumn BaseColumnName="ngayd" AllowUpdate="Yes" IsBound="true" Type="Custom"
                                                EditorControlID="ngayd" Width="120px">
                                                <CellStyle CssClass="css_ma_grid_c" />
                                                <Header Caption="Ngày" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="sct" Width="150px" AllowUpdate="Yes" IsBound="true"
                                                Type="Custom" EditorControlID="kso">
                                                <CellStyle CssClass="css_so_grid_r" HorizontalAlign="Right" />
                                                <Header Caption="Số ngày" />
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
                          <%--  <Cthuvien:ngayW ID="ngayd" onblur="ns_sct_P_KTRA('NGAYD')" runat="server" CssClass="css_ma_c" Width="90px" />
                            <Cthuvien:soW ID="kso" runat="server" CssClass="css_so_r" so_tp="0" Width="40px" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table ID = "UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" Width="70px" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_sct_P_NH();form_P_LOI();" />
                                    </td>
                                    <td style="border: 1px gray solid; width: 30px">
                                        <asp:ImageButton ID="chen" runat="server" ImageUrl="~/images/bitmaps/chen.bmp" OnClientClick="ns_sct_P_CHEN();form_P_LOI();"
                                            ToolTip="Thêm dòng cán bộ" />
                                    </td>
                                    <td style="border: 1px gray solid; width: 30px">
                                        <asp:ImageButton ID="cat" runat="server" ImageUrl="~/images/bitmaps/cat.bmp" OnClientClick="ns_sct_P_CAT();form_P_LOI();"
                                            ToolTip="Cắt dòng cán bộ" Style="height: 13px;" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="css_border" align="left">
                <div id = "UPa_gchu">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                </div>
            </td>
        </tr>
                    </table>
                </td>
          </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="hf_cb" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="380,395" />
    </div>
    
    <%-- Ket qua--%>
    <script language="javascript" type="text/javascript">
        function P_KET_QUA(b_dtuong, a_tso) {
            try {
                if (b_dtuong == null || b_dtuong == "") return;
                b_dtuong = b_dtuong.toUpperCase();
                var b_kq = a_tso[0];
                if (b_dtuong.indexOf("SO_THE") >= 0) {
                    $get('<%=SO_THE.ClientID%>').value = b_kq;
                    $get('<%=gchu.ClientID%>').innerHTML = a_tso[1];
                    ns_sct_P_LKE();
                    $get('<%=SO_THE.ClientID%>').focus();
                }
            }
            catch (err) { form_P_LOI(err); }
        }
    </script>
    <%-- KTRA--%>
    <script language="javascript" type="text/javascript">
        var b_mt = "";
        function ns_sct_P_KTRA(b_maTen) {
            try {
                var b_maId = "";
                b_maTen = b_maTen.toUpperCase();
                b_mt = b_maTen;
                switch (b_maTen) {
                    case "SO_THE": b_maId = '<%=SO_THE.ClientID%>'; break;
               
                }
                var b_ma = $get(b_maId);
                if (b_ma == null || C_NVL(b_ma.value) == "") return;
                if (b_maTen == "SO_THE") {
                    skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_sct_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                }
                else if (b_maTen == "NGAYD") {
                    var b_gridID = '<%=gr_lke.ClientID%>';
                    var b_ngay = Grid_Fobj_LayGtri_Act(b_gridID, "ngayd");
                    var b_so_dong = Grid_Fi_soDong(b_gridID);
                    var b_dem = 0, b_xuat_hien = 0;
                    for (b_dem = 0; b_dem < b_so_dong; b_dem++)
                        if (Grid_Fobj_LayGtri(b_gridID, b_dem, "ngayd") == b_ngay) b_xuat_hien++;
                    if (b_xuat_hien > 1) {
                        alert("Không được khai báo trùng ngày");
                        var b_hang = Grid_Fi_HangActive(b_gridID);
                        if (b_hang > -1) {
                            Grid_P_DatGtri(b_gridID, b_hang, "ngayd", "");
                            Grid_DatActiveCell(b_gridID, b_hang, "ngayd");
                        }
                    }
                }
            }
            catch (err) { form_P_LOI(err); }
        }
        function ns_sct_P_DatGchu(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) {
                form_P_LOI(b_kq);
                if (b_mt == "SO_THE") {
                    Grid_DatTrangCa('<%=gr_lke.ClientID%>');
                    $get('<%=SO_THE.ClientID%>').value = "";
                    $get('<%=SO_THE.ClientID%>').focus();
                }
                return;
            }
            else if (b_mt == "SO_THE") ns_sct_P_LKE();
            $get('<%=gchu.ClientID%>').innerHTML = b_kq;
        }
    </script>

    <%--Nhap--%>
    <script language="javascript" type="text/javascript">
        function ns_sct_P_NH() {
            try {
                var b_vungId = '<%=UPa_ct.ClientID%>';
                var b_loi = form_Fs_TEXT_KTRA(b_vungId);
                if (b_loi != "") { alert(b_loi); return true; }
                var b_so_the = $get('<%=SO_THE.ClientID%>').value;
                var a_dt_ct = Grid_Fdt_CotGtri('<%=gr_lke.ClientID%>');
                sns_qt.Fs_NS_SCT_NH(b_so_the, a_dt_ct, ns_sct_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                return false;
            }
            catch (err) { throw (err); }
        }
        function ns_sct_NH_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            $get('<%=SO_THE.ClientID%>').focus();
            return false;
        }
        function ns_sct_P_LKE() {
            try {
                var a_cot = Grid_Fas_TenCot('<%=gr_lke.ClientID%>'),
                    b_so_the = $get('<%=SO_THE.ClientID%>').value;
                sns_qt.Fs_NS_SCT_LKE(b_so_the, a_cot, ns_sct_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            catch (err) { form_P_LOI(err); }
        }
        function ns_sct_P_LKE_KQ(b_kq) {
            var b_gridId = '<%=gr_lke.ClientID%>';
            if (b_kq == "") Grid_DatTrangCa(b_gridId);
            else Grid_P_DatBangCH(b_gridId, b_kq);
            var b_hang = Grid_Fi_HangTrang(b_gridId);
            if (b_hang < 0) {
                Grid_ThemCuoi(b_gridId);
                b_hang = Grid_Fi_HangTrang(b_gridId);
            }
            Grid_DatActiveCell(b_gridId, b_hang, "ngayd");
        }
        function ns_sct_P_CHEN() {
            var b_so_the = $get('<%=SO_THE.ClientID%>').value;
            if (b_so_the == "") { alert("Hãy F1 chọn cán bộ"); return; }
            var b_gridID = '<%=gr_lke.ClientID%>';
            var b_ngay_ht = new Date();
            var b_ngay = b_ngay_ht.getDate(), b_thang = b_ngay_ht.getMonth() + 1, b_nam = b_ngay_ht.getFullYear();
            if (b_ngay < 10) { b_ngay = '0' + b_ngay; }
            if (b_thang < 10) { b_thang = '0' + b_thang; }
            var b_ngay_ht1 = b_ngay + "/" + b_thang + "/" + b_nam;
            var b_hang = Grid_Fi_TimHang(b_gridID, "ngayd", b_ngay_ht1);
            if (b_hang > -1) { alert("Đã tồn tại ngày hôm nay.Mai hãy chèn hàng"); }
            else {
                b_hang = Grid_Fi_HangTrang(b_gridID);
                if (b_hang < 0) {
                    Grid_ThemCuoi(b_gridID);
                    b_hang = Grid_Fi_HangTrang(b_gridID);
                }
                Grid_P_DatGtri(b_gridID, b_hang, "ngayd", b_ngay_ht1);
                Grid_DatActiveCell(b_gridID, b_hang, "sct");
            }
        }
        function ns_sct_P_CAT() {
            Grid_cutRowAct('<%=gr_lke.ClientID%>');
        }
    </script>
</asp:Content>
