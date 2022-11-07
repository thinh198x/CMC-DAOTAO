<%@ Page Language="C#" AutoEventWireup="true" CodeFile="daotao_ma.aspx.cs" Inherits="f_daotao_ma"
    Title="daotao_ma" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Cthuvien:ma" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>


            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_ct">
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_lke" Width="100%" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" hangKt="15" hamRow="GR_lke_RowChange() "  cotAn="ten_ta,ngay_gt,ten_vt,ma"
                                loai="X">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="ma_dvi" HeaderText="Đơn vị" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ma_cd" HeaderText="Mã chức danh" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gnd" />
                                        <asp:BoundField DataField="ma" HeaderText="Mã" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="ten" HeaderText="Tên" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ngay_tl" HeaderText="Ngày thành lập" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField DataField="ngay_ad" HeaderText="Ngày áp dụng" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="Ctr_khud_divL1" runat="server" loai="X" gridId="GR_lke" ham="P_LKE()" />
                    </div>
                      <div class="list_bt_action">
                        <Cthuvien:nhap ID="xuatExel" runat="server" Text="Xuất Excel" class="bt_action" anh="K"  Title="Ấn nút để xuất thông tin ra Excel" OnServerClick="nhap_Click" />
                    </div>
                    </div>

                    <div class="b_right col_50 inner" id="UPa_tk">
                          <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Mã đơn vị<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ma" runat="server" CssClass="form-control css_ma"
                                kt_xoa="G" onfocusout="P_KTRA('MA')" MaxLength="20" Enabled="false"></Cthuvien:ma>
                        </div>
                    </div>
                   
                  <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Ngày thành lập<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_TL" runat="server" kieu_luu="S" CssClass="form-control css_ma_c icon_lich"
                                kt_xoa="X" ten="Từ ngày" />
                        </div>
                    </div>
                        <div class="b_right form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Ngày áp dụng<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_AD" runat="server" kieu_luu="S" CssClass="form-control css_ma_c icon_lich"
                                kt_xoa="X" ten="Đến ngày" />
                        </div>
                    </div>

                        

                        <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="ghi_chu" runat="server" ten="Mô tả" ToolTip="Mô tả" CssClass="form-control css_ma" kt_xoa="X" Height="50px" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Mã chức danh</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ma_cd" f_tkhao="~/App_form/daotao-2022/Ntduc_test/ntduc_bai2.aspx" runat="server" CssClass="form-control css_ma" kieu_chu="True" kt_xoa="G" ten="Nhóm chức danh" BackColor="#f6f7f7"
                                placeholder="Nhấn (F1)" Width="200px" />
                            <Cthuvien:ma ID="ten" runat="server" CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="G" />
                        </div>
                    </div>

                            <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" class="bt_action" anh="K" OnClick="P_MOI();form_P_LOI('');" Title="Ấn nút để làm mới" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" OnClick="P_NH();form_P_LOI('');" Title="Ấn nút nhập để nhập mới" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" anh="K" OnClick="return P_XOA();form_P_LOI();" Title="Xóa dòng thông tin đang chọn" />
                        <%--<Cthuvien:nhap ID="file" runat="server" Text="File" class="bt_action" anh="K" OnClick="nhap_file();form_P_LOI('');" Title="Import" />--%>
                    </div>
                          <div style="display: none">
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" /> <%--ID upper bắt buộc nhập--%>
                    </div>
                </div>

            </div>
        
    </div>   
            </div>
        

    <Cthuvien:an ID="kthuoc" runat="server" Value="900,550" />
</asp:Content>
