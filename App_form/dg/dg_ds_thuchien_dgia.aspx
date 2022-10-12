<%@ Page Title="dg_ds_thuchien_dgia" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="dg_ds_thuchien_dgia.aspx.cs" Inherits="f_dg_ds_thuchien_dgia" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Tổng hợp danh sách thực hiện đánh giá" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <%--  <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label b_left col_20">Nhóm chức danh</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="n_chucdanh_tk" kt_xoa="G" CssClass="form-control css_list" ten="Yêu cầu tuyển dụng"
                                ktra="DT_NH_CHUCDANH_TK" runat="server" onchange="dg_ds_thuchien_dgia_P_NHOM_CDANH('N_CHUCDANH_TK')">                                                                                
                            </Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label b_left col_20">Chức danh</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="chucdanh_tk" CssClass="form-control css_list" ten="Mã yêu cầu TD" ktra="DT_CHUCDANH_TK" runat="server" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" Width="120px" OnClick="return dg_ds_thuchien_dgia_P_LKE();form_P_LOI();" />
                    </div>--%>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="L" hangKt="15" cotAn="so_id" hamRow="dg_ds_thuchien_dgia_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="50px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Kỳ ĐG" DataField="ky_dg"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Ngày tổng hợp" DataField="ngayd" HeaderStyle-Width="120px"
                                        ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="dg_ds_thuchien_dgia_P_LKE('K')" />
                    </div>
                    <%--<div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" class="bt_action" anh="K" OnServerClick="nhap_Click" Width="120px" />
                    </div>--%>
                </div>

                <div class="b_right col_50 inner" id="UPa_ct">

                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Nhóm nội dung" runat="server" ktra="DT_NAM" kieu_chu="true" CssClass="form-control css_list"
                                    kt_xoa="G" onchange="dg_ds_thuchien_dgia_P_KTRA('NAM');" kieu="S" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ky_dg" kt_xoa="X" ten="Yêu cầu tuyển dụng" ktra="DT_KY_DG" runat="server"
                                    CssClass="form-control css_list">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày tổng hợp</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayd" runat="server" ten="Ngày tổng hợp" CssClass="form-control icon_lich" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Ngày tổng hợp" />
                            </div>
                        </div>
                        <div class="list_bt_action">
                            <Cthuvien:nhap ID="tim" runat="server" Text="Tổng hợp" class="bt_action" anh="K" Width="120px" OnClick="return dg_ds_thuchien_dgia_P_TH();form_P_LOI();" />
                        </div>
                    </div>

                    <div class="grid_table width_common">
                        <div style="overflow-x:scroll;">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cot="so_the,ten,ten_cdanh,ten_phong,ngay_th,da_dg" hangKt="15" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Mã nhân viên">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="so_the" Enabled="false" runat="server" Width="100%" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Họ tên" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten" Enabled="false" runat="server" Width="100%" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chức danh" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten_cdanh" Enabled="false" runat="server" Width="100%" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Đơn vị" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten_phong" Enabled="false" runat="server" Width="100%" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày thực hiện đánh giá">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ngay_th" Enabled="false" runat="server" Width="100%" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Đã thực hiện đánh giá">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="da_dg" Enabled="false" runat="server" Width="100%" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_ct_slide" loai="N" runat="server" gridId="GR_ct" />
                        </div>
                    </div>


                    <%--<div class="list_bt_action">
                        <Cthuvien:nhap ID="tao" runat="server" Text="Làm mới" Width="100px" class="bt_action" anh="K" OnClick="return dg_ds_thuchien_dgia_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="ghi" runat="server" Width="100px" Text="Nhập" class="bt_action" anh="K" OnClick="return dg_ds_thuchien_dgia_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="delete" runat="server" Width="100px" Text="Xóa" class="bt_action" anh="K" OnClick="return dg_ds_thuchien_dgia_P_XOA();form_P_LOI();" />
                    </div>--%>
                </div>
                <div id="UPa_gchu">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1368,830" />
        <Cthuvien:an ID="Anncdanh" runat="server" />
        <Cthuvien:an ID="Ancdanh" runat="server" />
    </div>
</asp:Content>
