<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ns_khud.ascx.cs" Inherits="f_ns_khud" %>
<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>

<table cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <Cthuvien:GridX ID="ns_khud_GR_dk" runat="server" CssClass="gridX" loai="X"
                cot="cotan" cotAn="cotan" hangKt="0" AutoGenerateColumns="false" ctrS="ttt_nhap" hamUp="ns_khud_GR_Update" Width="100%">
                <Columns>
                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="20px" />
                    <asp:BoundField DataField="cotan" HeaderStyle-Width="10px" />
                </Columns>
            </Cthuvien:GridX>
        </td>
    </tr>
    <tr style="display:none">
        <td align="left" colspan="2">
            <Cthuvien:gchu ID="ns_khud_gchu" runat="server" kt_xoa="X" CssClass="css_gchu" Text="." />
        </td>
    </tr>
</table>
