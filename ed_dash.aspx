<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ed_dash.aspx.cs" Inherits="f_ed_dash"
    Title="ed_dash" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="ctr_khud_divC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="main_dashbroad">
            <div class="l_dashboad b_left">
                <div class="width_common">
                    <div class="block_l_db width_common">
                        <Cthuvien:luu ID="tenForm" runat="server" CssClass="title_dmuc width_common" Text="Thông tin gợi nhắc" />
                        <div class="b_left round_ctent">
                            <div id="NPa" runat="server" class="navi_tabngang width_common">
                                <Cthuvien:tab ID="NPa_dvi" runat="server" CssClass="css_tab_ngang_ac" Width="180px"
                                    Text="Hết hạn hợp đồng" ham="ed_dash_TDOI('D')" />
                                <Cthuvien:tab ID="NPa_giao" runat="server" CssClass="css_tab_ngang_de" Width="180px"
                                    Text="Sắp sinh nhật" ham="ed_dash_TDOI('G')" />
                            </div>
                            <div>
                                <asp:Panel ID="Pa_dvi" runat="server" Style="display: block;">
                                    <div class="b_left">
                                        <div class="css_divb c_divC">
                                            <div class="css_divCn">
                                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="X" hangKt="15" Width="100%">
                                                    <Columns>
                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                        <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                                        <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                                        <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh"  ItemStyle-CssClass="css_Gnd" />
                                                        <asp:BoundField HeaderText="Phòng ban" DataField="ten_phong" ItemStyle-CssClass="css_Gma_c" />
                                                        <asp:BoundField HeaderText="Ngày bắt đầu" DataField="ngay5" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                        <asp:BoundField HeaderText="Ngày hết hạn" DataField="ngay5" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                    </Columns>
                                                </Cthuvien:GridX>
                                            </div>
                                            <ctr_khud_divC:ctr_khud_divC ID="GR_lke_slide" loai="X" runat="server" gridId="GR_lke" ham="ed_dash_TDOI('L')" />
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Pa_giao" runat="server" Style="display: none;">
                                    <div class="b_left">
                                        <div class="css_divb c_divC">
                                            <div class="css_divCn">
                                                <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="X" hangKt="15" Width="100%">
                                                    <Columns>
                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                        <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                                        <asp:BoundField HeaderText="Tên nhân viên" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                                        <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh"  ItemStyle-CssClass="css_Gnd" />
                                                        <asp:BoundField HeaderText="Phòng ban" DataField="ten_phong"  ItemStyle-CssClass="css_Gma_c" />
                                                        <asp:BoundField HeaderText="Ngày sinh nhật" DataField="ngay5"   HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                    </Columns>
                                                </Cthuvien:GridX>
                                            </div>
                                            <ctr_khud_divC:ctr_khud_divC ID="Ctr_khud_divC1" loai="X" runat="server" gridId="GR_ct" ham="ed_dash_TDOI('L')" />
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="r_dashboad b_right">
                <div id="div_tke" class="block_r_db width_common">
                    <div class="block_tkcv">
                        <ul>
                            <li class="b_left block_xanhdtroi">
                                <div class="bts_cv">
                                    <Cthuvien:gchu ID="moi" runat="server" kt_xoa="X" CssClass="so_cv" Text="0" />
                                    <span>Tổng nhân sự</span>
                                </div>
                            </li>
                            <li class="b_right block_xanh">
                                <div class="bts_cv">
                                    <Cthuvien:gchu ID="dang" runat="server" kt_xoa="X" CssClass="so_cv" Text="0" />
                                    <span>Tuyển mới</span>
                                </div>
                            </li>
                            <li class="b_left block_vang " style="margin-bottom: 0">
                                <div class="bts_cv">
                                    <Cthuvien:gchu ID="sap" runat="server" kt_xoa="X" CssClass="so_cv" Text="0" />
                                    <span>Sắp sinh nhật</span>
                                </div>
                            </li>
                            <li class="b_right block_do" style="margin-bottom: 0">
                                <div class="bts_cv">
                                    <Cthuvien:gchu ID="qua" runat="server" kt_xoa="X" CssClass="so_cv" Text="0" />
                                    <span>Hết hợp đồng</span>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="block_r_db width_common top_nhieuviec top_donvi" style="display: none">
                    <span class="title_dmuc width_common">Top đơn vị quá hạn ít nhất</span>
                    <div class="width_common thongso_topdv">
                        <div id="div_dgia0" class="width_common"></div>
                    </div>
                </div>
                <div class="block_r_db width_common top_quahan top_donvi" style="display: none">
                    <span class="title_dmuc width_common">Top đơn vị quá hạn nhiều nhất</span>
                    <div class="width_common thongso_topdv">
                        <div id="div_dgia1" class="row width_common"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_ctDiv" class="css_divOver" style="display: none; overflow: hidden;">
        <div id="UPa_tk" class="css_divCt dilog_form" style="top: 50px; left: 250px; width: 920px">
            <div class="css_hpopup width_common" id="divTieuDe" onmousedown="form_Keo(event)" onmousemove="form_Keo(event,'UPa_tk')">
                <span class="b_left">Theo dõi công việc chi tiết</span>
                <div class="close_dilog b_right">
                    <img id="imgDong" runat="server" class="b_right" alt="" src="~/images/eDoc/icon_close.png" onclick="return ed_vb_nvT_P_TIM_NG('D','');" />
                </div>
            </div>
            <div class="css_hcpopup width_common">
                <div class="col_2_iterm width_common">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Đơn vị/ Bộ phận</span>
                        <div class="input-group">
                            <Cthuvien:gchu ID="dvbp" runat="server" kt_xoa="X" CssClass="css_gchu" />
                        </div>
                    </div>
                </div>
                <div class="col_2_iterm width_common">
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_30">Nhiệm vụ - Đang xử lý</span>
                        <div class="input-group">
                            <Cthuvien:gchu ID="Gchu1" runat="server" kt_xoa="X" CssClass="css_gchu" />
                        </div>
                    </div>
                </div>
                <div class="grid_table width_common css_divb c_divC">
                    <div class="css_divCn">
                        <Cthuvien:GridX ID="GR_ct2" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="gridX_cot gridX" loai="N" hangKt="10" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:BoundField HeaderImageUrl="~/images/eDoc/icon-attactfile.png" DataField="timF" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gso" />
                                <asp:BoundField HeaderText="Số" DataField="so" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd" />
                                <asp:BoundField HeaderText="Nơi gửi" DataField="noiG" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gngay" />
                                <asp:BoundField HeaderText="Công việc" DataField="cviec" ItemStyle-CssClass="css_Gnd" />
                                <asp:BoundField HeaderText="Hạn xử lý" DataField="han" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                <asp:BoundField HeaderText="Số ngày còn lại" DataField="sncl" ItemStyle-CssClass="css_Gnd" />
                                <asp:BoundField HeaderText="Cán bộ xử lý" DataField="nxl" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                            </Columns>
                        </Cthuvien:GridX>
                    </div>
                    <ctr_khud_divC:ctr_khud_divC ID="Ctr_khud_divC3" runat="server" loai="L" gridId="GR_ct2" ham="ed_vb_nvT_P_TIM_CT('L')" />
                </div>
                <div class="list_bt_action txt_center"></div>
            </div>
        </div>
    </div>
</asp:Content>
