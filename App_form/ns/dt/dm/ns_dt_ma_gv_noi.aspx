<%@ Page Title="ns_dt_ma_gv_noi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_ma_gv_noi.aspx.cs" Inherits="f_ns_dt_ma_gv_noi" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục giảng viên đào tạo nội bộ" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div style="display: none;">
                        <Cthuvien:DR_list ID="tt_tk" runat="server" Width="120px" CssClass="css_list" ToolTip="Tình trạng nhân viên" lke=",Làm việc,Nghỉ việc" tra=",0,1" />
                        <Cthuvien:DR_list ID="cap_gvien_tk" runat="server" Width="120px" CssClass="css_list" ToolTip="Cấp giảng viên" />
                        <Cthuvien:DR_list ID="loai_gvien_tk" runat="server" Width="120px" CssClass="css_list" ToolTip="Loại giảng viên" />
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K"  OnClick="return ns_dt_ma_gv_noi_P_LKE();form_P_LOI();" Width="100px" />
                        <Cthuvien:ma ID="tt_an" runat="server" CssClass="form-control css_ma" Text="" />
                        <Cthuvien:ma ID="lgv_an" runat="server" CssClass="form-control css_ma" Tex="" />
                        <Cthuvien:ma ID="cgv_an" runat="server" CssClass="form-control css_ma" Text="" />
                    </div>
                    <div class="grid_table width_common">
                        <div class="css_divb">
                            <div>
                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                    CssClass="table gridX" loai="X" hangKt="15" cotAn="so_the" hamRow="ns_dt_ma_gv_noi_GR_lke_RowChange()">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField DataField="so_the" />
                                        <asp:BoundField HeaderText="Tên giảng viên" DataField="ten" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Điện thoại" DataField="dtdd" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_r" />
                                        <asp:BoundField HeaderText="Email công ty" DataField="email_cty" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Kinh nghiệm giảng dạy" DataField="knghiem"  ItemStyle-CssClass="css_Gnd" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_ma_gv_noi_P_LKE()" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Width="100px" Text="Xuất excel" OnClick="return ns_dt_ma_gv_noi_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã nhân viên" ToolTip="Mã nhân viên" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" placeholder="Nhấn (F1)"
                                    kt_xoa="G" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_dt_ma_gv_noi_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten" MaxLength="30" gchu="gchu" ReadOnly="false" kieu_chu="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Họ tên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ho_ten" runat="server" CssClass="form-control css_ma" kt_xoa="G" ten="Họ tên" BackColor="#f6f7f7" ToolTip="Họ tên" MaxLength="255" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Chức danh <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_CDANH" ten="Chức danh" ToolTip="Chức danh" Enabled="false" runat="server" MaxLength="255" CssClass="form-control css_ma" kt_xoa="G" BackColor="#f6f7f7" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đơn vị <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_PHONG" runat="server" CssClass="form-control css_ma" kt_xoa="G" ten="Đơn vị" BackColor="#f6f7f7" ToolTip="Đơn vị" Enabled="false" MaxLength="255" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày sinh <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NSINH" ten="Ngày sinh" runat="server" CssClass="form-control icon_lich" kt_xoa="G" kieu_luu="I" BackColor="#f6f7f7" ToolTip="Ngày sinh" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày vào CT</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_ct" ten="Ngày vào CT" runat="server" CssClass="form-control icon_lich" kt_xoa="G" kieu_luu="I" BackColor="#f6f7f7" ToolTip="Ngày vào công ty" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Điện thoại</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="dthoai" runat="server" CssClass="form-control css_ma_r" kt_xoa="G" ten="Điện thoại" BackColor="#f6f7f7" kieu_so="true" ToolTip="Điện thoại" MaxLength="50" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Email công ty</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="email_cty" Enabled="false" runat="server" CssClass="form-control css_ma" kt_xoa="G" ten="Email công ty" BackColor="#f6f7f7" ToolTip="Email công ty" MaxLength="255" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Email cá nhân</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="email" runat="server" CssClass="form-control css_ma" kt_xoa="G" ToolTip="Email cá nhân" MaxLength="255" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Khóa ĐT giảng dạy</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="kdtao" ten="Khóa ĐT giảng dạy" ToolTip="Khóa ĐT giảng dạy" runat="server" CssClass="form-control css_ma" kt_xoa="X" MaxLength="1000" kieu_unicode="true" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">KN giảng dạy</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="knghiem" ten="KN giảng dạy" ToolTip="Kinh nghiệm giảng dạy" runat="server" CssClass="form-control css_ma" kt_xoa="X" MaxLength="1000" kieu_unicode="true" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mota" ToolTip="Mô tả" MaxLength="1000" runat="server" CssClass="form-control css_ma" kt_xoa="X" Height="50px" kieu_unicode="true" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K"  OnClick="return ns_dt_ma_gv_noi_P_MOI();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K"  OnClick="return ns_dt_ma_gv_noi_P_NH();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" class="bt_action" anh="K"  OnClick="form_P_TRA_CHON('SO_THE,HO_TEN,KNGHIEM');form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K"  onclick="return ns_dt_ma_gv_noi_P_XOA();form_P_LOI();" Width="100px" />
                        <div style="display: none">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                        </div>
                    </div>
                    <div id="UPa_gchu" class="css_border" align="left">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1300,620" />
</asp:Content>
