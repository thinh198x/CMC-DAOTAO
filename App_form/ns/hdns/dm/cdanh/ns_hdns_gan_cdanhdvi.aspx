<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_hdns_gan_cdanhdvi.aspx.cs" Inherits="f_ns_hdns_gan_cdanhdvi"
    Title="ns_hdns_gan_cdanhdvi" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Gán vị trí chức danh cho đơn vị" />
                <img class="b_right" src="../../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false"
                                CssClass="table gridX" Width="100%" loai="X" hangKt="20" cot="ma_ts,ten_phong,ngay_hl,so_id,phong,nsd"
                                cotAn="so_id,phong,nsd" hamRow="ns_hdns_gan_cdanhdvi_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã phòng ban" DataField="ma_ts" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên phòng ban" DataField="ten_phong" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày áp dụng" DataField="ngay_hl" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="so_id" />
                                    <asp:BoundField DataField="phong" />
                                    <asp:BoundField DataField="nsd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                            ham="ns_hdns_gan_cdanhdvi_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" hoi="3" Width="100px" class="bt_action" anh="K" OnClick="return ns_hdns_gan_cdanhdvi_P_EXCEL();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Phòng<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="PHONG" ten="Phòng" runat="server" CssClass="form-control css_list" ktra="DT_PH" onchange="ns_hdns_gan_cdanhdvi_P_MA_KTRA();" kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày áp dụng<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_HL" runat="server" CssClass="form-control icon_lich" ten="Ngày áp dụng" MaxLength="10" kt_xoa="G" kieu_chu="true" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common css_divb c_divC">
                        <div class="table gridX css_divCn">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" Width="100%" cot="MA_CD,ten,ten_tt,ma_cdanh_dvi,SO_ID_CD" cotAn="SO_ID_CD,ma_cdanh_dvi"
                                hangKt="20" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Mã chức danh" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="MA_CD" runat="server" ReadOnly="true" CssClass="css_Gma" kt_xoa="X"
                                                f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_cdanh_tk.aspx" Width="100%" placeholder="Nhấn (F1)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tên chức danh">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten" Enabled="false" runat="server" Width="100%" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Trạng thái" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten_tt" runat="server" Enabled="false" Width="100%" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mã chức danh theo đơn vị">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ma_cdanh_dvi" Enabled="false" runat="server" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SO_ID_CD" />
                                </Columns>
                            </Cthuvien:GridX>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_ct_slide" loai="N" runat="server" gridId="GR_ct" />

                        </div>
                        <div class="btex_luoi b_right" id="id_chensp">
                            <ul>
                                <li>
                                    <img alt="" src="/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_hdns_gan_cdanhdvi_HangLen();" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_hdns_gan_cdanhdvi_HangXuong();" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_hdns_gan_cdanhdvi_CatDong();" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/chen.png" title="Thêm 1 dòng mới" onclick="return ns_hdns_gan_cdanhdvi_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="ns_hdns_gan_cdanhdvi_P_MOI();form_P_LOI('');" Title="Ấn nút để làm mới" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_hdns_gan_cdanhdvi_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" class="bt_action" anh="K" OnClick="return form_P_TRA_CHON_GRID('GR_ct:phong,GR_ct:so_id_cd,GR_ct:ten');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_hdns_gan_cdanhdvi_P_XOA();form_P_LOI();" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="FileMau" runat="server" Text="File mẫu" Width="90px" OnServerClick="FileMau_Click" />
                        <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                        <Cthuvien:nhap ID="import" runat="server" Text="Nhập từ Excel" hoi="12" Width="100px" OnClick="return ns_hdns_gan_cdanhdvi_FILE_IMPORT();form_P_LOI();" />
                        <Cthuvien:nhap ID="mau" runat="server" Text="File mẫu" Width="100px" OnClick="return ns_hdns_gan_cdanhdvi_P_MAU();form_P_LOI();" />
                    </div>
                </div>

            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1150,550" />
    </div>
</asp:Content>
