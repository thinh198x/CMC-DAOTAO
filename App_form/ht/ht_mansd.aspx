<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ht_mansd.aspx.cs" Inherits="f_ht_mansd"
    Title="ht_mansd" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Người sử dụng" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Mã đăng nhập</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ma_tk" runat="server" CssClass="form-control css_ma" kt_xoa="X" ten="Mã nhóm quyền" ToolTip="Mã nhóm quyền" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_30">Tên đăng nhập</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ten_tk" runat="server" CssClass="form-control css_ma" kt_xoa="X" ten="Tên nhóm quyền" ToolTip="Tên nhóm quyền" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="timkiem" runat="server" anh="K" class="bt_action" Text="Tìm kiếm" hoi="0" OnClick="return ht_mansd_P_LKE('K');form_P_LOI('');" />
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                loai="X" hangKt="28" hamRow="ht_mansd_GR_lke_RowChange()" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="25%" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="40%" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="qu" HeaderStyle-Width="35%" ItemStyle-CssClass="css_Gnd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ht_mansd_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_15">Đơn vị</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="dvi" ten="Đơn vị" runat="server" kieu="S" CssClass="form-control css_list"
                                ktra="DT_DVI" onchange="ht_mansd_P_LKE('C')" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form" style="display: none">
                        <span class="standard_label b_left col_15">Phòng</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="phong" ten="Phòng" runat="server" kieu="S" CssClass="form-control css_list"
                                ktra="DT_PHONG" Width="275px" />
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left width_common form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã NSD</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" runat="server" CssClass="form-control css_ma" MaxLength="10"
                                    kieu_chu="True" kt_xoa="G" ToolTip="Mã để quản lý NSD. Phải là duy nhất trong đơn vị - giới hạn 10 ký tự" ten="mã NSD"
                                    onchange="ht_mansd_P_KTRA('MA')" />
                            </div>
                        </div>
                        <div class="b_right width_common form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã đăng nhập</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA_LOGIN" runat="server" CssClass="form-control css_ma" MaxLength="50"
                                    kieu_chu="True" kt_xoa="X" ToolTip="Mã để NSD đăng nhập vào hệ thống. Phải là duy nhất trong toàn hệ thống"
                                    ten="mã đăng nhập" onchange="ht_mansd_P_KTRA('MA_LOGIN')" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left width_common form-group iterm_form">
                            <span class="standard_label b_left col_30">Tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" runat="server" CssClass="form-control css_ma" kieu_unicode="True"
                                    kt_xoa="X" ten="tên NSD" />
                            </div>
                        </div>
                        <div class="b_right width_common form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Password</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="pas" runat="server" CssClass="form-control css_ma" kt_xoa="X" TextMode="Password" />
                            </div>
                        </div>
                        <div class="b_right width_common form-group iterm_form" style="display: none">
                            <span class="standard_label lv2 b_left col_30">Password</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="pas_goc" runat="server" CssClass="form-control css_ma" kt_xoa="X" TextMode="Password" MaxLength="150" />
                            </div>
                        </div>
                    </div>

                    <div id="NPa" runat="server" class="navi_tabngang width_common">
                        <Cthuvien:tab ID="NPa_dk" runat="server" CssClass="css_tab_ngang_ac"
                            Width="125px" Height="17px" Text="Nghiệp vụ" ham="ht_mansd_P_NPA('dk')" />
                        <Cthuvien:tab ID="NPa_nhom" runat="server" CssClass="css_tab_ngang_de"
                            Width="125px" Height="17px" Text="Nhóm" ham="ht_mansd_P_NPA('nhom')" />
                        <Cthuvien:tab ID="NPa_dvi" runat="server" CssClass="css_tab_ngang_de" Width="125px" Height="17px"
                            ToolTip="Danh sách đơn vị NSD quản lý" Text="Đơn vị" ham="ht_mansd_P_NPA('dvi')" />
                        <Cthuvien:tab ID="NPa_bcao" runat="server" CssClass="css_tab_ngang_de"
                            Width="125px" Height="17px" Text="Báo cáo" ham="ht_mansd_P_NPA('bcao')" />
                    </div>
                    <div>
                        <asp:Panel ID="Pa_dk" runat="server">
                            <div class="col_3_iterm width_common" style="padding: 10px 0px 10px 0px">
                                <div class="b_left width_common form-group iterm_form">
                                    <span class="standard_label b_left col_15">Phân hệ</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="phanhe" ten="Phân hệ" runat="server" kieu="S" CssClass="form-control css_list" ktra="DT_PHANHE"
                                            onchange="ht_mansd_P_CHUYEN_HANG()" />
                                    </div>
                                </div>
                                <div class="b_left width_common form-group iterm_form">
                                    <span class="standard_label lv2 b_left col_15">Tên</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="ten_form" runat="server" CssClass="form-control css_ma" kt_xoa="X" ten="Năm" ToolTip="Năm" kieu_unicode="true"
                                            onchange="ht_mansd_P_CHUYEN_HANG()" />
                                    </div>
                                </div>
                                <div class="b_left form-group iterm_form">
                                    <span class="standard_label b_left lv2 col_20"></span>
                                    <div class="input-group">
                                        <Cthuvien:kieu ID="full" runat="server" lke=",X" Width="30px" CssClass="form-control css_ma_c" Text="" />
                                        <span class="standard_label b_left lv2 col_40">Full quyền</span>
                                    </div>
                                </div>
                            </div>
                            <div class="grid_table width_common">
                                <div <%--style="overflow-y: scroll; height: 370px"--%>>
                                    <Cthuvien:GridX ID="GR_nv" runat="server" PageSize="1" CssClass="table gridX" loai="X" Width="100%" AutoGenerateColumns="false"
                                        cot="ten,ghi,xem,xoa,pd,in,mo_cpd,active,export,MD,NV" cotAn="MD,NV" hangKt="20">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField HeaderText="Nghiệp vụ" DataField="ten" HeaderStyle-Width="40%" ItemStyle-CssClass="css_Gnd" />
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text="Ghi" CssClass="text_tb"></asp:Label><br />
                                                    <br />
                                                    <input id="chon_all" type="checkbox" onclick="CheckAll(this, 'GHI');" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <Cthuvien:kieu ID="ghi" runat="server" CssClass="css_Gma_c" lke="C,K" Text="C" Width="100%" ToolTip="Quyền nhập/ghi dữ liệu: C-Có, K-Không" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text="Xem" CssClass="text_tb"></asp:Label><br />
                                                    <br />
                                                    <input id="chon_all" type="checkbox" onclick="CheckAll(this, 'XEM')" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <Cthuvien:kieu ID="xem" runat="server" CssClass="css_Gma_c" lke="C,K" Text="C" Width="100%" ToolTip="Quyền xem dữ liệu: C-Có, K-Không" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text="Xóa" CssClass="text_tb"></asp:Label><br />
                                                    <br />
                                                    <input id="chon_all" type="checkbox" onclick="CheckAll(this, 'XOA')" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <Cthuvien:kieu ID="xoa" runat="server" CssClass="css_Gma_c" lke="C,K" Text="C" Width="100%" ToolTip="Quyền xóa dữ liệu: C-Có, K-Không" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text="Phê duyệt" CssClass="text_tb"></asp:Label><br />
                                                    <br />
                                                    <input id="chon_all" type="checkbox" onclick="CheckAll(this, 'PD')" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <Cthuvien:kieu ID="PD" runat="server" CssClass="css_Gma_c" lke="C,K" Text="C" Width="100%" ToolTip="Quyền phê duyệt dữ liệu: C-Có, K-Không" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text="In biểu mẫu" CssClass="text_tb"></asp:Label><br />
                                                    <br />
                                                    <input id="chon_all" type="checkbox" onclick="CheckAll(this, 'IN')" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <Cthuvien:kieu ID="in" runat="server" CssClass="css_Gma_c" lke="C,K" Text="C" Width="100%" ToolTip="Quyền in biểu mẫu: C-Có, K-Không" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text="Mở chờ phê duyệt" CssClass="text_tb"></asp:Label><br />
                                                    <input id="chon_all" type="checkbox" onclick="CheckAll(this, 'MO_CPD')" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <Cthuvien:kieu ID="mo_cpd" runat="server" CssClass="css_Gma_c" lke="C,K" Text="C" Width="100%" ToolTip="Quyền mở chờ phê duyệt: C-Có, K-Không" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text="Đóng/Mở bảng công/lương" CssClass="text_tb"></asp:Label>
                                                    <input id="chon_all" type="checkbox" onclick="CheckAll(this, 'ACTIVE')" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <Cthuvien:kieu ID="active" runat="server" CssClass="css_Gma_c" lke="C,K" Text="C" Width="100%" ToolTip="Quyền quản lý nghiệp vụ: C-Có, K-Không" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text="Xuất báo cáo" CssClass="text_tb"></asp:Label><br />
                                                    <br />
                                                    <input id="chon_all" type="checkbox" onclick="CheckAll(this, 'EXPORT')" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <Cthuvien:kieu ID="export" runat="server" CssClass="css_Gma_c" lke="C,K" Text="C" Width="100%" ToolTip="Quyền xuất báo cáo: C-Có, K-Không" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="MD" />
                                            <asp:BoundField DataField="NV" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <ctr_khud_divL:ctr_khud_divL ID="GR_nv_slide" runat="server" ham="ht_mansd_P_CHUYEN_HANG()" gridId="GR_nv" />
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="Pa_nhom" runat="server" Style="display: none;">
                            <Cthuvien:GridX ID="GR_nhom" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" Width="100%"
                                loai="N" hangKt="15" cot="CHON,TEN,NHOM" cotAn="NHOM" ctrT="TEN" ctrS="nhap">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="nhom_chon" runat="server" Width="100%" CssClass="css_Gma_c" lke="X," ToolTip="Chọn nhóm" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Tên" DataField="TEN" HeaderStyle-Width="90%" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="NHOM" />
                                </Columns>
                            </Cthuvien:GridX>
                        </asp:Panel>
                        <asp:Panel ID="Pa_dvi" runat="server" Style="display: none;">
                            <Cthuvien:GridX ID="GR_dvi" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                loai="L" hangKt="15" cotAn="DVI" ctrT="TEN" cot="dvi_chon,ten,dvi" ctrS="nhap" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="dvi_chon" runat="server" Width="100%" CssClass="css_Gma_c" lke="X," ToolTip="Chọn nhóm" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Tên" DataField="ten" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="DVI" />
                                </Columns>
                            </Cthuvien:GridX>
                            <div id="id_chen" style="display: none">
                                <div class="btex_luoi b_right">
                                    <ul>
                                        <li>
                                            <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt dòng đã chọn" onclick="return ht_mansd_CatDong();" />
                                        </li>
                                        <li>
                                            <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn dòng" onclick="return ht_mansd_ChenDong();" />
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="Pa_bcao" runat="server" Style="display: none;">
                            <div class="width_common" style="padding: 10px 0px 10px 0px">
                                <div class="b_left width_common form-group iterm_form">
                                    <span class="standard_label b_left col_15">Báo cáo</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="loai_sl" ten="Loại báo cáo" runat="server" kieu="S" CssClass="form-control css_list" Width="50%" ktra="DT_LOAI"
                                            onchange="ht_mansd_P_KTRA('loai_sl')" />
                                    </div>
                                </div>
                            </div>
                            <Cthuvien:GridX ID="GR_bcao" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" Width="100%"
                                loai="N" hangKt="15" cot="CHON,ten,MA_BC,rep,ddan,excel,LOAI" cotAn="ma_bc,rep,ddan,excel,loai" ctrT="TEN" ctrS="nhap">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderStyle-Width="10%">
                                        <HeaderTemplate>
                                            <input id="chon_all" type="checkbox" onclick="CheckAll_BC(this)" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="chon" runat="server" Width="100%" CssClass="css_Gma_c" lke="X," ToolTip="Chọn nhóm" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="90%" ItemStyle-CssClass="css_Gnd" />
                                    <asp:BoundField DataField="ma_bc" />
                                    <asp:BoundField DataField="rep" />
                                    <asp:BoundField DataField="ddan" />
                                    <asp:BoundField DataField="excel" />
                                    <asp:BoundField DataField="loai" />
                                </Columns>
                            </Cthuvien:GridX>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_bcao_slide" runat="server" loai="N" gridId="GR_bcao" />
                        </asp:Panel>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ht_mansd_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ht_mansd_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ht_mansd_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Width="70px" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                    </div>

                    <div style="display: none">
                        <img id="dia" runat="server" alt="" src="~/images/bitmaps/dia.gif"
                            title="Lấy số liệu vào từ File" onclick="return ht_mansd_FILE();" />
                        <Cthuvien:dao ID="klk" runat="server" CssClass="css_kh_de_da" Width="85px"
                            ForeColor="#D5E0E3" lke="Nhân sự,Tất cả" Text="Nhân sự" nhap="false"
                            ToolTip="Liệt kê theo Modul: Nhân sự, tất cả (Click để thay đổi)" AutoPostBack="true" />
                    </div>
                    <div style="display: none">
                        <img id="tiep" runat="server" alt="" src="~/images/icon/phai.png"
                            title="Chọn nghiệp vụ NSD" onclick="return ht_mansd_Chon();" />
                    </div>
                </div>

            </div>
        </div>
    </div>

    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1040,830" />
        <Cthuvien:an ID="all_ghi" runat="server" />
        <Cthuvien:an ID="all_xem" runat="server" />
        <Cthuvien:an ID="all_xoa" runat="server" />
        <Cthuvien:an ID="all_pd" runat="server" />
        <Cthuvien:an ID="all_in" runat="server" />
        <Cthuvien:an ID="all_moPd" runat="server" />
        <Cthuvien:an ID="all_dong" runat="server" />
        <Cthuvien:an ID="all_xuatbc" runat="server" />
        <Cthuvien:an ID="all_Bc" runat="server" />
    </div>
</asp:Content>
