<%@ Page Title="dg_ngv_nbdg" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="dg_ngv_nbdg.aspx.cs" Inherits="f_dg_ngv_nbdg" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Nội bộ đánh giá" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common" style="display:none;">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Công ty</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="donvi_tk" ten="Công ty" runat="server" ktra="DT_DONVI_TK" kieu_chu="true" CssClass="form-control css_list"
                                    kt_xoa="G" onchange="dg_ngv_nbdg_P_NAM_TK();" kieu="S" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="trangthai_tk" ten="Trạng thái" runat="server" ktra="DT_TRANGTHAI_TK" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nam_tk" ten="Nhóm nội dung" runat="server" ktra="DT_NAM_TK" kieu_chu="true" 
                                    CssClass="form-control css_list" kt_xoa="G" onchange="dg_ngv_nbdg_P_NAM_TK();" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ky_dg_tk" ktra="DT_KY_DG_TK" ten="Kỳ đánh giá" runat="server" kieu_chu="true" 
                                    CssClass="form-control css_list" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" class="bt_action" anh="K" runat="server" Text="Tìm kiếm" Width="100px" OnClick="return dg_ngv_nbdg_P_LKE('M');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="trangthai,so_id" hamRow="dg_ngv_nbdg_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kỳ ĐG" DataField="ten_ky_dg" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten_canbo" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="dg_ngv_nbdg_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="width_common" style="display:none;">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Đơn vị <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="donvi" ten="Công ty" runat="server" ktra="DT_DONVI" kieu_chu="true" 
                                    CssClass="form-control css_list" kt_xoa="G" onchange="dg_ngv_nbdg_P_NAM();" kieu="S" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Nhóm nội dung" runat="server" ktra="DT_NAM" kieu_chu="true" CssClass="form-control css_list"
                                    kt_xoa="G" onchange="dg_ngv_nbdg_P_NAM();" kieu="S" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ đánh giá <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KY_DG" ten="Nhóm nội dung" runat="server" ktra="DT_KY_DG" kieu_chu="true" CssClass="form-control css_list"
                                    kt_xoa="G" onchange="dg_ngv_nbdg_P_KY_DG();" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Từ ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_d" ten="Từ ngày" disabled ReadOnly="true" runat="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_luu="S" BackColor="#f6f7f7" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_c" ten="Đến ngày" disabled ReadOnly="true" runat ="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_luu="S" BackColor="#f6f7f7" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">CD đánh giá <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="CDANH" ten="Chức danh" runat="server" ktra="DT_CDANH" kieu_chu="true" 
                                    CssClass="form-control css_list" kt_xoa="G" onchange="dg_ngv_nbdg_P_CDANH();" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Họ tên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="HOTEN" ten="Nhóm nội dung" runat="server" ktra="DT_HOTEN" kieu_chu="true" 
                                    CssClass="form-control css_list" kt_xoa="G" onchange="dg_ngv_nbdg_P_HOTEN();" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cot="stt,nhom_cauhoi,ma_cauhoi,nd_cauhoi,diem5,diem4,diem3,diem2,diem1,cauhoi_id" cotAn="cauhoi_id"
                                hangKt="10" gchuId="gchu" Width="100%" hamUp="tinhtong">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="STT" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="stt" runat="server" CssClass="css_Gma_c" Width="43px" gchu="Xếp loại bộ phận" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nhóm câu hỏi" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="nhom_cauhoi" disabled runat="server" CssClass="css_Gma" Width="100px" gchu="Nhóm câu hỏi" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mã câu hỏi" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ma_cauhoi" disabled runat="server" CssClass="css_Gma" Width="80px" gchu="Mã câu hỏi" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nội dung câu hỏi" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="nd_cauhoi" disabled runat="server" CssClass="css_Gma" Width="250px" gchu="Nội dung câu hỏi" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="5 - Xuất sắc" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="diem5" runat="server" Width="80px" CssClass="css_Gma_c" Text="X" lke=",X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="4 - Tốt" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="diem4" runat="server" Width="80px" CssClass="css_Gma_c" Text="X" lke=",X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="3 - Khá" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="diem3" runat="server" Width="80px" CssClass="css_Gma_c" Text="X" lke=",X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="2 - Trung bình" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="diem2" runat="server" Width="110px" CssClass="css_Gma_c" Text="X" lke=",X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="1 - Dưới trung bình" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="diem1" runat="server" Width="110px" CssClass="css_Gma_c" Text="X" lke=",X" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số id" HeaderStyle-Width="120px">
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
                            <span class="standard_label b_left col_45">Tổng số câu đạt điểm 5</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tong_diem5" ten="Mã nhóm câu hỏi" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kieu_chu="true"
                                    kt_xoa="G" MaxLength="20" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_45">Tổng số câu đạt điểm 4</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tong_diem4" ten="Mã nhóm câu hỏi" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kieu_chu="true"
                                    kt_xoa="G" MaxLength="20" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_45">Tổng số câu đạt điểm 3</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tong_diem3" ten="Mã nhóm câu hỏi" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kieu_chu="true"
                                    kt_xoa="G" MaxLength="20" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_45">Tổng số câu đạt điểm 2</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tong_diem2" ten="Mã nhóm câu hỏi" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kieu_chu="true"
                                    kt_xoa="G" MaxLength="20" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_45">Tổng số câu đạt điểm 1</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tong_diem1" ten="Mã nhóm câu hỏi" runat="server" BackColor="#f6f7f7" CssClass="form-control css_ma" kieu_chu="true"
                                    kt_xoa="G" MaxLength="20" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_45">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="trangthai" runat="server" lke="Chưa gửi, Đã gửi" tra="CG,DG" ten="Trạng thái" ToolTip="Trạng thái" CssClass="form-control css_list" BackColor="#f6f7f7" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" class="bt_action" anh="K" runat="server" Width="80px" Text="Nhập" OnClick="dg_ngv_nbdg_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="gui" class="bt_action" anh="K" runat="server" Width="80px" Text="Gửi" OnClick="return dg_ngv_nbdg_P_GUI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" class="bt_action" anh="K" runat="server" Width="80px" Text="Xóa" OnClick="return dg_ngv_nbdg_P_XOA();form_P_LOI();" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="so_id" runat="server" value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1300,730" />
</asp:Content>
