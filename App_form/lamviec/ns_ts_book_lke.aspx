<%@ Page Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true" CodeFile="ns_ts_book_lke.aspx.cs" Inherits="f_ns_ts_book_lke" Title="ns_ts_book_lke" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table id="UPa_ct" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh sách book nhân sự" />
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
                        <td class="form_right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label45" runat="server" CssClass="css_gchu" Text="Loại công việc" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="loai_tk" runat="server" CssClass="css_form" Width="206px">
                                                        <asp:ListItem Text="Tất cả" Value="TC" />
                                                        <asp:ListItem Text="Giao" Value="G" />
                                                        <asp:ListItem Text="Nhận" Value="N" />
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label8" runat="server" CssClass="css_gchu_c" Text="Tình trạng giao" Width="120px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="tt_giao" runat="server" CssClass="css_form" Width="206px">
                                                        <asp:ListItem Text="Tất cả" Value="TC" />
                                                        <asp:ListItem Text="Chưa xác nhận" Value="CXN" />
                                                        <asp:ListItem Text="Xác nhận" Value="XN" />
                                                        <asp:ListItem Text="Hủy bỏ" Value="TC" />
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server" CssClass="css_gchu_c" Text="Tình trạng nhận" Width="120px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_nhap ID="tt_nhan" runat="server" CssClass="css_form" Width="206px">
                                                        <asp:ListItem Text="Tất cả" Value="TC" />
                                                        <asp:ListItem Text="Chưa xác nhận" Value="CXN" />
                                                        <asp:ListItem Text="Xác nhận" Value="XN" />
                                                        <asp:ListItem Text="Từ chối" Value="TC" />
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Text="Từ ngày" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="tu_ngay_tk" runat="server" CssClass="css_form_c" Width="180px" kt_xoa="Z"
                                                            ten="Từ ngày" kieu_luu="I" kieu_date="true" />
                                                    </div>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="css_gchu_c" Text="Đến ngày" Width="120px" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="den_ngay_tk" runat="server" CssClass="css_form_c" Width="180px" kt_xoa="Z"
                                                            ten="Tới ngày" kieu_luu="I" kieu_date="true" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left">
                                        <div class="box3 txLeft">
                                            <a href="#" onclick="return ns_ts_bookns_P_LKE(false);" class="bt bt-grey"><i class="fa fa-search"></i><span class="txUnderline">T</span>ìm kiếm</a>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding-top: 2px">
                                        <table>
                                            <tr>
                                                <td>
                                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" cot="nd,mo_ta,nsd,ng_nhan,ten_nsd,ten_ng_nhan,tong_gio,ngay_dk_ht,tt_giao,tt_nhan,so_id" cotAn="so_id,nsd,ng_nhan" CssClass="table gridX" loai="X" hangKt="15" hamRow="ns_ts_GR_lke_RowChange(event)">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:BoundField HeaderText="Công việc" DataField="nd" HeaderStyle-Width="250px" ItemStyle-CssClass="css_ma" />
                                                            <asp:BoundField HeaderText="Mô tả" DataField="mo_ta" HeaderStyle-Width="250px" ItemStyle-CssClass="css_ma" />
                                                            <asp:BoundField HeaderText="Người giao" DataField="nsd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_ma_c" />
                                                            <asp:BoundField HeaderText="Người nhận" DataField="ng_nhan" HeaderStyle-Width="100px" ItemStyle-CssClass="css_ma_c" />
                                                            <asp:BoundField HeaderText="Người giao" DataField="ten_nsd" HeaderStyle-Width="150px" ItemStyle-CssClass="css_ma_c" />
                                                            <asp:BoundField HeaderText="Người nhận" DataField="ten_ng_nhan" HeaderStyle-Width="150px" ItemStyle-CssClass="css_ma_c" />
                                                            <asp:BoundField HeaderText="Tổng giờ" DataField="tong_gio" HeaderStyle-Width="60px" ItemStyle-CssClass="css_so" />
                                                            <asp:BoundField HeaderText="Ngày hoàn thành" DataField="ngay_dk_ht" HeaderStyle-Width="90px" ItemStyle-CssClass="css_ma_c" />
                                                            <asp:BoundField HeaderText="Tình trạng giao" DataField="tt_giao" HeaderStyle-Width="120px" ItemStyle-CssClass="css_ma_c" />
                                                            <asp:BoundField HeaderText="Tình trạng nhận" DataField="tt_nhan" HeaderStyle-Width="120px" ItemStyle-CssClass="css_ma_c" />
                                                            <asp:BoundField HeaderText="so id" DataField="so_id" HeaderStyle-Width="120px" ItemStyle-CssClass="css_ma_c" />
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" id="GR_lke_td" runat="server">
                                                    <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="150" gridId="GR_lke" ham="ns_ts_gv_P_LKE()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0"></table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" id="Upa_bt">
                <table cellpadding="0" cellspacing="1">
                    <tr>
                        <td>
                            <div class="box3 txRight2">
                                <a href="#" onclick="return ns_ts_gv_P_MO_GV(true,'CT');" class="bt bt-grey"><span class="txUnderline">C</span>hi tiết</a>
                                <a href="#" onclick="return ns_ts_TRDOI();" class="bt bt-grey"><span class="txUnderline">T</span>rao đổi</a>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="X" />
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1350,650" />
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="id_ct" runat="server" value="0" />
        <Cthuvien:an ID="id_cut" runat="server" value="0" />
        <Cthuvien:an ID="id_ts" runat="server" value="0" />
    </div>
    <div style="position: absolute; left: 300px; top: 70px;">
        <asp:Panel ID="pan_giaoviec" runat="server">
            <table id="tab_pgiaoviec" runat="server" cellpadding="1" cellspacing="13" style="border: 1px solid #C0C0C0; background-color: #E9E9D1; display: none; width: 500px;">
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" CssClass="css_phude" Text="Book" />
                    </td>
                    <td align="right">
                        <img id="Img5" runat="server" alt="" src="~/images/bitmaps/dong.png" onclick="return ns_ts_gv_P_MO_GV(false);" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table cellpadding="1" cellspacing="1">
                            <tr>
                                <td align="left">

                                    <asp:Label ID="Label7" runat="server" CssClass="css_gchu" Text="Nhân viên" Width="100px" />
                                </td>
                                <td align="left">
                                    <Cthuvien:DR_nhap ID="ng_nhan" runat="server" CssClass="css_drop" Width="206px"
                                        DataTextField="ten" DataValueField="ma" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Bbuoc12" runat="server" CssClass="css_gchu" Text="Vị trí" Width="100px" />
                                </td>
                                <td align="left">
                                    <Cthuvien:DR_nhap ID="vi_tri" runat="server" CssClass="css_drop" Width="206px"
                                        DataTextField="ten" DataValueField="ma" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Bbuoc7" runat="server" CssClass="css_gchu" Text="Loại công việc" Width="100px" />
                                </td>
                                <td align="left">
                                    <Cthuvien:DR_nhap ID="nhom_viec" runat="server" CssClass="css_drop" Width="206px"
                                        DataTextField="ten" DataValueField="ma" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Bbuoc4" runat="server" CssClass="css_gchu" Text="Dự án" Width="100px" />
                                </td>
                                <td align="left">
                                    <Cthuvien:DR_nhap ID="ma_du_an" runat="server" CssClass="css_drop" Width="250px"
                                        DataTextField="ten" DataValueField="ma" onchange="return ns_ts_timkiem_anhien();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Bbuoc8" runat="server" CssClass="css_gchu" Text="Độ ưu tiên" Width="100px" />
                                </td>
                                <td align="left">
                                    <Cthuvien:DR_nhap ID="uu_tien" runat="server" CssClass="css_drop" Width="206px"
                                        DataTextField="ten" DataValueField="ma" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Kỹ năng" Width="100px" />
                                </td>
                                <td align="left">
                                    <Cthuvien:DR_nhap ID="skill" runat="server" CssClass="css_drop" Width="206px"
                                        DataTextField="ten" DataValueField="ma" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Tổng giờ" Width="100px" />
                                </td>
                                <td align="left">
                                    <Cthuvien:so ID="tong_gio" runat="server" CssClass="css_so_c" Width="50px" co_dau="K" so_tp="0" ToolTip="" MaxLength="2" kt_xoa="X" />

                                </td>
                            </tr>

                            <tr id="hien_nganhan" runat="server">
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Text="Từ giờ" Width="100px" />
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="left">
                                                <Cthuvien:ma ID="tu_gio" runat="server" CssClass="css_ma_c" Width="80px" ToolTip="" kt_xoa="X" />
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label9" runat="server" CssClass="css_gchu_c" Text="Tới giờ" Width="100px" />
                                            </td>
                                            <td align="left">
                                                <Cthuvien:ma ID="toi_gio" runat="server" CssClass="css_ma_c" Width="80px" ToolTip="" kt_xoa="X" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="hien_daihan" runat="server" style="display: none">
                                <td align="left">
                                    <asp:Label ID="Label10" runat="server" CssClass="css_gchu" Text="Từ ngày" Width="100px" />
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="left">
                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="tu_ngay" runat="server" CssClass="css_ngay" Width="80px" ToolTip="" kt_xoa="X" />
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label11" runat="server" CssClass="css_gchu_c" Text="Tới ngày" Width="100px" />
                                            </td>
                                            <td align="left">
                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="toi_ngay" runat="server" CssClass="css_ma_c" Width="80px" ToolTip="" kt_xoa="X" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Bbuoc3" runat="server" CssClass="css_gchu" Text="Dự kiến hoàn thành" Width="110px" />
                                </td>
                                <td align="left">
                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_dk_ht" runat="server" CssClass="css_ngay" Width="200px" kt_xoa="X"
                                        ten="ngày khám" kieu_luu="I" kieu_date="true" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Bbuoc10" runat="server" CssClass="css_gchu" Text="Nội Dung" Width="100px" />

                                </td>
                                <td align="left">
                                    <Cthuvien:ma ID="ND" runat="server" CssClass="css_nd" kieu_unicode="True" kt_xoa="X" Width="400px" ten="Nội dung" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label5" runat="server" CssClass="css_gchu" Text="Mô tả" Width="100px" />
                                </td>
                                <td align="left">
                                    <%-- <Cthuvien:nd ID="mo_ta" runat="server" CssClass="css_nd" kieu_unicode="True" kt_xoa="X" Width="200px" Heigh="200px" TextMode="MultiLine" />--%>
                                    <Cthuvien:nd ID="mo_ta" runat="server" CssClass="css_nd" Width="400px" kieu_unicode="true" TextMode="MultiLine" Height="120px" kt_xoa="X" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <Cthuvien:nhap ID="nhap2" runat="server" Width="100px" Text="Nhập" OnClick="return ns_bookns_P_NH();return false;" />
                                            </td>
                                            <td>
                                                <Cthuvien:nhap ID="nhan_viec" runat="server" Text="Xác nhận" Width="100px" onClick="return ns_ts_BOOKNS_XACNHAN('XN');" />
                                            </td>
                                            <td>
                                                <Cthuvien:nhap ID="tu_choi" runat="server" Text="Từ chối" Width="100px" onClick="return ns_ts_gv_P_MO_TC(true); return false;" />
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
    </div>
    <AjaxTk:DragPanelExtender ID="DP_giaoviec" runat="server" TargetControlID="pan_giaoviec" DragHandleID="tab_pgiaoviec" />
    <div style="position: absolute; left: 400px; top: 200px;">
        <asp:Panel ID="pan_tc" runat="server">
            <table id="tab_ptc" runat="server" cellpadding="1" cellspacing="13" style="border: 1px solid #C0C0C0; background-color: #E9E9D1; display: none;">
                <tr>
                    <td>
                        <asp:Label ID="Label16" runat="server" CssClass="css_phude" Text="Lý do từ chối" />
                    </td>
                    <td align="right">
                        <img id="Img8" runat="server" alt="" src="~/images/bitmaps/dong.png" onclick="return ns_ts_gv_P_MO_TC(false,''); return false;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0">

                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label17" runat="server" CssClass="css_gchu" Text="Lý do" Width="70px" />
                                </td>
                                <td align="center">
                                    <Cthuvien:nd ID="ly_do" runat="server" CssClass="css_ma" Width="200px" kieu_unicode="true" TextMode="MultiLine" Height="80px" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left" colspan="1">
                                    <Cthuvien:nhap ID="nhap3" runat="server" Text="Nhập" Width="80px" OnClick="return ns_ts_gv_P_TC_NH();" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <AjaxTk:DragPanelExtender ID="DP_tc" runat="server" TargetControlID="pan_tc" DragHandleID="tab_ptc" />

</asp:Content>
