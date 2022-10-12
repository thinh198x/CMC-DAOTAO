<%@ Page Title="ns_dt_hvien_tgian" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_hvien_tgian.aspx.cs" Inherits="f_ns_dt_hvien_tgian" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh sách học viên tham gia khóa đào tạo" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nam_tk" runat="server" ten="Năm" ToolTip="Năm" ktra="DT_NAMTK" CssClass="form-control css_list" onchange="ns_dt_hvien_tgian_P_KTRA('NAM_TK')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tháng</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="thang_tk" runat="server" CssClass="form-control css_list" lke=",Tháng 01,Tháng 02, Tháng 03,Tháng 04,Tháng 05,Tháng 06,Tháng 07,Tháng 08,Tháng 09,Tháng 10,Tháng 11,Tháng 12" tra=",1,2,3,4,5,6,7,8,9,10,11,12" ten="Tháng" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Khóa ĐT</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KHOA_DT_TK" ktra="DT_KHOA_DT_TK" runat="server"  CssClass="form-control css_list" onchange="ns_dt_hvien_tgian_P_KTRA('KHOA_DT_TK')" kt_xoa="X" ten="Khóa ĐT"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Lớp ĐT</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="LOP_DT_TK" ktra="DT_LOP_DT_TK" runat="server"  CssClass="form-control css_list" onchange="ns_dt_hvien_tgian_P_KTRA('LOP_DT_TK')" kt_xoa="X" ten="Lớp ĐT"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" OnClick="return ns_dt_hvien_tgian_P_LKE('K');form_P_LOI();" Width="90px" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="16" cotAn="so_id" hamRow="ns_dt_hvien_tgian_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="80px"
                                        ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tháng" DataField="thang" HeaderStyle-Width="80px"
                                        ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Khóa đào tạo" DataField="khoa_dt" HeaderStyle-Width="160px"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Lớp đào tạo" DataField="lop_dt" HeaderStyle-Width="160px"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_hvien_tgian_P_LKE('K')" />

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_dt_hvien_tgian_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM"  runat="server" kt_xoa="X" ten="Năm" ToolTip="Năm" ktra="DT_NAM"  CssClass="form-control css_list" onchange="ns_dt_hvien_tgian_P_KTRA('NAM')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tháng <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="THANG"  runat="server"  CssClass="form-control css_list" lke="Tháng 01,Tháng 02, Tháng 03,Tháng 04,Tháng 05,Tháng 06,Tháng 07,Tháng 08,Tháng 09,Tháng 10,Tháng 11,Tháng 12" tra="1,2,3,4,5,6,7,8,9,10,11,12" ten="Tháng" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Khóa ĐT</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KHOA_DT"  ktra="DT_KDT" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Khóa đào tạo"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Lớp đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="lop_dt"  ten="lop_dt" CssClass="form-control css_list" runat="server" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Nhóm nội dung</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="nhom_nd"  ten="Nhóm nội dung" CssClass="form-control css_ma" runat="server" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Thời lượng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tluong" ten="Thời lượng"  runat="server" CssClass="form-control css_ma" kt_xoa="X" MaxLength="15"
                                     gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">TG bắt đầu</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy'  ID="ngayd" runat="server" ten="TG bắt đầu" CssClass="form-control icon_lich" kieu_luu="S"
                                    kt_xoa="X" ToolTip="TG bắt đầu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">TG kết thúc</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy'  ID="ngayc" runat="server" ten="TG kết thúc" CssClass="form-control icon_lich" kieu_luu="S"
                                    kt_xoa="X" ToolTip="TG kết thúc" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" runat="server" Text="Tổng hợp" class="bt_action" anh="K" OnClick="return ns_dt_hvien_tgian_P_TH('K');form_P_LOI();" Width="90px" />
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow: scroll;">
                            <Cthuvien:GridX ID="GR_ct" runat="server" loai="N" Width="100%"
                                AutoGenerateColumns="false" cotAn="loai_hv" cot="stt,so_the,ten,ten_cdanh,ten_phong,so_dt,email,email_ql,loai_hv" hangKt="12" PageSize="1" CssClass="table gridX">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="STT" HeaderText="STT" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="30px" />
                                    <asp:TemplateField HeaderText="Mã học viên" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="so_the" runat="server" CssClass="css_Gma" kt_xoa="X" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                BackColor="#f6f7f7" Width="120px" ktra="ns_cb,so_the,ten" placeholder="Nhấn (F1)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Họ tên" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten" runat="server" CssClass="css_Gma" kt_xoa="X" Width="120px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tên chức danh" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten_cdanh" runat="server" CssClass="css_Gma" kt_xoa="X" Width="150px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tên phòng" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten_phong" runat="server" CssClass="css_Gma" kt_xoa="X" Width="150px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số điện thoại" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="so_dt" runat="server" CssClass="css_Gso" kieu_so="true" kt_xoa="X" Width="120px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="Email" runat="server" CssClass="css_Gma" kt_xoa="X" Width="120px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email quản lý" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="email_ql" runat="server" CssClass="css_Gma" kt_xoa="X" Width="150px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Loại học viên" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_nhap ID="loai_hv" Height="22px" CssClass="css_Gma" runat="server" Width="120px" ten="Loại học viên">
                                                <asp:ListItem Selected="True" Value="" Text=""></asp:ListItem>
                                                <asp:ListItem Value="0" Text="Nội bộ"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Bên ngoài"></asp:ListItem>
                                            </Cthuvien:DR_nhap>
                                             <Cthuvien:DR_list ID="loai_hv" runat="server" lke="Nội bộ,Bên ngoài" tra="0,1" ten="Loại học viên" ToolTip="Loại học viên" CssClass="form-control css_list" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:BoundField DataField="loai_hv" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_GR_ct" runat="server" loai="N" gridId="GR_ct" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" class="bt_action" anh="K" OnClick="return ns_dt_hvien_tgian_P_NH();form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" OnClick="return ns_dt_hvien_tgian_P_MOI();form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_dt_hvien_tgian_P_XOA();form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="filemau" runat="server" Width="100px" class="bt_action" anh="K" Text="File mẫu" OnServerClick="nhap_Click" />
                        <Cthuvien:nhap ID="import" runat="server" Text="Import" class="bt_action" anh="K" onclick="return ns_dt_hvien_tgian_Import();form_P_LOI();" Width="120px" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="90px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                        </div>
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="so_id" runat="server" Value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1280,820" />
    <Cthuvien:an ID="thang_an" runat="server" Value="" />
    <Cthuvien:an ID="kdt_an" runat="server" Value="" />
    <Cthuvien:an ID="lop_dt_an" runat="server" Value="" />
</asp:Content>
