<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dg_ma_kdg.aspx.cs" Inherits="f_ns_dg_ma_kdg"
    Title="ns_dg_ma_kdg" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục kỳ đánh giá" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_64">
                <div class="b_left col_60 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="nsd,ten_kdg_theo,kdg_theo,pbo_kdg,adung_kdg,ngay_dg_d,ngay_dg_c,gchu" hamRow="ns_dg_ma_kdg_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã kỳ đánh giá" DataField="ma">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên kỳ đánh giá" DataField="ten">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ngày BĐ kỳ đánh giá" DataField="NG_HLUC">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ngày KT kỳ đánh giá" DataField="NG_HET_HLUC">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="BD" DataField="ngay_dg_d">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="KT" DataField="ngay_dg_c">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="kdg_theo" />
                                    <asp:BoundField DataField="ten_kdg_theo" />
                                    <asp:BoundField DataField="pbo_kdg" />
                                    <asp:BoundField DataField="adung_kdg" />
                                    <asp:BoundField DataField="gchu" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dg_ma_kdg_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" class="bt_action" runat="server" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_40 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã kỳ đánh giá<span class="require">*</span> </span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="Mã kỳ đánh giá" runat="server" CssClass="form-control css_ma" kieu_chu="true"
                                kt_xoa="G" MaxLength="20" onchange="ns_dg_ma_kdg_P_KTRA('MA')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Tên kỳ đánh giá<span class="require">*</span> </span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" ten="Tên kỳ đánh giá" runat="server" CssClass="form-control css_ma" kieu_unicode="True"
                                kt_xoa="X" MaxLength="255" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Ngày BĐ kỳ ĐG <span class="require">*</span> </span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NG_HLUC" runat="server" ten="Ngày BĐ kỳ ĐG" CssClass="form-control icon_lich"
                                MaxLength="10" kieu_chu="true" kt_xoa="X" onchange="ns_dg_ma_kdg_P_KTRA('NG_HLUC')" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Ngày KT kỳ ĐG <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NG_HET_HLUC" runat="server" ten="Ngày KT kỳ ĐG" CssClass="form-control icon_lich"
                                MaxLength="10" kieu_chu="true" kt_xoa="X" onchange="ns_dg_ma_kdg_P_KTRA('NG_HET_HLUC')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Kỳ đánh giá theo</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="kdg_theo" ktra="DT_MA_KDG_PBO" runat="server" kt_xoa="X" ten="Kỳ đánh giá theo" CssClass="form-control css_list"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Phân bổ kỳ đánh giá</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="pbo_kdg" ktra="DT_MA_KDG_PBO" runat="server" kt_xoa="X" ten="Phân bổ kỳ đánh giá" CssClass="form-control css_list"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Kỳ ĐG áp dụng cho</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="adung_kdg" ktra="DT_MA_KDG_ADUNG" runat="server" kt_xoa="X" CssClass="form-control css_list"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Thời gian thực hiện ĐG từ</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_dg_d" runat="server" ten="Thời gian thực hiện ĐG từ" CssClass="form-control icon_lich"
                                MaxLength="10" kieu_chu="true" kt_xoa="X" onchange="ns_dg_ma_kdg_P_KTRA('NGAY_DG_D')" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Thời gian thực hiện ĐG đến</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_dg_c" runat="server" ten="Thời gian thực hiện ĐG đến" CssClass="form-control icon_lich"
                                MaxLength="10" kieu_chu="true" kt_xoa="X" onchange="ns_dg_ma_kdg_P_KTRA('NGAY_DG_C')" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="gchu" ten="Mô tả" TextMode="MultiLine" runat="server" CssClass="form-control css_ma" kieu_unicode="True"
                                kt_xoa="X" Height="50px" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" Width="80px" class="bt_action" anh="K" OnClick="return ns_dg_ma_kdg_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="80px" class="bt_action" anh="K" OnClick="return ns_dg_ma_kdg_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="80px" class="bt_action" anh="K" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="80px" class="bt_action" anh="K" OnClick="return ns_dg_ma_kdg_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1150,540" />
    </div>
</asp:Content>
