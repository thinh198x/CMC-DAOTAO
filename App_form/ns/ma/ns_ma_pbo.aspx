<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_pbo.aspx.cs" Inherits="f_ns_ma_pbo"
    Title="ns_ma_pbo" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục phân bổ" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="nsd,ghichu,tt" hamRow="ns_ma_pbo_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã phân bổ" DataField="ma" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên phân bổ" DataField="ten" HeaderStyle-Width="150px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_tt"></asp:BoundField>
                                    <asp:BoundField HeaderText="Ghi chú" DataField="ghichu"></asp:BoundField>
                                    <asp:BoundField HeaderText="nsd" DataField="nsd">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="tt"></asp:BoundField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" gridId="GR_lke" ham="ns_ma_pbo_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_ma_pbo_P_IN();form_P_LOI();" Width="100px" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Mã phân bổ<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" ten="Mã phân bổ"
                                kt_xoa="G" onfocusout="ns_ma_pbo_P_KTRA('MA')" MaxLength="20"></Cthuvien:ma>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Tên phân bổ<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" ten="Tên phân bổ" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                MaxLength="100"></Cthuvien:ma>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Trạng thái<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TT" runat="server" CssClass="form-control css_list" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ToolTip="Trạng thái" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ghichu" runat="server" ten="Mô tả" kieu_unicode="true" ToolTip="Mô tả" CssClass="form-control css_ma" kt_xoa="X" Height="50px" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_ma_pbo_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_ma_pbo_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Width="80px" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" class="bt_action" anh="K" runat="server" Width="80px" Text="Xóa" OnClick="return ns_ma_pbo_P_XOA();form_P_LOI();" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="900,550" />
</asp:Content>
