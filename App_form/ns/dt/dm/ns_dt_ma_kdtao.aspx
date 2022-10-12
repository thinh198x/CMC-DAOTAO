<%@ Page Title="ns_dt_ma_kdtao" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_ma_kdtao.aspx.cs" Inherits="f_ns_dt_ma_kdtao" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục khóa đào tạo" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="nam_tk" runat="server" ten="Năm" ToolTip="Năm" CssClass="form-control css_ma" onchange="ns_dt_ma_kdtao_P_KTRA('NAMTK')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Khóa đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="kdt_tk" runat="server" ten="Khóa đào tạo" ToolTip="Khóa đào tạo" ktra="DT_KDTTK" CssClass="form-control css_list" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="timkiem" runat="server" Text="Tìm kiếm" class="bt_action" anh ="K" OnClick="return ns_dt_ma_kdtao_P_LKE();form_P_LOI(); " Width="100px" />
                    </div>
                    <div class="grid_table width_common">
                        <div class="css_divb">
                            <div style="width: 600px; overflow-x: scroll">
                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                    CssClass="table gridX" loai="X" hangKt="16" cotAn="so_id,nnd" hamRow="ns_dt_ma_kdtao_GR_lke_RowChange()">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Nhóm nội dung" DataField="ten_nnd" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Mã khóa đào tạo" DataField="ma" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Tên khóa đào tạo" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Thời lượng" DataField="tluong" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Mục đích" DataField="mucdich" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" HeaderStyle-Width="110px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField DataField="so_id" />
                                        <asp:BoundField DataField="nnd" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_ma_kdtao_P_LKE()" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_dt_ma_kdtao_P_IN();form_P_LOI();" />

                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="NAM" ten="Năm" ToolTip="Năm" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu_so="true" MaxLength="4" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Nhóm nội dung <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NND" ten="Nhóm nội dung" runat="server" ktra="DT_NND" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="ns_dt_ma_kdtao_P_KTRA('NND')" />

                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Nhóm nội dung đơn vị</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="nnd_dv" ten="Nhóm nội dung đơn vị" runat="server" ktra="DT_NND_DV" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="ns_dt_ma_kdtao_P_KTRA('NND_DV')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Mã khóa đào tạo <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" ten="Mã khóa đào tạo" ToolTip="Mã khóa đào tạo" runat="server" kieu_chu="true" CssClass="form-control css_ma"
                                    kt_xoa="G" MaxLength="20" onchange="ns_dt_ma_kdtao_P_KTRA('MA')" ReadOnly="true" BackColor="#f6f7f7" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Tên khóa đào tạo <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Tên khóa đào tạo" ToolTip="Tên khóa đào tạo" MaxLength="255" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu_unicode="true" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Hình thức đào tạo <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="HTHUC" lke=",Inclass,Hội thảo,On Job Training,Talkshow" tra=",IL,HT,OJT,TS" CssClass="form-control css_list" runat="server" ten="Hình thức đào tạo" ToolTip="Hình thức đào tạo" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Thời lượng đào tạo (giờ)</span>
                            <div class="input-group">
                                <Cthuvien:so ID="tluong" ten="Thời lượng đào tạo" so_tp="1" MaxLength="10" kt_xoa="X" runat="server" CssClass="form-control css_so" kieu_chu="True" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Trạng thái <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="TRANGTHAI" lke="Áp dụng,Ngừng áp dụng" tra="A,N" CssClass="form-control css_list" runat="server" ten="Trạng thái" ToolTip="Trạng thái" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_25">Nội dung đào tạo <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:nd ID="NDUNG" runat="server" TextMode="MultiLine" CssClass="form-control css_nd" kt_xoa="X" ToolTip="Nội dung đào tạo" ten="Nội dung đào tạo"
                                MaxLength="1000" kieu_unicode="true"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_25">Mục đích đào tạo</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mucdich" runat="server" TextMode="MultiLine" CssClass="form-control css_nd" kt_xoa="X" ToolTip="Nội dung đào tạo" ten="Nội dung đào tạo"
                                MaxLength="1000" kieu_unicode="true"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Nhóm chức danh</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ncd" ten="Nhóm chức danh" runat="server" ktra="DT_NCD" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="ns_dt_ma_kdtao_P_KTRA('NCD')" />
                                <Cthuvien:an ID="hincd" runat="server" Value="" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_25">Đối tượng tham gia</span>
                        <div class="input-group">
                            <div class="">
                                <div id="NPa" runat="server" class="navi_tabngang width_common">
                                    <Cthuvien:tab ID="NPa_cdanh" runat="server" CssClass="css_tab_ngang_ac" Width="100px"
                                        Height="20px" Text="Chức danh" />
                                    <Cthuvien:tab ID="NPa_dvi" runat="server" CssClass="css_tab_ngang_de" Width="100px"
                                        Height="20px" Text="Đơn vị" />
                                </div>
                                <div>
                                    <asp:Panel ID="Pa_cdanh" runat="server" Style="display: block;">
                                        <div id="UPa_lke">
                                            <Cthuvien:GridX ID="GR_cdanh" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                                CssClass="table gridX" loai="N" cot="ma,ten" hangKt="5">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:TemplateField HeaderText="Mã chức danh" HeaderStyle-Width="140px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="ma" runat="server" Width="140px" CssClass="css_Gma_c" guiId="hincd" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_ma_vtcdanh.aspx"
                                                                ktra="ns_ma_cdanh,ma,ten" placeholder="Nhấn F1" kt_xoa="G" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Tên chức danh" DataField="ten" HeaderStyle-Width="260px"
                                                        ItemStyle-CssClass="css_Gma" ReadOnly="true" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                        <div class="btex_luoi b_right">
                                            <ul>
                                                <li>
                                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_ma_kdtao_HangLen(1);" />
                                                </li>
                                                <li>
                                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_ma_kdtao_HangXuong(1);" />
                                                </li>
                                                <li>
                                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_ma_kdtao_CatDong(1);" />
                                                </li>
                                                <li>
                                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return ns_dt_ma_kdtao_ChenDong('C');" />
                                                </li>
                                            </ul>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="Pa_dvi" runat="server" Style="display: none;">
                                        <div>
                                            <Cthuvien:GridX ID="GR_dvi" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                                CssClass="table gridX" loai="N" cot="ma,ten" hangKt="5">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:TemplateField HeaderText="Mã đơn vị" HeaderStyle-Width="140px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="ma" runat="server" Width="140px" CssClass="css_Gma_c" f_tkhao="~/App_form/ht/ht_maph.aspx"
                                                                ktra="ht_ma_phong,ma,ten" placeholder="Nhấn F1" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Tên đơn vị" DataField="ten" HeaderStyle-Width="260px"
                                                        ItemStyle-CssClass="css_Gma" ReadOnly="true" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                        <div class="btex_luoi b_right">
                                            <ul>
                                                <li>
                                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_ma_kdtao_HangLen(2);" />
                                                </li>
                                                <li>
                                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_ma_kdtao_HangXuong(2);" />
                                                </li>
                                                <li>
                                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_ma_kdtao_CatDong(2);" />
                                                </li>
                                                <li>
                                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return ns_dt_ma_kdtao_ChenDong(2);" />
                                                </li>
                                            </ul>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_25">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mota" kieu_unicode="true" runat="server" CssClass="form-control css_nd" kt_xoa="X" TabIndex="5" TextMode="MultiLine" ToolTip="Mô tả" MaxLength="2000"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_dt_ma_kdtao_P_MOI();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_dt_ma_kdtao_P_NH();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" class="bt_action" anh="K" OnClick="form_P_TRA_CHON('MA,TEN');form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" onclick="return ns_dt_ma_kdtao_P_XOA();form_P_LOI();" Width="100px" />
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
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kdt_an" runat="server"></Cthuvien:an>
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,730" />
    </div>
</asp:Content>
