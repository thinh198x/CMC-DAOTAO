<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ht_madvi.aspx.cs" Inherits="f_ht_madvi"
    Title="ht_madvi" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>


<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Mã đơn vị" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" Width="100%"
                                loai="L" hangKt="15" cot="ten,ma,ma_ct,cap,tc,logo" cotAn="ma,ma_ct,cap,tc,logo" hamRow="ht_madvi_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Tên bộ phận" HeaderStyle-Width="100%">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten" runat="server" CssClass="css_Gnd" onclick="return ht_madvi_P_LKE('T');" Width="100%" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ma" />
                                    <asp:BoundField DataField="ma_ct" />
                                    <asp:BoundField DataField="cap" />
                                    <asp:BoundField DataField="tc" />
                                    <asp:BoundField DataField="logo" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ht_madvi_P_LKE('L')" />
                        <Cthuvien:kieu runat="server" ID="gt" ten="Hiển thị đơn vị giải thể" lke=",X" tra=",X" CssClass="form-control css_ma_c" Width="30px" onchange="return ht_madvi_P_LKE('M');" />
                        <asp:Label ID="lbltt" runat="server" Text="Hiển thị đơn vị giải thể" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div style="display: none">
                        <Cthuvien:ma ID="cap" runat="server" kt_xoa="X" />
                        <Cthuvien:ma ID="ma_ct" runat="server" kt_xoa="G" />
                        <Cthuvien:ma ID="logo" runat="server" kt_xoa="X" />
                        <Cthuvien:ma ID="trang_thai" runat="server" kt_xoa="X" />
                        <Cthuvien:ma ID="phong_ql" runat="server" kt_xoa="X" />
                        <Cthuvien:ma ID="cdanh_ql" runat="server" kt_xoa="X" />
                        <Cthuvien:so ID="sott" runat="server" CssClass="css_form_r" MaxLength="4" Width="168px" kt_xoa="K" Text="0" ten="Thứ tự sắp xếp" so_tp="2" />
                        <Cthuvien:ma ID="fax" runat="server" CssClass="css_form" MaxLength="100" kt_xoa="X" Width="168px" />
                        <Cthuvien:ma ID="tim_ten" runat="server" TabIndex="-1" CssClass="css_form" Width="173px" kt_xoa="K" nhap="false" onblur="ht_madvi_P_LKE()" />
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_15">Đơn vị cấp trên</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_ct" disabled="disabled" runat="server" CssClass="form-control css_ma" kt_xoa="G" kieu_unicode="True" BackColor="#f6f7f7" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã đơn vị <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" ten="Mã đơn vị" kt_xoa="G" onchange="ht_madvi_P_MA_KTRA()" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên viết tắt <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_VT" ten="Tên viết tắt" runat="server" CssClass="form-control css_ma" MaxLength="100" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>

                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên đơn vị <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" runat="server" ten="Tên đơn vị" CssClass="form-control css_ma" kieu_unicode="True" MaxLength="100" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên đơn vị TA</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_ta" runat="server" ten="Tên đơn vị TA" CssClass="form-control css_ma" MaxLength="100" kt_xoa="X" />
                            </div>
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
                            <span class="standard_label lv2 b_left col_30">Mã số thuế</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_thue" runat="server" CssClass="form-control css_ma" MaxLength="100" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Số điện thoại</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sdt" runat="server" CssClass="form-control css_so" MaxLength="100" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Người đại diện PL</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_ten_ql" ten="Mã người đại diện PL" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ktra="ns_cb,so_the,ten" ToolTip="Mã số người đại diện PL" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_tv_P_KTRA('SO_THE')" gchu="gchu" placeholder="Nhấn F1" kt_xoa="X" />
                                <div style="display: none">
                                    <Cthuvien:ma ID="ten_ql" runat="server" kt_xoa="X" />
                                </div>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh_ql" runat="server" CssClass="form-control css_ma" MaxLength="100"
                                    gchu="ten_ql" ten="Chức danh QLĐV" kieu_unicode="true" Enabled="false"
                                    kt_xoa="X" BackColor="#f6f7f7" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_15">Giấy phép đăng ký KD</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="gpkd" Multiline="true" runat="server" CssClass="form-control css_ma" kieu_unicode="true" MaxLength="250" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_15">Địa chỉ</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="dia_chi" Multiline="true" Height="50px" runat="server" CssClass="form-control css_nd" kieu_unicode="true" MaxLength="250" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_15">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghi_chu" Multiline="true" Height="50px" runat="server" CssClass="form-control css_nd" kieu_unicode="true" MaxLength="250" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <div class="b_left col_15">
                            <button onclick="return khud_trdoi_FI_NH();form_P_LOI();" class="bt_action">Chọn Logo</button>
                        </div>
                        <div class="input-group">
                            <img id="iurl" runat="Server" alt="Logo" title="Logo" src="~/images/no_image.png?1" style="width: 90px; height: 100px; float: left" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Text="Làm mới" giu="false" hoi="4" Width="100px" OnClick="return ht_madvi_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="tao" runat="server" class="bt_action" anh="K" Text="Thêm đơn vị con" hoi="4" Width="130px" OnClick="return ht_madvi_P_MOI_CON();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" giu="false" Text="Ghi" Width="80px" OnClick="return ht_madvi_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Text="Xóa" Width="80px" OnClick="return ns_ht_madvi_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" class="bt_action" anh="K" Text="Chọn" Width="80px" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1200,650" />
</asp:Content>
