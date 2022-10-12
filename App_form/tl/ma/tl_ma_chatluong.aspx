<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tl_ma_chatluong.aspx.cs" Inherits="f_tl_ma_chatluong"
    Title="tl_ma_chatluong" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Chất lượng" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">

                    <div class="grid_table width_common">
                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                            CssClass="table gridX" loai="X" hangKt="15" cotAn="nsd" hamRow="tl_ma_chatluong_GR_lke_RowChange()">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="120px">
                                    <ItemStyle CssClass="css_Gma" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="120px">
                                    <ItemStyle CssClass="css_Gnd" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="nsd" DataField="nsd">
                                    <ItemStyle CssClass="css_nd" />
                                </asp:BoundField>
                            </Columns>
                        </Cthuvien:GridX>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="tl_ma_chatluong_P_LKE('K')" /> 
                    </div>

                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã chất lượng <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" MaxLength="10" kt_xoa="G"
                                onchange="tl_ma_chatluong_P_KTRA('MA')" ten="Mã chất lượng" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Tên chất lượng <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" MaxLength="200" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                 ten="Tên chất lượng" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return tl_ma_chatluong_P_MOI();form_P_LOI();" />
                        <button onclick="return tl_ma_chatluong_P_NH();form_P_LOI();" class="bt_action"><span class="txUnderline">N</span>hập</button>
                        <button class="bt_action" onclick="return tl_ma_chatluong_P_XOA();form_P_LOI();"><span class="txUnderline">X</span>óa</button>
                        <button onclick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" class="bt_action"><span class="txUnderline">C</span>họn</button>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="700,500" />
    </div>
</asp:Content>
