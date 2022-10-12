<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctr_khud_ttt.ascx.cs" Inherits="ctr_khud_ttt" %>

<table cellpadding="0" cellspacing="0">
    <tr>
        <td align="left">
            <Cthuvien:GridX ID="khud_ttt_GR_dk" runat="server" CssClass="table gridX" loai="N" AutoGenerateColumns="false" 
                cot="ten,nd,MA,loai,bb,loi" cotAn="MA,loai,bb,loi" hangKt="12" ctrS="ttt_nhap" hamUp="khud_ttt_GR_Update">
                <Columns>
                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gnd" />
                    <asp:TemplateField HeaderText="Giá trị" HeaderStyle-Width="357px">
                        <ItemTemplate>
                            <Cthuvien:ma ID="khud_ttt_ma" runat="server" Width="350px" CssClass="css_Gma" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MA" />
                    <asp:BoundField DataField="loai" />
                    <asp:BoundField DataField="bb" />
                    <asp:BoundField DataField="loi" />
                </Columns>
            </Cthuvien:GridX>
        </td>
    </tr>
    <tr>
        <td align="left">
            <Cthuvien:gchu ID="khud_ttt_gchu" runat="server" kt_xoa="X" CssClass="css_gchu" Text="." />
        </td>
    </tr>
</table>