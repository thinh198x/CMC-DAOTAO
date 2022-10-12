<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ktcn_ctps.ascx.cs" Inherits="ktcn_ctps" ClassName="ktcn_ctps" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>

<table cellspacing="1" cellpadding="0">
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="Label44" runat="server" CssClass="css_phude" Text="Liệt kê công nợ tồn chi tiết" />
                    </td>
                    <td align="right">
                        <img runat="server" alt = "" src="../../images/bitmaps/dong.png" onclick="return ktcn_ctps_xl('D');" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <Cthuvien:GridX ID="ktcn_ctps_GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" 
                loai="C" hangKt="13" cot="ngay_ht,so_ct,TIEN,TIEN_QD,ton,ton_qd,phi,phi_qd,nd,SO_ID_PS,bt_ps,ccc" 
                cotAn="TIEN_QD,ton_qd,phi,phi_qd,SO_ID_PS,BT_PS,ccc" hamUp="ktcn_ctps_Update" ctrS="ktcn_ctps_nhap">
                <Columns>
                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                    <asp:BoundField HeaderText="Ngày" DataField="ngay_ht" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_c" />
                    <asp:BoundField HeaderText="Số CT" DataField="so_ct" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                    <asp:TemplateField HeaderText="Thanh toán" HeaderStyle-Width="110px">
                        <ItemTemplate>
                            <Cthuvien:so ID="ctps_tien" runat="server" Width="110px" CssClass="css_Gso" so_tp="2" co_dau="C" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="T.toán qui VNĐ" HeaderStyle-Width="110px">
                        <ItemTemplate>
                            <Cthuvien:so ID="ctps_tien_qd" runat="server" Width="110px" CssClass="css_Gso" so_tp="2" co_dau="C" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Tồn" DataField="ton" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gso" />
                    <asp:BoundField HeaderText="Tồn qui VNĐ" DataField="ton_qd" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gso" />
                    <asp:TemplateField HeaderText="Phí" HeaderStyle-Width="110px">
                        <ItemTemplate>
                            <Cthuvien:so ID="ctps_phi" runat="server" Width="110px" CssClass="css_Gso" so_tp="2" co_dau="C" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phí qui VNĐ" HeaderStyle-Width="110px">
                        <ItemTemplate>
                            <Cthuvien:so ID="ctps_phi_qd" runat="server" Width="110px" CssClass="css_Gso" so_tp="2" co_dau="C" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Nội dung" DataField="nd" HeaderStyle-Width="320px" ItemStyle-CssClass="css_Gnd" />
                    <asp:BoundField DataField="so_id_ps" />
                    <asp:BoundField DataField="bt_ps" />
                    <asp:BoundField DataField="ccc" />
                </Columns>
            </Cthuvien:GridX>
        </td>
    </tr>
    <tr>
        <td align="right">
            <table cellpadding="1" cellspacing="1">
                <tr>
                    <td align="left" style="width:160px;">
                        <Cthuvien:nhap ID="ktcn_ctps_nhap" runat="server" class="css_button_l" Width="70px" Text="Nhập" onclick="return ktcn_ctps_xl('N');" />
                    </td>
                    <td id="ktcn_ctps_GR_ct_td" runat="server">
                        <khud_slide:khud_slide ID="ktcn_ctps_GR_ct_slide" runat="server" loai="C" rong="140" gridId="ktcn_ctps_GR_ct" ham="ktcn_ctps_xl('S')" />
                    </td>
                    <td>
                        <table cellpadding="1" cellspacing="0">
                            <tr>
                                <td style="border: lightgray 1px solid; width: 20px;" align="center" valign="middle">
                                    <img runat="server" alt = "" src="../../images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ktcn_ctps_xl('C');" />
                                </td>
                                <td style="border: lightgray 1px solid; width: 20px;" align="center" valign="middle">
                                    <img runat="server" alt = "" src="../../images/bitmaps/lay.gif" title="Cắt các dòng không chọn" onclick="return ktcn_ctps_xl('G');" />
                                </td>
                                <td style="border: lightgray 1px solid; width: 20px;" align="center" valign="middle">
                                    <img runat="server" alt = "" src="../../images/bitmaps/chen.gif" title="Thêm chứng từ thanh toán" onclick="return ktcn_ctps_xl('T');" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
