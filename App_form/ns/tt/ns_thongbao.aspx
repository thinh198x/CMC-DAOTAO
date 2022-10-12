<%@ Page Title="ns_thongbao" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_thongbao.aspx.cs" Inherits="f_ns_thongbao" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="/js/jquery.min.js"></script>
    <script type="text/javascript" src="/js/highcharts.js"></script>
    <script type="text/javascript" src="/js/highcharts-more.js"></script>

    <script type="text/javascript" src="/js/exporting.js"></script>

    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Tình hình nhân sự" />
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
    </table>
    <table id="UPa_ct" runat="server">
        <tr>
            <td>
                <table>
                    <tr align="left">
                        <td align="left">
                            <table>
                                <tr align="left">
                                    <Cthuvien:DR_nhap ID="loai" runat="server" Width="265px" CssClass="css_drop" onchange="return ns_thongbao_thongke();">
                                        <asp:ListItem Text="Thống kê hợp đồng" Value="HD" />
                                        <asp:ListItem Text="Thống kê giới tính" Value="GT" />
                                        <asp:ListItem Text="Trình độ học vấn" Value="HV" />
                                    </Cthuvien:DR_nhap>
                                </tr>
                            </table>
                            <table style="width: 700px; height: 250px;">
                                <tr id="thongbao_hd" runat="server">
                                    <td>
                                        <div id="container" style="width: 700px; height: 250px;" />
                                    </td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                    <tr align="left">
                        <td align="left">
                            <table>
                                <tr align="left">
                                    <Cthuvien:DR_nhap ID="loai_bd" runat="server" Width="265px" CssClass="css_drop" onchange="return ns_thongbao_biendong();">
                                        <asp:ListItem Text="Tình hình biến động nhân sự" Value="BD" />
                                        <asp:ListItem Text="Tổng số lao động tăng theo tháng" Value="TA" />
                                        <asp:ListItem Text="Tổng số lao động nghỉ việc theo tháng" Value="NV" />
                                        <asp:ListItem Text="Tổng số lao động theo tháng" Value="TS" />
                                    </Cthuvien:DR_nhap>
                                </tr>
                            </table>
                            <table style="width: 700px; height: 350px;">
                                <tr id="nhansu_bd" runat="server">
                                    <td>
                                        <div id="container_bd" style="min-width: 700px; height: 350px; margin: 0 auto" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table style="width: 600px; height: 650px; background-color: white;">
                    <tr align="left" valign="top">
                        <td colspan="2">
                            <b>Thống kê nhanh</b><hr />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="width: 50%;">
                            <table>
                                <tr>
                                    <td>
                                        <Cthuvien:roi ID="Roi1" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Tổng số nhân viên hiện tại: 232" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                                    </td>
                                </tr>
                                <tr></tr>
                                <tr>
                                    <td>
                                        <Cthuvien:roi ID="Roi2" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Nhân sự tuyển mới trong tháng: 12" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                                    </td>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:roi ID="Roi3" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Nhân sự nghỉ việc trong tháng: 5" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top" style="width: 50%;">
                            <table>
                                <tr>
                                    <td>
                                        <Cthuvien:roi ID="Roi4" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Nhân sự chuyển đi trong tháng: 0" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                                    </td>
                                </tr>
                                <tr></tr>
                                <tr>
                                    <td>
                                        <Cthuvien:roi ID="Roi5" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Nhân sự chuyển đến trong tháng: 1" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                                    </td>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:roi ID="Roi6" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Độ tuổi bình quân: 31" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr align="left" valign="top">
                        <td colspan="2">
                            <b>Nhắc việc</b><hr />
                        </td>
                    </tr>
                    <tr>
                        <td id="td_tb" align="left" valign="top" style="width: 50%;">
                            <table>
                                <tr>
                                    <td>
                                        <Cthuvien:roi ID="Lb_sn" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Số nhân viên sinh nhật trong tháng: 61" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                                    </td>
                                </tr>
                                <tr></tr>
                                <tr>
                                    <td>
                                        <Cthuvien:roi ID="Lb_hd" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="HD" dong="true" Text="Số nhân viên sắp đến hạn hợp đồng: 3 " />
                                    </td>
                                </tr>
                                <tr></tr>
                                <tr>
                                    <td>
                                        <Cthuvien:roi ID="Lb_hh" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="HH" dong="true" Text="Số nhân viên đã hết hạn hợp đồng: 0" />
                                    </td>
                                </tr>
                                <tr>

                                </tr>
                                 <tr>
                                    <td>
                                        <Cthuvien:roi ID="lb_ut" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Số nhân viên sinh nhật trong tháng: 61" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top" style="width: 50%;">
                            <table>
                               
                                <tr>
                                    <td>
                                        <Cthuvien:roi ID="Roi7" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Đơn nghỉ phép cần duyệt: 6" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                                    </td>
                                </tr>
                                <tr></tr>
                                <tr>
                                    <td>
                                        <Cthuvien:roi ID="Roi8" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Đơn làm thêm giờ cần duyệt: 3" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                                    </td>
                                </tr>
                                <tr>
                                </tr>
                                 <tr>
                                    <td>
                                        <Cthuvien:roi ID="Roi11" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Giải trình chấm công cần duyệt: 0" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                                    </td>
                                </tr>
                                <tr></tr>
                                <tr>
                                    <td>
                                        <Cthuvien:roi ID="Roi9" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Đề xuất tuyển dụng cần duyệt: 1" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                                    </td>
                                </tr>
                                <tr></tr>
                                <tr>
                                    <td>
                                        <Cthuvien:roi ID="Roi10" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Đề xuất đào tạo cần duyệt: 2" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
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
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1420,800" />
    </div>
    <div id="div_phu"></div>
    <Cthuvien:an ID="SN" Value="SN" runat="server" />
    <Cthuvien:an ID="HD" Value="HD" runat="server" />
    <Cthuvien:an ID="HH" Value="HH" runat="server" />
</asp:Content>
