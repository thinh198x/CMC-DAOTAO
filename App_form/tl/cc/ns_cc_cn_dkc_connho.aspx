<%@ Page Title="ns_cc_cn_dkc_connho" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_cn_dkc_connho.aspx.cs" Inherits="f_ns_cc_cn_dkc_connho" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div id="divLke" class="l_c_content b_left">
            <div class="b_nd_tab" id="UPa_dau">
                <div class="r_cc_tochuc">
                    <vb_cctc:vb_cctc ID="cctc" runat="server" />
                </div>
            </div>
        </div>
        <div class="doi_menu_luoi" id="div_center_icon">
            <span class="next_r" id="ico_mo" style="display: none" onclick="return ed_vb_khac_P_DLKE('M')"></span>
            <span class="back_l" id="ico_do" onclick="return ed_vb_khac_P_DLKE('D')"></span>
        </div>
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Đăng ký ca nuôi con nhỏ dưới 1 tuổi" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common" style="display: none;">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma" kieu_chu="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_tk" ten="Tên nhân viên" runat="server" CssClass="form-control css_ma" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display: none;">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phong_tk" ten="Phòng" runat="server" CssClass="form-control css_list" onchange="ns_cc_cn_dkc_connho_P_KTRA('PHONG_TK')" ktra="DT_PHONG" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">

                        <div class="b_left form-group iterm_form">
                            <span class="standard_label  b_left col_40">Từ ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYD_TK" ten="Từ ngày" runat="server" kt_xoa="G" CssClass="form-control icon_lich" kieu_luu="S" />

                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label  lv2 b_left col_40">Đến ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYC_TK" ten="Đến ngày" runat="server" kt_xoa="G" CssClass="form-control icon_lich" kieu_luu="S" />

                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" Width="120px" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="return ns_cc_cn_dkc_connho_P_LKE('K');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="mota,cdanh,phong,so_id,tt" hamRow="ns_cc_cn_dkc_connho_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên nhân viên" DataField="ho_ten" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="150px" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="ten_phong" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ca" DataField="ten_ca" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày đăng ký từ" DataField="ngayd" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Ngày đăng ký đến" DataField="ngayc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mô tả" DataField="mota" />
                                    <asp:BoundField HeaderText="Mã chức danh" DataField="cdanh" />
                                    <asp:BoundField HeaderText="Mã phòng ban" DataField="phong" />
                                    <asp:BoundField HeaderText="TT" DataField="tt" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_cn_dkc_connho_P_LKE('K')" />

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" runat="server" Width="120px" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_cc_cn_dkc_connho_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" placeholder="Nhấn (F1)" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ktra="ns_cb,so_the,ten" ToolTip="Mã số nhân viên" kieu_chu="true" Enabled="false"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_cc_cn_dkc_connho_P_KTRA('SO_THE')" gchu="gchu" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" Enabled="false" runat="server" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label  b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ho_ten" Enabled="false" runat="server" CssClass="form-control css_ma" gchu="gchu" />
                            </div> 
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" runat="server" Enabled="false" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">

                        <div class="b_left form-group iterm_form">
                            <span class="standard_label  b_left col_40">Đăng ký từ ngày<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYD" ten="Từ ngày" runat="server" kt_xoa="G" CssClass="form-control icon_lich" kieu_luu="S" onchange="ns_cc_cn_dkc_connho_P_KTRA('NGAYD')" />

                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label  lv2 b_left col_40">Đăng ký đến ngày<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYC" ten="Đến ngày" runat="server" kt_xoa="G" CssClass="form-control icon_lich" kieu_luu="S" onchange="ns_cc_cn_dkc_connho_P_KTRA('NGAYC')" />

                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label  b_left col_40">Ca</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="CA" ten="Ca" runat="server" ktra="DT_CALV" kieu_chu="true" CssClass="form-control css_list" kt_xoa="X" 
                                    onchange="ns_cc_cn_dkc_connho_P_KTRA('CA_LV');"/>
                            </div>
                        </div>

                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Thời gian từ </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="GIOD" ten="Từ giờ" MaxLength="30" kt_xoa="X" runat="server" CssClass="form-control css_ma_c" kieu_chu="True"
                                    Enabled="false" BackColor="#f6f7f7" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Thời gian đến </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="GIOC" ten="Đến giờ" MaxLength="30" kt_xoa="X" runat="server" CssClass="form-control css_ma_c" kieu_chu="True"
                                    Enabled="false" BackColor="#f6f7f7" />
                            </div>
                        </div>
                    </div>

                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label  b_left col_20">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mota" ten="Mô tả" runat="server" CssClass="form-control css_nd" MaxLength="255" kieu_unicode="true" TextMode="MultiLine" Height="50px"
                                kt_xoa="X" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_cc_cn_dkc_connho_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" Width="80px" class="bt_action" anh="K" Text="Mới" OnClick="return ns_cc_cn_dkc_connho_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_cc_cn_dkc_connho_P_XOA();form_P_LOI();" />
                        <%--<Cthuvien:nhap ID="Nhap3" runat="server" Width="80px" Text="Hủy đơn" OnClick="return ns_cc_cn_dkc_connho_P_Update();form_P_LOI();" />--%>
                        <Cthuvien:nhap ID="gui" runat="server" class="bt_action" anh="K" Width="120px" Text="Gửi" OnClick="return ns_cc_cn_dkc_connho_P_GUI();form_P_LOI();" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="Nhap3" runat="server" Width="80px" class="bt_action" anh="K" Text="File mẫu" OnClick="return ns_cc_cn_dkc_connho_P_MAU();form_P_LOI();" />
                            <Cthuvien:nhap ID="Nhap4" runat="server" class="bt_action" anh="K" Text="Import excel" OnClick="return ns_cc_cn_dkc_connho_FILE_Import();form_P_LOI('');" />
                            <Cthuvien:nhap ID="btn_excel_mau" runat="server" Text="Mẫu excel" Width="70px" OnServerClick="btn_excel_mau_Click" />
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                        </div>
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <Cthuvien:an ID="kthuoc" runat="server" Value="1300,620" />
    <Cthuvien:an ID="aphong" runat="server" Value="" />
    <Cthuvien:an ID="akyluong" runat="server" Value="" />
</asp:Content>
