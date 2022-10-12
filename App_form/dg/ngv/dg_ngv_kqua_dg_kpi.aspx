<%@ Page Title="dg_ngv_kqua_dg_kpi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="dg_ngv_kqua_dg_kpi.aspx.cs" Inherits="f_dg_ngv_kqua_dg_kpi" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Kết quả đánh giá KPIs" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_4_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left lv2 col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" ktra="DT_NAM" kieu_chu="true" CssClass="form-control css_list"
                                    kt_xoa="G" onchange="dg_ngv_kqua_dg_kpi_P_NAM('N');" kieu="S" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left lv2 col_30">Kỳ đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KY_DG" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG" kieu_chu="true" CssClass="form-control css_list"
                                    kt_xoa="G" onchange="dg_ngv_kqua_dg_kpi_P_KTRA('KY_DG');" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left lv2 col_30">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="phong" ten="Phòng" runat="server" ktra="DT_PHONG" kieu_chu="true" CssClass="form-control css_list"
                                    kt_xoa="G" onchange="dg_ngv_kqua_dg_kpi_P_KTRA('PHONG');" kieu="S" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="return dg_ngv_kqua_dg_kpi_P_LKE('M');form_P_LOI();" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" hangKt="15" Width="100%"
                                cot="chon,so_the,ho_ten,ten_cdanh,ten_phong,ten_kydg,ketqua_xl,xeploai,heso,xac_nhan,ten_xac_nhan,trangthai,ten_xac_nhan_ns,so_id"
                                cotAn="so_id,xac_nhan,trangthai">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" lke="X," ToolTip="Chọn" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ho_ten" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="ten_phong" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Kỳ đánh giá" DataField="ten_kydg" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Kết quả đánh giá" DataField="ketqua_xl" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kết quả xếp loại" DataField="xeploai" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:TemplateField HeaderText="Hệ số" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="heso" runat="server" Width="100%" CssClass="css_Gso" so_tp="2" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Mã quản lý xác nhận" DataField="xac_nhan" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Quản lý xác nhận" DataField="ten_xac_nhan" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã nhân sự xác nhận" DataField="trangthai" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Nhân sự xác nhận" DataField="ten_xac_nhan_ns" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="N" gridId="GR_lke" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Text="Ghi nhận hệ số" OnClick="return dg_ngv_kqua_dg_kpi_P_XACNHAN('GN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xacnhan" runat="server" class="bt_action" anh="K" Text="Xác nhận" OnClick="return dg_ngv_kqua_dg_kpi_P_XACNHAN('XN');form_P_LOI();" />
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" onclick="checkEmpty()" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="an_nam" runat="server" value="0" />
        <Cthuvien:an ID="an_ky_dg" runat="server" value="0" />
        <Cthuvien:an ID="an_phong" runat="server" value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1390,780" />
    </div>
</asp:Content>
