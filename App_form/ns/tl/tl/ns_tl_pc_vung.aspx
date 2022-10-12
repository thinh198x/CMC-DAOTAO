﻿<%@ Page Title="ns_tl_pc_vung" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tl_pc_vung.aspx.cs" Inherits="f_ns_tl_pc_vung" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập phụ cấp theo vùng miền" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_64">
                <div class="b_left col_60 inner" id="UPa_tk">

                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,vung,ngay_hl" hamRow="ns_tl_pc_vung_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Phụ cấp" DataField="ten_pcap" HeaderStyle-Width="150px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Vùng" DataField="ten_vung" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Số tiền" DataField="sotien" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gma_r" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Loại hưởng" DataField="loaihuong" HeaderStyle-Width="150px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ten_ngay_hl" HeaderStyle-Width="150px">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ngày hết hiệu lực" DataField="ngay_het_hl" HeaderStyle-Width="150px">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="so_id" />
                                    <asp:BoundField DataField="vung" />
                                    <asp:BoundField DataField="ngay_hl" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_tl_pc_vung_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                    </div>
                </div>
                <div class="b_right col_40 inner" id="UPa_ct">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Phụ cấp <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="PCAP" ktra="DT_PCAP" kt_xoa="X" ten="Phụ cấp" runat="server" CssClass="form-control css_list"
                                ToolTip="Phụ cấp" f_tkhao="~/App_form/ns/hdns/dm/ns_hdns_ma_htkhac.aspx" onchange="ns_tl_pc_vung_P_KTRA('PCAP')"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Vùng <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="VUNG" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Vùng"
                                lke=",Vùng 1,Vùng 2,Vùng 3,Vùng 4" tra=",1,2,3,4" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Số tiền <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:so ID="SOTIEN" kieu_so="true" runat="server" MaxLength="20" ten="Số tiền" kt_xoa="X" CssClass="form-control css_so" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Loại hưởng <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="LOAIHUONG" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Vùng"
                                lke=",Theo công thực tế,Theo tháng" tra=",HTH2,HTH1" onchange="ns_tl_pc_vung_P_KTRA('LOAIHUONG')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Ngày hiệu lực <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_HL" runat="server" ten="Ngày hiệu lực" CssClass="form-control icon_lich" kieu_luu="S"
                                kt_xoa="X" ToolTip="Ngày hiệu lực" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Ngày hết hiệu lực</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_het_hl" runat="server" ten="Ngày hết hiệu lực" CssClass="form-control icon_lich" kieu_luu="S"
                                kt_xoa="X" ToolTip="Ngày hết hiệu lực" />
                        </div>
                    </div>

                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mota" TextMode="MultiLine" Height="50px" runat="server" CssClass="form-control css_nd" kt_xoa="X" MaxLength="2000" kieu_unicode="true" ten="Mô tả" ToolTip="Mô tả"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" class="bt_action" anh="K" OnClick="return ns_tl_pc_vung_P_NH();form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" OnClick="return ns_tl_pc_vung_P_MOI();form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_tl_pc_vung_P_XOA();form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="chon" runat="server" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('PCAP,VUNG,SOTIEN,LOAIHUONG,NGAY_HL,HOTRO');form_P_LOI();" Width="70px" />

                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="890,490" />
</asp:Content>
