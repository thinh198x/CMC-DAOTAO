<%@ Page Title="ns_td_capnhat_uv" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_capnhat_uv.aspx.cs" Inherits="f_ns_td_capnhat_uv" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_ttt.ascx" TagName="khud_ttt" TagPrefix="khud_ttt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Cập nhật thông tin ứng viên trúng tuyển" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_40">Năm</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="nam_tk" kieu_so="true" runat="server" MaxLength="4" ten="Năm" kt_xoa="X" CssClass="form-control css_ma_r" onchange="ns_td_capnhat_uv_P_KTRA('NAM_TK')" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_40">Yêu cầu tuyển dụng</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="ma_tk" kt_xoa="X" ten="Yêu cầu tuyển dụng" ktra="DT_MAYEUCAU_TK_TD" CssClass="form-control css_list" runat="server">                                                                                
                            </Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" Width="120px" OnClick="return ns_td_capnhat_uv_P_LKE('M');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15"
                                cotAn="ma,so_id,trangthai,trangthai_uv" hamRow="ns_td_capnhat_uv_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Mã YCTD" DataField="ma" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã YCTD" DataField="ten_ma" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Đơn vị" DataField="phong" HeaderStyle-Width="300px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Vị trí TD" DataField="cdanh" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Mã ứng viên" DataField="so_the" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tên ứng viên" DataField="ten_ungvien" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Trạng thái ứng viên" DataField="trangthai_uv" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Trạng thái thư mời" DataField="trangthai" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Trạng thái thư mời" DataField="ten_trangthai" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_td_capnhat_uv_P_LKE('K')" />

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Width="120px" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left lv2 col_40">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="NAM" kieu_so="true" runat="server" MaxLength="4" ten="Năm" kt_xoa="X" CssClass="form-control css_ma_r" onchange="ns_td_capnhat_uv_P_KTRA('NAM')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã yêu cầu TD <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="MA" kt_xoa="X" ten="Yêu cầu tuyển dụng" ktra="DT_MAYEUCAU_TD" runat="server" CssClass="form-control css_list" onchange="ns_td_capnhat_uv_P_KTRA('MAYEUCAU_TD')">         </Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Vị trí tuyển dụng</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="cdanh" runat="server" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" kieu_unicode="true" BackColor="#f6f7f7" Enabled="false" />
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Đơn vị</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="phongban_ct" runat="server" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" kieu_unicode="true" BackColor="#f6f7f7" Enabled="false" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Ứng viên <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="SO_THE" kt_xoa="X" ten="Ứng viên" ktra="DT_SO_THE" runat="server" CssClass="form-control css_list"
                                onchange="ns_td_capnhat_uv_P_KTRA('SO_THE')" />
                            <div style="display: none;">
                                <Cthuvien:ma ID="ten" runat="server" CssClass="css_form" kt_xoa="X" gchu="gchu" Width="150px" BackColor="#f6f7f7" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày bắt đầu CV</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayd" ten="Ngày bắt đầu CV" runat="server" CssClass="form-control icon_lich"
                                    kt_xoa="X" ToolTip="Ngày bắt đầu CV" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Thời gian thử việc</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="thoigian_tv" ten="Thời gian thử việc" runat="server" CssClass="form-control css_ma" kieu_unicode="true" ToolTip="Thời gian thử việc" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label lv2 b_left col_20">Địa điểm làm việc</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="diadiem_lv" runat="server" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" kieu_unicode="true" />
                        </div>
                    </div>
                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label lv2 b_left col_20">Thời gian làm việc</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="thoigian_lv" runat="server" ten="Thời gian làm việc" kieu_unicode="true" kt_xoa="G" CssClass="form-control css_ma" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Quản lý TT</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_ql" runat="server" kt_xoa="X" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Quản lý TT" placeholder="Nhấn (F1)"
                                    onchange="ns_td_capnhat_uv_P_KTRA('MA_QUANLY')" ktra="ns_cb,so_the,ten" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên QLTT	</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_ql" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                    ten="Tên QLTT" BackColor="#f6f7f7" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Chức danh QLTT</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="cdanh_ql" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                ten="Chức danh QLTT" BackColor="#f6f7f7" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Lương cơ bản</span>
                            <div class="input-group">
                                <Cthuvien:so ID="luong_cb" runat="server" CssClass="form-control css_so" kieu_so="True" kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Thưởng hiệu quả CV tháng</span>
                            <div class="input-group">
                                <Cthuvien:so ID="thuong_cv" ten="Thưởng hiệu quá CV tháng" CssClass="form-control css_so" runat="server" ToolTip="Thưởng hiệu quá CV tháng" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Thu nhập tháng</span>
                            <div class="input-group">
                                <Cthuvien:so ID="thunhap" runat="server" CssClass="form-control css_so" kieu_chu="True" kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">% hưởng lương thử việc</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="phantram_tv" runat="server" CssClass="form-control css_so" kieu_so="true" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Trạng thái thư mời <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="TRANGTHAI" runat="server" CssClass="form-control css_list" kt_xoa="X" lke=",Đã gửi,Đồng ý đi làm, Từ chối" tra=",DG,DL,TC" ten="Trạng thái thư mời" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày offer</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_offer" ten="Ngày offer" runat="server" CssClass="form-control icon_lich"
                                    kt_xoa="X" ToolTip="Ngày offer" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Lý do từ chối</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="lydo" MaxLength="100" runat="server" CssClass="form-control css_nd" kieu_unicode="true" TextMode="MultiLine" Height="80px" kt_xoa="X" ten="Ghi Chú" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Nhập" OnClick="return ns_td_capnhat_uv_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" OnClick="return ns_td_capnhat_uv_P_MOI();form_P_LOI();" Width="100px" />
                        <%--<Cthuvien:nhap ID="xoa" runat="server" CssClass="css_button" Font-Bold="True" Width="70px" Text="Xóa" OnClick="return ns_td_capnhat_uv_P_XOA();form_P_LOI();" />--%>
                        <Cthuvien:nhap ID="mail" runat="server" class="bt_action" anh="K" Font-Bold="True" Width="100px" Text="Gửi mail" OnClick="return ns_td_capnhat_uv_sendMail();form_P_LOI();" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="ps" runat="server" value="NS" />
        <Cthuvien:an ID="nv" runat="server" value="TT" />
        <Cthuvien:an ID="atluong" runat="server" />
        <Cthuvien:an ID="anluong" runat="server" />
        <Cthuvien:an ID="abluong" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1150,680" />
        <Cthuvien:an ID="cthuc_td" runat="server" value="CTHUC_TD" />
    </div>
</asp:Content>
