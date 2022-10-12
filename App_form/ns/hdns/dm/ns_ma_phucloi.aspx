<%@ Page Title="ns_ma_phucloi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ma_phucloi.aspx.cs" Inherits="f_ns_ma_phucloi" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục phúc lợi" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" cotAn="so_id,thamnien,tutuoi,dentuoi,ma_lvcdanh,ma_cdanh,ngay_c,is_tudong"
                                hangKt="15" hamRow="ns_ma_phucloi_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã phúc lợi" DataField="ma" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên phúc lợi" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Số tiền" DataField="sotien" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay_d" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="is_tudong" />
                                    <asp:BoundField DataField="so_id" />
                                    <asp:BoundField DataField="thamnien" />
                                    <asp:BoundField DataField="tutuoi" />
                                    <asp:BoundField DataField="dentuoi" />
                                    <asp:BoundField DataField="ma_lvcdanh" />
                                    <asp:BoundField DataField="ma_cdanh" />
                                    <asp:BoundField DataField="ngay_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_ma_phucloi_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" class="bt_action" runat="server" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã phúc lợi<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma" ten="Mã phúc lợi" runat="server" CssClass="form-control css_ma" kt_xoa="K"
                                    ToolTip="Mã phúc lợi" kieu_chu="true" ktra="ma,ten" MaxLength="20" onfocusout="ns_ma_phucloi_P_KTRA('MA')" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên phúc lợi<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" MaxLength="255" ten="Tên phúc lợi" runat="server" kt_xoa="X" CssClass="form-control css_ma"
                                    kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Số tiền<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="SOTIEN" kieu_so="true" ten="Số tiền" MaxLength="20" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    ToolTip="Số tiền" co_dau="K" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Thâm niên</span>
                            <div class="input-group">
                                <Cthuvien:so ID="thamnien" ten="Thâm niên" MaxLength="3" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    ToolTip="Thâm niên" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Tuổi con từ</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tutuoi" kieu_so="true" ten="Tuổi con từ" MaxLength="3" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    ToolTip="Tuổi con nhỏ từ" co_dau="K" onchange="ns_ma_phucloi_P_KTRA('tutuoi');" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tuổi con đến</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="dentuoi" kieu_so="true" ten="Đến tuổi" MaxLength="3" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    ToolTip="Đến tuổi" co_dau="K" onchange="ns_ma_phucloi_P_KTRA('dentuoi');" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Tuổi CBNV từ</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="cbtutuoi" kieu_so="true" ten="Tuổi CBNV từ" MaxLength="3" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    ToolTip="Tuổi con nhỏ từ" Width="145px" co_dau="K" onchange="ns_ma_phucloi_P_KTRA('cbtutuoi');" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tuổi CBNV đến</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="cbdentuoi" kieu_so="true" ten="Tuổi CBNV đến" MaxLength="3" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    ToolTip="Đến tuổi" Width="145px" co_dau="K" onchange="ns_ma_phucloi_P_KTRA('cbdentuoi');" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Cấp bậc</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ma_lvcdanh" ktra="DT_MA_LVCDANH" runat="server" CssClass="form-control css_list" kt_xoa="X"
                                    ten="Ngạch nghề nghiệp"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ma_cdanh" ktra="DT_MA_CDANH" runat="server" CssClass="form-control css_list" kt_xoa="X"
                                    ten="Bậc nghề nghiệp"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày hiệu lực<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_D" runat="server" ten="Ngày hiệu lực"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" onchange="ns_ma_phucloi_P_KTRA('NGAY_D');" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày hết hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_c" runat="server" ten="Ngày thành lập"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" onchange="ns_ma_phucloi_P_KTRA('ngay_c');" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label  b_left col_15">Tự động áp dụng</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="is_tudong" runat="server" lke="X," Width="30px" kt_xoa="X"
                                    ToolTip="X - Áp dụng phúc lợi tự động,  - Không áp dụng tự động" CssClass="form-control css_ma_c" Text="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label  b_left col_30">Loại hợp đồng</span>
                            <div class="input-group">
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Giới tính</span>
                            <div class="input-group">
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <div class="grid_table width_common">
                                <Cthuvien:GridX ID="GR_hd" runat="server" loai="N"
                                    AutoGenerateColumns="false" hangKt="15" cot="chon,ma,ten" PageSize="1" CssClass="table gridX">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="35px">
                                            <ItemTemplate>
                                                <Cthuvien:kieu ID="chon" runat="server" Width="100%" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ma" HeaderText="Mã loại HĐ" HeaderStyle-Width="80px" />
                                        <asp:BoundField HeaderText="Tên loại HĐ" DataField="ten" HeaderStyle-Width="230px" ItemStyle-CssClass="css_Gma" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <div class="grid_table width_common">
                                <Cthuvien:GridX ID="Gr_gt" runat="server" loai="N" AutoGenerateColumns="false" PageSize="1"
                                    hangKt="15" CssClass="table gridX" cot="chon,ma,ten" cotAn="ma">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="35px">
                                            <ItemTemplate>
                                                <Cthuvien:kieu ID="chon" runat="server" Width="100%" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ma" />
                                        <asp:BoundField DataField="ten" HeaderText="Giới tính" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_ma_phucloi_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_ma_phucloi_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN,SOTIEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_ma_phucloi_P_XOA();form_P_LOI();" />
                    </div>

                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1260,740" />
    </div>
</asp:Content>
