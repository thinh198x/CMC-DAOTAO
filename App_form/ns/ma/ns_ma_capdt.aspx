<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_capdt.aspx.cs" Inherits="f_ns_ma_capdt"
    Title="ns_ma_capdt" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Trình độ đào tạo" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" Width="100%" hangKt="15" cotAn="nsd" hamRow="ns_ma_capdt_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="60%">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Cấp" DataField="cap">
                                        <ItemStyle CssClass="css_so" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="nsd" DataField="nsd">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" rong="100" runat="server" loai="X" gridId="GR_lke"
                            ham="ns_ma_capdt_P_LKE()" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_15">Mã<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" runat="server" ten="Mã" CssClass="form-control css_ma" kieu_chu="True" MaxLength="10"
                                kt_xoa="G" onchange="ns_ma_capdt_P_KTRA('MA')" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_15">Tên<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" kieu_unicode="True" ten="Tên" kt_xoa="X" MaxLength="100"></Cthuvien:ma>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_15">Cấp<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:so ID="CAP" ten="Cấp" runat="server" CssClass="form-control css_ma" kt_xoa="X" MaxLength="3" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" Text="Nhập" anh="K" Width="100px" OnClick="return ns_ma_capdt_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" Text="Xóa" anh="K" Width="130px" OnClick="return ns_ma_capdt_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" class="bt_action" Text="Chọn" Width="80px" anh="K" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="770,646" />
</asp:Content>
