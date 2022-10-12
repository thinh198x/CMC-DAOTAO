<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_cc_th_tts.aspx.cs" Inherits="f_ns_cc_th_tts"
    Title="ns_cc_th_tts" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container_content">
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
                <Cthuvien:luu ID="tenForm" runat="server" Text="Bảng tổng hợp công thực tập sinh" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_ct">
                    <div class="col_5_iterm width_common">
                        <div class="b_left form-group iterm_form" style="width: 10%">
                            <span class="standard_label b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" kt_xoa="" ten="Năm" ktra="DT_NAM" runat="server" onchange="ns_cc_th_tts_P_NAM()" CssClass="form-control css_list" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form" style="width: 30%">
                            <span class="standard_label lv2 b_left col_30">Kỳ lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG_ID" kt_xoa="X" ten="Kỳ lương" ktra="DT_KY" runat="server" CssClass="form-control css_list" onchange="ns_cc_th_tts_P_LKE()" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the" ten="Mã nhân viên" kieu_chu="true" runat="server" CssClass="form-control css_ma" onchange="ns_cc_th_tts_P_LKE()" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form" style="display: none">
                            <span class="standard_label lv2 b_left col_30" style="width: 30%">Phòng ban</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phong" ktra="DT_PHONG" runat="server" kt_xoa="X" CssClass="form-control css_list" onchange="ns_cc_th_tts_P_LKE()" />
                            </div>
                        </div>
                        <div class="b_right form-group lv2 iterm_form">
                            <Cthuvien:nhap ID="Nhap1" runat="server" class="bt_action" Text="Tổng hợp" OnClick="return ns_cc_th_tts_P_TONGHOP();" />
                        </div>
                        <div class="grid_table width_common">
                            <div style="overflow-x: scroll">
                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                    CssClass="table gridX" loai="X" hangKt="20" cotAn="ten_kyluong,ma_cdanh,ma_phong">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="100px" />
                                        <asp:BoundField HeaderText="Họ và tên" DataField="ho_ten" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="150px" />
                                        <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="150px" />
                                        <asp:BoundField HeaderText="Phòng ban" DataField="ten_phong" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="150px" />
                                        <asp:BoundField HeaderText="Kỳ lương" DataField="ten_kyluong" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="200px" />
                                        <asp:BoundField HeaderText="Ngày bắt đầu" DataField="ngayd" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="100px" />
                                        <asp:BoundField HeaderText="Ngày kết thúc" DataField="ngayc" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="100px" />
                                        <asp:BoundField HeaderText="Số giờ làm việc trong tháng" DataField="TONG_GIO_LV_TT" ItemStyle-CssClass="css_Gma_r" HeaderStyle-Width="100px" />
                                        <asp:BoundField DataField="ma_cdanh" />
                                        <asp:BoundField DataField="ma_phong" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_th_tts_P_LKE()" />
                        </div>
                        <div class="list_bt_action">
                            <Cthuvien:nhap ID="layexcel" runat="server" class="bt_action" anh="K" Text="Xuất excel" onclick="ns_cc_th_tts_EXCEL()" />
                        </div>
                        <div style="display: none">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="excel_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div id="UPa_hi">
            <Cthuvien:an ID="kthuoc" runat="server" Value="1300,780" />
            <Cthuvien:an ID="an_nam" runat="server" />
            <Cthuvien:an ID="an_kyluong_id" runat="server" />
            <Cthuvien:an ID="an_so_the" runat="server" />
            <Cthuvien:an ID="an_phong" runat="server" />
        </div>
    </div>
</asp:Content>
