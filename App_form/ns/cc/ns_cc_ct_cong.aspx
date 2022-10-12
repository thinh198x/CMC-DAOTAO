<%@ Page Title="ns_cc_ct_cong" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_ct_cong.aspx.cs" Inherits="f_ns_cc_ct_cong" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right" id="UPa_ct">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập công thức công" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner">
                    <div class="col_4_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Công ty</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="MA_DVI_TK" ten="Bảng công" runat="server" CssClass="form-control css_list" ktra="DT_DVI" onchange="ns_cc_ct_cong_P_KTRA('MA_DVI')" kt_xoa="G" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Đối tượng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="MA_DT_TK" ten="Đối tượng" runat="server" CssClass="form-control css_list" ktra="DT_DT" onchange="ns_cc_ct_cong_P_KTRA('MA_DT')" kt_xoa="L" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Bảng công</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="LOAI_TK" ten="Bảng công" runat="server" CssClass="form-control css_list" lke="Bảng chấm công máy,Bảng công tổng hợp" tra="1,2" onchange="ns_cc_ct_cong_P_KTRA('LOAI')" kt_xoa="K" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="b_left col_60 inner">
                    <div id="NPa" runat="server" class="navi_tabngang width_common">
                        <Cthuvien:tab ID="NPa_ct" runat="server" CssClass="css_tab_ngang_ac" Width="180px"
                            Text="Hết hạn hợp đồng" />
                    </div>
                    <div>
                        <asp:Panel ID="Pa_ct" runat="server" Style="display: block;">
                            <div class="b_left">
                                <div class="css_divb c_divC">
                                    <div class="css_divCn">
                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                            CssClass="table gridX" loai="X" hangKt="11" cot="SOTT_NHOM,sott_hien_thi,ma,ten,congthuc,SO_ID,TT" cotAn="congthuc,SO_ID,TT" hamRow="ns_cc_ct_cong_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField DataField="SOTT_NHOM" HeaderText="STT tính" HeaderStyle-Width="70px" ItemStyle-CssClass="css_ma_c" />
                                                <asp:BoundField DataField="sott_hien_thi" HeaderText="STT hiển thị" HeaderStyle-Width="100px" ItemStyle-CssClass="css_ma_c" />
                                                <asp:BoundField HeaderText="Mã cột công" DataField="ma" HeaderStyle-Width="120px" />
                                                <asp:BoundField HeaderText="Tên cột công" DataField="ten" ItemStyle-Font-Bold="true" />
                                                <asp:BoundField DataField="congthuc" HeaderStyle-Width="10px" />
                                                <asp:BoundField DataField="SO_ID" HeaderStyle-Width="10px" />
                                                <asp:BoundField DataField="TT" HeaderStyle-Width="10px" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                        <ctr_khud_divL:ctr_khud_divL ID="GR_ct_slide" runat="server" loai="X" gridId="GR_ct" ham="ns_cc_ct_cong_P_LKE('K')" /> 
                                    </div>

                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <div class="b_left col_40 inner">
                    <div id="Div1" runat="server" class="navi_tabngang width_common">
                        <Cthuvien:tab ID="NPa_dl" runat="server" CssClass="css_tab_ngang_ac" Width="110px"
                            Height="20px" Text="Dữ liệu đầu vào" />
                    </div>
                    <div>
                        <asp:Panel ID="Panel1" runat="server" Style="display: block;">
                            <div class="b_left">
                                <div class="css_divb c_divC">
                                    <div class="css_divCn">
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="11" cotAn="" cot="ma,ten" hamRow="ns_cc_ct_cong_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã cột công" DataField="ma" ItemStyle-CssClass="css_ma" HeaderStyle-Width="120px" />
                                                <asp:BoundField HeaderText="Tên cột công" DataField="ten" HeaderStyle-Width="350px" ItemStyle-Font-Bold="true" />

                                            </Columns>
                                        </Cthuvien:GridX>
                                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_ct_cong_P_DV_LKE('K')" /> 

                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <div class="b_right col_100 inner">
                    <div class="col_4_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <div class="input-group">
                                <Cthuvien:kieu runat="server" ID="trang_thai" ten="Áp dụng" lke=",X" tra=",X" CssClass="form-control css_ma" Width="30px" kt_xoa="X" />
                                <span class="standard_label b_left lv2 col_30">Áp dụng</span>
                                <Cthuvien:kieu runat="server" ID="hien_thi" ten="Hiển thị bảng công" lke=",X" tra=",X" CssClass="form-control css_ma" Width="30px" kt_xoa="X" />
                                <span class="standard_label b_left lv2 col_50">Hiển thị bảng công</span>

                            </div>
                        </div>
                        <div class="b_left lv2 form-group iterm_form">
                            <div class="input-group">
                                <Cthuvien:so runat="server" ID="SOTT_NHOM" ten="Thứ tự tính" Text="0" kieu_so="true" co_dau="K" CssClass="form-control css_ma" Width="30px" kt_xoa="X" />
                                <span class="standard_label lv2 b_left col_30">Thứ tự tính</span>
                                <Cthuvien:so runat="server" ID="sott_hien_thi" ten="Thứ tự hiển thị" Text="0" kieu_so="true" co_dau="K" CssClass="form-control css_ma" Width="30px" kt_xoa="X" />
                                <span class="standard_label lv2 b_left col_40">Thứ tự hiển thị</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="b_right col_100 inner">
                    <Cthuvien:nd ID="congthuc" ToolTip="Công thức" Rows="8" runat="server" kieu="U" Width="100%"
                        CssClass="form-control css_nd" TextMode="MultiLine" kt_xoa="X" />
                </div>
                <div class="list_bt_action">
                    <Cthuvien:nhap ID="kiemtra" runat="server" class="bt_action" anh="K" Text="Kiểm tra CT" Width="120px" OnClick="return ns_cc_ct_cong_P_KT();form_P_LOI();" />
                    <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Text="Nhập" Width="90px" OnClick="return ns_cc_ct_cong_P_NH();form_P_LOI();" />
                    <div class="box3 txRight" style="text-align: left; padding-left: 50px; display: none;">
                        <a href="#" onclick="return ns_cc_ct_cong_cong();" class="bt bt-grey">Cộng</a>
                        <a href="#" onclick="return ns_cc_ct_cong_tru();" class="bt bt-grey">Trừ</a>
                        <a href="#" onclick="return ns_cc_ct_cong_nhan();" class="bt bt-grey">Nhân</a>
                        <a href="#" onclick="return ns_cc_ct_cong_chia();" class="bt bt-grey">Chia</a>
                    </div>
                </div>
                <div id="UPa_gchu">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu_nl" kt_xoa="K" />
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,800" />
    </div>
</asp:Content>
