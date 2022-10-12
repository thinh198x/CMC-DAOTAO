<%@ Page Title="ns_dt_tonghop_phieu_ks" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_tonghop_phieu_ks.aspx.cs" Inherits="f_ns_dt_tonghop_phieu_ks" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Tổng hợp phiếu khảo sát" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="gridX" loai="X" hangKt="20" cotAn="so_id" hamRow="ns_dt_tonghop_phieu_ks_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên" DataField="ten" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Từ ngày" DataField="tu_ngay" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đến ngày" DataField="den_ngay" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_tonghop_phieu_ks_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã đợt khảo sát</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" ten="Theo kế hoạch" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    onchange="ns_dt_tonghop_phieu_ks_P_KTRA('MA')" ktra="ns_dt_khoitao_ks,ma,ten" kt_xoa="G"
                                    f_tkhao="~/App_form/ns/dto/ns_dt_khoitao_ks.aspx" kieu_chu="true" gchu="gchu" placeholder="Nhấn F1" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="gridX" Width="100%" loai="X" cotAn="ma_nhucau" cot="ma_nhucau,TEN_NHUCAU,soluong" hangKt="10"
                                hamUp="ns_dt_tonghop_phieu_ks_sp_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="ma_nhucau" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Nhu cầu đào tạo">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="TEN_NHUCAU" Enabled="false" ReadOnly="true" kieu_chu="true" runat="server" Width="100%" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="soluong" HeaderText="Số lượng" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="width_common pv_bl lv2"><span>Danh sách tham gia</span></div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct_nv" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="gridX" Width="100%" loai="X" cot="so_the,ho_ten,phong,hinhthuc,thoi_diem_tg" hangKt="10" hamUp="ns_dt_danhgia_kq_sp_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Mã nhân viên" HeaderStyle-Width="90px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="so_the" Enabled="false" ReadOnly="true" kieu_chu="true" runat="server" Width="90px" CssClass="css_Gma"
                                                f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" />
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
                                    <asp:TemplateField HeaderText="Hình thức">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="hinhthuc" Enabled="false" ReadOnly="true" kieu_chu="true" runat="server" Width="100%"
                                                CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="thoi_diem_tg" HeaderText="Thời điểm tham gia" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_tonghop_phieu_ks_sp_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_tonghop_phieu_ks_sp_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_tonghop_phieu_ks_sp_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn thêm dòng" onclick="return ns_dt_tonghop_phieu_ks_sp_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_dt_tonghop_phieu_ks_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_dt_tonghop_phieu_ks_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_dt_tonghop_phieu_ks_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1200,730" />
    </div>
</asp:Content>
