<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_lqh.aspx.cs" Inherits="f_ns_ma_lqh"
    Title="ns_ma_lqh" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="hr_ns_ma_lqh" runat="server" Text="Danh mục loại quan hệ" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="nsd" hamRow="ns_ma_lqh_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="120px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="250px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="nsd" DataField="nsd">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" rong="100" runat="server" loai="X" gridId="GR_lke" ham="ns_ma_lqh_P_LKE()" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_15">Mã<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" ten="Mã loại quan hệ"
                                kt_xoa="G" onchange="ns_ma_lqh_P_KTRA('MA')" MaxLength="20" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_15">Tên<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" ten="Tên" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_ma_lqh_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Lưu" class="bt_action" anh="K" OnClick="return ns_ma_lqh_P_NH();form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_ma_lqh_P_XOA();form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" class="bt_action" anh="K" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" Width="70px" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="755,490" />
</asp:Content>
