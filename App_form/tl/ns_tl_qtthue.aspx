<%@ Page Title="ns_tl_qtthue" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tl_qtthue.aspx.cs" Inherits="f_ns_tl_qtthue" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Ủy quyền quyết toán thuế TNCN" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_30 inner" style="display: none;" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="L" hangKt="15" cotAn="so_id" hamRow="ns_tl_qtthue_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Năm" DataField="nam" ItemStyle-CssClass="css_Gma_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_tl_qtthue_P_LKE('K')" />
                    </div>
                </div>
                <div class="width_common inner" id="UPa_ct">
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30"></span>
                            <span class="standard_label lv2 b_left col_10">Năm</span>
                            <div class="input-group b_left col_10">
                                <%--<Cthuvien:ma ID="NAM" ten="Năm" kieu_so="true" runat="server" CssClass="form-control css_ma" kt_xoa="K" MaxLength="15" onchange="ns_tl_qtthue_P_KTRA('NAM')" Width="135px" gchu="gchu" />--%>
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" kt_xoa="X" Width="100px" onchange="ns_tl_qtthue_P_KTRA('NAM');" CssClass="form-control css_list" ktra="DT_NAM" />
                            </div>
                            <%--<Cthuvien:nhap ID="tonghop" runat="server" Text="Tổng hợp" class="bt_action" OnClick="ns_tl_qtthue_P_KTRA('NAM');form_P_LOI();" Width="100px" anh="K" />--%>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="N" cot="so_the,ten,cdanh,phong,uyquyen" hangKt="15">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Mã nhân viên(*)">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="SO_THE" runat="server" CssClass="css_Gma" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                ktra="ns_cb,so_the,ten" kt_xoa="G" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Tên nhân viên(*)" DataField="TEN" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="20%" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="CDANH" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="25%" />
                                    <asp:BoundField HeaderText="Phòng" DataField="PHONG" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="25%" />
                                    <asp:TemplateField HeaderText="Có ủy quyền quyết toán thuế" HeaderStyle-Width="15%">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="uyquyen" runat="server" lke="X," kt_xoa="X" ToolTip="X - Có ủy quyền,  - Không ủy quyền" CssClass="css_Gma_c" Text="X" Width="15%" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_tl_qtthue_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_tl_qtthue_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_tl_qtthue_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Thêm 1 dòng mới" onclick="return ns_tl_qtthue_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <%--<Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" class="bt_action" OnClick="return ns_tl_qtthue_P_NH();form_P_LOI();" Width="70px" anh="K" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" OnClick="return ns_tl_qtthue_P_MOI();form_P_LOI();" Width="70px" anh="K" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" OnClick="return ns_tl_qtthue_P_XOA();form_P_LOI();" Width="70px" anh="K" />
                        <Cthuvien:nhap ID="XuatFileMau" runat="server" Text="File mẫu" class="bt_action" OnServerClick="nhap_Click" Width="100px" anh="K" />
                        <Cthuvien:nhap ID="NhapFileMau" runat="server" Text="Import" class="bt_action" OnClick="return ns_tl_qtthue_P_Import();form_P_LOI();" Width="80px" anh="K" />--%>
                        <Cthuvien:nhap ID="XuatExcel" runat="server" Text="Xuất Excel" class="bt_action" OnServerClick="nhap_Click_Excel" Width="100px" anh="K" />
                    </div>
                </div>

            </div>
        </div>
    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="973,650" />
    </div>
</asp:Content>
