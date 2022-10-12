<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_ma_htkhac.aspx.cs" Inherits="f_ns_hdns_ma_htkhac"
    Title="ns_hdns_ma_htkhac" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục các khoản hỗ trợ khác (phụ cấp)" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="False" PageSize="1"
                                CssClass="table gridX" Width="100%" loai="X" hangKt="15" cotAn="ghichu,trangthai,hinhthuc" hamRow="ns_hdns_ma_htkhac_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã các khoản h.trợ" DataField="ma" HeaderStyle-Width="90px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tên các khoản hỗ trợ" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Số tiền" DataField="sotien" ItemStyle-CssClass="css_Gso" HeaderStyle-Width="90px"/>
                                    <asp:BoundField HeaderText="Hình thức hưởng" DataField="ten_ht" ItemStyle-CssClass="css_Gnd" HeaderStyle-Width="120px"/>
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_tt" ItemStyle-CssClass="css_Gnd_c" HeaderStyle-Width="90px"/>
                                    <asp:BoundField DataField="ghichu" />
                                    <asp:BoundField DataField="trangthai" />
                                    <asp:BoundField DataField="hinhthuc" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" gridId="GR_lke" ham="ns_hdns_ma_htkhac_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Mã các khoản h.trợ<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" ten="Mã các khoản h.trợ" kt_xoa="G" onchange="ns_hdns_ma_htkhac_P_KTRA('MA')" MaxLength="20" ReadOnly="true" kieu_chu="false" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Tên các khoản h.trợ<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu_unicode="true" ten="Tên các khoản hỗ trợ" MaxLength="255"></Cthuvien:ma>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Số tiền<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:so ID="SOTIEN" kieu_so="true" runat="server" CssClass="form-control css_so" co_dau="K" kt_xoa="X" ten="Số tiền" so_tp="3" MaxLength="20" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Hình thức hưởng</span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="HINHTHUC" ten="Hình thức hưởng" CssClass="form-control css_list" runat="server" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Trạng thái<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TRANGTHAI" runat="server" CssClass="form-control css_list" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghichu" runat="server" TextMode="MultiLine" CssClass="form-control css_nd" kt_xoa="X" Height="50px" ten="Mô tả" MaxLength="1000"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_hdns_ma_htkhac_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_hdns_ma_htkhac_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" class="bt_action" anh="K" OnClick="return form_P_TRA_CHON_GRID('GR_lke:ma,GR_lke:ten,GR_lke:sotien');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_hdns_ma_htkhac_P_XOA();form_P_LOI();" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div id="UPa_gchu" class="css_border" align="left">
            <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1150,550" />
        <Cthuvien:an ID="tthai" runat="server" />
    </div>
</asp:Content>
