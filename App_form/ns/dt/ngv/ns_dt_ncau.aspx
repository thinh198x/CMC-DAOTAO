<%@ Page Title="ns_dt_ncau" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_ncau.aspx.cs" Inherits="f_ns_dt_ncau" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Nhu cầu đào tạo" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_4_iterm width_common">
                         <div class="b_left form-group iterm_form">
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nam_tk" runat="server" ten="Năm" ToolTip="Năm" ktra="DT_NAMTK" CssClass="form-control css_list" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tháng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="thang_tk" ktra="DT_THANG" runat="server" kt_xoa="X" ten="Tháng" CssClass="form-control css_list"
                                    onchange="ns_dt_ncau_P_KTRA('THANG_TK')"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right lv2 form-group iterm_form">
                            <Cthuvien:nhap ID="timkiem" runat="server" class="bt_action" anh="K" Text="Tìm kiếm" OnClick="return ns_dt_ncau_P_LKE();form_P_LOI(); " Width="100px" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Khóa đào tạo" DataField="ten_kdt" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Thời lượng đào tạo" DataField="tluong_dt" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Địa điểm đào tạo" DataField="dia_diem" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Thời gian bắt đầu mong muốn" DataField="ten_thang" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đối tượng đề xuất" DataField="dtuong_dt" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số lượng học viên đăng ký" DataField="sl_hocvien" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Chi phí" DataField="chiphi_dk" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="Lý do đào tạo" DataField="lydo" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Mục tiêu sau đào tạo" DataField="muc_tieu" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_ncau_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <div style="display: none;">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                        </div>
                        <Cthuvien:nhap ID="excel" runat="server"  class="bt_action" anh="K" Width="100px" Text="Xuất excel" OnClick="return ns_dt_ncau_P_IN();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,650" />
        <Cthuvien:an ID="athang_tk" runat="server" Value="" />
    </div>
</asp:Content>
