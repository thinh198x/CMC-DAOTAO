<%@ Page Title="ns_td_ungvien_nv_pd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_ungvien_nv_pd.aspx.cs" Inherits="f_ns_td_ungvien_nv_pd" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_ttt.ascx" TagName="khud_ttt" TagPrefix="khud_ttt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%" style="background-color: #f4f6f8">
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="0" style="padding-left: 10px">
                    <tr>
                        <td align="right" colspan="2">
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu2" runat="server" CssClass="css_tieudeM" Text="Phê duyệt ứng viên thành nhân viên" />
                                    </td>
                                    <td align="right">
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
                                                <asp:Panel ID="Pa_ch" runat="server" Style="height: 500px; display: block;">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="center">
                                                                <table id="Upa_tk" cellpadding="1" cellspacing="1">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label26" runat="server" Width="100px" Text="Năm" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:ma ID="nam_tk" ten="Năm" kieu_so="true" runat="server" kt_xoa="K" CssClass="css_form_r" Width="140px" />
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label2" runat="server" Width="100px" Text="Vị trí tuyển dụng" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:ma ID="cdanh_tk" placeholder="Nhấn (F1)" runat="server" CssClass="css_form" kieu_chu="True" kt_xoa="G"
                                                                                ToolTip="Ví trí tuyển dụng" ktra="ns_ma_cdanh,ma,ten" gchu="gchu" f_tkhao="~/App_form/ns/hdns/tl/ns_ma_cdanh.aspx" BackColor="#f6f7f7" Width="140px" ten="Mã yêu cầu TD" onchange="ns_td_ungvien_nv_pd_P_KTRA('CDANH')" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Text="Từ ngày" Width="100px" />
                                                                        </td>
                                                                        <td>
                                                                            <div class="ip-group date">
                                                                                <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd_tk" ten="ngày yêu cầu" runat="server"
                                                                                    CssClass="css_form_c" Width="113px" kt_xoa="G" />
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label4" runat="server" Width="100px" Text="Đến ngày" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td>
                                                                            <div class="ip-group date">
                                                                                <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc_tk" ten="ngày yêu cầu" runat="server"
                                                                                    CssClass="css_form_c" Width="113px" kt_xoa="G" />
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label11" runat="server" CssClass="css_gchu" Text="Mã yêu cầu TD" Width="100px" />
                                                                        </td>
                                                                        <td>

                                                                            <Cthuvien:ma ID="ma_yc_tk" runat="server" BackColor="#f6f7f7" CssClass="css_form" f_tkhao="~/App_form/ns/td/ns_td_khct.aspx" gchu="gchu" kieu_chu="True" kt_xoa="G" ktra="ns_td_khct,ma,ma" onchange="ns_td_ungvien_nv_pd_P_KTRA('MA_YC_TK')" placeholder="Nhấn (F1)" ten="Mã yêu cầu TD" ToolTip="Mã yêu cầu tìm kiếm" Width="140px" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Text="Trạng thái phê duyệt" Width="100px" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:DR_lke ID="trangthai_pd" ten="Trạng thái phê duyệt" ktra="trangthai_pd" runat="server" CssClass="css_list" Width="140px">                                                                                
                                                                            </Cthuvien:DR_lke>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left"></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td style="padding-bottom:10px; padding-top:5px;">
                                                                            <a href="#" onclick="return ns_td_ungvien_nv_pd_P_LKE('M');form_P_LOI();" class="bt bt-grey"><i class="fa fa-search"></i>Tìm kiếm</a>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                    CssClass="table gridX" loai="X" hangKt="11" cot="sott,so_the,ten,nam,ma_yc,cdanh,phong_yc,ngay_bd,trangthai_pd" cotAn="so_id">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                        <asp:BoundField HeaderText="T.tự" DataField="sott" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                                                        <asp:BoundField HeaderText="Mã ứng viên" DataField="so_the" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                                                        <asp:BoundField HeaderText="Tên ứng viên" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                                                        <asp:BoundField HeaderText="Mã YCTD" DataField="ma_yc" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Vị trí tuyển dụng" DataField="cdanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Bộ phận yêu cầu" DataField="phong_yc" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Ngày đi làm dự kiến" DataField="ngay_bd" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                                                        <asp:BoundField HeaderText="Trạng thái phê duyệt" DataField="trangthai_pd" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                                    </Columns>
                                                                </Cthuvien:GridX>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td id="GR_lke_td" runat="server" align="center" style="padding-right: 10px;">
                                                                <khud_slide:khud_slide ID="GR_lke_slide" runat="server" rong="200" loai="X" gridId="GR_lke"
                                                                    ham="ns_td_ungvien_nv_pd_P_LKE('L')" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" style="padding-top: 20px; ">
                                                                <a href="#" onclick="return ns_td_ungvien_nv_pd_P_PHEDUYET();form_P_LOI();" class="bt bt-grey"><i class="fa fa-grey"></i>Phê duyệt</a>
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
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="ps" runat="server" value="NS" />
        <Cthuvien:an ID="nv" runat="server" value="TT" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1100,720" />
        <Cthuvien:an ID="cthuc_td" runat="server" value="CTHUC_TD" />
    </div>
</asp:Content>
