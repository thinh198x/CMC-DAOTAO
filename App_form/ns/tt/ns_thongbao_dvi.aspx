<%@ Page Title="ns_thongbao_dvi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_thongbao_dvi.aspx.cs" Inherits="f_ns_thongbao_dvi" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../../js/highcharts.js"></script>
    <script type="text/javascript" src="../../../js/highcharts-more.js"></script>

    <script type="text/javascript" src="../../../js/exporting.js"></script>
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thống kê % nhân sự của DataPost" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_ct">
                    <div>
                        <div class="input-group">
                            <Cthuvien:DR_nhap Style="display: none" ID="loai" runat="server" Width="265px" CssClass="css_drop" onchange="return ns_thongbao_dvi_thongke();">
                                <asp:ListItem Text="Thống kê % nhân sự các công ty" Value="HD" />
                                <asp:ListItem Text="Thống kê giới tính" Value="GT" />
                            </Cthuvien:DR_nhap>
                        </div>
                        <div id="thongbao_hd" runat="server">
                            <div id="container" style="min-width: 1300px; height: 670px; margin: 0 auto" />
                        </div>
                    </div>

                    <div style="display: none">
                        <div>
                            <span class="standard_label b_left col_50">Nhắc việc</span>
                            <div class="input-group">
                                <Cthuvien:roi ID="Lb_sn" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Số nhân viên sinh nhật trong tháng: 61" ForeColor="#0066ff" Font-Italic="true"
                                    f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />

                            </div>
                            <div class="input-group">
                                <Cthuvien:roi ID="Lb_hd" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                    f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="HD" dong="true" Text="Số nhân viên sắp đến hạn hợp đồng: 3 " />
                            </div>
                            <div class="input-group">
                                <Cthuvien:roi ID="Lb_hc" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                    f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="HC" dong="true" Text="Số nhân viên sắp hết hạn hộ chiếu: " />
                            </div>
                            <div class="input-group">
                                <Cthuvien:roi ID="Lb_cmt" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                    f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="CMT" dong="true" Text="Hết hạn chứng minh thư" />
                            </div>
                            <div class="input-group">
                                <Cthuvien:roi ID="Lb_qd" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                    f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="QD" dong="true" Text="Hết hạn quyết định" />
                            </div>
                            <div class="input-group">
                                <Cthuvien:roi ID="lb_vs" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                    f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="VS" dong="true" Text="Hết hạn visa" />
                            </div>
                            <div class="input-group">
                                <Cthuvien:roi ID="ls_td" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                    f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="TD" dong="true" Text="Bạn đang có yêu cầu TD " />
                            </div>
                        </div>
                        <div>
                            <span class="standard_label b_left col_50">Thống kê nhanh</span>
                            <div class="input-group">
                                <Cthuvien:roi ID="lb_tong" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Tổng số nhân viên hiện tại: 232" ForeColor="#0066ff" Font-Italic="true"
                                    f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                            </div>
                            <div class="input-group">
                                <Cthuvien:roi ID="lb_tm" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Nhân sự tuyển mới trong tháng: 12" ForeColor="#0066ff" Font-Italic="true"
                                    f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                            </div>
                            <div class="input-group">
                                <Cthuvien:roi ID="lb_nghi" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Nhân sự nghỉ việc trong tháng: 5" ForeColor="#0066ff" Font-Italic="true"
                                    f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                            </div>
                            <div class="input-group">
                                <Cthuvien:roi ID="lb_chuyendi" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Nhân sự chuyển đi trong tháng: 0" ForeColor="#0066ff" Font-Italic="true"
                                    f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                            </div>
                            <div class="input-group">
                                <Cthuvien:roi ID="lb_chuyenden" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Nhân sự chuyển đến trong tháng: 1" ForeColor="#0066ff" Font-Italic="true"
                                    f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                            </div>
                            <div class="input-group">
                                <Cthuvien:roi ID="lb_bq" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Độ tuổi bình quân: 31" ForeColor="#0066ff" Font-Italic="true"
                                    f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                            </div>
                        </div>
                    </div>
                    <div style="display: none">
                        <div style="width: 600px; overflow-x: scroll">
                            <div class="input-group">
                                <Cthuvien:DR_nhap ID="loai_bd" runat="server" Width="300px" DataTextField="ten" DataValueField="ma" CssClass="css_drop"
                                    onchange="return ns_thongbao_dvi_biendong();">
                                    <%-- <asp:ListItem Text="Tình hình biến động nhân sự" Value="BD" />--%>
                                    <asp:ListItem Text="Tổng số lao động tăng theo tháng" Value="TA" />
                                    <%-- <asp:ListItem Text="Tổng số lao động nghỉ việc theo tháng" Value="NV" />
                                        <asp:ListItem Text="Tổng số lao động theo tháng" Value="TS" />--%>
                                </Cthuvien:DR_nhap>
                            </div>

                            <div id="nhansu_bd" runat="server">
                                <div id="container_bd" style="min-width: 1300px; height: 450px; margin: 0 auto" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1290,860" />
    </div>
    <div id="div_phu"></div>
    <Cthuvien:an ID="SN" Value="SN" runat="server" />
    <Cthuvien:an ID="HD" Value="HD" runat="server" />
    <Cthuvien:an ID="HH" Value="HH" runat="server" />
</asp:Content>
