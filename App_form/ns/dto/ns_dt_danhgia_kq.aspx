<%@ Page Title="ns_dt_danhgia_kq" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_danhgia_kq.aspx.cs" Inherits="f_ns_dt_danhgia_kq" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Đánh giá - Kết quả đào tạo" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="gridX" loai="X" hangKt="20" cotAn="ma_dt,so_id,danhgia" hamRow="ns_dt_danhgia_kq_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="danhgia" DataField="ma_dt" />
                                    <asp:BoundField HeaderText="Khóa học" DataField="ten" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Ngày đánh giá" DataField="ngay_dg" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                    <asp:BoundField HeaderText="danhgia" DataField="danhgia" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_danhgia_kq_P_LKE('K')" />
                    </div>

                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Khóa học <span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA_DT" ten="Mã Khóa học" kt_xoa="K" ToolTip="Mã Khóa học" runat="server" CssClass="form-control css_ma"
                                    kieu_chu="true" BackColor="#f6f7f7" ktra="ns_dt_kdt,ma,ten" f_tkhao="~/App_form/ns/dto/ns_dt_kdt.aspx"
                                    onchange="ns_dt_danhgia_kq_P_KTRA('MA_DT')" placeholder="Nhấn F1" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày đánh giá<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_DG" runat="server"
                                    ten="Ngày thành lập" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl lv2"><span>Đánh giá</span></div>
                    <div class="grid_table width_common">
                        <Cthuvien:GridX ID="GR_dg" runat="server" AutoGenerateColumns="false" PageSize="1"
                            CssClass="gridX" Width="100%" loai="N" cot="noidung,diem_dg" hangKt="10">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:BoundField DataField="noidung" HeaderText="Nội dung" />
                                <asp:TemplateField HeaderText="Đánh giá">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="diem_dg" runat="server" kieu_unicode="True" Width="100%" CssClass="css_Gma" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </Cthuvien:GridX>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="gridX" Width="100%" loai="N" cot="so_the,ho_ten,phong,ketqua" hangKt="10">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Mã nhân viên">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="so_the" kieu_chu="true" Enabled="false" runat="server" Width="100%" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Họ tên">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ho_ten" Enabled="false" ReadOnly="true" kieu_chu="true" runat="server" Width="100%" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phòng">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phong" Enabled="false" ReadOnly="true" kieu_chu="true" runat="server" Width="100%" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Kết quả">
                                        <ItemTemplate>
                                            <Cthuvien:DR_nhap ID="ketqua" runat="server" Width="100%" Height="22px" CssClass="css_Gma">
                                                <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Đạt" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Chưa đạt" Value="2"></asp:ListItem>
                                            </Cthuvien:DR_nhap>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_danhgia_kq_sp_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_danhgia_kq_sp_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_danhgia_kq_sp_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn thêm dòng" onclick="return ns_dt_danhgia_kq_sp_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_dt_danhgia_kq_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_dt_danhgia_kq_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_dt_danhgia_kq_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="960,680" />
        <Cthuvien:an ID="HSO_THE" runat="server" Value="0" />
    </div>
</asp:Content>
