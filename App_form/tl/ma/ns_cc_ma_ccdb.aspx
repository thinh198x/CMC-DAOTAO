<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_cc_ma_ccdb.aspx.cs" Inherits="f_ns_cc_ma_ccdb"
    Title="ns_cc_ma_ccdb" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục chấm công đặc biệt" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" cotAn="so_id,ten_ncb" cot="ten_ncb,ten_cdanh,ngay_hl,so_id" hangKt="15" hamRow="ns_cc_ma_ccdb_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Cấp bậc" DataField="ten_ncb" HeaderStyle-Width="70px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay_hl" HeaderStyle-Width="85px">
                                        <ItemStyle CssClass="css_nd_c" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_ma_ccdb_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Width="100px" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form" style="display:none">
                        <span class="standard_label b_left col_30">Cấp bậc</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="ncb" ktra="DT_NCB" runat="server" CssClass="form-control css_list" ten="Cấp bậc" kt_xoa="G" onchange="ns_cc_ma_ccdb_P_KTRA('NCB');"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Chức danh <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="CDANH" ktra="DT_CDANH" runat="server" CssClass="form-control css_list" ten="Chức danh" kt_xoa="G" onchange="ns_cc_ma_ccdb_P_KTRA('THANG');"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Ngày hiệu lực <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_HL" ten="Ngày hiệu lực" runat="server" CssClass="form-control icon_lich" kieu_luu="S" ToolTip="Ngày bắt đầu kỳ lương" kt_xoa="X" onchange="ns_cc_ma_ccdb_P_KTRA('NGAY_BD');" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_cc_ma_ccdb_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_cc_ma_ccdb_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_cc_ma_ccdb_P_XOA();form_P_LOI();" />
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
