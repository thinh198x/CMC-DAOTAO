<%@ Page Title="ns_dt_kdt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_kdt.aspx.cs" Inherits="f_ns_dt_kdt" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Khóa thi online" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                            CssClass="table gridX" loai="X" hangKt="20" cotAn="so_id,tt" hamRow="ns_dt_kdt_GR_lke_RowChange()">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:BoundField HeaderText="Mã" DataField="ma" ItemStyle-CssClass="css_Gnd" />
                                <asp:BoundField HeaderText="Tên khóa đào tạo" DataField="ten" ItemStyle-CssClass="css_Gnd" />
                                <asp:BoundField HeaderText="Ngày trình" DataField="ngaytrinh" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField HeaderText="Tình trạng" DataField="tinhtrang" ItemStyle-CssClass="css_Gnd" />
                                <asp:BoundField HeaderText="Người PD" DataField="nguoi_pd" ItemStyle-CssClass="css_Gnd" />
                                <asp:BoundField HeaderText="so_id" DataField="so_id" ItemStyle-CssClass="css_Gnd" />
                                <asp:BoundField HeaderText="Ngày trình" DataField="tt" ItemStyle-CssClass="css_Gma_c" />
                            </Columns>
                        </Cthuvien:GridX>
                    </div>
                    <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_kdt_P_LKE('K')" />
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã khóa học<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" ten="Mã khóa học" ToolTip="Mã khóa học" runat="server" CssClass="form-control css_ma"
                                    kieu_chu="true" BackColor="#f6f7f7" ktra="ns_dt_dxuat,ma,ten" kt_xoa="K" f_tkhao="~/App_form/ns/dto/ns_dt_dxuat.aspx"
                                    onchange="ns_dt_kdt_P_KTRA('MA')" placeholder="Nhấn F1" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày trình</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaytrinh" runat="server" ten="Ngày trình"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Tên khóa học<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Tên khóa học" ToolTip="Tên khóa đào tạo" kieu_unicode="true"
                                    runat="server" CssClass="form-control css_ma" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Loại đào tạo<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="LOAIDT" runat="server" CssClass="form-control css_list"
                                    ten="Đối tượng cư trú" tra="HN,NB,BN" lke="Đào tạo hội nhập,Đào tạo nội bộ,Đào tạo bên ngoài" kt_xoa="X" />
                                <Cthuvien:an ID="hincd" runat="server" Value="" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Theo mã đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_nhucau" ten="Theo mã đào tạo" guiId="LOAIDT" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ktra="ns_dt_nhucau_dt,ma,ten" kt_xoa="G" f_tkhao="~/App_form/ns/dto/ns_dt_nhucau_dt.aspx"
                                    kieu_chu="true" gchu="gchu" onchange="ns_dt_kdt_P_KTRA('MA_NHUCAU')" placeholder="Nhấn F1" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Nơi đào tạo<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:nd ID="noidt" ten="Nơi đào tạo" runat="server" CssClass="form-control css_nd"
                                    kt_xoa="X" kieu_unicode="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Từ ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayd" runat="server" ten="Từ ngày" CssClass="form-control icon_lich"
                                    MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayc" runat="server" ten="Đến ngày" CssClass="form-control icon_lich"
                                    MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Hình thức đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="hinhthuc" ten="Hình thức đào tạo" runat="server" CssClass="form-control css_ma"
                                    BackColor="#f6f7f7" kieu_chu="true" ktra="ns_ma_htdt,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_htdt.aspx"
                                    onchange="ns_dt_kdt_P_KTRA('hinhthuc')" kt_xoa="X" placeholder="Nhấn F1" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Cam kết đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="is_camket" runat="server" lke="C,K" Width="30px" kt_xoa="X" ToolTip="C - Cam kết đào tạo, K - Không cam kết đào tạo" CssClass="form-control css_ma_c" Text="K" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Nguồn kinh phí</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="kinhphi" ten="Nguồn kinh phí" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ktra="ns_dt_ma_nguonkp,ma,ten" kt_xoa="X" f_tkhao="~/App_form/ns/dto/ns_dt_ma_nguonkp.aspx"
                                    kieu_chu="true" onchange="ns_dt_kdt_P_KTRA('KINHPHI')" gchu="gchu" placeholder="Nhấn F1" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Cam kết đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:so ID="giatri" ten="Cam kết đào tạo" runat="server" CssClass="form-control css_ma"
                                    onchange="ns_dt_kdt_P_KTRA('giatri')" kt_xoa="X" ValueText="0" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form" style="display: none">
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_nte" runat="server" kt_xoa="K" CssClass="form-control css_ma" kieu_chu="true"
                                    BackColor="#DBE8F1" f_tkhao="~/App_form/ns/ma/ns_ma_nte.aspx" Width="27px" Text="VND"
                                    ten="Mã tiền tệ" onchange="ns_dt_kdt_P_KTRA('MA_NTE')" ktra="ns_ma_nte,ma,ten" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form" style="display: none"> 
                            <span class="standard_label b_left col_15">Ý kiến lãnh đạo<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:nd ID="ykien" ToolTip="Ý kiến lãnh đạo" runat="server" CssClass="form-control css_nd"
                                    kt_xoa="X" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div id="NPa" runat="server" class="navi_tabngang width_common">
                        <Cthuvien:tab ID="NPa_nv" runat="server" CssClass="css_tab_ngang_ac" Width="150px"
                            Text="D/S theo nhân viên mới" />
                        <Cthuvien:tab ID="NPa_cdanh" runat="server" CssClass="css_tab_ngang_de" Width="148px"
                            Text="D/S theo chức danh" />
                        <Cthuvien:tab ID="NPa_nhucau" runat="server" CssClass="css_tab_ngang_de" Width="148px"
                            Text="D/S theo nhu cầu" />
                    </div>
                    <div>
                        <asp:Panel ID="Pa_nv" runat="server" Style="display: block;">
                            <div class="grid_table width_common">
                                <div>
                                    <Cthuvien:GridX ID="GR_nv" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                        CssClass="table gridX" loai="N" cot="so_the,ten,ten_phong,phong" cotAn="phong" hangKt="10" hamUp="ns_dt_kdt_nv_Update">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:TemplateField HeaderText="Mã nhân viên" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="so_the" runat="server" Width="100px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                        ktra="ns_cb,so_the,ten" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Tên Phòng" DataField="ten_phong" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Phòng" DataField="phong" ItemStyle-CssClass="css_Gma" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                            </div>
                            <div class="btex_luoi b_right">
                                <ul>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_kdt_nvm_HangLen();" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_kdt_nvm_HangXuong();" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_kdt_nvm_CatDong();" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn thêm dòng" onclick="return ns_dt_kdt_nvm_ChenDong('C');" />
                                    </li>
                                </ul>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="Pa_cdanh" runat="server" Style="display: none;">
                            <div class="grid_table width_common">
                                <div id="UPa_lke">
                                    <Cthuvien:GridX ID="Gr_cdanh" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                        CssClass="table gridX" loai="N" cot="so_the,ten,ten_phong,phong" cotAn="phong" hangKt="10" hamUp="ns_dt_kdt_cdanh_Update">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:TemplateField HeaderText="Mã nhân viên" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="so_the" runat="server" Width="100px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                        ktra="ns_cb,so_the,ten" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Tên Phòng" DataField="ten_phong" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Phòng" DataField="phong" ItemStyle-CssClass="css_Gma" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                            </div>
                            <div class="btex_luoi b_right">
                                <ul>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_kdt_cdanh_HangLen();" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_kdt_cdanh_HangXuong();" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_kdt_cdanh_CatDong();" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn thêm dòng" onclick="return ns_dt_kdt_cdanh_ChenDong('C');" />
                                    </li>
                                </ul>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="Pa_nhucau" runat="server" Style="display: none;">
                            <div class="grid_table width_common">
                                <div>
                                    <Cthuvien:GridX ID="Gr_nhucau" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                        CssClass="table gridX" loai="N" cot="so_the,ten,ten_phong,phong" cotAn="phong" hangKt="10" hamUp="ns_dt_kdt_cdanh_Update">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:TemplateField HeaderText="Mã nhân viên" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="so_the" runat="server" Width="100px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                        ktra="ns_cb,so_the,ten" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Tên Phòng" DataField="ten_phong" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Phòng" DataField="phong" ItemStyle-CssClass="css_Gma" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                            </div>
                            <div class="btex_luoi b_right">
                                <ul>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_kdt_ncau_HangLen();" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_kdt_ncau_HangXuong();" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_kdt_ncau_CatDong();" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn thêm dòng" onclick="return ns_dt_kdt_ncau_ChenDong('C');" />
                                    </li>
                                </ul>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_dt_kdt_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_dt_kdt_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_dt_kdt_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Width="70px" class="bt_action" anh="K" Text="Chọn" OnClick="return ns_dt_kdt_P_CHON();form_P_LOI();" />
                        <Cthuvien:nhap ID="chodk" runat="server" Width="100px" class="bt_action" anh="K" Text="Cho đăng ký" OnClick="return ns_dt_kdt_P_CHO_DK();form_P_LOI();" />
                        <Cthuvien:nhap ID="khoadk" runat="server" Width="110px" class="bt_action" anh="K" Text="Khóa đăng ký" OnClick="return ns_dt_kdt_P_KHOA_DK();form_P_LOI();" />
                        
                    </div>
                    <div id="UPa_gchu" class="css_border" align="left" style="margin-top: 70px;">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="trinh" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_dt_kdt_P_TRINH_PD();form_P_LOI();" />
                        <Cthuvien:so ID="tyle" ten="Tỷ lệ hưởng lương" runat="server" CssClass="css_form_r" Width="185px" kt_xoa="X" />
                        <Cthuvien:ma ID="nhomcn" ten="Nhóm chuyên ngành" runat="server" CssClass="css_form" kieu_chu="true"
                            BackColor="#f6f7f7" ktra="ns_ma_ncnganh,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_ncnganh.aspx"
                            onchange="ns_dt_kdt_P_KTRA('NHOMCN')" Width="185px" kt_xoa="X" placeholder="Nhấn F1" />
                        <Cthuvien:ma ID="chuyennganh" ten="Chuyên ngành" runat="server" CssClass="css_form" kieu_chu="true"
                            BackColor="#f6f7f7" ktra="ns_ma_cnganh,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_cnganh.aspx"
                            onchange="ns_dt_kdt_P_KTRA('CHUYENNGANH')" guiId="nhomcn" Width="185px" kt_xoa="X" placeholder="Nhấn F1" />
                        <Cthuvien:ma ID="quocgia" ten="Quốc gia" runat="server" CssClass="css_form" BackColor="#f6f7f7"
                            kieu_chu="true" ktra="ns_ma_nuoc,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_nuoc.aspx"
                            onchange="ns_dt_kdt_P_KTRA('quocgia')" Width="185px" kt_xoa="X" placeholder="Nhấn F1" />
                        <Cthuvien:ma ID="cap_dt" ten="Cấp đào tạo" runat="server" CssClass="css_form" BackColor="#f6f7f7"
                            kieu_chu="true" ktra="ns_ma_capdt,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_capdt.aspx"
                            onchange="ns_dt_kdt_P_KTRA('cap_dt')" Width="185px" kt_xoa="X" placeholder="Nhấn F1" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1330,710" />
        <Cthuvien:an ID="anloaidt" runat="server" Value="1330,710" />
    </div>
</asp:Content>
