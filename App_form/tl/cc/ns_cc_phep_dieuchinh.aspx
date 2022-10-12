<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_cc_phep_dieuchinh.aspx.cs" Inherits="f_ns_cc_phep_dieuchinh"
    Title="ns_cc_phep_dieuchinh" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>


<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Điều chỉnh phép - thâm niên" />
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
                        <td valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                            loai="X" hangKt="12" cotAn="so_id" hamRow="ns_cc_phep_dieuchinh_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="so_id" DataField="so_id" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Tên NV" DataField="ten" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Chức danh" DataField="chuc_danh" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Phòng" DataField="phong" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Số tháng điều chỉnh" DataField="thang_kttn" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Số phép điều chỉnh" DataField="phep_dieuchinh" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gnd" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" rong="70" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_cc_phep_dieuchinh_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Lable1" runat="server" CssClass="css_gchu" Text="Mã nhân viên" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="SO_THE" runat="server" CssClass="css_form" Width="220px"
                                                        kieu_chu="True" kt_xoa="G" ten="Mã nhân viên" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_cc_phep_dieuchinh_P_KTRA('SO_THE')"/>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label12" runat="server" CssClass="css_gchu" Text="Chức danh" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="ten_cdanh" runat="server" CssClass="css_form" kieu_unicode="True"
                                                        kt_xoa="X" Width="220px" ten="Chức danh" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Text="Tên nhân viên" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="ho_ten" runat="server" CssClass="css_form" kieu_unicode="True"
                                                        kt_xoa="X" Width="220px" ten="Tên nhân viên" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Text="Phòng" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="ten_phong" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" Width="220px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <div style="padding-top: 20px">
                                                        <asp:Label ID="Label4" Text="Điều chỉnh thâm niên" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="4">
                                                    <table cellpadding="1" cellspacing="1">
                                                        <tr>
                                                            <td align="left" style="width: 250px">
                                                                <asp:Label ID="Label5" runat="server" CssClass="css_gchu" Text="Số tháng không được tính thâm niên" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="thang_kttn" runat="server" CssClass="css_form_r" kieu_so="true" kt_xoa="X" Width="220px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 250px">
                                                                <asp:Label ID="Label6" runat="server" CssClass="css_gchu" Text="Tháng bắt đầu không được tính thâm niên" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd_kttn" runat="server" CssClass="css_form_c" kt_xoa="X" Width="220px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label7" runat="server" CssClass="css_gchu" Text="Lý do" />
                                                </td>
                                                <td align="left" colspan="3">
                                                    <Cthuvien:nd ID="lydo_kttn" runat="server" Multiline="true" CssClass="css_form" kt_xoa="G" Height="80px" Width="500px" ten="Lý do không tính thâm niên" ToolTip="Lý do không tính thâm niên" />
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="4">
                                                    <div style="padding-top: 20px">
                                                        <asp:Label ID="Label13" Text="Điều chỉnh phép" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>


                                            <tr>
                                                <td align="left" colspan="4">
                                                    <table cellpadding="1" cellspacing="1">
                                                        <tr>
                                                            <td align="left" style="width: 250px">
                                                                <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Text="Số phép điều chỉnh" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="phep_dieuchinh" runat="server" CssClass="css_form_r" kieu_so="true" kt_xoa="X" Width="220px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 250px">
                                                                <asp:Label ID="Label8" runat="server" CssClass="css_gchu" Text="Tháng điều chỉnh phép" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="thang_dieuchinh" runat="server" CssClass="css_form_c" kt_xoa="X" Width="220px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label9" runat="server" CssClass="css_gchu" Text="Lý do" />
                                                </td>
                                                <td align="left" colspan="3">
                                                    <Cthuvien:nd ID="lydo_dieuchinh" runat="server" Multiline="true" CssClass="css_form" kt_xoa="G" Height="80px" Width="500px" ten="Lý do điều chỉnh phép" ToolTip="Lý do điều chỉnh phép" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    <asp:Label ID="Label10" runat="server" CssClass="css_gchu" Text="Tháng gia hạn" />
                                                </td>
                                                <td align="left" colspan="2">
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="thang_giahan" runat="server" CssClass="css_form_c" kt_xoa="X" Width="220px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left">
                                        <table cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight">                                                        
                                                        <a href="#" onclick="return ns_cc_phep_dieuchinh_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline"></span>Nhập</a>
                                                        <a href="#" onclick="return ns_cc_phep_dieuchinh_P_MOI();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline"></span>Mới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_cc_phep_dieuchinh_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_cc_phep_dieuchinh_P_Export();form_P_LOI();"><i class="fa fa-tr2ash-o"></i><span class="txUnderline">X</span>uất Excel</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_cc_phep_dieuchinh_P_Mau();form_P_LOI();"><i class="fa fa-tras2h-o"></i><span class="txUnderline">F</span>ile mẫu</a>                                                        
                                                        <a href="#" class="bt bt-grey" onclick="return ns_cc_phep_dieuchinh_P_Import();form_P_LOI();"><i class="fa fa-tr2ash-o"></i><span class="txUnderline">I</span>mport</a>                                                        
                                                    </div>
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="nhap" runat="server" Width="70px" Text="File mẫu" OnServerClick="nhap_Click" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="xuat" runat="server" Width="70px" Text="Export" OnServerClick="xuat_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="X" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1100,760" />
</asp:Content>
