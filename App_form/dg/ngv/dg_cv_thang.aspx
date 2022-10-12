<%@ Page Title="dg_cv_thang" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="dg_cv_thang.aspx.cs" Inherits="f_dg_cv_thang" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Đánh giá công việc hàng tháng" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nam_tk" ten="Năm" runat="server" ktra="DT_NAM_TK" CssClass="form-control css_list" onchange="dg_cv_thang_P_KTRA('NAM')" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="trangthai_tk" ten="Mã yêu cầu TD" ktra="DT_TRANGTHAI_TK" runat="server"   CssClass="form-control css_list"/>
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server"  class="bt_action" anh="K" Text="Tìm kiếm" Width="100px" OnClick="return dg_cv_thang_P_LKE();form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="L" hangKt="20" cotAn="so_id,trangthai,ky_dg" hamRow="dg_cv_thang_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="50px"
                                        ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kỳ ĐG" DataField="ten_ky_dg" HeaderStyle-Width="150px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai" HeaderStyle-Width="80px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Xếp loại(TDG)" DataField="xeploai" HeaderStyle-Width="80px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Hệ số(TDG)" DataField="heso" HeaderStyle-Width="50px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Xếp loại(CBQL)" DataField="xeploai_ql" HeaderStyle-Width="80px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Hệ số(CBQL)" DataField="heso_ql" HeaderStyle-Width="50px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="so_id" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" HeaderStyle-Width="80px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Kỳ ĐG" DataField="ky_dg" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="dg_cv_thang_P_LKE('K')" />

                    </div>
                    <div class="list_bt_action" style="display: none;">
                        <Cthuvien:nhap ID="Nhap1" runat="server" Text="Xuất excel" OnClick="return dg_cv_thang_P_IN();form_P_LOI();" Width="100px" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" ktra="DT_NAM" CssClass="form-control css_list"
                                    Enabled="false" onchange="dg_cv_thang_P_KTRA('NAM')" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ đánh giá <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KY_DG" kt_xoa="X" Enabled="false" CssClass="form-control css_list" ten="Kỳ đánh giá" ktra="DT_KY_DG" runat="server" onchange="dg_cv_thang_P_KY_DG('K');"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" BackColor="#f6f7f7" runat="server" CssClass="form-control css_ma" kieu_chu="true"
                                    gchu="gchu" ten="Số thẻ cán bộ" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" BackColor="#f6f7f7" runat="server" CssClass="form-control css_ma" kieu_unicode="true"
                                    gchu="gchu" ten="Họ tên cán bộ" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="width: 760px; overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="N" hangKt="13"
                                cot="stt,ndung_cv,trong_so,ngay_d,ngay_dk,dien_giai,ketqua,tl_hthanh,tl_hthanh_ts,ykien,ykien_ql,tl_hthanh_ql,tl_hthanh_ts_ql,gchu_ql" hamUp="dg_cv_Update">
                                <%--dg_cv_thang_Update--%>
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Stt" DataField="stt" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:TemplateField HeaderText="Nội dung CV và kết quả mong muốn" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="nd_cv" runat="server" Width="150px" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Trọng số(%)" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="trong_so" runat="server" CssClass="css_Gso" Width="70px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày bắt đầu" HeaderStyle-Width="90px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder="dd/MM/yyyy" ID="ngay_d" runat="server" Width="90px" CssClass="css_Gma_c" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày hoàn thành(dự kiến)" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder="dd/MM/yyyy" ID="ngay_dk" runat="server" Width="100px" CssClass="css_Gma_c" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Diễn giải" HeaderStyle-Width="110px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dien_giai" runat="server" Width="110px" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Kết quả thực hiện" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ketqua" runat="server" Width="100px" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỉ lệ HT(%)" HeaderStyle-Width="90px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tl_hthanh" runat="server" Width="90px" CssClass="css_Gso" so_tp="2" co_dau="K" onkeyup="xulydulieu('nv')" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỉ lệ hoàn thành sau khi nhân trọng số(%)" HeaderStyle-Width="110px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tl_hthanh_ts" runat="server" Width="110px" CssClass="css_Gso" so_tp="2" co_dau="K" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Khó khăn/giải pháp/đề xuất" HeaderStyle-Width="110px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ykien" runat="server" Width="110px" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ý kiến về kết quả thực hiện(CBQL)" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ykien_ql" runat="server" CssClass="css_Gma" Width="100px" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ lệ HT(%)(CBQL)" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tl_hthanh_ql" runat="server" CssClass="css_Gma" Width="100px" kieu_so="true" Enabled="false" so_tp="1" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ lệ hoàn thành sau khi nhân trọng số(%)(CBQL)" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tl_hthanh_ts_ql" runat="server" CssClass="css_Gma" Width="150px" Enabled="false" so_tp="1" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ghi chú(CBQL)" HeaderStyle-Width="250px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="gchu_ql" runat="server" CssClass="css_Gma" Width="250px" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common mgt10">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Kết quả hoàn thành(TDG) <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="KETQUA_TONG" kieu_so="true" runat="server" MaxLength="4" ten="Kết quả" kt_xoa="X" CssClass="form-control css_so"
                                    BackColor="#f6f7f7" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Xếp loại đánh giá(TDG) <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="XEPLOAI" runat="server" CssClass="form-control css_ma" kieu_unicode="true" BackColor="#f6f7f7"
                                    gchu="gchu" ten="Xếp loại đánh giá" kt_xoa="X" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Hệ số(TDG) <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="HESO" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    gchu="gchu" ten="Họ tên cán bộ" kt_xoa="X" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="trangthai" ten="Trạng thái" runat="server" ktra="DT_TRANGTHAI" kieu_chu="true" CssClass="form-control css_list"
                                    kt_xoa="G" BackColor="#f6f7f7" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Kết quả hoàn thành(CBQL)</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ketqua_ht_ql" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                    ten="Kết quả hoàn thành" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Kết quả chung(CBQL)</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ketqua_chung_ql" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                    ten="Kết quả chung" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Xếp loại đánh giá(CBQL)</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="xeploai_ql" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_unicode="true" kieu_chu="true" kt_xoa="X"
                                    ten="xếp loại đánh giá" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Hệ số đánh giá(CBQL)</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="heso_ql" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                    ten="Hệ số đánh giá" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" class="bt_action" anh="K" runat="server" Text="Làm mới" Width="100px" OnClick="return dg_cv_thang_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" class="bt_action" anh="K" runat="server" Width="100px" Text="Nhập" OnClick="return dg_cv_thang_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="Gui" class="bt_action" anh="K" runat="server" Width="100px" Text="Gửi" OnClick="return dg_cv_thang_P_GUI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" class="bt_action" anh="K" runat="server" Width="100px" Text="Xóa" OnClick="return dg_cv_thang_P_XOA();form_P_LOI();" />

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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1450,870" />
    </div>
</asp:Content>
