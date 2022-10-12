<%@ Page Title="ns_tl_pc" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tl_pc.aspx.cs" Inherits="f_ns_tl_pc" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập phụ cấp" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="L" hangKt="20" cot="ten_pc,ng_hluc,ng_het_hluc,sotien,so_id,ma_pc" cotAn="so_id,ma_pc" hamRow="ns_tl_pc_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />

                                    <asp:BoundField HeaderText="Phụ cấp" DataField="ten_pc"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ng_hluc"
                                        ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Ngày hết hiệu lực" DataField="ng_het_hluc"
                                        ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Số tiền" DataField="sotien" HeaderStyle-Width="100px"
                                        ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" HeaderStyle-Width="0px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="ma_pc" DataField="ma_pc" HeaderStyle-Width="0px"
                                        ItemStyle-CssClass="css_Gnd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_tl_pc_P_LKE('K')" />

                    </div>
                    <%--<div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="90px" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_tl_pc_P_XUAT_EXEL();form_P_LOI();" />
                    </div>--%>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Phụ cấp <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="MA_PC" ktra="DT_PCAP" kt_xoa="X" ten="Phụ cấp" runat="server" CssClass="form-control css_list"
                                    ToolTip="Phụ cấp" f_tkhao="~/App_form/ns/hdns/dm/ns_hdns_ma_htkhac.aspx" onchange="ns_tl_pc_P_KTRA('MA_PC')"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số tiền <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="SOTIEN" runat="server" CssClass="form-control css_so" kieu_so="true" ten="Số tiền" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày hiệu lực <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay ID="NG_HLUC" placeholder="dd/MM/yyyy" runat="server" ten="Ngày hiệu lực" CssClass="form-control icon_lich" kt_xoa="X"
                                    kieu_luu="S" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày hết hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay ID="ng_het_hluc" placeholder="dd/MM/yyyy" runat="server" ten="Ngày hết hiệu lực" CssClass="form-control icon_lich" kt_xoa="X"
                                    kieu_luu="S" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_15">Ghi chú</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ghichu" ToolTip="Ghi chú" runat="server" Rows="2" kieu_unicode="true" CssClass="form-control css_nd" TextMode="MultiLine"
                                kt_xoa="X" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Loại hưởng <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="LOAIHUONG" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Vùng"
                                    lke="Theo công thực tế,Theo tháng" tra="HTH2,HTH1" onchange="ns_tl_pc_P_KTRA('LOAIHUONG')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Thiết lập theo <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="THIETLAP" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Thiết lập theo"
                                    lke="Phòng ban,Chức danh,Trình độ,Nhân viên,Thâm niên" tra="PB,CD,TD,NV,TN" onchange="ns_tl_pc_P_KTRA('THIETLAP')" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" id="Div-TN" style="display: none;">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Từ tháng</span>
                            <div class="input-group">
                                <Cthuvien:thang placeholder='MM/yyyy' ID="tuthang" runat="server" ten="Từ tháng" kt_xoa="X" CssClass="form-control icon_lich"
                                    ToolTip="Từ tháng" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến tháng</span>
                            <div class="input-group">
                                <Cthuvien:thang placeholder='MM/yyyy' ID="denthang" runat="server" kt_xoa="X" ten="Đến tháng" CssClass="form-control icon_lich"
                                    ToolTip="Đến tháng" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common" id="Div-NV" style="display: none;">
                        <div>
                            <Cthuvien:GridX ID="GR_NV" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="N" cot="tt,so_the,ten,phong,cdanh" cotAn="tt" hangKt="15" hamUp="ns_tl_pc_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="TT" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tt" runat="server" Width="70px" CssClass="css_Gma_c" kieu_luu="I" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mã nhân viên(*)" HeaderStyle-Width="130px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="SO_THE" runat="server" Width="130px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                ktra="ns_cb,so_the,ten" kieu_chu="true" onchange="ns_cp_P_KTRA('SO_THE')" kt_xoa="G" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Tên nhân viên(*)" DataField="TEN"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng(*)" DataField="PHONG" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Chức danh(*)" DataField="CDANH" ItemStyle-CssClass="css_Gma_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img alt="" src="/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_tl_pc_HangLen('GR_NV');" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_tl_pc_HangXuong('GR_NV');" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_tl_pc_CatDong('GR_NV');" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/chen.png" title="Thêm 1 dòng mới" onclick="return ns_tl_pc_ChenDong('C','GR_NV');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="grid_table width_common" id="Div-PB">
                        <div>
                            <Cthuvien:GridX ID="GR_PB" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="N" cot="chon,ma,ten" hangKt="19" hamUp="ns_tl_pc_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderStyle-Width="40px">
                                        <HeaderTemplate>
                                            <input id="chon_all" type="checkbox" onclick="CheckAll(this,'GR_PB')" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Mã phòng" DataField="MA"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên phòng" DataField="TEN" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_pb_slide" runat="server" loai="N" gridId="GR_PB" />
                        </div>
                        <%--                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img alt="" src="/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_tl_pc_HangLen('GR_PB');" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_tl_pc_HangXuong('GR_PB');" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_tl_pc_CatDong('GR_PB');" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/chen.png" title="Thêm 1 dòng mới" onclick="return ns_tl_pc_ChenDong('C','GR_PB');" />
                                </li>
                            </ul>
                        </div>--%>
                    </div>
                    <div class="grid_table width_common" id="Div-CD" style="display: none;">
                        <div>
                            <Cthuvien:GridX ID="GR_CD" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="N" cot="chon,ma,ten" hangKt="15" hamUp="ns_tl_pc_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                   
                                    <asp:TemplateField HeaderStyle-Width="40px">
                                        <HeaderTemplate>
                                            <input id="chon_all" type="checkbox" onclick="CheckAll(this,'GR_CD')" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Mã chức danh" DataField="MA"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên chức danh" DataField="TEN" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_cd_slide" runat="server" loai="N" gridId="GR_CD" />
                        </div>
                        <%-- <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img alt="" src="/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_tl_pc_HangLen('GR_CD');" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_tl_pc_HangXuong('GR_CD');" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_tl_pc_CatDong('GR_CD');" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/chen.png" title="Thêm 1 dòng mới" onclick="return ns_tl_pc_ChenDong('C','GR_CD');" />
                                </li>
                            </ul>
                        </div>--%>
                    </div>
                    <div class="grid_table width_common" id="Div-TD" style="display: none;">
                        <div>
                            <Cthuvien:GridX ID="GR_TD" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="N" cot="chon,ma,ten" hangKt="15" hamUp="ns_tl_pc_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    
                                    <asp:TemplateField HeaderStyle-Width="40px">
                                        <HeaderTemplate>
                                            <input id="chon_all" type="checkbox" onclick="CheckAll(this,'GR_TD')" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Mã trình độ" DataField="MA"
                                        ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên trình độ" DataField="TEN" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_td_slide" runat="server" loai="N" gridId="GR_TD" />
                        </div>
                       <%-- <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img alt="" src="/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_tl_pc_HangLen('GR_TD');" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_tl_pc_HangXuong('GR_TD');" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_tl_pc_CatDong('GR_TD');" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/chen.png" title="Thêm 1 dòng mới" onclick="return ns_tl_pc_ChenDong('C','GR_TD');" />
                                </li>
                            </ul>
                        </div>--%>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" class="bt_action" anh="K" OnClick="return ns_tl_pc_P_NH();form_P_LOI();"
                            Width="70px" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" anh="K" OnClick="return ns_tl_pc_P_MOI();form_P_LOI();"
                            Width="70px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_tl_pc_P_XOA();form_P_LOI();"
                            Width="70px" />
                        <Cthuvien:nhap ID="chon" runat="server" class="bt_action" anh="K" Font-Bold="True" OnClick="return ns_tl_pc_P_CHON();form_P_LOI();"
                            Text="Chọn" Width="70px" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="200px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
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
        <Cthuvien:an ID="ten_phong" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1023,700" />
    </div>
</asp:Content>
