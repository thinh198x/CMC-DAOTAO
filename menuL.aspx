<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menuL.aspx.cs" Inherits="f_menuL"
    Title="menu" EnableEventValidation="false" MasterPageFile="~/menuNen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" EnableViewState="false">
    <div class="container">
        <!-- Container Header -->
        <div class="menu_bar menu_chung">
            <div class="b_left">
                <Cthuvien:luu ID="tenForm" runat="server" />
                <span><%--<a onclick="P_MENUBc(event,'1')" ftkhao="ed_dash.aspx"><img width="140px" height="30px" src="images/eDoc/menu/logo_cmc.png" /></a> --%></span>
            </div>
            <!-- Bar ngang -->
            <div id="divBar" class="menu_header b_left"></div>

            <div class="b_right menu_tlap">
                <span onclick="sh_usermenu()">
                    <img src="images/eDoc/menu/icon_usersetting.png" />
                </span>
                <div class="dropdown-usermenu" style="display: none;">
                    <b class="arrow_active"></b>
                    <ul>
                        <li>
                            <Cthuvien:DR_nhap ID="qly_dvi" runat="server" CssClass="css_nsd" Style="font-weight: 100; margin-left: 14px; width: 164px; height: 25px;" DataTextField="ten" DataValueField="ma" onchange="login_P_NH_DVI()" />
                        </li>
                        <li class="icon_thietlapht">
                            <span id="tlap" onclick="P_MENUBc(event,this.id)" loai="B" ftkhao="/App_form/khud/kh_tso.aspx">Thiết lập hệ thống</span>
                        </li>
                        <li class="icon_logout">
                            <span onclick="return menu_P_MENU('R');">Đăng xuất</span>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="switch_role b_right">
                <div class="menu_nsd">
                    <img src="images/eDoc/menu/icon_role.png" />
                    <span id="nsd" runat="server" class="css_nsd"></span>
                </div>
            </div>
            <div class="menu_tbao b_right">
                <div class="menu_iTbao" onclick="menu_tb()">
                    <img src="images/eDoc/menu/icon_notification.png" />
                     <div class="noti_bubble">
                        <span id="dem_thongbao" runat="server"></span>
                    </div>
                </div>
                <div id="divTbao" class="divTbao" style="display: none;">
                    <b class="arrow_active"></b>
                    <ul>
                        <li>
                            <Cthuvien:roi ID="Lb_sn" runat="server" CssClass="css_lket_dat" Width="350px" Font-Bold="true" Text="Danh sách sinh nhật trong tháng: 0" ForeColor="#0066ff" Font-Italic="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" />
                        </li>
                        <li>
                            <Cthuvien:roi ID="Lb_hd" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="HD" Text="Danh sách sắp đến hạn hợp đồng: 0 " />
                        </li>
                        <li>
                            <Cthuvien:roi ID="lb_hs" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="HS" Text="Danh sách hết hạn nộp hồ sơ" />
                        </li>
                        <li>
                            <Cthuvien:roi ID="lb_cchn" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="CCHN" Text="Danh sách đủ điều kiện thi CCHN" />
                        </li>
                        <li>
                            <Cthuvien:roi ID="lb_con" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="CON" Text="Danh sách con hết giảm trừ" />
                        </li>

                        <li style="display: none">
                            <Cthuvien:roi ID="Lb_hc" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="HC" Text="Số nhân viên sắp hết hạn hộ chiếu: " /></li>
                        <li style="display: none">
                            <Cthuvien:roi ID="Lb_cmt" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="CMT" Text="Hết hạn chứng minh thư" /></li>
                        <li style="display: none">
                            <Cthuvien:roi ID="lb_td" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="TD" Text="Bạn đang có yêu cầu TD " /></li>
                        <li style="display: none">
                            <Cthuvien:roi ID="Lb_qd" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="QD" Text="Hết hạn quyết định" /></li>
                        <li style="display: none">
                            <Cthuvien:roi ID="lb_vs" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="VS" Text="Hết hạn visa" /></li>

                    </ul>
                </div>
            </div>
        </div>
        <!-- Duong dan form dang mo2222 -->
        <div id="divDan" class="menu_dan" style="text-align: left;"></div>
        <div class="menu_chung">
            <!-- Bar doc -->
            <div id="divDoc" class="menu_doc"></div>
            <!-- Container SideBar -->
            <div id="divMenuM" class="menu_sidebarM">
                <div id="divMenu" class="menu_sidebar"></div>
            </div>
            <!-- Container Content -->
            <div id="VFChinh" class="menu_frame">
            </div>
        </div>
    </div>
    <Cthuvien:an ID="tm" runat="server" />
    <Cthuvien:an ID="ttmh" runat="server" />
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
