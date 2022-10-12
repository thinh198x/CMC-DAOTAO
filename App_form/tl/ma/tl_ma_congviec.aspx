<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tl_ma_congviec.aspx.cs" Inherits="f_tl_ma_congviec"
    Title="tl_ma_congviec" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Công việc" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                            CssClass="table gridX" loai="X" hangKt="15" cotAn="nsd" hamRow="tl_ma_congviec_GR_lke_RowChange()">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="120px">
                                    <ItemStyle CssClass="css_Gma" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="250px">
                                    <ItemStyle CssClass="css_Gnd" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="nsd" DataField="nsd">
                                    <ItemStyle CssClass="css_Gnd" />
                                </asp:BoundField>
                            </Columns>
                        </Cthuvien:GridX>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="tl_ma_congviec_P_LKE('K')" /> 
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Mã công việc <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="Mã" runat="server" CssClass="form-control css_ma" kieu_chu="True"
                                kt_xoa="G" onchange="tl_ma_congviec_P_KTRA('MA')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Tên công việc <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" ten="Tên" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Từ ngày <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay ID="NGAYD" ten="Từ ngày" runat="server" CssClass="form-control icon_lich" placeholder="dd/MM/yyyy" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến ngày <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay ID="NGAYC" ten="Đến ngày" runat="server" CssClass="form-control icon_lich" placeholder="dd/MM/yyyy" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Đơn vị tính <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="DONVI_TINH" ten="Đơn vị tính" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Giá <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:so ID="GIA" ten="Giá" runat="server" CssClass="form-control css_so" kt_xoa="X" co_dau="K" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="mota" ten="Mô tả" runat="server" CssClass="form-control css_nd" Height="50px" kieu_unicode="True" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return tl_ma_congviec_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" OnClick="return tl_ma_congviec_P_NH();form_P_LOI();"
                            Text="Nhập" Width="70px" />
                        <Cthuvien:nhap ID="xoa" runat="server"  class="bt_action" anh="K" OnClick="return tl_ma_congviec_P_XOA();form_P_LOI();"
                            Text="Xóa" Width="70px" />
                        <Cthuvien:nhap ID="chon" runat="server"  class="bt_action" anh="K" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();"
                            Text="Chọn" Width="70px" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="755,275" />
    </div>

</asp:Content>
