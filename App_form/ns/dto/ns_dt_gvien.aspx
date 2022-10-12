<%@ Page Title="ns_dt_gvien" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_gvien.aspx.cs" Inherits="f_ns_dt_gvien" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh sách giảng viên" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="gridX" loai="X" cotAn="so_id" hangKt="15" hamRow="ns_dt_gvien_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="so_the" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Đơn vị" DataField="donvi" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_gvien_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Linh vực đào tạo<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="LVDAOTAO" ten="Lĩnh vực đào tạo" runat="server" kieu="S" CssClass="form-control css_list" ktra="DT_LVDAOTAO"
                                    onchange="ns_dt_gvien_P_KTRA('LVDAOTAO')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <div class="input-group">
                                <Cthuvien:kieu ID="lke" runat="server" CssClass="form-control css_ma_c" Width="30px" ten="Kiểu liệt kê"
                                    Text="B" lke="B,N" ToolTip="Liệt kê theo: B-Bên ngoài,N-Nội bộ"
                                    onblur="ns_dt_gvien_P_KTRA('LKE')" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Mã GV/Tổ chức</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã giảng viên/Tổ chức" runat="server" CssClass="form-control css_ma"
                                    BackColor="#f6f7f7" onblur="ns_dt_gvien_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" kt_xoa="G" placeholder="Nhấn F1" Width="45%" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Tên GV/Tổ chức</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ToolTip="Tên GV/Tổ chức" runat="server" ten="Tên GV/Tổ chức"
                                    CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Đơn vị</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="donvi" ten="Tên đơn vị" ToolTip="Tên đơn vị" kieu_unicode="true"
                                    runat="server" CssClass="form-control css_ma" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Bộ phận/Phòng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="phong" ten="Bộ phận/phòng" runat="server" CssClass="form-control css_ma"
                                    kt_xoa="X" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">L.vực hoạt động</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="hoatdong" ten="Lĩnh vực hoạt động" runat="server" CssClass="form-control css_ma"
                                    kieu_unicode="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20"><b>Hồ sơ năng lực</b></span>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="gridX" loai="N" cot="wlvdaotao,noidung,danhgia" hangKt="10" hamUp="ns_dt_gvien_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Lĩnh vực đào tạo(*)" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="wlvdaotao" runat="server" Width="100%" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/dto/ns_dt_ma_lvdaotao.aspx"
                                                ktra="ns_ma_lvdaotao,ma,ten" kieu_chu="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nội dung(*)">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="noidung" runat="server" Width="100%" kieu_unicode="true" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Đánh giá(*)">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="danhgia" runat="server" Width="100%" kieu_unicode="true" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_gvien_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_gvien_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_gvien_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return ns_dt_gvien_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                        <div class="list_bt_action">
                            <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_dt_gvien_P_MOI();form_P_LOI();" />
                            <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_dt_gvien_P_NH();form_P_LOI();" />
                            <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_dt_gvien_P_XOA();form_P_LOI();" />
                            <Cthuvien:nhap ID="chon" runat="server" Width="70px" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('SO_THE,TEN');form_P_LOI();" />
                        </div>
                        <div id="UPa_gchu" class="css_border" align="left" style="margin-top: 50px;">
                            <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="950,490" />
    </div>
</asp:Content>
