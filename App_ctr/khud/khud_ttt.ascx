<%@ Control Language="C#" AutoEventWireup="true" CodeFile="khud_ttt.ascx.cs" Inherits="khud_ttt" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>

<table cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <div class="css_divb">
                <div class="css_divCn">
                    <Cthuvien:GridX ID="khud_ttt_GR_dk" runat="server" CssClass="table gridX" loai="F"
                        cot="ten,nd,MA,loai,bb,loi,mmm" cotAn="MA,loai,bb,loi" hangKt="12" ctrS="ttt_nhap" hamUp="khud_ttt_GR_Update">
                        <Columns>
                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                            <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gnd" />
                            <asp:TemplateField HeaderText="Giá trị" HeaderStyle-Width="357px">
                                <ItemTemplate>
                                    <Cthuvien:ma ID="khud_ttt_ma" runat="server" Width="350px" CssClass="css_Gma"  />
                                </ItemTemplate>
                            </asp:TemplateField>    
                            <asp:BoundField DataField="MA" />
                            <asp:BoundField DataField="loai" />
                            <asp:BoundField DataField="bb" />
                            <asp:BoundField DataField="loi" />
                            <asp:BoundField DataField="mmm" />
                        </Columns>
                    </Cthuvien:GridX>
                </div>
                <ctr_khud_divC:ctr_khud_divC ID="khud_ttt_GR_dk_slide" runat="server" loai="L" gridId="khud_ttt_GR_dk" />
            </div>
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2">
            <Cthuvien:gchu ID="khud_ttt_gchu" runat="server" kt_xoa="X" CssClass="css_gchu" Text="." />
        </td>
    </tr>
</table>
