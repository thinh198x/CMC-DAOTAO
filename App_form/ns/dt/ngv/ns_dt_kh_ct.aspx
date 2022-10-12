<%@ Page Title="ns_dt_kh_ct" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_kh_ct.aspx.cs" Inherits="f_ns_dt_kh_ct" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Kế hoạch đào tạo chi tiết" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nam_tk" ktra="DT_NAM_TK" runat="server" CssClass="form-control css_list"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tháng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="thangtk" ktra="DT_THANG_TK" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Tháng"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">HT đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="hthuc_tk" lke=",Inclass,Hội thảo,On Job Training,Talkshow" tra=",IL,HT,OJT,TS"  CssClass="form-control css_list"
                                    kt_xoa="X" runat="server" ten="Hình thức đào tạo" ToolTip="Hình thức đào tạo" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" class="bt_action" anh="K" Width="100px" Text="Tìm kiếm" OnClick="return ns_dt_kh_ct_P_LKE();" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <div style="overflow-x: scroll;">
                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                    CssClass="table gridX" hangKt="15" cot="SOTT,SO_ID,MA_KDT,NAM,THANG,TEN,TEN_LOP,NGAY_D,NGAY_C,THLUONG,SL_HVIEN"
                                    cotAn="SOTT,SO_ID,MA_KDT" hamRow="ns_dt_kh_ct_GR_lke_RowChange()">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField DataField="SOTT" />
                                        <asp:BoundField DataField="SO_ID" />
                                        <asp:BoundField DataField="MA_KDT" />
                                        <asp:BoundField HeaderText="Năm" DataField="NAM" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="Tháng" DataField="THANG" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="Khóa ĐT" DataField="TEN" HeaderStyle-Width="170px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Lớp" DataField="TEN_LOP" HeaderStyle-Width="170px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Ngày BĐ" DataField="NGAY_D" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="Ngày KT" DataField="NGAY_C" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="Th.lượng ĐT" DataField="THLUONG" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="Số h.viên" DataField="SL_HVIEN" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />

                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_kh_ct_P_LKE()" />

                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_dt_kh_ct_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="width_common pv_bl"><span>Thông tin chung</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Theo kế hoạch</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="kh_nam" runat="server"  CssClass="form-control css_ma" lke=",X" Text="" kt_xoa="X"
                                    ToolTip="X - có theo kế hoạch năm, - không theo kế hoạch năm" onchange="ns_dt_kh_ct_P_NPA(),ns_dt_kh_ct_P_KTRA('YEUCAU')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="NAM" runat="server"  CssClass="form-control css_ma" kt_xoa="X" ToolTip="Năm" ten="Năm"
                                    onchange="ns_dt_kh_ct_P_KTRA('NAM')" MaxLength="4" kieu_so="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tháng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="thang" ktra="DT_THANG" runat="server"  CssClass="form-control css_list" kt_xoa="X" ten="Tháng" onchange="ns_dt_kh_ct_P_KTRA('THANG')"></Cthuvien:DR_lke>
                            </div>
                            <div style="display: none;">
                                <Cthuvien:ma ID="ten_kdt" ten="Tên khóa đào tạo" runat="server" CssClass="css_form" BackColor="#f6f7f7" ReadOnly="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Nhóm nội dung</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nhom_nd" runat="server"  CssClass="form-control css_list" ktra="DT_NND" kt_xoa="X" onchange="ns_dt_kh_ct_P_KTRA('NHOM_ND')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã khóa đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ma_kdt_nhucau" kt_xoa="X" runat="server"  CssClass=" css_list" ktra="DT_NHUCAU" onchange="ns_dt_kh_ct_P_KTRA('KDT_NHUCAU')" />
                                <Cthuvien:DR_lke ID="ma_kdt" kt_xoa="X" runat="server"  CssClass="form-control css_list" ten="Mã khóa đào tạo" ktra="DT_KDT" onchange="ns_dt_kh_ct_P_KTRA('MA_KDT')" />

                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã lớp(Tự sinh) <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA_LOP" kieu_unicode="true" ten="Mã lớp đào tạo" runat="server" Enabled="false" BackColor="#f6f7f7"  CssClass="form-control css_ma" kt_xoa="X" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên lớp đào tạo <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_LOP" kieu_unicode="true" ten="Tên lớp đào tạo" runat="server"  CssClass="form-control css_ma" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Hình thức đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="hinhthuc" lke=",Inclass,Hội thảo,On Job Training,Talkshow" tra=",IL,HT,OJT,TS" CssClass="form-control css_list"
                                    kt_xoa="X" runat="server" ten="Hình thức đào tạo" ToolTip="Hình thức đào tạo" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày bắt đầu</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_d" runat="server" CssClass="form-control icon_lich" kt_xoa="X"
                                    ten="Ngày bắt đầu" onchange="ns_dt_kh_ct_P_KTRA('ngay_d');" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày kết thúc</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_c" runat="server" CssClass="form-control icon_lich" kt_xoa="X"
                                    ten="Ngày kết thúc" onchange="ns_dt_kh_ct_P_KTRA('ngay_c');" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Địa điểm đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ddiem" ten="Địa điểm đào tạo" kieu_unicode="true" runat="server" CssClass="form-control css_ma"
                                    kt_xoa="X" MaxLength="200" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Thời lượng đào tạo <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="THLUONG" ten="Thời lượng đào tạo" MaxLength="10" kt_xoa="X" kieu_so="true" runat="server" so_tp="1"  CssClass="form-control css_ma" kieu_chu="True" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số h.viên d.kiến</span>
                            <div class="input-group">
                                <Cthuvien:so ID="sl_hvien" ten="Số lượng học viên dự kiến" runat="server" CssClass="form-control css_so" kt_xoa="X" MaxLength="3" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đối tác đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="doitac" ktra="DT_DTAC" runat="server"  CssClass="form-control css_list" onchange="ns_dt_kh_ct_P_LKE_GVIEN()" kt_xoa="X"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Giảng viên đào tạo</span></div>
                    <div class="grid_table width_common">
                        <Cthuvien:GridX ID="GR_gvdt" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                            CssClass="table gridX" loai="N" cot="loai_gv,ma_gv,ten_gv,knghiem" hangKt="5"
                            ctrS="nhap" hamUp="ns_dt_kh_ct_GR_Update">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:TemplateField HeaderText="Loại GV" HeaderStyle-Width="70px">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="loai_gv" runat="server" kt_xoa="X" Width="70px" CssClass="css_Gma" Enabled="false"></Cthuvien:ma>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mã giảng viên" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="ma_gv" ReadOnly="true" runat="server" placeholder="Nhấn (F1)" Width="100px" CssClass="css_Gma_c"
                                            f_tkhao="~/App_form/ns/dt/dm/ns_dt_ma_gv_noi.aspx"></Cthuvien:ma>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Họ tên giảng viên" HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="ten_gv" runat="server" kt_xoa="X" Width="150px" CssClass="css_Gma" Enabled="false"></Cthuvien:ma>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Kinh nghiệm giảng viên" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="knghiem" runat="server" CssClass="css_Gma" kieu_unicode="true" Enabled="false" kt_xoa="X" Width="200px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </Cthuvien:GridX>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_kh_gv_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_kh_gv_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_kh_gv_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return ns_dt_kh_gv_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Chi phí đào tạo</span></div>
                    <div class="grid_table width_common">
                        <Cthuvien:GridX ID="GR_cpdt" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                            CssClass="table gridX" loai="N" cot="sott,ma_cp,loai_cp,stien" hangKt="5"
                            ctrS="nhap" hamUp="ns_dt_kh_cp_GR_Update">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:TemplateField HeaderText="Số TT" HeaderStyle-Width="60px">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="sott" ten="Số TT" CssClass="css_Gma_c" runat="server" kt_xoa="X" Width="100%"></Cthuvien:ma>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mã loại chi phí" HeaderStyle-Width="120px">
                                    <ItemTemplate>
                                        <Cthuvien:DR_list ID="ma_cp" ten="Mã chi phí" lke="Chi phí giảng viên,Chi phí hậu cần" tra="GV,HC" runat="server" DataTextField="ten" DataValueField="ma"
                                            CssClass="css_Glist" kieu="S" Height="20px" Width="155px"> 
<%--                                                                            <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                                                                            <asp:ListItem Text="Chi phí giảng viên" Value="GV"></asp:ListItem>
                                                                            <asp:ListItem Text="Chi phí hậu cần" Value="HC"></asp:ListItem>--%>
                                        </Cthuvien:DR_list>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Loại chi phí" HeaderStyle-Width="240px">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="loai_cp" runat="server" CssClass="css_Gma" kieu_unicode="true" kt_xoa="X" Width="100%" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Số tiền" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <Cthuvien:so ID="stien" runat="server" Width="100%" CssClass="css_Gma_r" kt_xoa="X" co_dau="K" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </Cthuvien:GridX>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_kh_cp_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_kh_cp_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_kh_cp_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return ns_dt_kh_cp_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tổng chi phí</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tong_cp" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" Enabled="false" ReadOnly="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chi phí 1 học viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="cp_hvien" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" Enabled="false" ReadOnly="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_dt_kh_ct_P_MOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Width="80px" Text="Ghi" OnClick="return ns_dt_kh_ct_P_NH();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Width="80px" Text="Xóa" OnClick="return ns_dt_kh_ct_P_XOA();" />
                        <%--<Cthuvien:nhap ID="tkb" runat="server" Width="100px" Text="Thời khóa biểu" OnClick="return ns_dt_kh_ct_P_TT('TKB');" />
                                            <Cthuvien:nhap ID="mon" runat="server" Width="80px" Text="Môn thi" OnClick="return ns_dt_kh_ct_P_TT('MON');" />
                                            <Cthuvien:nhap ID="guipd" runat="server" Width="100px" Text="Gửi phê duyệt" OnClick="return ns_dt_kh_ct_P_PD();" />--%>
                        <Cthuvien:nhap ID="chon" runat="server" class="bt_action" anh="K" Width="80px" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN,LVUC_DTAO');" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />

                        </div>
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" ForeColor="Red" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,800" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
    </div>
</asp:Content>
