<%@ Control Language="C#" AutoEventWireup="true" CodeFile="khud_ma.ascx.cs" Inherits="khud_ma" className="khud_ma" %>

<table cellpadding="0" cellspacing="0">
    <tr>
        <td align="left">
            <Cthuvien:ma ID="khud_ma_ma" runat="server" Width="350px" CssClass="css_ma" />
        </td>
    </tr>
    <tr>
        <td align="left">
            <Cthuvien:GridX ID="khud_ma_GR_dk" runat="server" CssClass="table gridX" loai="MA" hangKt="10">
                <Columns>
                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                    <asp:BoundField HeaderText="Mã" DataField="ten" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                </Columns>
            </Cthuvien:GridX>
        </td>
    </tr>
</table>
