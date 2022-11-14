<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/trangnen.master" CodeFile="ntduc_bai2.aspx.cs" Inherits="bai2" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục vị trí chức danh" />
                <img class="b_right" src="../../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" Width="100%" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" hangKt="15" hamRow="GR_lke_RowChange()"
                                 loai="X" cthich="chon:Đánh dấu chọn ký">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="manhom" HeaderText="Nhóm chức danh" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ma" HeaderText="Mã chức danh" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="ten" HeaderText="Tên chức danh" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ten_tt" HeaderText="Trạng thái" ItemStyle-CssClass="css_Gma" />
      
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                            ham="P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="xuatExel" runat="server" Text="Xuất Excel" class="bt_action" anh="K" OnClick="P_IN();form_P_LOI('');" Title="Ấn nút để xuất thông tin ra Excel" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div style="display: none">
                        <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu2" kt_xoa="X" Font-Bold="true" />
                        <Cthuvien:DR_lke ID="ma_cm" runat="server" ktra="DT_CM" kieu_chu="True" ten="Tên chuyên môn" onchange="P_KTRA('MA_CM')" Width="270px" kt_xoa="G" />
                        <Cthuvien:DR_lke ID="ma_nn" runat="server" kieu_chu="True" ten="Nhóm chức danh lỗi"
                            MaxLength="30" kt_xoa="K" ktra="DT_NN" Width="270px" onchange="P_KTRA('MA_CB')" />
                        <Cthuvien:DR_lke ID="cbnn" runat="server" ktra="DT_CB" kieu_chu="True" ten="Tên cấp bậc nghề nghiệp"
                            onchange="P_KTRA('MA_CB')" Width="270px" kt_xoa="M" />
                        <Cthuvien:ma ID="day" ten="" runat="server" Text="A" kt_xoa="L" />
                        <Cthuvien:ma ID="so_id" runat="server" kt_xoa="X" />
                        <Cthuvien:ma ID="so_id_cm" runat="server" kt_xoa="X" />
                        <Cthuvien:ma ID="so_id_cbnn" runat="server" kt_xoa="X" />
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Nhóm chức danh<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="ma_nnn" runat="server" CssClass="form-control css_list" kieu_chu="True" ten="Nhóm chức danh"
                                kt_xoa="G" ktra="DT_NL" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Mã chức danh<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="mã chức danh" runat="server" CssClass="form-control css_ma" kieu_chu="True" Enabled="false"
                                kt_xoa="G" onchange="P_KTRA('MA')" BackColor="#f6f7f7" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Tên chức danh<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" ten="tên chức danh" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                MaxLength="255" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Trạng thái<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="tt" kieu="U" DataTextField="ten" DataValueField="ma" runat="server" CssClass="form-control css_list"></Cthuvien:DR_list>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghichu" runat="server" CssClass="form-control css_ma" TextMode="MultiLine" kt_xoa="X" Height="50px"
                                MaxLength="1000"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="P_MOI();form_P_LOI('');" Title="Ấn nút để làm mới" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" class="bt_action" anh="K" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="P_NH();form_P_LOI('');" Title="Ấn nút nhập để nhập mới" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return P_XOA();form_P_LOI();" Title="Xóa dòng thông tin đang chọn" />
                    </div>
                    <div style="display: none;">
                        <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" Text="Xuất excel" OnServerClick="nhap_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="ma_nnx" runat="server" Value="1300,560" />
</asp:Content>
