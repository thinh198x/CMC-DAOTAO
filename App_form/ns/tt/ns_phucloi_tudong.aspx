<%@ Page Title="ns_phucloi_tudong" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_phucloi_tudong.aspx.cs" Inherits="f_ns_phucloi_tudong" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="khud" %>
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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Phúc lợi tự động" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form" style="display: none">
                            <span class="standard_label lv2 b_left col_30">Phòng ban</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="dr_phongban" ktra="NS_PHUCLOI_TUDONG_DVI" CssClass="form-control css_list" runat="server" onchange="ns_phucloi_tudong_P_KTRA('dr_phongban')"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" runat="server" CssClass="form-control css_ma" kieu_chu="true" gchu="gchu" ten="Mã nhân viên" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="hoten_tk" runat="server" CssClass="form-control css_ma" gchu="gchu" ten="Họ tên nhân viên" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Từ ngày <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_D" runat="server" ten="Từ ngày" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Đến ngày <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_C" runat="server" ten="Đến ngày" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">
                                <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="return ns_phucloi_tudong_P_LKE();" />
                            </span>
                            <div class="input-group">
                            </div>
                        </div>

                    </div>
                </div>
                <div class="grid_table width_common">
                    <div>
                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="L"
                            Width="100%" cotAn="SO_ID" hangKt="15" gchuId="gchu">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:BoundField DataField="SO_THE" HeaderText="Mã NV" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField DataField="HO_TEN" HeaderText="Họ tên" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField DataField="cdanh" HeaderText="Vị trí chức danh" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField DataField="PHONG" HeaderText="Công ty/Bộ phận" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField DataField="TEN_PL" HeaderText="Loại phúc lợi" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField DataField="SOTIEN" HeaderText="Số tiền" ItemStyle-CssClass="css_Gso" />
                                <asp:BoundField HeaderText="Ngày áp dụng" DataField="ng_apdung" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField DataField="SO_ID" ItemStyle-CssClass="css_Gma" />
                            </Columns>
                        </Cthuvien:GridX>
                    </div>
                    <khud:ctr_khud_divL ID="GR_ct_slide" runat="server" loai="X" gridId="GR_ct" ham="ns_phucloi_tudong_P_LKE('K')" />
                </div>
                <div class="list_bt_action">
                    <Cthuvien:nhap ID="tonghop" runat="server" Width="100px" class="bt_action" anh="K" Text="Tổng hợp" OnClick="return ns_phucloi_tudong_TINH();form_P_LOI();" />
                    <Cthuvien:nhap ID="excel" runat="server" Width="100px" class="bt_action" anh="K" Text="Xuất excel" OnServerClick="excel_Click" />
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1050,780" />
        <Cthuvien:an ID="ma_phong" runat="server" />
    </div>
</asp:Content>
