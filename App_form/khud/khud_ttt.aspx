<%@ Page Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="khud_ttt.aspx.cs" Inherits="f_khud_ttt" Title="khud_ttt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="ten_form" runat="server" CssClass="css_tieudeM" Text="Thông tin " />
                        </td>
                        <td align="right">
                            <table id="UPa_dau" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width: 50px;">
                                        <img id="anh2" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right: 10px;">
                                        <img runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right: 10px;">
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
            <td align="left">
                <Cthuvien:GridX ID="GR_dk" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="gridX" loai="N"
                    cot="MA,TEN,LOAI,BB,rong" cotAn="LOAI,BB,rong" hangKt="12" ctrS="nhap" hamUp="khud_ttt_GR_Update">
                    <Columns>
                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                        <asp:TemplateField HeaderText="Mã" HeaderStyle-Width="120px">
                            <ItemTemplate>
                                <Cthuvien:ma ID="GR_ma" runat="server" Width="120px" CssClass="css_Gma" kieu_chu="True" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên" HeaderStyle-Width="300px">
                            <ItemTemplate>
                                <Cthuvien:ma ID="GR_ten" runat="server" Width="300px" CssClass="css_Gnd" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Loại" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <Cthuvien:kieu ID="GR_loai" runat="server" Width="50px" CssClass="css_Gma_c" 
                                    lke="C,H,S,N,G" Text="C" ToolTip="Kiểu:C-Chữ thường, H-Chữ hoa, S-Số, N-Ngày, G-Nhóm" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bắt buộc" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <Cthuvien:kieu ID="GR_bb" runat="server" Width="50px" CssClass="css_Gma_c" 
                                    lke="C,K" Text="K" ToolTip="Bắt buộc nhập: C-Có, K-Không" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rộng" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <Cthuvien:ma ID="GR_rong" runat="server" Width="50px" CssClass="css_Gma_c" kieu_so="true" ToolTip="Số ký tự" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </Cthuvien:GridX>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellspacing="1" cellpadding="1">
                    <tr>
                        <td>
                            <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" Width="70px" OnClick="return khud_ttt_P_NH();" />
                        </td>
                        <td>
                            <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="70px" OnClick="return khud_ttt_P_XOA();" />
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="1">
                                <tr>
                                    <td style="border:lightgray 1px solid; width:20px;" align="center" valign="middle">
                                        <img id="a1" runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển hàng lên" onclick="return khud_ttt_len();" />
                                    </td>
                                    <td style="border:lightgray 1px solid; width:20px;" align="center" valign="middle">
                                        <img id="a2" runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển hàng xuống" onclick="return khud_ttt_xuong();"/>
                                    </td>
                                    <td style="border:lightgray 1px solid; width:20px;" align="center" valign="middle">
                                        <img id="a3" runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn hàng" onclick="return khud_ttt_chen();"/>
                                    </td>
                                    <td style="border:lightgray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img ID="a4" runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return khud_ttt_cat(event);" />
                                    </td>
                                    <td id="td_hien_san" style="border:lightgray 1px solid; width: 20px;" align="center" valign="middle">
                                        <img ID="a5" runat="server" alt="" src="~/images/bitmaps/dia.gif" title="Thêm mã đã tạo sẵn" onclick="return khud_ttt_P_SAN();" />
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
    <div id="UPa_san" style="position:absolute;top:50px;left:70px; border: 1px solid #C0C0C0; background-color: #E9E9D1;display:none;">
        <table cellspacing="1" cellpadding="1">
            <tr id="tr_san">
                <td>
                    <asp:Label ID="Label42" runat="server" CssClass="css_phude" Text="Mã thống kê đã có" />
                </td>
                <td align="right">
                    <img id="dong_san" runat="server" alt="" src="~/images/bitmaps/dong.png" onclick="return khud_ttt_DONG();" />
                </td>
            </tr>
            <tr>
                <td>
                    <Cthuvien:GridX ID="GR_san" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="gridX" loai="L" hangKt="10">
                        <Columns>
                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                            <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                            <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="300px" ItemStyle-CssClass="css_Gnd" />
                            <asp:BoundField HeaderText="Loại" DataField="loai" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma_c" />
                        </Columns>
                    </Cthuvien:GridX>
                </td>
            </tr>
            <tr>
                <td>
                    <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="70px" OnClick="return khud_ttt_P_CHON();" />
                </td>
            </tr>
        </table>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="700,420" />
</asp:Content>
