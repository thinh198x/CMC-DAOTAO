<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_cc_ma_ccdv.aspx.cs" Inherits="f_ns_cc_ma_ccdv"
    Title="ns_cc_ma_ccdv" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập công chuẩn theo đơn vị" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ktra="DT_NAM" kt_xoa="K" ten="Năm" runat="server" rong="150" CssClass="form-control css_list" onchange="ns_cc_ma_ccdv_P_NAM()">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ công</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG" ktra="DT_KY" kt_xoa="G" ten="Kỳ lương" runat="server" CssClass="form-control css_list" onchange="ns_cc_ma_ccdv_P_KTRA('KYLUONG');">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Công chuẩn</span>
                            <div class="input-group" style="padding-right: 20px">
                                <Cthuvien:so ID="CONG_CHUAN" runat="server" ten="Công chuẩn" so_tp="1" CssClass="form-control css_so" kt_xoa="C"
                                    BackColor="#ffffff" ToolTip="Số ngày làm việc trong tháng" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left col_100 inner" id="UPa_tk">
                        <div class="grid_table width_common">
                            <div>
                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="gridX" Width="100%"
                                    loai="N" hangKt="20" cot="chon,ten,cong_chuan,ma,ma_ct,cap,tinh_trang,tc" cotAn="ma,ma_ct,cap,tinh_trang,tc">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="70px">
                                            <HeaderTemplate>
                                                <asp:Label ID="lable1" runat="server" Text="Chọn" CssClass="text_tb"></asp:Label><br />
                                                <input id="chon_all" type="checkbox" onclick="CheckAll(this, 'CHON')" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <Cthuvien:kieu ID="chon" runat="server" lke="X," Width="70px" kt_xoa="X" ToolTip="X - Chọn đơn vị,  - Bỏ chọn đơn vị" CssClass="css_Gma_c" Text="X" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tên bộ phận">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="ten" runat="server" CssClass="css_Gnd" onclick="return ns_cc_ma_ccdv_P_LKE('T');" Width="100%" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="cong_chuan" HeaderStyle-Width="150px" HeaderText="Công chuẩn" ItemStyle-CssClass="css_Gma_r" />
                                        <asp:BoundField DataField="ma" />
                                        <asp:BoundField DataField="ma_ct" />
                                        <asp:BoundField DataField="cap" />
                                        <asp:BoundField DataField="tinh_trang" />
                                        <asp:BoundField DataField="tc" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="N" gridId="GR_lke" />
                        </div>
                        <div class="list_bt_action">
                            <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" Width="80px" class="bt_action" anh="K" OnClick="return ns_cc_ma_ccdv_P_NH();form_P_LOI();" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <Cthuvien:an ID="kthuoc" runat="server" Value="700,800" />
        <Cthuvien:an ID="all_chon" runat="server" />
        <Cthuvien:an ID="ma" runat="server" />
        <Cthuvien:an ID="ten" runat="server" />
    </div>
</asp:Content>
