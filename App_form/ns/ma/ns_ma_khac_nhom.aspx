﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_khac_nhom.aspx.cs" Inherits="f_ns_ma_khac_nhom"
    Title="ns_ma_khac_nhom" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục nhóm biến động bảo hiểm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" cotAn="nsd,trang_thai,gchu" hangKt="15" hamRow="ns_ma_khac_nhom_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhóm biến động" DataField="ma" HeaderStyle-Width="160px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên nhóm biến động" DataField="ten">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="nsd" DataField="nsd">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_tt" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="100px" />
                                    <asp:BoundField DataField="trang_thai" />
                                    <asp:BoundField DataField="gchu" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_ma_khac_nhom_P_LKE('K')" />

                    </div>

                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã nhóm biến động <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="Mã" runat="server" CssClass="form-control css_ma" kieu_chu="True" MaxLength="30"
                                kt_xoa="G" onchange="ns_ma_khac_nhom_P_KTRA('MA')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Tên nhóm biến động <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" ten="Tên" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Trạng thái <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TRANG_THAI" runat="server" CssClass="form-control css_list" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Ghi chú</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="gchu" ten="Ghi chú" runat="server" CssClass="form-control css_nd" Height="50px" TextMode="MultiLine" kieu_unicode="True"
                                kt_xoa="X" MaxLength="2000" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_ma_khac_nhom_P_NH();form_P_LOI();" Width="80px" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" OnClick="return ns_ma_khac_nhom_P_MOI();form_P_LOI();" Width="80px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_ma_khac_nhom_P_XOA();form_P_LOI();" Width="80px" />
                        <Cthuvien:nhap ID="chon" runat="server" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" Width="80px" />

                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1010,500" />
</asp:Content>
