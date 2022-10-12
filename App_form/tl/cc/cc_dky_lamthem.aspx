<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cc_dky_lamthem.aspx.cs" Inherits="f_cc_dky_lamthem"
    Title="cc_dky_lamthem" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">

                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Đăng ký làm thêm" />
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
                                                <%--  <li class="vline"></li>--%>
                                                <%-- <li><i class="fa fa-user blue maR5"></i><span class="sz12">
                                                    <Cthuvien:luu ID="nsd" runat="server" Text="" CssClass="css_nsd" dich="K" /></span></li>--%>
                                            </ul>
                                            <div class="clear"></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="display: none">
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label11" runat="server" CssClass="css_gchu" Text="Tháng" Width="80px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:thang ID="thang" ten="Tháng" runat="server" CssClass="css_form_c" Width="120px" kieu_luu="I" onchange="cc_dky_lamthem_P_LKE();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,so_gio,hso" hamRow="cc_dky_lamthem_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã CB" DataField="so_the" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Ngày đăng ký" DataField="ngay_dky" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField DataField="so_id" HeaderStyle-Width="2px" />
                                                <asp:BoundField DataField="so_gio" HeaderStyle-Width="2px" />
                                                <asp:BoundField DataField="hso" HeaderStyle-Width="2px" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="50" gridId="GR_lke" ham="cc_dky_lamthem_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="middle" class="form_right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="lblmacb" runat="server" CssClass="css_gchu" Text="Mã số CB"></Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="SO_THE" ten="Số thẻ" runat="server" CssClass="css_form" kieu_chu="True" BackColor="#f6f7f7"
                                                                    kt_xoa="K" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" onchange="cc_dky_lamthem_P_KTRA('SO_THE')" Width="140px" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label19" runat="server" Text="Chức danh" Width="80px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="ten_cdanh" Enabled="false" runat="server" CssClass="css_form" Width="150px" kt_xoa="X" gchu="gchu" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label20" runat="server" Text="Họ tên" Width="80px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="ho_ten" Enabled="false" runat="server" CssClass="css_form" Width="140px" kt_xoa="X" gchu="gchu" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label17" runat="server" Text="Phòng ban" Width="80px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="ten_phong" runat="server" Enabled="false" CssClass="css_form" Width="150px" kt_xoa="X" gchu="gchu" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="lblngaydk" runat="server" CssClass="css_gchu" Text="Ngày đăng ký"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:ngay ID="NGAY_DKY" ten="Ngày làm thêm" runat="server" onchange="cc_dky_lamthem_P_KTRA('ngay_dky')" CssClass="css_form_c" kieu_luu="S"
                                                                    kt_xoa="G" Width="140px" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label5" runat="server" Width="80px" CssClass="css_gchu_c" Text="Hệ số" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:DR_nhap ID="hso" ten="Hệ số" runat="server" CssClass="css_form" Width="150px">
                                                                </Cthuvien:DR_nhap>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label8" runat="server" Width="80px" CssClass="css_gchu" Text="Từ giờ" />

                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="GIO_BD" ten="Từ giờ" runat="server" onchange="cc_dky_lamthem_P_KTRA('GIO_BD')" kt_xoa="X" CssClass="css_form_c"
                                                                    Width="140px" />

                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label1" runat="server" Width="80px" CssClass="css_gchu_c" Text="Đến giờ" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="GIO_KT" ten="Đến giờ" onchange="cc_dky_lamthem_P_KTRA('GIO_KT')" runat="server" kt_xoa="X" CssClass="css_form_c"
                                                                    Width="150px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" Width="80px" CssClass="css_gchu" Text="Số giờ làm thêm" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="so_gio" ten="Đến giờ" runat="server" kt_xoa="X" CssClass="css_form_c"
                                                                    Width="140px" />
                                                            </td>
                                                            <td align="left"></td>
                                                            <td align="left"></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="display: none">
                                                <td align="left"></td>
                                                <td align="left"></td>
                                            </tr>
                                            <tr style="display: none">
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="css_gchu" Text="Nghỉ bù" Width="80px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:kieu ID="nghibu" runat="server" Text="K" lke="C,K" ToolTip="K - Không, C - Có"
                                                        Width="30px" CssClass="css_form_c" BackColor="#00ccff" /></td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label7" runat="server" CssClass="css_gchu" Text="Ghi chú" Width="80px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="noidung" ten="Nội dung" runat="server" CssClass="css_form" kieu_unicode="true" TextMode="MultiLine" Rows="2"
                                                        Width="382px" kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>

                                    <td align="center">
                                        <table cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td>
                                                    <div class="box3 txCenter">
                                                        <a href="#" onclick="return cc_dky_lamthem_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return cc_dky_lamthem_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline"></span>Xóa</a>
                                                        <a href="#" onclick="return cc_dky_lamthem_P_IN();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">X</span>uất excel</a>
                                                        <a href="#" onclick="return cc_dky_lamthem_P_MAU();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">E</span>xcel mẫu</a>
                                                        <a href="#" onclick="return cc_dky_lamthem_FILE_Import();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">Nh</span>ập excel</a>

                                                    </div>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="btn_excel_mau" runat="server" Text="Mẫu excel" Width="70px" OnServerClick="btn_excel_mau_Click" />
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="1080,700" />
    <Cthuvien:an ID="so_id" runat="server" />
</asp:Content>
