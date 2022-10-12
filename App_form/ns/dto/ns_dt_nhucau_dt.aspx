<%@ Page Title="ns_dt_nhucau_dt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_nhucau_dt.aspx.cs" Inherits="f_ns_dt_nhucau_dt" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập mã đào tạo" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="ns_dt_nhucau_dt_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên" DataField="ten" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Loại" DataField="loaidt" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                            ham="ns_dt_nhucau_dt_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Loại đào tạo<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="LOAIDT" runat="server" CssClass="form-control css_list"
                                    ten="Đối tượng cư trú" tra="HN,NB,BN" lke="Đào tạo hội nhập,Đào tạo nội bộ,Đào tạo bên ngoài" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Mã đào tạo<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" ten="Mã đợt khảo sát" runat="server" kt_xoa="K" kieu_chu="true" CssClass="form-control css_ma"
                                     gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Tên đào tạo<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Tên đào tạo" kt_xoa="X" kieu_unicode="true"
                                    runat="server" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="tt" runat="server" CssClass="form-control css_list"
                                    ten="Trạng thái" tra="A,N" lke="Áp dụng,Ngừng áp dụng" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Chức danh<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="CDANH" placeholder="Nhấn (F1)" runat="server" Width="200px" ten="Chức danh" CssClass="form-control css_ma"
                                    BackColor="#f6f7f7" kieu_chu="true" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_ma_vtcdanh.aspx"
                                    kt_xoa="X" ktra="ns_ma_cdanh,ma,ten" ToolTip="Chức danh" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" Width="100%" loai="N" cotAn="ma_hinhthuc" cot="ma_hinhthuc,ten_hinhthuc" hangKt="10">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="ma_hinhthuc" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Hình thức đào tạo(*)">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ten_hinhthuc" placeholder="Nhấn (F1)" runat="server" Width="100%" CssClass="css_Gma"
                                                f_tkhao="~/App_form/ns/ma/ns_ma_htdt.aspx" ktra="ns_ma_htdt,ma,ten" ReadOnly="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_nhucau_dt_sp_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_nhucau_dt_sp_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_nhucau_dt_sp_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn thêm dòng" onclick="return ns_dt_nhucau_dt_sp_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_dt_nhucau_dt_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_dt_nhucau_dt_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_dt_nhucau_dt_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" class="bt_action" anh="K" OnClick="return form_P_TRA_HOI_CHON('MA,TEN');form_P_LOI();" Width="70px" />
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="ID_CDANH" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="960,680" />
    </div>
</asp:Content>
