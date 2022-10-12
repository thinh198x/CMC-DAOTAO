<%@ Page Title="ns_dt_tt_nghan" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_tt_nghan.aspx.cs" Inherits="f_ns_dt_tt_nghan" %>


<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Chứng chỉ đào tạo" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="20" cotAn="so_id,tthai" hamRow="ns_dt_tt_nghan_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Loại chứng chỉ" DataField="ten_loai_cc" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_tthai" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="so_id" />
                                    <asp:BoundField DataField="tthai" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" gridId="GR_lke" ham="ns_dt_tt_nghan_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ReadOnly="true" ID="so_the" ten="Mã cán bộ" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ktra="ns_cb,so_the,ten" ToolTip="Mã số cán bộ" Enabled="false"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" kt_xoa="K" />
                                <%--onchange="ns_ths_P_KTRA('SO_THE')"--%>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ReadOnly="true" ID="ten" ten="Họ tên" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ToolTip="Họ tên" kt_xoa="K" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span></span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Loại Chứng chỉ</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="LOAI_CC" onchange="checkanhien()" CssClass="form-control css_list" kt_xoa="X"
                                    ten="Loại chứng chỉ" runat="server" kieu="S" tra="CCHN,CCC,CCK" lke="Chứng chỉ hành nghề,Chứng chỉ con,Chứng chỉ khác" />
                            </div>
                        </div>
                    </div>

                    <div id="an_chungchi_khac">
                        <div class="b_left width_common form-group iterm_form">
                            <span class="standard_label b_left col_20">Tên chứng chỉ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cchi" ten="Chứng chỉ" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    kieu_unicode="true" gchu="gchu" ToolTip="Tên chứng chỉ" MaxLength="255" />
                            </div>
                        </div>
                        <div class="b_left width_common form-group iterm_form">
                            <span class="standard_label b_left col_20">Nội dung <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="noidung" ten="Nội dung" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    kieu_unicode="true" gchu="gchu" ToolTip="Nội dung" MaxLength="1000" />
                            </div>
                        </div>
                        <div class="col_2_iterm width_common">
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_40">Số hiệu</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="sohieu" ten="Số hiệu chứng chỉ" runat="server" CssClass="form-control css_ma"
                                        kieu_chu="true" gchu="gchu" ToolTip="Số hiệu chứng chỉ" kt_xoa="X" MaxLength="255" />
                                </div>
                            </div>
                            <div class="b_right form-group iterm_form">
                                <span class="standard_label lv2 b_left col_40">Cơ sở đào tạo</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="cs_dtao" ToolTip="Cơ sở đào tạo" runat="server" kieu_unicode="true" CssClass="form-control css_ma" kt_xoa="X" MaxLength="255" />
                                </div>
                            </div>
                        </div>
                        <div class="col_2_iterm width_common">
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_40">Từ ngày</span>
                                <div class="input-group">
                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="tu_ngay" runat="server" CssClass="form-control icon_lich" kt_xoa="X"
                                        ten="Từ ngày" ToolTip="Từ ngày" />
                                </div>
                            </div>
                            <div class="b_right form-group iterm_form">
                                <span class="standard_label lv2 b_left col_40">Đến ngày</span>
                                <div class="input-group">
                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="den_ngay" runat="server" CssClass="form-control icon_lich" kt_xoa="X" ten="Tới ngày"
                                        ToolTip="Đến ngày" />
                                </div>
                            </div>
                        </div>
                        <div class="col_2_iterm width_common">
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_40">Ngày hiệu lực CC</span>
                                <div class="input-group">
                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_hl" runat="server" CssClass="form-control icon_lich" kt_xoa="X"
                                        ten="Ngày hiệu lực" ToolTip="Ngày hiệu lực" />
                                </div>
                            </div>
                            <div class="b_right form-group iterm_form">
                                <span class="standard_label lv2 b_left col_40">Ngày hết hiệu lực CC</span>
                                <div class="input-group">
                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_hhl" runat="server" CssClass="form-control icon_lich" kt_xoa="X" ten="Tới ngày"
                                        ToolTip="Ngày hết hiệu lực" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="an_chungchi_hanhnghe">
                        <div class="grid_table width_common">
                            <div style="height: 300px; overflow: scroll;">
                                <Cthuvien:GridX ID="GR_CCHN" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                    CssClass="table gridX" loai="N" cot="ma_cchn,so_cchn,ngay_cap,thang_cap,vung,ubck,qtrr" cotAn="" hangKt="15">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Tên chứng chỉ hành nghề" HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <Cthuvien:DR_lke ID="ma_cchn" ktra="DT_CCHN" runat="server" CssClass="css_Glist" Width="100%" kt_xoa="X"> 
                                                </Cthuvien:DR_lke>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Số chứng chỉ" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="so_cchn" runat="server" CssClass="css_Gma_r" Width="100%" kt_xoa="X">

                                                </Cthuvien:ma>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ngày cấp chứng chỉ" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <Cthuvien:ngay ID="ngay_cap" runat="server" CssClass="css_Gma_c" MaxLength="10"
                                                    kieu_chu="true" kt_xoa="X" Width="100%" placeholder="dd/MM/yyyy" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tháng phát sinh" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <Cthuvien:thang ID="thang_cap" runat="server" CssClass="css_Gma_r" Width="100%" kt_xoa="X"
                                                    placeholder="MM/yyyy" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Vùng miền" HeaderStyle-Width="130px">
                                            <ItemTemplate>
                                                <Cthuvien:DR_lke ID="vung" ktra="DT_VUNG" runat="server" CssClass="css_Glist" Width="100%" kt_xoa="X">

                                                </Cthuvien:DR_lke>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Đối tượng UBCK" HeaderStyle-Width="170px">
                                            <ItemTemplate>
                                                <Cthuvien:DR_lke ID="ubck" ktra="DT_UBCK" runat="server" CssClass="css_Glist" Width="100%" kt_xoa="X">

                                                </Cthuvien:DR_lke>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Đối tượng QTRR" HeaderStyle-Width="170px">
                                            <ItemTemplate>
                                                <Cthuvien:DR_lke ID="QTRR" ktra="DT_QTRR" runat="server" CssClass="css_Glist" Width="100%" kt_xoa="X">

                                                </Cthuvien:DR_lke>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <div class="btex_luoi b_right">
                                <ul>
                                    <li>
                                        <img alt="" src="/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_tl_htro_antrua_phong_HangLen();" />
                                    </li>
                                    <li>
                                        <img alt="" src="/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_tl_htro_antrua_phong_HangXuong();" />
                                    </li>
                                    <li>
                                        <img alt="" src="/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_tl_htro_antrua_phong_CatDong();" />
                                    </li>
                                    <li>
                                        <img alt="" src="/images/eDoc/chen.png" title="Thêm 1 dòng mới" onclick="return ns_tl_htro_antrua_phong_ChenDong('C');" />
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div id="an_chungchi_con">
                        <div class="grid_table width_common">
                            <div style="height: 300px; overflow: scroll;">
                                <Cthuvien:GridX ID="GR_CCC" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                    CssClass="table gridX" loai="N"
                                    cot="ma_ccc,ccc_ngay_hl,ccc_ngayhet_hl,cam_ket,tien_camket,thang_camket,mota" cotAn="" hangKt="15">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Tên chứng chỉ con" HeaderStyle-Width="200px">
                                            <ItemTemplate>
                                                <Cthuvien:DR_lke ID="MA_CCC" ktra="DT_CCC" runat="server" CssClass="css_Glist" Width="100%" kt_xoa="X">
                                                </Cthuvien:DR_lke>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ngày hiệu lực" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <Cthuvien:ngay ID="ccc_ngay_hl" runat="server" CssClass="css_Gma_c" Width="100%" kt_xoa="X"
                                                    placeholder="dd/MM/yyyy">

                                                </Cthuvien:ngay>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ngày hết hiệu lực" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <Cthuvien:ngay ID="ccc_ngayhet_hl" runat="server" CssClass="css_Gma_c" Width="100%" kt_xoa="X"
                                                    placeholder="dd/MM/yyyy">

                                                </Cthuvien:ngay>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cam kết đào tạo" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <Cthuvien:kieu runat="server" ID="cam_ket" CssClass="css_Gma_c" Width="100%" lke=" ,X" Text=" " kt_xoa="X">

                                                </Cthuvien:kieu>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Số tiền cam kết" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <Cthuvien:so runat="server" ID="tien_camket" CssClass="css_Gso" Width="100%" so_tp="2" kt_xoa="X">
                                                </Cthuvien:so>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Thời gian cam kết (Tháng)" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <Cthuvien:so runat="server" ID="thang_camket" CssClass="css_Gso" Width="100%" so_tp="0" kt_xoa="X">
                                                </Cthuvien:so>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mô tả" HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <Cthuvien:ma runat="server" ID="mota" CssClass="css_Gma" Width="100%" kt_xoa="X">
                                                </Cthuvien:ma>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <div class="btex_luoi b_right">
                                <ul>
                                    <li>
                                        <img alt="" src="/images/eDoc/len.png" title="Chuyển dòng lên"
                                            onclick="return ns_tl_htro_antrua_phong_HangLen();" />
                                    </li>
                                    <li>
                                        <img alt="" src="/images/eDoc/xuong.png" title="Chuyển dòng xuống"
                                            onclick="return ns_tl_htro_antrua_phong_HangXuong();" />
                                    </li>
                                    <li>
                                        <img alt="" src="/images/eDoc/cat.png" title="Cắt các dòng đã chọn"
                                            onclick="return ns_tl_htro_antrua_phong_CatDong();" />
                                    </li>
                                    <li>
                                        <img alt="" src="/images/eDoc/chen.png" title="Thêm 1 dòng mới"
                                            onclick="return ns_tl_htro_antrua_phong_ChenDong('C');" />
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>

                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="MOI" class="bt_action" anh="K" runat="server" Text="Làm mới" CssClass="css_button" OnClick="return ns_dt_tt_nghan_P_MOI();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="NHAP" class="bt_action" anh="K" runat="server" Text="Ghi" CssClass="css_button" OnClick="return ns_dt_tt_nghan_P_NH();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="GUI" class="bt_action" anh="K" runat="server" Width="120px" Text="Gửi phê duyệt" OnClick="return ns_dt_tt_nghan_P_GUI();form_P_LOI();" />
                        <Cthuvien:nhap ID="XOA" class="bt_action" anh="K" runat="server" Text="Xóa" CssClass="css_button" onclick="return ns_dt_tt_nghan_P_XOA();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="file" class="bt_action" anh="K" runat="server" Text="File" CssClass="css_button" OnClick="return ns_dt_tt_nghan_FI_NH();" Width="70px" />

                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="so_id" runat="server" Value="" />
    <Cthuvien:an ID="so_the_an" runat="server" Value="" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1200,550" />
</asp:Content>
