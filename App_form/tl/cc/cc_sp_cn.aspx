<%@ Page Title="cc_sp_cn" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="cc_sp_cn.aspx.cs" Inherits="f_cc_sp_cn" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">

        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Chấm công sản phẩm cá nhân" />
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
                            CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="cc_sp_cn_GR_lke_RowChange()">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Ngày" DataField="ngay" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField HeaderText="Ca" DataField="ca" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField HeaderText="so_id" DataField="so_id" />
                            </Columns>
                        </Cthuvien:GridX>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="cc_sp_cn_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">

                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã nhân viên<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" placeholder="Nhấn (F1)" runat="server" CssClass="form-control css_ma"
                                    ktra="ns_cb,so_the,ten" ToolTip="Mã số cán bộ" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                    kieu_chu="true" onchange="cc_sp_cn_P_KTRA('SO_THE')" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY" runat="server" CssClass="form-control icon_lich" kt_xoa="G"
                                    kieu_luu="S" ten="Ngày" onchange="cc_sp_cn_P_KTRA('NGAY')" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ca<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:kieu ID="ca" runat="server" CssClass="form-control css_ma" Width="120px" ten="ten_kieu"
                                    Text="S" lke="S,C,Đ" ToolTip="S-Ca Sáng, C-Ca Chiều, Đ-Ca Đêm" onchange="cc_sp_cn_P_KTRA('NGAY')" />
                            </div>
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label b_left col_15">Ghi chú</span>
                        <div class="input-group">
                            <Cthuvien:nd ID="note" runat="server" CssClass="form-control css_nd" kieu_unicode="true" Height="50px"
                                kt_xoa="X" />
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="N" cot="masp,donvi,chatluong,soluong" hangKt="9" gchuId="gchu" ctrT="so_tt" ctrS="nhap" hamUp="cc_sp_cn_sp_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Mã sản phẩm" HeaderStyle-Width="160px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="masp" kieu_chu="true" runat="server" Width="140px" CssClass="css_Gma" placeholder="Nhấn (F1)"
                                                f_tkhao="~/App_form/tl/ma/tl_ma_spham.aspx" ktra="ns_tl_ma_spham,ma,ten" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Đơn vị" DataField="donvi" HeaderStyle-Width="133px" ItemStyle-CssClass="css_Gnd" />
                                    <asp:TemplateField HeaderText="Chất lượng" HeaderStyle-Width="160px">
                                        <ItemTemplate>
                                            <Cthuvien:so MaxLength="3" ID="chatluong" runat="server" Width="170px" CssClass="css_Gso" co_dau="K" so_tp="2" onchange="cc_sp_cn_P_KTRA('CHATLUONG')" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số lượng" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="soluong" runat="server" Width="150px" CssClass="css_Gso" so_tp="2" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>

                        <div class="btex_luoi b_right" id="id_chensp">
                            <ul>
                                <li>
                                    <img alt="" src="/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return cc_sp_cn_sp_HangLen();" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return cc_sp_cn_sp_HangXuong();" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return cc_sp_cn_sp_CatDong();" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/chen.png" title="Thêm 1 dòng mới" onclick="return cc_sp_cn_sp_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <button onclick="return cc_sp_cn_P_NH();form_P_LOI();" class="bt_action">Nhập</button>
                        <button onclick="return cc_sp_cn_P_MOI();form_P_LOI();" class="bt_action">Mới</button>
                        <button onclick="return cc_sp_cn_P_XOA();form_P_LOI();" class="bt_action">Xóa</button>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1055,680" />
    </div>
</asp:Content>
