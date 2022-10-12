<%@ Page Title="ns_td_khct" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_khct.aspx.cs" Inherits="f_ns_td_khct" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_ttt.ascx" TagName="khud_ttt" TagPrefix="khud_ttt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%" style="background-color: #f4f6f8">
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="0" style="padding-left: 10px">
                    <tr>
                        <td align="left" colspan="2">
                            <Cthuvien:luu ID="Luu2" runat="server" CssClass="css_tieudeM" Text="Kế hoạch tuyển dụng chi tiết" />
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
                                            </ul>
                                            <div class="clear"></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top"></td>
                        <td align="left" class="form_left" valign="top" style="padding-top: 20px">
                            <table id="UPa_tk" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div id="first-tab-group">
                                            <div class="box3" id="search">
                                                <asp:Panel ID="Pa_ch" runat="server" Style="width: 365px; height: 510px; display: block;">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <table id="Upa_tk" style="line-height: 20px; padding-left: 10px;" cellpadding="1" cellspacing="1">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label26" runat="server" Width="120px" Text="Năm" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td style="padding-bottom: 2px">
                                                                            <Cthuvien:ma ID="nam_tk" ten="Năm" kieu_so="true" runat="server" kt_xoa="K" CssClass="css_form_r" Width="170px" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label25" runat="server" Width="120px" Text="Tháng" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:DR_lke ID="thang_tk" kt_xoa="X" ten="Tháng" ktra="DT_THANG" runat="server"  Width="170px">                                                                                
                                                                            </Cthuvien:DR_lke>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label1" runat="server" Width="120px" Text="Đơn vị" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td style="padding-bottom: 2px">
                                                                            <Cthuvien:DR_lke ID="phong_tk" kt_xoa="X" ten="Phòng" ktra="DT_PHONG" runat="server"  Width="170px">                                                                                
                                                                            </Cthuvien:DR_lke>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label2" runat="server" Width="120px" Text="Chức danh" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:so ID="cdanh_tk" ten="Chức danh" runat="server" kt_xoa="K" CssClass="css_form" Width="170px" />

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label11" runat="server" Width="120px" Text="Mã yêu cầu TD" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td style="padding-bottom: 2px">
                                                                            <table cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <Cthuvien:ma ID="MA_YC_TK" placeholder="Nhấn (F1)" runat="server" CssClass="css_form" kieu_chu="True" kt_xoa="G"
                                                                                            ToolTip="Mã yêu cầu tìm kiếm" ktra="ns_td_dexuat,ma,ten" gchu="gchu" f_tkhao="~/App_form/ns/td/ns_td_dexuat.aspx" BackColor="#f6f7f7" Width="170px" ten="Mã yêu cầu TD" onchange="ns_td_khct_P_KTRA('MA_YC_TK')" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="padding-top: 5px">
                                                                        <td></td>
                                                                        <td style="padding-top: 5px; padding-bottom: 5px">
                                                                            <a href="#" onclick="return ns_td_khct_P_LKE('M');form_P_LOI();" class="bt bt-grey"><i class="fa fa-search"></i>Tìm kiếm</a>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div style="height: 425px; width: 365px; overflow: scroll">
                                                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                        CssClass="table gridX" loai="X" hangKt="12" cotAn="so_id" cot="sott,nam,thang,ma,phong_yc,cdanh,sl_cantuyen,sl_dexuat_td,trangthai_pd,so_id" hamRow="ns_td_khct_GR_lke_RowChange()"
                                                                        hamUp="ns_td_khct_lke_Update">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                            <asp:BoundField HeaderText="T.tự" DataField="sott" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                            <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                                                            <asp:BoundField HeaderText="Tháng" DataField="thang" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gso" />
                                                                            <asp:BoundField HeaderText="Mã yêu cầu TD" DataField="ma" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma" />
                                                                            <asp:BoundField HeaderText="Bộ phận yêu cầu" DataField="phong_yc" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                                                            <asp:BoundField HeaderText="Chức danh" DataField="cdanh" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                                                            <asp:BoundField HeaderText="Số lượng cần tuyển" DataField="sl_cantuyen" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gso" />
                                                                            <asp:BoundField HeaderText="Số lượng đề xuất tuyển dụng" DataField="sl_dexuat_td" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gso" />
                                                                            <asp:BoundField HeaderText="Trạng thái phê duyệt" DataField="trangthai_pd" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma_c" />
                                                                            <asp:BoundField HeaderText="leGrid" DataField="so_id" HeaderStyle-Width="10px" />
                                                                        </Columns>
                                                                    </Cthuvien:GridX>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td id="GR_lke_td" runat="server" align="center" style="padding-right: 10px;">
                                                                <khud_slide:khud_slide ID="GR_lke_slide" runat="server" rong="200" loai="X" gridId="GR_lke"
                                                                    ham="ns_td_khct_P_LKE('L')" />
                                                            </td>
                                                        </tr>
                                                    </table>
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
                                                    <table cellpadding="1" cellspacing="1" style="padding: 10px 0px 10px 0px">
                                                        <tr>
                                                            <td>
                                                                <table cellpadding="1" class="tab_content" cellspacing="1">
                                                                    <tr>
                                                                        <td>
                                                                            <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Width="120px" Text="Năm" Tolltip="Năm" />
                                                                        </td>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <Cthuvien:ma ID="NAM" kieu_so="true" runat="server" ten="Năm" kt_xoa="G" CssClass="css_form_r"
                                                                                            Width="155px" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <Cthuvien:bbuoc ID="Bbuoc3" Width="120px" runat="server" CssClass="css_gchu_c" Text="Tháng" Tolltip="Tháng" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <Cthuvien:DR_lke ID="THANG" kt_xoa="X" ten="Tháng" ktra="DT_THANG" runat="server"  Width="155px">                                                                                
                                                                                        </Cthuvien:DR_lke>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <Cthuvien:bbuoc ID="Bbuoc9" runat="server" Text="Đơn vị" CssClass="css_gchu" Width="120px"></Cthuvien:bbuoc>

                                                                        </td>
                                                                        <td align="left">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <Cthuvien:ma ID="PHONG" runat="server" CssClass="css_form" kieu_chu="true" ktra="ht_ma_phong,ma,ten"
                                                                                            kt_xoa="X" gchu="gchu" f_tkhao="~/App_form/ht/ht_maph.aspx" Width="155px" ten="Đơn vị" placeholder="Nhấn (F1)"
                                                                                            BackColor="#f6f7f7" />

                                                                                    </td>
                                                                                    <td>
                                                                                        <Cthuvien:bbuoc ID="Bbuoc8" runat="server" Text="Chức danh" CssClass="css_gchu_c" Width="120px"></Cthuvien:bbuoc>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <Cthuvien:ma ID="CDANH" runat="server" Width="155px" CssClass="css_form" placeholder="Nhấn (F1)"
                                                                                            BackColor="#f6f7f7" kieu_chu="true" ten="Chức danh" onchange="ns_td_khct_P_KTRA('CDANH');" f_tkhao="~/App_form/ns/hdns/tl/ns_ma_cdanh.aspx"
                                                                                            kt_xoa="X" ktra="ns_ma_cdanh,ma,ten" ToolTip="Chức danh" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">

                                                                            <Cthuvien:bbuoc ID="Bbuoc5" runat="server" Text="Mã yêu cầu TD" CssClass=" css_gchu" Width="120px"></Cthuvien:bbuoc>
                                                                        </td>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <Cthuvien:ma ID="MA" runat="server" onchange="ns_td_khct_P_KTRA('MA');" CssClass="css_form" kt_xoa="X" gchu="gchu" Width="155px" ten="Mã yêu cầu TD"
                                                                                            BackColor="#f6f7f7" />

                                                                                    </td>
                                                                                    <td>
                                                                                        <Cthuvien:bbuoc ID="Bbuoc10" runat="server" Text="Số lượng cần tuyển" CssClass=" css_gchu_c" Width="120px"></Cthuvien:bbuoc>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <Cthuvien:ma ID="SL_CANTUYEN" ten="Số lượng cần tuyển" kieu_so="true" runat="server" CssClass="css_form_r" ToolTip="Số lượng cần tuyển" Width="155px" kt_xoa="G" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <Cthuvien:bbuoc ID="Bbuoc11" runat="server" Text="Số lượng DX tuyển" CssClass="css_gchu_a" Width="120px"></Cthuvien:bbuoc>
                                                                        </td>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <Cthuvien:ma ID="SL_DEXUAT_TD" runat="server" Width="155px" CssClass="css_form_r" kieu_so="true" ten="Số lượng đề xuất tuyển" kt_xoa="X" ToolTip="Số lượng đề xuất tuyển" />
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
                                                                <Cthuvien:tab ID="TPu_khtk" runat="server" CssClass="css_tab_ngang_ac" Width="120px"
                                                                    Height="23px" Text="Kế hoạch triển khai" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="TPu_mtcv" runat="server" CssClass="css_tab_ngang_de" Width="120px"
                                                                    Height="23px" Text="Mô tả công việc" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="TPu_tlyc" runat="server" CssClass="css_tab_ngang_de" Width="160px"
                                                                    Height="23px" Text="Thiết lập yêu cầu khác" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="TPu_cttt" runat="server" CssClass="css_tab_ngang_de" Width="150px"
                                                                    Height="23px" Text="Cách thức thi tuyển" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="Pu_khtk" runat="server" Style="display: block;" Height="420px" Width="800px">
                                                        <table runat="Server" cellspacing="0" cellpadding="0" style="padding-top: 10px">
                                                            <tr>
                                                                <td align="left">
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td align="left" valign="top" class="tab_content">
                                                                                <table cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td class="css_border">
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <Cthuvien:bbuoc ID="Bbuoc12" runat="server" Text="Bộ phận yêu cầu" CssClass=" css_gchu_a" Width="111px"></Cthuvien:bbuoc>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellpadding="0" cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="PHONG_YC" runat="server" CssClass="css_form" kieu_chu="true" ktra="ht_ma_phong,ma,ten"
                                                                                                                        kt_xoa="X" gchu="gchu" f_tkhao="~/App_form/ht/ht_maph.aspx" Width="150px" ten="Bộ phận yêu cầu" placeholder="Nhấn (F1)"
                                                                                                                        BackColor="#f6f7f7" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label33" runat="server" Text="Ngày gửi yêu cầu" Width="100px" CssClass="css_gchu_c" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <div class="ip-group date">
                                                                                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_gui_yc" ten="ngày yêu cầu" runat="server"
                                                                                                                            CssClass="css_form_c" Width="124px" kt_xoa="G" />
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    <asp:Label ID="Label7" runat="server" CssClass="css_gchu_c" Width="100px" Text="Cách thức TD" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:DR_lke ID="cthuc_td" kt_xoa="X" ten="Cách thức tuyển dụng" ToolTip="Cách thức tuyển dụng" ktra="DT_CTHUC_TD" runat="server"  Width="149px">                                                                                
                                                                                                                    </Cthuvien:DR_lke>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Label24" runat="server" CssClass="css_gchu" Width="100px" Text="Loại tuyển dụng" />
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <table cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <Cthuvien:DR_lke ID="loai_td" kt_xoa="X" ten="Loại tuyển dụng" ktra="DT_LOAITD" runat="server"  Width="150px">                                                                                
                                                                                                                    </Cthuvien:DR_lke>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label8" runat="server" CssClass="css_gchu_c" Width="96px" Text="Chi phí TD" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:so ID="cphi_td" kieu_so="true" runat="server" ToolTip="Chi phí tuyển dụng" ten="Chi phí tuyển dụng" kt_xoa="G" CssClass="css_form_r"
                                                                                                                        Width="150px" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label3" runat="server" Text="Tuyển cho dự án" CssClass=" css_gchu_c" Width="96px"></asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="du_an" ten="Tuyển cho dự án" runat="server" CssClass="css_form" ToolTip="Tuyển cho dự án" Width="150px" kt_xoa="G" placeholder="Nhấn (F1)"
                                                                                                                        BackColor="#f6f7f7" f_tkhao="~/App_form/lamviec/ma/ns_ts_duan.aspx"
                                                                                                                        ktra="ns_ts_duan,ma,ten" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label9" runat="server" CssClass="css_gchu" Width="97px" Text="Có theo KH năm" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td align="left" style="width: 150px">
                                                                                                                    <Cthuvien:kieu ID="co_kehoach_nam" runat="server" onchange="ns_td_khct_P_KTRA('CO_KEHOACH_NAM');" lke=",X" Width="30px" kt_xoa="X" ToolTip="X - Theo kế hoạch năm,  - Không theo kế hoạch năm" CssClass="css_form_c" />
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    <asp:Label ID="Label16" runat="server" Text="Theo KH năm" CssClass=" css_gchu_c" Width="96px"></asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="theo_kehoach" disabled="disabled" runat="server" Width="150px" CssClass="css_form" placeholder="Nhấn (F1)"
                                                                                                                        BackColor="#f6f7f7" kieu_chu="true" ten="Theo kế hoạch năm" f_tkhao="~/App_form/ns/td/ns_td_kehoach_nam.aspx"
                                                                                                                        kt_xoa="X" ktra="ns_td_kehoach_nam,ma,ten" ToolTip="Theo kế hoạch năm" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label13" runat="server" CssClass="css_gchu_c" Width="96px" Text="Địa điểm làm việc" />

                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="diadiem_lv" ten="Địa điểm làm việc" runat="server" CssClass="css_form" ToolTip="Địa điểm làm việc" Width="149px" kt_xoa="G" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label6" runat="server" CssClass="css_gchu" Width="100px" Text="Đề xuất PA TD" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellpadding="0" cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td align="left">
                                                                                                                    <div style="height: 100px; width: 670px; overflow-y: scroll">
                                                                                                                        <Cthuvien:GridX ID="Gr_pa" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                                                                            CssClass="table gridX" loai="N" cot="sott,ma_pa,ten_pa" cotAn="sott,ma_pa" hangKt="6">
                                                                                                                            <Columns>
                                                                                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" ItemStyle-CssClass="css_Gma_c" />
                                                                                                                                <asp:BoundField HeaderText="STT" DataField="sott" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gnd" />
                                                                                                                                <asp:BoundField HeaderText="STT" DataField="ma_pa" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gnd" />
                                                                                                                                <asp:TemplateField HeaderText="Phương án đề xuất" HeaderStyle-Width="610px">
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <Cthuvien:ma ID="ten_pa" ktra="ns_ma_chung,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_chung.aspx" runat="server" guiId="phuong_an" kieu_chu="true" CssClass="css_Gma" kt_xoa="X" Width="610px" />
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                            </Columns>
                                                                                                                        </Cthuvien:GridX>
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label22" runat="server" Text="Đề xuất gấp" Width="100px" CssClass="css_gchu" />

                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellpadding="0" cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td style="width: 150px">
                                                                                                                    <Cthuvien:kieu ID="co_gap" runat="server" lke=",X" onfocusout="ns_td_khct_P_KTRA('CO_GAP');" Width="30px" kt_xoa="X" ToolTip="X - Đề xuất gấp,  - Không đề xuất gấp" CssClass="css_form_c" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label5" runat="server" CssClass="css_gchu_c" Width="100px" Text="Số ngày DX gấp" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="so_ngay_dx" disabled="disabled" ten="Số ngày đề xuất gấp" kieu_so="true" runat="server" CssClass="css_form_r" ToolTip="Số ngày đề xuất gấp" Width="150px" kt_xoa="G" />
                                                                                                                </td>
                                                                                                                <td></td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Label14" runat="server" CssClass="css_gchu" Width="97px" Text="Ngày DL dự kiến" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <div class="ip-group date">
                                                                                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_dl_dk" ten="Ngày đi làm dự kiến" runat="server"
                                                                                                                            CssClass="css_form_c" Width="124px" kt_xoa="G" />
                                                                                                                    </div>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label4" runat="server" Text="CV tối thiểu" CssClass=" css_gchu_c" Width="96px"></asp:Label>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:ma ID="cv_toithieu" kieu_so="true" ten="Số lượng hồ sơ tối thiểu" runat="server" CssClass="css_form" ToolTip="Số lượng hồ sơ tối thiểu" Width="150px" kt_xoa="G" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Label10" runat="server" CssClass="css_gchu" Width="97px" Text="Lý do tuyển dụng" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <Cthuvien:nd ID="lydo_td" ten="Lý do tuyển dụng" runat="server" kt_xoa="X" Height="30px"
                                                                                                                        CssClass="css_form" Width="673px" kieu_unicode="true" TextMode="MultiLine" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Width="120px" Text="Lương từ" Tolltip="Lương từ" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <Cthuvien:so so_tp="3" ID="LUONG_TU" kieu_so="true" runat="server" ten="Lương từ" kt_xoa="G" CssClass="css_form_r"
                                                                                                                        Width="150px" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:bbuoc ID="Bbuoc4" Width="96px" runat="server" CssClass="css_gchu_c" Text="Lương đến" Tolltip="Lương đến" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <Cthuvien:so so_tp="3" ID="LUONG_DEN" kieu_so="true" runat="server" ten="Lương đến" kt_xoa="G" CssClass="css_form_r"
                                                                                                                        Width="150px" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Label17" runat="server" CssClass="css_gchu" Width="97px" Text="Ghi chú" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <Cthuvien:nd ID="ghichu" ten="Mô tả công việc" runat="server" kt_xoa="X" Height="30px"
                                                                                                                        CssClass="css_form" Width="673px" kieu_unicode="true" TextMode="MultiLine" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="Label12" runat="server" Text="Trạng thái YC" Width="120px" CssClass="css_gchu" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td align="left">
                                                                                                                    <Cthuvien:DR_lke ID="trangthai_yc_pd" kt_xoa="X" ten="Trạng thái yêu cầu" ktra="DT_TRANGTHAI_YC_PD" runat="server"  Width="150px">                                                                                
                                                                                                                    </Cthuvien:DR_lke>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="Label27" runat="server" Text="Trạng thái PD" Width="96px" CssClass="css_gchu_c" />
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    <Cthuvien:DR_lke ID="trangthai_pd" kt_xoa="X" ten="Trạng thái PD" ktra="DT_TRANGTHAI_PD" runat="server"  Width="150px">                                                                                
                                                                                                                    </Cthuvien:DR_lke>
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
                                                    <asp:Panel ID="Pu_mtcv" runat="server" Style="display: none;" Height="420px" Width="800px">
                                                        <table cellpadding="0" cellspacing="0" style="padding-top: 15px">
                                                            <tr>
                                                                <td>
                                                                    <table cellpadding="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:GridX ID="Gr_mt" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                                    CssClass="table gridX" loai="N" cot="sott,tieuchi,yeucau_uv,md_qt" hangKt="6">
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" ItemStyle-CssClass="css_Gma_c" />
                                                                                        <asp:BoundField HeaderText="STT" DataField="sott" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gnd" />
                                                                                        <asp:BoundField HeaderText="Tiêu chí" DataField="tieuchi" HeaderStyle-Width="440px" ItemStyle-CssClass="css_Gnd" />
                                                                                        <asp:TemplateField HeaderText="Yêu cầu cụ thể đối với ứng viên" HeaderStyle-Width="130px">
                                                                                            <ItemTemplate>
                                                                                                <Cthuvien:ma ID="yeucau_uv" runat="server" CssClass="css_Gma" kt_xoa="X" Width="130px" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Mức độ quan trọng(tỷ trọng)%" HeaderStyle-Width="115px">
                                                                                            <ItemTemplate>
                                                                                                <Cthuvien:ma ID="md_qt" runat="server" CssClass="css_Gma" kt_xoa="G" Width="115px" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </Cthuvien:GridX>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <table cellpadding="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label21" runat="server" Text="Yêu cầu khác" Width="120px" CssClass="css_gchu" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <Cthuvien:nd ID="yc_khac" ten="Yêu cầu khác" runat="server" kt_xoa="X" Height="50px"
                                                                                                CssClass="css_form" Width="641px" kieu_unicode="true" TextMode="MultiLine" />
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
                                                    <asp:Panel ID="Pu_tlyc" runat="server" Style="display: none;" Height="420px" Width="800px">
                                                        <table cellspacing="0" style="padding-top: 15px;">
                                                            <tr>
                                                                <td>
                                                                    <table cellspacing="0">
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label18" runat="server" Text="Độ tuổi từ" Width="120px" CssClass="css_gchu" />
                                                                            </td>
                                                                            <td>
                                                                                <table cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="tuoi_tu" runat="server" CssClass="css_form" kieu_so="true" kt_xoa="G" ten="Độ tuổi từ" ToolTip="Độ tuổi từ" Width="155px" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label19" runat="server" Text="Độ tuổi đến" CssClass=" css_gchu_c" Width="120px"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="tuoi_den" ten="Độ tuổi đến" kieu_so="true" runat="server" CssClass="css_form" ToolTip="Độ tuổi đến" Width="155px" kt_xoa="G" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label23" runat="server" Text="Chiều cao" Width="120px" CssClass="css_gchu" />
                                                                            </td>
                                                                            <td>
                                                                                <table cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="chieu_cao" runat="server" CssClass="css_form" kt_xoa="G" ten="Chiều cao" ToolTip="Chiều cao" Width="155px" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label20" runat="server" Text="Cân nặng" Width="120px" CssClass="css_gchu_c" />
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="can_nang" ten="Cân nặng" runat="server" CssClass="css_form" ToolTip="Cân nặng" Width="155px" kt_xoa="G" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label28" runat="server" Text="Giới tính" Width="120px" CssClass="css_gchu" />
                                                                            </td>
                                                                            <td>
                                                                                <table cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <Cthuvien:DR_lke ID="gioi_tinh" kt_xoa="X" ten="Giới tính" ktra="DT_GIOI_TINH" runat="server"  Width="155px">                                                                                
                                                                                            </Cthuvien:DR_lke>
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
                                                    <asp:Panel ID="Pu_cttt" runat="server" Style="display: none;" Height="420px" Width="800px">
                                                        <table id="UPa_cttt" cellspacing="0" style="padding-top: 15px;">
                                                            <tr>
                                                                <td>
                                                                    <table cellpadding="0">
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label29" runat="server" Text="Vòng 1" Width="120px" CssClass="css_gchu" />
                                                                            </td>
                                                                            <td>
                                                                                <table cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="vong1" runat="server" CssClass="css_form" kt_xoa="G" ten="Vòng 1" ToolTip="Vòng 1" Width="150px" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label30" runat="server" Text="Vòng 2" CssClass=" css_gchu_c" Width="90px"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="vong2" ten="Vòng 2" runat="server" CssClass="css_form" ToolTip="Vòng 2" Width="150px" kt_xoa="G" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label34" runat="server" Text="Vòng 3" CssClass=" css_gchu_c" Width="90px"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="vong3" ten="Vòng 3" runat="server" CssClass="css_form" ToolTip="Vòng 3" Width="150px" kt_xoa="G" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label31" runat="server" Text="Thang điểm" Width="120px" CssClass="css_gchu" />
                                                                            </td>
                                                                            <td>
                                                                                <table cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="tdiem1" runat="server" CssClass="css_form" kieu_so="true" kt_xoa="G" ten="Thang điểm" ToolTip="Thang điểm" Width="150px" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label32" runat="server" Text="Thang điểm" Width="90px" CssClass="css_gchu_c" />
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="tdiem2" ten="Cân nặng" kieu_so="true" runat="server" CssClass="css_form" ToolTip="Thang điểm" Width="150px" kt_xoa="G" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="tdiem32" runat="server" Text="Thang điểm" Width="90px" CssClass="css_gchu_c" />
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="tdiem3" ten="Thang điểm" kieu_so="true" runat="server" CssClass="css_form" ToolTip="Thang điểm" Width="150px" kt_xoa="G" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label15" runat="server" Text="Điểm đạt" Width="120px" CssClass="css_gchu" />
                                                                            </td>
                                                                            <td>
                                                                                <table cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="diem_dat1" runat="server" CssClass="css_form" kieu_so="true" kt_xoa="G" ten="Điểm đạt" ToolTip="Điểm đạt" Width="150px" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label35" runat="server" Text="Điểm đạt" Width="90px" CssClass="css_gchu_c" />
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="diem_dat2" ten="Điểm đạt" kieu_so="true" runat="server" CssClass="css_form" ToolTip="Điểm đạt" Width="150px" kt_xoa="G" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label42" runat="server" Text="Điểm đạt" Width="90px" CssClass="css_gchu_c" />
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="diem_dat3" ten="Điểm đạt" kieu_so="true" runat="server" CssClass="css_form" ToolTip="Điểm đạt" Width="150px" kt_xoa="G" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label36" runat="server" Text="CB phỏng vấn 1" Width="120px" CssClass="css_gchu" />
                                                                            </td>
                                                                            <td>
                                                                                <table cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="canbo_pv1" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true" placeholder="Nhấn (F1)"
                                                                                                f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" onchange="ns_td_khct_P_KTRA('CANBO_PV1')" ktra="ns_cb,so_the,ten"
                                                                                                kt_xoa="G" ten="CB phỏng vấn 1" ToolTip="CB phỏng vấn 1" Width="150px" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label37" runat="server" Text="CB phỏng vấn 2" Width="90px" CssClass="css_gchu_c" />
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="canbo_pv2" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true" placeholder="Nhấn (F1)"
                                                                                                f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" onchange="ns_td_khct_P_KTRA('CANBO_PV2')" ktra="ns_cb,so_the,ten"
                                                                                                kt_xoa="G" ten="CB phỏng vấn 2" ToolTip="CB phỏng vấn 2" Width="150px" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label38" runat="server" Text="CB phỏng vấn 3" Width="90px" CssClass="css_gchu_c" />
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="canbo_pv3" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true" placeholder="Nhấn (F1)"
                                                                                                f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" onchange="ns_td_khct_P_KTRA('CANBO_PV3')" ktra="ns_cb,so_the,ten"
                                                                                                kt_xoa="G" ten="CB phỏng vấn 3" ToolTip="CB phỏng vấn 3" Width="150px" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label39" runat="server" Text="CD cán bộ PV 1" Width="120px" CssClass="css_gchu" />
                                                                            </td>
                                                                            <td>
                                                                                <table cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="cdanh_cb1" runat="server" BackColor="#f6f7f7" CssClass="css_form" kt_xoa="G" ten="Chức danh cán bộ PV 1" ToolTip="Chức danh cán bộ PV 1" Width="150px" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label40" runat="server" Text="CD cán bộ PV 2" Width="90px" CssClass="css_gchu_c" />
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="cdanh_cb2" ten="CD cán bộ PV 2" BackColor="#f6f7f7" runat="server" CssClass="css_form" ToolTip="Chức danh cán bộ PV 2" Width="150px" kt_xoa="G" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label41" runat="server" Text="CD cán bộ PV 3" Width="90px" CssClass="css_gchu_c" />
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <Cthuvien:ma ID="cdanh_cb3" ten="CD cán bộ PV 3" BackColor="#f6f7f7" runat="server" CssClass="css_form" ToolTip="Chức danh cán bộ PV 3" Width="150px" kt_xoa="G" />
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="css_border" align="left">
                                                    <div id="UPa_gchu">
                                                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table id="UPa_nhap" cellpadding="1" cellspacing="1" class="tableButton">
                                                        <tr>
                                                            <td>
                                                                <div class="box3 txRight">
                                                                    <a href="#" onclick="return ns_td_khct_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                                    <a href="#" class="bt bt-grey" onclick="return ns_td_khct_P_PHEDUYET('1');form_P_LOI();"><i class="fa fa-trashs-o"></i><span class="txUnderline"></span>Phê duyệt</a>
                                                                    <a href="#" onclick="return ns_td_khct_P_EXCEL();form_P_LOI();" class="bt bt-grey"><i class="fa fa-file-excel-o"></i>Xuất excel</a>
                                                                    <a href="#" onclick="return form_P_TRA_CHON('MA,PHONG_YC,CDANH,SL_CANTUYEN');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="display: none">
                                                                <Cthuvien:nhap ID="Xuatexcel" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuatexcel_Click" />
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
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="ps" runat="server" value="NS" />
        <Cthuvien:an ID="nv" runat="server" value="TT" />
        <Cthuvien:an ID="Thangtk" runat="server" value="" />
        <Cthuvien:an ID="phongtk" runat="server" value="" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1260,800" />
        <Cthuvien:an ID="phuong_an" runat="server" value="PHUONG_AN" />
    </div>
</asp:Content>