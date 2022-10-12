<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ktvt_tonphieu.ascx.cs" Inherits="ktvt_tonphieu" ClassName="ktvt_tonphieu" %>

<table cellspacing="1" cellpadding="1">
    <tr id="tonPh_tr">
        <td>
            <asp:Label ID="Label44" runat="server" CssClass="css_phude" Text="Liệt kê tồn theo phiếu nhập" />
        </td>
        <td align="right">
            <img runat="server" alt = "" src="../../images/bitmaps/dong.png" onclick="return ktvt_tonPhieu_DONG();" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <Cthuvien:GridX ID="ktvt_tonPhieu_GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="N"
                cot="ngay_ht,so_tt,gia,luong,luong_p1,luong_p2,XUAT,xuat_p1,xuat_p2,ngay_ht_g,so_tt_g,so_id_ps,bt_ps,so_id_ch,so_idg,btg"
                cotAn="luong_p1,luong_p2,xuat_p1,xuat_p2,so_id_ps,bt_ps,so_id_ch,so_idg,btg" hangKt="10" ctrS="ktvt_tonph_nh" hamUp="ktvt_tonPhieu_Update" >
                <Columns>
                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                    <asp:BoundField HeaderText="Ngày" DataField="ngay_ht" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_c" />
                    <asp:BoundField HeaderText="Số CT" DataField="so_tt" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                    <asp:BoundField HeaderText="Giá" DataField="gia" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                    <asp:BoundField HeaderText="Tồn" DataField="luong" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gso" />
                    <asp:BoundField HeaderText="Tồn" DataField="luong_p1" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gso" />
                    <asp:BoundField HeaderText="Tồn" DataField="luong_p2" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gso" />
                    <asp:TemplateField HeaderText="Xuất" HeaderStyle-Width="80px">
                        <ItemTemplate>
                            <Cthuvien:so ID="tonPhieu_xuat" runat="server" Width="80px" CssClass="css_Gso" so_tp="6" co_dau="K" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Xuất" HeaderStyle-Width="80px">
                        <ItemTemplate>
                            <Cthuvien:so ID="tonPhieu_xuat_p1" runat="server" Width="80px" CssClass="css_Gso" so_tp="6" co_dau="K" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Xuất" HeaderStyle-Width="80px">
                        <ItemTemplate>
                            <Cthuvien:so ID="tonPhieu_xuat_p2" runat="server" Width="80px" CssClass="css_Gso" so_tp="6" co_dau="K" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Ngày gốc" DataField="ngay_ht_g" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_c" />
                    <asp:BoundField HeaderText="Số CT gốc" DataField="so_tt_g" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                    <asp:BoundField DataField="so_id_ps" />
                    <asp:BoundField DataField="bt_ps" />
                    <asp:BoundField DataField="so_id_ch" />
                    <asp:BoundField DataField="so_idg" />
                    <asp:BoundField DataField="btg" />
                </Columns>
            </Cthuvien:GridX>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <table cellpadding="1" cellspacing="0">
                <tr>
                    <td>
                        <Cthuvien:nhap id="ktvt_tonph_nh" runat="server" width="80px" Text="Nhập" hoi="3" onclick="ktvt_tonPhieu_NH()"/>
                    </td>
                    <td>
                        <table cellpadding="1" cellspacing="1">
                            <tr>
                                <td align="center" valign="middle" style="border: lightgray 1px solid; width: 20px;">
                                    <img runat="server" alt = "" src="../../images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ktvt_tonPhieu_CatDong('C');" />
                                </td>
                                <td align="center" valign="middle" style="border: lightgray 1px solid; width: 20px;">
                                    <img runat="server" alt = "" src="../../images/bitmaps/lay.gif" title="Cắt các dòng không chọn" onclick="return ktvt_tonPhieu_CatDong('G');" />
                                </td>
                                <td align="center" valign="middle" style="border: lightgray 1px solid; width: 20px;">
                                    <img runat="server" alt = "" src="../../images/bitmaps/chen.gif" title="Liệt kê thêm phiếu đã nhập" onclick="return ktvt_tonPhieu_TAO('C');" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
