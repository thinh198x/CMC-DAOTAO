<%@ Page Title="cc_khoan_cn" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="cc_khoan_cn.aspx.cs" Inherits="f_cc_khoan_cn" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Chấm công khoán cá nhân" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                         <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Từ ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayd_tk" runat="server" ten="Ngày hiệu lực" CssClass="form-control icon_lich" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Từ ngày" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Đến ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngayc_tk" runat="server" ten="Đến ngày" CssClass="form-control icon_lich" kieu_luu="S"
                                    kt_xoa="X" ToolTip="Đến ngày" />
                            </div>
                        </div>

                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_20">Mã NV</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="so_the_tk" ten="Mã CB tìm kiếm" runat="server" CssClass="form-control css_ma" kt_xoa="K" kieu_chu="true" />
                        </div>
                    </div>
                    <div class="b_left  width_common form-group iterm_form">
                        <div class="list_bt_action">
                            <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" Width="100px" class="bt_action" anh="K" OnClick="cc_sp_cn_P_LKE('K');form_P_LOI();" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                            CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="cc_khoan_cn_GR_lke_RowChange()">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Mã sản phẩm/Công việc" DataField="masp" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Ngày" DataField="ngay" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField HeaderText="so_id" DataField="so_id" />
                            </Columns>
                        </Cthuvien:GridX>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="cc_khoan_cn_P_LKE('K')" /> 
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                   
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã nhân viên<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" runat="server" MaxLength="30" CssClass="form-control css_ma" kieu_chu="true"
                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Mã cán bộ" placeholder="Nhấn (F1)"
                                    onchange="cc_sp_cn_P_KTRA('SO_THE')" ktra="ns_cb,SO_THE,ten" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Sản phẩm/Công việc<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MASP" runat="server" kt_xoa="G" MaxLength="10" CssClass="form-control css_ma" ten="Mã sản phẩm/công việc"
                                    ToolTip="Mã sản phẩm/ công việc" kieu_chu="true" f_tkhao="~/App_form/tl/ma/tl_ma_spham.aspx" placeholder="Nhấn (F1)"
                                    ktra="ns_tl_ma_spham,ma,ten" onchange="cc_khoan_cn_P_KTRA('MASP')" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY" ten="Ngày" runat="server" MaxLength="10" CssClass="form-control icon_lich" kt_xoa="G"
                                    kieu_luu="S" onchange="cc_khoan_cn_P_KTRA('NGAY')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Tiền<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:so ID="TIEN" runat="server" kt_xoa="X" MaxLength="10" CssClass="form-control css_so" ten="Số tiền"
                                    ToolTip="Số tiền được nhận sau khi hoàn thành công việc" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Chất lượng<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:so ID="CHATLUONG" runat="server" kt_xoa="X" MaxLength="10" CssClass="form-control css_so" ten="Chất lượng"
                                    ToolTip="Chất lượng" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_40">Ngày hoàn thành<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYHOANTHANH" ten="Ngày hoàn thành" runat="server" MaxLength="10" CssClass="form-control icon_lich" kt_xoa="G"
                                    kieu_luu="S" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Tỷ lệ<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:so ID="TYLE" runat="server" kt_xoa="X" MaxLength="10" CssClass="form-control css_so" ten="Tỷ lệ"
                                    ToolTip="Tỷ lệ" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="b_left form-group width_common iterm_form">
                        <span class="standard_label b_left col_15">Ghi chú </span>
                        <div class="input-group">
                            <Cthuvien:nd ID="note" runat="server" TextMode="MultiLine" MaxLength="200" Height="50px" kt_xoa="X" CssClass="form-control css_ma" ten="Số tiền"
                                ToolTip="ghi chú" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <button onclick="return cc_khoan_cn_P_NH();form_P_LOI();" class="bt_action">Nhập</button>
                        <button onclick="return cc_khoan_cn_P_MOI();form_P_LOI();" class="bt_action">Mới</button>
                        <button onclick="return cc_khoan_cn_P_XOA();form_P_LOI();" class="bt_action">Xóa</button>
                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="980,550" />
    </div>
</asp:Content>
