<%@ Page Title="hd_ma_quyluong" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="hd_ma_quyluong.aspx.cs" Inherits="f_hd_ma_quyluong" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thiết lập quỹ lương" />
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
                        <td align="left" valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="18" cotAn="dvi,ma_cdanh,ns_ht,db_tb,db_ncong,db_ncong_td,tong_db_ncong,db_them_ncong,db_gio_td,db_tgio_tong,thuong_dnam,thuong_td,thuong_tong,db_ploi_td,quy_BHXH,quy_BHXH_TD,tong_BHXH,cd_td,quyl_tong,db_pc,db_pc_td,db_pc_td_tong,db_pl,db_pl_tong,quy_cd,quy_cd_tong,ghichu,nsd,so_id" 
                                            hamRow="hd_ma_quyluong_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Năm" DataField="nam_db" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Đơn vị" DataField="ten_dvi" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField DataField="dvi"></asp:BoundField>
                                                <asp:BoundField DataField="ma_cdanh"></asp:BoundField>
                                                <asp:BoundField DataField="ns_ht"></asp:BoundField>
                                                <asp:BoundField DataField="db_tb"></asp:BoundField>
                                                <asp:BoundField DataField="db_ncong"></asp:BoundField>
                                                <asp:BoundField DataField="db_ncong_td"></asp:BoundField>
                                                <asp:BoundField DataField="tong_db_ncong"></asp:BoundField>
                                                <asp:BoundField DataField="db_them_ncong"></asp:BoundField>
                                                <asp:BoundField DataField="db_gio_td"></asp:BoundField>
                                                <asp:BoundField DataField="db_tgio_tong"></asp:BoundField>
                                                <asp:BoundField DataField="thuong_dnam"></asp:BoundField>
                                                <asp:BoundField DataField="thuong_td"></asp:BoundField>
                                                <asp:BoundField DataField="thuong_tong"></asp:BoundField>
                                                <asp:BoundField DataField="db_ploi_td"></asp:BoundField>
                                                <asp:BoundField DataField="quy_BHXH"></asp:BoundField>
                                                <asp:BoundField DataField="quy_BHXH_TD"></asp:BoundField>
                                                <asp:BoundField DataField="tong_BHXH"></asp:BoundField>
                                                <asp:BoundField DataField="cd_td"></asp:BoundField>
                                                <asp:BoundField DataField="quyl_tong"></asp:BoundField>
                                                <asp:BoundField DataField="db_pc"></asp:BoundField>
                                                <asp:BoundField DataField="db_pc_td"></asp:BoundField>
                                                <asp:BoundField DataField="db_pc_td_tong"></asp:BoundField>
                                                <asp:BoundField DataField="db_pl"></asp:BoundField>
                                                <asp:BoundField DataField="db_pl_tong"></asp:BoundField>
                                                <asp:BoundField DataField="quy_cd"></asp:BoundField>
                                                <asp:BoundField DataField="quy_cd_tong"></asp:BoundField>
                                                <asp:BoundField DataField="ghichu"></asp:BoundField>
                                                <asp:BoundField DataField="nsd"></asp:BoundField>
                                                <asp:BoundField DataField="so_id"></asp:BoundField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="hd_ma_quyluong_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" style="text-align: left;" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td style="height: 36px">
                                        <Cthuvien:bbuoc  ID="Label15" runat="server" Text="Năm" Width="180px" CssClass="css_gchu"></Cthuvien:bbuoc>
                                        
                                    </td>
                                    <td style="height: 36px">
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    
                                                    <Cthuvien:DR_lke ID="NAM_DB" ktra="DT_NAM" ten="năm" ToolTip="Năm định biên" runat="server" Width="160px" CssClass="css_form" />
                                                    
                                                    <%--<Cthuvien:ma ID="nam_db" runat="server" CssClass="css_form" kieu_chu="true" kt_xoa="X" placeholder="Nhấn (F1)"
                                                         BackColor="#f6f7f7" gchu="gchu" Width="160px" 
                                                        />--%>
                                                </td>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label13" runat="server" Text="Đơn vị" CssClass="css_gchu_c" Width="180px"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="DVI" runat="server" CssClass="css_form" kieu_chu="True" ten="Đơn vị" BackColor="#f6f7f7" ktra="ht_ma_phong,ma,ten" placeholder="Nhấn (F1)"
                                                        f_tkhao="~/App_form/ht/ht_maph.aspx" MaxLength="30" kt_xoa="X" onfocusout="hd_ma_quyluong_P_KTRA('DVI')" Width="160px"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label1" runat="server" Text="Vị trí chức danh" Width="180px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="MA_CDANH" runat="server" CssClass="css_form" kieu_chu="true" kt_xoa="X" placeholder="Nhấn (F1)"
                                                         BackColor="#f6f7f7" ten="Mã chức danh" guiId="DVI" f_tkhao="~/App_form/ns/hdns/tl/hd_cdanh_dvi.aspx" onfocusout="hd_ma_quyluong_P_KTRA('MA_CDANH')"
                                                        gchu="gchu" Width="160px" ktra="ht_ma_phong,ma,ten" ToolTip="Vị trí chức danh" />
                                                </td>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" Text="Số lượng nhân sự hiện tại" CssClass="css_gchu_c" Width="180px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ns_ht" runat="server" CssClass="css_form" kt_xoa="X" 
                                                         BackColor="#f6f7f7" Enabled="false"
                                                        gchu="gchu" Width="160px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" ToolTip="Số lượng định biên trung bình" Text="S.lượng đ.biên TB" Width="180px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="db_tb" runat="server" CssClass="css_form" kieu_chu="true" kt_xoa="X"
                                                         BackColor="#f6f7f7"
                                                        gchu="gchu" Width="160px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Quỹ thưởng đầu năm" CssClass="css_gchu_c" Width="180px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="thuong_dnam" runat="server" CssClass="css_form" kt_xoa="X" Width="160px"
                                                        so_tp="2" ToolTip="Hệ số phụ cấp"  co_dau="K"   onfocusout="hd_ma_quyluong_P_KTRA('THUONG_DNAM,THUONG_TD=THUONG_TONG')" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" ToolTip="Quỹ lương định biên theo ngày công đầu năm" Text="Qlđb theo ngày công đầu năm" Width="180px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="db_ncong" runat="server" CssClass="css_form" kieu_chu="true" kt_xoa="X"
                                                         gchu="gchu" Width="160px" onfocusout="hd_ma_quyluong_P_KTRA('DB_NCONG,DB_NCONG_TD=TONG_DB_NCONG')"
                                                         co_dau="K" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Quỹ thưởng thay đổi" CssClass="css_gchu_c" Width="180px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="thuong_td" runat="server" CssClass="css_form" kt_xoa="X" Width="160px"
                                                        so_tp="2" ToolTip="Hệ số phụ cấp" co_dau="K"  onfocusout="hd_ma_quyluong_P_KTRA('THUONG_DNAM,THUONG_TD=THUONG_TONG')" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Qlđb theo ngày công thay đổi" ToolTip="Quỹ lương định biên theo ngày công thay đổi" Width="180px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="db_ncong_td" runat="server" CssClass="css_form" kt_xoa="X" co_dau="K"
                                                         gchu="gchu" Width="160px" onfocusout="hd_ma_quyluong_P_KTRA('DB_NCONG,DB_NCONG_TD=TONG_DB_NCONG')" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Tổng quỹ thưởng" CssClass="css_gchu_c" Width="180px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="thuong_tong" runat="server" CssClass="css_form"  kt_xoa="X"
                                                         BackColor="#f6f7f7" Enabled="false"
                                                        gchu="gchu" Width="160px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Tổng qlđb theo ngày công" ToolTip="Tổng quỹ lương định biên theo ngày công" Width="180px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="tong_db_ncong" runat="server" CssClass="css_form" Enabled="false" kt_xoa="X"
                                                         BackColor="#f6f7f7"
                                                        gchu="gchu" Width="160px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" Text="Định biên phụ cấp" CssClass="css_gchu_c" Width="180px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="db_pc" runat="server" CssClass="css_form" kt_xoa="X" Width="160px" co_dau="K"
                                                        so_tp="2" ToolTip="Hệ số phụ cấp"  onfocusout="hd_ma_quyluong_P_KTRA('DB_PC,DB_PC_TD=DB_PC_TD_TONG')"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" ToolTip="Quỹ lương làm thêm giờ định biên đầu năm" Text="Q.lương làm thêm ĐB đầu năm" Width="180px" CssClass="css_gchu" Height="16px" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="db_them_ncong" runat="server" CssClass="css_form" kieu_chu="true" kt_xoa="X" co_dau="K"
                                                         gchu="gchu" Width="160px"  onfocusout="hd_ma_quyluong_P_KTRA('DB_THEM_NCONG,DB_GIO_TD=DB_TGIO_TONG')" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label12" runat="server" Text="Định biên phụ cấp thay đổi" CssClass="css_gchu_c" Width="180px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="db_pc_td" runat="server" CssClass="css_form" kt_xoa="X" Width="160px" co_dau="K"
                                                        so_tp="2" ToolTip="Hệ số phụ cấp"  onfocusout="hd_ma_quyluong_P_KTRA('DB_PC,DB_PC_TD=DB_PC_TD_TONG')" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="Q.lương làm thêm ĐB thay đổi" ToolTip="Quỹ lương làm thêm giờ ĐB thay đổi" Width="180px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="db_gio_td" runat="server" CssClass="css_form" kieu_chu="true" kt_xoa="X" co_dau="K"
                                                         gchu="gchu" Width="160px"   onfocusout="hd_ma_quyluong_P_KTRA('DB_THEM_NCONG,DB_GIO_TD=DB_TGIO_TONG')"/>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label16" runat="server" Text="Tổng định biên phụ cấp" CssClass="css_gchu_c" Width="180px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="db_pc_td_tong" runat="server" CssClass="css_form" kt_xoa="X" 
                                                         BackColor="#f6f7f7" Enabled="false"
                                                        gchu="gchu" Width="160px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label17" runat="server" Text="Tổng lương làm thêm giờ ĐB" ToolTip="Tổng lương làm thêm giờ ĐB" Width="180px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="db_tgio_tong" runat="server" CssClass="css_form" kt_xoa="X" 
                                                         BackColor="#f6f7f7" Enabled="false"
                                                        gchu="gchu" Width="160px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label18" runat="server" Text="Định biên phúc lợi" CssClass="css_gchu_c" Width="180px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="db_pl" runat="server" CssClass="css_form" kt_xoa="X" Width="160px"
                                                        so_tp="2" ToolTip="Hệ số phụ cấp"  co_dau="K"  onfocusout="hd_ma_quyluong_P_KTRA('DB_PL,DB_PLOI_TD=DB_PL_TONG')"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label19" runat="server" Text="Định biên phúc lợi thay đổi" ToolTip="Định biên phúc lợi thay đổi" Width="180px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="db_ploi_td" runat="server" CssClass="css_form" kieu_chu="true" kt_xoa="X"
                                                         gchu="gchu" Width="160px" co_dau="K" onfocusout="hd_ma_quyluong_P_KTRA('DB_PL,DB_PLOI_TD=DB_PL_TONG')"/>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label20" runat="server" Text="Tổng định biên phúc lợi" CssClass="css_gchu_c" Width="180px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="db_pl_tong" runat="server" CssClass="css_form" kt_xoa="X" 
                                                         BackColor="#f6f7f7" Enabled="false" 
                                                        gchu="gchu" Width="160px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label21" runat="server" Text="Quỹ BHXH" ToolTip="Quỹ bảo hiểm xã hội" Width="180px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="quy_bhxh" runat="server" CssClass="css_form" kieu_chu="true" kt_xoa="X"
                                                        gchu="gchu" Width="160px" co_dau="K" onfocusout="hd_ma_quyluong_P_KTRA('QUY_BHXH,QUY_BHXH_TD=TONG_BHXH')" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label22" runat="server" Text="Quỹ BHXH thay đổi" CssClass="css_gchu_c" Width="180px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="quy_bhxh_td" runat="server" CssClass="css_form" kt_xoa="X" Width="160px"
                                                        so_tp="2" ToolTip="Hệ số phụ cấp" co_dau="K"  onfocusout="hd_ma_quyluong_P_KTRA('QUY_BHXH,QUY_BHXH_TD=TONG_BHXH')" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label23" runat="server" Text="Tổng BHXH" Width="180px" ToolTip="Tổng bảo hiểm xã hội" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="tong_bhxh" runat="server" CssClass="css_form" kt_xoa="X" 
                                                         BackColor="#f6f7f7" Enabled="false"
                                                        gchu="gchu" Width="160px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label24" runat="server" Text="Quỹ kinh phí CĐ" CssClass="css_gchu_c" Width="180px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="quy_cd" runat="server" CssClass="css_form" kt_xoa="X" Width="160px"
                                                        so_tp="2" ToolTip="Hệ số phụ cấp" co_dau="K"   onfocusout="hd_ma_quyluong_P_KTRA('QUY_CD,CD_TD=QUY_CD_TONG')" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label25" runat="server" Text="Quỹ kinh phí CĐ thay đổi" ToolTip="Quỹ kinh phí CĐ thay đổi" Width="180px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="cd_td" runat="server" CssClass="css_form" kieu_chu="true" kt_xoa="X"
                                                        gchu="gchu" Width="160px"   onfocusout="hd_ma_quyluong_P_KTRA('QUY_CD,CD_TD=QUY_CD_TONG')" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label26" runat="server" Text="Tổng quỹ kinh phí CĐ" CssClass="css_gchu_c" Width="180px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:so ID="quy_cd_tong" runat="server" CssClass="css_form" kt_xoa="X" 
                                                         BackColor="#f6f7f7" Enabled="false"
                                                        gchu="gchu" Width="160px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label27" runat="server" Text="Tổng quỹ lương" Width="180px" ToolTip="Tổng quỹ lương" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:so ID="quyl_tong" runat="server" CssClass="css_form" kt_xoa="X" 
                                                         BackColor="#f6f7f7"  Enabled="false"
                                                        gchu="gchu" Width="160px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label28" runat="server" Text="Ghi chú" CssClass="css_gchu_c" Width="180px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nd ID="ghichu" ten="Ghi chú" TextMode="MultiLine" Height="50px" runat="server" CssClass="css_form" kieu_unicode="True"
                                                        kt_xoa="X" Width="160px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                    </td>
                                    <td>
                                        <Cthuvien:so ID="so_id" runat="server" CssClass="css_form hiden" kieu_chu="true" kt_xoa="X"
                                                        gchu="gchu" Width="160px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" runat="server" class="box3 txRight">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return hd_ma_quyluong_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return hd_ma_quyluong_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                       <a href="#" class="bt bt-grey" onclick="return hd_ma_quyluong_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return hd_ma_quyluong_P_IN();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">X</span>uất excel</a>
                                                    </div>
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div id="UPa_gchu" class="css_border" align="left" style="height: 19px">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                    <%--<tr>
                        <td colspan="2" class="css_border" align="left" style="height: 19px">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1260,760" />
</asp:Content>
