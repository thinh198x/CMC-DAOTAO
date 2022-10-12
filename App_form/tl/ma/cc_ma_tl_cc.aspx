<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cc_ma_tl_cc.aspx.cs" Inherits="f_cc_ma_tl_cc"
    Title="cc_ma_tl_cc" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục ký hiệu chấm công" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_60 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" cotAn="huongluong,hluong" hangKt="15" hamRow="cc_ma_tl_cc_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã công" DataField="ma" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên công" DataField="ten">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Hình thức" DataField="loaicong" HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Hưởng lương" DataField="huongluong" HeaderStyle-Width="120px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Hưởng lương" DataField="hluong" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="cc_ma_tl_cc_P_LKE('K')" />

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Width="100px" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_40 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã công <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="Mã công" runat="server" CssClass="form-control css_ma" kieu_chu="true"
                                kt_xoa="G" MaxLength="20" onchange="cc_ma_tl_cc_P_KTRA('MA')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Tên công <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" MaxLength="255"
                                ten="Tên" />
                        </div>
                        <div style="display: none;">
                            <Cthuvien:so ID="tyle" ten="Tỷ lệ" runat="server" CssClass="form-control css_ma" kt_xoa="X" Width="80px" />
                            <Cthuvien:kieu ID="ngoai" runat="server" CssClass="form-control css_ma_c" Width="30px" Text="K"
                                lke="C,K" ToolTip="C-Có,K-Không" kt_xoa="true" />
                            <Cthuvien:DR_list ID="hinhthuc" runat="server" k_xoa="X" lke="Chấm theo công nhật,Chấm theo công giờ,Chấm theo công nhật hưởng thêm tiền,Chấm theo tiền/công (giờ),Chấm theo công nhật và hưởng 1 vài loại phụ cấp"
                                tra="C,G,1P,KG,CP" ten="Hưởng lương" />
                            <Cthuvien:DR_list ID="HLUONG" runat="server" k_xoa="X" lke="Hưởng nguyên lương,Không nhận lương từ công ty,Nghỉ không lương" tra="NL,LCT,KL" ten="Hưởng lương" />

                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Hình thức <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="LOAI" runat="server" CssClass="form-control css_list" lke="Làm việc,Nghỉ" tra="LV,N" ten="Loại công" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Trạng thái <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="TRANGTHAI" runat="server" CssClass="form-control css_list" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Ghi chú </span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mota" ten="Ghi chú" TextMode="MultiLine" runat="server" CssClass="form-control css_nd"
                                kieu_unicode="True" kt_xoa="X" MaxLength="2000" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" style="display: none;">
                        <Cthuvien:so ID="tien" runat="server" ten="Tiền công" kt_xoa="X" CssClass="form-control css_ma" Width="80px" />
                        <Cthuvien:so ID="conggio" runat="server" ten="công (giờ)" kt_xoa="X" CssClass="form-control css_ma" Width="30px" Text="1" />

                        <Cthuvien:so ID="tien2" runat="server" ten="Tiền công" kt_xoa="X" CssClass="form-control css_ma" Width="80px" />
                        <Cthuvien:so ID="conggio2" runat="server" ten="công (giờ)" kt_xoa="X" CssClass="form-control css_ma" Width="30px" Text="1" />
                        <Cthuvien:so ID="anca" runat="server" CssClass="form-control css_ma" Width="125px" kt_xoa="X" so_tp="2" />
                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                            CssClass="table gridX" loai="N" cot="mapc,tenpc,hso" hangKt="8" gchuId="gchu" ctrT="so_tt" ctrS="nhap" hamUp="cc_ma_tl_cc_GR_lke_Update">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:TemplateField HeaderText="Mã Phụ cấp" HeaderStyle-Width="90px">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="mapc" runat="server" Width="90px" CssClass="css_Gma_c" kieu_chu="true" MaxLength="30"
                                            f_tkhao="~/App_form/tl/ma/tl_tlap_pcap.aspx" ktra="ns_tl_tlap_pcap,ma,ten,gtri" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Tên phụ cấp" DataField="tenpc" HeaderStyle-Width="160px" />
                                <asp:TemplateField HeaderText="Hệ số" HeaderStyle-Width="165px">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="hso" runat="server" Width="165px" CssClass="css_Gso" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </Cthuvien:GridX>
                        <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return cc_ma_tl_cc_HangLen();" />
                        <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return cc_ma_tl_cc_HangXuong();" />
                        <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return cc_ma_tl_cc_CatDong();" />
                        <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return cc_ma_tl_cc_ChenDong('C');" />

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Width="70px" Text="Nhập" OnClick="return cc_ma_tl_cc_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Width="70px" Text="Mới" OnClick="return cc_ma_tl_cc_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Width="70px" Text="Xóa" OnClick="return cc_ma_tl_cc_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" class="bt_action" anh="K" Width="70px" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="960,510" />
    </div>
</asp:Content>
