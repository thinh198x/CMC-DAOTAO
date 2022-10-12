<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ktcn_cttt.ascx.cs" Inherits="ktcn_cttt" ClassName="ktcn_cttt" %>

<table cellspacing="1" cellpadding="0">
    <tr>
        <td>
            <asp:Label ID="Label7" runat="server" CssClass="css_phude" Text="Liệt kê chứng từ thanh toán" />
        </td>
        <td align="right">
            <img runat="server" alt = "" src="../../images/bitmaps/dong.png" onclick="return ktcn_cttt_P_DONG();" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <Cthuvien:GridX ID="ktcn_cttt_GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="L" hangKt="14">
                <Columns>
                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                    <asp:BoundField HeaderText="Ngày" DataField="ngay_ht" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_c" />
                    <asp:BoundField HeaderText="Số CT" DataField="so_ct" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                    <asp:BoundField HeaderText="Tiền" DataField="tien" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                    <asp:BoundField HeaderText="Tiền qui VNĐ" DataField="tien_qd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                    <asp:BoundField HeaderText="Nội dung" DataField="nd" HeaderStyle-Width="300px" ItemStyle-CssClass="css_Gnd" />
                    <asp:BoundField HeaderText="NSD" DataField="nsd" HeaderStyle-Width="40px" ItemStyle-CssClass="css_Gma_c" />
                </Columns>
            </Cthuvien:GridX>
        </td>
    </tr>
</table>
<script language="javascript" type="text/javascript">
    function ktcn_cttt_P_DONG() {
        ktcn_ct_P_XOA_CTR('tt');
        return false;
    }
    function ktcn_cttt_P_TAO(b_so_id, b_bt) {
        try {
            var a_cot = GridX_Fas_tenCot('<%=ktcn_cttt_GR_ct.ClientID%>');
            sktcn_ct.Fs_TAO_CTTT(b_so_id, b_bt, a_cot, ktcn_cttt_P_TAO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        catch (err) { form_P_LOI(err); }
    }
    function ktcn_cttt_P_TAO_KQ(b_kq) {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else if (b_kq == "") alert("Chưa phát sinh thanh toán");
        else {
            GridX_datBang('<%=ktcn_cttt_GR_ct.ClientID%>', b_kq);
            ktcn_ct_P_TAO_CTR("tt");
        }
    }
</script>
