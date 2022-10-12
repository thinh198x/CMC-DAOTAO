<%@ Page Title="ns_ngbc" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ngbc.aspx.cs" Inherits="f_ns_ngbc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="1" cellspacing="1">
     <tr style="background-color: #999999;">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Các báo cáo về tình hình nhân sự" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width:50px;">
                                        <img alt="" ID="Anh3" runat="server" src="~/images/bitmaps/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP('TT');" />
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
            <td align="left" class="C_out">
                <table id ="UPa_ct" runat ="server" border="0" cellpadding="1" cellspacing="1" >
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Tên" CssClass="css_gchu" />
                        </td>
                        <td>
                            <Cthuvien:gchu ID="ten" runat="server" CssClass="css_gchu" kt_xoa="X" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Loại" CssClass="css_gchu" />
                        </td>
                        <td>
                            <Cthuvien:DR_nhap ID="loai" runat="server" CssClass="css_drop" Width="296px" DataTextField="ten" DataValueField="ma" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Từ ngày" CssClass="css_gchu" />
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" runat="server" CssClass="css_ma_c" Width="100px" />
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label3" runat="server" Text="Đến ngày" CssClass="css_gchu_c" Width="55px" />
                                    </td>
                                    <td>
                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" runat="server" CssClass="css_ma_c" Width="100px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Mã đ.vị" CssClass="css_gchu" />
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:ma ID="ma_dvi" runat="server" CssClass="css_ma" Width="100px" f_tkhao="~/App_form/ht/manb/ht_madvi.aspx" kt_xoa="X" />
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label5" runat="server" Text="Phòng" CssClass="css_gchu_c" Width="55px" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="phong" runat="server" CssClass="css_ma" Width="100px" f_tkhao="~/App_form/ht/manb/ht_maph.aspx" kt_xoa="X" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Số thẻ" CssClass="css_gchu" />
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:ma ID="so_the" runat="server" CssClass="css_ma" Width="284px" ten="Số thẻ cán bộ"
                                            f_tkhao="~/App_form/ns/tt/ns_ngbc.aspx" kt_xoa="X" gchu="gchu" ktra="ns_ngbc,so_the,ten"
                                             onchange="ns_ngbc_P_KTRA('SO_THE')" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Mẫu" CssClass="css_gchu" />
                        </td>
                        <td>
                            <Cthuvien:DR_nhap ID="mau" runat="server" CssClass="css_drop" DataTextField="ten" DataValueField="ma" Width="296px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Kiểu In" CssClass="css_gchu" />
                        </td>
                       <td align="center">
                            <asp:RadioButtonList ID="chon_in" runat="server" Width="100%" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="X" Text="HTML" />
                                <asp:ListItem Value="I" Text="PDF" />
                                <asp:ListItem Value="E" Text="EXCEL" />
                                <asp:ListItem Value="W" Text="WORD" />
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" valign="middle">
                            <table>
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Xem trước" Width="100px" OnServerClick="xem_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        
                            <td colspan="2">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="9" cotAn="ma,ddan,tenrp" hamRow="ns_ngbc_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="TT" DataField="tt" HeaderStyle-Width="40px" ItemStyle-CssClass="Css_Gma" />
                                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="400px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Đường dẫn" DataField="ddan" />
                                    <asp:BoundField HeaderText="Report" DataField="tenrp" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                        
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left" class="css_border">
            <div id = "UPa_gchu">
                <Cthuvien:gchu ID="gchu" runat="server" Text="" CssClass="css_gchu" />
            </div>
            </td>

        </tr>
    </table>
    <div ID="UPa_hi" runat="server">
    <Cthuvien:an ID="hf_ma" runat="server" />
    <Cthuvien:an ID="ddan" runat="server" />
    <Cthuvien:an ID="tenrp" runat="server" />
    <Cthuvien:an ID="kthuoc" runat="server" value="900,320" />
        </div>
   <%-- Ktra--%>
    <script language="javascript" type="text/javascript">
        var ns_ngbc_lkeCho, b_vungId, b_grlkeId, b_slideId,b_tmf,b_chon_inId;
        function ns_ngbc_P_KD(b_tm, b_chon_in) {
            b_tmf = b_tm; b_chon_inId = b_chon_in;
            ns_ngbc_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
            b_ma_dviId = form_Fs_TEN_ID(b_vungId, 'ma_dvi'); b_phongId = form_Fs_TEN_ID(b_vungId, 'phong');
            b_so_theId = form_Fs_TEN_ID(b_vungId, 'so_the'); b_ten_bcId = form_Fs_TEN_ID(b_vungId, 'mau');
            ns_ngbc_lkeCho = setInterval('ns_ngbc_P_LKE_CHO()', 200);
        }
        function ns_ngbc_P_LKE_CHO() {
            if ($get(b_grlkeId) != null) { clearTimeout(ns_ngbc_lkeCho); ns_ngbc_P_LKE(); }
        }
        function ns_ngbc_P_LKE() {
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            sbc.Fs_NHAN_LUOI(a_cot_lke, ns_ngbc_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        function ns_ngbc_P_LKE_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            GridX_datBang(b_grlkeId, b_kq);
        }

        function ns_ngbc_P_KTRA(b_maTen) {
            try {
                var b_maId = "";
                b_maTen = b_maTen.toUpperCase();
                switch (b_maTen) {
                    case "MA_DVI": b_maId = '<%=ma_dvi.ClientID%>'; break;
                    case "PHONG": b_maId = '<%=phong.ClientID%>'; break;
                    case "SO_THE": b_maId = '<%=so_the.ClientID%>'; break;
                }
                var b_ma = $get(b_maId);
                if (b_ma == null || C_NVL(b_ma.value) == "") return;
                skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ngbc_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            catch (err) { form_P_LOI(err); }
        }
        function ns_ngbc_P_DatGchu(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            $get('<%=gchu.ClientID%>').innerHTML = b_kq;
        }
    </script>

    <script language="javascript" type="text/javascript">
        function ns_ngbc_GR_lke_RowChange() {
            var b_gridId = '<%=GR_lke.ClientID%>';
            $get('<%=ten.ClientID%>').innerHTML = GridX_Fas_layGtriA(b_gridId, "ten");
            $get('<%=hf_ma.ClientID%>').value = GridX_Fas_layGtriA(b_gridId, "ma");
            $get('<%=ddan.ClientID%>').value = GridX_Fas_layGtriA(b_gridId, "ddan");
            $get('<%=tenrp.ClientID%>').value = GridX_Fas_layGtriA(b_gridId, "tenrp");
            return true;
        }

        function ns_ngbc_P_XEM() {
            try {
                var b_loi = form_Fs_TEXT_KTRA(b_vungId);
                if (b_loi != "") { form_P_LOI(b_loi); return; }
                var b_ma_bc = form_Fctr_TEN_DTUONG('', 'hf_ma').value,
                    b_ddan = form_Fctr_TEN_DTUONG('', 'ddan').value,
                    b_kieu_in = ns_ngbc_P_CHON_IN(), a_dt_ct = form_Faa_TEXT_ROW(b_vungId),
                    b_ten_rp = form_Fctr_TEN_DTUONG('', 'tenrp').value;
                var b_ten_bc = $get(b_ten_bcId);
                if (b_ten_bc.selectedIndex > -1) {
                    b_ten_rp = b_ten_bc.value;
                }
                if (b_ten_rp == "") { form_P_LOI('Chưa chọn đúng báo cáo'); return; }
                //modul bhxh "ns_ngbc", "TT", 
                sbc.Fs_BKT_LUU_TSO("ns_ngbc", "TT", b_ma_bc, b_ddan, b_ten_rp, b_kieu_in, a_dt_ct, ns_ngbc_P_XEM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                return false;
            }
            catch (err) { form_P_LOI(err); }
        }
        //Sửa đây
        function ns_ngbc_P_XEM_KQ(b_kq) {
            //?md=TT
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            form_P_MO(b_tmf + '/App_form/bc/xembc.aspx?md=TT', null, null, "C");
        }
        function ns_ngbc_P_CHON_IN() {
            var b_chon_in = document.getElementById(b_chon_inId);
            var b_chon = b_chon_in.getElementsByTagName('input');
            for (var x = 0; x < b_chon.length; x++)
            { if (b_chon[x].checked) return b_chon[x].value; }

        }
        function ns_ngbc_P_DVI_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            form_Fctr_TEN_DTUONG(b_vungId, 'ma_dvi').value = b_kq;
        }
    </script>
</asp:Content>