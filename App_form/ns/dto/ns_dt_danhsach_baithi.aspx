<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dt_danhsach_baithi.aspx.cs" Inherits="f_ns_dt_danhsach_baithi"
    Title="ns_dt_danhsach_baithi" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh sách bài thi" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Loại</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="LOAI" runat="server" CssClass="form-control css_list" onchange="ns_dt_danhsach_baithi_P_KTRA('LOAI')"
                                    ten="Loại" tra="1,2,3" lke="Chưa tham gia thi,Đã kết thúc,Đã chấm điểm"/>
                            </div>
                        </div>
                        <div style="display: none">
                            <asp:Label ID="Label2" runat="server" Text="Mã nhân viên" Width="90px" CssClass="css_gchu" />
                            <Cthuvien:ma ID="SO_THE" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true"
                                Width="140px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Mã nhân viên cán bộ"
                                onchange="ns_dt_danhsach_baithi_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten" />
                            <Cthuvien:ma ID="cmtnd" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true"
                                Width="140px" />
                            <div><a href="#" onclick="return ns_dt_danhsach_baithi_P_LKE();form_P_LOI();" class="bt bt-yellow"><i class="fa fa-search"></i>Tìm kiếm</a></div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="gridX" loai="X" hangKt="15" cotAn="nsd,ma_kt,trangthai_thi,ma_dt" hamRow="ns_dt_danhsach_baithi_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="ma_kt" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Tên kỳ thi" DataField="ten" HeaderStyle-Width="30%">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ngày thi" DataField="ngaythi">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Thời gian từ" DataField="thitu">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Thời gian đên" DataField="thiden">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Thời gian làm bài" DataField="thoigian">
                                        <ItemStyle CssClass="css_Gma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tổng điểm" DataField="Tong_diem">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Điểm trắc nghiệm" DataField="diem_tn">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Điểm tự luận" DataField="diem_tl">
                                        <ItemStyle CssClass="css_Gso" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="trangthai_thi" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="ma_dt" HeaderStyle-Width="10px" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_danhsach_baithi_P_LKE('K')" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Width="120px" class="bt_action" anh="K" Text="Bắt đầu thi" OnClick="return ns_dt_khoitao_dthi_P_BATDAU();form_P_LOI();" />
                        <Cthuvien:nhap ID="xem" runat="server" Width="100px" class="bt_action" anh="K" Text="Xem" OnClick="return ns_dt_khoitao_dthi_P_XEM();form_P_LOI();" />
                        <Cthuvien:nhap ID="xemlai" runat="server" Width="110px" class="bt_action" anh="K" Text="Xem lại" OnClick="return ns_dt_khoitao_dthi_P_XEMLAI();form_P_LOI();" />
                        <Cthuvien:nhap ID="phuckhao" runat="server" Width="150px" class="bt_action" anh="K" Text="Phúc khảo bài thi" OnClick="return ns_dt_khoitao_dthi_P_PHUCKHAO();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1050,580" />
    </div>
</asp:Content>
