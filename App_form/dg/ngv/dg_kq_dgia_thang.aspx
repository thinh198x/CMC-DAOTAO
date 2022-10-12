<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dg_kq_dgia_thang.aspx.cs" Inherits="f_dg_kq_dgia_thang"
    Title="dg_kq_dgia_thang" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="r_c_content b_right">
        <div class="title_dmuc width_common">
            <Cthuvien:luu ID="tenForm" runat="server" Text="Kết quả đánh giá hàng tháng sử dụng tính lương" />
            <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
        </div>
        <div class="width_common auto_sc">
            <div class="b_left col_100 inner" id="UPa_ct">
                <div class="col_4_iterm width_common">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_15">Năm</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="NAM" kt_xoa="" ten="Năm" ktra="DT_NAM" runat="server" onchange="dg_kq_dgia_thang_P_KTRA('NAM')" CssClass="form-control css_list" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Kỳ đánh giá</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="KY_DG" kt_xoa="X" ten="Kỳ đánh giá" ktra="DT_KY_DG" runat="server" CssClass="form-control css_list"
                                onchange="dg_kq_dgia_thang_P_KTRA('KY_DG')" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Phòng ban</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="phongban" ktra="NS_DS_DEN_DVI" runat="server" kt_xoa="X" CssClass="form-control css_list"
                                onchange="dg_kq_dgia_thang_P_KTRA('PHONG')"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_right form-group lv2 iterm_form">
                        <Cthuvien:nhap ID="Nhap1" runat="server" class="bt_action" Text="Tổng hợp" OnClick="return dg_kq_dgia_thang_P_TONGHOP();" />
                        <Cthuvien:nhap ID="tim" runat="server" class="bt_action" Text="Tìm kiếm" OnClick="return dg_kq_dgia_thang_P_LKE('TK');" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="N" hangKt="15" cot="chon,so_the,ho_ten,cdanh,phong,ten_cdanh,ten_phong,xep_loai,heso,xacnhan,dl_cttns"
                                cotAn="cdanh,phong">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="chon" runat="server" Width="100%" CssClass="css_Gma_c" lke="X," ToolTip="Chọn" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mã nhân viên" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="so_the" runat="server" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                Width="70px" ReadOnly="true" placeholder="Nhấn (F1)" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Họ và tên" DataField="ho_ten" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="cdanh" />
                                    <asp:BoundField DataField="phong" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="ten_phong" ItemStyle-CssClass="css_Gma" />
                                    <asp:TemplateField HeaderText="Xếp loại đánh giá">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="xep_loai" runat="server" CssClass="css_Gma_c" Width="100%" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Hệ số đánh giá">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="heso" runat="server" CssClass="css_Gma_r" Width="100%" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Xác nhận" DataField="xacnhan" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Dữ liệu trên CTTNS" DataField="dl_cttns" ItemStyle-CssClass="css_Gma_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="N" gridId="GR_lke" />
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return dg_kq_dgia_thang_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return dg_kq_dgia_thang_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return dg_kq_dgia_thang_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return dg_kq_dgia_thang_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Text="Ghi" onclick="dg_kq_dgia_thang_P_NH('N');return false;" />
                        <Cthuvien:nhap ID="xacnh" runat="server" class="bt_action" anh="K" Text="Xác nhận" onclick="dg_kq_dgia_thang_P_XACNHAN('XN');return false;" />
                        <Cthuvien:nhap ID="excel_ds_cdg" runat="server" class="bt_action" anh="K" Text="DS nhân viên chưa đánh giá" onclick="dg_kq_dgia_DS_CHUA_DG()" />
                        <Cthuvien:nhap ID="layexcel" runat="server" class="bt_action" anh="K" Text="File mẫu" onclick="dg_kq_dgia_LAY_FILE_MAU()" />
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Nhập excel" onclick="dg_kq_dgia_thang_P_Excel();return false;" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="ds_cdg" runat="server" Width="100px" Text="Xuất excel" OnServerClick="excel_ds_Click" />
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="excel_mau_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,780" />
        <Cthuvien:an ID="an_kydg" runat="server" />
        <Cthuvien:an ID="an_phong" runat="server" />
    </div>
</asp:Content>
