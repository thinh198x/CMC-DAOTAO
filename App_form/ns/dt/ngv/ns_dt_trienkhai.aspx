<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dt_trienkhai.aspx.cs" Inherits="f_ns_dt_trienkhai"
    Title="ns_dt_trienkhai" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Triển khai khóa đào tạo" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div style="display: none;">
                        <Cthuvien:DR_lke ID="BAN" ktra="DT_BAN" runat="server" Width="150px" onchange="ns_dt_trienkhai_P_KTRA('BAN')" kt_xoa="X" ten="Ban/Bộ phận"></Cthuvien:DR_lke>
                        <Cthuvien:DR_lke ID="PHONG" ktra="DT_PHONG" runat="server" Width="150px" onchange="ns_dt_trienkhai_P_KTRA('PHONG')" kt_xoa="X" ten="Phòng/Bộ phận"></Cthuvien:DR_lke>
                        <Cthuvien:DR_lke ID="NAM_TK" ten="Năm" ktra="DT_NAM_TK" kt_xoa="M" onchange="ns_dt_trienkhai_P_KTRA('NAM_TK')" runat="server" Width="150px">                                                                                
                        </Cthuvien:DR_lke>
                        <Cthuvien:DR_lke ID="KYLUONG_TK" ten="Kỳ lương" ktra="DT_KYLUONG_TK" kt_xoa="N" runat="server" Width="150px">                                                                                
                        </Cthuvien:DR_lke>
                        <Cthuvien:nhap ID="tim" runat="server" Width="100px" Text="Tìm kiếm" OnClick="return ns_dt_trienkhai_P_LKE('K');form_P_LOI();" />
                        <Cthuvien:DR_list ID="trangthai_tk" ten="Bảng công" runat="server" Width="140px" lke=",Chưa gửi,Chờ phê duyệt,Đã phê duyệt,Không phê duyệt" tra=",CG,0,1,2" onchange="ns_dt_trienkhai_P_KTRA('TRANGTHAI_TK')" />
                        <Cthuvien:nhap ID="tims" runat="server" Width="100px" Text="Tìm kiếm" OnClick="return ns_dt_trienkhai_P_LKE('K');form_P_LOI();" />

                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="16" cotAn="trangthai,so_id,kdt,ma_lop"
                                cot="chon,nam,thang,khoa_dt,lop_hoc,tgian_bd,tgian_kt,tl_daotao,sl_hocvien,ten_trangthai,trangthai,so_id,kdt,ma_lop" hamRow="ns_dt_trienkhai_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn phê duyệt" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tháng" DataField="thang" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Khóa đào tạo" DataField="khoa_dt" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Lớp học" DataField="lop_hoc" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Thời gian BĐ" DataField="tgian_bd" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Thời gian KT" DataField="tgian_kt" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Thời lượng đào tạo" DataField="tl_daotao" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Số lượng HV dự kiến" DataField="sl_hocvien" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã trạng thái" DataField="trangthai" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số id" DataField="so_id" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số id" DataField="kdt" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số id" DataField="ma_lop" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_trienkhai_P_LKE()" />

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="tkhai" runat="server" class="bt_action" anh="K" Width="100px" Text="Triển khai" OnClick="return ns_dt_trienkhai_kdt_P();" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div style="display: none;">
                        <Cthuvien:ma ID="SO_THE" ten="Mã nhân viên" MaxLength="30" runat="server" CssClass="css_form" kieu_chu="True" BackColor="#f6f7f7" placeholder="Nhấn (F1)"
                            kt_xoa="K" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" onchange="ns_dt_trienkhai_P_KTRA('SO_THE')" Width="140px" />
                        <Cthuvien:ma ID="ten_cdanh" Enabled="false" runat="server" CssClass="css_form" Width="150px" kt_xoa="K" gchu="gchu" />
                        <Cthuvien:ma ID="ho_ten" Enabled="false" runat="server" CssClass="css_form" Width="140px" kt_xoa="K" gchu="gchu" />
                        <Cthuvien:ma ID="ten_phong" runat="server" Enabled="false" CssClass="css_form" Width="150px" kt_xoa="K" gchu="gchu" />
                        <Cthuvien:DR_lke ID="NAM" ten="Năm" ktra="DT_NAM" kt_xoa="M" onchange="ns_dt_trienkhai_P_KTRA('NAM')" runat="server" Width="140px">                                                                                
                        </Cthuvien:DR_lke>
                        <Cthuvien:DR_lke ID="KYLUONG" ten="Kỳ lương" ktra="DT_KYLUONG" kt_xoa="N" runat="server" Width="150px">                                                                                
                        </Cthuvien:DR_lke>
                        <Cthuvien:ngay ID="NGAY_GT" ten="Ngày giải trình" runat="server" onchange="ns_dt_trienkhai_P_KTRA('NGAY_GT')" CssClass="css_form_c" kieu_luu="S" kt_xoa="G" Width="114px" />
                        <Cthuvien:ma ID="giod" ten="Giờ vào" MaxLength="30" runat="server" kt_xoa="X" CssClass="css_form_c" kieu_chu="True" onchange="ns_dt_trienkhai_P_KTRA('GIOD')" Width="140px" />
                        <Cthuvien:ma ID="gioc" ten="Giờ ra" MaxLength="30" runat="server" kt_xoa="X" CssClass="css_form_c" kieu_chu="True" onchange="ns_dt_trienkhai_P_KTRA('GIOC')" Width="150px" />
                        <Cthuvien:DR_lke ID="MACC_NGHI" ktra="DT_KIEUNGHI" ten="Mã chấm công" runat="server" kt_xoa="X" Width="140px">                                                                                
                        </Cthuvien:DR_lke>
                        <Cthuvien:nd ID="ly_do" ten="Lý do" runat="server" CssClass="css_form" MaxLength="255" kieu_unicode="true" TextMode="MultiLine" Height="50px"
                            Width="382px" kt_xoa="X" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Nhập" OnClick="return ns_dt_trienkhai_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="moi" runat="server" Width="60px" Text="Mới" OnClick="return ns_dt_trienkhai_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="60px" Text="Xóa" OnClick="return ns_dt_trienkhai_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="gui" runat="server" Width="120px" Text="Gửi phê duyệt" OnClick="return ns_dt_trienkhai_P_GUI();form_P_LOI();" />
                        <Cthuvien:nhap ID="btn_excel_mau" runat="server" Text="Mẫu excel" Width="70px" OnServerClick="btn_excel_mau_Click" />
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />

                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu2" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1100,630" />
    <Cthuvien:an ID="so_id" runat="server" />
</asp:Content>
