<%@ Page Title="ns_td_lichpv" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_lichpv.aspx.cs" Inherits="f_ns_td_lichpv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
       <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Lịch phỏng vấn" />
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
                <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1" >
                    <tr>
                        <td align="left">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label3" runat="server" Width="80px" Text="Phòng" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:DR_nhap ID="PHONG" ten="Phòng" runat="server" DataTextField="ten" DataValueField="ma"
                                            CssClass="css_drop" kieu="S" Width="271px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Năm" Width="80px" CssClass="css_gchu" />
                                    </td>   
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>    
                                                <td>
                                                    <Cthuvien:ma ID="NAM" ten="Năm" runat="server" CssClass="css_so" 
                                                        Width="80px" kieu_so="true" onchange="ns_td_lichpv_P_KTRA('NAM')"/>
                                                </td>                                    
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" Text="Đợt" CssClass="css_gchu_c" Width="70px"/>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="DOT" ten="Đợt" ToolTip="Đợt tuyển dụng" kieu_so="true"
                                                        runat="server" CssClass="css_so" Width="80px" kt_xoa="X"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" Width="80px" Text="Mã nhóm CV" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="NHOM_CDANH" ten="Mã nhóm công việc" runat="server" ToolTip="Mã nhóm công việc"
                                                        BackColor="#f6f7f7" ktra="ns_ma_ncdanh,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_ncdanh.aspx"
                                                        CssClass="css_ma" kieu_chu="true" kieu="S" Width="80px" onchange="ns_td_lichpv_P_KTRA('NHOM_CDANH')"/>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" Width="70px" Text="Mã vị trí" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="MA_CDANH" ten="Mã vị trí cần tuyển" runat="server" ToolTip="Mã vị trí cần tuyển" 
                                                        BackColor="#f6f7f7" ktra="ns_ma_cdanh,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_cdanh.aspx"
                                                        CssClass="css_ma" kieu_chu="true" kieu="S" Width="80px" onchange="ns_td_lichpv_P_KTRA('MA_CDANH')"/>
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
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <Cthuvien:GridX ID="GR_ct" runat="server" mauten="#9fc54e,#3a3a3a,#ffffff">
                              <%--  <Bands>
                                    <igtbl:UltraGridBand AllowAdd ="Yes">
                                        <Columns>
                                            <igtbl:UltraGridColumn BaseColumnName="ma_hs" Width="80px" AllowUpdate="No" >
                                                <Header Caption="Mã hồ sơ" />
                                                <CellStyle CssClass="css_ma_grid_nd" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="ten" Width="120px" AllowUpdate="No">
                                                <Header Caption="Tên" />
                                                <CellStyle CssClass="css_ma_grid_nd" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="nsinh" AllowUpdate="No" Width="80px" Type="Custom"
                                                EditorControlID="wnsinh">
                                                <CellStyle CssClass="css_ma_grid_c" />
                                                <Header Caption="Ngày sinh" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="trinhdo" AllowUpdate="No" Width="120px">
                                                <CellStyle CssClass="css_ma_grid_nd" />
                                                <Header Caption="Trình độ" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="kinhnghiem" AllowUpdate="No" Width="120px">
                                                <CellStyle CssClass="css_ma_grid_nd" />
                                                <Header Caption="Kinh nghiệm" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="ngaypv" AllowUpdate="Yes" Width="90px" Type="Custom"
                                                EditorControlID="wngaypv">
                                                <CellStyle CssClass="css_ma_grid_c" />
                                                <Header Caption="Ngày phỏng vấn" />
                                            </igtbl:UltraGridColumn>
                                            <igtbl:UltraGridColumn BaseColumnName="giopv" AllowUpdate="Yes" Width="90px" >
                                                <CellStyle CssClass="css_ma_grid_c" />
                                                <Header Caption="Giờ phỏng vấn" />
                                            </igtbl:UltraGridColumn>
                                        </Columns>
                                    </igtbl:UltraGridBand>
                                </Bands>
                                <DisplayLayout AllowUpdateDefault="Yes" AutoGenerateColumns="False" BorderCollapseDefault="Separate"
                                                Name="ctl00xGRxlke2"  ScrollBar="Always" ScrollBarView="Vertical" Version="4.00" AllowAddNewDefault="Yes">
                                                <FrameStyle Height="160px" />
                                                <Pager PageSize="8" />
                                            </DisplayLayout>
                                  --%>
                            </Cthuvien:GridX>

                          <%--  <Cthuvien:ngayW ID="wnsinh" runat="server" CssClass="css_ma_c" />
                            <Cthuvien:ngayW ID="wngaypv" runat="server" CssClass="css_ma_c" />--%>
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="left">
                            <table>
                                <tr>
                                    <td align="center" style="border: 1px gray solid; width: 30px">
                                        <asp:ImageButton ID="chen" runat="server" ImageUrl="~/images/bitmaps/chen.bmp" ToolTip="Thêm dòng"
                                            Style="height: 13px" OnClientClick="ns_td_lichpv_P_CHEN();" />
                                    </td>
                                    <td align="center" style="border: 1px gray solid; width: 30px">
                                        <asp:ImageButton ID="cat" runat="server" ImageUrl="~/images/bitmaps/cat.bmp" ToolTip="Cắt dòng"
                                            Style="height: 13px;" OnClientClick="ns_td_lichpv_P_CAT();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>--%>
                    <%--<tr>
                        <td align="center">
                            <table id ="UPa_nhap" runat ="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center">
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_td_lichpv_P_NH();" Width="70px" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_td_lichpv_P_MOI();" Width="70px" />
                                    </td>
                                    <td align="center">
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_td_lichpv_P_XOA();" Width="70px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>--%>
                </table>
            </td>
            <td valign="middle">
          <%-- <div id ="UPa_lke">
                <Cthuvien:GridX ID="GR_lke" runat="server" mauten="#9fc54e,#3a3a3a,#ffffff" ctr_sott="sott"
                DisplayLayout-ClientSideEvents-AfterRowActivateHandler="ns_td_lichpv_GR_lke_ActiveRowChange">
                   <Bands>
                        <igtbl:UltraGridBand AllowAdd ="Yes">
                            <Columns>
                                <igtbl:UltraGridColumn BaseColumnName="dot" Width="50px">
                                    <Header Caption="Đợt" />
                                    <CellStyle CssClass="css_ma_grid_c" />
                                </igtbl:UltraGridColumn>
                                <igtbl:UltraGridColumn BaseColumnName="ma_cdanh" Width="150px">
                                    <Header Caption="Mã vị trí cần tuyển" />
                                    <CellStyle CssClass="css_ma_grid" />
                                </igtbl:UltraGridColumn>
                                <igtbl:UltraGridColumn BaseColumnName="so_id" Hidden="true">
                                    <Header Caption="#" />
                                </igtbl:UltraGridColumn>
                            </Columns>
                        </igtbl:UltraGridBand>
                    </Bands>
                    <DisplayLayout BorderCollapseDefault="Separate" Name="GRxlke1" ScrollBar="Always" 
                        ScrollBarView="Vertical" Version="4.00" AutoGenerateColumns="False" RowHeightDefault="18px">
                        <FrameStyle Height="300px" />
                        <Pager PageSize="15" />
                    </DisplayLayout>
                </Cthuvien:GridX>
                </div>--%>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="css_border" align="left">
                <div id ="UPa_gchu">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                </div>
            </td>
        </tr>
                    </table>
                </td>
            </tr>
    </table>
    <div id ="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1070,430" />
    </div>

    <%-- Ket qua--%>
    <script language="javascript" type="text/javascript">
        function P_KET_QUA(b_dtuong, a_tso) {
            try {
                if (b_dtuong == null || b_dtuong == "") return;
                b_dtuong = b_dtuong.toUpperCase();
                var b_kq = a_tso[0];
                if (b_dtuong.indexOf("NHOM_CDANH") >= 0) {
                    $get('<%=NHOM_CDANH.ClientID%>').value = b_kq;
                    $get('<%=gchu.ClientID%>').innerHTML = a_tso[1];
                    $get('<%=NHOM_CDANH.ClientID%>').focus();
                }
                else if (b_dtuong.indexOf("MA_CDANH") >= 0) {
                    var b_nhom_cdanh = $get('<%=NHOM_CDANH.ClientID%>').value;
                    if (b_nhom_cdanh != a_tso[2]) {
                        alert("Vi tri cong viec khong thuoc nhom cong viec da chon");
                    }
                    else {
                        $get('<%=MA_CDANH.ClientID%>').value = b_kq;
                        $get('<%=gchu.ClientID%>').innerHTML = a_tso[1];
                        ns_td_lichpv_P_LKE_UV(b_kq);
                        var b_gridId = '<%=GR_ct.ClientID%>';
                        var b_hang = Grid_Fi_HangTrang(b_gridId);
                        if (b_hang < 0) {
                            Grid_ThemCuoi(b_gridId);
                            b_hang = Grid_Fi_HangTrang(b_gridId);
                        }
                        Grid_DatActiveCell(b_gridId, b_hang, "ma_hs");
                    }
                }
            }
            catch (err) { form_P_LOI(err); }
        }
    </script>
    <%-- KTRA--%>
    <script language="javascript" type="text/javascript">
        var b_mt = "";
        function ns_td_lichpv_P_KTRA(b_maTen) {
            try {
                var b_maId = "";
                b_maTen = b_maTen.toUpperCase();
                b_mt = b_maTen;
                switch (b_maTen) {
                    case "NAM": b_maId = '<%=NAM.ClientID%>'; break;
                    case "NHOM_CDANH": b_maId = '<%=NHOM_CDANH.ClientID%>'; break;
                    case "MA_CDANH": b_maId = '<%=MA_CDANH.ClientID%>'; break;
                }
                var b_ma = $get(b_maId);
                if (b_ma == null || C_NVL(b_ma.value) == "") return;
                if (b_maTen == "NAM") {
                    ns_td_lichpv_P_LKE();
                }
                else if (b_maTen == "NHOM_CDANH") {
                    skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_td_lichpv_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                }
                else if (b_maTen == "MA_CDANH") {
                    var b_nhom_cdanh = $get('<%=NHOM_CDANH.ClientID%>').value;
                    sns_ma_ch.Fs_NS_MA_CDANH_HOI(b_nhom_cdanh,b_ma.value, ns_td_lichpv_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                    ns_td_lichpv_P_LKE_UV(b_ma.value);
                    var b_gridId = '<%=GR_ct.ClientID%>';
                    var b_hang = Grid_Fi_HangTrang(b_gridId);
                    if (b_hang < 0) {
                        Grid_ThemCuoi(b_gridId);
                        b_hang = Grid_Fi_HangTrang(b_gridId);
                    }
                    Grid_DatActiveCell(b_gridId, b_hang, "ma_hs");
                }
            }
            catch (err) { form_P_LOI(err); }
        }
        function ns_td_lichpv_P_LKE_UV(b_ma_cdanh) {
            try {
                var a_cot = Grid_Fas_TenCot('<%=GR_ct.ClientID%>'),
                    b_nhom_cdanh = $get('<%=NHOM_CDANH.ClientID%>').value;
                sns_td.Fs_NS_TD_LICHPV_LKE_UV(b_nhom_cdanh, b_ma_cdanh, a_cot, ns_td_lichpv_P_LKE_UV_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            catch (err) { form_P_LOI(err); }
        }
        function ns_td_lichpv_P_LKE_UV_KQ(b_kq) {
            var b_gridId = '<%=GR_ct.ClientID%>';
            if (b_kq == "") Grid_DatTrangCa(b_gridId);
            else {
                Grid_P_DatBangCH(b_gridId, b_kq);
                Grid_DatActiveCell(b_gridId, 0, "ngaypv");
            }
        }
        function ns_td_lichpv_P_DatGchu(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) {
                form_P_LOI(b_kq);
                if (b_mt == "NHOM_CDANH") {
                    $get('<%=NHOM_CDANH.ClientID%>').value = "";
                    $get('<%=NHOM_CDANH.ClientID%>').focus();
                }
                if (b_mt == "MA_CDANH") {
                    $get('<%=MA_CDANH.ClientID%>').value = "";
                    $get('<%=MA_CDANH.ClientID%>').focus();
                }
                return;
            }
            else if (b_mt == "NHOM_CDANH" || b_mt == "MA_CDANH") {
                $get('<%=gchu.ClientID%>').innerHTML = b_kq;
            }
        }
    </script>

    <%--Nhap--%>
    
</asp:Content>
