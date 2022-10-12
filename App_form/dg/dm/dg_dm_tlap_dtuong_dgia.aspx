<%@ Page Title="dg_dm_tlap_dtuong_dgia" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="dg_dm_tlap_dtuong_dgia.aspx.cs" Inherits="f_dg_dm_tlap_dtuong_dgia" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập đối tượng đánh giá" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label b_left col_20">Nhóm chức danh</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="n_chucdanh_tk" kt_xoa="G" CssClass="form-control css_list" ten="Yêu cầu tuyển dụng"
                                ktra="DT_NH_CHUCDANH_TK" runat="server" onchange="dg_dm_tlap_dtuong_dgia_P_NHOM_CDANH('N_CHUCDANH_TK')">                                                                                
                            </Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label b_left col_20">Chức danh</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="chucdanh_tk" CssClass="form-control css_list" ten="Mã yêu cầu TD" ktra="DT_CHUCDANH_TK" runat="server" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" class="bt_action" anh="K" Width="120px" OnClick="return dg_dm_tlap_dtuong_dgia_P_LKE();form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="L" hangKt="15" cotAn="so_id" hamRow="dg_dm_tlap_dtuong_dgia_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="50px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Kỳ ĐG" DataField="ky_dg"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Nhóm Chức danh" DataField="nhom_cdanh"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="200px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="dg_dm_tlap_dtuong_dgia_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" class="bt_action" anh="K" OnServerClick="nhap_Click" Width="120px" />
                    </div>
                </div>

                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Nhóm chức danh</span>
                            <div class="input-group">
                                <%-- <Cthuvien:DR_lke ID="nhom_cdanh" ten="Nhóm chức danh" runat="server" ktra="DT_NHOM_CDANH" kieu_chu="true"
                                    CssClass="form-control css_list" Width="220px" kt_xoa="G" onchange="dg_dm_tlap_dtuong_dgia_P_NHOM_CDANH('NHOM_CDANH')" />--%>
                                <Cthuvien:DR_lke ID="nhom_cdanh" kt_xoa="G" CssClass="form-control css_list" ten="Nhóm chức danh" kieu_chu="true"
                                    ktra="DT_NH_CHUCDANH_TK" runat="server">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chức danh <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="CDANH" ten="Chức danh" runat="server" ktra="DT_CDANH" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Nhóm nội dung" runat="server" ktra="DT_NAM" kieu_chu="true" CssClass="form-control css_list"
                                    kt_xoa="G" onchange="dg_dm_tlap_dtuong_dgia_P_KTRA('NAM');" kieu="S" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ky_dg" kt_xoa="X" ten="Yêu cầu tuyển dụng" ktra="DT_KY_DG" runat="server"
                                    CssClass="form-control css_list">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>

                    <div class="width_common pv_bl"><span>Đối tượng tham gia đánh giá</span></div>
                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label lv2 b_left col_50">CBQL cấp trên trực tiếp</span>
                        <div class="width_common line_55">
                            <div class="b_left col_50">
                                <div class="grid_table width_common">
                                    <div>
                                        <Cthuvien:GridX ID="GR_ct_qlct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="N" cot="so_the_ct,ten_ct" Width="100%"
                                            cotAn="" hangKt="6">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Mã nhân viên" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="SO_THE_CT" runat="server" CssClass="css_Gma" kt_xoa="X"
                                                            f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" Width="100%" placeholder="Nhấn (F1)" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Họ tên" DataField="ten_ct" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gma" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </div>
                                </div>
                            </div>
                            <div class="b_left col_45" style="margin-left: 20px;">
                                <div class="grid_table width_common">
                                    <div>
                                        <Cthuvien:GridX ID="GR_ct_cdanh_qlct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="N" cot="ma_cd_ct,ten_cd_ct" Width="100%"
                                            cotAn="" hangKt="6">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Mã chức danh" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="MA_CD_CT" runat="server" CssClass="css_Gma" kt_xoa="X"
                                                             f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_ma_vtcdanh.aspx" ktra="ns_ma_cdanh,ma,ten" Width="100%" placeholder="Nhấn (F1)" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tên chức danh">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="ten_cd_ct" Enabled="false" runat="server" Width="100%" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label lv2 b_left col_50">CB cấp dưới trực tiếp</span>
                        <div class="width_common line_55">
                            <div class="b_deft col_50">
                                <div class="grid_table width_common">
                                    <div>
                                        <Cthuvien:GridX ID="Gr_ct_qlcd" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="N" cot="so_the_cd,ten_cd" Width="100%"
                                            cotAn="" hangKt="6">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Mã nhân viên" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="SO_THE_CD" runat="server" CssClass="css_Gma" kt_xoa="X"
                                                            f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" Width="100%" placeholder="Nhấn (F1)" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Họ tên" DataField="ten_cd" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gma" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </div>
                                </div>
                            </div>
                            <div class="b_left col_45" style="margin-left: 20px;">
                                <div class="grid_table width_common">
                                    <div>
                                        <Cthuvien:GridX ID="Gr_ct_cdanh_qlcd" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="N" cot="ma_cd_cd,ten_cd_cd" Width="100%"
                                            cotAn="" hangKt="6">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Mã chức danh" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="MA_CD_CD" runat="server" CssClass="css_Gma" kt_xoa="X"
                                                             f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_ma_vtcdanh.aspx" ktra="ns_ma_cdanh,ma,ten" Width="100%" placeholder="Nhấn (F1)" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tên chức danh">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="ten_cd_cd" Enabled="false" runat="server" Width="100%" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label lv2 b_left col_50">CBQL ngang cấp</span>
                        <div class="width_common line_55">
                            <div class="b_left col_50">
                                <div class="grid_table width_common">
                                    <div>
                                        <Cthuvien:GridX ID="Gr_ct_qlnc" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="N" cot="so_the_nc,ten_nc" Width="100%"
                                            cotAn="" hangKt="6">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Mã nhân viên" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="SO_THE_NC" runat="server" CssClass="css_Gma" kt_xoa="X"
                                                            f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" Width="100%" placeholder="Nhấn (F1)" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Họ tên" DataField="ten_nc" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gma" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </div>
                                </div>
                            </div>
                            <div class="b_left col_45" style="margin-left: 20px;">
                                <div class="grid_table width_common">
                                    <div>
                                        <Cthuvien:GridX ID="Gr_ct_cdanh_qlnc" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="N" cot="ma_cd_nc,ten_cd_nc" Width="100%"
                                            cotAn="" hangKt="6">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Mã chức danh" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="MA_CD_NC" runat="server" CssClass="css_Gma" kt_xoa="X"
                                                            f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_ma_vtcdanh.aspx" ktra="ns_ma_cdanh,ma,ten"
                                                            Width="100%" placeholder="Nhấn (F1)" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tên chức danh">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="ten_cd_nc" Enabled="false" runat="server" Width="100%" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tao" runat="server" Text="Làm mới" Width="100px" class="bt_action" anh="K" OnClick="return dg_dm_tlap_dtuong_dgia_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="ghi" runat="server" Width="100px" Text="Nhập" class="bt_action" anh="K" OnClick="return dg_dm_tlap_dtuong_dgia_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="delete" runat="server" Width="100px" Text="Xóa" class="bt_action" anh="K" OnClick="return dg_dm_tlap_dtuong_dgia_P_XOA();form_P_LOI();" />
                    </div>
                </div>

                <%-- <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_15">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ghichu" ten="Ghi chú" runat="server" Height="50px" TextMode="MultiLine" CssClass="form-control css_nd" kieu_unicode="True"
                                kt_xoa="X" MaxLength="1000" />
                        </div>
                    </div>--%>
                <div id="UPa_gchu">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1368,830" />
        <Cthuvien:an ID="Anncdanh" runat="server" />
        <Cthuvien:an ID="Ancdanh" runat="server" />
    </div>
</asp:Content>
