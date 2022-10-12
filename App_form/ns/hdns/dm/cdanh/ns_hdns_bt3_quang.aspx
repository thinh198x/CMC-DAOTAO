<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_bt3_quang.aspx.cs" Inherits="f_ns_hdns_bt3_quang" 
     EnableEventValidation="false" MasterPageFile="~/trangnen.master"%>


<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục vị trí chức danh" />
                <img class="b_right" src="../../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_65">
                <div class="b_left col_55 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Từ ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_tu" runat="server" ten="Ngày hiệu lực" CssClass="form-control icon_lich" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Từ ngày" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_den" runat="server" ten="Đến ngày" CssClass="form-control icon_lich" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Đến ngày" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <div class="list_bt_action">
                            <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" Width="100px" class="bt_action" anh="K" OnClick="return ns_hdns_ma_bt3_quang_P_LKE();form_P_LOI();" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" Width="100%" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" hangKt="15" hamRow="ns_hdns_ma_bt3_quang_GR_lke_RowChange()"
                                cot="ma,ten,ng_qly,ngay_tl,ma_tt" cotAn="ten_ta,ten_vt,ghichu,nsd" loai="X" >
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="ma" HeaderText="Mã phòng ban" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="ten" HeaderText="Tên phòng ban" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ng_qly" HeaderText="Người quản lý" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />                                    
                                    <asp:BoundField DataField="ngay_tl" HeaderText="Ngày thành lập" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ma_tt" HeaderText="Tỉnh thành" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                            ham="ns_hdns_ma_bt3_quang_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="xuatExel" runat="server" Text="Xuất Excel" class="bt_action" anh="K" OnClick="ns_hdns_ma_bt3_quang_P_IN();form_P_LOI('');" Title="Ấn nút để xuất thông tin ra Excel" />
                    </div>
                </div>
                <div class="b_right col_45 inner" id="UPa_ct">      
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Mã phòng ban<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ma" ten="mã phòng ban" runat="server" CssClass="form-control css_ma" kieu_chu="True" Enabled="false"
                                kt_xoa="G" BackColor="#f6f7f7" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Tên phòng ban<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten" ten="tên phòng ban" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                MaxLength="255" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Tên tiếng anh</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_ta" ten="tên tiếng anh" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                MaxLength="255" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Tên viết tắt<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_vt" ten="tên viết tắt" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                MaxLength="255" />
                        </div>
                    </div>
                    
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày thành lập<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_tl" runat="server" kieu_luu="S" CssClass="form-control css_ma_c icon_lich"
                                    kt_xoa="X" ten="Từ ngày" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày giải thể</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_gt" runat="server" kieu_luu="S" CssClass="form-control css_ma_c icon_lich"
                                    kt_xoa="X" ten="Đến ngày" />
                            </div>
                        </div>
                    </div>


                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Người quản lý</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ng_qly"  runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                MaxLength="250" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Tỉnh thành</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="ma_tt" runat="server" CssClass="form-control css_list" kieu_chu="True" ten="Tỉnh thành"
                                kt_xoa="G" ktra="DT_TT" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Địa chỉ</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="dia_chi"  runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                MaxLength="255" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Ghi chú</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghi_chu" runat="server" CssClass="form-control css_ma" TextMode="MultiLine" kt_xoa="X" Height="50px"
                                MaxLength="1000"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="ns_hdns_ma_bt3_quang_P_MOI();form_P_LOI('');" Title="Ấn nút để làm mới" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="ns_hdns_ma_bt3_quang_P_NH();form_P_LOI('');" Title="Ấn nút nhập để nhập mới" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_hdns_ma_bt3_quang_P_XOA();form_P_LOI();" Title="Xóa dòng thông tin đang chọn" />
                        <Cthuvien:nhap ID="file" runat="server" Text="File" class="bt_action" anh="K" OnClick="nhap_file();form_P_LOI('');" Title="Import" />
                    </div>
                    <div style="display: none;">
                        <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" Text="Xuất excel" OnServerClick="nhap_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1300,560" />
</asp:Content>