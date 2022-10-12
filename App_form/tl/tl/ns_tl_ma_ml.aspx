<%@ Page Title="ns_tl_ma_ml" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tl_ma_ml.aspx.cs" Inherits="f_ns_tl_ma_ml" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thông tin bảng lương" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Công ty</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="MA_DVI_TK" ten="Công ty" runat="server" Width="200px" ktra="DT_DVI"
                                    CssClass="form-control css_list" onchange="ns_tl_ma_ml_P_KTRA('MA_DVI')" kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Loại lương<span class="require">*</span></span>
                            <div class="input-group">
                                <%--<Cthuvien:DR_list ID="" ten="Loại lương" lke="Lương thời gian" tra="LTG" runat="server" Width="200px"
                                    CssClass="form-control css_list" ktra="DT_DT" onchange="ns_tl_ma_ml_P_KTRA('MA_DT')" kt_xoa="L" />--%>
                                <Cthuvien:DR_list ID="MA_DT_TK" ten="Loại lương" lke="Bảng lương khối Back,Bảng lương khối Sale,Bảng lương cộng tác viên BB,Bảng lương cộng tác viên BS"
                                    tra="BACK,SALE,BB,BS" runat="server" CssClass="form-control css_list" onchange="ns_tl_ma_ml_P_KTRA('MA_DT')" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Loại dữ liệu</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="LOAI_CT_TK" ten="Loại dữ liệu" runat="server" Width="200px"
                                    CssClass="form-control css_list" lke=",Chưa xếp nhóm,Dữ liệu cơ bản,Dữ liệu đầu vào,Dữ liệu import,Dữ liệu tính toán"
                                    tra=",9,0,1,2,3" onchange="ns_tl_ma_ml_P_KTRA('LOAI_CT_TK')" kt_xoa="K" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_35">Bảng lương<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="BLUONG_TK" ten="Bảng lương" runat="server" Width="200px" ktra="DT_BLUONG"
                                    CssClass="form-control css_list" lke="Bảng lương tổng hợp" tra="1" onchange="ns_tl_ma_ml_P_KTRA('BLUONG_TK')" kt_xoa="L" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap1" runat="server" Text="Tìm kiếm" anh="K" class="bt_action" OnClick="return ns_tl_ma_ml_P_LKE('K');form_P_LOI();" Width="100px" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cot="ten_cot,ten_ct,ten_ap_dung_ct,ap_dung_ct,d_vi,so_id" cotAn="ap_dung_ct,d_vi,so_id" hamRow="ns_tl_ma_ml_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Cột" DataField="ten_cot">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên cột lương" DataField="ten_ct">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Loại dữ liệu" DataField="ten_ap_dung_ct">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ap_dung_ct" />
                                    <asp:BoundField DataField="d_vi" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_ct_slide" runat="server" loai="X" gridId="GR_ct" ham="ns_tl_ma_ml_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="width_common">
                        <div class="form-group iterm_form">
                            <span class="standard_label lv2 b_left col_25">Loại lương</span>
                            <div class="input-group">
                                <%--<Cthuvien:DR_list ID="D_TUONG" ten="Loại lương" lke="Lương thời gian" tra="LTG" CssClass="form-control css_list" runat="server" ktra="DT_DT" onchange="ns_tl_ma_ml_P_KTRA('MA_DT')" kt_xoa="L" />--%>
                                <Cthuvien:DR_list ID="D_TUONG" ten="Loại lương" lke="Bảng lương khối Back,Bảng lương khối Sale,Bảng lương cộng tác viên BB,Bảng lương cộng tác viên BS"
                                    tra="BACK,SALE,BB,BS" runat="server" CssClass="form-control css_list" onchange="ns_tl_ma_ml_P_KTRA('MA_DT')" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="form-group iterm_form">
                            <span class="standard_label lv2 b_left col_25">Mã mục lương</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_COT" runat="server" CssClass="form-control css_ma" onchange="ns_tl_ma_ml_P_KTRA('MA');" MaxLength="50" kieu_chu="true"
                                    gchu="gchu" ten="Mã mục lương" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="form-group iterm_form">
                            <span class="standard_label lv2 b_left col_25">Tên mục lương</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_CT" ten="Tên mục lương" runat="server" MaxLength="255" CssClass="form-control css_ma" kieu_unicode="True"
                                    kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="form-group iterm_form">
                            <span class="standard_label lv2 b_left col_25">Loại dữ liệu</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="AP_DUNG_CT" ten="Loại dữ liệu" runat="server"
                                    CssClass="form-control css_list" lke="Chưa xếp nhóm,Dữ liệu cơ bản,Dữ liệu đầu vào,Dữ liệu import,Dữ liệu tính toán"
                                    tra="9,0,1,2,3" onchange="ns_tl_ma_ml_P_KTRA('LOAI_CT')" kt_xoa="K" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="form-group iterm_form">
                            <span class="standard_label lv2 b_left col_25">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="trang_thai" ten="Trạng thái" runat="server" lke="Áp dụng,Ngừng áp dụng"
                                    CssClass="form-control css_list" tra="X,N" kt_xoa="K" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_75">Thứ tự tính</span>
                            <div class="input-group">
                                <Cthuvien:so runat="server" ID="SOTT_NHOM" ten="Thứ tự tính" Text="0" kieu_so="true" CssClass="form-control css_ma" Width="40px" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="form-group iterm_form">
                            <span class="standard_label lv2 b_left col_60">TT hiển thị TK</span>
                            <div class="input-group">
                                <Cthuvien:so runat="server" ID="sott_hien_thi" ten="Thứ tự hiển thị bảng lương trong kỳ" Text="0" kieu_so="true" CssClass="form-control css_ma_c" Width="40px" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_60">TT hiển thị TH</span>
                            <div class="input-group">
                                <Cthuvien:so runat="server" ID="sott_hien_thi_th" ten="Thứ tự hiển thị bảng lương tổng hợp" Text="0" kieu_so="true" CssClass="form-control css_ma" Width="40px" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_75">Lương trong kỳ</span>
                            <div class="input-group">
                                <Cthuvien:kieu runat="server" ID="hien_thi_tk" ten="Lương trong kỳ" lke=",X" tra=",X" CssClass="form-control css_ma" Width="40px" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="form-group iterm_form">
                            <span class="standard_label lv2 b_left col_60">Lương tổng hợp</span>
                            <div class="input-group">
                                <Cthuvien:kieu runat="server" ID="hien_thi_th" ten="Lương tổng hợp" lke=",X" tra=",X" CssClass="form-control css_ma" Width="40px" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">TT hiển thị KD</span>
                            <div class="input-group">
                                <Cthuvien:so runat="server" ID="sott_hien_thi_kd" ten="Thứ tự hiển thị bảng lương kinh doanh" Text="0" kieu_so="true" CssClass="form-control css_form_c" Width="40px" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_60">Lương KD</span>
                            <div class="input-group">
                                <Cthuvien:kieu runat="server" ID="hien_thi_kd" ten="Lương kinh doanh" lke=",X" tra=",X" CssClass="form-control css_form_c" Width="40px" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" anh="K" Text="Nhập" class="bt_action" OnClick="return ns_tl_ma_ml_P_NH();form_P_LOI();" Width="70px" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1220,550" />
    </div>
</asp:Content>
