<%@ Page Title="ns_dt_ma_dtac" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_ma_dtac.aspx.cs" Inherits="f_ns_dt_ma_dtac" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục đối tác đào tạo" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div class="css_divb">
                            <div>
                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                    CssClass="table gridX" loai="X" hangKt="15" cotAn="" hamRow="ns_dt_ma_dtac_GR_lke_RowChange()">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField HeaderText="Mã đối tác" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Tên đối tác" DataField="ten" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Lĩnh vực đào tạo" DataField="lvuc_dtao" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Điện thoại" DataField="dthoai" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_ma_dtac_P_LKE()" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_dt_ma_dtac_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="width_common pv_bl"><span>Thông tin chung</span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Mã đối tác đào tạo <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" ten="Mã đối tác đào tạo" ToolTip="Mã đối tác đào tạo" runat="server" CssClass="form-control css_ma" kt_xoa="G" kieu_unicode="false" MaxLength="20" onchange="ns_dt_ma_dtac_P_KTRA('MA')" kieu_chu="True" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Tên đối tác đào tạo <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Tên đối tác đào tạo" kieu_unicode="true" runat="server" CssClass="form-control css_ma" kt_xoa="X" ToolTip="Tên đối tác đào tạo" MaxLength="255" />
                            </div>
                        </div>
                    </div>
                    <div style="display: none;">
                        <div class="css_divb" style="margin-right: 20px;">
                            <div class="css_divCn">
                                <Cthuvien:GridX ID="GR_lvcha" runat="server" AutoGenerateColumns="false" PageSize="1"
                                    CssClass="table gridX" loai="N" cot="MA_LVCHA,TEN_LVCHA" cotAn="" hangKt="4">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Mã lĩnh vực đào tạo" HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="MA_LVCHA" runat="server" Width="151px" CssClass="css_Gma" f_tkhao="~/App_form/ns/dt/dm/ns_dt_lvdt.aspx" kieu_chu="false" ReadOnly="true" ToolTip="Mã lĩnh vực đào tạo" MaxLength="20" placeholder="Nhấn (F1)" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Tên lĩnh vực đào tạo" DataField="TEN_LVCHA" HeaderStyle-Width="244px" ItemStyle-CssClass="css_Gnd" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divC:ctr_khud_divC ID="Ctr_khud_divc1" runat="server" gridId="GR_lvcha" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Lĩnh vực đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="lv_dtao" ten="Lĩnh vực đào tạo" kieu_unicode="true" ToolTip="Lĩnh vực đào tạo" MaxLength="50" runat="server" CssClass="form-control css_ma" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left lv2 col_50">Điện thoại</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="dthoai" ten="Số điện thoại đối tác" kieu_so="true" ToolTip="Số điệnt thoại đối tác" MaxLength="50" runat="server" CssClass="form-control css_ma_r" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Website</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="website" runat="server" CssClass="form-control css_ma" kt_xoa="X" ten="website" ToolTip="Website" MaxLength="255" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Fax</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="fax" runat="server" CssClass="form-control css_ma" kt_xoa="X" ten="fax" MaxLength="50" ToolTip="Số fax" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Mã số thuế</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="msthue" ten="Mã số thuế" runat="server" CssClass="form-control css_ma" kt_xoa="X" MaxLength="30" ToolTip="Mã số thuế" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Số GP hoạt động KD</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_gp" ten="Số giấy phép hoạt động kinh doanh" MaxLength="50" ToolTip="Số giấy phép hoạt động kinh doanh" runat="server" CssClass="form-control css_ma" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_25">Địa chỉ</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="dchi" ten="Địa chỉ" runat="server" kieu_unicode="true" CssClass="form-control css_ma" kt_xoa="X" ToolTip="Địa chỉ" MaxLength="500" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_25">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd Height="50px" ID="mota" runat="server" CssClass="form-control css_ma" kt_xoa="X" ten="mô tả" ToolTip="Mô tả" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Thông tin người liên hệ</span></div>
                    <div class="grid_table width_common">
                        <div class="">
                            <div>
                                <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" Width="100%" PageSize="1" CssClass="table gridX" loai="N" cot="hten,cdanh,sdt,email" cotAn="" hangKt="5">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Họ tên" HeaderStyle-Width="130px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="hten" runat="server" kieu_chu="False" CssClass="css_Gma" kt_xoa="X" Width="130px" ToolTip="Họ tên" MaxLength="255" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Chức danh" HeaderStyle-Width="110px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="cdanh" runat="server" kieu_chu="False" CssClass="css_Gma" kt_xoa="X" Width="110px" ToolTip="Chức danh" MaxLength="50" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Số điện thoại" HeaderStyle-Width="112px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="sdt" runat="server" kieu_so="true" Width="100%" CssClass="css_Gma" kieu_chu="False" kieu_unicode="false" kt_xoa="X" ToolTip="Số điện thoại" MaxLength="50" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email" HeaderStyle-Width="143px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="email" runat="server" Width="100%" CssClass="css_Gma" kieu_chu="False" kt_xoa="X" kieu_unicode="false" ToolTip="Email" MaxLength="100" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </Cthuvien:GridX>
                            <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divc2" runat="server" gridId="GR_ct" />

                            </div>
                            <div class="btex_luoi b_right">
                                <ul>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_ma_dtac_HangLen(1);" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_ma_dtac_HangXuong(1);" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_ma_dtac_CatDong(1);" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return ns_dt_ma_dtac_ChenDong('C');" />
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Thông tin giảng viên đào tạo</span></div>
                    <div class="grid_table width_common">
                        <div class="css_divb" style="margin-right: 20px;">
                            <div class="css_divCn">
                                <Cthuvien:GridX ID="Grid_gv" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                    CssClass="table gridX" loai="N" cot="ma_gv,hoten,nsinh,lvuc,knghiem,mota" cotAn="" hangKt="5">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Mã giảng viên" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="ma_gv" runat="server" kieu_chu="False" CssClass="css_Gma" kt_xoa="X" Width="130px" ToolTip="Họ tên" MaxLength="255" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tên giảng viên" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="hoten" runat="server" kieu_chu="False" CssClass="css_Gma" kt_xoa="X" Width="130px" ToolTip="Họ tên" MaxLength="255" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ngày sinh" HeaderStyle-Width="90px">
                                            <ItemTemplate>
                                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="nsinh" runat="server" kieu_chu="False" CssClass="css_Gma_c" kt_xoa="X" Width="90px" ToolTip="Chức danh" MaxLength="50" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Lĩnh vực" HeaderStyle-Width="90px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="lvuc" runat="server" Width="100%" CssClass="css_Gma" kieu_chu="False" kieu_unicode="false" kt_xoa="X" ToolTip="Số điện thoại" MaxLength="50" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Kinh nghiệm" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="knghiem" runat="server" Width="100%" CssClass="css_Gma" kieu_chu="False" kt_xoa="X" kieu_unicode="false" ToolTip="Email" MaxLength="100" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mô tả" HeaderStyle-Width="110px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="mota" runat="server" Width="100%" CssClass="css_Gma" kt_xoa="X" kieu_unicode="false" ToolTip="Mota" MaxLength="2000" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <div class="btex_luoi b_right">
                                <ul>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_ma_dtac_HangLen(2);" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_ma_dtac_HangXuong(2);" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_ma_dtac_CatDong(2);" />
                                    </li>
                                </ul>
                            </div>
                        </div>

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_dt_ma_dtac_P_MOI();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_dt_ma_dtac_P_NH();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" class="bt_action" anh="K" OnClick="form_P_TRA_CHON('MA,TEN');form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" onclick="return ns_dt_ma_dtac_P_XOA();form_P_LOI();" Width="100px" />
                        <div style="display: none">
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
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,770" />
    </div>
</asp:Content>
