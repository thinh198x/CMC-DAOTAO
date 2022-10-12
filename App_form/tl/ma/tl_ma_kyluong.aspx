<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tl_ma_kyluong.aspx.cs" Inherits="f_tl_ma_kyluong"
    Title="tl_ma_kyluong" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục kỳ công lương" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_60 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" cotAn="nsd,thang,so_id,cong_chuan" cot="nam,ten,ngay_bd,ngay_kt,cong_chuan,nsd,thang,so_id" hangKt="15" hamRow="tl_ma_kyluong_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="70px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên kỳ công" DataField="ten">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ngày bắt đầu" DataField="ngay_bd" HeaderStyle-Width="85px">
                                        <ItemStyle CssClass="css_nd_c" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ngày kết thúc" DataField="ngay_kt" HeaderStyle-Width="85px">
                                        <ItemStyle CssClass="css_nd_c" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Công chuẩn" DataField="cong_chuan" HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="css_nd_c" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nsd" />
                                    <asp:BoundField DataField="thang" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="tl_ma_kyluong_P_LKE()" />

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Width="100px" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_40 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Năm <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="NAM" runat="server" MaxLength="4" ten="Năm kỳ công/lương" kt_xoa="G" CssClass="form-control css_ma" kieu_so="true"
                                onchange="tl_ma_kyluong_P_KTRA('THANG');" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Tháng <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="THANG" ktra="DT_THANG" runat="server" CssClass="form-control css_list" ten="Tháng kỳ lương" kt_xoa="G" onchange="tl_ma_kyluong_P_KTRA('THANG');"></Cthuvien:DR_lke>

                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Tên kỳ công <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" ten="Tên" runat="server" MaxLength="200" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" />

                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Ngày bắt đầu <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_BD" ten="Ngày bắt đầu kỳ lương" runat="server" CssClass="form-control icon_lich" kieu_luu="S" ToolTip="Ngày bắt đầu kỳ lương" kt_xoa="X" onchange="tl_ma_kyluong_P_KTRA('NGAY_BD');" />

                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Ngày kết thúc <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_KT" ten="Ngày kết thúc kỳ lương" runat="server" CssClass="form-control icon_lich" kieu_luu="S" kieu_date="true" ToolTip="Ngày kết thúc kỳ lương" kt_xoa="X" onchange="tl_ma_kyluong_P_KTRA('NGAY_KT');" />

                        </div>
                        <div style="display: none;">

                            <Cthuvien:so ID="cong_chuan" runat="server" MaxLength="2" ten="Công chuẩn" kt_xoa="X" CssClass="form-control css_ma" so_tp="1"
                                co_dau="K" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Text="Làm mới" OnClick="return tl_ma_kyluong_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K"  Text="Ghi" OnClick="return tl_ma_kyluong_P_NH();form_P_LOI();" />
                       <%-- <Cthuvien:nhap ID="chon" runat="server" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />--%>
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K"  Text="Xóa" OnClick="return tl_ma_kyluong_P_XOA();form_P_LOI();" />

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1060,530" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
    </div>
</asp:Content>
