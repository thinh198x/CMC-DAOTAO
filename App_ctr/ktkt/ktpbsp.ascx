<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ktpbsp.ascx.cs" Inherits="ktpbsp" ClassName="ktpbsp" %>

<table cellpadding="0" cellspacing="0">
    <tr>
        <td align="left" style="border-bottom: 1px solid lightgray;">
            <table id="NPa_ktpbsp" runat="server" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <Cthuvien:tab id="NPa_ktpbsp_tk" runat="server" CssClass="css_tab_ngang_ac" Width="100px" Text="Tài khoản" />
                    </td>
                    <td style="width:1px;" />
                    <td>
                        <Cthuvien:tab id="NPa_ktpbsp_sp" runat="server" CssClass="css_tab_ngang_de" Width="100px" Text="Bộ phận" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="left" valign="middle" style="height:120px;width:300px">
            <asp:Panel id="Pa_ktpbsp_tk" runat="server">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left">
                            <Cthuvien:GridX id="ktpbsp_GR_tk" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                loai="N" cot="MA_TK,ma_tke,PT" hangKt="5" ctrT="NGAY" ctrS="nhap" hamUp="ktpbsp_GR_tk_Update" gchuId="ktpbsp_gchu">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Tài khoản" HeaderStyle-Width="151px">
                                        <ItemTemplate>
                                            <Cthuvien:ma id="ktpbsp_tk_ma_tk" runat="server" Width="151px" CssClass="css_Gma" kieu_chu="True" 
                                                f_tkhao="~/App_form/ktkt/ktkt_ma/ktkt_matk.aspx" ten="mã tài khoản" ktra="kt_ma_tk,ma,ten" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Thống kê" HeaderStyle-Width="152px">
                                        <ItemTemplate>
                                            <Cthuvien:ma id="ktpbsp_tk_ma_tke" runat="server" Width="152px" CssClass="css_Gma" kieu_chu="True" 
                                                f_tkhao="~/App_form/ktkt/ktkt_ma/ktkt_matktke.aspx" cot_tc="ma_tk" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="%" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so id="ktpbsp_tk_pt" runat="server" Width="60px" CssClass="css_Gso" so_tp="2" co_dau="K" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <table cellpadding="0" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Tổng" Width="40px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:gchu id="ktpbsp_to_tk" runat="server" Width="50px" CssClass="css_tong_r" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="1">
                                            <tr>
                                                <td align="center" valign="middle" style="border:lightgray 1px solid; width:20px;" >
                                                    <img runat="server" alt = "" ID="kt_a1" runat="server" TabIndex="-1" ImageUrl="~/images/bitmaps/len.gif"
                                                        ToolTip="Chuyển dòng lên" OnClientClick="return ktpbsp_tk_HangLen();" />
                                                </td>
                                                <td align="center" valign="middle" style="border:lightgray 1px solid; width:20px;" >
                                                    <img runat="server" alt = "" ID="kt_a2" runat="server" TabIndex="-1" ImageUrl="~/images/bitmaps/xuong.gif"
                                                        ToolTip="Chuyển dòng xuống" OnClientClick="return ktpbsp_tk_HangXuong();" />
                                                </td>
                                                <td align="center" valign="middle" style="border:lightgray 1px solid; width:20px;" >
                                                    <img runat="server" alt = "" ID="kt_a3" runat="server" TabIndex="-1" ImageUrl="~/images/bitmaps/cat.gif"
                                                        ToolTip="Cắt các dòng đã chọn" OnClientClick="return ktpbsp_tk_CatDong();" />
                                                </td>
                                                <td align="center" valign="middle" style="border:lightgray 1px solid; width:20px;" >
                                                    <img runat="server" alt = "" ID="kt_a4" runat="server" TabIndex="-1" ImageUrl="~/images/bitmaps/chen.gif" 
                                                        ToolTip="Chèn dòng" OnClientClick="return ktpbsp_tk_ChenDong();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel id="Pa_ktpbsp_sp" runat="server" Style="display: none;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <Cthuvien:GridX id="ktpbsp_GR_sp" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" 
                                loai="N" cot="dvi,phong,sp,PT" hangKt="5" ctrT="NGAY" ctrS="nhap" hamUp="ktpbsp_GR_sp_Update" gchuId="ktpbsp_gchu">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Đơn vị" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma id="ktpbsp_sp_dvi" runat="server" CssClass="css_Gma" Width="100px" kieu_chu="True" 
                                                f_tkhao="~/App_form/ht/ht_madvi.aspx" ten="mã đơn vị" ktra="ht_ma_dvi,ma_goc,ten" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phòng" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma id="ktpbsp_sp_phong" runat="server" CssClass="css_Gma" Width="100px" kieu_chu="True" 
                                                f_tkhao="~/App_form/ht/ht_maph.aspx" ten="mã phòng" ktra="ht_ma_phong,ma,ten" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sản phẩm" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma id="ktpbsp_sp_sp" runat="server" CssClass="css_Gma" Width="100px" kieu_chu="True" 
                                                f_tkhao="~/App_form/ktsx/ktsx_ma/ktsx_masp.aspx" ten="mã sản phẩm" ktra="sx_ma_sp,ma,ten" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="%" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <Cthuvien:so id="ktpbsp_sp_pt" runat="server" Width="60px" CssClass="css_Gso" so_tp="2" co_dau="K" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <table cellpadding="0" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Tổng" Width="40px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:gchu id="ktpbsp_to_sp" runat="server" Width="50px" CssClass="css_tong_r" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="1">
                                            <tr>
                                                <td align="center" valign="middle" style="border:lightgray 1px solid; width:20px;" >
                                                    <img runat="server" alt = "" ID="sp_a1" runat="server" TabIndex="-1" ImageUrl="~/images/bitmaps/len.gif"
                                                        ToolTip="Chuyển dòng lên" OnClientClick="return ktpbsp_sp_HangLen();" />
                                                </td>
                                                <td align="center" valign="middle" style="border:lightgray 1px solid; width:20px;" >
                                                    <img runat="server" alt = "" ID="sp_a2" runat="server" TabIndex="-1" ImageUrl="~/images/bitmaps/xuong.gif"
                                                        ToolTip="Chuyển dòng xuống" OnClientClick="return ktpbsp_sp_HangXuong();" />
                                                </td>
                                                <td align="center" valign="middle" style="border:lightgray 1px solid; width:20px;" >
                                                    <img runat="server" alt = "" ID="sp_a3" runat="server" TabIndex="-1" ImageUrl="~/images/bitmaps/cat.gif"
                                                        ToolTip="Cắt các dòng đã chọn" OnClientClick="return ktpbsp_sp_CatDong();" />
                                                </td>
                                                <td align="center" valign="middle" style="border:lightgray 1px solid; width:20px;" >
                                                    <img runat="server" alt = "" ID="sp_a4" runat="server" TabIndex="-1" ImageUrl="~/images/bitmaps/chen.gif" 
                                                        ToolTip="Chèn dòng" OnClientClick="return ktpbsp_sp_ChenDong();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td align="left">
            <Cthuvien:gchu ID="ktpbsp_gchu" runat="server" CssClass="css_gchu" kt_xoa="X" Text="." />
        </td>
    </tr>
</table>
