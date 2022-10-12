<%@ Page Title="ns_dt_ngv_dg_kdt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_ngv_dg_kdt.aspx.cs" Inherits="f_ns_dt_ngv_dg_kdt" %>

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
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Đánh giá khóa đào tạo" />
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
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="12" cotAn="nsd,so_id" hamRow="ns_dt_ngv_dg_kdt_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="40px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="Tháng" DataField="thang" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Khóa đào tạo" DataField="ten" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Lớp đào tạo" DataField="lop" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField DataField="nsd" />
                                                <asp:BoundField DataField="so_id" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_dt_ngv_dg_kdt_P_LKE()" />
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
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Năm" Width="115px" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td style="width: 143px">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="NAM" ten="Năm" runat="server" CssClass="css_form"
                                                                    Width="160px" kt_xoa="X" kieu_so="true" MaxLength="4" ToolTip="Năm" />
                                                            </td>
                                                            <td style="padding-left: 10px">
                                                                <asp:Label ID="Bbuoc2" runat="server" Text="Tháng" Width="110px" CssClass="css_gchu_c"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <%--<Cthuvien:so ID="thang" ten="Tháng" runat="server" kieu_chu="true" CssClass="css_form"
                                                                    Width="160px" kt_xoa="X" MaxLength="30" />--%>
                                                                <Cthuvien:DR_lke ID="THANG" ten="Tháng" ktra="DT_THANG" kt_xoa="X" runat="server" Width="154px" ToolTip="Tháng"></Cthuvien:DR_lke>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label13" runat="server" Text="Tên khóa học" Width="115px" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td style="width: 143px">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="TEN" ten="Tên khóa đào tạo" runat="server" CssClass="css_form" Width="160px" kt_xoa="X" ToolTip="Tên khóa đào tạo" />
                                                            </td>
                                                            <td style="padding-left: 10px">
                                                                <Cthuvien:bbuoc ID="Label22" runat="server" Text="Lớp đào tạo" Width="110px" CssClass="css_gchu_c"></Cthuvien:bbuoc>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="lop" ten="Lớp đào tạo" ToolTip="Lớp đào tạo" runat="server" kieu_chu="true" CssClass="css_form"
                                                                    Width="160px" kt_xoa="X" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="Giảng viên" Width="115px" CssClass="css_gchu" />
                                                </td>
                                                <td style="width: 143px">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="gv" ten="Thời lượng đào tạo" runat="server" CssClass="css_form"
                                                                    Width="160px" kt_xoa="X" />
                                                            </td>
                                                            <td style="padding-left: 10px">
                                                                <asp:Label ID="Label8" runat="server" Text="Ngày học" Width="110px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay" ten="Ngày" runat="server" CssClass="css_form"
                                                                    Width="160px" kt_xoa="X" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Điểm thích của k.học" Width="115px" CssClass="css_gchu" />
                                                </td>
                                                <td style="width: 452px;">
                                                    <Cthuvien:ma ID="diemthich" ten="Điểm thích của k.học" ToolTip="Điểm thích của k.học" runat="server" CssClass="css_form"
                                                        Width="452px" kt_xoa="X" />

                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label17" runat="server" Text="Điểm thấy k.học cần làm tốt" Width="115px" CssClass="css_gchu" />
                                                </td>
                                                <td style="width: 452px;">
                                                    <Cthuvien:ma ID="gop_y" ten="Điểm thấy k.học cần làm tốt" ToolTip="Điểm thấy k.học cần làm tốt" runat="server" CssClass="css_form"
                                                        Width="452px" kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <div style="padding-top: 10px">
                                            <asp:Label ID="Label12" Text="Đánh giá chi tiết" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                            <hr width="100%" />
                                        </div>
                                        <table cellpadding="1" cellspacing="1" border="1">
                                            <thead>
                                                <tr>
                                                    <td style="background-color: #d5ddea; width: 120px;" align="center">
                                                        <asp:Label ID="Label3" runat="server" Text="Tiêu chí" CssClass="css_Gma_c" />
                                                    </td>
                                                    <td style="background-color: #d5ddea" align="center">
                                                        <asp:Label ID="Label4" runat="server" Text="Điền trung bình đánh gái" CssClass="css_Gma_c" />
                                                    </td>
                                                    <td style="background-color: #d5ddea" align="center">
                                                        <asp:Label ID="Label5" runat="server" Text="Nhận xét chung" CssClass="css_Gma_c" />
                                                    </td>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td style="width: 120px">
                                                        <asp:Label ID="abc" runat="server" Text="Nội dung đào tạo" BorderStyle="None" />
                                                    </td>
                                                    <td>
                                                        <Cthuvien:ma ID="nd_dg" runat="server" Width="218px" BorderStyle="None" />
                                                    </td>
                                                    <td>
                                                        <Cthuvien:ma ID="nd_nx" runat="server" Width="218px" BorderStyle="None" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td style="width: 120px">
                                                        <asp:Label ID="Label1" runat="server" Text="Giảng viên" BorderStyle="None" />
                                                    </td>
                                                    <td>
                                                        <Cthuvien:ma ID="gv_dg" runat="server" Width="218px" BorderStyle="None" />
                                                    </td>
                                                    <td>
                                                        <Cthuvien:ma ID="gv_nx" runat="server" Width="218px" BorderStyle="None" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td style="width: 120px">
                                                        <asp:Label ID="Label2" runat="server" Text="Công tác tổ chức" BorderStyle="None" />
                                                    </td>
                                                    <td>
                                                        <Cthuvien:ma ID="tc_dg" runat="server" Width="218px" BorderStyle="None" />
                                                    </td>
                                                    <td>
                                                        <Cthuvien:ma ID="tc_nx" runat="server" Width="218px" BorderStyle="None" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top: 5px;">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td style="padding-top: 20px">
                                                    <div class="box3 txRight2" style="width: 400px;">
                                                        <a href="#" onclick="return ns_dt_ngv_dg_kdt_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i>Nhập</a>
                                                        <a href="#" onclick="return ns_dt_ngv_dg_kdt_P_MOI();form_P_LOI();" class="bt bt-grey"><i class="fa fa-moi"></i>Mới</a>
                                                        <a href="#" onclick="return ns_dt_ngv_dg_kdt_P_XOA();form_P_LOI();" class="bt bt-grey"><i class="fa fa-trash-o"></i>Xóa</a>
                                                        <a href="#" onclick="return ns_dt_ngv_dg_kdt_P_IN();form_P_LOI();" class="bt bt-grey"><i class="fa fa-moi"></i>Xuất Excel</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON('MA,TEN,thoiluong,noidung');form_P_LOI();" class="bt bt-grey"><i class="fa fa-moi"></i>Chọn</a>
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
