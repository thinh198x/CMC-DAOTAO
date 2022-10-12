<%@ Page Title="ns_dt_trienkhai_kdt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_trienkhai_kdt.aspx.cs" Inherits="f_ns_dt_trienkhai_kdt" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Triển khai khóa đào tạo" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_ct">
                    <div class="width_common pv_bl"><span>Thông tin chung</span></div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nam" ktra="DT_NAM" Enabled="false" runat="server" CssClass="form-control css_list" onchange="ns_dt_trienkhai_kdt_P_KTRA('LKE_KDT')"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tháng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="thang" ktra="DT_THANG" Enabled="false" CssClass="form-control css_list" runat="server"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã khóa đào tạo <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="MA_KDT" ktra="DT_DM_KDT" Enabled="false" runat="server" CssClass="form-control css_list" onchange="ns_dt_trienkhai_kdt_P_KTRA('MA_KDT')"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Tên khóa đào tạo <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_kdt" ten="Tên khóa đào tạo" Enabled="false" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Nhóm nội dung</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="nhom_nd" ten="Nhóm nội dung" Enabled="false" runat="server" CssClass="form-control css_ma" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã lớp đào tạo <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_lop" ten="Mã lớp đào tạo" runat="server" Enabled="false" CssClass="form-control css_ma" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Tên lớp đào tạo <span class="require">*</span>	</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_lop" ten="Tên lớp đào tạo" runat="server" kieu_unicode="true" Enabled="false" CssClass="form-control css_ma" />

                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày bắt đầu</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_d" runat="server" CssClass="form-control icon_lich" kt_xoa="X"
                                    ten="Ngày bắt đầu" onchange="ns_dt_trienkhai_kdt_P_KTRA('ngay_d');" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày kết thúc</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_c" runat="server" CssClass="form-control icon_lich" kt_xoa="X"
                                    ten="Ngày kết thúc" onchange="ns_dt_trienkhai_kdt_P_KTRA('ngay_c');" />

                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Thời lượng đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:so ID="THLUONG" ten="Thời lượng đào tạo" runat="server" CssClass="form-control css_so" kt_xoa="X" co_dau="K" MaxLength="5" onchange="ns_dt_trienkhai_kdt_P_KTRA('thluong');" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Địa điểm đào tạo </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ddiem" ten="Địa điểm đào tạo" runat="server" CssClass="form-control css_ma" kieu_unicode="true" MaxLength="200" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Hình thức đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="hinhthuc" Enabled="false" ktra="DT_HINHTHUC" runat="server" ten="Hình thức đào tạo" ToolTip="Hình thức đào tạo" CssClass="form-control css_ma" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Số h.viên d.kiến</span>
                            <div class="input-group">
                                <Cthuvien:so ID="sl_hvien" Enabled="false" ten="Số lượng học viên dự kiến" runat="server" CssClass="form-control icon_so" kt_xoa="X" MaxLength="3" />

                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Đối tác đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="doitac" Enabled="false" ktra="DT_DTAC" runat="server" CssClass="form-control css_list " onchange="ns_dt_trienkhai_kdt_P_KTRA('MA_KDT')"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Giảng viên đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="gv_dt" runat="server" CssClass="form-control css_ma" kieu_unicode="true"></Cthuvien:ma>
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Điểm danh học viên</span></div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_gvdt" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="N" hangKt="5" cot="sott,so_the,hoten,ddanh,cdanh,phong,sodt,email,ghichu"
                                ctrS="nhap">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="STT" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="sott" ten="Số thứ tự" runat="server" kt_xoa="X" Width="100%" CssClass="css_Gma" BackColor="#f6f7f7"></Cthuvien:ma>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mã nhân viên" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="so_the" ten="Mã nhân viên" runat="server" kt_xoa="X" Width="100%" CssClass="css_Gma" BackColor="#f6f7f7"></Cthuvien:ma>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Họ tên" HeaderStyle-Width="220px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="hoten" runat="server" CssClass="css_Gma" kieu_unicode="true" kt_xoa="X" Width="100%" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm danh" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_list ID="ddanh" runat="server" Width="150px" lke=",Có mặt,Vắng có phép, Vắng không phép" tra=",CM,CP,KP" ten="Trạng thái" CssClass="css_Glist" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chức danh" HeaderStyle-Width="160px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cdanh" runat="server" CssClass="css_Gma" kt_xoa="X" Width="100%" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phòng ban" HeaderStyle-Width="160px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phong" runat="server" CssClass="css_Gma" kt_xoa="X" Width="100%" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số ĐT" HeaderStyle-Width="160px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="sodt" runat="server" CssClass="css_Gma" kt_xoa="X" Width="100%" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email" HeaderStyle-Width="160px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="email" runat="server" CssClass="css_Gma" kt_xoa="X" Width="100%" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="220px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ghichu" runat="server" CssClass="css_Gma" kt_xoa="X" Width="100%" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide_gv" runat="server" loai="X" gridId="GR_gvdt"  />

                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_trienkhai_hv_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_trienkhai_hv_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_trienkhai_hv_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return ns_dt_trienkhai_hv_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="width_common pv_bl mgt10"><span>Chi phí đào tạo</span></div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_cpdt" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cot="stt,loai_cp,stien" hangKt="3"
                                ctrS="nhap" hamUp="ns_dt_trienkhai_cp_GR_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Số TT" HeaderStyle-Width="140px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="stt" ten="Số TT" CssClass="css_Gma_c" runat="server" kt_xoa="X" Width="100%" kieu_so="true"></Cthuvien:so>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Loại chi phí" HeaderStyle-Width="380px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="loai_cp" runat="server" CssClass="css_Gma" kt_xoa="X" Width="100%" MaxLength="250" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số tiền" HeaderStyle-Width="240px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="stien" runat="server" Width="100%" CssClass="css_Gma_r" kt_xoa="X" co_dau="K" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </Cthuvien:GridX>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide_cp" runat="server" loai="X" gridId="GR_cpdt"  />

                            <div class="btex_luoi b_right">
                                <ul>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_trienkhai_cp_HangLen();" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_trienkhai_cp_HangXuong();" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_trienkhai_cp_CatDong();" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return ns_dt_trienkhai_cp_ChenDong('C');" />
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="col_4_iterm width_common  mgt10">
                        <div class="b_left form-group iterm_form">
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Tổng chi phí</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tong_cp" runat="server" CssClass="form-control css_so" BackColor="#f6f7f7" ReadOnly="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chi phí 1 học viên</span>
                            <div class="input-group">
                                <Cthuvien:so ID="cp_hvien" runat="server" CssClass="form-control css_so" BackColor="#f6f7f7" ReadOnly="true" kt_xoa="X" />
                            </div>
                        </div>

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_dt_trienkhai_kdt_P_MOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_dt_trienkhai_kdt_P_NH();" />
                    </div>

                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1350,880" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
    </div>
</asp:Content>
