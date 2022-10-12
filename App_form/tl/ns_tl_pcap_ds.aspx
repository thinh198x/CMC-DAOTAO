<%@ Page Title="ns_tl_pcap_ds" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tl_pcap_ds.aspx.cs" Inherits="f_ns_tl_pcap_ds" %>

<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh sách phụ cấp cán bộ hưởng" />
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
                                                                <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_ma" BackColor="#f6f7f7"
                                                                    ktra="ns_cb,so_the,ten" ToolTip="Mã số cán bộ" kieu_chu="true" Width="120px"
                                                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_tl_pcap_ds_P_KTRA('SO_THE')" gchu="gchu" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label31" runat="server" Text="Tháng" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:thang  placeholder='MM/yyyy' ID="THANG" runat="server" Width="100px" CssClass="css_ma_c" kt_xoa="K"
                                                                    kieu_luu="S" onchange="ns_tl_pcap_ds_P_KTRA('SO_THE')" />
                                                            </td>
                                                        </tr>
                                                    </table>
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
                                                        CssClass="table gridX" loai="L" hangKt="9" gchuId="gchu">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:BoundField HeaderText="Mã phụ cấp" DataField="mapc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                            <asp:BoundField HeaderText="Tên phụ cấp" DataField="tenpc" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                                            <asp:BoundField HeaderText="Giá trị" DataField="giatri" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gso" />
                                                            <asp:BoundField HeaderText="Hình thức" DataField="hinhthuc" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                            <asp:BoundField HeaderText="Từ ngày" DataField="ngayd" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                                            <asp:BoundField HeaderText="Phòng" DataField="phong" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                                            <asp:BoundField HeaderText="Mã gốc" DataField="ma_goc" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                                            <asp:BoundField HeaderText="Số QĐ" DataField="so_qd" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
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
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1150,420" />
    </div>
</asp:Content>
