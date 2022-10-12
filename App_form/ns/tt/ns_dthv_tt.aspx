<%@ Page Title="ns_dthv_tt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dthv_tt.aspx.cs" Inherits="f_ns_dthv_tt" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="khud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Bằng cấp chuyên môn" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,tthai" hamRow="ns_dthv_tt_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Từ tháng" DataField="thangd" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đến tháng" DataField="thangc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tên trường" DataField="ten_truong" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_tthai" HeaderStyle-Width="100px" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                    <asp:BoundField HeaderText="so_id" DataField="tthai" />
                                </Columns>
                            </Cthuvien:GridX>
                            <khud:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dthv_tt_P_LKE()" />

                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" class="bt_action" anh="K" runat="server" Width="100px" Text="Xuất excel" OnServerClick="excel_Click" />

                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã nhân viên" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7" kt_xoa="K" ReadOnly="true" Enabled="false" />
                                <Cthuvien:an ID="so_the_an" runat="server" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten" ten="Họ tên" runat="server" CssClass="form-control css_ma"
                                    ToolTip="Họ tên nhân viên" kt_xoa="K" ReadOnly="true" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span></span></div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Từ tháng <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:thang placeholder='MM/yyyy' ID="THANGD" runat="server" CssClass="form-control icon_lich" kt_xoa="X"
                                    kieu_luu="S" ten="Từ tháng" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến tháng</span>
                            <div class="input-group">
                                <Cthuvien:thang placeholder='MM/yyyy' ID="thangc" runat="server" CssClass="form-control icon_lich" kt_xoa="X"
                                    kieu_luu="S" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Năm tốt nghiệp <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="NAM_TN" kieu_so="true"  runat="server" CssClass="form-control css_ma" kt_xoa="X" ten="Năm tốt nghiệp" MaxLength="4" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tên trường <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="TEN_TRUONG" ktra="DT_TRUONG" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Tên trường"></Cthuvien:DR_lke>
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Trình độ</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="capdt" ktra="DT_TRINHDO" runat="server" CssClass="form-control css_list" kt_xoa="X" ten="Trình độ"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Là bằng cấp chính</span>
                            <div class="input-group">
                                <Cthuvien:kieu runat="server" ID="tinhtrang" Width="20px" lke="C,K" ToolTip="C - Có, K - Không" CssClass="form-control css_ma" Text="C" BackColor="#00ccff" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Hình thức ĐT</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="hinhthuc" runat="server" CssClass="form-control css_list" ktra="ns_dthv_tt_HTDT" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Chuyên ngành ĐT</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="cnganh" runat="server" CssClass="form-control css_list" ktra="ns_dthv_tt_CNGANH" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Kết quả tốt nghiệp</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="xeploai" runat="server" CssClass="form-control css_list" lke=" ,Giỏi,Khá,Trung bình" tra="M,G,K,TB" ten="Kết quả tốt nghiệp" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Số hiệu bằng</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="sohieu" ten="Số hiệu bằng" runat="server" CssClass="form-control css_ma" kieu_chu="true"
                                    gchu="gchu" ToolTip="Số hiệu bằng cấp" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngaycap" runat="server" CssClass="form-control icon_lich" kt_xoa="X" ten="Ngày cấp"
                                    kieu_luu="S" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="note" ten="Mô tả" runat="server" kt_xoa="X" CssClass="form-control css_ma"
                                Width="100%" kieu_unicode="true" TextMode="MultiLine" Height="50px"/>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" class="bt_action" anh="K" runat="server" Text="Làm mới" OnClick="return ns_dthv_tt_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" class="bt_action" anh="K" runat="server" Width="80px" Text="Ghi" OnClick="return ns_dthv_tt_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="gui" class="bt_action" anh="K" runat="server" Text="Gửi phê duyệt" OnClick="return ns_dthv_tt_P_GUI();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" class="bt_action" anh="K" runat="server" Width="80px" Text="Xóa" OnClick="return ns_dthv_tt_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="file" class="bt_action" anh="K" runat="server" Width="120px" Text="Đính kèm file" OnClick="return nhap_file();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="so_id" runat="server" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1100,530" />
</asp:Content>
