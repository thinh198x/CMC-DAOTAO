<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_ht_setup.aspx.cs" Inherits="f_ns_ma_ht_setup"
    Title="ns_ma_ht_setup" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Cài đặt hệ thống" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width: 50px;">
                                        <img alt="" id="Anh3" runat="server" src="~/images/bitmaps/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td valign="middle">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label5" runat="server" CssClass="css_gchu" Text="Đơn vị" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="dvi" runat="server" CssClass="css_drop" Width="150px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu" Text="Tên" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" runat="server" CssClass="css_nd" kieu_unicode="True"
                                                        kt_xoa="X" Width="266px" ten="tên NSD" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <table id="NPa" runat="server" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_cc" runat="server" CssClass="css_tab_ngang_ac"
                                                                    Width="125px" Height="17px" ToolTip="Cài đặt thông số chấm công" Text="Chấm công" ham="ns_ma_ht_setup_P_NPA('dk')" />
                                                            </td>
                                                            <td style="width: 1px;" />
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_hd" runat="server" CssClass="css_tab_ngang_de"
                                                                    Width="125px" Height="17px" ToolTip="Cài đặt thông tin hợp đồng" Text="Hợp đồng" ham="ns_ma_ht_setup_P_NPA('nhom')" />
                                                            </td>
                                                            <td style="width: 1px;" />
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_luong" runat="server" CssClass="css_tab_ngang_de" Width="125px" Height="17px"
                                                                    ToolTip="Cài đặt thông số tính lương" Text="Tiền Lương" ham="ns_ma_ht_setup_P_NPA('dvi')" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" style="width: 470px; height: 345px;">
                                                    <asp:Panel ID="Pa_dk" runat="server">
                                                        <Cthuvien:GridX ID="GR_nv" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="N"
                                                            cot="ten,ma,nhap,xem,han,qly,MD,NV" cotAn="MD,NV" hangKt="16" ctrT="TEN" ctrS="nhap">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:BoundField HeaderText="Nghiệp vụ" DataField="ten" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gnd" />
                                                                <asp:TemplateField HeaderText="Nhập mã" HeaderStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:kieu ID="nv_ma" runat="server" Width="50px" CssClass="css_Gma_c"
                                                                            lke="C,K" Text="C" ToolTip="Quyền khai báo mã: C-Có, K-Không" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Nhập SL" HeaderStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:kieu ID="nv_nhap" runat="server" Width="50px" CssClass="css_Gma_c"
                                                                            lke="C,K" Text="C" ToolTip="Quyền nhập liệu: C-Có, K-Không" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Xem" HeaderStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:kieu ID="nv_xem" runat="server" Width="50px" CssClass="css_Gma_c"
                                                                            lke="C,K" Text="C" ToolTip="Quyền xem số liệu: C-Có, K-Không" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Hạn SL" HeaderStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:kieu ID="nv_han" runat="server" Width="50px" CssClass="css_Gma_c"
                                                                            lke="C,K" Text="C" ToolTip="Quyền đặt hạn nhập liệu: C-Có, K-Không" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Q.lý" HeaderStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:kieu ID="nv_qly" runat="server" Width="50px" CssClass="css_Gma_c"
                                                                            lke="C,K" Text="C" ToolTip="Quyền quản lý nghiệp vụ: C-Có, K-Không" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="MD" />
                                                                <asp:BoundField DataField="NV" />
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pa_nhom" runat="server" Style="display: none;">
                                                        <Cthuvien:GridX ID="GR_nhom" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                                            loai="N" hangKt="16" cot="ten,CHON,NHOM" cotAn="NHOM" ctrT="TEN" ctrS="nhap">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="402px" ItemStyle-CssClass="css_Gnd" />
                                                                <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:kieu ID="nhom_chon" runat="server" Width="40px" CssClass="css_Gma_c" lke="X," ToolTip="Chọn nhóm" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="NHOM" />
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pa_dvi" runat="server" Style="display: none;">
                                                        <Cthuvien:GridX ID="GR_dvi" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                                            loai="L" hangKt="16" cotAn="DVI" ctrT="TEN" ctrS="nhap">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="445px" ItemStyle-CssClass="css_Gnd" />
                                                                <asp:BoundField DataField="DVI" />
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" Width="80px" OnClick="return ns_ma_ht_setup_P_NH();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" Width="80px" OnClick="return ns_ma_ht_setup_P_MOI();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="80px" OnClick="return ns_ma_ht_setup_P_XOA();form_P_LOI();" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td style="border: lightgray 1px solid; width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt = "" ID="dia" runat="server" TabIndex="-1" ImageUrl="~/images/bitmaps/dia.gif"
                                                                    ToolTip="Lấy số liệu vào từ File" OnClientClick="return ns_ma_ht_setup_FILE();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td id="id_chen" runat="server" style="display: none;">
                                                    <table cellpadding="0" cellspacing="1">
                                                        <tr>
                                                            <td align="center" valign="middle" style="border: lightgray 1px solid; width: 20px;">
                                                                <img runat="server" alt = "" ID="dvi_cat" TabIndex="-1" ImageUrl="~/images/bitmaps/cat.gif"
                                                                    ToolTip="Cắt các dòng đã chọn" OnClientClick="return ns_ma_ht_setup_CatDong();" />
                                                            </td>
                                                            <td align="center" valign="middle" style="border: lightgray 1px solid; width: 20px;">
                                                                <img runat="server" alt = "" ID="dvi_chen" runat="server" ImageUrl="~/images/bitmaps/chen.gif"
                                                                    ToolTip="Chèn dòng" OnClientClick="return ns_ma_ht_setup_ChenDong();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="display: none;">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="center" valign="middle" style="border: lightgray 1px solid; width: 20px;">
                                                                <img runat="server" alt = "" ID="tiep" runat="server" ImageUrl="~/images/bitmaps/phai.gif"
                                                                    ToolTip="Chọn nghiệp vụ NSD" OnClientClick="return ns_ma_ht_setup_Chon();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                            loai="X" hangKt="15" hamRow="ns_ma_ht_setup_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Phòng" DataField="phong" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                    <td class="css_scrl_td">
                                        <khud_scrl:khud_scrl ID="GR_lke_slide" loai="X" runat="server" gridId="GR_lke" ham="ns_ma_ht_setup_P_LKE('K')" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
                    </table>
                </td>
            </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1000,685" />
</asp:Content>
