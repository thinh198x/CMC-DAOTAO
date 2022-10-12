<%@ Page Title="ns_ths" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ths.aspx.cs" Inherits="f_ns_ths" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Túi hồ sơ" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    ktra="ns_cb,so_the,ten" ToolTip="Mã số cán bộ"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_ths_P_KTRA('SO_THE')" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_20">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten" ten="Họ tên" runat="server" CssClass="form-control css_ma"
                                    ToolTip="Họ tên" />
                            </div>
                        </div>
                    </div>
                    <div id="NPa" runat="server" class="navi_tabngang width_common">
                        <Cthuvien:tab ID="NPa_dk" runat="server" CssClass="css_tab_ngang_ac" Width="150px"
                            Height="20px" Text="Hồ sơ chính" ham="ns_ths_P_NPA('0')" />
                        <Cthuvien:tab ID="NPa_kq" runat="server" CssClass="css_tab_ngang_de" Width="180px"
                            Height="20px" Text="Bằng cấp/chứng chỉ đặc thù" ham="ns_ths_P_NPA('1')" />
                    </div>
                    <div class="width_common" style="padding: 0px 0px 20px 0px">
                        <asp:Panel ID="Pa_dk" runat="server" Style="display: block;">
                            <div class="css_divb" style="margin-right: 20px;">
                                <div class="css_divCn">
                                    <Cthuvien:GridX ID="GR_ct" runat="server" loai="N" AutoGenerateColumns="false" hangKt="15"
                                        cot="CHON,ten,batbuoc,ngay_p,ngay_n,loai,duong_dan,ma" cotAn="ma" PageSize="1" CssClass="table gridX"
                                        hamRow="ns_ths_GR_ct_RowChange()" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:TemplateField HeaderStyle-Width="80px">
                                                <HeaderTemplate>
                                                    <input id="chon_all" type="checkbox" onclick="CheckAll(this);" runat="server" />
                                                    <asp:Label ID="Label1" runat="server" Width="50px" Text="Hoàn thành" CssClass="text_tb"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <Cthuvien:kieu ID="CHON" runat="server" Width="70px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tên hồ sơ" HeaderStyle-Width="500px">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="ten" runat="server" CssClass="css_Gnd" Width="100%" ToolTip="Tên hồ sơ" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="80px">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" runat="server" Width="80px" Text="Bắt buộc" CssClass="text_tb"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <Cthuvien:kieu ID="BATBUOC" runat="server" Width="70px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ngày phải nộp">
                                                <ItemTemplate>
                                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_p" runat="server" CssClass="css_Gma_c" Width="100%" ToolTip="Ngày phải nộp" kieu_luu="I" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ngày nộp">
                                                <ItemTemplate>
                                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_n" runat="server" CssClass="css_Gma_c" Width="100%" ToolTip="Ngày nộp" kieu_luu="I" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Loại hồ sơ">
                                                <ItemTemplate>
                                                    <Cthuvien:DR_list ID="loai" runat="server" CssClass="css_Glist" lke=",Bản cứng,Bản mềm" tra=",C,M" Width="100%" ToolTip="Loại hồ sơ" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Đường dẫn">
                                                <ItemTemplate>
                                                    <Cthuvien:ma ID="duong_dan" runat="server" CssClass="css_Gnd" ToolTip="Đường dẫn file" Width="100%" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ma" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <ctr_khud_divC:ctr_khud_divC ID="Ctr_khud_divc" runat="server" loai="N" gridId="GR_ct" />
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="Pa_kq" runat="server" Style="display: none;">
                            <div class="grid_table width_common">
                                <Cthuvien:GridX ID="GR_lke" runat="server" loai="N" AutoGenerateColumns="false" PageSize="1"
                                    hangKt="15" CssClass="table gridX" cot="hthanh,loai_bc,ngay_pn,ngayn">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Hoàn thành" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <Cthuvien:kieu ID="hthanh" runat="server" Width="100%" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Hoàn thành" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Loại bằng cấp/chứng chỉ">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="loai_bc" runat="server" Width="100%" CssClass="css_Gma" Text="" ToolTip="Loại bằng cấp/chứng chỉ" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ngày phải nộp" HeaderStyle-Width="170px">
                                            <ItemTemplate>
                                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_pn" runat="server" CssClass="css_Gma_c" Width="100%" ToolTip="Ngày phải nộp" kieu_luu="I" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ngày nộp" HeaderStyle-Width="170px">
                                            <ItemTemplate>
                                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayn" runat="server" CssClass="css_Gma_c" Width="100%" ToolTip="Ngày nộp" kieu_luu="I" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <div class="btex_luoi b_right" id="id_chensp">
                                <ul>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_ths_HangLen();" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_ths_HangXuong();" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_ths_CatDong();" />
                                    </li>
                                    <li>
                                        <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Thêm 1 dòng mới" onclick="return ns_ths_chenDong('C');" />
                                    </li>
                                </ul>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_10">Nơi lưu hồ sơ</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="noi_luu" kieu_unicode="true" ten="Nơi lưu hồ sơ" runat="server" CssClass="form-control css_ma" kt_xoa="X" ToolTip="Thông tin chỗ lưu trữ hồ sơ" MaxLength="255" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_10">Mô tả</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="mota" kieu_unicode="true" ten="Mô tả" runat="server" CssClass="form-control css_ma" kt_xoa="X" ToolTip="Mô tả" MaxLength="1000" />
                            </div>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" class="bt_action" anh="K" onclick="return ns_ths_P_NH();form_P_LOI();" Width="100px" />
                          <Cthuvien:nhap ID="excel" runat="server" Text="File" class="bt_action" anh="K" OnClick="ns_ths_P_FILE();form_P_LOI('');" Title="Đính kèm file" />
                    </div>
                   
                    <div style="display: none;">
                        <Cthuvien:nhap ID="file" runat="server" Text="File" class="bt_action" anh="K" OnClick="return ns_ths_FI_NH();form_P_LOI();" Width="70px" />
                    </div>
                    <div>
                        <div id="UPa_gchu">
                            <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="900,620" />
    </div>
</asp:Content>
