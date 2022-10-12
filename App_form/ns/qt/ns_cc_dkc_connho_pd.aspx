<%@ Page Title="ns_cc_dkc_connho_pd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_dkc_connho_pd.aspx.cs" Inherits="f_ns_cc_dkc_connho_pd" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Phê duyệt đăng ký ca nuôi con nhỏ dưới 1 tuổi" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_5_iterm width_common">
                        <div class="b_left form-group iterm_form" style="display: none;">
                            <span class="standard_label b_left col_30">Năm</span>
                            <div class="input-group">
                                <div>
                                    <Cthuvien:DR_lke ID="PHONG" ktra="DT_PHONG" ten="Phòng" kt_xoa="X" runat="server" Width="140px"></Cthuvien:DR_lke>
                                    <Cthuvien:ngay ID="NGAYD" runat="server" kieu_luu="S" CssClass="css_form_c" Width="100px"
                                        ten="Từ ngày" />
                                    <Cthuvien:ngay ID="NGAYC" runat="server" kieu_luu="S" CssClass="css_form_c" Width="100px"
                                        ten="Đến ngày" />
                                </div>
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" onchange="ns_cc_dkc_connho_pd_P_KTRA('NAM');" CssClass="form-control css_list" kt_xoa="K" ktra="DT_NAM" />

                            </div>
                        </div>
                        <%--<div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ công</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG" ten="Kỳ công" runat="server" CssClass="form-control css_list" kt_xoa="G" onchange="ns_cc_dkc_connho_pd_P_KTRA('KYLUONG')" ktra="DT_KYLUONG" />

                            </div>
                        </div>--%>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_nhap ID="tinhtrang" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0" Selected="True" Text="Chờ phê duyệt"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Đã phê duyệt"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Không phê duyệt"></asp:ListItem>
                                </Cthuvien:DR_nhap>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="so_the_tk" runat="server" CssClass="form-control css_ma" gchu="gchu" />

                            </div>
                        </div>
                        <div class="b_right lv2 form-group iterm_form">
                            <Cthuvien:nhap ID="tim" runat="server" class="bt_action" anh="K" Text="Tìm kiếm" Width="90px" OnClick="ns_cc_dkc_connho_pd_P_LKE();form_P_LOI('');" Title="Tìm kiếm" />

                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll;">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" hangKt="15" Width="100%" cotAn="SO_ID,mota,ca"
                                cot="so_id,chon,ma_nv,ho_ten,ten_cdanh,ten_phong,ngayd,ngayc,ten_ca,giod,gioc,mota,ca">
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
                                    <asp:BoundField HeaderText="Chức danh" DataField="TEN_CDANH" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng" DataField="TEN_PHONG" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Đăng ký từ ngày" DataField="NGAYD" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đăng ký đến ngày" DataField="NGAYC" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Ca làm việc" DataField="ten_ca" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Từ giờ" DataField="giod" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đến giờ" DataField="gioc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Mô tả" DataField="mota" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" /> 
                                    <asp:BoundField HeaderText="Mã ca" DataField="ca" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" /> 
                                </Columns>
                            </Cthuvien:GridX>
                            <div id="GR_lke_td">
                                <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_dkc_connho_pd_P_LKE()" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" runat="server" Text="Phê duyệt" Width="120px" class="bt_action" anh="K" title="Phê duyệt" OnClick="return ns_cc_dkc_connho_pd_P_PHEDUYET('C');form_P_LOI();" />
                        <Cthuvien:nhap ID="thanhly" runat="server" Text="Không phê duyệt" Width="130px" class="bt_action" anh="K" title="Không phê duyệt" OnClick="return ns_cc_dkc_connho_pd_P_KOPHEDUYET();form_P_LOI();" />
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

