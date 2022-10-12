<%@ Page Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true" CodeFile="ns_ts_timkiem.aspx.cs" Inherits="f_ns_ts_timkiem" Title="ns_ts_timkiem" %>

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
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Tìm kiếm " />
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
                        <td align="center">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left" class="form_right">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Text="Loại tìm kiếm" Width="120px" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:DR_nhap ID="loai" runat="server" CssClass="css_form" Width="206px">
                                                                    <asp:ListItem Text="Thời gian rảnh rỗi" Value="RR" />
                                                                    <asp:ListItem Text="Kế hoạch công việc" Value="KH" />
                                                                </Cthuvien:DR_nhap>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label15" runat="server" CssClass="css_gchu_c" Text="Thời gian rảnh từ" Width="120px" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:so ID="ranh" runat="server" CssClass="css_form_c" Width="30px" Text="0" />
                                                                
                                                            </td>
                                                            <td>  
                                                                <asp:Label ID="Label132" runat="server" CssClass="css_gchu" Text="Man Hour" Width="134px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="css_gchu" Text="Từ ngày" Width="60px" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <div class="ip-group date">
	                                                                <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" runat="server" Width="80px" CssClass="css_form_c" />
                                                                    </div>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label3" runat="server" CssClass="css_gchu_c" Text="Đến ngày" Width="88px" />
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
	                                                                <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" runat="server" Width="80px" CssClass="css_form_c" />
                                                                    </div>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" CssClass="css_gchu_c" Text="Nhân sự" Width="60px" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:DR_nhap ID="NG_NHAN_TK" runat="server" CssClass="css_form" Width="206px"
                                                                    DataTextField="ten" DataValueField="ma" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>

                                                <td align="left" valign="top" colspan="2">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label12" runat="server" Width="120px" Text="Tiêu chí kỹ năng" CssClass="css_link_nhom" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                    CssClass="table gridX" loai="N" cot="dk,ma,ten,tu,den" hangKt="3" gchuId="gchu">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                        <asp:TemplateField HeaderText="Điều kiện" HeaderStyle-Width="40px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:kieu ID="dk" runat="server" lke="OR,AND" Width="40px" CssClass="css_Gma_c" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Mã kỹ năng" HeaderStyle-Width="60px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="ma" kieu_chu="true" runat="server" Width="60px" CssClass="css_Gma"
                                                                                    f_tkhao="~/App_form/ns/ma/ns_ma_kynang.aspx" ktra="ns_ma_kynang,ma,ten" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="Tên kỹ năng" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                                                        <asp:TemplateField HeaderText="Từ (Năm)" HeaderStyle-Width="60px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="tu" runat="server" Width="60px" CssClass="css_Gma_c" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Đến (Năm)" HeaderStyle-Width="60px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="den" runat="server" Width="60px" CssClass="css_Gma_c" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </Cthuvien:GridX>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_danhsach_ct_CatDong();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="padding-top: 5px; width:100px">
                                                    <div class="box3 txLeft">
                                                        <a href="#" onclick="return ns_ts_timkiem_P_LKE();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">T</span>ìm kiếm</a>
                                                    </div>
                                                </td>
                                                <td style="padding-top: 5px; width:175px"">
                                                    <div class="box3 txLeft">
                                                        <a href="#" onclick="return ns_ts_tim_P_CHON();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                        <a href="#" onclick="return ns_ts_gv_P_TT();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">T</span>hông tin</a>
                                                    </div>
                                                </td>
                                                <td style="padding-top: 5px; padding-left:88px; ">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_ts_gv_P_MO_GV(true,'GV');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">B</span>ook</a>
                                                    </div>
                                                </td>
                                                <%--<td align="left">
                                                    <Cthuvien:nhap ID="timkiem" runat="server" Text="Tìm kiếm" Width="100px" OnClick="return ns_ts_timkiem_P_LKE();" />
                                                </td>
                                                <td>
                                                    <div style="float: left">
                                                        <Cthuvien:nhap ID="chon" runat="server" Width="80px" Text="Chọn" OnClick="return ns_ts_tim_P_CHON();form_P_LOI();" />
                                                    </div>
                                                    <div style="float: left; padding-left: 25px">
                                                        <Cthuvien:nhap ID="tt" runat="server" Text="Thông tin" CssClass="css_button" OnClick="return ns_ts_gv_P_TT();form_P_LOI();"
                                                            Width="70px" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="Nhap1" runat="server" Width="80px" Text="Book" OnClick="return ns_ts_gv_P_MO_GV(true,'GV');form_P_LOI();" />
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2" style="padding-top: 2px">
                                        <div style="height: 350px; width: 960px; overflow: scroll">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="X" hangKt="15">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="18px" />
                                                                <asp:BoundField HeaderText="Mã nhân viên" DataField="ng_nhan" HeaderStyle-Width="80px" ItemStyle-CssClass="css_ma_c" />
                                                                <asp:BoundField HeaderText="Nhân viên" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_ma" />
                                                                <asp:BoundField HeaderText="Ngày" DataField="ngay_dk_ht" HeaderStyle-Width="100px" ItemStyle-CssClass="css_ma_c" />
                                                                <asp:BoundField HeaderText="Man Hour" DataField="tong_gio" HeaderStyle-Width="60px" ItemStyle-CssClass="css_ma_c" />
                                                                <asp:BoundField HeaderText="Nội dung" DataField="nd" HeaderStyle-Width="250px" ItemStyle-CssClass="css_ma" />
                                                                <asp:BoundField HeaderText="Mô tả" DataField="mo_ta" HeaderStyle-Width="250px" ItemStyle-CssClass="css_ma" />
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>
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
            <td align="left" colspan="2">
                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="X" />
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1050,800" />
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
                                        DataTextField="ten" DataValueField="ma" disabled="true" />
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
                                    <asp:Label ID="Label8" runat="server" CssClass="css_gchu" Text="Từ giờ" Width="100px" />
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
                                                <Cthuvien:nhap ID="nhan_viec" runat="server" Text="Nhận việc" Width="100px" onClick="return ns_ts_gv_TT_P_NH('DN');" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <Cthuvien:nhap ID="tu_choi" runat="server" Text="Từ chối" Width="100px" onClick="return ns_ts_gv_P_MO_TC(true); return false;" />
                                            </td>
                                            <td>
                                                <Cthuvien:nhap ID="kt" runat="server" Text="Kết thúc" Width="100px" onClick="return ns_ts_gv_TT_P_NH('CDG');" />
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
</asp:Content>
