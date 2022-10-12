<%@ Page Title="dg_ngv_tonghop_dgnb" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="dg_ngv_tonghop_dgnb.aspx.cs" Inherits="f_dg_ngv_tonghop_dgnb" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Tổng hợp kết quả đánh giá nội bộ" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" ktra="DT_NAM" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="dg_ngv_tonghop_dgnb_P_NAM();" kieu="S" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ đánh giá <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KY_DG" ten="Kỳ đánh giá" runat="server" ktra="DT_KY_DG" kieu_chu="true" CssClass="form-control css_list"
                                    kt_xoa="G" onchange="dg_ngv_tonghop_dgnb_P_KTRA('KY_DG')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30"></span>
                            <div class="input-group">
                            </div>
                        </div>
                    </div>
                    <div class="grid_table mgt10 width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="X" hangKt="7" cotAn="so_id" hamRow="dg_ngv_tonghop_dgnb_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="STT" DataField="SOTT" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten_canbo" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Đơn vị" DataField="ten_donvi" HeaderStyle-Width="227px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày vào" DataField="ngay_vao" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Điểm đánh giá" DataField="diem" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="dg_ngv_tonghop_dgnb_P_LKE('K')" />
                    </div>
                    <div class="width_common mgt10 lv2 pv_bl"><span>Chi tiết</span></div>
                    <div class="css_divb">
                        <div class="css_divCn">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="N" cotAn="ghichu" hangKt="7" hamUp="dg_ngv_tonghop_dgnb_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="STT" DataField="SOTT" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Yêu cầu đánh giá" DataField="ycau" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Tổng số phiếu ĐG" DataField="tong_dg" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="5 - Xuất sắc" DataField="dg_xuatsac" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="4 - Tốt" DataField="dg_tot" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="3 - Khá" DataField="dg_kha" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="2 - Trung bình" DataField="dg_trungbinh" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="1 - Dưới trung bình" DataField="dg_duoitb" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Điểm trung bình" DataField="diem_tb" ItemStyle-CssClass="css_Gso" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divC:ctr_khud_divC ID="GR_ct_slide" loai="N" runat="server" gridId="GR_ct" />
                    </div>
                    <div class="col_3_iterm mgt10 width_common mg_top">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_60">Số lượng CBNV được mời đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sl_moi_dg" ten="Số lượng CBNV được mời đánh giá" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu="S" Style="background-color: #ebebed; margin-right: 50px" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_60">Số lượng CBNV thực hiện đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sl_thuchien_dg" ten="Số lượng CBNV thực hiện đánh giá" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu="S" Style="background-color: #ebebed;" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Width="120px" class="bt_action" anh="K" Text="Tổng hợp" OnClick="return dg_ngv_tonghop_dgnb_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="excel" runat="server" Width="120px" class="bt_action" anh="K" Text="Xuất excel" OnServerClick="excel_Click" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="so_id" runat="server" value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1100,780" />
</asp:Content>
