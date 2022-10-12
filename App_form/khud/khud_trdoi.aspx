<%@ Page Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="khud_trdoi.aspx.cs" Inherits="f_khud_trdoi" Title="khud_trdoi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" style="width: 100%;">
                    <tr>
                        <td style="text-align: left;">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Lưu File và trao đổi" />
                        </td>
                        <td style="text-align: right;">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td style="width: 50px; text-align: center;">
                                        <img id="Img1" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img2" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img3" runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
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
                        <td>
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <div id="UPa_anh" style="width: 645px; height: 365px; overflow: auto;">
                                                        <video id="phim" runat="server" style="display: none;" controls />
                                                        <audio id="tieng" runat="server" style="display: none;" controls />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="1" cellspacing="1">
                                                        <tr>
                                                            <td>
                                                                <table cellpadding="1" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" CssClass="css_gchu" Width="80px" Text="Nội dung File" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <Cthuvien:ma ID="nd_fi" runat="server" CssClass="css_ma" Width="250px" />
                                                                                    </td>
                                                                                    <td id="td_nen" runat="server" style="padding-left: 5px; vertical-align: middle;">
                                                                                        <Cthuvien:gchu ID="nen" runat="server" CssClass="css_tong" Text="Nén ảnh" onclick="return khud_trdoi_P_NEN();" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table cellpadding="1" cellspacing="1">
                                                                                <tr>
                                                                                    <td>
                                                                                        <Cthuvien:nhap ID="fi_xem" runat="server" Width="68px" Text="Xem" anh="K" OnClick="return khud_trdoi_FI_XEM();" title="Xem qua ứng dụng của Window" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <Cthuvien:nhap ID="fi_nh" runat="server" Width="68px" Text="Lưu" OnClick="return khud_trdoi_CH();" title="Lưu lên Server" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <Cthuvien:nhap ID="fi_xoa" runat="server" Width="68px" Text="Xóa" OnClick="return khud_trdoi_FI_XOA();" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <Cthuvien:nhap ID="fi_lay" runat="server" Width="68px" Text="Lấy" hoi="2" OnClick="return khud_trdoi_FI_LAY();" title="Lấy từ Server vể" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <Cthuvien:nhap ID="fi_sua" runat="server" Width="68px" Text="Sửa" OnClick="return khud_trdoi_FI_SUA();" title="Sửa tiêu đề File" />
                                                                                    </td>
                                                                                    <td id="td_ghep" runat="server">
                                                                                        <Cthuvien:nhap ID="Fi_ghep" runat="server" Width="68px" Text="Ghép" OnClick="return khud_trdoi_FI_GHEP();" title="Ghép File đã có" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td id="td_anhDK" runat="server" style="display: none;">
                                                                <img id="Img4" runat="server" alt="" src="~/images/icon/anhDK.png" onmousedown="return khud_trdoi_CBI(event);" />
                                                            </td>
                                                            <td id="td_anhM" runat="server" style="display: none;">
                                                                <img id="anhM" runat="server" alt="" src="~/images/icon/map.png" title="Xem tọa độ ảnh" onclick="return khud_trdoi_anhM();" />
                                                            </td>
                                                            <td id="td_mdo" runat="server" style="display: none;">
                                                                <Cthuvien:gchu runat="server" CssClass="css_tong_c" Text="!!" ToolTip="Tọa độ không tin cậy do dùng Apple" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left;">
                                                    <div id="div_nd" style="overflow-y: scroll; background-color: White; width: 645px; height: 149px; text-align: left;" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left;">
                                                    <Cthuvien:ma ID="nd" runat="server" CssClass="css_nd" kt_xoa="X" MaxLength="500" Width="640px" onchange="return khud_trdoi_ND_NH();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top">
                                        <div id="div_lke" runat="server" style="overflow-y: scroll; height: 626px;">
                                            <Cthuvien:GridX ID="GR_fi" runat="server" AutoGenerateColumns="false" CssClass="table gridX" loai="L" hangKt="16"
                                                cot="anh,ten,chon,GOC,tdo,mdo,ngay_nh" cotAn="GOC,tdo,mdo,ngay_nh,chon" hamRow="khud_trdoi_GR_fi_RowChange()" tde="K">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" ItemStyle-Width="9px" />
                                                    <asp:BoundField HeaderText="Ảnh" DataField="anh" HeaderStyle-Width="65px" ItemStyle-Height="36px" ItemStyle-Width="64px" />
                                                    <asp:BoundField HeaderText="Nội dung File" DataField="ten" HeaderStyle-Width="281px" ItemStyle-Width="280px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:TemplateField HeaderText="X" HeaderStyle-Width="20px" ItemStyle-Width="20px" ItemStyle-CssClass="css_Gma_c">
                                                        <ItemTemplate>
                                                            <Cthuvien:kieu ID="dk_chon" runat="server" Width="20px" CssClass="css_Gma_c" lke=",x" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="GOC" />
                                                    <asp:BoundField DataField="tdo" />
                                                    <asp:BoundField DataField="mdo" />
                                                    <asp:BoundField DataField="ngay_nh" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <input type="file" id="file" runat="server" onchange="return khud_trdoi_DOC();" style="display: none;" multiple="multiple" />
    <div id="bdo" style="position: absolute; top: 40px; left: 20px; width: 1000px; height: 630px; display: none;"></div>
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?v=3&key=AIzaSyCEqhBN1zTB29Nd3fILTgMOJiPYkjmMNCk&sensor=false&amp;libraries=places"></script>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1150,750" />
</asp:Content>
