<%@ Page Title="dg_ngv_ctcv_ht" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="dg_ngv_ctcv_ht.aspx.cs" Inherits="f_dg_ngv_ctcv_ht" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Nhập chỉ tiêu công việc hàng tháng" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                     <div class="b_left width_common form-group iterm_form">
                            <span class="standard_label b_left col_20">Kỳ đánh giá <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KY_DG_TK" ten="Kỳ đánh giá" CssClass="form-control css_list" runat="server" ktra="DT_KY_DG_TK" kt_xoa="G" />
                            </div>
                        </div>
                     <div class="b_right width_common form-group iterm_form">
                            <span class="standard_label lv2 b_left col_20">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="trangthai_tk" ten="Trạng thái" runat="server" ktra="DT_TRANGTHAI_TK" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="dg_ngv_ctcv_ht_P_NAM_TK();" />
                            </div>
                        </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tim" runat="server" class="bt_action" anh="K" Text="Tìm kiếm" Width="100px" OnClick="return dg_ngv_ctcv_ht_P_LKE('M');form_P_LOI();" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="18" cotAn="so_id,trangthai" hamRow="dg_ngv_ctcv_ht_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Kỳ ĐG" DataField="ten_ky_dg" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="trangthai" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="dg_ngv_ctcv_ht_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" ktra="DT_NAM" CssClass="form-control css_list" kt_xoa="G" onchange="dg_ngv_ctcv_ht_P_NAM();" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Kỳ đánh giá <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KY_DG" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG" CssClass="form-control css_list" kt_xoa="G" onchange="dg_ngv_ctcv_ht_P_LKE('KDG')" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true"
                                    ten="Mã nhân viên" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kieu_chu="true" kieu_unicode="true"
                                    ten="Tên nhân viên" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="N" cot="stt,nd_congviec,trongso,ngay_d,ngay_ht" hangKt="10" gchuId="gchu" hamUp="dg_ngv_ctcv_ht_STT">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="STT" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="stt" runat="server" kieu_so="true" Width="50px" CssClass="css_Gma_c" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nội dung công việc và kết quả mong muốn" HeaderStyle-Width="250px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="nd_congviec" runat="server" CssClass="css_Gma" Width="250px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Trọng số" HeaderStyle-Width="90px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="trongso" runat="server" kieu_so="true" Width="90px" CssClass="css_Gso" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày bắt đầu" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder="dd/MM/yyyy" ID="ngay_d" runat="server" CssClass="css_Gma_c" Width="100px" kt_xoa="X" TaoValid="true" kieu_luu="S" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày hoàn thành dự kiến" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:ngay placeholder="dd/MM/yyyy" ID="ngay_ht" runat="server" CssClass="css_Gma_c" Width="100px" kt_xoa="X" TaoValid="true" kieu_luu="S" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="b_left mgt10 width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Ghi chú</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghichu" ten="Mô tả" TextMode="MultiLine" runat="server" CssClass="form-control css_nd" kieu_unicode="True"
                                kt_xoa="X" Height="50px" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="trangthai" ten="Trạng thái" runat="server" ktra="DT_TRANGTHAI" kieu_chu="true" CssClass="form-control css_list" kt_xoa="K" BackColor="#f6f7f7" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="list_bt_action">

                        <Cthuvien:nhap ID="moi" class="bt_action" anh="K" runat="server" Text="Làm mới" OnClick="return dg_ngv_ctcv_ht_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" class="bt_action" anh="K" runat="server" Width="80px" Text="Nhập" OnClick="dg_ngv_ctcv_ht_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="gui" class="bt_action" anh="K" runat="server" Width="80px" Text="Gửi" OnClick="return dg_ngv_ctcv_ht_P_GUI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" class="bt_action" anh="K" runat="server" Width="80px" Text="Xóa" OnClick="return dg_ngv_ctcv_ht_P_XOA();form_P_LOI();" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="so_id" runat="server" value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1300,750" />
</asp:Content>
