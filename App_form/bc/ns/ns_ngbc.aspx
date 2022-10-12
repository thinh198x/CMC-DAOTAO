<%@ Page Title="ns_ngbc" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="ns_ngbc.aspx.cs" Inherits="f_ns_ngbc" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh sách báo cáo" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_15">Báo cáo</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="loai_sl" ten="Báo cáo" runat="server" kieu="S"
                                CssClass="form-control css_list" ktra="DT_LOAI_SL" onchange="ns_ngbc_P_KTRA('loai_sl')" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" Width="100%"
                                loai="X" hangKt="15" hamRow="ns_ngbc_GR_lke_RowChange()" cot="ten,ma_bc,rep,ddan,excel" cotAn="ma_bc,rep,ddan,excel">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Tên">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten" runat="server" ReadOnly="true" Width="100%" CssClass="css_Gma" kt_xoa="G" ToolTip="Tên báo cáo" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ma_bc" />
                                    <asp:BoundField DataField="rep" />
                                    <asp:BoundField DataField="ddan" />
                                    <asp:BoundField DataField="excel" />
                                </Columns>
                            </Cthuvien:GridX>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"  ham="ns_ngbc_P_KTRA('LOAI_SL')" />
                        </div>
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_tree" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                loai="L" hangKt="14" cotAn="ma" hamRow="ns_ngbc_GR_tree_RowChange()" Style="display: none" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Đơn vị" DataField="ten">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trdonvi" style="display: none">
                        <span class="standard_label b_left col_30">Đơn vị</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="don_vi" runat="server" kieu="U" CssClass="form-control css_list" ktra="DT_DON_VI"/>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trPhong">
                        <span class="standard_label b_left col_30">Phòng ban</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="phong" runat="server" kieu="U" CssClass="form-control css_list" ktra="DT_PHONG"
                                onchange="ns_ngbc_P_KTRA('PHONG')"/>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trNam">
                        <span class="standard_label b_left col_30">Năm</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="nam" ten="Năm" runat="server" ktra="DT_NAM" CssClass="form-control css_list" kt_xoa="X"
                                onchange="ns_ngbc_P_NAM_DT(),ns_ngbc_P_NAM();" kieu="S" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trThang_tk" style="display: none">
                        <span class="standard_label b_left col_30">Tháng</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="thangtk" runat="server" CssClass="form-control css_list" ktra="DT_THANG" kt_xoa="X"
                                ten="Tháng" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trNam1" style="display: none">
                        <span class="standard_label b_left col_30">Năm</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="nam1" ten="Năm" runat="server" ktra="DT_NAM1" CssClass="form-control css_list" kt_xoa="G" onchange="ns_ngbc_P_NAM();" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trdt" style="display: none">
                        <span class="standard_label b_left col_30">Khóa đào tạo</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="khoa_dt" ten="Khóa đào tạo" runat="server" ktra="DT_KHOA" kieu_chu="true" CssClass="form-control css_list"
                                kt_xoa="G" onchange="ns_ngbc_P_NAM();" kieu="S" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trKyluong">
                        <span class="standard_label b_left col_30">Kỳ lương</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="kyluong" ten="Kỳ lương" runat="server" ktra="DT_KYLUONG" kt_xoa="X"
                                CssClass="form-control css_list" kieu="S" onchange="ns_ngbc_P_KTRA('KYLUONG')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trKyluong_c">
                        <span class="standard_label b_left col_30">Kỳ lương đến</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="kyluong_c" ten="Kỳ lương" runat="server" ktra="DT_KYLUONG1" kt_xoa="X"
                                CssClass="form-control css_list" kieu="S" onchange="ns_ngbc_P_KTRA('KYLUONG')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trKyDG" style="display: none">
                        <span class="standard_label b_left col_30">Kỳ đánh giá</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="ky_dg" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG" kieu_chu="true" CssClass="form-control css_list"
                                kt_xoa="G" onchange="ns_ngbc_P_KY_DG()" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trNam_kpi" style="display: none">
                        <span class="standard_label b_left col_30">Năm</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="nam_kpi" ten="Năm đánh giá KPI" runat="server" ktra="DT_NAM_KPI" kt_xoa="X"
                                 onchange="ns_ngbc_P_NAM_KPI()" CssClass="form-control css_list" kieu="S" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trKyDG_KPI" style="display: none">
                        <span class="standard_label b_left col_30">Kỳ đánh giá KPI</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="ky_dg_kpi" ten="Kỳ đánh giá KPI" runat="server" ktra="DT_KY_DG_KPI" kt_xoa="X"
                                CssClass="form-control css_list" kieu="S" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trVitri" style="display: none">
                        <span class="standard_label b_left col_30">Vị trí</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="vitri" ten="Nhân viên" runat="server" ktra="DT_VITRI" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trNGHIVIEC_TUTHANG" style="display: none">
                        <span class="standard_label b_left col_30">Từ tháng</span>
                        <div class="input-group">
                            <Cthuvien:thang placeholder='MM/yyyy' ID="tuthang" runat="server" ten="Từ tháng" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trNGHIVIEC_DENTHANG" style="display: none">
                        <span class="standard_label b_left col_30">Đến tháng</span>
                        <div class="input-group">
                            <Cthuvien:thang placeholder='MM/yyyy' ID="denthang" runat="server" ten="Từ tháng" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trNGHIVIEC_NGAY" style="display: none">
                        <span class="standard_label b_left col_30">Ngày</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="Ngay" runat="server" ten="Ngày" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trDtuong" style="display: none">
                        <span class="standard_label b_left col_30">Đối tượng</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="dtuong" ten="Đối tượng" runat="server" ktra="DT_DTUONG" kieu_chu="true" CssClass="form-control css_list"
                                kt_xoa="G" onchange="ns_ngbc_P_DTUONG()" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trNGHIVIEC_TUNGAY" style="display: none">
                        <span class="standard_label b_left col_30">Từ ngày</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="tungay" runat="server" ten="Ngày" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trNGHIVIEC_DENNGAY" style="display: none">
                        <span class="standard_label b_left col_30">Đến ngày</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="denngay" runat="server" ten="Ngày" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trNhanVien" style="display: none">
                        <span class="standard_label b_left col_30">Nhân viên</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="hoten" ten="Nhân viên" runat="server" ktra="DT_HOTEN" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trCanBo" style="display: none">
                        <span class="standard_label b_left col_30">Nhân viên</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="canbo" ten="Nhân viên" runat="server" ktra="DT_CANBO" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" style="display: none">
                        <span class="standard_label b_left col_30">Mã cán bộ</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ma_cb" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kt_xoa="X"
                                f_tkhao="~/App_form/ht/ht_mansd.aspx" gchu="gchu" kieu_chu="True"
                                ktra="ht_ma_nsd,MA_LOGIN,TEN" Enabled="True" ten="Mã CÁN BỘ" placeholder="Nhấn F1" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" style="display: none">
                        <span class="standard_label b_left col_30">Chọn</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="ten_bc" runat="server" ktra="DT_TEN_BC" 
                                CssClass="form-control css_list" onchange="ns_ngbc_P_KTRA('ten_bc')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" style="display: none">
                        <span class="standard_label b_left col_30">Dự án</span>
                        <div class="input-group">
                            <Cthuvien:DR_nhap ID="duan" runat="server" CssClass="form-control css_list" ktra="DT_DUAN" kieu="S" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" id="trTHANG" style="display: none">
                        <span class="standard_label b_left col_30">Tháng</span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="thang" CssClass="form-control css_list" lke="Tháng 1,Tháng 2,Tháng 3,Tháng 4,Tháng 5,Tháng 6,Tháng 7,Tháng 8,Tháng 9,Tháng 10,Tháng 11,Tháng 12"
                                tra="1,2,3,4,5,6,7,8,9,10,11,12" runat="server" kt_xoa="X" ten="Tháng"></Cthuvien:DR_list>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" style="display: none">
                        <asp:RadioButtonList ID="chon_in" runat="server" Width="100%" RepeatDirection="Horizontal">
                            <asp:ListItem Value="X" Text="HTML" />
                            <asp:ListItem Value="I" Text="PDF" />
                            <asp:ListItem Selected="True" Value="E" Text="EXCEL" />
                            <asp:ListItem Value="W" Text="WORD" />
                        </asp:RadioButtonList>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="file" runat="server" Width="100px" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_ngbc_P_XEM();form_P_LOI();" />
                    </div>

                </div>
            </div>
        </div>
    </div>


    <div id="UPa_hi">
        <Cthuvien:an ID="ten_rp" runat="server" />
        <Cthuvien:an ID="ten_menu" runat="server" />
        <Cthuvien:an ID="naman" runat="server" />
        <Cthuvien:an ID="ddan" runat="server" Value="~/App_rpt/tt/" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="900,840" />
    </div>
</asp:Content>
