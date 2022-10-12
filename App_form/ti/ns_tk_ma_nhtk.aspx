<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_tk_ma_nhtk.aspx.cs" Inherits="f_ns_tk_ma_nhtk"
    Title="ns_tk_ma_nhtk" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Mã nhóm tìm kiếm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_64">
                <div class="b_left col_60 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                            CssClass="table gridX" loai="X" hangKt="5" cotAn="nsd" hamRow="ns_tk_ma_nhtk_GR_lke_RowChange()">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="90px">
                                    <ItemStyle CssClass="css_Gma" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="150px">
                                    <ItemStyle CssClass="css_Gnd" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Bảng" DataField="bang" HeaderStyle-Width="150px">
                                    <ItemStyle CssClass="css_Gnd" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="nsd" DataField="nsd">
                                    <ItemStyle CssClass="css_Gnd" />
                                </asp:BoundField>
                            </Columns>
                        </Cthuvien:GridX>
                        <div id="GR_lke_td">
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_tk_ma_nhtk_P_LKE('K')" /> 
                        </div>
                    </div>
                </div>
                <div class="b_right col_40 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="Mã" runat="server" CssClass="form-control css_ma" kieu_chu="True" kt_xoa="G"
                                onchange="ns_tk_ma_nhtk_P_KTRA('MA')" />
                            <div style="display: none;">
                                <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Tên</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                ten="Tên" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Bảng</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="BANG" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                ten="Bảng" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <button onclick="return ns_tk_ma_nhtk_P_NH();form_P_LOI();" class="bt_action"><span class="txUnderline">N</span>hập</button>
                        <button class="bt_action" onclick="return ns_tk_ma_nhtk_P_XOA();form_P_LOI();"><span class="txUnderline">X</span>óa</button>
                        <button onclick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" class="bt_action"><span class="txUnderline">C</span>họn</button>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="755,380" />
</asp:Content>

