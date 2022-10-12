<%@ Page Title="ti_bc_dong" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ti_bc_dong.aspx.cs" Inherits="f_ti_bc_dong" %>

<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Báo cáo động" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common">
                <div class="col_2_iterm width_common">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Loại báo cáo</span>
                        <div class="input-group">
                            <Cthuvien:DR_lke ID="NHOM" ktra="DT_NHOM" runat="server" Width="150px" kt_xoa="X"
                                onchange="ti_bc_dong_P_KTRA('NHOM')" ten="Loại báo cáo"></Cthuvien:DR_lke>
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                    </div>
                </div>
            </div>
            <div class="b_left width_common" id="TPu">
                <div id="NPa" runat="server" class="navi_tabngang width_common">
                    <Cthuvien:tab ID="NPa_dk" runat="server" CssClass="css_tab_ngang_ac" Width="150px" ham="ti_bc_dong_P_NPA('dk')"
                        Text="Điều kiện tìm kiếm" />
                    <Cthuvien:tab ID="NPa_kq" runat="server" CssClass="css_tab_ngang_de" Width="150px" ham="ti_bc_dong_P_NPA('kq')"
                        Text="Chọn kết quả hiển thị" />
                </div>
                <div>
                    <asp:Panel ID="Pa_dk" runat="server" Style="display: block;">
                        <div>
                            <div class="b_left col_40 inner">
                                <div class="b_left width_common form-group iterm_form">
                                    <span class="standard_label b_left col_30">Kết hợp</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_list ID="KH" ten="Kết hợp" runat="server" DataTextField="ten" DataValueField="ma"
                                            CssClass="form-control css_list" kieu="S" tra="AND,OR" lke="Và,Hoặc">
                                        </Cthuvien:DR_list>
                                    </div>
                                </div>
                                <div class="b_left width_common form-group iterm_form">
                                    <span class="standard_label b_left col_30">Mở khối lệnh</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_list ID="ng_mo" ten="Mở ngoặc đơn" runat="server" DataTextField="ten" DataValueField="ma"
                                            CssClass="form-control css_list" kieu="S" tra=",(" lke=",(">
                                        </Cthuvien:DR_list>
                                    </div>
                                </div>
                                <div class="b_left width_common form-group iterm_form">
                                    <span class="standard_label b_left col_30">Tên cột	</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_lke ID="TEN" runat="server" kt_xoa="X" CssClass="form-control css_list" ktra="DT_BCDT" DataValueField="ma" DataTextField="ten" />
                                    </div>
                                </div>
                                <div class="b_left width_common form-group iterm_form" style="display: none">
                                    <span class="standard_label b_left col_30">Phủ định</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_list ID="PD" ten="Phủ định" runat="server" DataTextField="ten" DataValueField="ma"
                                            CssClass="form-control css_list" kieu="S" tra="CO,NOT" lke="Có,Không">
                                        </Cthuvien:DR_list>
                                    </div>
                                </div>
                                <div class="b_left width_common form-group iterm_form">
                                    <span class="standard_label b_left col_30">Toán tử</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_list ID="TT" ten="Toán tử" runat="server" DataTextField="ten" DataValueField="ma"
                                            CssClass="form-control css_list" kieu="S" lke="Bằng,Lơn hơn,Nhỏ hơn,Chứa" tra="=,LH,NH,LIKE" />
                                    </div>
                                </div>
                                <div class="b_left width_common form-group iterm_form">
                                    <span class="standard_label b_left col_30">Giá trị</span>
                                    <div class="input-group">
                                        <Cthuvien:ma ID="GT" runat="server" CssClass="form-control css_ma" kt_xoa="G" kieu_unicode="true" />

                                    </div>
                                </div>
                                <div class="b_left width_common form-group iterm_form">
                                    <span class="standard_label b_left col_30">Đóng khối lệnh</span>
                                    <div class="input-group">
                                        <Cthuvien:DR_list ID="ng_dong" ten="Đóng ngoặc đơn" runat="server" DataTextField="ten" DataValueField="ma"
                                            CssClass="form-control css_list" kieu="S" lke=",)" tra=",)">
                                        </Cthuvien:DR_list>
                                    </div>
                                </div>
                                <div class="b_left width_common form-group iterm_form">
                                    <span class="standard_label b_left col_30"></span>
                                    <div class="input-group">
                                        <button onclick="return ti_bc_dong_THEM_DK();" class="bt_action">Thêm điều kiện</button>
                                    </div>
                                </div>
                            </div>
                            <div class="b_right col_60 inner">
                                <div class="grid_table width_common">
                                    <Cthuvien:GridX ID="GR_ct" Width="100%" runat="server" loai="N" AutoGenerateColumns="false" PageSize="1" cotAn="kh,ten,pd,tt,loai,pd_ten" CssClass="table gridX" hangKt="14">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField HeaderText="Kết hợp" DataField="kh_ten" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Ngoặc mở" DataField="ng_mo" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField HeaderText="Tên cột" DataField="ten_ten" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Phủ định" DataField="pd_ten" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Toán tử" DataField="tt_ten" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Giá trị" DataField="gt" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="kh" DataField="kh" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="ten" DataField="ten" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="pd" DataField="pd" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="tt" DataField="tt" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="loai" DataField="loai" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Ngoặc đóng" DataField="ng_dong" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma_c" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Pa_kq" runat="server" Style="display: none;">
                        <div class="grid_table width_common">
                            <div id="UPa_lke" style="height: 420px; overflow-y: scroll;">
                                <Cthuvien:GridX ID="GR_lke" runat="server" loai="N" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                    hangKt="12" CssClass="table gridX" cot="chon,ma,ten,nhom,loai" cotAn="ma,nhom,loai">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                            <HeaderTemplate>
                                                <input id="chon_all" type="checkbox" onclick="CheckAll(this)" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="40px" />
                                        <asp:BoundField HeaderText="Dữ liệu hiển thị" DataField="ten" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="nhom" DataField="nhom" />
                                        <asp:BoundField HeaderText="loai" DataField="loai" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                        </div>
                    </asp:Panel>

                </div>
            </div>
            <div class="list_bt_action">
                <div style="text-align: center">
                    <button class="bt_action" onclick="return ti_bc_dong_P_TIM();form_P_LOI();"><span class="txUnderline">X</span>uất báo cáo</button>
                </div>
                <div id="id_tk" class="btex_luoi b_right">
                    <ul>
                        <li>
                            <img alt="" src="../../images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ti_bc_dong_HangLen();" />
                        </li>
                        <li>
                            <img alt="" src="../../images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ti_bc_dong_HangXuong();" />
                        </li>
                        <li>
                            <img alt="" src="../../images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ti_bc_dong_CatDong();" />
                        </li>
                    </ul>
                </div>
                <div style="display: none;">
                    <Cthuvien:nhap ID="XuatExcel" runat="server" Width="70px" Text="Export" OnServerClick="xuatExcel_Click" />
                </div>
            </div>
            <div id="UPa_gchu">
                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="anNhom" runat="server" />
        <Cthuvien:an ID="acheckall" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="950,620" />
    </div>

</asp:Content>
