<%@ Page Title="ns_cc_giaitrinh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_giaitrinh.aspx.cs" Inherits="f_ns_cc_giaitrinh" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Giải trình chấm công" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <div class="acc">
                                            <ul>
                                                <li><a href="#" onclick="return form_dong();"><i class="fa fa-sign-out"></i></a></li>
                                                <li><a href="#" onclick="return form_GOP();"><i class="fa fa-envelope-o"></i></a></li>
                                                <li><a href="#" onclick="return form_HELP();"><i class="fa fa-question"></i></a></li>
                                            </ul>
                                            <div class="clear"></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>

                        <td class="form_right" colspan="2">
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Text="Ban/Phòng"
                                            Width="50px" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>

                                                <td>
                                                    <Cthuvien:DR_lke ID="BAN" ktra="DT_BAN" runat="server" Width="150px" onchange="ns_cc_giaitrinh_P_KTRA_DR('BAN')" kt_xoa="X" ten="Ban/Bộ phận"></Cthuvien:DR_lke>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Text="Phòng/Bộ phận" Width="50px" /> 
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="phong" ktra="DT_PHONG" runat="server" Width="150px" onchange="ns_cc_giaitrinh_P_KTRA_DR('PHONG')" kt_xoa="X" ten="Phòng/Bộ phận"></Cthuvien:DR_lke>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label11" runat="server" CssClass="css_gchu_c" Text="Năm"
                                            Width="50px" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_lke ID="NAM" ktra="DT_NAM_TK" kt_xoa="K" ten="Năm" runat="server" Width="70px" onchange="ns_cc_giaitrinh_P_NAM();">                                                                                
                                                    </Cthuvien:DR_lke>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="css_gchu_c" Text="Kỳ công"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="KYLUONG" ktra="DT_KY" kt_xoa="G" ten="Kỳ công" runat="server" Width="220px" onchange="ns_cc_giaitrinh_P_KTRA_DR('KYLUONG');">                                                                                
                                                    </Cthuvien:DR_lke>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" class="form_left" colspan="2">
                                        <div>
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="10" cotAn="lhd,ma_nguoiky,cdanh_nguoiky">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="soqd" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ngay_hl" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                    <asp:BoundField HeaderText="Chức danh" DataField="cap_ktkl" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="Phòng ban" DataField="hinhthuc" HeaderStyle-Width="145px" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="Ngày giải trình" DataField="lydo" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="Giờ vào" DataField="sotien" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gso" />
                                                    <asp:BoundField HeaderText="Giờ ra" DataField="sotien" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gso" />
                                                    <asp:BoundField HeaderText="Mã công" DataField="sotien" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gso" />
                                                    <asp:BoundField HeaderText="Lý do" DataField="sotien" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gso" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                        <div>
                                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                                ham="ns_cc_giaitrinh_P_LKE()" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" class="tableButton" width="100%">
                                            <tr>
                                                <td style="text-align: center">
                                                    <Cthuvien:nhap ID="XuatExcel" runat="server" Text="Xuất excel" Width="90px" OnClick="return ns_cc_giaitrinh_P_IN();form_P_LOI();" />
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
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
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1100,700" />
</asp:Content>
