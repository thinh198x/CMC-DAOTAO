<%@ Page Title="dg_ngv_tonghop_dgkh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="dg_ngv_tonghop_dgkh.aspx.cs" Inherits="f_dg_ngv_tonghop_dgkh" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Tổng hợp kết quả đánh giá khách hàng" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" ktra="DT_NAM" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="dg_ngv_tonghop_dgkh_P_NAM();" kieu="S" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ đánh giá <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KY_DG" ten="Nhóm nội dung" runat="server" ktra="DT_KY_DG" kieu_chu="true" CssClass="form-control css_list" kt_xoa="G" onchange="dg_ngv_tonghop_dgkh_P_KTRA('KY_DG');" />

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
                                CssClass="table gridX" loai="X" hangKt="7" cot="sott,ten_canbo,ten_cdanh,ten_donvi,ngay_vao,diem,so_the" cotAn="so_the" 
                                hamRow="dg_ngv_tonghop_dgkh_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="STT" DataField="SOTT" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Họ tên" DataField="ten_canbo" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Đơn vị" DataField="ten_donvi" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày vào" DataField="ngay_vao" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Điểm đánh giá" DataField="diem" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField DataField="so_the" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="width_common mgt10 pv_bl"><span>Chi tiết</span></div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cotAn="ghichu" hangKt="7" hamUp="dg_ngv_tonghop_dgkh_Update" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="STT" DataField="SOTT" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Yêu cầu đánh giá" DataField="ycau" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tổng số phiếu ĐG" DataField="tong_dg" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="5 - Xuất sắc" DataField="dg_xuatsac" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="4 - Tốt" DataField="dg_tot" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="3 - Khá" DataField="dg_kha" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="2 - Trung bình" DataField="dg_trungbinh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="1 - Dưới trung bình" DataField="dg_duoitb" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Điểm trung bình" DataField="diem_tb" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="col_3_iterm width_common mg_top">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_50">Số lượng khách hàng đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sl_thuchien_dg" ten="Số lượng khách hàng đánh giá" runat="server" CssClass="form-control css_ma" kt_xoa="X" kieu="S" Style="background-color: #ebebed;" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Width="120px" class="bt_action" anh="K" Text="Tổng hợp" OnClick="return dg_ngv_tonghop_dgkh_P_NH();form_P_LOI();" />
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
