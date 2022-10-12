<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tl_ma_spham.aspx.cs" Inherits="f_tl_ma_spham"
    Title="tl_ma_spham" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Sản phẩm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                            CssClass="table gridX" loai="X" hangKt="15" cotAn="donvi,nsd" hamRow="tl_ma_spham_GR_lke_RowChange()">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="120px">
                                    <ItemStyle CssClass="css_Gma" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="250px">
                                    <ItemStyle CssClass="css_Gnd" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="đơn vị" DataField="donvi" HeaderStyle-Width="250px">
                                    <ItemStyle CssClass="css_Gnd" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="nsd" DataField="nsd">
                                    <ItemStyle CssClass="css_Gnd" />
                                </asp:BoundField>
                            </Columns>
                        </Cthuvien:GridX>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="tl_ma_spham_P_LKE('K')" /> 
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Mã sản phẩm <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" MaxLength="10" runat="server" CssClass="form-control css_ma" kieu_chu="True" kt_xoa="G"
                                onchange="tl_ma_spham_P_KTRA('MA')" ten="Mã sản phẩm" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Tên sản phẩm <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" MaxLength="100" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                W ten="Tên sản phẩm" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Đơn vị tính <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="DONVI" MaxLength="10" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                 ten="Đơn vị sản phẩm" ToolTip="Đơn vị sản phẩm" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return tl_ma_spham_P_MOI();form_P_LOI();" />
                        <button onclick="return tl_ma_spham_P_NH();form_P_LOI();" class="bt_action"><span class="txUnderline">N</span>hập</button>
                        <button class="bt_action" onclick="return tl_ma_spham_P_XOA();form_P_LOI();"><span class="txUnderline">X</span>óa</button>
                        <button onclick="return form_P_TRA_CHON('MA,TEN,donvi');form_P_LOI();" class="bt_action"><span class="txUnderline">C</span>họn</button>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="880,530" />
    </div>
</asp:Content>
