<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ntduc_bai3.aspx.cs" Inherits="ntduc_b3"  MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục Phòng ban" />
                <img class="b_right" src="../../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_64">
                <div class="b_left col_60 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Từ ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_tu" runat="server" ten="Ngày hiệu lực" CssClass="form-control icon_lich" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Từ ngày" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_den" runat="server" ten="Đến ngày" CssClass="form-control icon_lich" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Đến ngày" />
                            </div>
                        </div>
                    </div>
                 
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" Width="100%" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" hangKt="15" hamRow="ns_pb_ntduc_bai3_GR_lke_RowChange()"
                            cotAn="ten_ta,ngay_gt,ten_vt,nsd" loai="X" cthich="chon:Đánh dấu chọn ký">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="ma" HeaderText="Mã phòng ban" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="ten" HeaderText="Tên phòng ban" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ng_qly" HeaderText="Người quản lý" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />                                    
                                    <asp:BoundField DataField="ngay_tl" HeaderText="Ngày thành lập" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />  
                                     <asp:BoundField DataField="ngay_gt" HeaderText="Ngày ket thuc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />  
                                    
                                    
                                    <asp:BoundField DataField="ma_tt" HeaderText="Tỉnh thành" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke"
                            ham="ns_hdns_ntduc_bai3_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="xuatExel" runat="server" Text="Xuất Excel" class="bt_action" anh="K"  Title="Ấn nút để xuất thông tin ra Excel" OnServerClick="nhap_Click" />
                    </div>
                </div>
                <div class="b_right col_40 inner" id="UPa_ct">
                       <div class="b_left form-group iterm_form">
						<span class="standard_label b_left col_20">Tỉnh thành<span class="require">*</span></span>
						<div class="input-group">
							<Cthuvien:DR_lke ID="MA_TT" runat="server" CssClass="form-control css_list" kieu_chu="True" ten="Tỉnh thanh" kt_xoa="G" ktra="DT_TT" lke="" />
						</div>
					</div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Mã phòng ban<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" ten="mã phòng ban" runat="server" CssClass="form-control css_ma" kieu_chu="True" Enabled="false"
                                kt_xoa="G" BackColor="#f6f7f7" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Tên phòng ban<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" ten="tên phòng ban" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                MaxLength="255" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Tên tiếng anh</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_ta" ten="tên tiếng anh" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                MaxLength="255" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Tên viết tắt<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_vt" ten="tên viết tắt" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                MaxLength="255" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày thành lập<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_TL" runat="server" kieu_luu="S" CssClass="form-control css_ma_c"
                                   kt_xoa="X" ten="Từ ngày" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày giải thể</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_gt" runat="server" kieu_luu="S" CssClass="form-control css_ma_c"
                                    kt_xoa="X" ten="Đến ngày" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Người quản lý</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ng_qly"  runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                MaxLength="250" />
                        </div>
                    </div>
                
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Địa chỉ</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="dia_chi"  runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X"
                                MaxLength="255" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_20">Ghi chú</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghi_chu" runat="server" CssClass="form-control css_ma" TextMode="MultiLine" kt_xoa="X" Height="50px"
                                MaxLength="1000"></Cthuvien:nd>
                        </div>
                    </div>
                    <div class="list_bt_action">
                       	<Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="ns_hdns_ntduc_bai3_P_MOI();form_P_LOI('');" Title="Ấn nút để làm mới" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="ns_hdns_ntduc_bai3_P_NH();form_P_LOI('');" Title="Ấn nút nhập để nhập mới" />
<%--                        <Cthuvien:nhap ID="Nhapexcel" runat="server" Text="Import" class="bt_action" anh="K" OnClick="ns_hdns_ntduc_bai3_FILE_Import();form_P_LOI('');" Title="Import" />--%>
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return ns_hdns_ntduc_bai3_P_XOA();form_P_LOI();" Title="Xóa dòng thông tin đang chọn" />
                          <%--<Cthuvien:nhap ID="file" runat="server" Text="File" Width="70px" class="bt_action" anh="K"
                                title="File" OnClick="return ns_hdns_ntduc_bai3_FILE_NHAP();form_P_LOI();" />--%>
                    </div>
                    <div style="display: none;">
                        <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" Text="Xuất excel" OnServerClick="nhap_Click"  />
                      
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1300,560" />
   
</asp:Content>
