<%@ Page Title="ns_bc_syll" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_bc_syll.aspx.cs" Inherits="f_ns_bc_syll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="1" cellspacing="1">
        <tr style="background-color: #999999;">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Xem sơ yếu lý lịch cán bộ" />
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
                <table id ="UPa_ct" runat ="server" border="0" cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label10" runat="server" Text="Mã số CB" CssClass="css_gchu" Width="60px"/>
                        </td>
                        <td>
                            <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_ma" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten"
                                ToolTip="Mã số cán bộ" kieu_chu="true" Width="120px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_bc_syll_P_KTRA('SO_THE')" gchu="gchu" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Kiểu In" CssClass="css_gchu" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="kieu_in" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="X" Text="Excel" />
                                <asp:ListItem Value="W" Text="Word" />
                                <asp:ListItem Value="I" Text="Web" />
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" valign="middle">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="xem" runat="server" Text="Xem" CssClass="css_button" 
                                            Width="50px" onclick="xem_Click" />
                                    </td>
                                </tr>
                            </table>
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
    <Cthuvien:an ID="hf_ma" runat="server" />
    <Cthuvien:an ID="ddan" runat="server" />
    <Cthuvien:an ID="tenrp" runat="server" />
    <Cthuvien:an ID="kthuoc" runat="server" value="290,190" />

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
                    $get('<%=xem.ClientID%>').focus();
                }
            }
            catch (err) { form_P_LOI(err); }
        }
    </script>

   <%-- Ktra--%>
    <script language="javascript" type="text/javascript">
        function ns_bc_syll_P_KTRA(b_maTen) {
            try {
                var b_maId = "";
                b_maTen = b_maTen.toUpperCase();
                switch (b_maTen) {
                    case "SO_THE": b_maId = '<%=SO_THE.ClientID%>'; break;
                }
                var b_ma = $get(b_maId);
                if (b_ma == null || C_NVL(b_ma.value) == "") return;
                skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_bc_syll_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
            catch (err) { form_P_LOI(err); }
        }
        function ns_bc_syll_P_DatGchu(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            $get('<%=gchu.ClientID%>').innerHTML = b_kq;
        }
    </script>
</asp:Content>