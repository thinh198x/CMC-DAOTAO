<%@ Page Title="ns_dt_qldl" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_qldl.aspx.cs" Inherits="f_ns_dt_qldl" %>

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
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Quản lý dữ liệu đào tạo" />
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
                        <td align="left" valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <table id="UPa_tk" border="0" cellpadding="1" cellspacing="1">
                                            <tr style="padding-bottom: 15px">
                                                <td>
                                                    <asp:Label ID="Bbuoc3" runat="server" Text="Tên khóa học" Width="80px" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ten_kh_tk" ten="Tên khóa đào tạo" runat="server" CssClass="css_form" Width="160px" kt_xoa="G" ToolTip="Tên khóa đào tạo" placeholder="Nhấn (F1)"
                                                        f_tkhao="~/App_form/ns/dt/dm/ns_dt_ma_kdtao.aspx" BackColor="#f6f7f7" ReadOnly="true" />
                                                    <div style="display: none">
                                                        <Cthuvien:ma ID="ma_kh_tk" ten="Mã khóa đào tạo" runat="server" CssClass="css_form" Width="160px" kt_xoa="X" ToolTip="Tên khóa đào tạo" />
                                                    </div>

                                                </td>
                                                <td>
                                                    <a href="#" onclick="return ns_dt_qldl_P_LKE();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">T</span>ìm kiếm</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="12" cotAn="nsd,so_id" hamRow="ns_dt_qldl_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Tên khóa học" DataField="ten_kh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Tên hồ sơ" DataField="ten_hs" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Mã biểu mẫu" DataField="ma_bm" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Thời hạn l.trữ" DataField="thoihan" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField DataField="so_id" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_dt_qldl_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" class="form_right">
                            <table id="UPa_ct" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left" style="padding-top: 27px">
                                        <table runat="Server" cellpadding="1" cellspacing="1">

                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label13" runat="server" Text="Tên khóa học" Width="115px" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td style="width: 143px">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="TEN_KH" ten="Tên khóa đào tạo" runat="server" CssClass="css_form" Width="160px" kt_xoa="G" ToolTip="Tên khóa đào tạo" placeholder="Nhấn (F1)"
                                                                    f_tkhao="~/App_form/ns/dt/dm/ns_dt_ma_kdtao.aspx" BackColor="#f6f7f7" ReadOnly="true" />
                                                                <div style="display: none">
                                                                    <Cthuvien:ma ID="ma_kh" ten="Mã khóa đào tạo" runat="server" CssClass="css_form" Width="160px" kt_xoa="X" ToolTip="Tên khóa đào tạo" />
                                                                </div>
                                                            </td>
                                                            <td style="padding-left: 10px">
                                                                <asp:Label ID="Label22" runat="server" Text="Tên hồ sơ" Width="110px" CssClass="css_gchu_c"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="ten_hs" ten="Tên hồ sơ" ToolTip="Tên hồ sơ" runat="server" CssClass="css_form"
                                                                    Width="160px" kt_xoa="X" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="Mã biểu mẫu" Width="115px" CssClass="css_gchu" />
                                                </td>
                                                <td style="width: 143px">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="ma_bm" ten="Mã biểu mẫu" runat="server" CssClass="css_form" Width="160px" kt_xoa="X" />
                                                            </td>
                                                            <td style="padding-left: 10px">
                                                                <asp:Label ID="Label8" runat="server" Text="Hình thức lưu trữ" Width="110px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="hinhthuc" ten="Hình thức lưu trữ" runat="server" CssClass="css_form" Width="160px" kt_xoa="X" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Thời hạn lưu trữ" Width="115px" CssClass="css_gchu" />
                                                </td>
                                                <td style="width: 143px">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="thoihan" ten="Thời hạn lưu trữ" runat="server" CssClass="css_form" Width="160px" kt_xoa="X" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label17" runat="server" Text="Mức độ quan trọng" Width="115px" CssClass="css_gchu" />
                                                </td>
                                                <td style="width: 452px;">
                                                    <Cthuvien:ma ID="md_qtrong" ten="Mức độ quan trọng" ToolTip="Mức độ quan trọng" runat="server" CssClass="css_form"
                                                        Width="452px" kt_xoa="X" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="ghichu" Width="115px" CssClass="css_gchu" />
                                                </td>
                                                <td style="width: 452px;">
                                                    <Cthuvien:ma ID="ghichu" ten="Mức độ quan trọng" ToolTip="Mức độ quan trọng" runat="server" CssClass="css_form" Width="452px" kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top: 5px;">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td style="padding-top: 20px">
                                                    <div class="box3 txRight2" style="width: 400px;">
                                                        <a href="#" onclick="return ns_dt_qldl_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i>Nhập</a>
                                                        <a href="#" onclick="return ns_dt_qldl_P_MOI();form_P_LOI();" class="bt bt-grey"><i class="fa fa-moi"></i>Mới</a>
                                                        <a href="#" onclick="return ns_dt_qldl_P_XOA();form_P_LOI();" class="bt bt-grey"><i class="fa fa-trash-o"></i>Xóa</a>
                                                        <a href="#" onclick="return ns_dt_qldl_P_IN();form_P_LOI();" class="bt bt-grey"><i class="fa fa-moi"></i>Xuất Excel</a>
                                                        <%--<a href="#" onclick="return form_P_TRA_CHON('MA,TEN,thoiluong,noidung');form_P_LOI();" class="bt bt-grey"><i class="fa fa-moi"></i>Chọn</a>--%>
                                                    </div>
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
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
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1280,700" />
    </div>
</asp:Content>
