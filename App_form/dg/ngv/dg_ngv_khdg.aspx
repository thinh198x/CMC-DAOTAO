<%@ Page Title="dg_ngv_khdg" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="dg_ngv_khdg.aspx.cs" Inherits="f_dg_ngv_khdg" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Khách hàng đánh giá" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nam_tk" ten="Năm" runat="server" ktra="DT_NAM_TK" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="dg_ngv_khdg_P_NAM_TK();" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label b_left lv2 col_40">Kỳ đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ky_dg_tk" ktra="DT_KY_DG_TK" ten="Kỳ đánh giá" runat="server" kieu_chu="true" 
                                    CssClass="form-control css_list" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="hoten_tk" ten="họ tên" runat="server" CssClass="form-control css_ma" kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30"></span>
                            <div class="input-group">
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" Width="120px" class="bt_action" anh="K" OnClick="return dg_ngv_khdg_P_LKE('M');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="trangthai,so_id" hamRow="dg_ngv_khdg_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kỳ ĐG" DataField="ten_ky_dg" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten_canbo" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="dg_ngv_khdg_P_LKE('K')" />

                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" ktra="DT_NAM" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="dg_ngv_khdg_P_NAM();" kieu="S" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ đánh giá <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KY_DG" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG" kieu_chu="true" 
                                    CssClass="form-control css_list" kt_xoa="G" onchange="dg_ngv_khdg_P_laynam();" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Từ ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_d" ten="Ngày áp dụng" runat="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_luu="S" BackColor="#f6f7f7" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_c" ten="Ngày áp dụng" runat="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_luu="S" BackColor="#f6f7f7" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã nhân viên<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" runat="server" CssClass="form-control css_ma" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" kt_xoa="K" ten="Mã nhân viên" placeholder="Nhấn (F1)"
                                    onchange="dg_ngv_khdg_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten" ToolTip="Mã nhân viên" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="HO_TEN" ten="Tên nhân viên" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Tên nhân viên" kt_xoa="X" kieu_unicode="true" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                       <%-- <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="CDANH" ten="Chức danh" runat="server" ktra="DT_CDANH" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="dg_ngv_khdg_P_CDANH();" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Họ tên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="HOTEN" ten="Họ tên" runat="server" ktra="DT_HOTEN" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="dg_ngv_khdg_P_HOTEN();" />
                            </div>
                        </div>--%>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" ten="Chức danh" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Tên nhân viên" kt_xoa="X" kieu_unicode="true" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form" style="display:none;">
                            <span class="standard_label lv2 b_left col_40">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="cdanh" ten="Chức danh" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma"
                                    ToolTip="Tên nhân viên" kt_xoa="X" kieu_unicode="true" Enabled="false" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã KH đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_kh" runat="server" CssClass="form-control css_ma" kieu_chu="true" kt_xoa="X"
                                    ten="Tên KH đánh giá"/>
                                <%--onchange="dg_ngv_khdg_P_MA_KH();"--%>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên KH đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_kh" runat="server" CssClass="form-control css_ma" kt_xoa="X" ten="Tên KH đánh giá" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label lv2 b_left col_20">Thông tin khác KH</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ttin_kh" ten="Thông tin khác KH" TextMode="MultiLine" runat="server" CssClass="form-control css_nd" kieu_unicode="True"
                                kt_xoa="X" Height="50px" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cot="stt,nhom_cauhoi,ma_cauhoi,nd_cauhoi,diem5,diem4,diem3,diem2,diem1,cauhoi_id" cotAn="cauhoi_id" hangKt="10" gchuId="gchu" Width="650px" hamUp="tinhtong">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="STT" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="stt" runat="server" CssClass="css_Gma_c" Width="43px" gchu="Xếp loại bộ phận" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nhóm câu hỏi" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="nhom_cauhoi" runat="server" CssClass="css_Gma" Width="100px" gchu="Tỷ lệ xuất sắc (A*)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mã câu hỏi" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ma_cauhoi" runat="server" CssClass="css_Gma" Width="100px" gchu="Tỷ lệ xuất sắc (A*)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nội dung câu hỏi" HeaderStyle-Width="250px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="nd_cauhoi" runat="server" CssClass="css_Gma" Width="250px" gchu="Tỷ lệ tốt (A)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="5 - Xuất sắc" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="diem5" runat="server" Width="80px" CssClass="css_Gma_c" Text="" lke=",X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="4 - Tốt" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="diem4" runat="server" Width="80px" CssClass="css_Gma_c" Text="" lke=",X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="3 - Khá" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="diem3" runat="server" Width="80px" CssClass="css_Gma_c" Text="" lke=",X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="2 - Trung bình" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="diem2" runat="server" Width="100px" CssClass="css_Gma_c" Text="" lke=",X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="1 - Dưới trung bình" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="diem1" runat="server" Width="125px" CssClass="css_Gma_c" Text="" lke=",X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="1 - Dưới trung bình" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cauhoi_id" runat="server" CssClass="css_Gma_c" Width="85px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Kết quả</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Tổng số câu đạt điểm 5</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tong_diem5" ten="Mã nhóm câu hỏi" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kieu_chu="true"
                                    kt_xoa="G" MaxLength="20" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Tổng số câu đạt điểm 4</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tong_diem4" ten="Mã nhóm câu hỏi" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kieu_chu="true"
                                    kt_xoa="G" MaxLength="20" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Tổng số câu đạt điểm 3</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tong_diem3" ten="Mã nhóm câu hỏi" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kieu_chu="true"
                                    kt_xoa="G" MaxLength="20" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Tổng số câu đạt điểm 2</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tong_diem2" ten="Mã nhóm câu hỏi" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kieu_chu="true"
                                    kt_xoa="G" MaxLength="20" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Tổng số câu đạt điểm 1</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tong_diem1" ten="Mã nhóm câu hỏi" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kieu_chu="true"
                                    kt_xoa="G" MaxLength="20" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Width="100px" class="bt_action" anh="K" Text="Nhập" OnClick="dg_ngv_khdg_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="100px" class="bt_action" anh="K" Text="Xóa" OnClick="return dg_ngv_khdg_P_XOA();form_P_LOI();" />

                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
 
    <Cthuvien:an ID="so_id" runat="server" value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1300,800" />
</asp:Content>
