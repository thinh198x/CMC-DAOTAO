<%@ Page Title="ns_cb_qly" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cb_qly.aspx.cs" Inherits="f_ns_cb_qly" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_ttt.ascx" TagName="khud_ttt" TagPrefix="khud_ttt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%" style="background-color: #f4f6f8">
        <tr>
            <td align="left">
                <table cellpadding="0" cellspacing="0" style="padding-left: 10px">
                    <tr>
                        <td align="left" colspan="2">
                            <Cthuvien:luu ID="Luu2" runat="server" CssClass="css_tieudeM" Text="Hồ sơ nhân viên" />
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
                                                <li style="display: none"><a>
                                                    <Cthuvien:dao ID="klk" runat="server" CssClass="css_kh_de_da" Width="85px"
                                                        ForeColor="#D5E0E3" lke="Hoạt động,Thôi việc" Text="Hoạt động"
                                                        ToolTip="Liệt kê theo tình trạng: Đang hoạt động, Đã thôi việc (Click để thay đổi)" AutoPostBack="true" /></a></li>

                                                <div class="clear"></div>
                                            </ul>
                                            <div class="clear"></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <table id="NPa" runat="server" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:tab ID="NPa_ch" runat="server" ham="ns_cb_active_tab();" CssClass="css_tab_doc_ac" Width="25px" Height="99px" hinh="/images/ns/timkiem.png" />
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:tab ID="NPa_kh" runat="server" CssClass="css_tab_doc_de" Width="25px" Height="120px" hinh="/images/ns/thongtinkhac.png" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" class="form_left" valign="top" style="padding-top: 20px;">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div id="first-tab-group">
                                            <div class="box3" id="search">
                                                <asp:Panel ID="Pa_ch" runat="server" Style="width: 365px; height: 510px; display: block;">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr style="display: none;">
                                                            <td>
                                                                <table id="Upa_tk" style="line-height: 20px; padding-left: 10px;" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label11" runat="server" Width="70px" Text="Trạng thái" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td style="padding-bottom: 2px">
                                                                            <table cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <Cthuvien:DR_nhap ID="dr_trangthai" onchange="ns_cb_P_KTRA('PHONG_TK')" ten="Trạng thái làm việc" runat="server"
                                                                                            CssClass="css_form" kieu="S" Width="230px">
                                                                                            <asp:ListItem Selected="True" Text="Làm việc" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="Nghỉ việc" Value="1"></asp:ListItem>
                                                                                        </Cthuvien:DR_nhap>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label20" runat="server" Width="70px" Text="Phòng" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td style="padding-bottom: 2px">
                                                                            <table cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <Cthuvien:DR_nhap ID="phong_tk" ten="Phòng" runat="server" DataTextField="ten" DataValueField="ma"
                                                                                            CssClass="css_form" kieu="S" Width="230px" onchange="ns_cb_P_KTRA('PHONG_TK')" f_tkhao="~/App_form/ht/ht_maph.aspx" />
                                                                                    </td>
                                                                                    <td style="width: 20px;" align="center" valign="middle">
                                                                                        <div class="div-table-collum" style="width: 40px; padding-left: 5px;"><a href="#" onclick="return ns_cb_phong('phong');" class="bt bt-grey"><i class="fa fa-list maR0"></i></a></div>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label26" runat="server" Width="70px" Text="Mã CB" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td style="padding-bottom: 2px">
                                                                            <Cthuvien:ma ID="so_the_tk" ten="Mã CB tìm kiếm" runat="server" kt_xoa="K" CssClass="css_form" kieu_chu="true" Width="200px" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label25" runat="server" Width="70px" Text="Họ và Tên" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:ma ID="ten_tk" ten="Tên tìm kiếm" runat="server" kt_xoa="X" CssClass="css_form" kieu_unicode="true" Width="200px" />

                                                                        </td>
                                                                    </tr>
                                                                    <tr style="padding-top: 5px">
                                                                        <td></td>
                                                                        <td style="padding-top: 5px; padding-bottom: 5px">
                                                                            <a href="#" onclick="return ns_cb_TIMKIEM();form_P_LOI();" class="bt bt-grey"><i class="fa fa-search"></i>Tìm kiếm</a>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                    CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,iurl" hamRow="ns_cb_GR_lke_RowChange()">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                        <asp:BoundField HeaderText="T.tự" DataField="sott" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Số Thẻ" DataField="so_the" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Họ Tên" DataField="ten" HeaderStyle-Width="179px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Số id" DataField="so_id" />
                                                                        <asp:BoundField HeaderText="anh the" DataField="iurl" />
                                                                    </Columns>
                                                                </Cthuvien:GridX>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td id="GR_lke_td" runat="server" align="center" style="padding-right: 10px;">
                                                                <khud_slide:khud_slide ID="GR_lke_slide" runat="server" rong="280" loai="X" gridId="GR_lke" ham="ns_cb_TIMKIEM()" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </div>
                                            <div class="box3" id="thongtinkhac">
                                                <asp:Panel ID="Pa_kh" runat="server" Style="width: 350px; height: 510px; padding-left: 15px; display: none;">
                                                    <ul class="tabContent-list">

                                                        <li>Thông tin</li>
                                                        <ul class="tabContent-list2">

                                                            <li><a id="ns_ls_ct_tct" href="#" onclick="ns_cb_activemenu('ns_ls_ct_tct')">
                                                                <Cthuvien:roi ID="Ls_tct" runat="server" Width="365px"
                                                                    f_tkhao="~/App_form/ns/ls/ns_ls_ct_tct.aspx" gui="SO_THE,TEN,PHONG,TEN_PHONG" dong="true" Text="Quá trình công tác trong công ty" /></a></li>
                                                            <li><a id="ns_lsct" href="#" onclick="ns_cb_activemenu('ns_lsct')">
                                                                <Cthuvien:roi ID="Ls_lsct" runat="server" Width="365px"
                                                                    f_tkhao="~/App_form/ns/ls/ns_lsct.aspx" gui="SO_THE,TEN,PHONG" dong="true" Text="Quá trình công tác trước khi vào công ty" /></a></li>
                                                            <li><a id="ns_hd" href="#" onclick="ns_cb_activemenu('ns_hd')">
                                                                <Cthuvien:roi ID="Lb_hd" runat="server" Width="365px"
                                                                    f_tkhao="~/App_form/ns/qt/ns_hd.aspx" gui="SO_THE,TEN,PHONG" dong="true" Text="Hợp đồng lao động" /></a></li>
                                                            <li><a id="ns_ktkl_kt" href="#" onclick="ns_cb_activemenu('ns_ktkl_kt')">
                                                                <Cthuvien:roi ID="Lb_kt" runat="server" Width="365px"
                                                                    f_tkhao="~/App_form/ns/ktkl/ns_ktkl_kt.aspx" gui="SO_THE,TEN,PHONG" dong="true" Text="Khen thưởng" /></a></li>
                                                            <li><a id="ns_ktkl_kl" href="#" onclick="ns_cb_activemenu('ns_ktkl_kl')">
                                                                <Cthuvien:roi ID="Lb_kl" runat="server" Width="365px"
                                                                    f_tkhao="~/App_form/ns/ktkl/ns_ktkl_kl.aspx" gui="SO_THE,TEN,PHONG" dong="true" Text="Kỷ luật" /></a></li>


                                                        </ul>
                                                    </ul>
                                                </asp:Panel>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" class="form_right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" runat="Server" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="css_border" style="width: 90px; height: 120px;">
                                                                <img id="iurl" runat="Server" alt=" ảnh thẻ" title="Anh the" src="~/images/no_image.png" style="width: 90px; height: 100px; float: right" />
                                                            </td>
                                                            <td style="height: 120px">
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <Cthuvien:bbuoc ID="Label9" runat="server" Width="70px" Text="Mã CB" CssClass="css_gchu_c" />
                                                                        </td>
                                                                        <td>
                                                                            <table cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <Cthuvien:ma ID="so_the" runat="server" CssClass="css_form" kieu_chu="True" kt_xoa="G"
                                                                                            ToolTip="Mã số cán bộ" Width="220px" ten="Số thẻ" onchange="ns_cb_P_KTRA('SO_THE')" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <Cthuvien:bbuoc ID="Label3" runat="server" Width="90px" Text="Họ và Tên" CssClass="css_gchu_c" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <Cthuvien:ma ID="TEN" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X"
                                                                                            Width="220px" ten="Họ và tên" onchange="ns_cb_P_KTRA('TEN')" />
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
                                                <td align="left">
                                                    <table id="TPu" runat="server" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:tab ID="TPu_syll" runat="server" CssClass="css_tab_ngang_ac" Width="120px"
                                                                    Height="23px" Text="Sơ yếu lý lịch" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="TPu_ttct" runat="server" CssClass="css_tab_ngang_de" Width="120px"
                                                                    Height="23px" Text="Thông tin công ty" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="TPu_ttnl" runat="server" CssClass="css_tab_ngang_de" Width="120px"
                                                                    Height="23px" Text="Thông tin năng lực" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="TPu_ttk" runat="server" CssClass="css_tab_ngang_de" Width="120px"
                                                                    Height="23px" Text="Thông tin khác" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="Pu_syll" runat="server" Style="display: block;" Height="430px" Width="800px">
                                                        <table runat="Server" cellspacing="0" cellpadding="0">
                                                            <tr style="display: none">
                                                                <td>
                                                                    <table cellpadding="1" cellspacing="1">
                                                                        <tr>
                                                                            <td>
                                                                                <table cellspacing="1">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label4" runat="server" Text="Tên hoa" CssClass="css_gchu" Width="70px" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <table cellspacing="0" cellpadding="0">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <Cthuvien:ma ID="TEN_HOA" runat="server" CssClass="css_form" kt_xoa="X" Width="200px"
                                                                                                            ten="Tên hoa" kieu_chu="True" BackColor="#f6f7f7" Enabled="False" ToolTip="Tên hoa không dấu" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="display: none">
                                                                                            <asp:Label ID="Label28" runat="server" CssClass="css_gchu" Width="50px" Text="Thứ tự" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <table cellspacing="0" cellpadding="0">
                                                                                                <tr>
                                                                                                    <td style="display: none">
                                                                                                        <Cthuvien:ma ID="tt" runat="server" CssClass="css_so" kieu_so="true" MaxLength="4"
                                                                                                            kt_xoa="X" Width="25px" ten="Thứ tự" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <Cthuvien:bbuoc ID="Bbuoc2" runat="server" Width="50px" Text="Phòng" CssClass="css_gchu" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <table cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <Cthuvien:DR_nhap ID="PHONG" ten="Phòng" runat="server" DataTextField="ten" DataValueField="ma"
                                                                                                            CssClass="css_form" Width="487px" f_tkhao="~/App_form/ht/ht_maph.aspx" />
                                                                                                    </td>
                                                                                                    <td style="width: 20px;" align="center" valign="middle">
                                                                                                        <div class="div-table-collum" style="width: 40px; padding-left: 5px;"><a href="#" onclick="return ns_cb_phong('phong');" class="bt bt-grey"><i class="fa fa-list maR0"></i></a></div>
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
                                                                <td align="left">
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td align="left" valign="top" class="tab_content">
                                                                                <table cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td class="css_border">
                                                                                            <table cellpadding="1" cellspacing="1" border="0">
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <Cthuvien:bbuoc ID="Label7" runat="server" Text="Giới tính" CssClass="css_gchu" Width="100px" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellpadding="0" cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <Cthuvien:DR_nhap ID="GTINH" ten="Giới tính" runat="server" CssClass="css_form"
                                                                                                                        Width="150px" DataTextField="ten" DataValueField="ma" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:bbuoc ID="Label15" runat="server" Text="N.sinh" Width="100px" CssClass="css_gchu_c" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <div class="ip-group date">
                                                                                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NSINH" ten="N.sinh" runat="server" CssClass="css_form_c"
                                                                                                                            Width="124px" kt_xoa="X" ToolTip="Năm sinh" />
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    <asp:Label ID="Bbuoc7" runat="server" Text="Đối tượng cư chú" CssClass="css_gchu_c" Width="100px" />
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    <Cthuvien:DR_nhap ID="dt_cutru" runat="server" CssClass="css_form" Width="150px"
                                                                                                                        DataTextField="ten" DataValueField="ma" ten="Đối tượng cư chú" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Label22" runat="server" Text="Mobile" Width="100px" CssClass="css_gchu" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellpadding="0" cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="dtdd" ten="ĐT.D.Động" kieu_so="true" runat="server" Width="150px" ToolTip="Số điện thoại di động"
                                                                                                                        CssClass="css_form" kt_xoa="X" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label5" runat="server" CssClass="css_gchu_c" Width="100px" Text="Email" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="email" ten="Email" runat="server" CssClass="css_form" kt_xoa="X" Width="150px"
                                                                                                                        Enabled="true" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label36" runat="server" CssClass="css_gchu_c" Width="100px" Text="Hôn nhân" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:DR_nhap ID="tt_honnhan" ten="Tình trạng hôn nhân" runat="server" DataTextField="ten" DataValueField="ma"
                                                                                                                        CssClass="css_form" Width="150px" f_tkhao="~/App_form/ns/ma/ns_ma_tt.aspx" ktra="ns_ma_tt,ma,ten" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <Cthuvien:bbuoc ID="Label12" runat="server" CssClass="css_gchu" Width="100px" Text="CMND" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="SOCMT" ten="Số CMND" kieu_so="true" ToolTip="Số chứng minh nhân dân" runat="server"
                                                                                                                        CssClass="css_form" kt_xoa="X" Width="149px" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label16" runat="server" CssClass="css_gchu_c" Width="95px" Text="Ngày cấp" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <div class="ip-group date">
                                                                                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_cmt" ten="Ngày cấp CMND" ToolTip="Ngày cấp CMND" runat="server"
                                                                                                                            CssClass="css_form_c" kt_xoa="X" Width="125px" />
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label17" runat="server" CssClass="css_gchu_c" Width="96px" Text="Nơi cấp" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="nc_cmt" placeholder="Nhấn (F1)" BackColor="#f6f7f7" ten="Nhập mã nơi cấp cmt" runat="server"
                                                                                                                        CssClass="css_form" Width="150px" f_tkhao="~/App_form/ns/ma/ns_ma_tt.aspx" ktra="ns_ma_tt,ma,ten" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Bbuoc1" runat="server" CssClass="css_gchu" Width="100px" Text="Ngày hết hạn CMT" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <div class="ip-group date">
                                                                                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_hh_cmt" ten="ngày hết hạn cmt" ToolTip="Ngày hết hạn cmt" runat="server"
                                                                                                                            CssClass="css_form_c" kt_xoa="X" Width="125px" />
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <Cthuvien:bbuoc ID="Label10" runat="server" Text="Quốc tịch" CssClass="css_gchu" Width="100px" /></td>
                                                                                                    <td>
                                                                                                        <table cellpadding="0" cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <Cthuvien:DR_nhap ID="NN" runat="server" CssClass="css_form" Width="150px"
                                                                                                                        DataTextField="ten" DataValueField="ma" ten="Mã nước" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Bbuoc4" runat="server" CssClass="css_gchu_c" Width="100px" Text="Dân tộc" /></td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="dantoc" placeholder="Nhấn (F1)" Width="150px" ten="Dân tộc" BackColor="#f6f7f7" runat="server" CssClass="css_form" f_tkhao="~/App_form/ns/ma/ns_ma_dt.aspx" ktra="ns_ma_dt,ma,ten" /></td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label35" runat="server" CssClass="css_gchu_c" Width="100px" Text="Tôn giáo" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="tongiao" placeholder="Nhấn (F1)" ten="Tôn giáo" runat="server" BackColor="#f6f7f7" CssClass="css_form" Width="150px" f_tkhao="~/App_form/ns/ma/ns_ma_tg.aspx" ktra="ns_ma_tg,ma,ten" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Label24" runat="server" CssClass="css_gchu" Width="100px" Text="Đ/c hiện tại" />
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <table cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="dchi" runat="server" kt_xoa="X" CssClass="css_form" Width="672px"
                                                                                                                        kieu_unicode="true" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Bbuoc6" runat="server" CssClass="css_gchu" Width="100px" Text="Tỉnh/Thành phố" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="tt_hientai" placeholder="Nhấn (F1)" runat="server" Width="150px" CssClass="css_form"
                                                                                                                        BackColor="#f6f7f7" kieu_chu="true" f_tkhao="~/App_form/ns/ma/ns_ma_tt.aspx"
                                                                                                                        kt_xoa="X" onchange="ns_hd_P_KTRA('TTHIENTAI')" ktra="ns_ma_tt,ma,ten" ToolTip="Tỉnh/Thành phố" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label37" runat="server" CssClass="css_gchu_c" Width="96px" Text="Quận/Huyện" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="qh_hientai" placeholder="Nhấn (F1)" runat="server" Width="150px" CssClass="css_form"
                                                                                                                        BackColor="#f6f7f7" kieu_chu="true" f_tkhao="~/App_form/ns/ma/ns_ma_qh.aspx" guiId="NN,tt_hientai"
                                                                                                                        kt_xoa="X" onchange="ns_hd_P_KTRA('QHHIENTAI')" ktra="ns_ma_qh,ma,ten" ToolTip="Quận/Huyện" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label38" runat="server" CssClass="css_gchu_c" Width="96px" Text="Xã/Phường" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="xp_hientai" placeholder="Nhấn (F1)" runat="server" Width="150px" CssClass="css_form"
                                                                                                                        BackColor="#f6f7f7" kieu_chu="true" f_tkhao="~/App_form/ns/ma/ns_ma_xp.aspx" guiId="NN,tt_hientai,qh_hientai"
                                                                                                                        kt_xoa="X" onchange="ns_hd_P_KTRA('XPHIENTAI')" ktra="ns_ma_xp,ma,ten" ToolTip="Xã/Phường" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Label30" runat="server" CssClass="css_gchu" Width="100px" Text="H.Khẩu t.trú" />
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <table cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="hkhau" runat="server" kt_xoa="X" CssClass="css_form" Width="672px"
                                                                                                                        kieu_unicode="true" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Label39" runat="server" CssClass="css_gchu" Width="100px" Text="Tỉnh/Thành phố" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="tt_thuongtru" placeholder="Nhấn (F1)" runat="server" Width="150px" CssClass="css_form"
                                                                                                                        BackColor="#f6f7f7" kieu_chu="true" f_tkhao="~/App_form/ns/ma/ns_ma_tt.aspx" guiId="NN"
                                                                                                                        kt_xoa="X" onchange="ns_hd_P_KTRA('TTTHUONGTRU')" ktra="ns_ma_tt,ma,ten" ToolTip="Tỉnh/Thành phố" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label13" runat="server" CssClass="css_gchu_c" Width="96px" Text="Quận/Huyện" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="qh_thuongtru" placeholder="Nhấn (F1)" runat="server" Width="150px" CssClass="css_form"
                                                                                                                        BackColor="#f6f7f7" kieu_chu="true" f_tkhao="~/App_form/ns/ma/ns_ma_qh.aspx" guiId="NN,tt_thuongtru"
                                                                                                                        kt_xoa="X" onchange="ns_hd_P_KTRA('QHTHUONGTRU')" ktra="ns_ma_qh,ma,ten" ToolTip="Quận/Huyện" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label42" runat="server" CssClass="css_gchu_c" Width="96px" Text="Xã/Phường" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="xp_thuongtru" placeholder="Nhấn (F1)" runat="server" Width="150px" CssClass="css_form"
                                                                                                                        BackColor="#f6f7f7" kieu_chu="true" f_tkhao="~/App_form/ns/ma/ns_ma_xp.aspx" guiId="NN,tt_thuongtru,qh_thuongtru"
                                                                                                                        kt_xoa="X" onchange="ns_hd_P_KTRA('XPTHUONGTRU')" ktra="ns_ma_xp,ma,ten" ToolTip="Xã/Phường" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Label18" runat="server" CssClass="css_gchu" Width="100px" Text="Khi cần liên lạc với ai" />
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <table cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <Cthuvien:nd ID="khican_ll" runat="server" kt_xoa="X" CssClass="css_form" Width="672px" Height="50px" Rows="3"
                                                                                                                        kieu_unicode="true" TextMode="MultiLine" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr style="display: none">
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Label31" runat="server" CssClass="css_gchu" Width="100px" Text="Ngày biên chế" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellpadding="0" cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <div class="ip-group date">
                                                                                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_bc" ten="Ngày biên chế" ToolTip="Ngày vào biên chế" runat="server"
                                                                                                                            CssClass="css_form" kt_xoa="X" Width="125px" />
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    <asp:Label ID="Label33" runat="server" CssClass="css_gchu_c" Width="100px" Text="N. vào ngành" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <div class="ip-group date">
                                                                                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_vn" ten="N. vào ngành" ToolTip="N. vào ngành" runat="server"
                                                                                                                            CssClass="css_form" kt_xoa="X" Width="123px" />
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="display: none">
                                                                                                    <td align="left" style="height: 29px">
                                                                                                        <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu" Width="100px" Text="Nhóm CD" />
                                                                                                    </td>
                                                                                                    <td style="height: 29px">
                                                                                                        <table cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="nhom_cd" placeholder="Nhấn (F1)" runat="server" Width="150px" CssClass="css_form" ten="Nhóm chức danh" nhap="true" kieu_chu="true"
                                                                                                                        kt_xoa="X" BackColor="#f6f7f7" f_tkhao="~/App_form/ns/ma/ns_ma_ncdanh.aspx" ktra="ns_ma_ncdanh,ma,ten"
                                                                                                                        onchange="ns_hd_P_KTRA('NCD')" disable="true" ToolTip="Nhóm chức danh " />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:bbuoc ID="Label6" runat="server" CssClass="css_gchu_c" Width="96px" Text="Chức danh" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="cdanh" placeholder="Nhấn (F1)" runat="server" Width="150px" ten="Chức danh" CssClass="css_form"
                                                                                                                        BackColor="#f6f7f7" disable="true" kieu_chu="true" f_tkhao="~/App_form/ns/ma/ns_ma_cdanh.aspx" guiId="nhom_cd"
                                                                                                                        kt_xoa="X" onchange="ns_hd_P_KTRA('cdanh')" ktra="ns_ma_cdanh,ma,ten" ToolTip="Chức danh" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label40" runat="server" CssClass="css_gchu_c" Width="96px" Text="Bậc CD" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="bac_cdanh" disable="true" placeholder="Nhấn (F1)" runat="server" CssClass="css_form" Width="150px" kt_xoa="X" kieu_chu="true"
                                                                                                                        f_tkhao="~/App_form/ns/ma/ns_ma_baccdanh.aspx" gchu="gchu" ktra="ns_ma_baccdanh_ct,ma,ma"
                                                                                                                        BackColor="#f6f7f7" onchange="ns_hd_P_KTRA('BCD')" ten="tên bậc chức danh công việc"
                                                                                                                        ToolTip="Bậc chức danh công việc" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="display: none">

                                                                                                    <td>
                                                                                                        <table cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td align="left">
                                                                                                                    <asp:Label ID="Label23" runat="server" CssClass="css_gchu_c" Width="96px" Text="ĐT Nhà riêng" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="dtnr" ten="Điện thoại nhà riêng" kieu_so="true" runat="server" ToolTip="Số điện thoại nhà riêng"
                                                                                                                        CssClass="css_form" kt_xoa="X" Width="150px" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="display: none">
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Label14" runat="server" CssClass="css_gchu" Width="104px" Text="H.thức trả lương" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellspacing="0" cellpadding="0">
                                                                                                            <tr>
                                                                                                                <td align="left">
                                                                                                                    <Cthuvien:DR_nhap ID="nhan" ten="Nhận tiền" runat="server" CssClass="css_form"
                                                                                                                        DataTextField="ten" DataValueField="ma" Width="150px" onchange="ns_cb_P_KTRA('nhan')" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="display: none">
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Label27" runat="server" CssClass="css_gchu" Width="100px" Text="Mã giới thiệu" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellpadding="0" cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td align="left">
                                                                                                                    <Cthuvien:ma ID="ma_gt" runat="server" CssClass="css_form" kieu_chu="True" kt_xoa="X" BackColor="#f6f7f7"
                                                                                                                        ToolTip="Mã số cán bộ" ktra="ns_cb,so_the,ten" Width="150px" ten="Số thẻ người giới thiệu ( bảo lãnh)" onchange="ns_cb_P_KTRA('SO_THE_GT')" />
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu_c" Width="100px" Text="Tên giới thiệu" />
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    <Cthuvien:ma ID="ten_gt" runat="server" CssClass="css_form" kieu_unicode="true" kt_xoa="X" Enabled="false"
                                                                                                                        ToolTip="Mã số cán bộ" Width="150px" ten="tên người giới thiệu ( bảo lãnh)" />
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    <asp:Label ID="Label34" runat="server" CssClass="css_gchu_c" Width="100px" Text="Gán mã NSD" />
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    <Cthuvien:ma ID="ma_nsd" runat="server" CssClass="css_form" kieu_unicode="true" kt_xoa="X"
                                                                                                                        ToolTip="Mã số cán bộ" Width="150px" ten="tên người giới thiệu ( bảo lãnh)" />
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
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pu_ttct" runat="server" Style="display: none;" Height="430px" Width="800px">
                                                        <table runat="Server" cellspacing="2" cellpadding="2">
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label41" runat="server" Text="Cấp 1" CssClass="css_gchu" Width="100px" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="cap1" ten="Cấp 1" runat="server" BackColor="#f6f7f7" ReadOnly="true" CssClass="css_form" kt_xoa="X" Width="150px"
                                                                                    Enabled="true" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label43" runat="server" Text="Cấp 2" CssClass="css_gchu_c" Width="100px" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="cap2" ten="Cấp 2" runat="server" BackColor="#f6f7f7" ReadOnly="true" CssClass="css_form" kt_xoa="X" Width="150px"
                                                                                    Enabled="true" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label44" runat="server" Text="Cấp 3" CssClass="css_gchu_c" Width="100px" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="cap3" ten="Cấp 3" runat="server" BackColor="#f6f7f7" ReadOnly="true" CssClass="css_form" kt_xoa="X" Width="150px"
                                                                                    Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label45" runat="server" Text="Cấp 4" CssClass="css_gchu" Width="100px" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="Ma1" ten="Cấp 4" runat="server" BackColor="#f6f7f7" ReadOnly="true" CssClass="css_form" kt_xoa="X" Width="150px"
                                                                                    Enabled="true" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label46" runat="server" Text="Cấp 5" CssClass="css_gchu_c" Width="100px" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="Ma2" ten="Cấp 5" runat="server" BackColor="#f6f7f7" ReadOnly="true" CssClass="css_form" kt_xoa="X" Width="150px"
                                                                                    Enabled="true" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label47" runat="server" CssClass="css_gchu_c" Width="100px">Kiêm nhiệm</asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:kieu ID="kiemnhiem" runat="server" lke="C,K" Width="30px" ToolTip="C - Có,K - Không" CssClass="css_form_c" Text="K" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label48" runat="server" Text="Ngạch nghề nghiệp" CssClass="css_gchu" Width="100px" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="ngach_nnghiep" ten="Ngạch nghề nghiệp" runat="server" BackColor="#f6f7f7" ReadOnly="true" CssClass="css_form" kt_xoa="X" Width="150px" Enabled="true" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label49" runat="server" Text="Cấp bậc nghề nghiệp" CssClass="css_gchu_c" Width="100px" /></td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="capbac_nnghiep" ten="Cấp bậc nghề nghiệp" runat="server" BackColor="#f6f7f7" ReadOnly="true" CssClass="css_form" kt_xoa="X" Width="150px" Enabled="true" /></td>
                                                                            <td>
                                                                                <asp:Label ID="Label50" runat="server" Text="Ngành nghề" CssClass="css_gchu_c" Width="100px" /></td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="nganh_nghe" ten="Ngành nghề" BackColor="#f6f7f7" runat="server" ReadOnly="true" CssClass="css_form" kt_xoa="X" Width="150px" Enabled="true" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label51" runat="server" Text="Chuyên môn" CssClass="css_gchu" Width="100px" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="chuyenmon" ten="Chuyên môn" runat="server" BackColor="#f6f7f7" ReadOnly="true" CssClass="css_form" kt_xoa="X" Width="150px" Enabled="true" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label52" runat="server" Text="Chức danh" CssClass="css_gchu_c" Width="100px" /></td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="cdanh_ht" ten="Chức danh" runat="server" BackColor="#f6f7f7" ReadOnly="true" CssClass="css_form" kt_xoa="X" Width="150px" Enabled="true" /></td>
                                                                            <td>
                                                                                <asp:Label ID="Label53" runat="server" Text="Chức danh maketing" CssClass="css_gchu_c" Width="100px" /></td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="Cdanh_maketing" ten="Chức danh maketing" runat="server" CssClass="css_form" kt_xoa="X" Width="150px" Enabled="true" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label55" runat="server" Text="Phân loại CB" CssClass="css_gchu" Width="100px" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:DR_nhap ID="loai_cb" ten="Loại cb" runat="server" CssClass="css_form"
                                                                                    Width="150px" DataTextField="ten" DataValueField="ma" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Bbuoc5" runat="server" CssClass="css_gchu_c" Width="100px" Text="Quản lý t.tiếp" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="quanly_tt" ten="Quản lý t.tiếp" BackColor="#f6f7f7" onfocusout="KiemTra_QL()" ToolTip="Quản lý trực tiếp" runat="server"
                                                                                    CssClass="css_form" kt_xoa="X" Width="150px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label57" runat="server" Text="Email công ty" CssClass="css_gchu_c" Width="100px" /></td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="email_cty" ten="Email công ty" runat="server" CssClass="css_form" kt_xoa="X" Width="150px" Enabled="true" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label56" runat="server" Text="Trạng thái" CssClass="css_gchu" Width="100px" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="ttr" ten="Trạng thái" BackColor="#f6f7f7" ToolTip="Trạng thái" runat="server"
                                                                                    CssClass="css_form" kt_xoa="X" Width="150px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label58" runat="server" CssClass="css_gchu_c" Width="100px" Text="Ngày vào công ty" />
                                                                            </td>
                                                                            <td>
                                                                                <div class="ip-group date">
                                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" runat="server" Width="125px" CssClass="css_form_c" kieu_luu="S"
                                                                                        kt_xoa="X" />
                                                                                </div>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label59" runat="server" Text="Ngày vào thử việc" CssClass="css_gchu_c" Width="100px" /></td>
                                                                            <td>
                                                                                <div class="ip-group date">
                                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_tv" runat="server" Width="125px" CssClass="css_form_c" kieu_luu="S"
                                                                                        kt_xoa="X" />
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label32" runat="server" CssClass="css_gchu" Width="100px" Text="N. chính thức" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <div class="ip-group date">
                                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_ct" ten="N. chính thức" ToolTip="N. chính thức" runat="server"
                                                                                        CssClass="css_form" kt_xoa="X" Width="124px" />
                                                                                </div>
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:bbuoc ID="Label29" runat="server" CssClass="css_gchu_c" Width="100px" Text="Đối tượng lương" /></td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="NHOM" runat="server" CssClass="css_form" kieu_chu="true" BackColor="#f6f7f7"
                                                                                    kt_xoa="X" Width="150px" placeholder="Nhấn (F1)" ktra="ns_ma_nh,ma,ten" gchu="gchu" ten="Đối tượng lương" f_tkhao="~/App_form/ns/ma/ns_ma_nh.aspx" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pu_ttnl" runat="server" Style="display: none;" Height="430px" Width="800px">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                        CssClass="table gridX" loai="N" hangKt="13" cot="NHOM_NL_TEN,NANGLUC_TEN,muc_nl,nhom_nl,nangluc"
                                                                        cotAn="sott,so_id,nhom_nl,nangluc,gchu_nl" hamUp="ns_cb_nl_Update">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                            <asp:TemplateField HeaderText="Nhóm năng lực" HeaderStyle-Width="250px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="NHOM_NL_TEN" runat="server" CssClass="css_Gma_c" kieu_chu="true"
                                                                                        Width="250px" f_tkhao="~/App_form/dgnl/dm/dgnl_dm_n_nl.aspx" gchu="gchu" ten="Nhóm năng lực"
                                                                                        onchange="dgnl_tl_nl_cho_cdanh_P_KTRA('MA_NHOM')" ktra="dg_dm_nhom_nl,ma,ten" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Năng lực" HeaderStyle-Width="250px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="NANGLUC_TEN" runat="server" CssClass="css_Gma_c" kieu_chu="true"
                                                                                        Width="250px" f_tkhao="~/App_form/dgnl/dm/dgnl_dm_nl.aspx" gchu="gchu" ten="năng lực" guiId="hincd"
                                                                                        onchange="dgnl_tl_nl_cho_cdanh_P_KTRA('MANL')" ktra="dg_dm_nl,ma,ten" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Mức năng lực theo chức danh" HeaderStyle-Width="250px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="muc_nl" runat="server" Width="250px" CssClass="css_Gma" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField HeaderText="nhom_nl" DataField="nhom_nl">
                                                                                <ItemStyle CssClass="css_Gnd" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="nangluc" DataField="nangluc">
                                                                                <ItemStyle CssClass="css_Gnd" />
                                                                            </asp:BoundField>
                                                                        </Columns>
                                                                    </Cthuvien:GridX>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pu_ttk" runat="server" Style="display: none;" Height="430px" Width="800px">
                                                        <table cellpadding="2" cellspacing="2">
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label61" runat="server" Text="Số sổ BHXH" CssClass="css_gchu" Width="100px" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="so_bhxh" ten="Sổ sổ BHXH" runat="server" CssClass="css_form" kt_xoa="X" Width="150px" Enabled="true" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label62" runat="server" Text="Số thẻ BHYT" CssClass="css_gchu_c" Width="100px" /></td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="so_bhyt" ten="Số thẻ BHYT" runat="server" CssClass="css_form" kt_xoa="X" Width="150px" Enabled="true" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Width="100px" Text="Mã S.thuế" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="mast" ten="Mã S.thuế" runat="server" CssClass="css_form_c" ToolTip="Mã số thuế"
                                                                                    kt_xoa="X" Width="150px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label60" runat="server" Text="Ngày cấp " CssClass="css_gchu_c" Width="100px" /></td>
                                                                            <td>
                                                                                <div class="ip-group date">
                                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngaycap_mst" runat="server" Width="125px" CssClass="css_form_c" kieu_luu="S"
                                                                                        kt_xoa="X" />
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label64" runat="server" Text="Số hộ chiếu" CssClass="css_gchu" Width="100px" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="so_hchieu" ten="Số hộ chiếu" runat="server" CssClass="css_form" kt_xoa="X" Width="150px" Enabled="true" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label63" runat="server" Text="Ngày hết hạn" CssClass="css_gchu_c" Width="100px" /></td>
                                                                            <td>
                                                                                <div class="ip-group date">
                                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_hochieu" runat="server" Width="125px" CssClass="css_form_c" kieu_luu="S"
                                                                                        kt_xoa="X" />
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label65" runat="server" Text="Số visa" CssClass="css_gchu" Width="100px" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="so_visa" ten="Sổ visa" runat="server" CssClass="css_form" kt_xoa="X" Width="150px" Enabled="true" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label66" runat="server" Text="Ngày cấp" CssClass="css_gchu_c" Width="100px" /></td>
                                                                            <td>
                                                                                <div class="ip-group date">
                                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngaycap_visa" runat="server" Width="125px" CssClass="css_form_c" kieu_luu="S"
                                                                                        kt_xoa="X" />
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label67" runat="server" Text="Nơi cấp" CssClass="css_gchu" Width="100px" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="noicap_visa" ten="Nơi cấp" runat="server" CssClass="css_form"
                                                                                    kt_xoa="X" Width="150px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label68" runat="server" Text="Ngày hết hạn" CssClass="css_gchu_c" Width="100px" /></td>
                                                                            <td>
                                                                                <div class="ip-group date">
                                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayhethan_visa" runat="server" Width="125px" CssClass="css_form_c" kieu_luu="S"
                                                                                        kt_xoa="X" />
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label69" runat="server" Text="Công đoàn" CssClass="css_gchu" Width="100px" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td style="width: 150px">
                                                                                <Cthuvien:kieu ID="congdoan" runat="server" lke="X," Width="30px" ToolTip="X - Tham gia,  - Không tham gia" CssClass="css_form_c" Text="X" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label70" runat="server" Text="Ngày tham gia" CssClass="css_gchu_c" Width="100px" /></td>
                                                                            <td>
                                                                                <div class="ip-group date">
                                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngaythamgia" runat="server" Width="125px" CssClass="css_form_c" kieu_luu="S"
                                                                                        kt_xoa="X" />
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label21" runat="server" CssClass="css_gchu" Width="100px" Text="Ngân hàng" />
                                                                </td>
                                                                <td>
                                                                    <table cellspacing="0" cellpadding="0">
                                                                        <tr>

                                                                            <td>
                                                                                <Cthuvien:ma ID="nha" runat="server" CssClass="css_form" kt_xoa="X" ToolTip="Ngân hàng" placeholder="Nhấn (F1)"
                                                                                    Width="150px" kieu_unicode="True" ten="Ngân hàng" f_tkhao="~/App_form/ns/ma/ns_ma_nha.aspx"
                                                                                    ktra="ns_ma_nha,ma,ten" kieu_chu="True" onchange="ns_cb_P_KTRA('NHA')" BackColor="#f6f7f7" />
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label8" runat="server" CssClass="css_gchu_c" Width="100px" Text="Số TK" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="sotk" runat="server" CssClass="css_form" kieu_so="true" kt_xoa="X"
                                                                                    ToolTip="Số tài khoản" Width="150px" kieu_chu="True" ten="Số tài khoản" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label19" runat="server" CssClass="css_gchu" Width="100px" Text="Địa chỉ NH" />
                                                                </td>
                                                                <td>
                                                                    <Cthuvien:nd ID="nha_dchi" runat="server" kt_xoa="X" ten="Địa chỉ ngân hàng" CssClass="css_form" Width="413px"
                                                                        kieu_unicode="true" ToolTip="Địa chỉ ngân hàng" TextMode="MultiLine" Height="50px" Rows="3" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="css_border" align="left">
                                                    <div id="UPa_gchu">
                                                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <table id="UPa_nhap" cellpadding="1" cellspacing="1" class="tableButton">
                                                        <tr>
                                                            <td>
                                                                <div class="box3 txRight">
                                                                    <a href="#" onclick="return ns_cb_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                                    <a href="#" class="bt bt-grey" onclick="return ns_cb_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                                    <a href="#" onclick="return khud_trdoi_FI_NH();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">Ả</span>nh</a>
                                                                    <a href="#" onclick="return form_P_TRA_CHON('SO_THE,TEN,PHONG,TEN_PHONG,EMAIL,NGAYD,CDANH,NSINH,DTDD,EMAIL_CTY,TTR');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                                    <a href="#" id="hien_ttt" runat="server" class="bt bt-grey"><span class="txUnderline">T</span>hông tin thêm</a>
                                                                    <a href="#" id="ttt" onclick="return from_MA_TT();form_P_LOI();" runat="server" class="bt bt-grey"><span class="txUnderline">M</span>ã thông tin</a>
                                                                    <a href="#" id="file" onclick="return nhap_file();form_P_LOI();" runat="server" class="bt bt-grey"><span class="txUnderline">F</span>ile</a>
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
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>



    <div id="UPa_ttt" style="border: 1px solid #C0C0C0; background-color: #E9E9D1; display: none;">
        <table cellspacing="1" cellpadding="1">
            <tr id="tr_ttt">
                <td>
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label54" runat="server" CssClass="css_phude" Text="Thông tin thêm" />
                            </td>
                            <td align="right">
                                <img id="dong_ttt" alt="" src="../../../images/bitmaps/dong.png" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <khud_ttt:khud_ttt ID="khud_ttt" runat="server" ps="NS" nv="TT" />
                </td>
                <td></td>
            </tr>
        </table>
    </div>

    <AjaxTk:ModalPopupExtender ID="MPo_ttt" runat="server" BackgroundCssClass="css_modal"
        PopupDragHandleControlID="tr_ttt" PopupControlID="UPa_ttt" TargetControlID="hien_ttt"
        CancelControlID="dong_ttt" OnCancelScript="khud_ttt_P_DONG()" />
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="ps" runat="server" value="NS" />
        <Cthuvien:an ID="nv" runat="server" value="TT" />
        <Cthuvien:an ID="fileanh" runat="server" value="0" />
        <Cthuvien:an ID="ten_phong" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1260,780" />
    </div>
</asp:Content>
