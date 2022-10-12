<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_email_sn.aspx.cs" Inherits="f_ns_ma_email_sn"
    Title="ns_ma_email_sn" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập email sinh nhật" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="gridX" loai="X" hangKt="15" cotAn="noidung" hamRow="ns_ma_email_sn_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã pháp nhân" DataField="ma_pn" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="80px" />
                                    <asp:BoundField HeaderText="Tiêu đề" ItemStyle-CssClass="css_Gnd" DataField="tieude" HeaderStyle-Width="250px" />
                                    <asp:BoundField HeaderText="Nội dung" ItemStyle-CssClass="css_Gnd" DataField="noidung" HeaderStyle-Width="10" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_ma_email_sn_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Đơn vị</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke kt_xoa="G" ID="MA_PN" ten="Giới tính" runat="server" Width="200px" ToolTip="Giới tính" ktra="DT_MA_PN"
                                    CssClass="form-control css_list" onchange="ns_ma_email_sn_P_KTRA('MA_PN')" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Tiêu đề</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TIEUDE" kieu_unicode="true" runat="server" ten="Tiêu đề email" CssClass="form-control css_ma" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Nội dung</span>
                            <div class="input-group">
                                <Cthuvien:nd ID="NOIDUNG" runat="server" CssClass="form-control css_nd" kieu_unicode="true" kt_xoa="X"
                                    Height="300px" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_ma_email_sn_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_ma_email_sn_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_ma_email_sn_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="mau" runat="server" Width="70px" class="bt_action" anh="K" Text="File mẫu" OnClick="return ns_ma_email_sn_FI_NH();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1100,660" />
    </div>
</asp:Content>
