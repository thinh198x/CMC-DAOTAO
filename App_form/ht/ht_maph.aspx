<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ht_maph.aspx.cs" Inherits="f_ht_maph"
    Title="ht_maph" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập cơ cấu tổ chức" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                loai="X" hangKt="15" cot="ten,ma,ma_ct,cap,tinh_trang,tc" Width="100%" cotAn="ma,ma_ct,cap,tinh_trang,tc" hamRow="ht_maph_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Tên bộ phận" HeaderStyle-Width="100%">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten" runat="server" CssClass="css_Gnd" Width="100%" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ma" />
                                    <asp:BoundField DataField="ma_ct" />
                                    <asp:BoundField DataField="cap" />
                                    <asp:BoundField DataField="tinh_trang" />
                                    <asp:BoundField DataField="tc" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                            ham="ht_maph_P_LKE('L')" />
                        <Cthuvien:kieu runat="server" ID="gt" ten="Hiển thị đơn vị giải thể" lke=",X" tra=",X" CssClass="form-control css_ma_c" Width="30px" onchange="return ht_maph_P_LKE('M');" />
                        <asp:Label ID="lbltt" runat="server" Text="Hiển thị đơn vị giải thể" />
                        <div class="list_bt_action">
                            <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" class="bt_action" anh="K" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                        </div>
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div style="display: none">
                        <Cthuvien:ma ID="cap" runat="server" kt_xoa="X" />
                        <Cthuvien:ma ID="ma_ct" runat="server" kt_xoa="X" />
                        <Cthuvien:ma ID="logo" runat="server" kt_xoa="X" />
                        <Cthuvien:ma ID="trang_thai" runat="server" kt_xoa="X" />
                        <Cthuvien:ma ID="ma" runat="server" kt_xoa="X" />
                        <Cthuvien:so ID="sott" runat="server" ten="Thứ tự sắp xếp" CssClass="css_form_r" MaxLength="4" Width="168px"
                            Text="0" so_tp="2" />
                        <Cthuvien:ma ID="ma_thue" runat="server" CssClass="css_form" MaxLength="20" kt_xoa="X" Width="168px" />
                        <Cthuvien:ma ID="sdt" runat="server" CssClass="css_form" MaxLength="30" kt_xoa="X" Width="168px" />
                        <Cthuvien:ma ID="fax" runat="server" CssClass="css_form" MaxLength="30" kt_xoa="X" Width="168px" />
                        <Cthuvien:nd ID="ghi_chu" Multiline="true" Height="50px" runat="server" CssClass="css_form" kieu_unicode="true" MaxLength="500" kt_xoa="X" Width="428px" />
                        <Cthuvien:nhap ID="clogo" runat="server" Text="Chọn Logo" hoi="7" OnClick="return khud_trdoi_FI_NH();form_P_LOI();" />
                        <img id="iurl" runat="Server" alt="Logo" title="Logo" src="~/images/no_image.png" style="width: 90px; height: 100px; float: left" />
                        <Cthuvien:ma ID="tim_ten" runat="server" TabIndex="-1" CssClass="css_form" Width="190px"
                            kt_xoa="K" nhap="false" onblur="ht_maph_P_LKE()" />
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_15">Đơn vị cấp trên</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_ct" disabled runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã đơn vị</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_ts" disabled runat="server" CssClass="form-control css_ma" ten="Mã đơn vị" kt_xoa="G" onchange="ht_madvi_P_MA_KTRA()" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên viết tắt <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_VT" ten="Tên viết tắt" runat="server" CssClass="form-control css_ma" MaxLength="100" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>

                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_15">Tên đơn vị <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" ten="Tên đơn vị" CssClass="form-control css_ma" kieu_unicode="True" MaxLength="255" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_15">Tên đơn vị TA</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_ta" runat="server" ten="Tên đơn vị TA" CssClass="form-control css_ma" MaxLength="255" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày thành lập <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_TL" runat="server" ten="Ngày thành lập" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày giải thể</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_gt" runat="server" ten="Ngày giải thể" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Quản lý đơn vị</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="phong_ql" runat="server" CssClass="form-control css_ma" MaxLength="100" kt_xoa="X"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" placeholder="Nhấn (F1)" BackColor="#f6f7f7" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="cdanh_ql" disabled runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_unicode="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Vùng miền <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="VUNG_MIEN" ten="Vùng miền" runat="server" ktra="DT_VUNG" kieu_chu="true"
                                    CssClass="form-control css_list" kt_xoa="G" onchange="" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Khối  <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KHOI" ten="Khối" runat="server" ktra="DT_KHOI" kieu_chu="true"
                                    CssClass="form-control css_list" kt_xoa="G" onchange="" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã phân bổ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="MA_PB" ten="Mã phân bổ" runat="server" ktra="DT_MAPB" kieu_chu="true"
                                    CssClass="form-control css_list" kt_xoa="G" onchange="" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_15">Địa chỉ</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="dia_chi" Multiline="true" Height="50px" runat="server" CssClass="form-control css_ma" kieu_unicode="true" MaxLength="500" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" Text="Làm mới" anh="K" hoi="4" Width="100px" OnClick="return ht_maph_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="tao" runat="server" class="bt_action" Text="Thêm đơn vị con" anh="K" hoi="3" Width="130px" OnClick="return ht_maph_P_MOI_CON();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" Text="Ghi" Width="80px" anh="K" OnClick="return ht_maph_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" class="bt_action" Text="Chọn" Width="80px" anh="K" OnClick="return form_P_TRA_CHON_GRID('GR_lke:ma,GR_lke:ten');form_P_LOI();" />
                        <Cthuvien:nhap ID="giaithe" runat="server" class="bt_action" Text="Giải thể" Width="100px" anh="K" OnClick="return ht_maph_P_GT();form_P_LOI();" />

                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1050,800" />
</asp:Content>
