<%@ Page Title="ht_bd_ns" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ht_bd_ns.aspx.cs" Inherits="f_ht_bd_ns" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="/js/jquery.min.js"></script>
    <script type="text/javascript" src="/js/highcharts.js"></script>
    <script type="text/javascript" src="/js/highcharts-more.js"></script>

    <script type="text/javascript" src="/js/exporting.js"></script>

    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quản lý cảnh báo" />
                <img class="b_right" src="/images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="col_100 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <span class="standard_label b_left col_50">Cảnh báo</span>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <Cthuvien:roi ID="Lb_sn" runat="server" CssClass="css_lket_dat" Width="350px" Font-Bold="true" Text="Số nhân viên sinh nhật trong tháng: 61" ForeColor="#0066ff" Font-Italic="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" />
                        </div> 
                        <div class="b_left form-group iterm_form">
                            <Cthuvien:roi ID="Lb_hd" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="HD" Text="Số nhân viên sắp đến hạn hợp đồng: 3 " />
                        </div>
                        <div class="b_right form-group iterm_form">
                            <Cthuvien:roi ID="lb_hs" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="HS" Text="Hết hạn nộp hồ sơ" />
                        </div>                                    
                    </div>              
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form" style="display:none">
                           <Cthuvien:roi ID="Lb_hc" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="HC" Text="Số nhân viên sắp hết hạn hộ chiếu: " />
                        </div>
                        <div class="b_right form-group iterm_form"style="display:none">
                             <Cthuvien:roi ID="Lb_cmt" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="CMT" Text="Hết hạn chứng minh thư" />
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <Cthuvien:roi ID="lb_cchn" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="CCHN" Text="Danh sách đủ điều kiện thi CCHN" />
                        </div>
                        <div class="b_left form-group iterm_form">
                            <Cthuvien:roi ID="lb_con" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="CON" Text="Danh sách con hết giảm trừ" />
                        </div>
                        <div class="b_left form-group iterm_form" style="display:none">
                            <Cthuvien:roi ID="lb_td" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                            f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="TD" Text="Bạn đang có yêu cầu TD " />
                        </div>
                        <div class="b_left form-group iterm_form" style="display:none">
                            <Cthuvien:roi ID="Lb_qd" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="QD" Text="Hết hạn quyết định" />
                        </div>
                        <div class="b_right form-group iterm_form" style="display:none">
                            <Cthuvien:roi ID="lb_vs" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="VS" Text="Hết hạn visa" />
                        </div>                       
                    </div>
                    <div style="display: none;">
                        <div class="col_2_iterm width_common">
                            <span class="standard_label b_left col_50">Thống kê nhanh theo công ty</span>
                        </div>
                        <div class="col_3_iterm width_common">
                            <div class="b_left form-group iterm_form">
                                <Cthuvien:roi ID="lb_tong" runat="server" f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="TONG" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Tổng số nhân viên hiện tại: 232" ForeColor="#0066ff" Font-Italic="true" />
                            </div>
                            <div class="b_right form-group iterm_form">
                                <Cthuvien:roi ID="lb_tm" runat="server" f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="MOI" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Nhân sự tuyển mới trong tháng: 12" ForeColor="#0066ff" Font-Italic="true" />
                            </div>
                            <div class="b_left form-group iterm_form">
                                <Cthuvien:roi ID="lb_nghi" runat="server" f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="NGHI" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Nhân sự nghỉ việc trong tháng: 5" ForeColor="#0066ff" Font-Italic="true" />
                            </div>
                        </div>
                        <div class="col_3_iterm width_common">
                             <div class="b_left form-group iterm_form">
                                <Cthuvien:roi ID="ld_captrung" runat="server" CssClass="css_lket_dat" f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="CTRUNG" Width="290px" Font-Bold="true" Text="Số lượng nhân sự cấp trung:" ForeColor="#0066ff" Font-Italic="true" />
                            </div>
                            <div class="b_right form-group iterm_form">
                                <Cthuvien:roi ID="ld_caocap" runat="server" CssClass="css_lket_dat" f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="CCAO" Width="290px" Font-Bold="true" Text="Số lượng nhân sự cao cấp:" ForeColor="#0066ff" Font-Italic="true" />
                            </div>
                              <div class="b_right form-group iterm_form" style="display:none">
                                 <Cthuvien:roi ID="lb_chuyendi" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Nhân sự chuyển đi trong tháng: 0" ForeColor="#0066ff" Font-Italic="true"
                                                dong="true" />
                            </div>
                              <div class="b_right form-group iterm_form" style="display:none">
                                 <Cthuvien:roi ID="lb_chuyenden" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Nhân sự chuyển đến trong tháng: 1" ForeColor="#0066ff" Font-Italic="true"
                                               />
                            </div>
                            <div class="b_right form-group iterm_form">
                                <Cthuvien:roi ID="lb_bq" runat="server" CssClass="css_lket_dat" f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" Font-Bold="true" Text="Độ tuổi bình quân: 31" ForeColor="#0066ff" Font-Italic="true" />
                            </div>
                        </div>
                   
                        <div class="col_2_iterm width_common">
                            <span class="standard_label b_left col_50">Thống kê nhanh theo tập đoàn </span>
                        </div>
                        <div class="col_3_iterm width_common">
                            <div class="b_left form-group iterm_form">
                                <Cthuvien:roi ID="ld_tong_ns_td" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Tổng số nhân sự " ForeColor="#0066ff" Font-Italic="true"
                                    dong="true" />
                            </div>
                            <div class="b_right form-group iterm_form">
                                <Cthuvien:roi ID="ld_tong_ns_tm" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Tổng số nhân sự tăng mới " ForeColor="#0066ff" Font-Italic="true"
                                    dong="true" />
                            </div>
                             <div class="b_left form-group iterm_form">
                                <Cthuvien:roi ID="ld_tong_ns_nghiviec" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Nhân sự nghỉ việc trong tháng: 5" ForeColor="#0066ff" Font-Italic="true"
                                    dong="true" />
                            </div>
                        </div>

                        <div class="col_2_iterm width_common">
                       
                            <div class="b_left form-group iterm_form">
                                <Cthuvien:roi ID="ld_tong_nghi_tt" runat="server" CssClass="css_lket_dat" Width="390px" Font-Bold="true" Text="Nhân sự nghỉ việc trong tháng: 5" ForeColor="#0066ff" Font-Italic="true"
                                    dong="true" />
                            </div>
                             <div class="b_right form-group iterm_form" style="display:none">
                               <Cthuvien:roi ID="Roi1" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="HC" Text="Số nhân viên sắp hết hạn hộ chiếu: " />
                            </div>
                        </div>
                    </div>

                    <div class="col_100 inner">
                            <div class="b_left form-group iterm_form">
                                <Cthuvien:DR_nhap ID="loai_bd" runat="server" Width="320px" DataTextField="ten" DataValueField="ma" CssClass="css_drop"
                                    onchange="return ns_thongbao_biendong();">
                                    <asp:ListItem Text="Tổng số lao động tăng theo tháng" Value="TA" />
                                </Cthuvien:DR_nhap>
                            </div>
                            <div class="b_right form-group iterm_form">
                               <div id="nhansu_bd">
                                     <div id="container_bd" style="min-width: 1300px; height: 360px; margin: 0 auto" />
                               </div>
                            </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="An1" runat="server" Value="1340,540" />
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1370,800" />
    </div>
    <div id="div_phu"></div>
    <Cthuvien:an ID="SN" Value="SN" runat="server" />
    <Cthuvien:an ID="HD" Value="HD" runat="server" />
    <Cthuvien:an ID="TD" Value="TD" runat="server" />
    <Cthuvien:an ID="QD" Value="QD" runat="server" />
    <Cthuvien:an ID="HH" Value="HH" runat="server" />
    <Cthuvien:an ID="HS" Value="HS" runat="server" />
    <Cthuvien:an ID="CCHN" Value="CCHN" runat="server" />
    <Cthuvien:an ID="CON" Value="CON" runat="server" />
    <Cthuvien:an ID="TONG" Value="TONG" runat="server" />
    <Cthuvien:an ID="NGHI" Value="NGHI" runat="server" />
    <Cthuvien:an ID="MOI" Value="MOI" runat="server" />
    <Cthuvien:an ID="CTRUNG" Value="CTRUNG" runat="server" />
    <Cthuvien:an ID="CCAO" Value="CCAO" runat="server" />
    <Cthuvien:an ID="BINHQUAN" Value="BINHQUAN" runat="server" />
</asp:Content>
