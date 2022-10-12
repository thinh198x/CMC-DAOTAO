<%@ Page Title="ns_dt_hoctap" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_hoctap.aspx.cs" Inherits="f_ns_dt_hoctap" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Quá trình học tập" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="12" cotAn="so_id" hamRow="ns_dt_hoctap_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Từ tháng" DataField="thangd" HeaderStyle-Width="80px"
                                        ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField HeaderText="Đến tháng" DataField="thangc" HeaderStyle-Width="80px"
                                        ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField HeaderText="Năm tốt nghiệp" DataField="nam_tn" HeaderStyle-Width="80px"
                                        ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField HeaderText="Tên trường" DataField="truong" HeaderStyle-Width="170px"
                                        ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_hoctap_P_LKE('K')" /> 
                        </div>
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã số CB<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ktra="ns_cb,so_the,ten" ToolTip="Mã số cán bộ" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" placeholder="Nhấn (F1)"
                                    kieu_chu="true" onchange="ns_dt_hoctap_P_KTRA('so_the')" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <Cthuvien:gchu ID="hotencanbo" runat="server" CssClass="css_gchu lv2" kt_xoa="G" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Từ tháng<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:thang placeholder='MM/yyyy' ID="THANGD" ten="Từ tháng" runat="server" CssClass="form-control icon_lich" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến tháng</span>
                            <div class="input-group">
                                <Cthuvien:thang placeholder='MM/yyyy' ID="thangc" runat="server" CssClass="form-control icon_lich" kt_xoa="X" ten="Đến tháng" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Năm tốt nghiệp<span class="require">*</span> </span>
                        <div class="input-group">
                            <Cthuvien:ma ID="NAM_TN" ten="Năm tốt nghiệp" runat="server" CssClass="form-control icon_lich" kt_xoa="X"
                                kieu_so="true" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Tên trường<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TRUONG" ten="Tên trường" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Hình thức đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_htdt" ten="Hình thức đào tạo" runat="server" CssClass="form-control css_ma" kieu_chu="True" BackColor="#f6f7f7"
                                    f_tkhao="~/App_form/ns/ma/ns_ma_htdt.aspx" ktra="ns_ma_htdt,ma,ten"
                                    kt_xoa="X" onchange="ns_dt_hoctap_P_KTRA('ma_htdt')" placeholder="Nhấn F1" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chuyên ngành ĐT</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_cndt" ten="Chuyên ngành ĐT" runat="server" CssClass="form-control css_ma" kieu_chu="True" BackColor="#f6f7f7"
                                    f_tkhao="~/App_form/ns/ma/ns_ma_cnganh_dt.aspx" ktra="NS_MA_CNGANH_DT,ma,ten"
                                    kt_xoa="X" onchange="ns_dt_hoctap_P_KTRA('ma_cndt')" placeholder="Nhấn F1" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">KQ đào tạo </span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ma_ketqua_dt" ten="KQ đào tạo" runat="server" kt_xoa="X" CssClass="form-control css_list"
                                    ktra="DT_KQDT"/>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số hiệu bằng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_hieu_bang" ten="Số hiệu bằng" runat="server" CssClass="form-control css_ma" kt_xoa="X"
                                    />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_hieu_luc" runat="server" CssClass="form-control icon_lich" kt_xoa="X"
                                    ten="Ngày hiệu lực" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Ghi chú</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="note" ten="Ghi chú" kieu_unicode="true" runat="server" kt_xoa="X" CssClass="form-control css_ma" Height="50px"
                                TextMode="MultiLine" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <button onclick="return ns_dt_hoctap_P_NH();form_P_LOI();" class="bt_action"><span class="txUnderline">N</span>hập</button>
                        <button onclick="return ns_dt_hoctap_P_MOI();" class="bt_action"><span class="txUnderline">M</span>ới</button>
                        <button class="bt_action" onclick="return ns_dt_hoctap_P_XOA();form_P_LOI();"><span class="txUnderline">X</span>óa</button>
                        <button onclick="return nhap_file();" class="bt_action"><span class="txUnderline">F</span>ile</button>

                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="so_id" runat="server" Value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1100,580" />
</asp:Content>
