<%@ Page Title="ns_dsach_thieu_plenh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dsach_thieu_plenh.aspx.cs" Inherits="f_ns_dsach_thieu_plenh" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Import danh sách thiếu phiếu lệnh" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Năm </span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="nam_tk" kt_xoa="X" ten="Năm" ktra="DT_NAM_TK" runat="server" onchange="ns_dsach_thieu_plenh_P_NAM('TK')" CssClass="form-control css_list" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Kỳ công lương</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="kyluong_tk" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_LUONG_TK" kieu_chu="true" onchange="ns_dsach_thieu_plenh_P_KTRA('KY_DG');" CssClass="form-control css_list" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="timkiem" runat="server" anh="K" class="bt_action" Text="Tìm kiếm" hoi="0" OnClick="return ns_dsach_thieu_plenh_P_LKE('M');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="ky_luong_id" hamRow="ns_dsach_thieu_plenh_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="5%" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="15%" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kỳ đánh giá" DataField="ky_luong_id" HeaderStyle-Width="40%" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Kỳ đánh giá" DataField="ten_ky_luong_id" HeaderStyle-Width="40%" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dsach_thieu_plenh_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" kt_xoa="X" ten="Năm" ktra="DT_NAM" runat="server" onchange="ns_dsach_thieu_plenh_P_NAM('N')" CssClass="form-control css_list" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ lương <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KY_LUONG_ID" ten="Kỳ công lương" runat="server" ktra="DT_KY" kieu_chu="true" CssClass="form-control css_list" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="grid_table width_common">
                            <div style="overflow-x: scroll">
                                <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" ctrT="so_tt" ctrS="nhap"
                                    CssClass="table gridX" loai="N" hangKt="15" gchuId="gchu" 
                                    cot="so_the,hoten,ten_cdanh,ten_phong,so_plenh_thieu"
                                    Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Mã nhân viên" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="so_the" runat="server" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" Width="100%" Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Họ tên" HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="hoten" runat="server" CssClass="css_Gma" kt_xoa="X" Width="100%" Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Chức danh" HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="ten_cdanh" runat="server" CssClass="css_Gma" kt_xoa="X" Width="100%" Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Đơn vị" HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="ten_phong" runat="server" CssClass="css_Gma" kt_xoa="X" Width="100%" Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Số phiếu lệnh thiếu" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="so_plenh_thieu" runat="server" CssClass="css_Gma_r" kt_xoa="X" Width="100%" Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_ct_slide" runat="server" loai="N" gridId="GR_ct" />
                        </div>
                        <div class="list_bt_action">
                            <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_dsach_thieu_plenh_P_MOI();form_P_LOI();" />
                            <Cthuvien:nhap ID="Nhap3" runat="server" Width="80px" class="bt_action" anh="K" Text="File mẫu" OnClick="return ns_dsach_thieu_plenh_P_MAU();form_P_LOI();" />
                            <Cthuvien:nhap ID="Nhap4" runat="server" class="bt_action" anh="K" Text="Import excel" OnClick="return ns_dsach_thieu_plenh_FILE_Import();form_P_LOI('');" />
                            <div style="display: none;">
                                <Cthuvien:nhap ID="btn_excel_mau" runat="server" Text="Mẫu excel" Width="70px" OnServerClick="btn_excel_mau_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="aky_dg" runat="server" value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,750" />
    </div>
</asp:Content>
