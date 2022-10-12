<%@ Page Title="ns_cb_ql" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cb_ql.aspx.cs" Inherits="f_ns_cb_ql" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_ttt.ascx" TagName="khud_ttt" TagPrefix="khud_ttt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container_content">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Xem thông tin CBNV thuộc quyền quản lý" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner tabdoc_left">
                    <div class="tab_doc pdl10">
                        <div id="DPu" runat="server">
                            <Cthuvien:tab ID="DPu_tk" runat="server" CssClass="css_tab_doc_ac" Text="Tìm kiếm" />
                            <Cthuvien:tab ID="DPu_ttk" runat="server" CssClass="css_tab_doc_de" Text="Thông tin khác" />
                        </div>
                    </div>

                    <asp:Panel ID="Pu_tk" runat="server" Style="display: block;">
                        <div id="UPa_tk" class="non_tabdoc inner">
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_30">Trạng thái</span>
                                <div class="input-group">
                                    <Cthuvien:DR_list ID="trangthai_tk" onchange="ns_cb_P_KTRA('PHONG_TK')" CssClass="form-control css_list" ten="Trạng thái" runat="server" kieu="S" Width="210px" tra="0,1" lke="Làm việc,Nghỉ việc" />
                                </div>
                            </div>
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_30">Phòng</span>
                                <div class="input-group">
                                    <Cthuvien:DR_lke ID="phong_tk" ten="Phòng" runat="server" kieu="S" CssClass="form-control css_list" Width="210px" ktra="DT_PH" />
                                </div>
                            </div>
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_30">Mã nhân viên</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="so_the_tk" ten="Mã CB tìm kiếm" runat="server" CssClass="form-control css_ma" kt_xoa="K" kieu_chu="true" Width="210px" />
                                </div>
                            </div>
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_30">Họ và tên</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="ten_tk" ten="Tên tìm kiếm" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="true" Width="210px" />
                                </div>
                            </div>
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_30"></span>
                                <div class="list_bt_action">
                                    <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" Width="100px" class="bt_action" anh="K" OnClick="return ns_cb_P_LKE();form_P_LOI();" />
                                </div>
                            </div>
                            <div class="grid_table width_common">
                                <div style="overflow-x: scroll">
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                        CssClass="table gridX" loai="X" hangKt="13" cotAn="so_id,iurl" hamRow="ns_cb_GR_lke_RowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Họ và tên" DataField="ten" HeaderStyle-Width="179px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="179px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Đơn vị" DataField="ten_phong" HeaderStyle-Width="179px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Trạng thái NV" DataField="ten_ttr" HeaderStyle-Width="179px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Ngày vào công ty" DataField="ngayd" HeaderStyle-Width="179px" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField HeaderText="Số id" DataField="so_id" />
                                            <asp:BoundField HeaderText="anh the" DataField="iurl" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" rong="280" loai="X" gridId="GR_lke" ham="ns_cb_P_LKE()" />
                            </div>
                            <div class="list_bt_action">
                                <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" hoi="3" Width="100px" OnClick="return ns_cb_P_EXCEL();form_P_LOI();" />
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Pu_ttk" runat="server" Style="display: none;">
                        <div class="non_tabdoc inner">
                            <div class="sublist_gr">
                                <ul class="tabContent-list">
                                    <li>Thông tin</li>
                                    <ul class="tabContent-list2">
                                        <li><a id="ns_lsct" href="#" onclick="ns_cb_P_ACTIVEMENU('ns_lsct')">
                                            <Cthuvien:roi ID="Ls_lsct" runat="server" Width="365px"
                                                f_tkhao="~/App_form/ns/ls/ns_lsct.aspx" gui="SO_THE,TEN,PHONG" dong="true" Text="Quá trình công tác trước khi vào công ty" /></a></li>
                                        <li><a id="ns_ls_luong" href="#" onclick="ns_cb_P_ACTIVEMENU('ns_ls_luong')">
                                            <Cthuvien:roi ID="Roi5" runat="server" Width="365px"
                                                f_tkhao="~/App_form/ns/ls/ns_ls_qtct.aspx" gui="SO_THE,TEN,PHONG,TEN_PHONG" dong="true" Text="Quá trình công tác trong công ty" /></a></li>
                                        <li><a id="ns_ls_ct_tct" href="#" onclick="ns_cb_P_ACTIVEMENU('ns_ls_ct_tct')">
                                            <Cthuvien:roi ID="Ls_tct" runat="server" Width="365px"
                                                f_tkhao="~/App_form/ns/ls/ns_ls_luong.aspx" gui="SO_THE,TEN,PHONG,TEN_PHONG" dong="true" Text="Quá trình lương trong công ty" /></a></li>
                                        <li><a id="ns_lsld" href="#" onclick="ns_cb_P_ACTIVEMENU('ns_lsld')">
                                            <Cthuvien:roi ID="Roi1" runat="server" Width="365px"
                                                f_tkhao="~/App_form/ns/ls/ns_ls_hd_ld.aspx" gui="SO_THE,TEN,PHONG" dong="true" Text="Quá trình hợp đồng lao động" /></a></li>
                                        <li style="display: none"><a id="ns_hd" href="#" onclick="ns_cb_P_ACTIVEMENU('ns_hd')">
                                            <Cthuvien:roi ID="Lb_hd" runat="server" Width="365px"
                                                f_tkhao="~/App_form/ns/qt/ns_hd.aspx" gui="SO_THE,TEN,PHONG" dong="true" Text="Quá trình ký hợp đồng lao động" /></a></li>
                                        <li><a id="ns_lskt" href="#" onclick="ns_cb_P_ACTIVEMENU('ns_lskt')">
                                            <Cthuvien:roi ID="Roi3" runat="server" Width="365px"
                                                f_tkhao="~/App_form/ns/ls/ns_ls_kt.aspx" gui="SO_THE,TEN,PHONG" dong="true" Text="Quá trình khen thưởng" /></a></li>
                                        <li><a id="ns_lskl" href="#" onclick="ns_cb_P_ACTIVEMENU('ns_lskl')">
                                            <Cthuvien:roi ID="Roi4" runat="server" Width="365px"
                                                f_tkhao="~/App_form/ns/ls/ns_ls_kl.aspx" gui="SO_THE,TEN,PHONG" dong="true" Text="Quá trình kỷ luật" /></a></li>
                                        <li><a id="ns_lsdt" href="#" onclick="ns_cb_P_ACTIVEMENU('ns_lsdt')">
                                            <Cthuvien:roi ID="Roi2" runat="server" Width="365px"
                                                f_tkhao="~/App_form/ns/ls/ns_ls_dt.aspx" gui="SO_THE,TEN,PHONG" dong="true" Text="Quá trình đào tạo trong công ty" /></a></li>
                                        <li><a id="ns_qt_hoctap" href="#" onclick="ns_cb_P_ACTIVEMENU('ns_qt_hoctap')">
                                            <Cthuvien:roi ID="Qt_hoctap" runat="server" Width="365px"
                                                f_tkhao="~/App_form/ns/tt/ns_dt_hoctap.aspx" gui="SO_THE,TEN,PHONG" dong="true" Text="Quá trình học tập" /></a></li>
                                        <li style="display: none"><a id="ns_cp" href="#" onclick="ns_cb_P_ACTIVEMENU('ns_cp')">
                                            <Cthuvien:roi ID="Lb_cp" runat="server" Width="365px"
                                                f_tkhao="~/App_form/ns/qt/ns_cp.aspx" gui="SO_THE,TEN,PHONG" dong="true" Text="Chuyển phòng" /></a></li>
                                        <li style="display: none"><a id="ns_hdct" href="#" onclick="ns_cb_P_ACTIVEMENU('ns_hdct')">
                                            <Cthuvien:roi ID="Lb_qtlv" runat="server" Width="365px"
                                                f_tkhao="~/App_form/ns/qt/ns_hdct.aspx" gui="SO_THE,TEN,PHONG" dong="true" Text="Quá trình làm việc" /></a></li>

                                        <li style="display: none"><a id="ns_biendong_bh" href="#" onclick="ns_cb_P_ACTIVEMENU('ns_biendong_bh')">
                                            <Cthuvien:roi ID="Lb_bhxh" runat="server" Width="365px"
                                                f_tkhao="~/App_form/ns/cd/ns_biendong_bh.aspx" gui="SO_THE,TEN,PHONG" dong="true" Text="Bảo hiểm" /></a></li>
                                        <li style="display: none"><a id="ns_tv" href="#" onclick="ns_cb_P_ACTIVEMENU('ns_tv')">
                                            <Cthuvien:roi ID="Lb_kthd" runat="server" Width="365px"
                                                f_tkhao="~/App_form/ns/qt/ns_tv.aspx" gui="SO_THE,TEN,PHONG,TEN_PHONG,EMAIL,NGAYD" dong="true" Text="Chấm dứt hợp đồng" /></a></li>
                                        <li style="display: none"><a id="ns_ktkl_kt" href="#" onclick="ns_cb_P_ACTIVEMENU('ns_ktkl_kt')">
                                            <Cthuvien:roi ID="Lb_kt" runat="server" Width="365px"
                                                f_tkhao="~/App_form/ns/ktkl/ns_ktkl_kt.aspx" gui="SO_THE,TEN,PHONG" dong="true" Text="Khen thưởng" /></a></li>
                                        <li style="display: none"><a id="ns_ktkl_kl" href="#" onclick="ns_cb_P_ACTIVEMENU('ns_ktkl_kl')">
                                            <Cthuvien:roi ID="Lb_kl" runat="server" Width="365px"
                                                f_tkhao="~/App_form/ns/ktkl/ns_ktkl_kl.aspx" gui="SO_THE,TEN,PHONG" dong="true" Text="Kỷ luật" /></a></li>
                                        <li><a id="ns_ls_dg" href="#" onclick="ns_cb_P_ACTIVEMENU('ns_ls_dg')">
                                            <Cthuvien:roi ID="lb_dg" runat="server" Width="365px"
                                                f_tkhao="~/App_form/ns/ls/ns_ls_dg.aspx" gui="SO_THE,TEN,PHONG" dong="true" Text="Kết quả đánh giá" /></a></li>
                                    </ul>

                                </ul>
                            </div>

                        </div>

                    </asp:Panel>

                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form css_border" style="width: 90px;">
                            <img id="iurl" runat="Server" alt=" ảnh thẻ" title="Anh the" src="~/images/no_image.png" style="width: 90px; height: 100px; float: right" onclick="return khud_trdoi_FI_NH();form_P_LOI();" />
                        </div>
                        <div class="b_left form-group iterm_form" style="padding-left: 80px; padding-top: 5px;">
                            <span class="standard_label b_left col_40">Mã nhân viên<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the" runat="server" CssClass="form-control css_ma" kieu_chu="True" kt_xoa="G"
                                    ToolTip="Mã nhân viên" ten="Mã nhân viên" Enabled="false" />
                                <%--onchange="ns_cb_P_KTRA('SO_THE')" />--%>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form" style="padding-top: 5px;">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                    ten="Họ và tên" onchange="ns_cb_P_KTRA('TEN')" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form" style="padding-left: 80px;">
                            <span class="standard_label b_left col_40">Mã marketing</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="kiemnhiem" runat="server" CssClass="form-control css_ma" kieu_chu="True" kt_xoa="G"
                                    ToolTip="Mã nhân viên" ten="Mã nhân viên" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên hoa<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN_HOA" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                    ten="Họ và tên" onchange="ns_cb_P_KTRA('TEN')" />
                            </div>
                        </div>
                    </div>


                    <div id="TPa" runat="server" class="navi_tabngang width_common">
                        <Cthuvien:tab ID="TPa_syll" runat="server" CssClass="css_tab_ngang_ac" Width="120px"
                            Text="Sơ yếu lý lịch" />
                        <Cthuvien:tab ID="TPa_ttct" runat="server" CssClass="css_tab_ngang_de" Width="120px"
                            Text="Thông tin công ty" />
                        <Cthuvien:tab ID="TPa_ttk" runat="server" CssClass="css_tab_ngang_de" Width="120px"
                            Text="Thông tin khác" />
                        <div style="display: none">
                            <Cthuvien:tab ID="TPu_ttnl" runat="server" CssClass="css_tab_ngang_de" Width="120px"
                                Text="Thông tin năng lực" />
                        </div>
                    </div>
                    <div>
                        <asp:Panel ID="Pa_syll" runat="server" Style="display: block;">
                            <div style="display: none">
                                <%-- <Cthuvien:ma ID="TEN_HOA" runat="server" CssClass="css_form" kt_xoa="X" Width="200px"
                                    ten="Tên hoa" kieu_chu="True" BackColor="#f6f7f7" Enabled="False" ToolTip="Tên hoa không dấu" />--%>
                                <Cthuvien:ma ID="tt" runat="server" CssClass="css_so" kieu_so="true" MaxLength="10"
                                    kt_xoa="X" Width="25px" ten="Thứ tự" />
                                <Cthuvien:DR_lke ID="phong1" ten="Phòng" runat="server" Width="487px" ktra="DT_PH" kt_xoa="X" />
                            </div>
                            <div class="col_3_iterm width_common" style="padding-top: 5px;">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Giới tính<span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="GTINH" ten="Giới tính" CssClass="form-control css_list" runat="server" ktra="DT_GT" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Ngày sinh<span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NSINH" ten="Ngày sinh" runat="server" CssClass="form-control css_ma_c"
                                            kt_xoa="X" ToolTip="Ngày sinh" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">ĐT Nhà riêng<span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="dtnr" ten="ĐT nhà riêng" kieu_so="true" runat="server" ToolTip="Số điện thoại nhà riêng"
                                            CssClass="form-control css_ma_r" kt_xoa="X" MaxLength="20" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">ĐT di động</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="dtdd" ten="ĐT.D.Động" kieu_so="true" runat="server" ToolTip="Số điện thoại di động"
                                            CssClass="form-control css_ma_r" kt_xoa="X" MaxLength="20" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Email cá nhân</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="email" ten="Email" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                            Enabled="true" MaxLength="255" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Hôn nhân</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke kt_xoa="X" ID="tt_honnhan" ten="Tình trạng hôn nhân" runat="server" CssClass="form-control css_list" ktra="DT_TTHN" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">CMTND/Hộ chiếu</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="socmt9" ten="Số CMT theo MST" kieu_so="true" runat="server" ToolTip="Số CMTND 9 số"
                                            CssClass="form-control css_ma_r" kt_xoa="X" MaxLength="255" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Ngày cấp</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_cmt9" ten="Ngày cấp CMTND 9 số" ToolTip="Ngày cấp CMTND 9 số" runat="server"
                                            CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Nơi cấp</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="nc_cmt9" kt_xoa="X" ten="Nơi cấp CMTND 9 số" runat="server" CssClass="form-control css_ma" MaxLength="255" kieu_unicode="true" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Số CMT mới nhất<span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="SOCMT" ten="Số CMT mới nhất" kieu_so="true" runat="server" ToolTip="Số CMTND/Thẻ CC công dân"
                                            CssClass="form-control css_ma_r" kt_xoa="X" MaxLength="255" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Ngày cấp<span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_CMT" ten="Ngày cấp CMTND/Thẻ CC công dân" ToolTip="Ngày cấp CMTND/Thẻ CC công dân" runat="server"
                                            CssClass="form-control css_ngay" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Nơi cấp<span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="NC_CMT" ten="Nơi cấp CMTND/Thẻ CC công dân" kt_xoa="X" runat="server" CssClass="form-control css_ma" MaxLength="255" kieu_unicode="true" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Quốc tịch<span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="NN" runat="server" ten="Quốc tịch" CssClass="form-control css_list" ktra="ns_ma_nuoc,ma,ten" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Dân tộc</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke kt_xoa="X" ID="dantoc" ten="Dân tộc" CssClass="form-control css_list" runat="server" ktra="ns_ma_dt,ma,ten" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Tôn giáo</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke kt_xoa="X" ID="tongiao" ten="Dân tộc" CssClass="form-control css_list" runat="server" ktra="ns_ma_tg,ma,ten" />
                                    </div>
                                </div>
                            </div>
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_15">Nơi sinh</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="noi_sinh" runat="server" kt_xoa="X" CssClass="form-control css_ma"
                                        kieu_unicode="true" MaxLength="255" />
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Tỉnh/Thành phố</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke kt_xoa="X" ID="tt_noisinh" ten="Tỉnh/Thành phố" CssClass="form-control css_list" kieu_unicode="true" runat="server" onchange="ns_cb_P_KTRA_DR('tt_noisinh')" ToolTip="Tỉnh/Thành phố" ktra="ns_ma_tt,ma,ten" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Quận/Huyện</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke kt_xoa="X" ID="qh_noisinh" ten="Quận/Huyện" CssClass="form-control css_list" runat="server" onchange="ns_cb_P_KTRA_DR('qh_noisinh')" ToolTip="Quận Huyện" ktra="ns_ma_qh,ma,ten" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Xã/Phường</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke kt_xoa="X" ID="xp_noisinh" ten="Xã/Phường" CssClass="form-control css_list" runat="server" onchange="ns_cb_P_KTRA_DR('xp_noisinh')" ToolTip="Tỉnh/Thành phố" ktra="ns_ma_xp,ma,ten" />
                                    </div>
                                </div>
                            </div>
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_15">Quê quán</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="quequan" runat="server" kt_xoa="X" CssClass="form-control css_ma"
                                        kieu_unicode="true" MaxLength="255" />
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Tỉnh/Thành phố</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke kt_xoa="X" ID="tt_quequan" ten="Tỉnh/Thành phố" CssClass="form-control css_list" kieu_unicode="true" runat="server" onchange="ns_cb_P_KTRA_DR('tt_quequan')" ToolTip="Tỉnh/Thành phố" ktra="ns_ma_tt,ma,ten" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Quận/Huyện</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke kt_xoa="X" ID="qh_quequan" ten="Quận/Huyện" CssClass="form-control css_list" runat="server" onchange="ns_cb_P_KTRA_DR('qh_quequan')" ToolTip="Quận Huyện" ktra="ns_ma_qh,ma,ten" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Xã/Phường</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke kt_xoa="X" ID="xp_quequan" ten="Xã/Phường" CssClass="form-control css_list" runat="server" onchange="ns_cb_P_KTRA_DR('xp_quequan')" ToolTip="Tỉnh/Thành phố" ktra="ns_ma_xp,ma,ten" />
                                    </div>
                                </div>
                            </div>
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_15">Địa chỉ thường trú</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="dchi_thuongtru" runat="server" kt_xoa="X" CssClass="form-control css_ma"
                                        kieu_unicode="true" MaxLength="255" />
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Tỉnh/Thành phố</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke kt_xoa="X" ID="tt_thuongtru" ten="Tỉnh/Thành phố" CssClass="form-control css_list" runat="server" onchange="ns_cb_P_KTRA_DR('tt_thuongtru')" ToolTip="Tỉnh/Thành phố" ktra="ns_ma_tt,ma,ten" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Quận/Huyện</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke kt_xoa="X" ID="qh_thuongtru" ten="Quận/Huyện" CssClass="form-control css_list" runat="server" onchange="ns_cb_P_KTRA_DR('qh_thuongtru')" ToolTip="Tỉnh/Thành phố" ktra="ns_ma_qh,ma,ten" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Xã/Phường</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke kt_xoa="X" ID="xp_thuongtru" ten="Xã/Phường" CssClass="form-control css_list" runat="server" onchange="ns_cb_P_KTRA_DR('xp_thuongtru')" ToolTip="Tỉnh/Thành phố" ktra="ns_ma_xp,ma,ten" />
                                    </div>
                                </div>
                            </div>
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_15">Địa chỉ hiện tại</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="dchi_tamtru" runat="server" kt_xoa="X" CssClass="form-control css_ma"
                                        kieu_unicode="true" MaxLength="255" />
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Tỉnh/Thành phố</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke kt_xoa="X" ID="tt_tamtru" ten="Tỉnh/Thành phố" CssClass="form-control css_list" runat="server" onchange="ns_cb_P_KTRA_DR('tt_tamtru')" ToolTip="Tỉnh/Thành phố" ktra="ns_ma_tt,ma,ten" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Quận/Huyện</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke kt_xoa="X" ID="qh_tamtru" ten="Quận/Huyện" CssClass="form-control css_list" runat="server" onchange="ns_cb_P_KTRA_DR('qh_tamtru')" ToolTip="Tỉnh/Thành phố" ktra="ns_ma_qh,ma,ten" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Xã/Phường</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="xp_tamtru" kt_xoa="X" ten="Xã/Phường" CssClass="form-control css_list" runat="server" onchange="ns_cb_P_KTRA_DR('xp_tamtru')" ToolTip="Tỉnh/Thành phố" ktra="ns_ma_xp,ma,ten" />
                                    </div>
                                </div>
                            </div>
                            <div class="width_common pv_bl"><span>Thông tin liên hệ</span></div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Họ tên</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="hoten_ll" ten="Họ tên người liên lạc" kieu_unicode="true" runat="server" ToolTip="Họ tên người liên lạc"
                                            CssClass="form-control css_ma" kt_xoa="X" MaxLength="255" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Quan hệ</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="quanhe_ll" ktra="DT_QUANHE_LL" runat="server" CssClass="form-control css_list" kt_xoa="X"></Cthuvien:DR_lke>
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Số ĐT</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="sdt_ll" ten="Số ĐT" kieu_so="true" runat="server" ToolTip="Số CMTND 9 số"
                                            CssClass="form-control css_ma_r" kt_xoa="X" MaxLength="255" />
                                    </div>
                                </div>
                            </div>
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_15">Địa chỉ</span>
                                <div class="input-group">
                                    <Cthuvien:nd ID="khican_ll" runat="server" kt_xoa="X" CssClass="form-control css_ma" Height="50px" Rows="3"
                                        kieu_unicode="true" TextMode="MultiLine" MaxLength="255" />
                                </div>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="Pa_ttct" runat="server" Style="display: none;">
                            <div class="b_left form-group iterm_form" style="padding-top: 5px;">
                                <span class="standard_label b_left col_15">Công ty<span class="require">*</span></span>
                                <div class="input-group">
                                    <Cthuvien:DR_lke ID="DONVI" ktra="DT_DONVI" runat="server" CssClass="form-control css_list" onchange="ns_cb_P_KTRA_DR('DONVI')" kt_xoa="X" ten="Công ty"></Cthuvien:DR_lke>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common" style="padding-top: 5px;">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Ban/Phòng<span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="PHONG_BAN" ktra="DT_PHONG_BAN" runat="server" CssClass="form-control css_list" onchange="ns_cb_P_KTRA_DR('PHONG_BAN')" kt_xoa="X" ten="Phòng/Bộ phận"></Cthuvien:DR_lke>
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form" style="display: none;">
                                    <span class="standard_label lv2 b_left col_45">Phòng/Bộ phận</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="ban" ktra="DT_BAN" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Ban/Bộ phận"></Cthuvien:DR_lke>
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Khối<span class="require">*</span> </span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="KHOI" ktra="DT_KHOI" runat="server" CssClass="form-control css_list"
                                            kt_xoa="X" ten="Khối"> 
                                        </Cthuvien:DR_lke>
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Là công ty chính</span>
                                    <div class="input-group">
                                        <Cthuvien:kieu ID="la_cty_chinh" runat="server" lke="X, " Width="30px" ToolTip="X - Có,  - Không" CssClass="form-control css_ma_c" Text="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="b_left form-group iterm_form" style="padding-top: 5px;">
                                <span class="standard_label b_left col_15">Đơn vị/ bộ phận<span class="require">*</span></span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="phongban_ct" runat="server" CssClass="form-control" Enabled="false" BackColor="#f6f7f7" kt_xoa="X" ten="Đơn vị/ bộ phận" />
                                </div>
                            </div>
                            <div style="display: none">
                                <Cthuvien:ma ID="phong" runat="server" BackColor="#f6f7f7" kt_xoa="X" CssClass="css_form" Width="150px" MaxLength="255" />
                            </div>
                            <div class="col_3_iterm width_common" style="padding-top: 5px;">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Chức danh<span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="CDANH" ktra="DT_CDANH" runat="server" onchange="ns_cb_P_KTRA_DR('CDANH');" CssClass="form-control css_list" kt_xoa="X" ten="Chức danh"></Cthuvien:DR_lke>
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Nhóm chức danh </span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="ncdanh" runat="server" BackColor="#f6f7f7" disabled kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="true" MaxLength="255" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Cấp bậc</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="bac_cdanh" ktra="DT_BCDANH" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Cấp bậc chức danh"></Cthuvien:DR_lke>
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common" style="padding-top: 5px;">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label  b_left col_45">Đối tượng nhân viên<span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="DTNV" ktra="DT_DTNV" runat="server" CssClass="form-control css_list"
                                            kt_xoa="X" ten="Đối tượng nhân viên">
                                        </Cthuvien:DR_lke>
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Trạng thái</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="ten_ttr" ten="Trạng thái" Enabled="false" BackColor="#f6f7f7" ToolTip="Trạng thái" runat="server"
                                            CssClass="form-control css_ma" kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common" style="padding-top: 5px;">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Ngày vào tập đoàn</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayd" runat="server" disabled BackColor="#f6f7f7" CssClass="form-control icon_lich" kieu_luu="S"
                                            kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Ngày vào công ty</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_tv" runat="server" disabled BackColor="#f6f7f7" CssClass="form-control icon_lich" kieu_luu="S"
                                            kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common" style="padding-top: 5px;">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Ngày vào chính thức</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_ct" disabled BackColor="#f6f7f7" ten="Ngày vào chính thức" ToolTip="Ngày vào chính thức" runat="server"
                                            CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Ngày ký HĐ đầu tiên</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_bd_hopdong" disabled="disabled" BackColor="#f6f7f7" ten="Ngày ký HĐLĐ đầu tiên" ToolTip="Ngày ký HĐLĐ đầu tiên"
                                            runat="server" CssClass="form-control icon_lich" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Gán mã NSD</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="ma_nsd" runat="server" CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="X" Enabled="false"
                                            ToolTip="Mã số cán bộ" ten="tên người giới thiệu ( bảo lãnh)" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Mã phân bổ <span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="MA_PBO" runat="server" CssClass="form-control css_list" ten="Mã phân bổ"
                                            ktra="DT_MA_PBO" kt_xoa="X" />

                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Địa chỉ làm việc</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke kt_xoa="X" ID="address" ten="Địa chỉ làm việc" CssClass="form-control css_list" runat="server" ToolTip="Địa chỉ làm việc" ktra="DT_ADDRESS" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Chi nhánh</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="branch" kt_xoa="X" ten="Chi nhánh" CssClass="form-control css_list" runat="server" ToolTip="Chi nhánh" ktra="DT_BRANCH" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common" style="padding-top: 5px;">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Quản lý trực tiếp</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="ten_quanly_tt" ten="Quản lý trực tiếp" ToolTip="Quản lý trực tiếp" runat="server"
                                            CssClass="form-control css_ma" kt_xoa="X" />
                                    </div>
                                    <div style="display: none">
                                        <Cthuvien:ma ID="quanly_tt" ten="Quản lý trực tiếp" ToolTip="Quản lý trực tiếp" runat="server"
                                            CssClass="form-control css_ma" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Email công ty</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="email_cty" ten="Email công ty" runat="server" CssClass="form-control css_ma" kt_xoa="X" Enabled="true" MaxLength="255" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Mã chấm công</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="ma_cc" ten="Mã chấm công" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu_so="true" MaxLength="255" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Đối tượng quản trị rủi ro</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="qtrr" runat="server" CssClass="form-control css_list" ten="Đối tượng quản trị rủi ro" ktra="DT_QTRR" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Vùng miền<span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke kt_xoa="X" ID="VUNG" ten="Vùng miền" CssClass="form-control css_list" runat="server"
                                            ToolTip="Vùng miền" ktra="DT_VUNG" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Đối tượng UBCK</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="ubck" kt_xoa="X" ten="Ủy ban chứng khoán" CssClass="form-control css_list" runat="server" ToolTip="Chi nhánh" ktra="DT_UBCK" />
                                    </div>
                                </div>
                            </div>
                            <div style="display: none">
                                <Cthuvien:kieu ID="co_lanhdao" runat="server" lke="X,K" Width="30px" ToolTip="X - Có,K - Không" CssClass="form-control css_ma_c" Text="K" kt_xoa="X" />

                                <Cthuvien:ma ID="ten_cm" ten="Chuyên môn" disabled runat="server" BackColor="#f6f7f7" CssClass="css_form" kt_xoa="X" Width="150px" />
                                <Cthuvien:ma ID="ten_cbnn" ten="Cấp bậc nghề nghiệp" disabled runat="server" BackColor="#f6f7f7" CssClass="css_form" kt_xoa="X" Width="150px" />
                                <Cthuvien:ma ID="ten_loai_cb" ten="Phân loại NV" disabled runat="server" BackColor="#f6f7f7" CssClass="css_form" kt_xoa="X" Width="150px" />
                                <Cthuvien:ma ID="ten_capnv" ten="Loại cb" disabled runat="server" BackColor="#f6f7f7" CssClass="css_form" kt_xoa="X" Width="150px" />
                                <%--<Cthuvien:kieu ID="kiemnhiem" runat="server" lke="C,K" Width="30px" ToolTip="C - Có,K - Không" CssClass="css_form_c" Text="K" />--%>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="Pa_ttnl" runat="server" Style="display: none;">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" hangKt="13" cot="ten_nhom_nl,ten_nl,muc_nl,ghichu,muc_nl_id"
                                cotAn="muc_nl_id" hamUp="ns_cb_nl_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Nhóm năng lực" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten_nhom_nl" runat="server" CssClass="css_Gma_c" kieu_chu="true"
                                                Width="200px" disabled />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Năng lực" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten_nl" runat="server" CssClass="css_Gma_c" kieu_chu="true"
                                                Width="150px" gchu="gchu" ten="Năng lực" guiId="hincd" disabled="disabled" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mức năng lực" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="muc_nl" runat="server" Width="150px" CssClass="css_Gma" ReadOnly="true" onchange="ns_cb_P_KTRA('MANL')" BackColor="#f6f7f7" placeholder="Nhấn (F1)" f_tkhao="~/App_form/ns/hdns/dm/ns_hdns_ma_nl.aspx" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mô tả" HeaderStyle-Width="250px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ghichu" runat="server" Width="250px" CssClass="css_Gma" MaxLength="100" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="muc_nl_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </asp:Panel>
                        <asp:Panel ID="Pa_ttk" runat="server" Style="display: none;">
                            <div class="col_3_iterm width_common" style="padding-top: 5px;">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Đối tượng cư trú <span class="require">*</span></span>
                                    <div class="input-group">
                                        <Cthuvien:DR_list ID="DT_CUTRU" runat="server" CssClass="form-control css_list" ten="Đối tượng cư trú" tra="CT,KCT" lke="Đối tượng cư trú,Đối tượng không cư trú" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Số sổ BHXH</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="so_bhxh" ten="Sổ sổ BHXH" runat="server" CssClass="form-control css_ma" kt_xoa="X" MaxLength="255" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Sở trường</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="thoihan_hchieu" ten="Sở trường" kieu_unicode="true" runat="server" CssClass="form-control css_ma" kt_xoa="X" MaxLength="255" />
                                    </div>
                                </div>

                            </div>
                            <div class="col_3_iterm width_common" style="padding-top: 5px;">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label  b_left col_45">Đóng công đoàn</span>
                                    <div class="input-group">
                                        <Cthuvien:kieu ID="cd" runat="server" lke=" ,X" Width="30px" ToolTip="X - Có,  - Không" kt_xoa="X"
                                            CssClass="form-control css_ma_c" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Ngày tham gia CĐ</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaythamgia" runat="server" ten="Ngày tham gia CĐ" CssClass="form-control icon_lich" kieu_luu="S"
                                            kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common" style="padding-top: 5px;">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Số hộ chiếu</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="so_hchieu" ten="Số hộ chiếu" runat="server" CssClass="form-control css_ma" kt_xoa="X" MaxLength="255" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Ngày cấp hộ chiếu</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaycap_hchieu" ten="Ngày cấp hộ chiếu" runat="server" CssClass="form-control icon_lich" kieu_luu="S"
                                            kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Nơi cấp</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="noicap_visa" ten="Nơi cấp" kieu_unicode="true" runat="server" CssClass="form-control css_ma"
                                            kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="width_common pv_bl"><span>Thông tin mã số thuế</span></div>
                            <div class="col_3_iterm width_common" style="padding-top: 5px;">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Mã số thuế</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="mast" ten="Mã số thuế" runat="server" CssClass="form-control css_ma" ToolTip="Mã số thuế"
                                            kt_xoa="X" MaxLength="100" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Có cam kết</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="ht_tinhluong" runat="server" CssClass="form-control css_list" ten="HT tính lương" ktra="DT_HTTL" kt_xoa="X" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Ngày cấp MST</span>
                                    <div class="input-group">
                                        <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaycap_mst" ten="Ngày cấp mã số thuế" runat="server" CssClass="form-control icon_lich" kieu_luu="S"
                                            kt_xoa="X" />
                                    </div>
                                </div>
                            </div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Cơ quan thuế QL</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="cqthue" ten="Cơ quan thuế QL" kieu_unicode="true" runat="server" CssClass="form-control css_ma" ToolTip="Cơ quan thuế QL"
                                            kt_xoa="X" MaxLength="100" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                </div>
                                <div class="b_right form-group iterm_form">
                                </div>
                            </div>
                            <div class="width_common pv_bl"><span>Thông tin sức khỏe</span></div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Chiều cao</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="chieucao" kieu_unicode="true" ten="Chiều cao" runat="server" CssClass="form-control css_ma" ToolTip="Chiều cao"
                                            kt_xoa="X" MaxLength="100" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Cân nặng</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="cannang" kieu_unicode="true" ten="Chiều cao" runat="server" CssClass="form-control css_ma" ToolTip="Cân nặng"
                                            kt_xoa="X" MaxLength="100" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Nhóm máu</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="nhommau" kieu_unicode="true" ten="Nhóm máu" runat="server" CssClass="form-control css_ma" ToolTip="Nhóm máu"
                                            kt_xoa="X" MaxLength="100" />
                                    </div>
                                </div>
                            </div>
                            <div class="width_common pv_bl"><span>Thông tin tài khoản</span></div>
                            <div class="col_3_iterm width_common">
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left col_45">Số TK</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="sotk" runat="server" CssClass="form-control css_ma" kt_xoa="X" ToolTip="Số tài khoản" kieu_chu="True" ten="Số tài khoản" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Ngân hàng</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="nha" runat="server" kt_xoa="X" ToolTip="Ngân hàng"
                                            kieu_unicode="True" ten="Ngân hàng" CssClass="form-control css_list" onchange="ns_cb_P_KTRA_DR('NHA')" ktra="ns_ma_nha,ma,ten" />
                                    </div>
                                </div>
                                <div class="b_right form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_45">Chi nhánh</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="cnhanh_nha" CssClass="form-control css_list" runat="server" kt_xoa="X" ToolTip="Chi nhánh"
                                            kieu_unicode="True" ten="Chi nhánh" ktra="DT_CNNH" />
                                    </div>
                                </div>
                            </div>
                            <div style="display: none">
                                <Cthuvien:ma ID="ten_nn" ten="Sở trường" runat="server" kieu_unicode="true" CssClass="form-control css_ma" kt_xoa="X" />
                                <Cthuvien:ma ID="Ma1" ten="Tên phòng ban" runat="server" CssClass="css_form" kieu_unicode="true" kt_xoa="X" Width="150px" MaxLength="255" />
                                <Cthuvien:ma ID="so_bhyt" ten="Số thẻ BHYT" runat="server" CssClass="css_form" kt_xoa="X" Width="150px" MaxLength="255" />
                                <Cthuvien:ma ID="hopdong_id" ten="Id hợp đồng ẩn" runat="server" CssClass="css_form" kt_xoa="X" Width="150px" MaxLength="255" />
                                <Cthuvien:ma ID="is_3b" ten="có điều chuyển 3 bên" runat="server" CssClass="css_form" kt_xoa="X" Width="150px" MaxLength="255" />

                                <Cthuvien:ma ID="so_visa" ten="Sổ visa" runat="server" CssClass="css_form" kt_xoa="X" Width="150px" MaxLength="255" />
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaycap_visa" runat="server" ten="Ngày cấp visa" Width="125px" CssClass="css_form_c" kieu_luu="S"
                                    kt_xoa="X" />
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayhethan_visa" runat="server" ten="Ngày hết hạn visa" Width="125px" CssClass="css_form_c" kieu_luu="S"
                                    kt_xoa="X" />
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="list_bt_action">

                        <div style="display: none;">
                            <Cthuvien:nhap ID="anh_the" runat="server" class="bt_action" anh="K" Font-Bold="True" Text="Ảnh"
                                OnClick="return khud_trdoi_FI_NH();form_P_LOI();" />
                            <Cthuvien:nhap ID="hien_ttt" runat="server" class="bt_action" anh="K" Text="Thông tin thêm" />
                            <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <div id="UPa_ttt" style="border: 1px solid #C0C0C0; background-color: #E9E9D1; display: none;">
        <table cellspacing="1" cellpadding="1">
            <tr id="tr_ttt">
                <td>
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label54" runat="server" CssClass="css_phude" Text="Thông tin thêm" />
                            </td>
                            <td align="right">
                                <img id="dong_ttt" alt="" src="../../../images/bitmaps/dong.png" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <khud_ttt:khud_ttt ID="khud_ttt" runat="server" ps="NS" nv="TT" />
                </td>
                <td></td>
            </tr>
        </table>
    </div>
    <AjaxTk:ModalPopupExtender ID="MPo_ttt" runat="server" BackgroundCssClass="css_modal"
        PopupDragHandleControlID="tr_ttt" PopupControlID="UPa_ttt" TargetControlID="hien_ttt"
        CancelControlID="dong_ttt" OnCancelScript="khud_ttt_P_DONG()" />
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="ps" runat="server" value="NS" />
        <Cthuvien:an ID="nv" runat="server" value="TT" />
        <Cthuvien:an ID="fileanh" runat="server" value="0" />
        <Cthuvien:an ID="phong_an" runat="server" />
        <Cthuvien:an ID="trangthai_an" runat="server" />
        <Cthuvien:an ID="ten_phong" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,800" />
    </div>
</asp:Content>
