<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_cc_ma_tspb.aspx.cs" Inherits="f_ns_cc_ma_tspb"
    Title="ns_cc_ma_tspb" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thông số phép năm" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="False" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="ns_cc_ma_tspb_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="NGAY_HL" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_ma_tspb_P_LKE()" />

                    </div>
                </div>
                <div class="b_left col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left width_common form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày hiệu lực <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_HL" runat="server" CssClass="form-control icon_lich"
                                    kt_xoa="X" ten="Từ ngày" Width="80%" ToolTip="Từ ngày"></Cthuvien:ngay>
                            </div>
                        </div>
                        <div class="b_right width_common form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Thâm niên tăng phép(Năm) <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="THAM_NIEN" runat="server" CssClass="form-control css_so" kieu_so="true"
                                    ten="Thâm niên tăng phép(Năm)" ToolTip="Năm" kt_xoa="K" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left width_common form-group iterm_form">
                            <span class="standard_label b_left col_30">Số phép tăng <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="PHEP_TANG" runat="server" CssClass="form-control css_so" so_tp="2"
                                    ten="Thâm niên tăng phép(Năm)" Width="80%" ToolTip="Số phép tăng" kt_xoa="K" />
                            </div>
                        </div>
                        <div class="b_right width_common form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Ngày cắt phép <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_CP" runat="server" CssClass="form-control icon_lich"
                                    kt_xoa="X" ten="Từ ngày" ToolTip="Từ ngày"></Cthuvien:ngay>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left width_common form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày cắt nghỉ bù <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_CPB" runat="server" CssClass="form-control icon_lich"
                                    kt_xoa="X" ten="Ngày cắt nghỉ bù" Width="80%" ToolTip="Ngày cắt nghỉ bù"></Cthuvien:ngay>
                            </div>
                        </div>
                        <div class="b_right width_common form-group iterm_form">
                            <span class="standard_label lv2 b_left col_50">Được sử dụng phép từ<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="LOAI_HUONG" lke="Chính thức,Thử việc" tra="1,0" CssClass="form-control css_list"
                                    runat="server" ten="Trạng thái" ToolTip="Chính thức được sử dụng phép từ" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_cc_ma_tspb_P_MOI();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_cc_ma_tspb_P_NH();form_P_LOI();" Width="70px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" onclick="return ns_cc_ma_tspb_P_XOA();form_P_LOI();" Width="70px" />
                    </div>
                    <div id="UPa_gchu" class="css_border" align="left">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
                <div class="b_right col_10 inner">
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="710,550" />
        <Cthuvien:an ID="tthai" runat="server" />
        <Cthuvien:an ID="so_id" runat="server" />
    </div>
</asp:Content>
