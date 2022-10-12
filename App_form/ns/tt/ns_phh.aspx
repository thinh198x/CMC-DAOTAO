<%@ Page Title="ns_phh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_phh.aspx.cs" Inherits="f_ns_phh" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Quá trình phong học hàm / danh hiệu" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width:50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right:10px;" class="css_lket_dat">
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
        <tr align="left">
            <td>
                <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1" >
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Mã số CB" CssClass="css_gchu" Width="85px" />
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_ma" BackColor="#f6f7f7"
                                            ktra="ns_cb,so_the,ten" ToolTip="Mã số cán bộ" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                            kieu_chu="true" Width="135px" onchange="ns_phh_P_KTRA('so_the')" gchu="gchu" />
                                    </td>
                                    <td>
                                        <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" CssClass="css_gchu" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text="Lĩnh vực" Width="85px" CssClass="css_gchu" />
                        </td>
                        <td>
                            <Cthuvien:ma ID="linhv" runat="server" kt_xoa="X" CssClass="css_ma" Width="365px"
                                kieu_unicode="true" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label22" runat="server" Text="Nhóm C.ngành" Width="95px" CssClass="css_gchu" />
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:ma ID="nhom_cnganh" ten="Nhóm chuyên ngành" runat="server" CssClass="css_ma"
                                            kt_xoa="X" BackColor="#f6f7f7" ktra="ns_ma_ncnganh,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_ncnganh.aspx"
                                            kieu_chu="true" Width="135px" onchange="ns_phh_P_KTRA('NHOM_CNGANH')" gchu="gchu"
                                            ToolTip="Nhóm chuyên ngành" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Chuyên ngành" Width="85px" CssClass="css_gchu_c" />
                                    </td>
                                    <td>
                                        <Cthuvien:ma ID="cnganh" ten="Chuyên ngành" runat="server" CssClass="css_ma" BackColor="#f6f7f7"
                                            kt_xoa="X" ktra="ns_ma_cnganh,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_cnganh.aspx"
                                            kieu_chu="true" Width="135px" onchange="ns_phh_P_KTRA('CNGANH')" guiId="nhom_cnganh"  gchu="gchu" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="H.Hàm/D.Hiệu" Width="85px" CssClass="css_gchu" />
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:ma ID="HOCHAM" ten="Học hàm/ danh hiệu" runat="server" CssClass="css_ma"
                                            kt_xoa="X" BackColor="#f6f7f7" ktra="ns_ma_hh,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_hh.aspx"
                                            kieu_chu="true" Width="135px" onchange="ns_phh_P_KTRA('HOCHAM')" gchu="gchu"
                                            ToolTip="Tên học hàm/ Danh hiệu" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Ngày phong" Width="85px" CssClass="css_gchu_c" />
                                    </td>
                                    <td>
                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" runat="server" ToolTip="Ngày phong học hàm/ danh hiệu"
                                            Width="135px" CssClass="css_ma_c" kt_xoa="X" kieu_luu="I" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="HĐ phê duyệt" Width="85px" CssClass="css_gchu" />
                        </td>
                        <td>
                            <Cthuvien:ma ID="hoidong" runat="server" kt_xoa="X" CssClass="css_ma" Width="365px"
                                kieu_unicode="true" ToolTip="Hội đồng phong học hàm/ danh hiệu" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label14" runat="server" Text="Ghi chú" Width="85px" CssClass="css_gchu" />
                        </td>
                        <td>
                            <Cthuvien:nd ID="note" ten="Ghi chú" runat="server" Height="50px" kt_xoa="X" CssClass="css_ma"
                                Width="365px" kieu_unicode="true" TextMode="MultiLine" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_phh_P_NH();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_phh_P_MOI();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_phh_P_XOA();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="file" runat="server" Text="File" CssClass="css_button" OnClick="return nhap_file();form_P_LOI();" Width="70px" />
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
                                CssClass="table gridX" loai="X" hangKt="9" cotAn="so_id" hamRow="ns_phh_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Lĩnh vực" DataField="linhv" HeaderStyle-Width="100px"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chuyên ngành" DataField="cnganh" HeaderStyle-Width="100px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Học hàm" DataField="hocham" HeaderStyle-Width="100px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </td>
                    </tr>
                    <tr>
                         <td id="GR_lke_td" runat="server" align="center">
                            <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="150" gridId="GR_lke"
                                ham="ns_phh_P_LKE()" />
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
    <Cthuvien:an ID="so_id" runat="server" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="900,370" />
</asp:Content>
