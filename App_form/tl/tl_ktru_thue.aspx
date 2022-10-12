<%@ Page Title="tl_ktru_thue" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_ktru_thue.aspx.cs" Inherits="f_tl_ktru_thue" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Khấu trừ thuế" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width: 50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img2" runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
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
                        <td valign="middle">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Phòng" CssClass="css_gchu" Width="50px" />
                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="PHONG" runat="server" kieu="U" Width="202px" CssClass="css_drop"
                                                                    onchange="tl_ktru_thue_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />
                                                            </td>
                                                            <td style="width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return tl_ktru_thue_phong();" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text="Tháng" Width="50px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:thang  placeholder='MM/yyyy' ID="THANG" runat="server" Width="100px" CssClass="css_ma_c" kt_xoa="X"
                                                                    kieu_luu="S" onblur="return tl_ktru_thue_P_KTRA('THANG')" />
                                                            </td>
                                                            <td style="width: 10px"></td>
                                                            <td>
                                                                <Cthuvien:nhap ID="tinh_thue" runat="server" Text="Tính thuế" CssClass="css_button"
                                                                    OnClick="return tl_ktru_thue_P_TINH();form_P_LOI();" Width="100px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="UPa_cc" style="height: 500px; width: 750px; overflow: scroll">
                                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="N" cot="SO_THE,TEN,TONGCHIUTHUE,PHUTHUOC,TRUTHUE" hangKt="24" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Mã cán bộ" DataField="so_the" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:TemplateField HeaderText="Tổng chịu thuế" HeaderStyle-Width="150px">
                                                        <ItemTemplate>
                                                            <Cthuvien:so ID="tongchiuthue" runat="server" Width="150px" CssClass="css_Gso" so_tp="3" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Số người phụ thuộc" HeaderStyle-Width="120px">
                                                        <ItemTemplate>
                                                            <Cthuvien:so ID="phuthuoc" runat="server" Width="120px" CssClass="css_Gso" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Giá trị" HeaderStyle-Width="120px">
                                                        <ItemTemplate>
                                                            <Cthuvien:so ID="truthue" runat="server" Width="120px" so_tp="3" CssClass="css_Gso" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                    </td>

                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return tl_ktru_thue_P_NH();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return tl_ktru_thue_P_MOI();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return tl_ktru_thue_P_XOA();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="in" runat="server" Text="In" CssClass="css_button" OnClick="return tl_ktru_thue_P_IN();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                                    <img runat="server" alt="" src="../../images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return tl_ktru_thue_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="../../images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return tl_ktru_thue_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="../../images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return tl_ktru_thue_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="../../images/bitmaps/chen.gif" title="Chèn dòng" onclick="return tl_ktru_thue_ChenDong('C');" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="tl_ktru_thue_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Tháng" DataField="thang" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" rong="20"
                                            ham="tl_ktru_thue_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1000,700" />
    </div>
</asp:Content>
