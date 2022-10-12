<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dg_tl_cb_nvien.aspx.cs" Inherits="f_dg_tl_cb_nvien"
    Title="dg_tl_cb_nvien" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thiết lập tiêu chí đánh giá cho CBNV" />
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
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label6" runat="server" CssClass="css_gchu" Text="Mã số CB" Tolltip="Mã số cán bộ" />
                                                </td>
                                                <td>
                                                    <table cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="SO_THE" runat="server" CssClass="css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                                                    Width="140px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Số thẻ cán bộ"
                                                                    onchange="ns_biendong_bh_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten" />
                                                            </td>
                                                            <td style="width: 100px">
                                                                <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu" kt_xoa="X" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label12" runat="server" Text="Tên CB" Width="86px" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="ho_ten" runat="server" kt_xoa="X" CssClass="css_ma" kieu_chu="true"
                                                                    Width="140px" kieu_unicode="true" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="css_gchu">Nhóm tiêu chí</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="NHOMNL" runat="server" CssClass="css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                                                    Width="140px" f_tkhao="~/App_form/dg/dm/dg_dm_nhom_tieuchi.aspx" gchu="gchu" ten="Nhóm tiêu chí"
                                                                    onchange="dg_tl_cb_nvien_P_KTRA('MA_NHOM')" ktra="dg_dm_nhom_tieuchi,ma,ten" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="css_gchu">tiêu chí</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="MANL" runat="server" CssClass="css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                                        Width="140px" f_tkhao="~/App_form/dg/dm/dg_dm_tieuchi.aspx" gchu="gchu" ten="tiêu chí"
                                                        onchange="dg_tl_cb_nvien_P_KTRA('MANL')" ktra="dg_dm_tieuchi,ma,ten" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" CssClass="css_gchu">Trọng số đánh giá</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="MUCNL" ten="Trọng số đánh giá" runat="server" CssClass="css_nd" kieu_unicode="True"
                                                        kt_xoa="X" Width="140px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu">Ghi chú</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="ghichu" TextMode="MultiLine" Rows="2" ten="Ghi chú" runat="server" CssClass="css_nd" kieu_unicode="True"
                                                        kt_xoa="X" Width="140px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-left: 20px">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="nhap" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return dg_tl_cb_nvien_P_NH();form_P_LOI();"
                                                        Text="Nhập" Width="70px" />
                                                </td>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="xoa" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return dg_tl_cb_nvien_P_XOA();form_P_LOI();"
                                                        Text="Xóa" Width="70px" />
                                                </td>
                                                <td align="center">
                                                    <Cthuvien:nhap ID="chon" runat="server" CssClass="css_button" Font-Bold="True" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();"
                                                        Text="Chọn" Width="70px" />
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
                                            CssClass="table gridX" loai="X" hangKt="15" cotAn="nsd,nhomnl,manl,ghichu,nhomnl,manl" hamRow="dg_tl_cb_nvien_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã CB" DataField="so_the" HeaderStyle-Width="80px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tên CB" DataField="ho_ten" HeaderStyle-Width="120px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Nhóm tiêu chí" DataField="ten_nhom" HeaderStyle-Width="100px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tiêu chí" DataField="ten_nl" HeaderStyle-Width="100px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Trọng số đánh giá" DataField="mucnl" HeaderStyle-Width="80px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ghichu" DataField="ghichu">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="so_id" DataField="so_id">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="manl" DataField="manl">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="nhomnl" DataField="nhomnl">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" rong="40" runat="server" loai="X" gridId="GR_lke"
                                            ham="dg_tl_cb_nvien_P_LKE()" />
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
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1010,480" />
</asp:Content>
