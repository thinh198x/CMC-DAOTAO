<%@ Page Title="ns_dt_tochuc_thi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_tochuc_thi.aspx.cs" Inherits="f_ns_dt_tochuc_thi" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Tổ chức thi" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="ns_dt_tochuc_thi_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Tên kỳ thi" DataField="ten" HeaderStyle-Width="170px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày thi" DataField="ngaythi" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Tình trạng" DataField="tinhtrang" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_tochuc_thi_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Loại</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="loai_kh" runat="server" CssClass="form-control css_list" ten="Đối tượng cư trú" tra="1,2"
                                    lke="Theo khóa học,Định kỳ" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã khóa học</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ma_kh" ten="Mã khóa học" ToolTip="Mã khóa học" kt_xoa="G" runat="server" CssClass="form-control css_ma"
                                    kieu_chu="true" BackColor="#f6f7f7" ktra="ns_dt_kdt,ma,ten" f_tkhao="~/App_form/ns/dto/ns_dt_kdt.aspx"
                                    placeholder="Nhấn F1" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã kỳ thi<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" ten="Mã kỳ thi" kt_xoa="G" runat="server" CssClass="form-control css_ma" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Tên kỳ thi<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Tên kỳ thi" kieu_unicode="true" runat="server" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Ngày thi<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYTHI" runat="server" ten="Ngày thi"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Mã đề thi<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA_DT" BackColor="#f6f7f7" ktra="ns_dt_khoitao_dthi,ma,ten" f_tkhao="~/App_form/ns/dto/ns_dt_khoitao_dthi.aspx"
                                    placeholder="Nhấn F1" ten="Mã đề thi" runat="server" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Thi từ<span class="require">*</span> </span>
                            <div class="input-group">
                                <%--<Cthuvien:ma ID="THITU" ten="Thi từ" runat="server" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />--%>
                                 <Cthuvien:ma ID="THITU" ten="Thi đến" runat="server" onchange="ns_dt_tochuc_thi_P_KTRA('THITU')" kt_xoa="X" CssClass="form-control css_ma_c" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Thi đến<span class="require">*</span></span>
                            <div class="input-group">
                                <%--<Cthuvien:ma ID="THIDEN" ten="Thi đến" runat="server" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />--%>
                                 <Cthuvien:ma ID="THIDEN" ten="Thi đến" runat="server" onchange="ns_dt_tochuc_thi_P_KTRA('THIDEN')" kt_xoa="X" CssClass="form-control css_ma_c" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Thời gian làm bài(Phút)<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="THOIGIAN" kieu_so="true" ten="Thời gian làm bài(Phút)" runat="server" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Người chấm thi </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tenchamthi" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                    placeholder="Nhấn F1" ten="Người chấm thi" runat="server" kieu_unicode="true" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                         <div class="b_left form-group iterm_form" style="display:none;">
                            <span class="standard_label b_left col_40">Người chấm thi </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="chamthi" ten="Mã người chấm thi" runat="server" kieu_unicode="true" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Người giám sát</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="tengiamsat" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                    placeholder="Nhấn F1" ten="Người giám sát" runat="server" kieu_unicode="true" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form" style="display:none;">
                            <span class="standard_label b_left col_40">Người chấm thi </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="giamsat" ten="Mã người chấm thi" runat="server" kieu_unicode="true" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="gridX" Width="100%" loai="N" cot="stt,so_the,ho_ten,donvi,phong,cdanh" hangKt="9" hamUp="ns_dt_tochuc_thi_sp_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="stt" HeaderStyle-Width="40px" ControlStyle-CssClass="css_gchu_c" HeaderText="STT" />
                                    <asp:TemplateField HeaderText="Mã nhân viên">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="so_the" kieu_chu="true" runat="server" Width="100%" CssClass="css_Gma"
                                                f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="ns_cb,so_the,ten" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Họ tên">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ho_ten" Enabled="false" ReadOnly="true" kieu_chu="true" runat="server" Width="100%" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Đơn vị">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="donvi" Enabled="false" ReadOnly="true" kieu_chu="true" runat="server" Width="100%" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phòng">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="phong" Enabled="false" ReadOnly="true" kieu_chu="true" runat="server" Width="100%" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chức danh">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cdanh" Enabled="false" ReadOnly="true" kieu_chu="true" runat="server" Width="100%" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_tochuc_thi_sp_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_tochuc_thi_sp_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_tochuc_thi_sp_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn thêm dòng" onclick="return ns_dt_tochuc_thi_sp_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_dt_tochuc_thi_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_dt_tochuc_thi_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_dt_tochuc_thi_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Width="70px" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1260,700" />
    </div>
</asp:Content>
