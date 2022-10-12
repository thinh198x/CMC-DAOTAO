<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dt_tgian_gday_hvien.aspx.cs" Inherits="f_ns_dt_tgian_gday_hvien"
    Title="ns_dt_tgian_gday_hvien" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Tổng hợp thời gian học tập của học viên" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="NAM_TK" kieu_so="true" ten="Năm" runat="server" onchange="ns_dt_tgian_gday_hvien_P_KTRA('NAM_TK')" CssClass="form-control css_ma" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Phòng/bộ phận</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="PHONG" ktra="DT_PHONG" runat="server" CssClass="form-control css_ma" kt_xoa="X" onchange="ns_dt_tgian_gday_hvien_P_KTRA('PHONG')" ten="Phòng/Bộ phận"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group lv2 iterm_form">
                            <Cthuvien:nhap ID="Nhap1" runat="server" Text="Tổng hợp" class="bt_action" anh="K" OnClick="return ns_dt_tgian_gday_hvien_P_LKE('K');form_P_LOI();" Width="90px" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="padding-top: 10px; overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="17" cotAn="so_id" cot="stt,ma_hv,ten_hv,ten_cdanh,ten_phong,sogio_tgia_iclas,sogio_tgia_ojt,sogio_tgia,sogio_dt_thucte_iclas,sogio_dt_thucte_ojt,sogio_dt_thucte,tyle,tong_cp,so_id">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="STT" DataField="stt" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Mã học viên" DataField="ma_hv" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tên học viên" DataField="ten_hv" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="ten_phong" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số giờ phải tham gia (Inclass)" DataField="sogio_tgia_iclas" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Số giờ phải tham gia (OJT)" DataField="sogio_tgia_ojt" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tổng số giờ phải tham gia" DataField="sogio_tgia" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Số giờ đào tạo thực tế (Inclass)" DataField="sogio_dt_thucte_iclas" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Số giờ đào tạo thực tế (OJT)" DataField="sogio_dt_thucte_ojt" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tổng số giờ đào tạo thực tế" DataField="sogio_dt_thucte" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tỷ lệ %" DataField="tyle" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tổng chi phí HV" DataField="tong_cp" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="Số id" DataField="so_id" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_tgian_gday_hvien_P_LKE('M')" />

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tkhai" runat="server" Width="100px"  class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_dt_tgian_gday_hvien_P_IN();form_P_LOI();" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1390,800" />
    <Cthuvien:an ID="so_id" runat="server" />
    <Cthuvien:an ID="phongan" runat="server" />
    <Cthuvien:an ID="naman" runat="server" />
</asp:Content>
