<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_ma_bacluong.aspx.cs" Inherits="f_ns_hdns_ma_bacluong"
    Title="ns_hdns_ma_bacluong" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục bậc lương" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" Width="100%" loai="X" hangKt="15" cotAn="so_id,ma_tl,ma_nl,ma_nnnghiep,ten_nnnghiep" hamRow="ns_hdns_ma_bacluong_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Bảng lương" DataField="ten_tl" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Ngạch lương" DataField="ten_nl" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Ngạch nghề nghiệp" DataField="ten_nnnghiep" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="so_id" />
                                    <asp:BoundField DataField="ma_tl" />
                                    <asp:BoundField DataField="ma_nl" />
                                    <asp:BoundField DataField="ma_nnnghiep" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke" ham="ns_hdns_ma_bacluong_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_hdns_ma_bacluong_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Bảng lương<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="MA_TL" ten="Thang lương" runat="server" CssClass="form-control css_list" ktra="DT_MA_TL" kt_xoa="G" f_tkhao="~/App_form/ns/hdns/tl/hd_ma_httluong.aspx" onchange="ns_hdns_ma_bacluong_P_KTRA('MA_TL')" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Ngạch lương<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="MA_NL" runat="server" ten="Ngạch lương" ToolTip="Ngạch lương" MaxLength="30" kt_xoa="G" ktra="DT_MA_NL" CssClass="form-control css_list" onchange="ns_hdns_ma_bacluong_P_KTRA('MA_NL')" />
                        </div>
                    </div>
                    <div class="grid_table width_common css_divb c_divC">
                        <div class="table gridX css_divCn">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" Width="100%" PageSize="1" CssClass="table gridX" loai="N"
                                cot="bacluong,tongluong,luong_cb,thuong_dg,trangthai,so_id_ct" cotAn="so_id_ct,thuong_dg,tongluong" hangKt="15" hamUp="ns_hdns_ma_bacluong_GR_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Bậc lương*" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="bacluong" runat="server" CssClass="css_Gma" kt_xoa="X" MaxLength="100" Width="100px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tổng lương* (VND)" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tongluong" Text="10" runat="server" MaxLength="15" Width="120px" CssClass="css_Gso" kt_xoa="X" so_tp="3" co_dau="K" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Lương cơ bản (VND)" HeaderStyle-Width="110px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="luong_cb" runat="server" MaxLength="15" Width="110px" CssClass="css_Gso" kt_xoa="X" so_tp="3" co_dau="K" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Thưởng đánh giá tháng (VND)">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="thuong_dg" Text="K" runat="server" CssClass="css_Gso" MaxLength="15" BackColor="#f6f7f7" kt_xoa="X" Enabled="false" so_tp="3" co_dau="K" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Trạng thái">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="trangthai" lke="Áp dụng,Ngừng áp dụng" tra="A,N" CssClass="css_Gma_c" runat="server" ten="Trạng thái" ToolTip="Trạng thái" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="so_id_ct" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divC:ctr_khud_divC ID="Ctr_khud_divc1" runat="server" gridId="GR_ct" />
                    </div>
                    <div class="btex_luoi b_right">
                        <ul>
                            <li>
                                <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_hdns_ma_bacluong_HangLen(1);" />
                            </li>
                            <li>
                                <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_hdns_ma_bacluong_HangXuong(1);" />
                            </li>
                            <li>
                                <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_hdns_ma_bacluong_CatDong(1);" />
                            </li>
                            <li>
                                <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_hdns_ma_bacluong_ChenDong('C');" />
                            </li>
                        </ul>
                    </div>
                    <div style="display: none">
                        <Cthuvien:DR_lke ID="ma_nnnghiep" runat="server" ten="Ngạch nghề nghiệp" ToolTip="Ngạch nghề nghiệp" kt_xoa="G" ktra="DT_MA_NNNGHE" Width="200px" CssClass="css_list" onchange="ns_hdns_ma_bacluong_P_KTRA('MA_NNNGHIEP')" />
                        <Cthuvien:nhap ID="excelmau" runat="server" Text="File mẫu" Width="100px" OnClick="return ns_hdns_ma_bacluong_P_MAU();form_P_LOI('');" Title="File mẫu" />

                        <Cthuvien:nhap ID="import" runat="server" Text="Import" Width="100px" OnClick="return ns_hdns_ma_bacluong_FILE_IMPORT();form_P_LOI();" />
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                        <Cthuvien:nhap ID="btn_excel_mau" runat="server" Text="Mẫu excel" Width="70px" OnServerClick="btn_excel_mau_Click" />
                    </div>
                    <div class="list_bt_action lv2">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_hdns_ma_bacluong_P_MOI();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_hdns_ma_bacluong_P_NH();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" class="bt_action" anh="K" OnClick="return form_P_TRA_CHON('');form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_hdns_ma_bacluong_P_XOA();form_P_LOI();" Width="100px" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="900,540" />
    </div>
</asp:Content>
