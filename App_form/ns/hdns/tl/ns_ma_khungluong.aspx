<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_ma_khungluong.aspx.cs" Inherits="f_ns_ma_khungluong"
    Title="ns_ma_khungluong" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục khung lương" />
                <img class="b_right" src="../../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" Width="100%" hangKt="15" cotAn="nsd,ngayc,ma_ncd,ma_cap"
                                hamRow="ns_ma_khungluong_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã khung lương" DataField="ma">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Cấp bậc" DataField="ten_cap">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mức min" DataField="mucmin">
                                        <ItemStyle CssClass="css_Gma_r" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mức max" DataField="mucmax">
                                        <ItemStyle CssClass="css_Gma_r" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Điểm giữa" DataField="diemgiua">
                                        <ItemStyle CssClass="css_Gma_r" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngayd">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ma_ncd" />
                                    <asp:BoundField DataField="ma_cap" />
                                    <asp:BoundField DataField="ngayc" />
                                    <asp:BoundField DataField="nsd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL" runat="server" loai="X" gridId="GR_lke"
                            ham="ns_ma_khungluong_P_LKE()" />
                    </div>
                     <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_ma_khungluong_P_EXCEL();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã khung lương<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" kieu_chu="true" ten="Mã khung lương"
                                    kt_xoa="G" onchange="ns_ma_khungluong_P_KTRA('MA');" MaxLength="20" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Cấp bậc<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="MA_CAP" ten="Cấp bậc" runat="server" ktra="DT_MA_CAP" kt_xoa="G" CssClass="form-control css_list" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mức min</span>
                            <div class="input-group">
                                <Cthuvien:so ID="mucmin" runat="server" CssClass="form-control css_so" kt_xoa="X" ten="Mức min" so_tp="2" co_dau="K" onchange="ns_ma_khungluong_P_TINH()" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mức max</span>
                            <div class="input-group">
                                <Cthuvien:so ID="mucmax" runat="server" CssClass="form-control css_so" kt_xoa="X" ten="Mức max" co_dau="K" so_tp="2" onchange="ns_ma_khungluong_P_TINH()" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Điểm giữa</span>
                            <div class="input-group">
                                <Cthuvien:so ID="diemgiua" runat="server" CssClass="form-control css_so" kt_xoa="X" ten="Điểm giữa" so_tp="2" co_dau="K" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày hiệu lực<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYD" runat="server" ten="Ngày hiệu lực"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày hết hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayc" runat="server" ten="Ngày hết hiệu lực"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Nhóm chức danh</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="ma_ncd" ten="Nhóm chức danh" runat="server" ktra="DT_MA_NCD" kt_xoa="G" CssClass="form-control css_list" onchange="ns_ma_khungluong_P_KTRA('MA_NCD')" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" Width="100%" cot="chon,cdanh,ten" hangKt="10" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="CHON" runat="server" Width="40px" CssClass="css_Gma_c" lke="X," ToolTip="Chọn" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mã chức danh">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cdanh" runat="server" ReadOnly="true" CssClass="css_Gma" kt_xoa="X" Width="100%" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tên chức danh">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten" Enabled="false" runat="server" CssClass="css_Gma" kieu_chu="true" kt_xoa="X" Width="100%" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_15">Mô tả</span>
                            <div class="input-group">
                                <Cthuvien:nd ID="note" runat="server" TextMode="MultiLine" CssClass="form-control css_nd" kieu_unicode="True" kt_xoa="X" Height="50px"
                                    MaxLength="1000"></Cthuvien:nd>
                            </div>
                        </div>
                    </div>
                    <div style="display: none">
                        <Cthuvien:ma ID="day2" runat="server" CssClass="css_form" kieu_unicode="True" ten="Tên ngạch lương"
                            Width="54px"></Cthuvien:ma>
                        
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_ma_khungluong_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_ma_khungluong_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Width="80px" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_ma_khungluong_P_XOA();form_P_LOI();" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1250,600" />
    <Cthuvien:an ID="luu_day" runat="server" Value="" />
</asp:Content>
