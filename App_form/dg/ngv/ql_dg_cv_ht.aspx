<%@ Page Title="ql_dg_cv_ht" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ql_dg_cv_ht.aspx.cs" Inherits="f_ql_dg_cv_ht" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quản lý đánh giá công việc hàng tháng" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_40">Năm<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="nam1" ten="Năm" runat="server" ktra="DT_NAM" kieu_chu="true" CssClass="form-control css_list"
                                kt_xoa="G" onchange="ql_dg_cv_ht_P_NAM('F');" kieu="S" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_40">Kỳ đánh giá<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="ky_dg1" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_40">Trạng thái</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="trangthai_tk" ten="Trạng thái" runat="server" ktra="DT_TRANGTHAI_TK" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="ql_dg_cv_ht_P_NAM_TK();" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" class="bt_action" anh="K" runat="server" Text="Tìm kiếm" Width="100px" OnClick="return ql_dg_cv_ht_P_LKE('M');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="13" cotAn="so_id,trangthai,xacnhan" hamRow="ql_dg_cv_ht_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kỳ ĐG" DataField="ten_ky_dg" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="ma" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Kết quả ĐG" DataField="kq_dg" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Xác nhận" DataField="xacnhan" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ql_dg_cv_ht_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" class="bt_action" anh="K" runat="server" Width="100px" Text="Xuất excel" OnClick="return ns_hdct_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" ktra="DT_NAM" kieu_chu="true" CssClass="form-control css_list"
                                    Enabled="false" kt_xoa="G" onchange="ql_dg_cv_ht_P_NAM('N');" kieu="S" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ đánh giá<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KY_DG" ten="Nhóm nội dung" Enabled="false" runat="server" ktra="DT_KY_DG" kieu_chu="true" CssClass="form-control css_list"
                                    kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                    ten="Mã nhân viên" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                    ten="Tên nhân viên" Enabled="false" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table mgt10 width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cot="stt,nd_congviec,trongso,ngay_d,ngay_ht,diengiai_kqth,ketqua,tyle_ht_nv,tyle_ht_tso_nv,kkhan_gphap_dxuat,ykien_kq_th,tyle_ht_ql,tyle_ht_tso_ql,gchu"
                                hangKt="10" gchuId="gchu" Width="100%" hamRow="ktra_dulieu()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="STT" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="stt" runat="server" kieu_so="true" Width="40px" CssClass="css_Gso" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nội dung công việc và kết quả mong muốn" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="nd_congviec" runat="server" CssClass="css_Gma" Width="130px" gchu="Tỷ lệ xuất sắc (A*)" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Trọng số" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="trongso" runat="server" kieu_so="true" Width="80px" CssClass="css_Gso" onkeyup="xulydulieu('ts')" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày bắt đầu" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder="dd/MM/yyyy" ID="ngay_d" runat="server" CssClass="css_Gma_c" Width="100px" kt_xoa="X" TaoValid="true" kieu_luu="S" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày hoàn thành dự kiến" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder="dd/MM/yyyy" ID="ngay_ht" runat="server" CssClass="css_Gma_c" Width="100px" kt_xoa="X" TaoValid="true" kieu_luu="S" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Diễn giải" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diengiai_kqth" runat="server" CssClass="css_Gma" Width="100px" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Kết quả thực hiện" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ketqua" runat="server" CssClass="css_Gma" Width="100px" onkeyup="xulydulieu('nv')" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ lệ HT(%)" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tyle_ht_nv" runat="server" CssClass="css_Gma" Width="100px" so_tp="1" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ lệ hoàn thành sau khi nhân trọng số(%)" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tyle_ht_tso_nv" runat="server" CssClass="css_Gma" Width="100px" so_tp="1" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Khó khăn/giải pháp/đề xuất" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="kkhan_gphap_dxuat" runat="server" CssClass="css_Gma" Width="100px" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ý kiến về kết quả thực hiện(CBQL)" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ykien_kq_th" runat="server" CssClass="css_Gma" Width="100px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ lệ HT(%)(CBQL)" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tyle_ht_ql" runat="server" CssClass="css_Gma" Width="100px" kieu_so="true" onkeyup="xulydulieu('ql')" so_tp="1" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ lệ hoàn thành sau khi nhân trọng số(%)(CBQL)" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tyle_ht_tso_ql" runat="server" CssClass="css_Gma" Enabled="false" so_tp="1" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ghi chú(CBQL)" HeaderStyle-Width="250px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="gchu" runat="server" CssClass="css_Gma" Width="250px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="col_2_iterm mgt10 width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Kết quả hoàn thành(TDG)<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="KETQUA_TONG" kieu_so="true" runat="server" MaxLength="4" ten="Kết quả" kt_xoa="X" CssClass="form-control css_so"
                                    BackColor="#f6f7f7" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Xếp loại đánh giá(TDG)<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="XEPLOAI" runat="server" CssClass="form-control css_ma" kieu_unicode="true" BackColor="#f6f7f7"
                                    gchu="gchu" ten="Xếp loại đánh giá" kt_xoa="X" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Hệ số(TDG)<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="HESO" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    gchu="gchu" ten="Họ tên cán bộ" kt_xoa="X" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="trangthai" runat="server" lke="Chưa gửi, Chờ xem xét,Đã xem xét,Không phê duyệt" tra="CG,0,1,2" ten="Trạng thái" ToolTip="Trạng thái" CssClass="form-control css_list" BackColor="#f6f7f7" Enabled="false" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Kết quả hoàn thành(CBQL)</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="kq_ht" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                    ten="Kết quả hoàn thành" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kết quả chung(CBQL)</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="kqchung" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kt_xoa="X"
                                    ten="Kết quả chung" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Xếp loại đánh giá(CBQL)</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="xeploai_danhgia" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_unicode="true" kieu_chu="true" kt_xoa="X"
                                    ten="xếp loại đánh giá" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Hệ số đánh giá(CBQL)</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="heso_danhgia" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kt_xoa="X"
                                    ten="Hệ số đánh giá" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" class="bt_action" anh="K" runat="server" Width="80px" Text="Nhập" OnClick="ql_dg_cv_ht_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="gui" class="bt_action" anh="K" runat="server" Width="80px" Text="Xác nhận" OnClick="return ql_dg_cv_ht_P_XACNHAN();form_P_LOI();" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                        </div>
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="nam_tk_an" runat="server" />
    <Cthuvien:an ID="ky_dg_tk_an" runat="server" />
    <Cthuvien:an ID="trangthai_tk_an" runat="server" />
    <Cthuvien:an ID="so_id" runat="server" value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1370,770" />
</asp:Content>
