<%@ Page Title="ns_dt_ma_cket" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_ma_cket.aspx.cs" Inherits="f_ns_dt_ma_cket" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục cam kết đào tạo" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">

                    <div class="grid_table width_common">
                        <div class="css_divb">
                            <div>
                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                    CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="ns_dt_ma_cket_GR_lke_RowChange()">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:BoundField DataField="so_id" />
                                        <asp:BoundField HeaderText="Mức chi phí từ" DataField="cp_tu" ItemStyle-CssClass="css_Gma_r" />
                                        <asp:BoundField HeaderText="Mức chi phí đến" DataField="cp_den" ItemStyle-CssClass="css_Gma_r" />
                                        <asp:BoundField HeaderText="Thời gian cam kết (Tháng)" DataField="thgian_cket" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_r" />
                                        <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ng_hluc" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Ngày hết hiệu lực" DataField="ng_hhluc" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_ma_cket_P_LKE()" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_dt_ma_cket_P_IN();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div style="display: none;">
                        <Cthuvien:ma ID="so_id" runat="server" kt_xoa="G" kieu_so="true" CssClass="css_form" />

                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mức chi phí từ <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="cp_tu" runat="server" kt_xoa="X" CssClass="form-control css_so" co_dau="K" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mức chi phí đến</span>
                            <div class="input-group">
                                <Cthuvien:so ID="cp_den" runat="server" kt_xoa="X" CssClass="form-control css_so" co_dau="K" />

                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Thời gian cam kết <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="THGIAN_CKET" runat="server" CssClass="form-control css_so" kt_xoa="X" gchu="gchu" ten="Thời gian cam kết" ToolTip="Nhập số tháng cam kết" kieu_so="true" MaxLength="10" />
                                <Cthuvien:ma ID="ma3" runat="server" kt_xoa="K" CssClass="form-control css_ma" kieu_chu="true" Enabled="false" BackColor="#DBE8F1" Width="80px" Text="THÁNG" />

                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày hiệu lực <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NG_HLUC" ten="Ngày hiệu lực" runat="server" CssClass="form-control icon_lich" kieu_luu="S"
                                    kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày hết hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ng_hhluc" ten="Ngày hết hiệu lực" ToolTip="Ngày hết hiệu lực" runat="server" CssClass="form-control icon_lich" kt_xoa="X" kieu_luu="S" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mota" ten="Mô tả" runat="server" CssClass="form-control css_nd" kt_xoa="X" MaxLength="1000" ToolTip="Mô tả" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="return ns_dt_ma_cket_P_MOI();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="return ns_dt_ma_cket_P_NH();form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" class="bt_action" anh="K" OnClick="form_P_TRA_CHON('SOID,CP_TU');form_P_LOI();" Width="100px" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" onclick="return ns_dt_ma_cket_P_XOA();form_P_LOI();" Width="100px" />
                        <div style="display: none">
                            <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="Xuat_Excel" />
                        </div>
                    </div>
                    <div id="UPa_gchu" class="css_border" align="left">
                        <Cthuvien:gchu ID="ghichu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1180,550" />
</asp:Content>
