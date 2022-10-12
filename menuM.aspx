<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menuM.aspx.cs" Inherits="f_menuM"
    Title="menu" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" EnableViewState="false">
    <table width="100%">
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center" colspan="2" width="100%" style="height: 40px">
                            <table cellpadding="1" width="100%" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" />
                                    </td>
                                    <td align="right">
                                        <div class="acc">
                                            <ul>
                                                <li><a href="#" onclick="return form_dong();"><i class="fa fa-sign-out"></i></a></li>
                                                <li><a href="#" onclick="return form_GOP();"><i class="fa fa-envelope-o"></i></a></li>
                                                <li><a href="#" onclick="return form_HELP();"><i class="fa fa-question"></i></a></li>
                                                <%--CssClass="css_drop" --%>
                                                <li class="vline"></li>
                                                <li><i class="fa fa-user blue maR5"></i><span class="sz12">
                                                    <Cthuvien:DR_nhap ID="qly_dvi" runat="server" CssClass="css_nsd" Style="font-weight: 100;"
                                                        DataTextField="ten" DataValueField="ma" onchange="login_P_NH_DVI()" /></span></li>
                                                <li><i class="fa fa-user blue maR5"></i><span class="sz12">
                                                    <Cthuvien:luu ID="nsd" runat="server" Text="" CssClass="css_nsd" Style="font-weight: 100;" dich="K" /></span></li>
                                            </ul>
                                            <div class="clear"></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <table id="UPa_menu" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <img id="Img3" runat="server" alt="" src="~/images/menu/cehrM.png" />
                                    </td>
                                    <td style="width: 237px"></td>
                                    <td>
                                        <div class="topmn">
                                            <div class="bg-blue">
                                                <a href="#" id="MENUQL" onclick="return menu_P_MENU('L');">
                                                    <div><i class="fa fa-users"></i></div>
                                                    <div style="font-size: 14px">Quản lý</div>
                                                </a>
                                            </div>
                                            <div class="bg-green">
                                                <a href="#" id="MENUTT" onclick="return menu_P_MENU('C');" class="active">
                                                    <div><i class="fa fa-user-secret"></i></div>
                                                    <div style="font-size: 14px">Thông tin</div>
                                                </a>
                                            </div>
                                            <div class="bg-pink">
                                                <a href="#" id="MENUCN" onclick="return menu_P_MENU('N');">
                                                    <div><i class="fa fa-user"></i></div>
                                                    <div style="font-size: 14px">Cá nhân</div>
                                                </a>
                                            </div>
                                            <div class="bg-yellow">
                                                <a href="#" id="MENUBC" onclick="return menu_P_MENU('B');">
                                                    <div><i class="fa fa-desktop"></i></div>
                                                    <div style="font-size: 14px">Báo cáo</div>
                                                </a>
                                            </div>
                                            <div class="bg-grey">
                                                <a href="#" onclick="return menu_P_TSO();">
                                                    <div><i class="fa fa-cog"></i></div>
                                                    <div style="font-size: 14px">Thiết lập</div>
                                                </a>
                                            </div>
                                        </div>
                                    </td>

                                    <%--                                        <td style="width: 76px;" /> 
                                        <td id="td_ld" class="css_Mld" onclick="return menu_P_MENU('L');">
                                            <asp:Label ID="Label5" runat="server" Style="padding-left: 3px;" Text="QUẢN LÝ" />
                                        </td>
                                        <td style="width: 15px;" />
                                        <td id="td_ct" class="css_MctAc" onclick="return menu_P_MENU('C');">
                                            <asp:Label ID="Label1" runat="server" Style="padding-left: 3px;" Text="THÔNG TIN" />
                                        </td>
                                        <td style="width: 15px;" />
                                        <td id="td_nv" class="css_Mnv" onclick="return menu_P_MENU('N');">
                                            <asp:Label ID="Label6" runat="server" Text="CÁ NHÂN" />
                                        </td>
                                        <td style="width: 15px;" />
                                        <td id="td_bc" class="css_Mbc" onclick="return menu_P_MENU('B');">
                                            <asp:Label ID="Label2" runat="server" Text="BÁO CÁO" />
                                        </td>
                                        <td style="width: 15px;" />
                                        <td class="css_Mra" onclick="return menu_P_MENU('R');">
                                            <asp:Label ID="Label3" runat="server" Text="THOÁT" />
                                        </td>--%>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-top: 15px">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="css_Mgiua">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td id="td_goc" style="padding-top: 5px;"></td>
                                                <td valign="top" style="padding-left: 40px; padding-top: 5px;" onclick="return menu_P_DUX('','D');">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:luu ID="lblnvu" runat="server" Style="color: #0E76BC; font-size: 16px;" Text="NGHIỆP VỤ THƯỜNG DÙNG" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td id="td_dung"></td>
                                                        </tr>
                                                        <tr>
                                                            <td id="td_tb" style="display: none">
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:roi ID="Lb_sn" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" Text="Số nhân viên sinh nhật trong tháng: " ForeColor="#0066ff" Font-Italic="true"
                                                                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="SN" dong="true" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:roi ID="Lb_hd" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                                                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="HD" dong="true" Text="Số nhân viên sắp đến hạn hợp đồng: " />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:roi ID="Lb_hc" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                                                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="HC" dong="true" Text="Số nhân viên sắp hết hạn hộ chiếu: " />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:roi ID="Lb_cmt" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                                                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="CMT" dong="true" Text="Hết hạn chứng minh thư" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:roi ID="Lb_qd" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                                                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="QD" dong="true" Text="Hết hạn quyết định" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:roi ID="lb_vs" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                                                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="VS" dong="true" Text="Hết hạn visa" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:roi ID="ls_td" runat="server" CssClass="css_lket_dat" Width="290px" Font-Bold="true" ForeColor="#0066ff" Font-Italic="true"
                                                                                f_tkhao="~/App_form/ns/tt/ns_menu_tbao_ct.aspx" gui="TD" dong="true" Text="Bạn đang có yêu cầu TD " />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="css_Mday"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="div_phu"></div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="0,0" />
    <Cthuvien:an ID="tm" runat="server" />
    <Cthuvien:an ID="SN" Value="SN" runat="server" />
    <Cthuvien:an ID="HD" Value="HD" runat="server" />
    <Cthuvien:an ID="HC" Value="HC" runat="server" />
    <Cthuvien:an ID="CMT" Value="CMT" runat="server" />
    <Cthuvien:an ID="QD" Value="QD" runat="server" />
    <Cthuvien:an ID="VS" Value="VS" runat="server" />
    <Cthuvien:an ID="HH" Value="HH" runat="server" />
    <Cthuvien:an ID="TD" Value="TD" runat="server" />
</asp:Content>
