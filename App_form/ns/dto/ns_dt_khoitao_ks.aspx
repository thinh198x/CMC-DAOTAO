<%@ Page Title="ns_dt_khoitao_ks" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_khoitao_ks.aspx.cs" Inherits="f_ns_dt_khoitao_ks" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Khởi tạo khảo sát" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="ns_dt_khoitao_ks_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên" DataField="ten" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Từ ngày" DataField="tu_ngay" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đến ngày" DataField="den_ngay" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_khoitao_ks_P_LKE('K')" />

                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Mã đợt khảo sát <span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" ten="Mã đợt khảo sát" kt_xoa="K" runat="server" CssClass="form-control css_ma"
                                    onchange="ns_dt_khoitao_ks_P_KTRA('MA')" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Tên đợt khảo sát<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Tên đợt khảo sát" kieu_unicode="true"
                                    runat="server" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Từ ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="tu_ngay" runat="server" ten="Từ ngày"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="den_ngay" runat="server" ten="Từ ngày"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="gridX" Width="100%" loai="N" cotAn="ma_nhucau" cot="ma_nhucau,TEN_NHUCAU" hangKt="10"
                                hamUp="ns_dt_khoitao_ks_sp_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="ma_nhucau" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Nhu cầu đào tạo">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="TEN_NHUCAU" placeholder="Nhấn (F1)" runat="server" Width="100%" CssClass="css_Gma"
                                                f_tkhao="~/App_form/ns/dto/ns_dt_nhucau_dt.aspx" ktra="ns_dt_nhucau_dt,ma,ten" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_khoitao_ks_sp_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_khoitao_ks_sp_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_khoitao_ks_sp_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chen thêm dòng" onclick="return ns_dt_khoitao_ks_sp_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_dt_khoitao_ks_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_dt_khoitao_ks_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_dt_khoitao_ks_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" class="bt_action" anh="K" OnClick="return form_P_TRA_CHON('ma,ten');form_P_LOI();" Width="70px" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1000,670" />
    </div>
</asp:Content>
