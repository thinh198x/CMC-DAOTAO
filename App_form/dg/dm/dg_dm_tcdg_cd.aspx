<%@ Page Title="dg_dm_tcdg_cd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="dg_dm_tcdg_cd.aspx.cs" Inherits="f_dg_dm_tcdg_cd" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập tiêu chí đánh giá theo chức danh" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="nam,ky_dg,so_id" hamRow="dg_dm_tcdg_cd_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kỳ đánh giá" DataField="ky_dg" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Nhóm chức danh" DataField="nhom_cdanh" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="cdanh" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày áp dụng" DataField="ngay_ad" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="dg_dm_tcdg_cd_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" class="bt_action" runat="server" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common" style="display: none">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nam" ten="Năm" runat="server" ktra="DT_NAM" CssClass="form-control css_list"
                                    onchange="dg_dm_tcdg_cd_P_NAM();" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ky_dg" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG" CssClass="form-control css_list"
                                    onchange="dg_dm_tcdg_cd_P_KTRA('KY_DG');" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Nhóm chức danh<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NCD" ten="Nhóm chức danh" runat="server" ktra="DT_NCD" onchange="ns_cdanh_P_LIST()"
                                    CssClass="form-control css_list" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Chức danh<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="CD" ten="Chức danh" runat="server" CssClass="form-control css_list" ktra="DT_CD" onchange="dg_dm_tcdg_cd_P_KTRA('NCD');" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày áp dụng<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_AD" runat="server" ten="Ngày áp dụng" CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cotAn="so_idct,titrong" hangKt="15" gchuId="gchu" Width="100%"
                                cot="nhom_tc,trongso_ntc,tieuchi,mota,trongso_tc,donvitinh,khongdat,cancaitien,dat,tot,xuatsac,titrong,so_idct">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Nhóm tiêu chí*" HeaderStyle-Width="17%">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="NHOM_TC" ktra="DT_NTC" runat="server" CssClass="css_Glist" Width="100%" ten="Nhóm tiêu chí"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Trọng số của nhóm tiêu chí*" HeaderStyle-Width="7%">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="TRONGSO_NTC" runat="server" CssClass="css_Gma" kieu_so="true" onkeyup="checknumber('NTC')" Width="100%"></Cthuvien:ma>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tiêu chí*" HeaderStyle-Width="17%">
                                        <ItemTemplate>
                                            <Cthuvien:DR_lke ID="TIEUCHI" ktra="tieuchi_P_LIST()" Width="100%" runat="server" CssClass="css_Glist" ten="Nhóm tiêu chí"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mô tả" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="mota" runat="server" CssClass="css_Gma" ten="Mô tả" kieu_unicode="true" Width="100%" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Trọng số của tiêu chí*" HeaderStyle-Width="7%">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="TRONGSO_TC" runat="server" CssClass="css_Gma" kieu_so="true" onkeyup="checknumber('TC')" Width="100%" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Đơn vị tính">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="donvitinh" runat="server" CssClass="css_Gma" ten="Đơn vị tính" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Không đạt">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="khongdat" runat="server" CssClass="css_Gma" ten="Mô tả" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cần cải tiến">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cancaitien" runat="server" CssClass="css_Gma" ten="Cần cải tiến" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Đạt">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="dat" runat="server" CssClass="css_Gma" Width="60px" ten="Đạt" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tốt">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="tot" runat="server" CssClass="css_Gma" ten="Tốt" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Xuất sắc">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="xuatsac" runat="server" CssClass="css_Gma" ten="Xuất sắc" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỉ trọng">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="titrong" runat="server" CssClass="css_Gma" ten="Tỉ trọng" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số id chi tiết">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="so_idct" runat="server" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Text="Làm mới" OnClick="return dg_dm_tcdg_cd_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Text="Ghi" OnClick="return dg_dm_tcdg_cd_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Text="Xóa" OnClick="return dg_dm_tcdg_cd_P_XOA();form_P_LOI();" />
                    </div>

                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1370,700" />
        <Cthuvien:an ID="Anncdanh" runat="server" />
        <Cthuvien:an ID="Ancdanh" runat="server" />
    </div>
</asp:Content>
