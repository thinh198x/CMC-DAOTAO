<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dt_dexuat.aspx.cs" Inherits="f_ns_dt_dexuat"
    Title="ns_dt_dexuat" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Đề xuất đào tạo" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="trang_thai_tk" ten="Trạng thái" CssClass="form-control css_list" runat="server" lke=",Chưa gửi,Chờ phê duyệt,Đã phê duyệt,Không phê duyệt" tra=",CG,0,1,2" onchange="ns_dt_dexuat_P_KTRA('TRANGTHAI_TK')" />

                            </div>
                        </div>
                        <div class="b_right lv2 form-group iterm_form">
                            <Cthuvien:nhap ID="tim" runat="server" Width="120px" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="return ns_dt_dexuat_P_LKE('K');form_P_LOI();" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="12" cotAn="so_id,tt,thang" cot="nam,ten_thang,ten_khoa_dt,tluong_dt,trang_thai,so_id,tt,thang" hamRow="ns_dt_dexuat_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tháng" DataField="ten_thang" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Khóa đào tạo" DataField="ten_khoa_dt" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Thời lượng đào tạo" DataField="tluong_dt" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trang_thai" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số id" DataField="so_id" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số id" DataField="tt" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số id" DataField="thang" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_dexuat_P_LKE('K')" />

                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="NAM" runat="server" CssClass="form-control css_ma" kt_xoa="X" ToolTip="Năm" ten="Năm" onchange="ns_dt_dexuat_P_KTRA('NAM')" MaxLength="4" kieu_so="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Khóa đào tạo <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KHOA_DT" runat="server" CssClass="form-control css_list" ktra="DT_KDT" onchange="ns_dt_dexuat_P_KTRA('KHOA_DT')" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Tháng mong muốn <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="THANG" CssClass="form-control css_list" runat="server" lke="Tháng 01,Tháng 02, Tháng 03,Tháng 04,Tháng 05,Tháng 06,Tháng 07,Tháng 08,Tháng 09,Tháng 10,Tháng 11,Tháng 12" tra="1,2,3,4,5,6,7,8,9,10,11,12" ten="Tháng" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Thời lượng đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tluong_dt" ToolTip="Thời lượng đào tạo" runat="server" CssClass="form-control css_so" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Lý do đào tạo</span>
                        <div class="input-group">
                            <Cthuvien:nd kieu_unicode="true" ID="lydo" ten="Từ giờ" Height="40px" kt_xoa="X" runat="server" CssClass="form-control css_nd" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Mục tiêu đào tạo</span>
                        <div class="input-group">
                            <Cthuvien:nd kieu_unicode="true" ID="muc_tieu" ten="Từ giờ" Height="40px" kt_xoa="X" runat="server" CssClass="form-control css_nd" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Địa điểm</span>
                        <div class="input-group">
                            <Cthuvien:nd kieu_unicode="true" ID="dia_diem" ten="Từ giờ" Height="40px" kt_xoa="X" runat="server" CssClass="form-control css_nd" />

                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="mo_ta" kieu_unicode="true" Height="40px" ToolTip="Thời lượng đào tạo" runat="server" CssClass="form-control css_nd" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Width="80px" Text="Nhập" OnClick="return ns_dt_dexuat_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Width="60px" Text="Mới" OnClick="return ns_dt_dexuat_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Width="60px" Text="Xóa" OnClick="return ns_dt_dexuat_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="gui" runat="server" class="bt_action" anh="K" Width="120px" Text="Gửi phê duyệt" OnClick="return ns_dt_dexuat_P_GUI();form_P_LOI();" />
                        <div style="display: none">
                            <Cthuvien:nhap ID="btn_excel_mau" runat="server" Text="Mẫu excel" Width="70px" OnServerClick="btn_excel_mau_Click" />
                        </div>
                        <div style="display: none">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                        </div>
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu2" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1210,630" />
    <Cthuvien:an ID="so_id" runat="server" />
</asp:Content>
