<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_tl_tlap_nghiphep.aspx.cs" Inherits="f_ns_tl_tlap_nghiphep"
    Title="ns_tl_tlap_nghiphep" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="center" colspan="2">
                            <table cellpadding="1" width="100%" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Cài đặt thông số nghỉ phép" />
                                    </td>
                                    <td align="right">
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
                        <td class="form_right">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <table>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label4" runat="server" CssClass="css_gchu" Text="Thâm niên (Năm)" Width="100px" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:so ID="thamnien" runat="server" CssClass="css_form_c" kt_xoa="G" Width="50px" ten="Thâm niên" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label6" runat="server" CssClass="css_gchu_c" Text="Tăng thêm" Width="80px" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:so ID="ngaytang" runat="server" CssClass="css_form_c" kt_xoa="G" Width="50px" ten="Ngày tăng" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label7" runat="server" CssClass="css_gchu" Text="Ngày nghỉ" Width="70px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Text="Ngày tháng cài đặt lại dữ liệu nghỉ phép (dd/MM)" Width="290px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="ngaycd" runat="server" CssClass="css_form_c" kt_xoa="G" MaxLength="5"
                                                        onblur="ns_tl_tlap_nghiphep_P_KTRA('NGAYCD')" Width="100px" ten="Ngày tháng cài đặt lại dữ liệu nghỉ phép hàng năm" ToolTip="(Định dạng dd/MM) Ngày tháng cài đặt lại dữ liệu nghỉ phép hàng năm" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Text="Cho phép cộng dồn sang năm sau" Width="230px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:kieu ID="congdon" runat="server" CssClass="css_form_c" kt_xoa="X" ToolTip="K - Không, C - Có" Text="K" lke="K,C"
                                                        Width="50px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label5" runat="server" CssClass="css_gchu" Text="Mã chấm công nghỉ phép 1 ngày" Width="230px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="ma1ngay" ten="Mã chấm công nghỉ phép 1 ngày" runat="server" CssClass="css_form" kt_xoa="X" Width="100px"
                                                        f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" kieu_chu="true" onchange="ns_tl_tlap_nghiphep_P_KTRA('MA1NGAY')" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Text="Mã chấm công nghỉ phép nửa ngày" Width="230px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="manuangay" ten="Mã chấm công nghỉ phép nửa ngày" runat="server" CssClass="css_form" kt_xoa="X" Width="100px"
                                                        f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" kieu_chu="true" onchange="ns_tl_tlap_nghiphep_P_KTRA('MANUANGAY')" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label8" runat="server" CssClass="css_gchu" Text="Áp dụng tính phép cho nhân viên theo" Width="230px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_nhap ID="ngaybdphep" ten="Ngày bắt đầu tính phép" runat="server" CssClass="css_form" kt_xoa="X" Width="150px">
                                                        <asp:ListItem Text="Ngày vào đơn vị" Value="NV" />
                                                        <asp:ListItem Text="Ngày biên chế" Value="BC" />
                                                        <asp:ListItem Text="Ngày chính thức" Value="CT" />
                                                        <asp:ListItem Text="Ngày vào ngành" Value="VN" />
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="padding-left: 56px">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center">
                                                    <div class="box3 txRight2">
                                                        <a href="#" onclick="return ns_tl_tlap_nghiphep_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i>Nhập</a>
                                                        <a href="#" onclick="return ns_tl_tlap_nghiphep_P_XOA();form_P_LOI();" class="bt bt-grey"><i class="fa fa-trash-o"></i>Xóa</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" class="bt bt-grey">Mới</a>
                                                    </div>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="550,420" />
    </div>
</asp:Content>
