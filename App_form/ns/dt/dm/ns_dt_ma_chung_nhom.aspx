<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dt_ma_chung_nhom.aspx.cs" Inherits="f_ns_dt_ma_chung_nhom"
    Title="ns_dt_ma_chung_nhom" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục nhóm dùng chung cho đào tạo" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_64">
                <div class="b_left col_60 inner" id="UPa_tk">

                    <div class="grid_table width_common">
                        <div class="css_divb">
                            <div>
                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                    CssClass="table gridX" loai="X" cotAn="" hangKt="15" hamRow="ns_dt_ma_chung_nhom_GR_lke_RowChange()">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField HeaderText="Mã nhóm danh mục" DataField="ma" HeaderStyle-Width="140px">
                                            <ItemStyle CssClass="css_Gma" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Tên nhóm danh mục" DataField="ten">
                                            <ItemStyle CssClass="css_Gnd" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="css_Gnd" />
                                        </asp:BoundField>
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_ma_chung_nhom_P_LKE()" />
                        </div>
                    </div>
                </div>
                <div class="b_right col_40 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã nhóm danh mục <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="Mã nhóm danh mục" ToolTip="Mã nhóm danh mục" runat="server" CssClass="form-control css_ma" kieu_chu="True"
                                kt_xoa="G" onchange="ns_dt_ma_chung_nhom_P_KTRA('MA')" MaxLength="20" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Tên nhóm danh mục <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" ten="Tên nhóm danh mục" ToolTip="Tên nhóm danh mục" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" MaxLength="250" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Trạng thái <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TRANGTHAI" runat="server" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái" ToolTip="Trạng thái" CssClass="form-control css_list" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mota" runat="server" TextMode="MultiLine" kieu_unicode="True" CssClass="form-control css_nd" kt_xoa="X" 
                                 MaxLength="200"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_dt_ma_chung_nhom_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="100px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_dt_ma_chung_nhom_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Width="100px" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="100px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_dt_ma_chung_nhom_P_XOA();form_P_LOI();" />

                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1060,500" />
</asp:Content>
