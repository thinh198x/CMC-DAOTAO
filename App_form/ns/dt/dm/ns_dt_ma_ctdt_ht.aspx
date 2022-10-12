<%@ Page Title="ns_dt_ma_ctdt_ht" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_ma_ctdt_ht.aspx.cs" Inherits="f_ns_dt_ma_ctdt_ht" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục chỉ tiêu đào tạo và học tập" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_20 inner">
                    <div class="grid_table width_common">
                        <div class="css_divb">
                            <div>
                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                    CssClass="table gridX" loai="X" cotAn="so_id,tl_dt,tl_gd" hangKt="21" hamRow="ns_dt_ma_ctdt_ht_GR_lke_RowChange()">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay_hl" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField DataField="so_id" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_ma_nnd_P_LKE()" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_dt_ma_ctdt_ht_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_80 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="NAM" ten="Năm" runat="server" kieu_so="true" CssClass="form-control css_ma" kt_xoa="G" MaxLength="20" />
                                <Cthuvien:an ID="hincd" runat="server" Value="" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày hiệu lực <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder="dd/MM/yyyy" ID="NGAY_HL" ten="Ngày hiệu lực" ToolTip="Ngày hiệu lực" runat="server" CssClass="form-control icon_lich" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                           
                        </div>
                    </div>
                    <div class="grid_table mgt10 width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="N" cotAn="so_id,ncdanh,cdanh" cot="TEN_NCDANH,TEN_CDANH,tl_tg_tt,tl_tg_tt_ojt,tl_gd_tt,tl_gd_tt_ojt,so_id,ncdanh,cdanh" hangKt="15">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Nhóm chức danh" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="TEN_NCDANH" runat="server" ReadOnly="true" placeholder="Nhấn (F1)" CssClass="css_Gma" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_ma_nnn.aspx"
                                                ktra="ns_hdns_ma_nnn,ma,ten" kt_xoa="G"  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chức danh" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="TEN_CDANH" placeholder="Nhấn (F1)" ReadOnly="true" runat="server" CssClass="css_GndV" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_ma_vtcdanh.aspx"
                                                ktra="ns_hdns_ma_vtcdanh,ma,ten" kt_xoa="G"  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TL tham dự ĐT tối thiểu (Inclass)" HeaderStyle-Width="110px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tl_tg_tt" ten="TL tham dự ĐT tối thiểu (Inclass)" runat="server" kieu_so="true" CssClass="css_Gso" Width="120px" kt_xoa="G" MaxLength="20" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TL tham dự ĐT tối thiểu (OJT)" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tl_tg_tt_ojt" ten="TL tham dự ĐT tối thiểu (OJT)" runat="server" kieu_so="true" CssClass="css_Gso" Width="100px" kt_xoa="G" MaxLength="20" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TL giảng dạy tối thiểu(Inclass)" HeaderStyle-Width="110px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tl_gd_tt" ten="TL giảng dạy tối thiểu(Inclass)" runat="server" kieu_so="true" CssClass="css_Gso" Width="120px" kt_xoa="G" MaxLength="20" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TL giảng dạy tối thiểu(OJT)" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tl_gd_tt_ojt" ten="TL giảng dạy tối thiểu(OJT)" runat="server" kieu_so="true" CssClass="css_Gso" Width="100px" kt_xoa="G" MaxLength="20" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="so_id" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="ncdanh" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="cdanh" HeaderStyle-Width="10px" />
                                </Columns>
                            </Cthuvien:GridX>

                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_ma_ctdt_ht_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_ma_ctdt_ht_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_ma_ctdt_ht_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return ns_dt_ma_ctdt_ht_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_dt_ma_ctdt_ht_P_MOI();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_dt_ma_ctdt_ht_P_NH();form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" class="bt_action" anh="K" OnClick="form_P_TRA_CHON('MA,TEN');form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" onclick="return ns_dt_ma_ctdt_ht_P_XOA();form_P_LOI();" Width="70px" />
                        <div style="display: none">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                        </div>
                    </div>
                    <div id="UPa_gchu" class="css_border" align="left">
                        <Cthuvien:gchu ID="ghichu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1390,850" />
</asp:Content>
