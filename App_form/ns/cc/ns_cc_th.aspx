<%@ Page Title="ns_cc_th" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_th.aspx.cs" Inherits="f_ns_cc_th" %>

<%@ Register Src="~/App_ctr/khud/ns_khud.ascx" TagName="ns_khud" TagPrefix="ns_khud" %>
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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Bảng tổng hợp công" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_ct">
                    <div style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="PHONG" runat="server" kieu="U" CssClass="form-control css_list" ten="Phòng" onchange="ns_cc_tonghop_P_KTRA('PHONG')" ktra="DT_PHONG" />
                            </div>
                        </div>
                    </div>
                    <div class="col_4_iterm width_common">
                        <div class="b_left form-group iterm_form" style="width: 168px">
                            <span class="standard_label lv2 b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" CssClass="form-control css_list" onchange="ns_cc_th_P_NAM();" ktra="DT_NAM" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form" style="width: 33%;">
                            <span class="standard_label lv2 b_left col_30">Kỳ công</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG" ten="Kỳ công" runat="server" CssClass="form-control css_list" onchange="ns_cc_th_P_KTRA('KYLUONG')" ktra="DT_KY" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the" ten="Mã nhân viên tìm kiếm" onchange="ns_cc_th_P_KTRA('SO_THE')" runat="server" kt_xoa="K" CssClass="form-control css_ma" kieu_chu="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_45"></span>
                            <div class="input-group">
                                <Cthuvien:nhap ID="nhap" runat="server" Text="Tổng hợp" class="bt_action" anh="K" Width="90px" OnClick="ns_cc_th_TINH();form_P_LOI('');" Title="Tổng hợp" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <div style="width: 2700px;">
                                <ns_khud:ns_khud ID="ns_khud" runat="server" />
                            </div>
                            <div style="display: none;">
                                <Cthuvien:GridX ID="GR_lke" runat="server" loai="X" hangKt="18" CssClass="table gridX" AutoGenerateColumns="false" PageSize="1">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField DataField="cotan" ItemStyle-CssClass="css_Gma" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_th_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tdMo" runat="server" Text="Mở" class="bt_action" anh="K" OnClick="return ns_cc_th_P_MO();form_P_LOI();" Width="80px" />
                        <Cthuvien:nhap ID="tdKhoa" runat="server" Text="Đóng" class="bt_action" anh="K" OnClick="return ns_cc_th_P_DONG();form_P_LOI();" Width="80px" />
                        <Cthuvien:nhap ID="Nhap3" runat="server" Text="Xuất excel" class="bt_action" anh="K" OnClick="return ns_cc_th_P_IN();form_P_LOI();" Width="120px" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="file" runat="server" Text="File" CssClass="css_button" OnClick="return ns_cc_tonghop_P_FILES();form_P_LOI();"
                                Width="70px" />
                            <Cthuvien:nhap ID="chuyentien" runat="server" Text="In lệnh chuyển tiền" CssClass="css_button"
                                OnClick="return ns_cc_tonghop_P_CHUYEN_TIEN();form_P_LOI();" Width="150px" />
                            <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_cc_tonghop_HangLen();" />
                            <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_cc_tonghop_HangXuong();" />
                            <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_cc_tonghop_CatDong();" />
                            <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_cc_tonghop_ChenDong('C');" />
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="70px" Text="Xuất excel" OnServerClick="nhap_Click" />
                            <Cthuvien:nhap ID="Nhap1" runat="server" Width="70px" Text="Xuất excel" OnServerClick="nhap1_Click" />
                            <Cthuvien:nhap ID="pheduyet" runat="server" Text="Phê duyệt" CssClass="css_button" OnClick="return ns_cc_tonghop_P_PHEDUYET();form_P_LOI();"
                                Width="100px" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,740" />
        <Cthuvien:an ID="aphong" runat="server" Value="1" />
        <Cthuvien:an ID="akyluong" runat="server" Value="" />
    </div>
</asp:Content>
