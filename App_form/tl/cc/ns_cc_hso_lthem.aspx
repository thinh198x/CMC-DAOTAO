<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_cc_hso_lthem.aspx.cs" Inherits="f_ns_cc_hso_lthem"
    Title="ns_cc_hso_lthem" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Hệ số làm thêm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">

                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="trangthai,ghichu,nsd" hamRow="ns_cc_hso_lthem_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Hệ số" DataField="ten" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ten_trangthai" HeaderText="Trạng thái" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="trangthai" />
                                    <asp:BoundField DataField="ghichu" />
                                    <asp:BoundField DataField="nsd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                            ham="ns_cc_hso_lthem_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="xuat" runat="server" Text="Xuất excel" hoi="3" class="bt_action" anh="K" Width="90px" OnClick="return ns_cc_hso_lthem_P_EXCEL();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="Mã" runat="server" CssClass="form-control css_ma" kieu_chu="True" MaxLength="20"
                                kt_xoa="G" onchange="ns_cc_hso_lthem_P_KTRA('MA')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Hệ số <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" ten="Hệ số" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                MaxLength="100" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Trạng thái <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TRANGTHAI" runat="server" CssClass="form-control css_list" lke="Áp dụng,Ngừng áp dụng" ten="Trạng thái" tra="A,N" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghichu" ten="Mô tả" TextMode="MultiLine" runat="server" CssClass="form-control css_nd"
                                kieu_unicode="True" kt_xoa="X" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" Width="100px" OnClick="return ns_cc_hso_lthem_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" Width="100px" OnClick="return ns_cc_hso_lthem_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" Width="100px" OnClick="return ns_cc_hso_lthem_P_XOA();form_P_LOI();" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="100px" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                            <Cthuvien:nhap ID="mau" runat="server" Text="File mẫu" hoi="4" Width="100px" OnClick="return ns_cc_hso_lthem_P_MAU();form_P_LOI();" />
                            <Cthuvien:nhap ID="import" runat="server" Text="Import" Width="100px" OnClick="return ns_cc_hso_lthem_P_IMPORT();form_P_LOI();" />
                            <Cthuvien:nhap ID="FileMau" runat="server" Text="Mẫu excel" Width="90px" OnServerClick="FileMau_Click" />
                            <Cthuvien:nhap ID="XuatExcel" runat="server" Text="Xuất excel" Width="100px" OnServerClick="XuatExcel_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1000,530" />
</asp:Content>
