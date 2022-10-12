<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dg_ma_chung.aspx.cs" Inherits="f_ns_dg_ma_chung"
    Title="ns_dg_ma_chung" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục dùng chung đánh giá" />
                <img class="b_right" src="../../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_64">
                <div class="b_left col_60 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="nsd,nhom_ma,thamso1,thamso2,trangthai,mota"
                                hamRow="ns_dg_ma_chung_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Nhóm danh mục" DataField="ten_nhom">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mã danh mục" DataField="ma">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên danh mục" DataField="ten">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nhom_ma" />
                                    <asp:BoundField DataField="thamso1" />
                                    <asp:BoundField DataField="thamso2" />
                                    <asp:BoundField DataField="trangthai" />
                                    <asp:BoundField DataField="mota" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dg_ma_chung_P_LKE()" />
                    </div>
                </div>
                <div class="b_right col_40 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_35">Nhóm danh mục <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="NHOM_MA" ktra="DT_DG_MA_CHUNG_NHOM" ten="Nhóm danh mục" runat="server" kt_xoa="L" CssClass="form-control css_list"
                                onchange="ns_dg_ma_chung_P_MOI('GX');"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_35">Mã danh mục <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="Mã danh mục" runat="server" CssClass="form-control" kieu_chu="True"
                                kt_xoa="G" onchange="ns_dg_ma_chung_P_KTRA('MA')" MaxLength="20" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_35">Tên danh mục <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" ten="Tên danh mục" runat="server" kieu_unicode="true" CssClass="form-control" kt_xoa="X"
                                MaxLength="255" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_35">Trạng thái <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TRANGTHAI" runat="server" lke="Áp dụng,Ngừng áp dụng" tra="A,N"
                                ten="Trạng thái" CssClass="form-control css_list" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_35">Tham số 1</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="thamso1" ten="Tham số 1" runat="server" CssClass="form-control css_ma" kt_xoa="X" MaxLength="50" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_35">Tham số 2</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="thamso2" ten="Tham số 2" runat="server" CssClass="form-control css_ma" kt_xoa="X" MaxLength="50" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_35">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mota" runat="server" TextMode="MultiLine" kieu_unicode="True" CssClass="form-control css_ma" kt_xoa="X"
                                Height="50px" MaxLength="1000"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_dg_ma_chung_P_MOI('GLX');form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Width="80px" Text="Ghi" OnClick="return ns_dg_ma_chung_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" class="bt_action" anh="K" Width="80px" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Width="80px" Text="Xóa" OnClick="return ns_dg_ma_chung_P_XOA();form_P_LOI();" />
                    </div>

                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1080,500" />
    </div>
</asp:Content>

