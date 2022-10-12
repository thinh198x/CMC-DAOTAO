
<%@ Page Title="hdns_mota_cv" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="hdns_mota_cv.aspx.cs" Inherits="f_hdns_mota_cv" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Mô tả công việc vị trí chức danh" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div style="overflow-x:scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="22" cot="so_id,nhom_cd,cdanh,ten_nhom_cd,ten_cdanh" cotAn="so_id,nhom_cd,cdanh" hamRow="hdns_mota_cv_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="SO_ID" DataField="so_id" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="NHOM_CD" DataField="nhom_cd" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="CDANH" DataField="cdanh" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Nhóm chức danh" DataField="ten_nhom_cd" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="220px" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                            <div id="GR_lke_td">
                                <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="hdns_mota_cv_P_LKE('K')" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="width_common pv_bl"><span>Thông tin về bản mô tả công việc</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã số công việc</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma" runat="server" CssClass="form-control css_ma" kt_xoa="L" ten="Mã số công việc" ToolTip="Mã số công việc" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày ban hành</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_bh" runat="server" CssClass="form-control icon_lich" kt_xoa="L" ten="Ngày ban hành" ToolTip="Ngày ban hành" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày sửa đổi</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_sd" runat="server" CssClass="form-control icon_lich" kt_xoa="L" ten="Ngày ban hành" ToolTip="Ngày ban hành" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Người soạn thảo</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_ma_nguoi_st" runat="server" kt_xoa="L" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Người soạn thảo" placeholder="Nhấn (F1)"
                                    onchange="hdns_mota_cv_P_KTRA('MA_NGUOI_ST')" ToolTip="Mã người soạn thảo" />
                                <div style="display: none;">
                                    <Cthuvien:ma ID="ma_nguoi_st" ktra="ns_cb,so_the,ten" runat="server" kt_xoa="L" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Người phê duyệt</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_ma_nguoi_pd" runat="server" kt_xoa="L" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Người phê duyệt" placeholder="Nhấn (F1)"
                                    onchange="hdns_mota_cv_P_KTRA('MA_NGUOI_PD')" ToolTip="Mã người phê duyệt" />
                                <div style="display: none;">
                                    <Cthuvien:ma ID="ma_nguoi_pd" ktra="ns_cb,so_the,ten" runat="server" kt_xoa="L" />
                                </div>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Thông tin chung về vị trí</span></div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Nhóm chức danh <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="NHOM_CD" ktra="DT_NHOM_CD" runat="server" CssClass="form-control css_list" onchange="hdns_mota_cv_P_KTRA('NHOM_CD')" kt_xoa="G" ten="Nhóm chức danh"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Tên vị trí CD <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="CDANH" ktra="DT_CDANH" runat="server" CssClass="form-control css_list" onchange="hdns_mota_cv_P_KTRA('CDANH')" kt_xoa="G" ten="Chức danh"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Mục đích công việc</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mucdich" ten="Mục đích công việc" runat="server" kt_xoa="X" Height="50px"
                                CssClass="form-control css_nd" kieu_unicode="true" TextMode="MultiLine" />
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Nhiệm vụ</span></div>
                    <div class="grid_table width_common">
                        <Cthuvien:GridX ID="GR_nv" runat="server" AutoGenerateColumns="false" PageSize="1" loai="N" Width="100%"
                            CssClass="table gridX" hangKt="4"
                            cot="SOTT,NV_CV,THAMQUYEN,muctieu_kq">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:TemplateField HeaderText="STT(*)" HeaderStyle-Width="70px">
                                    <ItemTemplate>
                                        <Cthuvien:so ID="SOTT" runat="server" CssClass="css_Gma_c" kt_xoa="X" Width="70px" so_tp="2" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nhiệm vụ công việc(*)" HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="NV_CV" runat="server" kieu_unicode="true" CssClass="css_Gma" kt_xoa="X" Width="150px" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Thẩm quyền(*)" HeaderStyle-Width="120px">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="THAMQUYEN" runat="server" kieu_unicode="true" CssClass="css_Gma" kt_xoa="X" Width="120px" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Kết quả" HeaderStyle-Width="210px">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="muctieu_kq" runat="server" kieu_unicode="true" Width="210px" CssClass="css_Gma" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </Cthuvien:GridX>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return hdns_mota_cv_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return hdns_mota_cv_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return hdns_mota_cv_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return hdns_mota_cv_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Quan hệ công việc</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Báo cáo cho</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_baocao" runat="server" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_ma_vtcdanh.aspx" CssClass="form-control css_ma" kt_xoa="X" ten="Báo cáo cho" ToolTip="Báo cáo cho" BackColor="#f6f7f7" placeholder="Nhấn (F1)" />
                                <div style="display: none">
                                    <Cthuvien:ma ID="baocao" runat="server" kt_xoa="X" />
                                </div>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Quan hệ bên trong</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_qh_bentrong" runat="server" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_ma_vtcdanh.aspx" CssClass="form-control css_ma" kt_xoa="X" ten="Quan hệ bên trong" ToolTip="Quan hệ bên trong" BackColor="#f6f7f7" placeholder="Nhấn (F1)" />
                                <div style="display: none">
                                    <Cthuvien:ma ID="qh_bentrong" runat="server" kt_xoa="X" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Quan hệ bên ngoài</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="qh_benngoai" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu_unicode="true" ten="Quan hệ ngoài" ToolTip="Quan hệ bên ngoài" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Kỹ năng</span></div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Kỹ năng</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="kynang" ten="Kỹ năng" runat="server" kt_xoa="X" Height="50px"
                                CssClass="form-control css_nd" kieu_unicode="true" TextMode="MultiLine" />
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Trình độ</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kinh nghiệm (năm)</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="kinhnghiem" runat="server" CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="X" ten="Kinh nghiệm" ToolTip="Kinh nghiệm" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chuyên ngành</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="chuyennganh" runat="server" CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="X" ten="Chuyên ngành" ToolTip="Chuyên ngành" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Bằng cấp/ Chứng chỉ</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="bangcap" runat="server" CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="X" ten="Bằng cấp/ Chứng chỉ" ToolTip="Bằng cấp/ Chứng chỉ" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Yêu cầu khác</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="yc_khac" ten="Yêu cầu khác" runat="server" kt_xoa="X" Height="50px"
                                CssClass="form-control css_nd" kieu_unicode="true" TextMode="MultiLine" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <button onclick="return hdns_mota_cv_P_NH();form_P_LOI();" class="bt_action"><span class="txUnderline">N</span>hập</button>
                        <button onclick="return hdns_mota_cv_P_MOI('XGL');form_P_LOI();" class="bt_action"><span class="txUnderline">M</span>ới</button>
                        <button class="bt_action" onclick="return hdns_mota_cv_P_XOA();form_P_LOI();"><span class="txUnderline">X</span>óa</button>
                        <button class="bt_action" onclick="return hdns_mota_cv_Export();form_P_LOI();">File mẫu</button>
                        <button class="bt_action" onclick="return hdns_mota_cv_Import();form_P_LOI();">Import</button>

                        <div style="display: none">
                            <Cthuvien:nhap ID="nhap" runat="server" Width="70px" Text="File mẫu" OnServerClick="nhap_Click" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1200,800" />
    </div>
</asp:Content>
