<%@ Page Title="ns_caidat_baocao" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_caidat_baocao.aspx.cs" Inherits="f_ns_caidat_baocao" %>

<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Phân quyền cơ cấu tổ chức" />
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
                        <td>
                            <table runat="server" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table cellspacing="0" id="UPa_ct">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" Text="Mã số CB" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="MA" ten="Mã người sử dụng" runat="server" CssClass="css_ma" BackColor="#f6f7f7"
                                                                    ktra="ht_ma_nsd,ma,ten" ToolTip="Mã người sử dụng" kieu_chu="true" Width="120px" kt_xoa="G"
                                                                    f_tkhao="~/App_form/ht/ht_mansd.aspx" onchange="ns_caidat_baocao_P_KTRA('MA')" gchu="gchu" />
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Họ tên" CssClass="css_gchu" Width="60px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ten" ten="Họ tên" runat="server" CssClass="css_ma" Width="310px" kt_xoa="X" kieu_unicode="true" ReadOnly="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:GridX ID="GR_ct" runat="server" loai="N"
                                                        AutoGenerateColumns="false" hangKt="15" cot="ma_bc,ten_bc" PageSize="1" CssClass="table gridX" hamUp="ns_caidat_baocao_Update">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:TemplateField HeaderText="Mã báo cáo" HeaderStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="ma_bc" kieu_chu="true" f_tkhao="~/App_form/ht/ht_maph.aspx" ktra="ht_ma_phong,ma,ten" runat="server" Width="200px" CssClass="css_Gma" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Chức danh" HeaderStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="cdanh" kieu_chu="true" runat="server" f_tkhao="~/App_form/ns/ma/ns_ma_cdanh.aspx" ktra="ns_ma_cdanh,ma,ten" Width="200px" CssClass="css_Gma" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="Table1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_caidat_baocao_P_NH();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_caidat_baocao_P_MOI();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_caidat_baocao_P_XOA();form_P_LOI();"
                                                        Width="70px" />
                                                </td> 
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                                    <img id="Img3" runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_caidat_baocao_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img id="Img4" runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_caidat_baocao_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img id="Img5" runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_caidat_baocao_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                    <img id="Img6" runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_caidat_baocao_ChenDong('C');" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="css_border" align="left">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                loai="X" hangKt="15" hamRow="ns_caidat_baocao_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên NSD" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                        <td class="css_scrl_td">
                            <khud_scrl:khud_scrl ID="GR_lke_slide" loai="X" runat="server" gridId="GR_lke" ham="ht_mansd_P_LKE('K')" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="450,490" />
    </div>
</asp:Content>
