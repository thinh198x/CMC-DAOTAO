<%@ Page Title="tl_tlap_thieu_phieulenh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_tlap_thieu_phieulenh.aspx.cs" Inherits="f_tl_tlap_thieu_phieulenh" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập điều kiện thiếu phiếu lệnh" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%" cotAn="so_id"
                                CssClass="table gridX" loai="X" hangKt="10" hamRow="tl_tlap_thieu_phieulenh_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="so_id" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay" ItemStyle-CssClass="css_Gma_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="tl_tlap_thieu_phieulenh_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <%--<div class="col_2_iterm width_common">--%>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Ngày hiệu lực</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY" runat="server" ten="Ngày hiệu lực" CssClass="form-control icon_lich css_ngay" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label b_left col_20">Lần 1(% tạm giữ)</span>
                        <div class="input-group">
                            <Cthuvien:so ID="LAN1" MaxLength="15" runat="server" CssClass="form-control css_so" kt_xoa="X" 
                                ten="Giá trị" />
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label b_left col_20">Lần 2(% tạm giữ)</span>
                        <div class="input-group">
                            <Cthuvien:so ID="LAN2" MaxLength="15" runat="server" CssClass="form-control css_so" kt_xoa="X"
                                ten="Giá trị" />
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label b_left col_20">Lần 3(% tạm giữ)</span>
                        <div class="input-group">
                            <Cthuvien:so ID="LAN3" MaxLength="15" runat="server" CssClass="form-control css_so" kt_xoa="X"
                                ten="Giá trị" />
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label b_left col_20">Lần 3(% trích thu)</span>
                        <div class="input-group">
                            <Cthuvien:so ID="LAN3_THU" MaxLength="15" runat="server" CssClass="form-control css_so" kt_xoa="X"
                                ten="Giá trị" />
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label b_left col_20">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ghichu" runat="server"  kieu_unicode="true" ten="Mô tả" ToolTip="Mô tả" CssClass="form-control css_ma" kt_xoa="X" TextMode="MultiLine" Rows="3" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" class="bt_action" OnClick="return tl_tlap_thieu_phieulenh_P_NH();form_P_LOI();" Width="70px" anh="K" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" OnClick="return tl_tlap_thieu_phieulenh_P_MOI();form_P_LOI();" Width="70px" anh="K" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" OnClick="return tl_tlap_thieu_phieulenh_P_XOA();form_P_LOI();" Width="70px" anh="K" />
                    </div>
                </div>
            </div>


        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="600,540" />
    </div>
</asp:Content>
