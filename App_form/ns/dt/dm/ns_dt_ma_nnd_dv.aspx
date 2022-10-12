<%@ Page Title="ns_dt_ma_nnd_dv" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_ma_nnd_dv.aspx.cs" Inherits="f_ns_dt_ma_nnd_dv" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục nhóm nội dung đơn vị" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_64">
                <div class="b_left col_60 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div class="css_divb">
                            <div>
                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                    CssClass="table gridX" loai="X" cotAn="nnd" hangKt="15" hamRow="ns_dt_ma_nnd_dv_GR_lke_RowChange()">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField HeaderText="Nhóm nội dung" DataField="ten_nnd" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Mã nhóm nội dung ĐV" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Tên nhóm nội dung ĐV" DataField="ten" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Trạng thái" DataField="tthai" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField DataField="nnd" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_ma_nnd_dv_P_LKE()" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_dt_ma_nnd_dv_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_40 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã nhóm nội dung <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="NND" ten="Nhóm nội dung" runat="server" ktra="DT_NND" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Nhóm nội dung đơn vị <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="Mã nhóm nội dung đơn vị" runat="server" kieu_chu="true" CssClass="form-control css_ma" onchange="ns_dt_ma_nnd_dv_P_KTRA('MA')" kt_xoa="G" MaxLength="20" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Tên nhóm nội dung đơn vị <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" ten="Tên nhóm nội dung đơn vị" ToolTip="Tên nhóm nội dung đơn vị" runat="server" CssClass="form-control css_ma" kt_xoa="X" MaxLength="250" kieu_unicode="true" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Trạng thái <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TTHAI" runat="server" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái" ToolTip="Trạng thái" CssClass="form-control css_list" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mota" runat="server" kieu_unicode="true" CssClass="form-control css_nd" kt_xoa="X" TabIndex="5" TextMode="MultiLine" MaxLength="2000"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_dt_ma_nnd_dv_P_MOI();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_dt_ma_nnd_dv_P_NH();form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" class="bt_action" anh="K" OnClick="form_P_TRA_CHON('MA,TEN');form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" onclick="return ns_dt_ma_nnd_dv_P_XOA();form_P_LOI();" Width="70px" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />

                        </div>
                    </div>
                    <div id="UPa_gchu" class="css_border" align="left">
                        <Cthuvien:gchu ID="ghichu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <Cthuvien:an ID="kthuoc" runat="server" Value="990,600" />
</asp:Content>
