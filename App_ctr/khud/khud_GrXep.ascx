<%@ Control Language="C#" AutoEventWireup="true" CodeFile="khud_GrXep.ascx.cs" Inherits="khud_GrXep" className="khud_GrXep" %>

<div id="FGr_XepDiv" runat="server" class="css_divOver" style="display:none;" onclick="return FGr_Xep_DO(event);">
    <div id="FGr_Xep" runat="server" class="css_divCt" style="padding:15px; padding-left:10px; width:210px;">
        <table cellspacing="1" cellpadding="1">
            <tr>
                <td>
                    <asp:Label ID="Label21" runat="server" CssClass="css_gchu" Width="60px" Text="Kiểu xếp" />
                </td>
                <td>
                    <Cthuvien:kieu ID="FGr_Xep_kieu" runat="server" CssClass="css_nd_c" Width="130px" lke="Không xếp,Tăng dần,Giảm dần" tra="p,l,x" />
                </td>
            </tr>
            <tr id="FGr_Xep_tr_ma" runat="server">
                <td style="text-align:left;">
                    <asp:Label ID="Label22" runat="server" CssClass="css_gchu" Text="Lọc từ" />
                </td>
                <td>
                    <Cthuvien:ma ID="FGr_Xep_ma_tu" runat="server" CssClass="css_ma" Width="130px" kt_xoa="X" />
                </td>
            </tr>
            <tr id="FGr_Xep_tr_ma_den" runat="server">
                <td style="text-align:left;">
                    <asp:Label ID="Label23" runat="server" CssClass="css_gchu" Text="Đến" />
                </td>
                <td>
                    <Cthuvien:ma ID="FGr_Xep_ma_den" runat="server" CssClass="css_ma" Width="130px" kt_xoa="X" />
                </td>
            </tr>
            <tr id="FGr_Xep_tr_ng" runat="server">
                <td style="text-align:left;">
                    <asp:Label ID="Label24" runat="server" CssClass="css_gchu" Text="Lọc từ" />
                </td>
                <td>
                    <Cthuvien:ngay ID="FGr_Xep_ng_tu" runat="server" CssClass="css_ngay" Width="130px" kt_xoa="X" 
                        kieu_date="true" TaoValid="true" kieu_luu="S" ten="từ ngày" />
                </td>
            </tr>
            <tr id="FGr_Xep_tr_ng_den" runat="server">
                <td style="text-align:left;">
                    <asp:Label ID="Label25" runat="server" CssClass="css_gchu" Text="Đến" />
                </td>
                <td>
                    <Cthuvien:ngay ID="FGr_Xep_ng_den" runat="server" CssClass="css_ngay" Width="130px" kt_xoa="X" 
                        kieu_date="true" TaoValid="true" kieu_luu="S" ten="đến ngày" />
                </td>
            </tr>
            <tr id="FGr_Xep_tr_so" runat="server">
                <td style="text-align:left;">
                    <asp:Label ID="Label26" runat="server" CssClass="css_gchu" Text="Lọc từ" />
                </td>
                <td>
                    <Cthuvien:so ID="FGr_Xep_so_tu" runat="server" CssClass="css_so" Width="130px" kt_xoa="X" co_dau="C" so_tp="2"  />
                </td>
            </tr>
            <tr id="FGr_Xep_tr_so_den" runat="server">
                <td style="text-align:left;">
                    <asp:Label ID="Label27" runat="server" CssClass="css_gchu" Text="Đến" />
                </td>
                <td>
                    <Cthuvien:so ID="FGr_Xep_so_den" runat="server" CssClass="css_so" Width="130px" kt_xoa="X" co_dau="C" so_tp="2" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td style="text-align:center;">
                    <Cthuvien:nhap ID="FGr_Xep_chon" runat="server" Width="70px" Text="Chọn" OnClick="return FGr_Xep_NH();" anh="K" />
                </td>
            </tr>
        </table>
    </div>
</div>
<script>
    var b_FGr_Xep_tr_maId = '<%=FGr_Xep_tr_ma.ClientID%>',b_FGr_Xep_tr_soId = '<%=FGr_Xep_tr_so.ClientID%>',
        b_FGr_Xep_tr_ngId = '<%=FGr_Xep_tr_ng.ClientID%>', b_FGr_XepId = '<%=FGr_Xep.ClientID%>',
        b_FGr_Xep_gridId, b_FGr_Xep_td, b_FGr_Xep_cot;
    function FGr_Xep_NH() {
        var b_loi, b_tu, b_den;
        if (b_FGr_Xep_cot.loai == 'n') {
            b_tu = C_NVL(form_Fs_TEN_GTRI(b_FGr_XepId, 'FGr_Xep_ng_tu'));
            if (C_NVL(b_tu.replace('/', '')) == '') b_tu = '';
            else {
                b_loi = Fs_NGAY_LOI(b_tu, 'C');
                if (b_loi != '') { form_P_LOI_DICH(b_loi); return false; }
            }
            b_den = C_NVL(form_Fs_TEN_GTRI(b_FGr_XepId, 'FGr_Xep_ng_den'));
            if (C_NVL(b_den.replace('/', '')) == '') b_den = '';
            else {
                b_loi = Fs_NGAY_LOI(b_den, 'C');
                if (b_loi != '') { form_P_LOI_DICH(b_loi); return false; }
            }
        }
        else if (b_FGr_Xep_cot.loai == 's') {
            b_tu = C_NVL(form_Fs_TEN_GTRI(b_FGr_XepId, 'FGr_Xep_so_tu'));
            if (C_NVL(b_tu.replace(',', '')) == '') b_tu = '';
            b_den = C_NVL(form_Fs_TEN_GTRI(b_FGr_XepId, 'FGr_Xep_so_den'));
            if (C_NVL(b_den.replace(',', '')) == '') b_den = '';
        }
        else {
            b_tu = C_NVL(form_Fs_TEN_GTRI(b_FGr_XepId, 'FGr_Xep_ma_tu'));
            b_den = C_NVL(form_Fs_TEN_GTRI(b_FGr_XepId, 'FGr_Xep_ma_den'));
        }
        var b_loc = (b_tu != '' || b_den != '') ? 'l' : '';
        var b_xep = form_Fs_TEN_GTRI(b_FGr_XepId, 'FGr_Xep_kieu');
        b_FGr_Xep_td.className = 'css_HeStG' + b_xep + b_loc;
        if (b_xep != 'p' || b_loc != '') {
            b_xep = b_FGr_Xep_cot.cot + '|' + b_FGr_Xep_cot.loai + '|' + b_xep + '|' + b_tu + '|' + b_den;
        }
        else b_xep = '';
        if (b_xep != C_NVL(b_FGr_Xep_td.getAttribute('xep'))) {
            Attribute_P_DAT(b_FGr_Xep_td, 'xep', b_xep);
            b_loc = $get(b_FGr_Xep_gridId).getAttribute('hamLke');
            eval(b_loc);
        }
        $get(b_FGr_XepId + 'Div').style.display = 'none';
        form_chay = 0;
        return false;
    }
</script>
