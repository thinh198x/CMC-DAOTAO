<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tl_tlap_lamca.aspx.cs" Inherits="f_tl_tlap_lamca"
    Title="tl_tlap_lamca" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục ca làm việc" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="nsd,ma_cong" hamRow="tl_tlap_lamca_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã ca" DataField="ma" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên ca" DataField="ten" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Mã công" DataField="KIEU_CONG" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Thời gian bắt đầu" DataField="GIO_BD" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Thời gian kết thúc" DataField="GIO_KT" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="ma_cong" />
                                    <asp:BoundField DataField="nsd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                            ham="tl_tlap_lamca_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Width="100px" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Mã ca <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" ten="Mã ca" runat="server" CssClass="form-control css_ma"
                                    kt_xoa="G" onchange="tl_tlap_lamca_P_KTRA('MA')" MaxLength="20" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Tên ca <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Tên ca" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                    MaxLength="255"></Cthuvien:ma>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Thời gian bắt đầu ca <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="GIO_BD" ten="Thời gian bắt đầu ca" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    ToolTip="Nhập kiểu giờ định dạng 00:00" MaxLength="5" kieu_so="true" onchange="tl_tlap_lamca_P_KTRA('GIO_BD')" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Thời gian kết thúc <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="GIO_KT" ten="Thời gian kết thúc" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    ToolTip="Nhập kiểu giờ định dạng 00:00" MaxLength="5" kieu_so="true" onchange="tl_tlap_lamca_P_KTRA('GIO_KT')" />

                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Nghỉ giữa ca từ giờ </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="giora_giuaca" ten="Nghỉ giữa ca từ giờ" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    ToolTip="Nhập kiểu giờ định dạng 00:00" MaxLength="6" kieu_so="true" onchange="tl_tlap_lamca_P_KTRA('giora_giuaca')" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Nghỉ giữa ca đến giờ </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="giovao_giuaca" ten="Nghỉ giữa ca đến giờ" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    ToolTip="Nhập kiểu giờ định dạng 00:00" MaxLength="6" kieu_so="true" onchange="tl_tlap_lamca_P_KTRA('giovao_giuaca')" />

                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Được đi muộn (phút) </span>
                            <div class="input-group">
                                <Cthuvien:ma kieu_so="true" MaxLength="2" ID="duoc_dimuon" runat="server" CssClass="form-control css_ma" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Được về sớm (phút) </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="duoc_vesom" MaxLength="2" kieu_so="true" runat="server" CssClass="form-control css_ma" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Mã công <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="MA_CONG" ten="Mã công" ktra="DT_MA_CONG" CssClass="form-control css_list" kt_xoa="X" runat="server"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Thời gian ca <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="THOIGIAN" ten="Thời gian của ca" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    MaxLength="2" kieu_so="true" />
                            </div>
                            <div style="display: none;">
                                <Cthuvien:kieu ID="QUET_TRUA" runat="server" lke="C,K" Width="40px" ToolTip="C - Có quẹt trưa, K - Không quẹt trưa" CssClass="form-control css_ma" Text="C" />
                                <Cthuvien:kieu ID="hinhthuc" ten="Tên" runat="server" CssClass="form-control css_ma" Text="C"
                                    lke="C,K" ToolTip="C - Giờ bắt đầu và giờ kết thúc trong 1 ngày,K - Giờ bắt đầu và giờ kết thúc không trong 1 ngày" Width="40px" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Kiểu công T7/CN</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="nghi_7_cn" runat="server" lke="Nghỉ t7 + Chủ nhật,Nghỉ chiều t7 và Chủ nhật,Nghỉ chủ nhật"
                                    CssClass="form-control css_list" tra="1,2,3" ten="Kiểu công t7,CN" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Trạng thái <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="trangthai" runat="server" CssClass="form-control css_list" lke="Áp dụng,Ngừng áp dụng" tra="A,N" ten="Trạng thái" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_25">Mô tả </span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mota" runat="server" TextMode="MultiLine" kieu_unicode="True" CssClass="form-control css_nd" kt_xoa="X"
                                Width="100%" MaxLength="1000"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return tl_tlap_lamca_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" class="bt_action" anh="K" Text="Ghi" OnClick="return tl_tlap_lamca_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Width="80px" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN,nghi_7_cn');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" class="bt_action" anh="K" Text="Xóa" OnClick="return tl_tlap_lamca_P_XOA();form_P_LOI();" />

                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1340,540" />
</asp:Content>
