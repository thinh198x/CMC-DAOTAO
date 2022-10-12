<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_field.aspx.cs" Inherits="f_ns_ma_field"
    Title="ns_ma_field" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục các trường thông tin" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Loại <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_nhap ID="loai_tk" onchange="ns_ma_field_P_LKE('K')" ten="Loại" runat="server"
                                    CssClass="form-control" kieu="S">
                                    <asp:ListItem Selected="True" Text="Hợp đồng" Value="HD"></asp:ListItem>
                                    <asp:ListItem Text="Quyết định" Value="QD"></asp:ListItem>
                                </Cthuvien:DR_nhap>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên trường</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_tk" runat="server" onchange="ns_ma_field_P_LKE()" ten="Mã" CssClass="form-control css_ma" kieu_chu="True"
                                    kt_xoa="G"></Cthuvien:ma>
                            </div>
                        </div>
                    </div>

                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="nsd,loai" hamRow="ns_ma_field_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="120px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="250px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Loại" DataField="loai">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="nsd" DataField="nsd">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div id="GR_lke_td">
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_ma_field_P_LKE('K')" /> 
                        </div>
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form" style="display: none;">
                        <span class="standard_label b_left col_30">Loại <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="NHOM_MA" runat="server" CssClass="form-control" tra="HD,QD" lke="Hợp đồng,Quyết định" ></Cthuvien:DR_list>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="Mã" runat="server" CssClass="form-control css_ma" kieu_chu="True"
                                kt_xoa="G" onchange="ns_ma_field_P_KTRA('MA')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Tên <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" ten="Tên" runat="server" kieu_unicode="true" CssClass="form-control css_ma" kt_xoa="X"/>
                            <div style="display: none;">
                                <Cthuvien:DR_list ID="TRANGTHAI" ten="Trạng thái" runat="server"
                                    tra="A,N" lke="Áp dụng,Ngừng áp dụng"
                                    CssClass="form-control" kieu="S">
                                </Cthuvien:DR_list>
                                <Cthuvien:ma ID="thamso1" ten="Tham số 1" runat="server" CssClass="css_form" kt_xoa="X" Width="190px" />
                                <Cthuvien:ma ID="thamso2" ten="Tham số 2" runat="server" CssClass="css_form" kt_xoa="X" Width="190px" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <button onclick="return ns_ma_field_P_NH();form_P_LOI();" class="bt_action"><span class="txUnderline">N</span>hập</button>
                        <button class="bt_action" onclick="return ns_ma_field_P_XOA();form_P_LOI();"><span class="txUnderline">X</span>óa</button>
                        <button onclick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" class="bt_action"><span class="txUnderline">C</span>họn</button>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1000,500" />
</asp:Content>
