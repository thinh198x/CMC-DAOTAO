<%@ Page Language="C#" AutoEventWireup="true" CodeFile="namdvbai4.aspx.cs" Inherits="nam_bai4"
    Title="nam_bai4" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="NAM bai 4" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_65">
                            <div class="width_common auto_sc line_65">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" Width="100%" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" hangKt="15" hamRow="GR_lke_RowChange()"
                                loai="X" >
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="ma" HeaderText="Đơn vị" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="ngay_tl" HeaderText="Ngày thành lập" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ngay_ad" HeaderText="Ngày thành áp dụng" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />                                    
                                    <asp:BoundField DataField="ten_cd" HeaderText="Tên chức danh" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                            ham="P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="xuatExel" runat="server" Text="Xuất Excel" class="bt_action" anh="K" OnClick="P_IN();form_P_LOI('');" Title="Ấn nút để xuất thông tin ra Excel" />
                    </div>
                </div>
                <div class="b_left col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_40">Đơn vị<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="đơn vị" runat="server" CssClass="form-control css_ma" kieu_chu="True"
                                kt_xoa="G" BackColor="#f6f7f7" />
                        </div>
                    </div>
                    </div>
                       <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Chức danh<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA_CD" f_tkhao="~/App_form/daotao-2022/NamDV/Bai2_1/namdv_bai2.aspx" runat="server" CssClass="form-control css_ma" kieu_chu="True" kt_xoa="G" ten="Nhóm chức danh" BackColor="#f6f7f7"
                                placeholder="Nhấn (F1)" Width="200px" />
                            <Cthuvien:ma ID="TEN_CD" runat="server" CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày thành lập<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_TL" runat="server" kieu_luu="S" CssClass="form-control css_ma_c icon_lich"
                                    kt_xoa="X" ten="Từ ngày" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày áp dụng</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_AD" runat="server" kieu_luu="S" CssClass="form-control css_ma_c icon_lich"
                                    kt_xoa="X" ten="Đến ngày" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Mô tả<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:nd ID="gchu" runat="server" CssClass="form-control css_ma" TextMode="MultiLine" kt_xoa="X" Height="50px"
                                MaxLength="2000"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="P_MOI();form_P_LOI('');" Title="Ấn nút để làm mới" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="P_NH();form_P_LOI('');" Title="Ấn nút nhập để nhập mới" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return P_XOA();form_P_LOI();" Title="Xóa dòng thông tin đang chọn" />
                    </div>
                    <div style="display: none;">
                        <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" Text="Xuất excel" OnServerClick="nhap_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>   
    <Cthuvien:an ID="kthuoc" runat="server" Value="900,550" />
</asp:Content>
