<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_ma_ngaynghi.aspx.cs" Inherits="f_ns_hdns_ma_ngaynghi"
    Title="ns_hdns_ma_ngaynghi" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục ngày nghỉ lễ" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_60 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="False" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="ns_hdns_ma_ngaynghi_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="60px" ItemStyle-CssClass="css_GmaN_c" />
                                    <asp:BoundField HeaderText="Mã ngày nghỉ lễ" DataField="ma" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên ngày nghỉ lễ" DataField="ten" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Ngày nghỉ" DataField="tungay" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Số ngày nghỉ" DataField="so_ngay" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_hdns_ma_ngaynghi_P_LKE()" />

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_hdns_ma_ngaynghi_P_IN();form_P_LOI();" />

                    </div>
                </div>
                <div class="b_right col_40 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Năm <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="NAM" runat="server" CssClass="form-control css_ma" kieu_so="true" ten="Năm" ToolTip="Năm" kt_xoa="K" MaxLength="4" onchange="ns_hdns_ma_ngaynghi_P_KTRA('NAM')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Mã ngày nghỉ lễ <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" kieu_chu="True" ten="Mã ngày nghỉ lễ" ToolTip="Mã ngày nghỉ lễ" kt_xoa="G" onchange="ns_hdns_ma_ngaynghi_P_KTRA('MA')" MaxLength="20" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Tên ngày nghỉ lễ <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" kieu_unicode="true" CssClass="form-control css_ma" kt_xoa="X" ten="Tên ngày nghỉ lễ" ToolTip="Tên ngày nghỉ lễ" MaxLength="100"></Cthuvien:ma>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Từ ngày <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="TUNGAY" ten="Từ ngày" runat="server" CssClass="form-control icon_lich"
                                kt_xoa="X" ToolTip="Ngày sinh" onchange="ns_hdns_ma_ngaynghi_P_KTRA('TUNGAY')"/>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Đến ngày <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="DENNGAY" runat="server" onchange="ns_hdns_ma_ngaynghi_P_KTRA('DENNGAY')"
                                CssClass="form-control icon_lich" kt_xoa="X" ten="Đến Ngày" ToolTip="Đến Ngày"></Cthuvien:ngay>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Số ngày nghỉ lễ</span>
                        <div class="input-group">
                            <Cthuvien:so ID="so_ngay" runat="server" CssClass="form-control css_ma" kt_xoa="X" ten="Số ngày nghỉ lễ" ToolTip="Số ngày nghỉ lễ" MaxLength="100"></Cthuvien:so>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Trạng thái <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TRANGTHAI" lke="Áp dụng,Ngừng áp dụng" tra="A,N" CssClass="form-control css_list" runat="server" ten="Trạng thái" ToolTip="Trạng thái" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Mô tả </span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mota" runat="server" TextMode="MultiLine" CssClass="form-control css_ma" kt_xoa="X" Height="50px" ten="Mô tả" ToolTip="Mô tả" MaxLength="1000"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_hdns_ma_ngaynghi_P_MOI();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_hdns_ma_ngaynghi_P_NH();form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" class="bt_action" anh="K" OnClick="form_P_TRA_CHON('MA,TEN');form_P_LOI();" Width="70px" />

                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" onclick="return ns_hdns_ma_ngaynghi_P_XOA();form_P_LOI();" Width="70px" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                        </div>
                    </div>
                    <div id="UPa_gchu" class="css_border" align="left">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1100,580" />
        <Cthuvien:an ID="tthai" runat="server" />
        <Cthuvien:an ID="so_id" runat="server" />
    </div>
</asp:Content>
