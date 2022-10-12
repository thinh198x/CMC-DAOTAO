<%@ Page Title="ns_ld_da" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ld_da.aspx.cs" Inherits="f_ns_ld_da" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quản lý lao động theo dự án" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Dự án</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="duan_tk" runat="server" Width="350px" kt_xoa="X" ten="Đợt tuyển dụng" kieu_unicode="true" CssClass="form-control css_form" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="timkiem" runat="server" anh="K" class="bt_action" Text="Tìm kiếm" hoi="0" OnClick="return ns_ld_da_P_LKE('K');" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" hamRow="ns_ld_da_GR_lke_RowChange()" cotAn="so_id">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Tên dự án" DataField="ten_da">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ngày thành lập" DataField="ngay_tl" HeaderStyle-Width="150px">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="so_id" HeaderStyle-Width="10px" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_ld_da_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" class="bt_action" runat="server" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên dự án <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_DA" ten="Tên dự án" runat="server" kt_xoa="X" CssClass="form-control css_form" Width="300px" kieu_unicode="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày thành lập</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_tl" runat="server" ten="Ngày thành lập" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="N" cot="so_the,ho_ten,cdanh,phong,cdanh_da,ngayd,ngayc" hangKt="15">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Mã nhân viên" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="so_the" runat="server" Width="130px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                ktra="ns_cb,so_the,ten" kieu_chu="true" placeholder="Nhấn (F1)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Họ tên nhân viên" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ho_ten" Enabled="false" Width="130px" runat="server" kt_xoa="X" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chức danh" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cdanh" runat="server" Width="130px" CssClass="css_Gma_c" kt_xoa="X" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Đơn vị" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phong" runat="server" Enabled="false" Width="130px" CssClass="css_Gma" kieu_unicode="true" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chức danh trong dự án" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cdanh_da" runat="server" Width="130px" CssClass="css_Gma_r" kieu_unicode="true" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày bắt đầu" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayd" Width="80px" runat="server" CssClass="css_Gma_c" kieu_luu="S" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày kết thúc" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayc" Width="80px" runat="server" Enabled="true" CssClass="css_Gma_c" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_ld_da_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_ld_da_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_ld_da_CatDong();" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action lv2">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" anh="K" class="bt_action" Text="Làm mới" OnClick="return ns_ld_da_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" anh="K" class="bt_action" Text="Ghi" OnClick="return ns_ld_da_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" anh="K" class="bt_action" Text="Xóa" OnClick="return ns_ld_da_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,680" />
    </div>
</asp:Content>
