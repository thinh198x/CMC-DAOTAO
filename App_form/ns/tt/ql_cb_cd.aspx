<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ql_cb_cd.aspx.cs" Inherits="f_ql_cb_cd"
    Title="ql_cb_cd" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>


<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%" style="background-color: #f4f6f8">
        <tr>
            <td align="left">
                <table cellpadding="0" cellspacing="0" style="padding-left: 10px">
                    <tr>
                        <td align="left" colspan="2">
                            <Cthuvien:luu ID="Luu2" runat="server" CssClass="css_tieudeM" Text="CBNV thuộc quyền quản lý" />
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
                        
                        <td align="left" class="form_left" valign="top" style="padding-top: 20px">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div id="first-tab-group">
                                            <div class="box3" id="search">
                                                
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <table id="Upa_tk" style="line-height: 20px; padding-left: 10px;" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label11" runat="server" Width="70px" Text="Trạng thái" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td style="padding-bottom: 2px">                                                                            
                                                                            <Cthuvien:DR_nhap ID="dr_trangthai" onchange="ns_cb_P_KTRA('PHONG_TK')" ten="Trạng thái làm việc" runat="server"
                                                                                CssClass="css_form" kieu="S" Width="230px">
                                                                                <asp:ListItem Selected="True" Text="Làm việc" Value="0"></asp:ListItem>
                                                                                <asp:ListItem Text="Nghỉ việc" Value="1"></asp:ListItem>
                                                                            </Cthuvien:DR_nhap>                                                                                   
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
                                                                    CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="ns_cb_GR_lke_RowChange()">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                        <asp:BoundField HeaderText="T.tự" DataField="sott" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Số Thẻ" DataField="so_the" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Họ Tên" DataField="ten" HeaderStyle-Width="179px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Số id" DataField="so_id" />                                                                        
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
                                                            <td style="height: 120px">
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <Cthuvien:bbuoc ID="Label9" runat="server" Width="70px" Text="Mã CB" CssClass="css_gchu_c" />
                                                                        </td>   
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
                                            <tr>
                                                <td align="left">
                                                    <table id="TPu" runat="server" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:tab ID="TPu_syll" runat="server" CssClass="css_tab_ngang_ac" Width="120px"
                                                                    Height="23px" Text="Sơ yếu lý lịch" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="TPu_ttnl" runat="server" CssClass="css_tab_ngang_de" Width="120px"
                                                                    Height="23px" Text="Thông tin năng lực" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="TPu_ct_truoc" runat="server" CssClass="css_tab_ngang_de" Width="120px"
                                                                    Height="23px" Text="QT c.tác trước đây" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="TPu_ct" runat="server" CssClass="css_tab_ngang_de" Width="120px"
                                                                    Height="23px" Text="QT c.tác tại CT" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="TPu_dtao" runat="server" CssClass="css_tab_ngang_de" Width="120px"
                                                                    Height="23px" Text="QT đào tạo" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="TPu_htap" runat="server" CssClass="css_tab_ngang_de" Width="120px"
                                                                    Height="23px" Text="QT học tập" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="TPu_hd" runat="server" CssClass="css_tab_ngang_de" Width="120px"
                                                                    Height="23px" Text="QT HĐ" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="TPu_kt" runat="server" CssClass="css_tab_ngang_de" Width="120px"
                                                                    Height="23px" Text="QT khen thưởng" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="TPu_kl" runat="server" CssClass="css_tab_ngang_de" Width="120px"
                                                                    Height="23px" Text="QT kỷ luật" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="TPu_dgia" runat="server" CssClass="css_tab_ngang_de" Width="120px"
                                                                    Height="23px" Text="Kết quả đánh giá" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="Pu_syll" runat="server" Style="display: block;" Height="430px" Width="800px">
                                                        <table cellpadding="1" cellspacing="1" border="0">
                                                            <tr>
                                                                <td align="left">
                                                                    <Cthuvien:bbuoc ID="Label7" runat="server" Text="Giới tính" CssClass="css_gchu" Width="100px" />
                                                                </td>                                                                
                                                                <td>
                                                                    <Cthuvien:DR_nhap ID="GTINH" ten="Giới tính" runat="server" CssClass="css_form"
                                                                        Width="150px" DataTextField="ten" DataValueField="ma" Enabled="false" />
                                                                </td>
                                                                <td>
                                                                    <Cthuvien:bbuoc ID="Label15" runat="server" Text="N.sinh" Width="100px" CssClass="css_gchu_c" />
                                                                </td>
                                                                <td>
                                                                    <div class="ip-group date">
                                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NSINH" ten="N.sinh" runat="server" CssClass="css_form_c"
                                                                            Width="124px" kt_xoa="X" ToolTip="Năm sinh" Enabled="false" />
                                                                    </div>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="Bbuoc7" runat="server" Text="Đối tượng cư chú" CssClass="css_gchu_c" Width="100px" />
                                                                </td>
                                                                <td align="left">
                                                                    <Cthuvien:DR_nhap ID="dt_cutru" runat="server" CssClass="css_form" Width="150px"
                                                                        DataTextField="ten" DataValueField="ma" ten="Đối tượng cư chú" Enabled="false" />
                                                                </td>                                                                        
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label22" runat="server" Text="Mobile" Width="100px" CssClass="css_gchu" />
                                                                </td>                                                                
                                                                <td>
                                                                    <Cthuvien:ma ID="dtdd" ten="ĐT.D.Động" kieu_so="true" runat="server" Width="150px" ToolTip="Số điện thoại di động"
                                                                        CssClass="css_form" kt_xoa="X" Enabled="false" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label5" runat="server" CssClass="css_gchu_c" Width="100px" Text="Email" />
                                                                </td>
                                                                <td>
                                                                    <Cthuvien:ma ID="email" ten="Email" runat="server" CssClass="css_form" kt_xoa="X" Width="150px"
                                                                         Enabled="false" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label36" runat="server" CssClass="css_gchu_c" Width="100px" Text="Hôn nhân" />
                                                                </td>
                                                                <td>
                                                                    <Cthuvien:DR_nhap ID="tt_honnhan" ten="Tình trạng hôn nhân" runat="server" DataTextField="ten" DataValueField="ma"
                                                                        CssClass="css_form" Width="150px" Enabled="false" />
                                                                </td>
                                                                        
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <Cthuvien:bbuoc ID="Label12" runat="server" CssClass="css_gchu" Width="100px" Text="CMND" />
                                                                </td>                                                                
                                                                <td>
                                                                    <Cthuvien:ma ID="SOCMT" ten="Số CMND" kieu_so="true" ToolTip="Số chứng minh nhân dân" runat="server"
                                                                        CssClass="css_form" kt_xoa="X" Width="149px" Enabled="false" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label16" runat="server" CssClass="css_gchu_c" Width="95px" Text="Ngày cấp" />
                                                                </td>
                                                                <td>
                                                                    <div class="ip-group date">
                                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_cmt" ten="Ngày cấp CMND" ToolTip="Ngày cấp CMND" runat="server"
                                                                            CssClass="css_form_c" kt_xoa="X" Width="125px" Enabled="false" />
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label17" runat="server" CssClass="css_gchu_c" Width="96px" Text="Nơi cấp" />
                                                                </td>
                                                                <td>
                                                                    <Cthuvien:ma ID="nc_cmt"  placeholder="Nhấn (F1)" BackColor="#f6f7f7" ten="Nhập mã nơi cấp cmt" runat="server"
                                                                        CssClass="css_form" Width="150px" Enabled="false" />
                                                                </td>
                                                                        
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Bbuoc1" runat="server" CssClass="css_gchu" Width="100px" Text="Ngày hết hạn CMT" />
                                                                </td>
                                                                
                                                                <td>
                                                                    <div class="ip-group date">
                                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_hh_cmt" ten="ngày hết hạn cmt" ToolTip="Ngày hết hạn cmt" runat="server"
                                                                            CssClass="css_form_c" kt_xoa="X" Width="125px" Enabled="false" />
                                                                    </div>
                                                                </td>
                                                                <td></td>      
                                                                <td></td> 
                                                                <td></td> 
                                                                <td></td>   
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <Cthuvien:bbuoc ID="Label10" runat="server" Text="Quốc tịch" CssClass="css_gchu" Width="100px" />
                                                                </td>
                                                                <td>
                                                                    <Cthuvien:DR_nhap ID="NN" runat="server" CssClass="css_form" Width="150px"
                                                                        DataTextField="ten" DataValueField="ma" ten="Mã nước" Enabled="false" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Bbuoc4" runat="server" CssClass="css_gchu_c" Width="100px" Text="Dân tộc" /></td>
                                                                <td>
                                                                    <Cthuvien:ma ID="dantoc" placeholder="Nhấn (F1)" Width="150px" ten="Dân tộc" BackColor="#f6f7f7" runat="server" CssClass="css_form"  Enabled="false" /></td>
                                                                <td>
                                                                    <asp:Label ID="Label35" runat="server" CssClass="css_gchu_c" Width="100px" Text="Tôn giáo" />
                                                                </td>
                                                                <td>
                                                                    <Cthuvien:ma ID="tongiao" placeholder="Nhấn (F1)" ten="Tôn giáo" runat="server" BackColor="#f6f7f7" CssClass="css_form" Width="150px"  Enabled="false" />
                                                                </td>
                                                                       
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label24" runat="server" CssClass="css_gchu" Width="100px" Text="Đ/c hiện tại" />
                                                                </td>
                                                                
                                                                <td colspan="5">
                                                                    <Cthuvien:ma ID="dchi" runat="server" kt_xoa="X" CssClass="css_form" Width="672px"
                                                                        kieu_unicode="true" Enabled="false" />
                                                                </td>
                                                                        
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Bbuoc6" runat="server" CssClass="css_gchu" Width="100px" Text="Tỉnh/Thành phố" />
                                                                </td>
                                                                
                                                                <td>
                                                                    <Cthuvien:ma ID="tt_hientai" runat="server" Width="150px" CssClass="css_form"
                                                                        BackColor="#f6f7f7" kieu_chu="true" f_tkhao="~/App_form/ns/ma/ns_ma_tt.aspx"
                                                                        kt_xoa="X" Enabled="false" ToolTip="Tỉnh/Thành phố" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label37" runat="server" CssClass="css_gchu_c" Width="96px" Text="Quận/Huyện" />
                                                                </td>
                                                                <td>
                                                                    <Cthuvien:ma ID="qh_hientai" runat="server" Width="150px" CssClass="css_form"
                                                                        BackColor="#f6f7f7" kieu_chu="true" Enabled="false" ToolTip="Quận/Huyện" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label38" runat="server" CssClass="css_gchu_c" Width="96px" Text="Xã/Phường" />
                                                                </td>
                                                                <td>
                                                                    <Cthuvien:ma ID="xp_hientai" runat="server" Width="150px" CssClass="css_form"
                                                                        BackColor="#f6f7f7" kieu_chu="true"  Enabled="false" ToolTip="Xã/Phường" />
                                                                </td>
                                                                        
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label30" runat="server" CssClass="css_gchu" Width="100px" Text="H.Khẩu t.trú" />
                                                                </td>                                                                
                                                                <td colspan="5">
                                                                    <Cthuvien:ma ID="hkhau" runat="server" kt_xoa="X" CssClass="css_form" Width="672px"
                                                                        kieu_unicode="true" Enabled="false" />
                                                                </td>
                                                                        
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label39" runat="server" CssClass="css_gchu" Width="100px" Text="Tỉnh/Thành phố" />
                                                                </td>
                                                                
                                                                <td>
                                                                    <Cthuvien:ma ID="tt_thuongtru" runat="server" Width="150px" CssClass="css_form"
                                                                        BackColor="#f6f7f7" kieu_chu="true" Enabled="false" ToolTip="Tỉnh/Thành phố" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label13" runat="server" CssClass="css_gchu_c" Width="96px" Text="Quận/Huyện" />
                                                                </td>
                                                                <td>
                                                                    <Cthuvien:ma ID="qh_thuongtru" runat="server" Width="150px" CssClass="css_form"
                                                                        BackColor="#f6f7f7" kieu_chu="true" Enabled="false" ToolTip="Quận/Huyện" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label42" runat="server" CssClass="css_gchu_c" Width="96px" Text="Xã/Phường" />
                                                                </td>
                                                                <td>
                                                                    <Cthuvien:ma ID="xp_thuongtru" runat="server" Width="150px" CssClass="css_form"
                                                                        BackColor="#f6f7f7" kieu_chu="true" Enabled="false" ToolTip="Xã/Phường" />
                                                                </td>
                                                                        
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:Label ID="Label18" runat="server" CssClass="css_gchu" Width="100px" Text="Khi cần liên lạc với ai" />
                                                                </td>
                                                                <td align="left" colspan="5">                                                                    
                                                                    <Cthuvien:nd ID="khican_ll" runat="server" kt_xoa="X" CssClass="css_form" Width="672px" Height="50px" Rows="3"
                                                                        kieu_unicode="true" TextMode="MultiLine" Enabled="false" />
                                                                            
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pu_ttnl" runat="server" Style="display: none;" Height="430px" Width="800px">
                                                        <Cthuvien:GridX ID="GR_ttnl" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" hangKt="13" cot="nhom_nl,ten_nl,muc_nl" >
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:BoundField DataField="nhom_nl" HeaderText="Nhóm năng lực" HeaderStyle-Width="250px" />
                                                                <asp:BoundField DataField="ten_nl" HeaderText="Năng lực" HeaderStyle-Width="250px" />
                                                                <asp:BoundField DataField="muc_nl" HeaderText="Mức năng lực theo chức danh" HeaderStyle-Width="250px" />                                                                                                                              
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pu_ct_truoc" runat="server" Style="display: none;" Height="430px" Width="800px">
                                                        <Cthuvien:GridX ID="GR_ct_truoc" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" hangKt="13" cot="TENCTY,DCCTY,SODT,NGAYD,NGAYC,CDANH,MUCLUONG,LYDO" >
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:BoundField DataField="TENCTY" HeaderText="Công ty" HeaderStyle-Width="150px"/>
                                                                <asp:BoundField DataField="DCCTY" HeaderText="Địa chỉ" HeaderStyle-Width="150px" />
                                                                <asp:BoundField DataField="SODT" HeaderText="Số điện thoại" HeaderStyle-Width="100px" />     
                                                                <asp:BoundField DataField="NGAYD" HeaderText="Ngày vào" HeaderStyle-Width="80px" />
                                                                <asp:BoundField DataField="NGAYC" HeaderText="Ngày ra" HeaderStyle-Width="80px" />
                                                                <asp:BoundField DataField="CDANH" HeaderText="Chức danh" HeaderStyle-Width="100px" />     
                                                                <asp:BoundField DataField="MUCLUONG" HeaderText="Mức lương" HeaderStyle-Width="100px" />
                                                                <asp:BoundField DataField="LYDO" HeaderText="Lý do" HeaderStyle-Width="150px" />                                                                                                                                                                                            
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pu_ct" runat="server" Style="display: none;" Height="430px" Width="800px">
                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" hangKt="13" cot="SO_QD,NGAY_QD,NGAYD,NGAYC,LNG,NGACH,BAC,HSO" >
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:BoundField DataField="SO_QD" HeaderText="Công ty" HeaderStyle-Width="150px"/>
                                                                <asp:BoundField DataField="NGAY_QD" HeaderText="Địa chỉ" HeaderStyle-Width="150px" />
                                                                <asp:BoundField DataField="NGAYD" HeaderText="Số điện thoại" HeaderStyle-Width="100px" />     
                                                                <asp:BoundField DataField="NGAYC" HeaderText="Ngày vào" HeaderStyle-Width="80px" />
                                                                <asp:BoundField DataField="LNG" HeaderText="Ngày ra" HeaderStyle-Width="80px" />
                                                                <asp:BoundField DataField="NGACH" HeaderText="Chức danh" HeaderStyle-Width="100px" />     
                                                                <asp:BoundField DataField="BAC" HeaderText="Mức lương" HeaderStyle-Width="100px" />
                                                                <asp:BoundField DataField="HSO" HeaderText="Lý do" HeaderStyle-Width="150px" />                                                                                                                                                                                            
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pu_dtao" runat="server" Style="display: none;" Height="430px" Width="800px">
                                                        
                                                    </asp:Panel>
                                                     <asp:Panel ID="Pu_htap" runat="server" Style="display: none;" Height="430px" Width="800px">
                                                        <Cthuvien:GridX ID="GR_htap" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" hangKt="13" cot="ten_htdt,ten_cndt,TRUONG,THANGD,THANGC,NAM_TN,ten_kqdt,NGAY_HIEU_LUC" >
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:BoundField DataField="ten_htdt" HeaderText="Công ty" HeaderStyle-Width="150px"/>
                                                                <asp:BoundField DataField="ten_cndt" HeaderText="Địa chỉ" HeaderStyle-Width="150px" />
                                                                <asp:BoundField DataField="TRUONG" HeaderText="Số điện thoại" HeaderStyle-Width="100px" />     
                                                                <asp:BoundField DataField="THANGD" HeaderText="Ngày vào" HeaderStyle-Width="80px" />
                                                                <asp:BoundField DataField="THANGC" HeaderText="Ngày ra" HeaderStyle-Width="80px" />
                                                                <asp:BoundField DataField="NAM_TN" HeaderText="Chức danh" HeaderStyle-Width="100px" />     
                                                                <asp:BoundField DataField="ten_kqdt" HeaderText="Mức lương" HeaderStyle-Width="100px" />
                                                                <asp:BoundField DataField="NGAY_HIEU_LUC" HeaderText="Lý do" HeaderStyle-Width="150px" />                                                                                                                                                                                            
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pu_hd" runat="server" Style="display: block;" Height="430px" Width="800px">
                                                        <Cthuvien:GridX ID="GR_hd" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" hangKt="13" cot="ten_lhd,SO_HD,NGAY_KY,NGAYD,NGAYC,PHONG,LNG,NGACH,BAC,HSO" >
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:BoundField DataField="ten_lhd" HeaderText="Công ty" HeaderStyle-Width="150px"/>
                                                                <asp:BoundField DataField="SO_HD" HeaderText="Địa chỉ" HeaderStyle-Width="150px" />
                                                                <asp:BoundField DataField="NGAY_KY" HeaderText="Số điện thoại" HeaderStyle-Width="100px" />     
                                                                <asp:BoundField DataField="NGAYD" HeaderText="Ngày vào" HeaderStyle-Width="80px" />
                                                                <asp:BoundField DataField="NGAYC" HeaderText="Ngày ra" HeaderStyle-Width="80px" />
                                                                <asp:BoundField DataField="PHONG" HeaderText="Chức danh" HeaderStyle-Width="100px" />     
                                                                <asp:BoundField DataField="LNG" HeaderText="Mức lương" HeaderStyle-Width="100px" />
                                                                <asp:BoundField DataField="NGACH" HeaderText="Lý do" HeaderStyle-Width="150px" />       
                                                                <asp:BoundField DataField="BAC" HeaderText="Lý do" HeaderStyle-Width="150px" />    
                                                                <asp:BoundField DataField="HSO" HeaderText="Lý do" HeaderStyle-Width="150px" />                                                                                                                                                                                         
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pu_kt" runat="server" Style="display: none;" Height="430px" Width="800px">
                                                        <Cthuvien:GridX ID="GR_kt" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" hangKt="13" cot="ten_htkt,ten_cap_ktkl,ten_noi_ktkl,SOQD,NGAYQD,MUCTHUONG,LYDO" >
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:BoundField DataField="ten_htkt" HeaderText="Công ty" HeaderStyle-Width="150px"/>
                                                                <asp:BoundField DataField="ten_cap_ktkl" HeaderText="Địa chỉ" HeaderStyle-Width="150px" />
                                                                <asp:BoundField DataField="ten_noi_ktkl" HeaderText="Số điện thoại" HeaderStyle-Width="100px" />    
                                                                <asp:BoundField DataField="SOQD" HeaderText="Ngày vào" HeaderStyle-Width="80px" /> 
                                                                <asp:BoundField DataField="NGAYQD" HeaderText="Ngày vào" HeaderStyle-Width="80px" />
                                                                <asp:BoundField DataField="MUCTHUONG" HeaderText="Ngày ra" HeaderStyle-Width="80px" />
                                                                <asp:BoundField DataField="LYDO" HeaderText="Chức danh" HeaderStyle-Width="100px" />                                                                                                  
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pu_kl" runat="server" Style="display: block;" Height="430px" Width="800px">
                                                        <Cthuvien:GridX ID="GR_kl" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" hangKt="13" cot="ten_htkl,ten_cap_ktkl,ten_noi_ktkl,SOQD,NGAYQD,NGAYD,NGAYC,MUCPHAT,LYDO" >
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:BoundField DataField="ten_htkl" HeaderText="Công ty" HeaderStyle-Width="150px"/>
                                                                <asp:BoundField DataField="ten_cap_ktkl" HeaderText="Địa chỉ" HeaderStyle-Width="150px" />
                                                                <asp:BoundField DataField="ten_noi_ktkl" HeaderText="Số điện thoại" HeaderStyle-Width="100px" /> 
                                                                <asp:BoundField DataField="SOQD" HeaderText="Ngày vào" HeaderStyle-Width="80px" />     
                                                                <asp:BoundField DataField="NGAYQD" HeaderText="Ngày vào" HeaderStyle-Width="80px" />
                                                                <asp:BoundField DataField="NGAYD" HeaderText="Ngày ra" HeaderStyle-Width="80px" />
                                                                <asp:BoundField DataField="NGAYC" HeaderText="Chức danh" HeaderStyle-Width="100px" />    
                                                                <asp:BoundField DataField="MUCPHAT" HeaderText="Ngày ra" HeaderStyle-Width="80px" />
                                                                <asp:BoundField DataField="LYDO" HeaderText="Chức danh" HeaderStyle-Width="100px" />                                                                                                  
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pu_dgia" runat="server" Style="display: none;" Height="430px" Width="800px">
                                                        
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



    
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="ps" runat="server" value="NS" />
        <Cthuvien:an ID="nv" runat="server" value="TT" />
        <Cthuvien:an ID="fileanh" runat="server" value="0" />
        <Cthuvien:an ID="ten_phong" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1260,780" />
    </div>
</asp:Content>