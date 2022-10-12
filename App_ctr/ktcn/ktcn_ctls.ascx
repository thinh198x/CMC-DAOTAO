<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ktcn_ctls.ascx.cs" Inherits="ktcn_ctls" ClassName="ktcn_ctls" %>

<table cellspacing="1" cellpadding="0">
    <tr>
        <td>
            <asp:Label ID="Label8" runat="server" CssClass="css_phude" Text="Điều kiện thanh toán" />
        </td>
        <td align="right">
            <img runat="server" alt = "" src="../../images/bitmaps/dong.png" onclick="return ktcn_ctls_P_DONG();" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table cellpadding="1" cellspacing="1">
                <tr>
                    <td>
                        <Cthuvien:GridX ID="ktcn_ctls_GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" 
                            loai="N" cot="NGAY,TIEN,ls" hangKt="6" hamUp="ktcn_ctls_Update" ctrS="ktcn_ctls_ppt">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:TemplateField HeaderText="Ngày" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ctls_ngay" runat="server" Width="100px" CssClass="css_Gma_c" ToolTip="Ngày trả" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tiền" HeaderStyle-Width="120px">
                                    <ItemTemplate>
                                        <Cthuvien:so ID="ctls_tien" runat="server" Width="120px" CssClass="css_Gso" so_tp="2"
                                            co_dau="K" ToolTip="Tiền trả" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lãi suất" HeaderStyle-Width="120px">
                                    <ItemTemplate>
                                        <Cthuvien:so ID="ctls_ls" runat="server" Width="120px" CssClass="css_Gso" so_tp="4" co_dau="K" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </Cthuvien:GridX>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellspacing="1" cellpadding="1" width="100%">
                            <tr>
                                <td style="width: 50px;">
                                    <asp:Label ID="Label25" runat="server" CssClass="css_gchu" Width="50px" Text="PP.Tính" />
                                </td>
                                <td align="left">
                                    <Cthuvien:DR_nhap ID="ktcn_ctls_ppt" runat="server" CssClass="css_drop" DataTextField="ten"
                                        DataValueField="ma" Width="70px" kieu="S" />
                                </td>
                                <td align="center">
                                    <Cthuvien:nhap ID="ktcn_ctls_nhap" runat="server" class="css_button_l" Width="80px"
                                        Text="Nhập" onclick="ktcn_ctls_P_NHAP()" />
                                </td>
                                <td align="right">
                                    <table cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td style="border: lightgray 1px solid; width: 20px;" align="center" valign="middle">
                                                <img runat="server" alt = "" src="../../images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ktcn_ctls_P_HangLen();" />
                                            </td>
                                            <td style="border: lightgray 1px solid; width: 20px;" align="center" valign="middle">
                                                <img runat="server" alt = "" src="../../images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ktcn_ctls_P_HangXuong();" />
                                            </td>
                                            <td style="border: lightgray 1px solid; width: 20px;" align="center" valign="middle">
                                                <img runat="server" alt = "" src="../../images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ktcn_ctls_P_CatDong();" />
                                            </td>
                                            <td style="border: lightgray 1px solid; width: 20px;" align="center" valign="middle">
                                                <img runat="server" alt = "" src="../../images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ktcn_ctls_P_ChenDong();" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<script language="javascript" type="text/javascript">
    var b_ktcn_ctls_pptId,b_ktcn_ctls_grctId;
    function ktcn_ctls_KD(b_pptId,b_grctId) {
        b_ktcn_ctls_pptId = b_pptId; b_ktcn_ctls_grctId = b_grctId;
    }
    function ktcn_ctls_Update(b_event) {
        var b_ctr = form_Fctr_event(b_event);
        var b_value = C_NVL(b_ctr.value);
        if (b_value != "") GridX_ThemHang(b_ktcn_ctls_grctId);
        return false;
    }
    function ktcn_ctls_P_HangLen() {
        GridX_chuyenHang(b_ktcn_ctls_grctId,-1);
        return false;
    }
    function ktcn_ctls_P_HangXuong() {
        GridX_chuyenHang(b_ktcn_ctls_grctId,1);
        return false;
    }
    function ktcn_ctls_P_ChenDong() {
        GridX_chenHang(b_ktcn_ctls_grctId);
        return false;
    }
    function ktcn_ctls_P_CatDong() {
        GridX_boChon(b_ktcn_ctls_grctId,'C');
        return false;
    }
    function ktcn_ctls_P_DONG() {
        ktcn_ct_P_XOA_CTR('ls');
        return false;
    }
    function ktcn_ctls_P_NHAP() {
        try {
            var b_ppt = $get(b_ktcn_ctls_pptId).value, a_dt = GridX_Fdt_cotGtriH(b_ktcn_ctls_grctId);
            sktcn_ct.Fs_NHAP_CTLS(window.name, b_ppt, a_dt, ktcn_ctls_P_NHAP_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        catch (err) { form_P_LOI(err); }
    }
    function ktcn_ctls_P_NHAP_KQ(b_kq) {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else ktcn_ct_P_XOA_CTR('ls');
    }
    function ktcn_ctls_P_TAO() {
        try {
            var a_cot = GridX_Fas_tenCot(b_ktcn_ctls_grctId);
            sktcn_ct.Fs_TAO_CTLS(window.name, a_cot, ktcn_ctls_P_TAO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        catch (err) { form_P_LOI(err); }
    }
    function ktcn_ctls_P_TAO_KQ(b_kq) {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else { GridX_datBang(b_ktcn_ctls_grctId, b_kq); ktcn_ct_P_TAO_CTR("ls"); }
    }
</script>