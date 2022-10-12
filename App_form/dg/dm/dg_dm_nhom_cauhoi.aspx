<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dg_dm_nhom_cauhoi.aspx.cs" Inherits="f_dg_dm_nhom_cauhoi"
    Title="dg_dm_nhom_cauhoi" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục nhóm câu hỏi" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_64">
                <div class="b_left col_60 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="trangthai,mo_ta" hamRow="dg_dm_nhom_cauhoi_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhóm câu hỏi" DataField="ma" HeaderStyle-Width="120px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên nhóm câu hỏi" DataField="ten">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" HeaderStyle-Width="120px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai" HeaderStyle-Width="120px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mo_ta" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                            ham="dg_dm_nhom_cauhoi_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="100px"   class="bt_action" anh="K"  Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_40 inner" id="UPa_ct">
                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label b_left col_30">Mã nhóm câu hỏi <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="Mã nhóm câu hỏi" runat="server" CssClass="form-control css_ma" kieu_chu="true"
                                kt_xoa="G" MaxLength="20" onchange="dg_dm_nhom_cauhoi_P_KTRA('MA')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label  b_left col_30">Tên nhóm câu hỏi <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" ten="Tên nhóm câu hỏi" runat="server" CssClass="form-control css_ma" kieu_unicode="True"
                                kt_xoa="X" MaxLength="255" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label  b_left col_30">Trạng thái <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TRANGTHAI" runat="server" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái" ToolTip="Trạng thái" CssClass="form-control css_list" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label  b_left col_30">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mo_ta" ten="Mô tả" TextMode="MultiLine" runat="server" CssClass="form-control css_nd" kieu_unicode="True"
                                kt_xoa="X" Height="50px" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" Width="100px"   class="bt_action" anh="K"  OnClick="return dg_dm_nhom_cauhoi_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="100px"   class="bt_action" anh="K"  Text="Ghi" OnClick="return dg_dm_nhom_cauhoi_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Width="100px"   class="bt_action" anh="K"  Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="100px"   class="bt_action" anh="K"  Text="Xóa" OnClick="return dg_dm_nhom_cauhoi_P_XOA();form_P_LOI();" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu1" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1000,540" />
</asp:Content>
