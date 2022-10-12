<%@ Page Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true" CodeFile="ns_ts_lke.aspx.cs" Inherits="f_ns_ts_lke" Title="ns_ts_lke" %>

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
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Liệt kê công việc" />
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
                                                    <Cthuvien:DR_nhap ID="loai_tk" runat="server" CssClass="css_form" Width="206px"
                                                        DataTextField="ten" DataValueField="ma" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label8" runat="server" CssClass="css_gchu_c" Text="Hoàn thành" Width="120px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="hoan_thanh_tk" runat="server" CssClass="css_form" Width="206px"
                                                        DataTextField="ten" DataValueField="ma" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server" CssClass="css_gchu_c" Text="Người nhận" Width="120px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_nhap ID="ng_nhan_tk" runat="server" CssClass="css_form" Width="206px"
                                                        DataTextField="ten" DataValueField="ma" />
                                                </td>
                                                <%--<td>
                                                    <Cthuvien:DR_lke ID="ng_nhan_tk" runat="server" ktra="KT_HANG"  Width="200px"/>
                                                </td>--%>
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
                                                            ten="ngày khám" kieu_luu="I" kieu_date="true" />
                                                    </div>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="css_gchu_c" Text="Đến ngày" Width="120px" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="den_ngay_tk" runat="server" CssClass="css_form_c" Width="180px" kt_xoa="Z"
                                                            ten="ngày khám" kieu_luu="I" kieu_date="true" />
                                                    </div>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label10" runat="server" CssClass="css_gchu_c" Text="Mã VV" Width="120px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ma_vv" runat="server" CssClass="css_form" Width="210px" kt_xoa="Z"
                                                        ten="Mã vụ việc" kieu_chu="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label12" runat="server" CssClass="css_gchu" Text="Tên dự án" Width="80px" /></td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:DR_nhap ID="duan" runat="server" CssClass="css_form" Width="205px"
                                                        DataTextField="ten" DataValueField="ma" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <div class="box3 txLeft">
                                            <a href="#" onclick="return ns_ts_gv_P_LKE(false);" class="bt bt-grey"><i class="fa fa-search"></i><span class="txUnderline">T</span>ìm kiếm</a>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding-top: 2px">

                                        <table>
                                            <tr>
                                                <td>
                                                    <div style="height: 470px; width: 1200px; overflow: scroll">
                                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" cot="SOTT,MA_DU_AN,MA_WBS,ten_du_an,loai,ND,NG_GIAO,NSD,ng_tao,NGAY_DK_HT,TONG_GIO,TONG_GIO_CHA,thuc_hien,THUC_TE,phan_tram_xong,ngay_con,ttrang,ten_ttrang,id,id_ct,path,ma_ttrang,loai_lsx,GHINHAN_HT" cotAn="SOTT,id,id_ct,path,ng_tao,ten_ttrang,ma_ttrang,ma_wbs,loai_lsx,TONG_GIO_CHA,thuc_hien,GHINHAN_HT" CssClass="table gridX" loai="X" hangKt="15" hamRow="ns_ts_GR_lke_RowChange(event)">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:BoundField HeaderText="Mã VV" DataField="sott" ItemStyle-CssClass="css_ma" />
                                                                <asp:BoundField HeaderText="Mã VV" DataField="ma_du_an" HeaderStyle-Width="80px" ItemStyle-CssClass="css_ma" />
                                                                <asp:BoundField HeaderText="Mã WBS" DataField="ma_wbs" HeaderStyle-Width="80px" ItemStyle-CssClass="css_ma" />
                                                                <asp:BoundField HeaderText="Tên dự án" DataField="ten_du_an" HeaderStyle-Width="200px" ItemStyle-CssClass="css_ma" />
                                                                <asp:BoundField HeaderText="" DataField="loai" HeaderStyle-Width="20px" ItemStyle-CssClass="css_ma_c" />
                                                                <asp:BoundField HeaderText="Công việc" DataField="nd" HeaderStyle-Width="400px" ItemStyle-CssClass="css_ma" />
                                                                <asp:BoundField HeaderText="Ng giao" DataField="NG_GIAO" HeaderStyle-Width="140px" ItemStyle-CssClass="css_ma_c" />
                                                                <asp:BoundField HeaderText="Ng nhận" DataField="nsd" HeaderStyle-Width="140px" ItemStyle-CssClass="css_ma_c" />
                                                                <asp:BoundField HeaderText="Ngày giao" DataField="ng_tao" HeaderStyle-Width="100px" ItemStyle-CssClass="css_ma_c" />
                                                                <asp:BoundField HeaderText="Ngày dự kiến HT" DataField="ngay_dk_ht" HeaderStyle-Width="100px" ItemStyle-CssClass="css_ma_c" />
                                                                <asp:BoundField HeaderText="Tổng Manday" DataField="tong_gio" HeaderStyle-Width="80px" ItemStyle-CssClass="css_so" />
                                                                <asp:BoundField HeaderText="Tổng giờ cấp trên" DataField="tong_gio_cha" HeaderStyle-Width="60px" ItemStyle-CssClass="css_so" />
                                                                <asp:BoundField HeaderText="" DataField="thuc_hien" HeaderStyle-Width="20px" ItemStyle-CssClass="css_ma_c" />
                                                                <asp:BoundField HeaderText="Giờ timesheet" DataField="thuc_te" HeaderStyle-Width="60px" ItemStyle-CssClass="css_so" />
                                                                <asp:BoundField HeaderText="Hoàn thành(%)" DataField="phan_tram_xong" HeaderStyle-Width="60px" ItemStyle-CssClass="css_ma_c" />
                                                                <asp:BoundField HeaderText="Ngày còn lại" DataField="ngay_con" HeaderStyle-Width="80px" ItemStyle-CssClass="css_ma_c" />
                                                                <asp:BoundField HeaderText="Trạng thái" DataField="ttrang" HeaderStyle-Width="120px" ItemStyle-CssClass="css_ma_c" />
                                                                <asp:BoundField HeaderText="Trạng thái" DataField="ten_ttrang" HeaderStyle-Width="10px" ItemStyle-CssClass="css_ma_c" />
                                                                <asp:BoundField HeaderText="so id" DataField="id" HeaderStyle-Width="120px" ItemStyle-CssClass="css_ma_c" />
                                                                <asp:BoundField HeaderText="so id ct" DataField="id_ct" HeaderStyle-Width="120px" ItemStyle-CssClass="css_ma_c" />
                                                                <asp:BoundField HeaderText="path" DataField="path" HeaderStyle-Width="420px" ItemStyle-CssClass="css_ma_c" />

                                                                <asp:BoundField HeaderText="" DataField="ma_ttrang" HeaderStyle-Width="20px" ItemStyle-CssClass="css_ma_c" />
                                                                <asp:BoundField HeaderText="" DataField="loai_lsx" HeaderStyle-Width="20px" ItemStyle-CssClass="css_ma_c" />
                                                                <asp:BoundField HeaderText="" DataField="ghinhan_ht" HeaderStyle-Width="20px" ItemStyle-CssClass="css_ma_c" />

                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </div>
                                                </td>
                                                <td>
                                                    <table style="display: none;">
                                                        <tr style="display: none;">
                                                            <td>
                                                                <img src="../../images/arrow_up.png" alt="" height="16" width="16" onclick="return ns_ts_P_chuyen_hang(-1);" />
                                                            </td>
                                                        </tr>
                                                        <tr style="display: none;">
                                                            <td>
                                                                <img src="../../images/arrow_down.png" alt="" height="16" width="16" onclick="return ns_ts_P_chuyen_hang(1);" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <img id="dvi_cat" runat="server" alt="" src="~/images/gtk_cut.png"
                                                                    title="Cắt  dòng đã chọn" onclick="return ns_ts_gv_CatDong();" height="20" width="20" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <img id="dvi_chen" runat="server" alt="" src="~/images/gtk_paste.png"
                                                                    title="Dán dòng đã cắt" onclick="return ns_ts_gv_P_DC();" height="20" width="20" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <img id="Img7" runat="server" alt="" src="~/images/back.png"
                                                                    title="Chuyển lên cấp trên" onclick="return ns_ts_gv_P_BACK();" height="20" width="20" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <img id="Img9" runat="server" alt="" src="~/images/next.png"
                                                                    title="Chuyển lên cấp trên" onclick="return ns_ts_gv_P_NEXT();" height="20" width="20" />
                                                            </td>
                                                        </tr>
                                                    </table>
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
                            <div class="box3 txRight">
                                <a href="#" onclick="return ns_ts_gv_P_MO_BOOK(true);" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">B</span>ook NS</a>
                                <a href="#" class="bt bt-grey" onclick="return ns_ts_gv_P_MO_GV(true,'GV');"><span class="txUnderline">G</span>iao việc</a>
                                <a href="#" class="bt bt-grey" onclick="return ns_ts_gv_P_MO_GV(true,'GVC');;"><span class="txUnderline">G</span>iao việc con</a>
                                <a href="#" class="bt bt-grey" onclick="return ns_ts_gv_P_MO_GV(true,'CT');"><span class="txUnderline">C</span>hi tiết</a>
                                <a href="#" class="bt bt-grey" onclick="return ns_ts_gv_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                <a href="#" class="bt bt-grey" onclick="return ns_ts_gv_P_MO_TS(true);"><span class="txUnderline">T</span>ime Sheet</a>
                                <a href="#" class="bt bt-grey" onclick="return ns_ts_gv_P_MO_DG(true); return false;"><span class="txUnderline">Đ</span>ánh giá</a>
                                <a href="#" class="bt bt-grey" onclick="return ns_ts_TRDOI();"><span class="txUnderline">T</span>rao đổi</a>
                                <a href="#" class="bt bt-grey" onclick="return ns_danhsach_P_IN();form_P_LOI();"><i class="fa fa-print"></i><span class="txUnderline">I</span>n</a>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1350,790" />
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="id_ct" runat="server" value="0" />
        <Cthuvien:an ID="id_cut" runat="server" value="0" />
        <Cthuvien:an ID="id_ts" runat="server" value="0" />
    </div>
    <div style="position: absolute; left: 400px; top: 200px;">
        <asp:Panel ID="pan_danhgia" runat="server">
            <table id="tab_pdanhgia" runat="server" cellpadding="1" cellspacing="13" style="border: 1px solid #C0C0C0; background-color: #E9E9D1; display: none;">
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" CssClass="css_phude" Text="Đánh giá timesheet" />
                    </td>
                    <td align="right">
                        <img id="Img4" runat="server" alt="" src="~/images/bitmaps/dong.png" onclick="return ns_ts_gv_P_MO_DG(false,''); return false;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" colspan="2">
                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" Width="80px" OnClick="return ns_ts_gv_P_DG_NH();" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <AjaxTk:DragPanelExtender ID="DP_danhgia" runat="server" TargetControlID="pan_danhgia" DragHandleID="tab_pdanhgia" />
    <div style="position: absolute; left: 300px; top: 70px;">
        <asp:Panel ID="pan_giaoviec" runat="server">
            <table id="tab_pgiaoviec" runat="server" cellpadding="1" cellspacing="13" style="border: 1px solid #C0C0C0; background-color: #E9E9D1; display: none; width: 500px;">
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" CssClass="css_phude" Text="Giao việc" />
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
                                    <Cthuvien:bbuoc ID="Bbuoc6" runat="server" CssClass="css_gchu" Text="Nhân viên" Width="100px" />
                                </td>
                                <td align="left">
                                    <Cthuvien:DR_nhap ID="NG_NHAN" ten="Nhân viên nhận việc" runat="server" CssClass="css_drop" Width="206px"
                                        DataTextField="ten" DataValueField="ma" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <Cthuvien:bbuoc ID="Bbuoc13" runat="server" CssClass="css_gchu" Text="Vị trí" Width="100px" />
                                </td>
                                <td align="left">
                                    <Cthuvien:DR_nhap ID="VI_TRI" ten="Vị trí" runat="server" CssClass="css_drop" Width="206px"
                                        DataTextField="ten" DataValueField="ma" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label7" runat="server" CssClass="css_gchu" Text="Loại LSX" Width="100px" />
                                </td>
                                <td align="left">
                                    <Cthuvien:DR_nhap ID="nhom_viec" runat="server" CssClass="css_drop" Width="206px"
                                        DataTextField="ten" DataValueField="ma" ten="Loại lệnh sản xuất" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <Cthuvien:bbuoc ID="Bbuoc7" runat="server" CssClass="css_gchu" Text="Dự án" Width="100px" />
                                </td>
                                <td align="left">
                                    <Cthuvien:ma ID="MA_DU_AN" BackColor="#f6f7f7" runat="server" Width="200px" CssClass="css_ma" f_tkhao="~/App_form/lamviec/ma/ns_ts_duan.aspx"
                                        ktra="ns_ts_duan,ma,ten" kieu_chu="true" ten="Dự án" />
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
                                    <Cthuvien:ma ID="skill" BackColor="#f6f7f7" runat="server" Width="200px" CssClass="css_ma" f_tkhao="~/App_form/ns/ma/ns_ma_kynang.aspx"
                                        ktra="ns_ma_kynang,ma,ten" kieu_chu="true" ten="Dự án" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label11" runat="server" CssClass="css_gchu" Text="Mã WBS" Width="100px" />
                                </td>
                                <td align="left">
                                    <Cthuvien:ma ID="ma_wbs" runat="server" CssClass="css_ma" Width="50px" ToolTip="" MaxLength="20" kt_xoa="X" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" id="tdLTongLsx">
                                    <Cthuvien:bbuoc ID="Bbuoc10" runat="server" CssClass="css_gchu" Text="Tổng Manday LSX" Width="100px" />
                                </td>
                                <td align="left" id="tdVTongLsx">
                                    <Cthuvien:so ID="tong_gio_lsx" ten="Tổng Manday lsx" MaxLength="4" runat="server" CssClass="css_so_c" Width="50px" co_dau="K" so_tp="0" ToolTip="" kt_xoa="G" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <Cthuvien:bbuoc ID="Bbuoc4" runat="server" CssClass="css_gchu" Text="Tổng Manday giao" Width="100px" />
                                </td>
                                <td align="left">
                                    <Cthuvien:so ID="TONG_GIO" ten="Tổng Manday giao" MaxLength="4" runat="server" CssClass="css_so_c" Width="50px" co_dau="K" so_tp="0" ToolTip="" kt_xoa="X" />

                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Dự kiến hoàn thành" Width="110px" />
                                </td>
                                <td align="left">
                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_DK_HT" runat="server" CssClass="css_ngay" Width="200px" kt_xoa="X"
                                        ten="Ngày dự kiến hoàn thành" kieu_luu="I" kieu_date="true" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu" Text="Nội Dung" Width="110px" />
                                </td>
                                <td align="left">
                                    <Cthuvien:nd ID="ND" runat="server" TextMode="MultiLine" Rows="2" Height="50px" CssClass="css_nd" kieu_unicode="True" kt_xoa="X" Width="400px" ten="Nội dung" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Text="Mô tả" Width="100px" />
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
                                                <Cthuvien:nhap ID="nhap1" runat="server" Width="100px" Text="Nhập" OnClick="return ns_ts_gv_P_NH();return false;" />
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
    <div style="position: absolute; left: 200px; top: 100px;">
        <asp:Panel ID="pan_nh_ts" runat="server">
            <table id="tab_pnh_ts" runat="server" cellpadding="1" cellspacing="13" style="border: 1px solid #C0C0C0; background-color: #E9E9D1; display: none;">
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" CssClass="css_phude" Text="Đánh giá" />
                    </td>
                    <td align="right">
                        <img id="Img6" runat="server" alt="" src="~/images/bitmaps/dong.png" onclick="return ns_ts_gv_P_MO_DG(false);" />
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        <table cellpadding="1" cellspacing="1">
                            <tr>
                                <td>
                                    <table id="Table1" runat="server" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td align="left">
                                                <Cthuvien:bbuoc ID="Bbuoc5" runat="server" CssClass="css_gchu" Text="Kết quả" />
                                            </td>
                                            <td>
                                                <Cthuvien:DR_nhap ID="kqua_dg" runat="server" CssClass="css_drop" Width="206px" DataTextField="ten" DataValueField="ma" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <Cthuvien:bbuoc ID="Bbuoc9" runat="server" CssClass="css_gchu" Text="Đánh giá" />
                                            </td>
                                            <td align="left">
                                                <Cthuvien:DR_nhap ID="danh_gia" runat="server" CssClass="css_drop" Width="206px"
                                                    DataTextField="ten" DataValueField="ma" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <Cthuvien:bbuoc ID="Bbuoc11" runat="server" CssClass="css_gchu" Text="Nội dung" Width="70px" />
                                            </td>
                                            <td>
                                                <Cthuvien:nd ID="ND_DG" runat="server" CssClass="css_ma" Width="200px" kieu_unicode="true" TextMode="MultiLine" Height="80px" kt_xoa="X" ten="Nội dung đánh giá" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <table cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td>
                                                <Cthuvien:nhap ID="nhap2" runat="server" Width="70px" Text="Nhập" OnClick="return ns_ts_gv_P_DG_NH();" />
                                            </td>
                                            <td>
                                                <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="70px" OnClick="return ns_ts_dg_P_XOA();" />
                                            </td>
                                            <td>
                                                <Cthuvien:nhap ID="moi" runat="server" Text="Mới" Width="70px" OnClick="return ns_ts_dg_P_MOI();" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="padding-top: 2px">
                        <table>
                            <tr>
                                <td>
                                    <Cthuvien:GridX ID="GR_dg_lke" runat="server" AutoGenerateColumns="false" PageSize="1" cot="ngay,so_id" cotAn="so_id" CssClass="table gridX" loai="X" hangKt="15" hamRow="ns_ts_gv_P_DG_CT()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="18px" />
                                            <asp:BoundField HeaderText="Ngày" DataField="ngay" HeaderStyle-Width="300px" ItemStyle-CssClass="css_ma_c" />
                                            <asp:BoundField HeaderText="Số ID" DataField="so_id" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" id="GR_dg_lke_td" runat="server">
                                    <khud_slide:khud_slide ID="GR_dg_lke_slide" runat="server" loai="X" gridId="GR_dg_lke" ham="ns_ts_P_LKE()" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <AjaxTk:DragPanelExtender ID="DP_nh_ts" runat="server" TargetControlID="pan_nh_ts" DragHandleID="tab_pnh_ts" />
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





    <div style="position: absolute; left: 200px; top: 100px;">
        <asp:Panel ID="pan_book" runat="server">
            <table id="tab_pbook" runat="server" cellpadding="1" cellspacing="13" style="border: 1px solid #C0C0C0; background-color: #E9E9D1; display: none;">
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" CssClass="css_phude" Text="Book Nhân sự" />
                    </td>
                    <td align="right">
                        <img id="Img10" runat="server" alt="" src="~/images/bitmaps/dong.png" onclick="return ns_ts_gv_P_MO_BOOK(false);" />
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        <table cellpadding="1" cellspacing="1">
                            <tr>
                                <td>
                                    <Cthuvien:GridX ID="GR_book" runat="server" AutoGenerateColumns="false" PageSize="1"
                                        CssClass="table gridX" loai="N" cot="ng_nhan,ten" hangKt="5">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="18px" />
                                            <asp:TemplateField HeaderText="Mã nhân viên" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ng_nhan" runat="server" Width="100px" CssClass="css_Gma_c" f_tkhao="~/App_form/lamviec/ns_ts_timkiem.aspx"
                                                        ktra="ns_ts_timkiem,ng_nhan,ten" kieu_chu="true" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="250px" ItemStyle-CssClass="css_ma_c" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <table cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td>
                                                <Cthuvien:nhap ID="nhap5" runat="server" Width="70px" Text="Nhập" OnClick="return ns_ts_gv_P_BOOK_NH();" />
                                            </td>
                                            <td>
                                                <Cthuvien:nhap ID="Nhap6" runat="server" Text="Xóa" Width="70px" OnClick="return ns_ts_dg_P_XOA();" />
                                            </td>
                                            <td>
                                                <Cthuvien:nhap ID="Nhap7" runat="server" Text="Mới" Width="70px" OnClick="return ns_ts_dg_P_MOI();" />
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
    <AjaxTk:DragPanelExtender ID="DP_book" runat="server" TargetControlID="pan_book" DragHandleID="tab_pbook" />


</asp:Content>
