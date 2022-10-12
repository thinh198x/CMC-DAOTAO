<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cc_ma_cc.aspx.cs" Inherits="f_cc_ma_cc"
    Title="cc_ma_cc" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập kiểu công" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="nsd,cc_sang,cc_chieu" hamRow="cc_ma_cc_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã kiểu công" DataField="ma" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên kiểu công" DataField="ten">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Trạng thái" DataField="ten_trangthai" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                ham="cc_ma_cc_P_LKE()" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" class="bt_action" anh="K" Text="Xuất excel" hoi="3" Width="100px" OnClick="return cc_ma_cc_P_EXCEL();form_P_LOI();" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã kiểu công <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" kieu_chu="True" kt_xoa="G" MaxLength="20"
                                onchange="cc_ma_cc_P_KTRA('MA')" ten="Mã kiểu công" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Tên kiểu công <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" MaxLength="100"
                                ten="Tên kiểu công" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Kiểu công buổi sáng <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="SANG" ten="Kiểu công buổi sáng" CssClass="form-control css_list" runat="server" ktra="DT_CC" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Kiểu công buổi chiều <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="CHIEU" ten="Kiểu công buổi chiều" CssClass="form-control css_list" runat="server" ktra="DT_CC" kt_xoa="X" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Kiểu làm việc<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="loai" ten="Loại" runat="server" CssClass="form-control css_list" lke="Làm việc cả ngày,Làm việc nửa ngày,Nghỉ cả ngày,Nghỉ lễ" tra="LV,LVN,N,NL" />
                        </div>
                    </div>

                    <div style="display: none;">
                        <Cthuvien:so ID="tyle" ten="Tỷ lệ" runat="server" CssClass="form-control css_ma" kt_xoa="X" Width="80px" />
                        <Cthuvien:so ID="tien2" runat="server" ten="Tiền công" kt_xoa="X" CssClass="css_form" Width="80px" />
                        <Cthuvien:kieu ID="ngoai" runat="server" CssClass="form-control css_ma_c" Width="30px" Text="K"
                            lke="C,K" ToolTip="C-Có,K-Không" kt_xoa="true" />
                        <Cthuvien:DR_list ID="hinhthuc" ten="Hình thức" runat="server" CssClass="form-control css_list"
                            lke="Chấm theo công nhật,Chấm theo công giờ,Chấm theo công nhật hưởng thêm tiền,Chấm theo tiền/công(giờ),Chấm theo công nhật và hưởng 1 vài loại phụ cấp"
                            tra="C,G,1P,KG,CP" />
                        <Cthuvien:so ID="tien" runat="server" ten="Tiền công" kt_xoa="X" CssClass="form-control css_ma" Width="80px" />
                        <Cthuvien:so ID="conggio" runat="server" ten="công (giờ)" kt_xoa="X" CssClass="form-control css_ma" Width="30px" Text="1" />
                        <Cthuvien:so ID="conggio2" runat="server" ten="công (giờ)" kt_xoa="X" CssClass="form-control css_ma" Width="30px" Text="1" />
                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                            CssClass="table gridX" loai="N" cot="mapc,tenpc,hso" hangKt="8" gchuId="gchu" ctrT="so_tt" ctrS="nhap" hamUp="cc_ma_cc_pcap_Update">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:TemplateField HeaderText="Mã Phụ cấp" HeaderStyle-Width="90px">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="mapc" runat="server" Width="90px" CssClass="css_Gma_c" kieu_chu="true"
                                            f_tkhao="~/App_form/tl/ma/tl_tlap_pcap.aspx" ktra="ns_tl_tlap_pcap,ma,ten,gtri" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Tên phụ cấp" DataField="tenpc" HeaderStyle-Width="160px" />
                                <asp:TemplateField HeaderText="Hệ số" HeaderStyle-Width="165px">
                                    <ItemTemplate>
                                        <Cthuvien:ma ID="hso" runat="server" Width="165px" CssClass="css_Gso" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </Cthuvien:GridX>
                        <Cthuvien:so ID="anca" runat="server" CssClass="form-control css_ma" kt_xoa="X" so_tp="2" />

                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Trạng thái <span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="trangthai" ten="Trạng thái" runat="server" CssClass="form-control css_list" lke="Áp dụng,Ngừng áp dụng" tra="A,N" />

                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="mota" runat="server" Rows="2" ten="Mô tả" kt_xoa="X" TextMode="MultiLine" CssClass="form-control css_nd" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Text="Làm mới" hoi="4" Width="90px" OnClick="return cc_ma_cc_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Text="Ghi" Width="90px" OnClick="return cc_ma_cc_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" class="bt_action" anh="K" Text="Chọn" Width="90px" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Text="Xóa" Width="90px" OnClick="return cc_ma_cc_P_XOA();form_P_LOI();" />
                        <div style="display: none;">
                            <Cthuvien:nhap ID="XuatExcel" runat="server" Width="90px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1100,550" />
    </div>
</asp:Content>
