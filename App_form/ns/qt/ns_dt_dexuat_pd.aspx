<%@ Page Title="ns_dt_dexuat_pd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_dexuat_pd.aspx.cs" Inherits="f_ns_dt_dexuat_pd" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Phê duyệt đề xuất đào tạo" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Tháng</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="thang" runat="server" CssClass="form-control css_list" lke="Tháng 01,Tháng 02, Tháng 03,Tháng 04,Tháng 05,Tháng 06,Tháng 07,Tháng 08,Tháng 09,Tháng 10,Tháng 11,Tháng 12" tra="1,2,3,4,5,6,7,8,9,10,11,12" ten="Tháng" />
                                <div style="display: none">
                                    <Cthuvien:DR_lke ID="PHONG" ktra="DT_PHONG" ten="Phòng" kt_xoa="X" runat="server" Width="140px"></Cthuvien:DR_lke>
                                    <Cthuvien:ngay ID="NGAYD" runat="server" kieu_luu="S" CssClass="css_form_c" Width="100px"
                                        ten="Từ ngày" />
                                    <Cthuvien:ngay ID="NGAYC" runat="server" kieu_luu="S" CssClass="css_form_c" Width="100px"
                                        ten="Đến ngày" />
                                </div>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tình trạng</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="tinhtrang" runat="server" CssClass="form-control css_list" lke="Chờ phê duyệt,Đã phê duyệt,Không phê duyệt" tra="0,1,2" ten="Trạng thái phê duyệt" />

                            </div>
                        </div>
                        <div class="b_right lv2 form-group iterm_form">
                            <Cthuvien:nhap ID="tim" runat="server" class="bt_action" anh="K" Text="Tìm kiếm" Width="90px" OnClick="ns_dt_dexuat_pd_P_LKE();form_P_LOI('');" Title="Tìm kiếm" />

                        </div>
                    </div>
                    <div class="width_common pv_bl"><span></span></div>
                    <div class="grid_table width_common">
                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                            CssClass="table gridX" loai="N" hangKt="15" Width="100%" cotAn="SO_ID"
                            cot="SO_ID,chon,MA_NV,HO_TEN,khoa_dt,thang,tluong_dt,sl_hocvien,chiphi_dk,muc_tieu,dia_diem">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="5px" />
                                <asp:BoundField DataField="SO_ID" ItemStyle-CssClass="css_Gma_c" />
                                <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                    <ItemTemplate>
                                        <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn phê duyệt" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Mã NV" DataField="MA_NV" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField HeaderText="Tên NV" DataField="ho_ten" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Khóa đào tạo" DataField="khoa_dt" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Tháng mong muốn" DataField="thang" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Thời lượng đào tạo" DataField="tluong_dt" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_r" />
                                <asp:BoundField HeaderText="Số lượng học viên" DataField="sl_hocvien" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_r" />
                                <asp:BoundField HeaderText="chi phí dự kiến" DataField="chiphi_dk" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_r" />
                                <asp:BoundField HeaderText="Mục tiêu sau đào tạo" DataField="muc_tieu" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Địa điểm đào tạo" DataField="dia_diem" ItemStyle-CssClass="css_Gma" />
                            </Columns>
                        </Cthuvien:GridX>
                        <div id="GR_lke_td">
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_dexuat_ld_pd_P_LKE()" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" class="bt_action" anh="K" runat="server" Text="Phê duyệt" Width="120px" title="Phê duyệt" OnClick="return ns_dt_dexuat_pd_P_PHEDUYET('C');form_P_LOI();" />
                        <Cthuvien:nhap ID="thanhly" class="bt_action" anh="K" runat="server" Text="Không phê duyệt" Width="130px" title="Không phê duyệt" OnClick="return ns_dt_dexuat_pd_P_KOPHEDUYET();form_P_LOI();" />

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1180,620" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="phongc" runat="server" />
    </div>
    <%-- KTRA--%>
</asp:Content>

