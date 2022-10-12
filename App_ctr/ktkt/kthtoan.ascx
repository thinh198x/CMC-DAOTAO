<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kthtoan.ascx.cs" Inherits="kthtoan" ClassName="kthtoan" %>

<table cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <Cthuvien:GridX ID="ktoan_GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="N"
                cot="NV,MA_TK,ma_tke,tien,note,bt" cotAn="bt" hangKt="5" gchuId="gchu" ctrT="so_tt" ctrS="nhap" hamUp="kthtoan_Update">
                <Columns>
                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                    <asp:TemplateField HeaderText="PS" HeaderStyle-Width="22px">
                        <ItemTemplate>
                            <Cthuvien:kieu ID="ktoan_nv" runat="server" Width="22px" CssClass="css_Gma_c" 
                                lke="N,C" Text="N" ToolTip="Phát sinh: N-Nợ, C-Có" f_tkhao="GR_ktoan" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tài khoản" HeaderStyle-Width="95px">
                        <ItemTemplate>
                            <Cthuvien:ma ID="ktoan_ma_tk" runat="server" Width="95px" CssClass="css_Gma" 
                                kieu_chu="True" ten="mã tài khoản" ktra="kt_ma_tk,ma,ten" 
                                f_tkhao="~/App_form/ktkt/ktkt_ma/ktkt_matk.aspx" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Thống kê" HeaderStyle-Width="95px">
                        <ItemTemplate>
                            <Cthuvien:ma ID="ktoan_ma_tke" runat="server" Width="95px" CssClass="css_Gma"
                                kieu_chu="True" f_tkhao="~/App_form/ktkt/ktkt_ma/ktkt_matktke.aspx" cot_tc="ma_tk" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tiền" HeaderStyle-Width="120px">
                        <ItemTemplate>
                            <Cthuvien:so ID="ktoan_tien" runat="server" Width="118px" CssClass="css_Gso" so_tp="0" co_dau="C" 
                                f_tkhao="~/App_form/ktkt/ktkt_sodu.aspx" cot_tc="ma_tk,ma_tke" ToolTip="F1: Xem số dư" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Diễn giải" HeaderStyle-Width="230px">
                        <ItemTemplate>
                            <Cthuvien:ma ID="ktoan_note" runat="server" Width="230px" CssClass="css_Gnd" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="bt" />
                </Columns>
            </Cthuvien:GridX>
        </td>
    </tr>
    <tr>
        <td align="right">
            <table cellpadding="0" cellspacing="1">
                <tr>
                    <td>
                        <asp:Label ID="Label39" runat="server" CssClass="css_gchu" Width="30px" Text="Nợ" />
                    </td>
                    <td>
                        <Cthuvien:gchu ID="ktoan_no" runat="server" CssClass="css_tong_r" Width="150px" kt_xoa="X" ToolTip="Tổng nợ" Font-Bold="True" />
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" CssClass="css_gchu_c" Width="30px" Text="Có" />
                    </td>
                    <td>
                        <Cthuvien:gchu ID="ktoan_co" runat="server" CssClass="css_tong_r" Width="150px" kt_xoa="X" ToolTip="Tổng có" Font-Bold="True" />
                    </td>
                    <td valign="middle">
                        <table cellpadding="0" cellspacing="1">
                            <tr>
                                <td align="center" valign="middle" style="border:lightgray 1px solid; width:20px;" >
									<img runat="server" alt = "" ID="ktoan_len" runat="server" ImageUrl="~/images/bitmaps/len.gif" 
										ToolTip="Chuyển dòng lên" OnClientClick="return kthtoan_HangLen();" />
                                </td>
                                <td style="border:lightgray 1px solid; width:20px;" align="center" valign="middle">
									<img runat="server" alt = "" ID="ktoan_xuong" runat="server" ImageUrl="~/images/bitmaps/xuong.gif" 
										ToolTip="Chuyển dòng xuống" OnClientClick="return kthtoan_HangXuong();" />
                                </td>
                                <td style="border:lightgray 1px solid; width:20px;" align="center" valign="middle">
									<img runat="server" alt = "" ID="ktoan_cat" runat="server" ImageUrl="~/images/bitmaps/cat.gif" 
										ToolTip="Cắt các dòng đã chọn" OnClientClick="return kthtoan_CatDong();" />
                                </td>
                                <td style="border:lightgray 1px solid; width:20px;" align="center" valign="middle">
									<img runat="server" alt = "" ID="ktoan_chen" runat="server" ImageUrl="~/images/bitmaps/chen.gif" 
										ToolTip="Chèn dòng" OnClientClick="return kthtoan_ChenDong('C');" />
                                </td>
                                <td style="border:lightgray 1px solid; width:20px;" align="center" valign="middle">
									<img runat="server" alt = "" ID="ktoan_dia" runat="server" ImageUrl="~/images/bitmaps/dia.gif" 
										ToolTip="Lấy số liệu từ đĩa" OnClientClick="return kthtoan_File();" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
