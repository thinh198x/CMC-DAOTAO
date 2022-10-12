<%@ Page Title="ns_dt_dxuat" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_dxuat.aspx.cs" Inherits="f_ns_dt_dxuat" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Đề xuất kế hoạch thi online" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="gridX" loai="X" hangKt="15" cotAn="loaidt,phong,kynang,trangthai,nguoi_pd,lan" hamRow="ns_dt_dxuat_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã khóa đào tạo" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên khóa đào tạo" DataField="ten" HeaderStyle-Width="50%" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Lần" DataField="lan" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Ngày đề xuất" DataField="ngayd" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Phòng" DataField="loaidt" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Kỹ năng" DataField="kynang" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Tình trạng" DataField="trangthai" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Người PD" DataField="nguoi_pd" ItemStyle-CssClass="css_Gnd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_dxuat_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phong" runat="server" CssClass="form-control css_list" ten="Phòng" ktra="DT_PHONG"
                                    kt_xoa="X" onchange="ns_dt_dxuat_P_KTRA('PHONG')" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Loại đào tạo<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="LOAIDT" runat="server" CssClass="form-control css_list" ten="Loại đào tạo"
                                    tra=",HN,NB,BN" lke=",Đào tạo hội nhập,Đào tạo nội bộ,Đào tạo bên ngoài" kt_xoa="X" />
                                <%--onchange="ns_dt_dxuat_P_KTRA('LOAIDT');"--%>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Theo mã đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_nhucau" ten="Theo mã đào tạo" runat="server" guiId="loaidt" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ktra="ns_dt_nhucau_dt,ma,ten" kt_xoa="G" f_tkhao="~/App_form/ns/dto/ns_dt_nhucau_dt.aspx"
                                    kieu_chu="true" gchu="gchu" placeholder="Nhấn F1" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã kế hoạch<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="kynang" ten="Theo kế hoạch" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ktra="ns_dt_kh,ma,nam" kt_xoa="G" f_tkhao="~/App_form/ns/dt/ns_dt_kh.aspx"
                                    kieu_chu="true" onchange="ns_dt_dxuat_P_KTRA('KEHOACH')" gchu="gchu" placeholder="Nhấn F1" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Lần đề xuất</span>
                            <div class="input-group">
                                <Cthuvien:so ID="lan" runat="server" CssClass="form-control css_ma" kt_xoa="G" gchu="gchu"
                                    ten="Lần đề xuất" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã khóa đào tạo<span class="require">*</span></span>
                            <div class="input-group">
                                <%--onchange="ns_dt_dxuat_P_KTRA('MA')"--%>
                                <Cthuvien:ma ID="MA"  ten="Mã khóa đào tạo" runat="server" kieu_chu="true" CssClass="form-control css_ma"
                                     kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày đề xuất<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYD" runat="server" ten="Ngày đề xuất" CssClass="form-control icon_lich"
                                    MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Tên khóa đào tạo<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Tên khóa đào tạo" runat="server" kieu_unicode="true" CssClass="form-control css_ma" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Mục tiêu </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="muctieu" ten="Mục tiêu khóa học" runat="server" kieu_unicode="true"
                                    CssClass="form-control css_ma" TextMode="MultiLine" Rows="2" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Nội dung</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="noidung" ten="Nội dung khóa học" runat="server" kieu_unicode="true"
                                    CssClass="form-control css_ma" TextMode="MultiLine" Rows="2" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Thời lượng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="thoiluong" ten="Thời lượng" runat="server" kieu_unicode="true" CssClass="form-control css_ma"
                                    kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">T/gian bắt đầu </span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="thoigian" runat="server" ten="Thời gian bắt đầu dự kiến" CssClass="form-control icon_lich"
                                    MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Giảng viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tengv" ten="Giảng viên" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ktra="ns_dt_gvien,SO_THE,ten" kt_xoa="X" f_tkhao="~/App_form/ns/dto/ns_dt_gvien.aspx"
                                    kieu_chu="true" onfocusout="ns_dt_dxuat_P_KTRA('TENGV')" gchu="gchu" placeholder="Nhấn F1" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form" style="display:none;">
                            <span class="standard_label lv2 b_left col_40">Giảng viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the" ten="Mã giảng viên" runat="server" kieu_unicode="true"
                                    CssClass="form-control css_ma" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đơn vị tổ chức</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="dvtochuc" ten="Đơn vị tổ chức" runat="server" kieu_unicode="true"
                                    CssClass="form-control css_ma" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Địa điểm</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="diadiem" ten="Địa điểm" kieu_unicode="true" runat="server" CssClass="form-control css_ma"
                                    kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Chi phí dự kiến</span>
                            <div class="input-group">
                                <Cthuvien:so ID="chiphi" ten="Chi phí dự kiến" kieu_so="true" runat="server" CssClass="form-control css_ma_r" kt_xoa="X" so_tp="2" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">S/lượng dự kiến</span>
                            <div class="input-group">
                                <Cthuvien:so ID="soluong" ten="Số lượng dự kiến" kieu_so="true" runat="server" CssClass="form-control css_ma_r" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Ý kiến cấp trên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ykien" ten="Ý kiến cấp trên" kieu_unicode="true" runat="server" CssClass="form-control css_ma"
                                    kt_xoa="X"  TextMode="MultiLine" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_dt_dxuat_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_dt_dxuat_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_dt_dxuat_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Width="70px" class="bt_action" anh="K" Text="Chọn" OnClick="return ns_dt_dxuat_P_CHON();form_P_LOI();" />
                    </div>
                    <div id="UPa_gchu" class="css_border" align="left" style="margin-top: 110px;">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1100,720" />
        <Cthuvien:an ID="loaidtan" runat="server" Value="0" />
    </div>
</asp:Content>
