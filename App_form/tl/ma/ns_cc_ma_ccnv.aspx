<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_cc_ma_ccnv.aspx.cs" Inherits="f_ns_cc_ma_ccnv"
    Title="ns_cc_ma_ccnv" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="r_c_content b_right">
        <div class="title_dmuc width_common">
            <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập công chuẩn theo nhân viên" />
            <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
        </div>
        <div class="width_common auto_sc">
            <div class="b_left col_100 inner" id="UPa_ct">
                <div class="col_3_iterm width_common">
                    <div class="b_left form-group iterm_form" style="width: 10%">
                        <span class="standard_label b_left col_30">Năm</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="NAM" kt_xoa="" ten="Năm" ktra="DT_NAM" runat="server" onchange="ns_cc_ccnv_P_NAM()" CssClass="form-control css_list" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Kỳ lương</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="KYLUONG" kt_xoa="X" ten="Kỳ lương" ktra="DT_KY" runat="server" CssClass="form-control css_list"
                                onchange="ns_cc_ccnv_P_KTRA('KYLUONG')" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Phòng ban</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="PHONG" kt_xoa="X" ten="Phòng ban" ktra="DT_PHONG" runat="server" CssClass="form-control css_list"
                                onchange="ns_cc_ccnv_P_KTRA('PHONG')" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="gridX" Width="100%"
                                loai="N" hangKt="20" cot="ma_dvi,so_the,ho_ten,ten_cdanh,ten_phong,ngayd,ngayc,cong_chuan,so_qd"
                                cotAn="ma_dvi,so_qd">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="ma_dvi" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Mã nhân viên" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="SO_THE" runat="server" ReadOnly="true" CssClass="css_Gma" BackColor="#f6f7f7" kieu_chu="true"
                                                Width="150px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" kt_xoa="K" ten="Mã nhân viên" placeholder="Nhấn (F1)"
                                                onchange="ns_cc_ccnv_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten" ToolTip="Mã nhân viên" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ho_ten" HeaderStyle-Width="200px" HeaderText="Họ tên" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ten_cdanh" HeaderStyle-Width="200px" HeaderText="Chức danh" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ten_phong" HeaderStyle-Width="200px" HeaderText="Phòng ban" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ngayd" HeaderStyle-Width="80px" HeaderText="Từ ngày" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="ngayc" HeaderStyle-Width="80px" HeaderText="Đến ngày" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:TemplateField HeaderText="Công chuẩn" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="cong_chuan" runat="server" CssClass="css_Gso" Width="80px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="so_qd" HeaderStyle-Width="10px" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" rong="280" loai="N" gridId="GR_lke" />
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_cc_ma_ccnv_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_cc_ma_ccnv_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_cc_ma_ccnv_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return ns_cc_ma_ccnv_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Lưu" Width="80px" OnClick="return ns_cc_ma_ccnv_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="excel" runat="server" Text="File mẫu" Width="80px" OnServerClick="nhap_Click" />
                        <Cthuvien:nhap ID="Import" runat="server" Text="Import" Width="80px" OnClick="return ns_cc_ma_ccnv_P_Import();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1100,800" />
        <Cthuvien:an ID="ma_phong" runat="server" />
        <Cthuvien:an ID="ma" runat="server" />
        <Cthuvien:an ID="akyluong" runat="server" />
        <Cthuvien:an ID="aphong" runat="server" />
        <Cthuvien:an ID="ten" runat="server" />
        <Cthuvien:an ID="ngayd" runat="server" />
        <Cthuvien:an ID="ngayc" runat="server" />
    </div>
</asp:Content>
