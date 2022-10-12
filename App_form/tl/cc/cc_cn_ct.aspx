<%@ Page Title="cc_cn_ct" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="cc_cn_ct.aspx.cs" Inherits="f_cc_cn_ct" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<%@ Register Src="~/App_ctr/khud/vb_cctc.ascx" TagName="vb_cctc" TagPrefix="vb_cctc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div id="divLke" class="l_c_content b_left">
            <div class="b_nd_tab" id="UPa_dau">
                <div class="r_cc_tochuc">
                    <vb_cctc:vb_cctc ID="cctc" runat="server" />
                </div>
            </div>
        </div>
        <div class="doi_menu_luoi" id="div_center_icon">
            <span class="next_r" id="ico_mo" style="display: none" onclick="return ed_vb_khac_P_DLKE('M')"></span>
            <span class="back_l" id="ico_do" onclick="return ed_vb_khac_P_DLKE('D')"></span>
        </div>
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Xử lý dữ liệu chấm công" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_ct">
                   <div class="col_3_iterm width_common" style="margin-right: 2px;">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="PHONG" ktra="DT_PHONG_TK" ten="Phòng" runat="server" CssClass="form-control css_list" onchange="cc_cn_ct_P_KTRA('PHONG')">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" runat="server" CssClass="form-control css_ma" onchange="cc_cn_ct_P_KTRA('KYLUONG');">                                                                                
                                </Cthuvien:ma>
                            </div>

                        </div>
                    </div>
                    <div class="col_3_iterm width_common" style="margin-right: 2px;">
                        
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ktra="DT_NAM_TK" kt_xoa="K" ten="Năm" runat="server" CssClass="form-control css_list" onchange="cc_cn_ct_P_NAM();">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ công</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG" ktra="DT_KY" kt_xoa="G" ten="Kỳ công" runat="server" CssClass="form-control css_list" onchange="cc_cn_ct_P_KTRA('KYLUONG');">                                                                                
                                </Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Công chuẩn</span>
                            <div class="input-group" style="padding-right: 15px;">
                                <Cthuvien:so ID="ngaylam" runat="server" ten="Công chuẩn" CssClass="form-control css_so" kt_xoa="G"
                                    ReadOnly="true" Enabled="false" BackColor="#ffffff" ToolTip="Công chuẩn" />
                                <Cthuvien:gchu ID="nsd" runat="server" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common" style="margin-right: 2px;">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Từ ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYD" runat="server" CssClass="form-control icon_lich" kt_xoa="G"
                                    ten="Từ ngày" BackColor="#ffffff" Enabled="false" kieu_luu="S" ReadOnly="true" onblur="cc_cn_ct_P_KTRA('NGAYD');" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Đến ngày</span>
                            <div class="input-group"  >
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYKT" runat="server" CssClass="form-control icon_lich" kt_xoa="G"
                                    ten="Đến ngày" Enabled="false" BackColor="#ffffff" kieu_luu="S" ReadOnly="true" onblur="cc_cn_ct_P_KTRA('NGAYKT');" />
                            </div>
                        </div>
                       
                    </div>
                    <div class="grid_table width_common" style="margin-bottom: 3px;">
                        <div id="UPa_ngay" style="margin-right: 2px;">
                            <Cthuvien:GridX ID="GR_ngay" runat="server" AutoGenerateColumns="false" hamRow="cc_cn_ct_doimau()" PageSize="1"
                                CssClass="table gridX" loai="L" hangKt="2" Width="98.5%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Thứ/Ngày/Tháng" DataField="TT" HeaderStyle-Width="207px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n1" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n2" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n3" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n4" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n5" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n6" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n7" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n8" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n9" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n10" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n11" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n12" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n13" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n14" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n15" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n16" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n17" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n18" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n19" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n20" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n21" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n22" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n23" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n24" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n25" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n26" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n27" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n28" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n29" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n30" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="n31" ItemStyle-CssClass="css_Gma_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="grid_table width_common css_divb c_divC">
                        <div class="table gridX css_divCn">

                            <Cthuvien:GridX ID="GR_lke" hamUp="cc_cn_ct_Update" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" hangKt="15" Width="100%"
                                cot="so_the,ten,n1,n2,n3,n4,n5,n6,n7,n8,n9,n10,n11,n12,n13,n14,n15,n16,n17,n18,n19,n20,n21,n22,n23,n24,n25,n26,n27,n28,n29,n30,n31">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tên NV" DataField="ten" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gma" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n1" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n2" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n3" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n4" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n5" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n6" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n7" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n8" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n9" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n10" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n11" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n12" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n13" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n14" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n15" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n16" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n17" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n18" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n19" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n20" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n21" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n22" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n23" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n24" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n25" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n26" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n27" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n28" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n29" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n30" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="n31" runat="server" CssClass="css_Gma_c"  Width="100%"
                                                f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" ktra="ns_cc_ma_cc,ma,ten" ToolTip="Mã chấm công" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divC:ctr_khud_divC ID="GR_lke_slide" runat="server" gridId="GR_lke" loai="N" />

                        <%--ham="tl_phanca_P_LKE_KHOITAO()" --%>
                    </div>
                    <div class="col_4_iterm width_common mg_top" id="UPa_nhap">
                        <div class="b_left form-group iterm_form">
                            <Cthuvien:nhap ID="tdMo" runat="server" class="bt_action" anh="K" Text="Mặc định" Width="140px" OnClick="cc_ma_cc_P_MACDINH();form_P_LOI('');" Title="Nhập" />
                        </div>
                        <div class="b_left form-group iterm_form">
                            <div class="input-group">
                                <Cthuvien:ma ID="MA_MDINH" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                    Width="28px" f_tkhao="~/App_form/tl/ma/cc_ma_cc.aspx" gchu="gchu" ktra="ns_cc_ma_cc,ma,ten"
                                    ten="Mã chấm công mặc định" kt_xoa="K" onchange="cc_cn_ct_P_KTRA('MA_MDINH')" />
                                <Cthuvien:kieu ID="kieu" runat="server" CssClass="form-control css_ma" Width="28px" Text="T"
                                    lke="T,H" ToolTip="T-Tất cả hàng,H-Từng hàng" kt_xoa="true" BackColor="LightCyan"
                                    ForeColor="Blue" />
                                <span class="standard_label lv2 b_left col_25">Từ ngày</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="tu_ngay" runat="server" CssClass="form-control css_ma" kieu_so="true" Width="28px" gchu="gchu"
                                        ten="Ngày bắt đầu" kt_xoa="K" MaxLength="2" />
                                </div>
                                <span class="standard_label lv2 b_left col_25">Tới ngày</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="toi_ngay" runat="server" CssClass="form-control css_ma" kieu_so="true" Width="28px" gchu="gchu"
                                        ten="Ngày kết thúc" kt_xoa="K" MaxLength="2" />
                                </div>
                                <div style="display: none;">
                                    <Cthuvien:ma ID="tim" runat="server" CssClass="css_ma" BackColor="#f6f7f7"
                                        Width="120px" kt_xoa="K" />
                                    <Cthuvien:nhap ID="timkiem" runat="server" Text="tim" CssClass="css_button" OnClick="cc_cn_ct_P_TIMKIEM();form_P_LOI();"
                                        Width="70px" />
                                    <Cthuvien:nhap ID="btn_excel_mau" runat="server" Width="70px" Text="Xuất excel" OnServerClick="btn_excel_mau_Click" />
                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                                </div>
                            </div>

                        </div>
                        <div class="b_right form-group iterm_form">
                            <Cthuvien:nhap ID="In" runat="server" Text="Xuất excel" class="bt_action" anh="K" Width="90px" OnClick="cc_cn_ct_P_IN();form_P_LOI('');" Title="Xuất excel" />
                            <Cthuvien:nhap ID="excel" runat="server" Text="File mẫu" class="bt_action" anh="K" Width="80px" OnClick="cc_cn_ct_P_EXPORT();form_P_LOI('');" Title="File mẫu" />
                            <Cthuvien:nhap ID="file" runat="server" Text="Import" class="bt_action" anh="K" Width="80px" OnClick="cc_cn_ct_P_IMPORT();form_P_LOI('');" Title="Import" />
                        </div>
                        <div class="b_right form-group iterm_form">
                            <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" class="bt_action" anh="K" Width="80px" OnClick="cc_cn_ct_P_NH();form_P_LOI('');" Title="Nhập" />
                            <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" Width="80px" OnClick="cc_cn_ct_P_MOI();form_P_LOI('');" Title="Mới" />
                            <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" Width="80px" OnClick="cc_cn_ct_P_XOA();form_P_LOI('');" Title="Xóa" />

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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1400,700" />
        <Cthuvien:an ID="t7" runat="server" />
        <Cthuvien:an ID="cn" runat="server" />
        <Cthuvien:an ID="thumuc" runat="server" />
        <Cthuvien:an ID="aphong" runat="server" Value="1" />
        <Cthuvien:an ID="akyluong" runat="server" Value="" />
    </div>
</asp:Content>
