<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_htkl.aspx.cs" Inherits="f_ns_ma_htkl"
    Title="ns_ma_htkl" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục hình thức kỷ luật" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" Width="100%" loai="X" hangKt="15" cotAn="nsd,ghichu,tt" hamRow="ns_ma_htkl_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="ma" HeaderText="Mã hình thức KL" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ten" HeaderText="Tên hình thức KL" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="tien" HeaderText="Số tiền" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="ngay_hl" HeaderText="Ngày hiệu lực" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="ten_tt" HeaderText="Trạng thái" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="tt" />
                                    <asp:BoundField DataField="ghichu" />
                                    <asp:BoundField DataField="nsd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                            ham="ns_ma_htkl_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_25">Mã hình thức KL<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ma" ten="Mã hình thức KL" runat="server" CssClass="form-control css_ma" kieu_chu="false" kt_xoa="G"
                                onfocusout="ns_ma_htkl_P_KTRA('MA')" MaxLength="20" ToolTip-="Mã hình thức khen thưởng" ReadOnly="true" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_25">Tên hình thức KL<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" ten="Tên hình thức KL" runat="server" CssClass="form-control css_ma" kieu_unicode="True"
                                kt_xoa="X" MaxLength="100" ToolTip="Tên hình thức kỷ luật" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_25">Số tiền trừ<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:so ID="TIEN" kieu_so="true" runat="server" CssClass="form-control css_so" co_dau="K" kt_xoa="X" ten="Số tiền" so_tp="3" MaxLength="20" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_25">Ngày hiệu lực<span class="require">*</span> </span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_HL" ten="Ngày hiệu lực" runat="server" CssClass="form-control icon_lich" kieu_luu="S" kt_xoa="X" ToolTip="Ngày hiệu lực" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_25">Trạng thái<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TT" runat="server" CssClass="form-control css_list" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_25">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghichu" runat="server" Height="50px" TextMode="MultiLine" CssClass="form-control css_nd" kieu_unicode="True"
                                kt_xoa="X" ten="Mô tả" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_ma_htkl_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_ma_htkl_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Width="80px" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_ma_htkl_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1250,530" />
</asp:Content>
