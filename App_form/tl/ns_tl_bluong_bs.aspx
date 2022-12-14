<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_tl_bluong_bs.aspx.cs" Inherits="f_ns_tl_bluong_bs"
    Title="ns_tl_bluong_bs" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="r_c_content b_right">
        <div class="title_dmuc width_common">
            <Cthuvien:luu ID="tenForm" runat="server" Text="Bảng lương công tác viên khối BS" />
            <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
        </div>
        <div class="width_common auto_sc">
            <div class="b_left col_100 inner" id="UPa_ct">
                <div class="col_5_iterm width_common">
                    <div class="b_left form-group iterm_form" style="width: 10%">
                        <span class="standard_label b_left col_30">Năm</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="NAM" kt_xoa="" ten="Năm" ktra="DT_NAM" runat="server" onchange="ns_tl_bluong_bs_P_NAM()" CssClass="form-control css_list" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Kỳ lương</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="KYLUONG_ID" kt_xoa="X" ten="Kỳ lương" ktra="DT_KY" runat="server" CssClass="form-control css_list" onchange="ns_tl_bluong_bs_P_LKE()" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_40">Mã nhân viên</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="so_the" ten="Mã nhân viên" kieu_chu="true" runat="server" CssClass="form-control css_ma" onchange="ns_tl_bluong_bs_P_LKE()" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30" style="width: 30%">Phòng ban</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="phong" ktra="DT_PHONG" runat="server" kt_xoa="X" CssClass="form-control css_list" onchange="ns_tl_bluong_bs_P_LKE()" />
                        </div>
                    </div>
                    <div class="b_right form-group lv2 iterm_form">
                        <Cthuvien:nhap ID="Nhap1" runat="server" class="bt_action" Text="Tổng hợp" OnClick="return ns_tl_bluong_bs_P_TONGHOP();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="20" cotAn="cdanh,phong">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="100px"/>
                                    <asp:BoundField HeaderText="Họ và tên" DataField="ho_ten" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="150px" />
                                    <asp:BoundField HeaderText="Họ và tên nhận lương" DataField="ho_ten_hoa" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="150px" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="150px" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="ten_phong" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="150px" />
                                    <asp:BoundField HeaderText="Mã marketing" DataField="ma_mkt" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="150px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kỳ lương" DataField="ten_kyluong" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="200px" />
                                    <asp:BoundField HeaderText="Phí giao dịch thực thu" DataField="phi_gd_thucthu" ItemStyle-CssClass="css_Gma_r" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Tỷ lệ hoa hồng" DataField="tyle_hoahong" ItemStyle-CssClass="css_Gma_r" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Hoa hồng hợp tác tháng này" DataField="hoahong_hoptac" ItemStyle-CssClass="css_Gma_r" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Tháng trước chuyển sang" DataField="thangtruoc_chuyensang" ItemStyle-CssClass="css_Gma_r" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Truy lĩnh" DataField="truno_bhxh" ItemStyle-CssClass="css_Gma_r" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Truy Thu" DataField="truy_thu" ItemStyle-CssClass="css_Gma_r" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Hoa hồng tiền vay" DataField="hoahong_tienvay" ItemStyle-CssClass="css_Gma_r" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Hoa hồng IR" DataField="hoahong_ir" ItemStyle-CssClass="css_Gma_r" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Hoa hồng trái phiếu" DataField="hoahong_traiphieu" ItemStyle-CssClass="css_Gma_r" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Tổng thu nhập trước thuế" DataField="tong_thunhap_truocthue" ItemStyle-CssClass="css_Gma_r" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Thanh toán tháng này" DataField="thanhtoan_thangnay" ItemStyle-CssClass="css_Gma_r" HeaderStyle-Width="100px" /> 
                                    <asp:BoundField HeaderText="Chuyển sang tháng sau" DataField="chuyen_thangsau" ItemStyle-CssClass="css_Gma_r" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Thuế TNCN tháng này" DataField="thue_tncn" ItemStyle-CssClass="css_Gma_r" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="Số thực nhận tháng này" DataField="thuc_nhan" ItemStyle-CssClass="css_Gma_r" HeaderStyle-Width="100px" />
                                    <asp:BoundField DataField="cdanh" />
                                    <asp:BoundField DataField="phong" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_tl_bluong_bs_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="layexcel" runat="server" class="bt_action" anh="K" Text="Xuất excel" onclick="ns_tl_bluong_bs_EXCEL()" />
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
</asp:Content>
