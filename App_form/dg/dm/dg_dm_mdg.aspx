<%@ Page Title="dg_dm_mdg" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="dg_dm_mdg.aspx.cs" Inherits="f_dg_dm_mdg" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập mẫu đánh giá" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nam_tk" ten="Năm" runat="server" ktra="DT_NAM_TK" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="dg_dm_mdg_P_NAM_TK();" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ky_dg_tk" ktra="DT_KY_DG_TK" ten="Kỳ đánh giá" runat="server" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Đối tượng đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="doituong_dg_tk" ten="Đối tượng đánh giá" runat="server" ktra="DT_DG_TK" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="cdanh_tk" ten="Chức danh" ktra="DT_CDANH_TK" runat="server" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="timkiem" runat="server" anh="K" class="bt_action" Text="Tìm kiếm" hoi="0" OnClick="return dg_dm_mdg_P_LKE('K');" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="dg_dm_mdg_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kỳ ĐG" DataField="ten_ky_dg" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Nhóm chức danh" DataField="ten_nhom_cdanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Đối tượng ĐG" DataField="ten_doituong_dg" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày áp dụng" DataField="ngay_ad" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="dg_dm_mdg_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" class="bt_action" anh="K" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" ktra="DT_NAM" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="dg_dm_mdg_P_NAM();" kieu="S" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ đánh giá <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KY_DG" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đối tượng ĐG</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="doituong_dg" ten="Đối tượng ĐG" runat="server" ktra="DT_DG" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày áp dụng</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_ad" ten="Ngày áp dụng" runat="server" CssClass="form-control" kt_xoa="X" kieu_luu="S" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Nhóm chức danh</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nhom_cdanh" ten="Nhóm chức danh" runat="server" ktra="DT_NHOM_CDANH" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="dg_dm_mdg_P_NHOM_CDANH();" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="cdanh" ten="Chức danh" ktra="DT_CDANH" runat="server" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form" style="display: none;">
                            <Cthuvien:DR_lke ID="cdanh_ptson" ten="Chức danh" runat="server" ktra="DT_CDANH" kieu_chu="true" CssClass="css_list" Width="150px" kt_xoa="G" />
                        </div>
                    </div>
                    <%--<div class="width_common pv_bl"><span>Chức danh</span></div>
                    <div class="grid_table width_common">
                        <div class="table gridX">
                            <Cthuvien:GridX ID="Gr_cdanh" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX2" loai="N" cot="cdanh" hangKt="4" gchuId="gchu" Width="100%" hamUp="dg_cv_thang_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Chức danh">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="cdanh" ten="Chức danh" runat="server" ktra="DT_CDANH" kieu_chu="true" CssClass="css_Glist" kt_xoa="G" Width="100%" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                            <ctr_khud_divL:ctr_khud_divL ID="Gr_cdanh_slide" runat="server" loai="N" gridId="Gr_cdanh" />

                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return dg_dm_mdg_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return dg_dm_mdg_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>--%>
                    <div class="width_common pv_bl"><span>Thông tin mẫu đánh giá</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Nhóm câu hỏi</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nhom_cauhoi" ten="Nhóm nội dung" runat="server" ktra="DT_NHOM_CAUHOI" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cot="stt,ma_cauhoi,nd_cauhoi" hangKt="5" gchuId="gchu" Width="100%" hamUp="dg_cv_thang_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="STT" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="stt" runat="server" CssClass="css_Gma_c" Width="50px" kieu_so="true" gchu="Xếp loại bộ phận" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mã câu hỏi" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ma_cauhoi" runat="server" CssClass="css_Gma" Width="100px" gchu="Mã câu hỏi" onfocusout="dg_dm_mdg_P_KTRA('MA_CAUHOI')" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nội dung câu hỏi">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="nd_cauhoi" runat="server" CssClass="css_Gma" Width="400px" gchu="Nội dung câu hỏi" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return dg_dm_mdg_cauhoi_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return dg_dm_mdg_cauhoi_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return dg_dm_mdg_cauhoi_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return dg_dm_mdg_cauhoi_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left lv2 col_20">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mo_ta" ten="Mô tả" TextMode="MultiLine" runat="server" CssClass="form-control css_nd" kieu_unicode="True"
                                kt_xoa="X" Height="50px" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="dg_dm_mdg_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="100px" class="bt_action" anh="K" Text="Ghi" OnClick="dg_dm_mdg_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="100px" class="bt_action" anh="K" Text="Xóa" OnClick="return dg_dm_mdg_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="import" runat="server" Width="100px" class="bt_action" anh="K" Text="File mẫu" OnClick="return dg_dm_mdg_P_MAU();form_P_LOI();" />
                        <Cthuvien:nhap ID="Nhap4" runat="server" Width="100px" class="bt_action" anh="K" Text="Import" OnClick="return dg_dm_mdg_FILE_Import();form_P_LOI();" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="btn_excel_mau" runat="server" Text="Mẫu excel" Width="70px" OnServerClick="btn_excel_mau_Click" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="so_id" runat="server" value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1450,850" />
</asp:Content>
