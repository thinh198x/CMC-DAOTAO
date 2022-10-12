<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_biendongbhxh.aspx.cs" Inherits="f_ns_ma_biendongbhxh"
    Title="ns_ma_biendongbhxh" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục phương án" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15"
                                cotAn="nhom_biendong,trang_thai,mota" hamRow="ns_ma_biendongbhxh_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Nhóm biến động" DataField="ten_nhom_biendong" HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mã phương án" DataField="ma" HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên phương án" DataField="ten" HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trang_thai" HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nhom_biendong" />
                                    <asp:BoundField DataField="trang_thai" />
                                    <asp:BoundField DataField="mota" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke" ham="ns_ma_biendongbhxh_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Width="100px" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Nhóm biến động <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="NHOM_BIENDONG" runat="server" CssClass="form-control css_list" lke=",Tăng,Giảm,Điều chỉnh" tra=",T,G,DC" ten="Nhóm biến động" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã phương án <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="Mã phương án" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Tên phương án<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten" ten="Tên phương án" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Trạng thái <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TRANG_THAI" runat="server" CssClass="form-control css_list" lke=",Áp dụng,Ngừng áp dụng" tra=",A,N" ten="Trạng thái" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mota" ten="Mô tả" runat="server" CssClass="form-control css_nd" kieu_unicode="True" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_ma_biendongbhxh_P_NH();form_P_LOI();" Width="80px" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" OnClick="return ns_ma_biendongbhxh_P_MOI();form_P_LOI();" Width="80px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_ma_biendongbhxh_P_XOA();form_P_LOI();" Width="80px" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1060,500" />
</asp:Content>
