<%@ Page Title="ns_tl_dtuong_bluong" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_tl_dtuong_bluong.aspx.cs" Inherits="f_ns_tl_dtuong_bluong" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập đối tượng bảng lương" />
                <img class="b_right" src="../../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Bảng lương<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_list ID="ma_bluong_tk" ten="Loại lương" lke=",Bảng lương Back,Bảng lương Sale,Bảng lương cộng tác viên BB,Bảng lương cộng tác viên BS,Bảng lương thực tập sinh"
                                tra=",BACK,SALE,BB,BS,TTS" runat="server" onchange="ns_tl_dtuong_bluong_P_LKE()" CssClass="form-control css_list" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-wrap: normal">
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="22" cotAn="so_id,ma_bluong"
                                hamRow="ns_tl_dtuong_bluong_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="SO_ID" DataField="so_id" />
                                    <asp:BoundField HeaderText="Mã bảng lương" DataField="ma_bluong" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Bảng lương" DataField="ten_bluong" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày Áp dụng" DataField="ngay_ad" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_tl_dtuong_bluong_P_LKE('K')" />
                        </div>
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Bảng lương<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="MA_BLUONG" ten="Loại lương" lke="Bảng lương Back,Bảng lương Sale,Bảng lương cộng tác viên BB,Bảng lương cộng tác viên BS,Bảng lương thực tập sinh"
                                    tra="BACK,SALE,BB,BS,TTS" runat="server" CssClass="form-control css_list" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày áp dụng<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY_AD" ten="Ngày áp dụng" runat="server" CssClass="form-control icon_lich"
                                    kt_xoa="X" ToolTip="Ngày áp dụng" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span></span></div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_20">Khối<span class="require">*</span></span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="khoi" ktra="DT_KHOI" kt_xoa="L" ten="Khối" runat="server"
                                CssClass="form-control css_list" ToolTip="Khối"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="width_common pv_bl"><span>Đối tượng nhân viên</span></div>
                    <div class="grid_table width_common">
                        <div style="overflow-wrap: normal">
                            <Cthuvien:GridX ID="GR_Dtnv" runat="server" AutoGenerateColumns="false" PageSize="1" loai="N" Width="100%"
                                CssClass="table gridX" hangKt="6" cot="chon_dtnv,ma_dtnv,ten_dtnv">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="chon_dtnv" runat="server" Width="100%" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Mã" DataField="ma_dtnv" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tên" DataField="ten_dtnv" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <button onclick="return ns_tl_dtuong_bluong_THEM_MOI();form_P_LOI();" class="bt_action">Làm mới</button>
                        <button onclick="return ns_tl_dtuong_bluong_them();form_P_LOI();" class="bt_action">Thêm điều kiện</button>
                    </div>

                    <div class="grid_table width_common">
                        <div style="height: 400px; overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_Khoi" runat="server" AutoGenerateColumns="false" PageSize="1" loai="N" Width="100%"
                                CssClass="table gridX" hangKt="50" cot="ma_khoi,ten_khoi,ma_dtnv,ten_dtnv">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã khối" DataField="ma_khoi" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tên khối" DataField="ten_khoi" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã đối tượng NV" DataField="ma_dtnv" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tên đối tượng NV" DataField="ten_dtnv" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img alt="" src="../../../../images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_tl_dtuong_bluong_P_HangLen();" />
                                </li>
                                <li>
                                    <img alt="" src="../../../../images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_tl_dtuong_bluong_P_HangXuong();" />
                                </li>
                                <li>
                                    <img alt="" src="../../../../images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_tl_dtuong_bluong_P_CatDong();" />
                                </li>
                                <li>
                                    <img alt="" src="../../../../images/bitmaps/chen.gif" title="Thêm 1 dòng mới" onclick="return ns_tl_dtuong_bluong_P_chenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>

                    <div class="list_bt_action">
                        <button onclick="return ns_tl_dtuong_bluong_P_MOI('XGL');form_P_LOI();" class="bt_action">Làm mới</button>
                        <button onclick="return ns_tl_dtuong_bluong_P_NH();form_P_LOI();" class="bt_action">Nhập</button>
                        <button class="bt_action" onclick="return ns_tl_dtuong_bluong_P_XOA();form_P_LOI();">Xóa</button>

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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1200,800" />
    </div>
</asp:Content>
