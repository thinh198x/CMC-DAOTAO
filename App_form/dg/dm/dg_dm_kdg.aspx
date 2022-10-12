<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dg_dm_kdg.aspx.cs" Inherits="f_dg_dm_kdg"
    Title="dg_dm_kdg" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

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
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="nsd,pbo_kdg,adung_kdg,ngay_dg_d,ngay_dg_c,gchu" hamRow="dg_dm_kdg_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã kỳ đánh giá" DataField="ma" HeaderStyle-Width="120px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên kỳ đánh giá" DataField="ten">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ngày BĐ kỳ đánh giá" DataField="NG_HLUC" HeaderStyle-Width="140px">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ngày KT kỳ đánh giá" DataField="NG_HET_HLUC" HeaderStyle-Width="140px">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="BD" DataField="ngay_dg_d" HeaderStyle-Width="140px">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="KT" DataField="ngay_dg_c" HeaderStyle-Width="140px">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pbo_kdg" />
                                    <asp:BoundField DataField="adung_kdg" />
                                    <asp:BoundField DataField="gchu" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                            ham="dg_dm_kdg_P_LKE()" />

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="100px"   class="bt_action" anh="K"  Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_40 inner" id="UPa_ct">
                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label b_left col_30">Mã kỳ đánh giá <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="Mã kỳ đánh giá" runat="server" CssClass="form-control css_ma" kieu_chu="true"
                                kt_xoa="G" MaxLength="20" onchange="dg_dm_kdg_P_KTRA('MA')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label  b_left col_30">Tên kỳ đánh giá <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" ten="Tên kỳ đánh giá" runat="server" CssClass="form-control css_ma" kieu_unicode="True"
                                kt_xoa="X" MaxLength="255" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label  b_left col_30">Ngày BĐ kỳ ĐG <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NG_HLUC" ten="Ngày bắt đầu kỳ đánh giá" runat="server" CssClass="form-control icon_lich" kt_xoa="X"
                                kieu_luu="S" onchange="dg_dm_kdg_P_KTRA('NG_HLUC')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label  b_left col_30">Ngày KT kỳ ĐG</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ng_het_hluc" runat="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_unicode="True"
                                kieu_luu="S" ten="Ngày kết thúc" onchange="dg_dm_kdg_P_KTRA('NG_HET_HLUC')" />
                        </div>
                    </div>

                    <div class="b_left width_common form-group iterm_form" style="display: none;">
                        <span class="standard_label  b_left col_30"></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="pbo_kdg" ktra="DT_MA_KDG_PBO" runat="server" Width="190px" kt_xoa="X"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" style="display: none;">
                        <span class="standard_label  b_left col_30"></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="adung_kdg" ktra="DT_MA_KDG_ADUNG" runat="server" Width="190px" kt_xoa="X"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label  b_left col_30">Thời gian thực hiện ĐG từ</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_dg_d" runat="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_unicode="True"
                                kieu_luu="S" ten="Thời gian thực hiện ĐG từ" onchange="dg_dm_kdg_P_KTRA('NGAY_DG_D')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label  b_left col_30">Thời gian thực hiện ĐG đến</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_dg_c" runat="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_unicode="True"
                                kieu_luu="S" ten="Thời gian thực hiện ĐG đến" onchange="dg_dm_kdg_P_KTRA('NGAY_DG_C')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label  b_left col_30">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="gchu" ten="Mô tả" TextMode="MultiLine" runat="server" CssClass="form-control css_nd" kieu_unicode="True"
                                kt_xoa="X" Height="50px" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server"   class="bt_action" anh="K"  Width="100px" Text="Làm mới" OnClick="return dg_dm_kdg_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server"   class="bt_action" anh="K"  Width="100px" Text="Ghi" OnClick="return dg_dm_kdg_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server"   class="bt_action" anh="K"  Width="100px" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server"   class="bt_action" anh="K"  Width="100px" Text="Xóa" OnClick="return dg_dm_kdg_P_XOA();form_P_LOI();" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu1" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1150,540" />
</asp:Content>
