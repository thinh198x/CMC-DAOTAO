﻿<%@ Page Title="ns_tl_htro_antrua_phong" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tl_htro_antrua_phong.aspx.cs" Inherits="f_ns_tl_htro_antrua_phong" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập hỗ trợ ăn trưa theo phòng" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="L" hangKt="20" cot="ng_hluc,ng_het_hluc,sotien,so_id" cotAn="so_id,ng_het_hluc" hamRow="ns_tl_htro_antrua_phong_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ng_hluc"
                                        ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Ngày hết hiệu lực" DataField="ng_het_hluc"
                                        ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Số tiền" DataField="sotien" HeaderStyle-Width="100px"
                                        ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" HeaderStyle-Width="0px"
                                        ItemStyle-CssClass="css_Gnd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_tl_htro_antrua_phong_P_LKE('K')" />

                    </div>
                    <%--<div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="90px" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_tl_htro_antrua_phong_P_XUAT_EXEL();form_P_LOI();" />
                    </div>--%>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Số tiền <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="SOTIEN" runat="server" CssClass="form-control css_so" kieu_so="true" ten="Số tiền" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày hiệu lực <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay ID="NG_HLUC" placeholder='dd/MM/yyyy' runat="server" ten="Ngày hiệu lực" CssClass="form-control icon_lich" kt_xoa="X"
                                    kieu_luu="S" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_right form-group iterm_form" style="display: none">
                            <span class="standard_label lv2 b_left col_40">Ngày hết hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay ID="ng_het_hluc" placeholder='dd/MM/yyyy' runat="server" ten="Ngày hết hiệu lực" CssClass="form-control icon_lich" kt_xoa="X"
                                    kieu_luu="S" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_15">Ghi chú</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ghichu" ToolTip="Ghi chú" runat="server" Rows="2" kieu_unicode="true" CssClass="form-control css_nd" TextMode="MultiLine"
                                kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_15"></span>
                        <div class="input-group">
                            <Cthuvien:kieu ID="theo_nv" runat="server" Text="" lke="X," onchange="ns_cb_P_KTRA('NV')"
                                ToolTip="Thiết lập ca mặc định theo nhân viên" Width="30px" CssClass="form-control css_ma_c" />
                            <span class="standard_label b_left lv2 col_40">Theo nhân viên</span>
                            <Cthuvien:kieu ID="theo_dvi" runat="server" Text="" lke=",X" onchange="ns_cb_P_KTRA('DVI')" ToolTip="Thiết lập ca mặc định theo Phòng" Width="30px" CssClass="form-control css_ma_c" />
                            <span class="standard_label b_left lv2 col_40">Theo Phòng</span>
                        </div>
                        <div style="display: none;">
                            <Cthuvien:DR_lke ID="phong_tk" ten="Phòng" runat="server" ktra="DT_PHONG_TK"
                                CssClass="form-control css_list" kieu="S" Width="250px" onchange="ns_tl_htro_antrua_phong_P_KTRA('PHONG_TK')" f_tkhao="~/App_form/ht/ht_maph.aspx" />
                            <img runat="server" id="img" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return ns_cb_phong('phong_tk');" />
                        </div>
                    </div>
                    <div class="grid_table width_common" id="an_grNv">
                        <div style="height: 400px; overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="N" cot="tt,so_the,ten,phong,ten_phong" cotAn="tt,phong" hangKt="50" hamUp="ns_tl_htro_antrua_phong_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="TT" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tt" runat="server" Width="70px" CssClass="css_Gma_c" kieu_luu="I" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mã nhân viên(*)" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="SO_THE" placeholder="Nhấn (F1)" runat="server" Width="130px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                ktra="ns_cb,so_the,ten" kieu_chu="true" onchange="ns_cb_P_KTRA('SO_THE')" kt_xoa="G" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Tên nhân viên(*)" DataField="TEN"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng(*)" DataField="PHONG" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Phòng(*)" DataField="ten_phong" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>

                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img alt="" src="/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_tl_htro_antrua_phong_HangLen();" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_tl_htro_antrua_phong_HangXuong();" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_tl_htro_antrua_phong_CatDong();" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/chen.png" title="Thêm 1 dòng mới" onclick="return ns_tl_htro_antrua_phong_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>

                    <div class="grid_table width_common" id="an_grDvi">
                        <div style="height: 400px; overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_Dvi" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" hangKt="50" gchuId="gchu" cot="chon,stt,ma_phong,ten_phong,so_tien" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderStyle-Width="40px">
                                        <HeaderTemplate>
                                            <input id="chon_all" type="checkbox" onclick="CheckAll(this)" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Số TT" DataField="STT" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Mã ban/phòng" DataField="ma_phong" HeaderStyle-Width="150px" />
                                    <asp:TemplateField HeaderText="Ban/Phòng">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten_phong" runat="server" CssClass="css_Gnd" Width="100%" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số tiền" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="so_tien" runat="server" CssClass="css_Gma_r" Width="100%" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_Dvi_slide" runat="server" loai="N" gridId="GR_Dvi" />
                    </div>

                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" class="bt_action" anh="K" OnClick="return ns_tl_htro_antrua_phong_P_NH();form_P_LOI();"
                            Width="70px" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" OnClick="return ns_tl_htro_antrua_phong_P_MOI();form_P_LOI();"
                            Width="70px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_tl_htro_antrua_phong_P_XOA();form_P_LOI();"
                            Width="70px" />
                        <Cthuvien:nhap ID="chon" runat="server" class="bt_action" anh="K" Font-Bold="True" OnClick="return ns_tl_htro_antrua_phong_P_CHON();form_P_LOI();"
                            Text="Chọn" Width="70px" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="200px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                        </div>
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="ten_phong" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1023,700" />
    </div>
</asp:Content>
