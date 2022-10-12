<%@ Page Title="tl_ma_dongia" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_ma_dongia.aspx.cs" Inherits="f_tl_ma_dongia" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Đơn giá" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">

                    <div class="grid_table width_common">
                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                            CssClass="table gridX" loai="X" hangKt="15" cotAn="masp,so_id" hamRow="tl_ma_dongia_GR_lke_RowChange()">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:BoundField HeaderText="Mã sản phẩm" DataField="ten_sp" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Mã sản phẩm" DataField="masp" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Ngày" DataField="ngay" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField HeaderText="Đơn giá" DataField="dongia" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gso" />
                                <asp:BoundField HeaderText="so_id" DataField="so_id" />
                            </Columns>
                        </Cthuvien:GridX>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="tl_ma_dongia_P_LKE('K')" />
                    </div>

                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Sản phẩm<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="MASP" CssClass="form-control css_list" runat="server" ktra="DT_SP" f_tkhao="~/App_form/tl/ma/tl_ma_spham.aspx" kt_xoa="K" ten="Sản phẩm" ToolTip="Sản phẩm" onchange="tl_ma_dongia_P_KTRA('MASP')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Đơn giá<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="DONGIA" CssClass="form-control css_ma" so_tp="2" co_dau="K" runat="server"  kt_xoa="K" ten="Chất lượng" ToolTip="Chất lượng" kieu_so="true" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày áp dụng<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY" runat="server" CssClass="form-control icon_lich" kt_xoa="G"
                                    ten="Ngày áp dụng" ToolTip="Ngày áp dụng" onchange="tl_ma_dongia_P_KTRA('NGAY')" />

                            </div>

                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="b_left form-group iterm_form">
                        <span class="standard_label b_left col_15">Ghi chú</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="note" ten="Mô tả" runat="server" CssClass="form-control css_nd" Height="50px" kieu_unicode="True" kt_xoa="X" />
                        </div>
                    </div>

                    <div class="list_bt_action">
                        <button onclick="return tl_ma_dongia_P_NH();form_P_LOI();" class="bt_action"><span class="txUnderline">N</span>hập</button>
                        <button onclick="return tl_ma_dongia_P_MOI();form_P_LOI();" class="bt_action">Mới</button>
                        <button class="bt_action" onclick="return tl_ma_dongia_P_XOA();form_P_LOI();"><span class="txUnderline">X</span>óa</button>
                        <button onclick="return form_P_TRA_CHON_GRID('GR_ct:ma,GR_ct:hso');form_P_LOI();" class="bt_action"><span class="txUnderline">C</span>họn</button>

                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="880,470" />
    </div>
</asp:Content>
