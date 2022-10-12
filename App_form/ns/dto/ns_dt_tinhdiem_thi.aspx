<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dt_tinhdiem_thi.aspx.cs" Inherits="f_ns_dt_tinhdiem_thi"
    Title="ns_dt_tinhdiem_thi" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Tính điểm thi" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner">
                    <div id="UPa_ct">
                        <div class="col_3_iterm width_common">
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_15">Kỳ thi<span class="require">*</span> </span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="KYTHI" runat="server" onchange="ns_dt_tinhdiem_thi_P_KTRA('KYTHI')" CssClass="form-control css_ma" kieu_chu="true" BackColor="#f6f7f7"
                                        kt_xoa="G" placeholder="Nhấn (F1)" ktra="ns_dt_tochuc_thi,ma,ten" gchu="gchu" ten="Nhóm" f_tkhao="~/App_form/ns/dto/ns_dt_tochuc_thi.aspx" />
                                </div>
                            </div>
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label lv2 b_left col_30">Ngày chấm<span class="require">*</span></span>
                                <div class="input-group">
                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_CHAM" runat="server" ten="Ngày chấm thi"
                                        CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="width: 1200px; overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="gridX" loai="X" hangKt="20" cotAn="nsd,ma_dt" hamRow="ns_dt_tinhdiem_thi_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="SO_THE" HeaderStyle-Width="90">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Họ tên" DataField="ho_ten" HeaderStyle-Width="150px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Đơn vị" DataField="donvi" HeaderStyle-Width="160px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Phòng" DataField="phong" HeaderStyle-Width="160px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Chức danh" DataField="cdanh" HeaderStyle-Width="160px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tổng số câu hỏi" DataField="tong_cauhoi" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Số câu trắc nghiệm" DataField="sc_tracnghiem" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Điểm trắc nghiệm" DataField="diem_tracnghiem" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Số câu tự luận" DataField="sc_tuluan" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Điểm tự luận" DataField="diem_tuluan" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tổng số điểm" DataField="tong_diem" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Điểm đạt" DataField="diem_dat" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="ma dt" DataField="ma_dt" HeaderStyle-Width="10px">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_tinhdiem_thi_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_dt_tinhdiem_thi_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="cham_tl" runat="server" Width="150px" class="bt_action" anh="K" Text="Chấm điểm tự luận" OnClick="return ns_dt_tinhdiem_thi_P_CHAMDIEM();form_P_LOI();" />
                        <Cthuvien:nhap ID="xem" runat="server" Width="70px" class="bt_action" anh="K" Text="Xem lại" OnClick="return ns_dt_tinhdiem_thi_P_XEMLAI();form_P_LOI();" />
                        <Cthuvien:nhap ID="excel" runat="server" Width="100px" class="bt_action" anh="K" Text="Xuất excel" OnClick="return ns_dt_tinhdiem_thi_P_EXPORT();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1100,680" />
    </div>
</asp:Content>
