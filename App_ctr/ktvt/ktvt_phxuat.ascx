<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ktvt_phxuat.ascx.cs" Inherits="ktvt_phxuat" ClassName="ktvt_phxuat" %>
<table cellspacing="1" cellpadding="1">
    <tr id="phXuat_tr">
        <td>
            <asp:Label ID="Label45" runat="server" CssClass="css_phude" Text="Liệt kê phiếu xuất" />
        </td>
        <td align="right">
            <img id="phXuat_dong" runat="server" alt="" src="../../images/bitmaps/dong.png" onclick="return ktvt_phXuat_DONG();" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <Cthuvien:GridX ID="ktvt_phXuat_GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="L" hangKt="10">
                <Columns>
                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                    <asp:BoundField HeaderText="Ngày" DataField="ngay_htc" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_c" />
                    <asp:BoundField HeaderText="LCT" DataField="l_ct" HeaderStyle-Width="40px" ItemStyle-CssClass="css_Gma_c" />
                    <asp:BoundField HeaderText="Số CT" DataField="so_tt" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                    <asp:BoundField HeaderText="Nội dung" DataField="nd" HeaderStyle-Width="440px" ItemStyle-CssClass="css_Gnd" />
                </Columns>
            </Cthuvien:GridX>
        </td>
    </tr>
</table>

<script language="javascript" type="text/javascript">
    function ktvt_phXuat_DONG() {
        ktvt_ct_P_XOA_CTR('phXuat');
        return false;
    }
    function ktvt_phXuat_TAO(b_so_id, b_bt) {
        try {
            var a_cot = GridX_Fas_tenCot('<%=ktvt_phXuat_GR_ct.ClientID%>');
            sktvt_ct.Fs_PH_XUAT(b_so_id, b_bt, a_cot, ktvt_phXuat_TAO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        catch (err) { form_P_LOI(err); }
    }
    function ktvt_phXuat_TAO_KQ(b_kq) {
        if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
        else if (b_kq == "") alert('Chưa có phiếu xuất');
        else {
            GridX_datBang('<%=ktvt_phXuat_GR_ct.ClientID%>', b_kq);
            ktvt_ct_P_TAO_CTR('phXuat');
        }
    }
</script>
