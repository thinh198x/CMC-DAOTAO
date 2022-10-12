<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ktvt_tonkho.ascx.cs" Inherits="ktvt_tonkho" ClassName="ktvt_tonkho" %>
<table cellspacing="1" cellpadding="1">
    <tr>
        <td>
            <asp:Label ID="Label43" runat="server" CssClass="css_phude" Text="Liệt kê tồn kho" />
        </td>
        <td align="right">
            <img runat="server" alt = "" src="../../images/bitmaps/dong.png" onclick="return b_ktvt_tonKho_DONG();" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <Cthuvien:GridX ID="ktvt_tonKho_GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="N"
                cot="nuoc,model,dv,cl,luong,luong_p1,luong_p2,XUAT,xuat_p1,xuat_p2,tien" cotAn="luong_p1,luong_p2,xuat_p1,xuat_p2" hangKt="10" hamUp="ktvt_tonKho_Update" >
                <Columns>
                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                    <asp:BoundField HeaderText="Nước SX" DataField="nuoc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                    <asp:BoundField HeaderText="Model" DataField="model" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gma" />
                    <asp:BoundField HeaderText="Đơn vị" DataField="dv" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                    <asp:BoundField HeaderText="C.lượng" DataField="cl" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                    <asp:BoundField HeaderText="Tồn" DataField="luong" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gso" />
                    <asp:BoundField HeaderText="Tồn" DataField="luong_p1" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gso" />
                    <asp:BoundField HeaderText="Tồn" DataField="luong_p1" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gso" />
                    <asp:TemplateField HeaderText="Xuất" HeaderStyle-Width="80px">
                        <ItemTemplate>
                            <Cthuvien:so ID="tonKho_xuat" runat="server" Width="80px" CssClass="css_Gso" so_tp="6" co_dau="K" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Xuất" HeaderStyle-Width="80px">
                        <ItemTemplate>
                            <Cthuvien:so ID="tonKho_xuat_p1" runat="server" Width="80px" CssClass="css_Gso" so_tp="6" co_dau="K" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Xuất" HeaderStyle-Width="80px">
                        <ItemTemplate>
                            <Cthuvien:so ID="tonKho_xuat_p2" runat="server" Width="80px" CssClass="css_Gso" so_tp="6" co_dau="K" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Tiền" DataField="tien" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gso" />
                </Columns>
            </Cthuvien:GridX>
        </td>
    </tr>
    <tr>
        <td>
            <Cthuvien:nhap id="ktvt_tonKho_nhap" runat="server" width="80px" Text="Nhập" hoi="3" onclick="ktvt_tonKho_P_NH()" />
        </td>
        <td align="right">
            <table cellpadding="1" cellspacing="0">
                <tr>
                    <td align="center" valign="middle" style="border: lightgray 1px solid; width: 20px;">
                        <img runat="server" alt = "" src="../../images/bitmaps/cat.gif" onclick="return ktvt_tonKho_CatDong();" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
