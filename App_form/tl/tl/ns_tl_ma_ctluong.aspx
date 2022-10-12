<%@ Page Title="ns_tl_ma_ctluong" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tl_ma_ctluong.aspx.cs" Inherits="f_ns_tl_ma_ctluong" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập công thức lương" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_64">
                <div class="b_left col_60 inner" id="UPa_ct">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Công ty<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="MA_DVI_TK" ten="Công ty" runat="server" ktra="DT_DVI"
                                CssClass="form-control css_list" onchange="ns_tl_ma_ctluong_P_KTRA('MA_DVI')" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Bảng lương</span>
                            <div class="input-group">
                                <%--  <Cthuvien:DR_list ID="BLUONG_TK" ten="Bảng lương" runat="server" Width="250px" CssClass="form-control css_list"
                                    lke=",Bảng lương trong kỳ,Bảng lương tổng hợp,Bảng lương sở" tra=",0,1,2" onchange="ns_tl_ma_ctluong_P_KTRA('BLUONG_TK')" kt_xoa="G" />--%>
                                <Cthuvien:DR_list ID="BLUONG_TK" ten="Bảng lương" runat="server" Width="250px" CssClass="form-control css_list"
                                    lke="Bảng lương tổng hợp" tra="1" onchange="ns_tl_ma_ctluong_P_KTRA('BLUONG_TK')" kt_xoa="G" />
                            </div>
                        </div>
                        <div class="form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Loại bảng lương<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="MA_DT_TK" ten="Loại lương" lke="Bảng lương khối BACK,Bảng lương khối SALE,Bảng lương công tác viên BB,Bảng lương công tác viên khối BS,Bảng lương thực tập sinh"
                                    tra="BACK,SALE,BB,BS,TTS" runat="server" Width="250px" CssClass="form-control css_list" ktra="DT_DT"
                                    onchange="ns_tl_ma_ctluong_P_KTRA('BLUONG_TK')" kt_xoa="G" />
                            </div>
                        </div>
                    </div>
                    <div id="NPa" runat="server" class="navi_tabngang width_common">
                        <Cthuvien:tab ID="NPa_ct" runat="server" CssClass="css_tab_ngang_ac" Width="110px" Height="20px" Text="Cột công thức" />
                    </div>
                    <div>
                        <asp:Panel ID="Pa_ct" runat="server" Style="display: block;">
                            <div class="grid_table width_common">
                                <div>
                                    <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                        CssClass="table gridX" loai="X" hangKt="15" cot="sott_nhom,sott_hien_thi,ma,ten,congthuc,so_id,TT" cotAn="congthuc,so_id,TT" hamRow="ns_tl_ma_ctluong_GR_lke_RowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="SOTT_NHOM" HeaderText="STT tính" HeaderStyle-Width="70px" ItemStyle-CssClass="css_ma_c" />
                                            <asp:BoundField DataField="sott_hien_thi" HeaderText="STT hiển thị" HeaderStyle-Width="100px" ItemStyle-CssClass="css_ma_c" />
                                            <asp:BoundField HeaderText="Mã cột lương" DataField="ma" />
                                            <asp:BoundField HeaderText="Tên cột lương" DataField="ten" ItemStyle-Font-Bold="true" />
                                            <asp:BoundField DataField="congthuc" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="SO_ID" HeaderStyle-Width="10px" />
                                            <asp:BoundField DataField="TT" HeaderStyle-Width="10px" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <ctr_khud_divL:ctr_khud_divL ID="GR_ct_slide" runat="server" loai="X" gridId="GR_ct" ham="ns_tl_ma_ctluong_P_LKE('K')" />
                            </div>
                        </asp:Panel>
                    </div>
                    <div>
                        <Cthuvien:nd ID="congthuc" ToolTip="Công thức" Rows="10" runat="server" kieu="U" Width="100%" CssClass="form-control css_ma" TextMode="MultiLine" kt_xoa="X" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="kiemtra" runat="server" Text="Kiểm tra" Width="90px" OnClick="return ns_tl_ma_ctluong_P_KT();form_P_LOI();" class="bt_action" anh="K" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Lưu" Width="90px" OnClick="return ns_tl_ma_ctluong_P_NH();form_P_LOI();" class="bt_action" anh="K" />
                    </div>
                </div>
                <div class="b_right col_40 inner" id="UPa_dv">
                    <div id="Table1" runat="server" class="navi_tabngang width_common">
                        <Cthuvien:tab ID="NPa_dl" runat="server" CssClass="css_tab_ngang_ac" Width="110px" Height="20px" Text="Dữ liệu đầu vào" />
                    </div>
                    <div>
                        <asp:Panel ID="Panel1" runat="server" Style="display: block;">
                            <div class="grid_table width_common">
                                <div>
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                        CssClass="table gridX" loai="X" hangKt="20" cotAn="" cot="ma,ten" hamRow="ns_tl_ma_ctluong_GR_lke_RowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField HeaderText="Mã cột lương" DataField="ma" ItemStyle-CssClass="css_ma" />
                                            <asp:BoundField HeaderText="Tên cột lương" DataField="ten" ItemStyle-Font-Bold="true" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_tl_ma_ctluong_P_DV_LKE('K')" />
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="col_3_iterm width_common" style="display: none">
                        <Cthuvien:kieu runat="server" ID="trang_thai" ten="Áp dụng" lke=",X" tra=",X" CssClass="css_form_c" Width="30px" kt_xoa="X" />
                        <Cthuvien:kieu runat="server" ID="hien_thi" ten="Hiển thị bảng công" lke=",X" tra=",X" CssClass="css_form_c" Width="30px" kt_xoa="X" />
                        <Cthuvien:so runat="server" ID="sott_nhom" ten="Thứ tự tính" Text="0" kieu_so="true" CssClass="css_form_c" Width="30px" kt_xoa="X" />
                        <Cthuvien:so runat="server" ID="sott_hien_thi" ten="Thứ tự hiển thị" Text="0" kieu_so="true" CssClass="css_form_c" Width="30px" kt_xoa="X" />
                    </div>
                </div>
            </div>

        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,800" />
    </div>
</asp:Content>
