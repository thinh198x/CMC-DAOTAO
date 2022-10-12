<%@ Page Title="ns_bhxh_thaydoi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_bhxh_thaydoi.aspx.cs" Inherits="f_ns_bhxh_thaydoi" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thay đổi thông tin bảo hiểm" />
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
                        <td align="left">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <table id="Upa_ct" runat="server" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label10" runat="server" Text="Mã số CB" Width="75px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <table cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:ma ID="SO_THE" runat="server" kt_xoa="G" CssClass="css_ma" kieu_chu="true"
                                                                                gchu="gchu" ten="Mã số cán bộ" Width="150px" ToolTip="Mã số cán bộ" BackColor="#f6f7f7"
                                                                                ktra="ns_bhxh,so_the,ten" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_bhxh_P_KTRA('SO_THE')" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label12" runat="server" Width="20px" Text=" " CssClass="css_gchu_c" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:ma ID="ten" ten="Tên cán bộ" runat="server" kieu_unicode="true" Width="220px"
                                                                                kt_xoa="G" CssClass="css_ma" Enabled="false" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="Ngày" Width="75px" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay" runat="server" kt_xoa="G" CssClass="css_ma_c" Width="150px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                    CssClass="table gridX" loai="N" hangKt="10" cotAn="so_id" cot="muctd,noidungcu,noidungmoi">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                        <asp:BoundField HeaderText="Mục thay đổi" DataField="muctd" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:TemplateField HeaderText="Nội dung cũ" HeaderStyle-Width="180px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="noidungcu" runat="server" Width="180px" CssClass="css_Gma" ToolTip="Nội dung cũ" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Nội dung mới" HeaderStyle-Width="180px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="noidungmoi" runat="server" Width="180px" CssClass="css_Gma" ToolTip="Nội dung mới" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </Cthuvien:GridX>
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
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="nhap" runat="server" Width="70px" CssClass="css_button" OnClick="return ns_bhxh_thaydoi_P_NH();form_P_LOI();"
                                                        Text="Nhập" />
                                                </td>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="moi" runat="server" Width="70px" CssClass="css_button" OnClick="return ns_bhxh_thaydoi_P_MOI();form_P_LOI();"
                                                        Text="Mới" />
                                                </td>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="xoa" runat="server" Width="70px" CssClass="css_button" OnClick="return ns_bhxh_thaydoi_P_XOA();form_P_LOI();"
                                                        Text="Xóa" />
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
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="12" hamRow="ns_bhxh_thaydoi_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Số Thẻ" DataField="so_the" HeaderStyle-Width="120px"
                                                    ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Họ Tên" DataField="ten" HeaderStyle-Width="190px" ItemStyle-CssClass="css_Gma" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_bhxh_thaydoi_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="css_border" colspan="2">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" kt_xoa="X" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="920,350" />
    </div>
</asp:Content>
