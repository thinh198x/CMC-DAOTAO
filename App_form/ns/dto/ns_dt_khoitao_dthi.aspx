<%@ Page Title="ns_dt_khoitao_dthi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_khoitao_dthi.aspx.cs" Inherits="f_ns_dt_khoitao_dthi" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Khởi tạo đề thi" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                            CssClass="gridX" loai="X" hangKt="20" cotAn="so_id" hamRow="ns_dt_khoitao_dthi_GR_lke_RowChange()">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                <asp:BoundField HeaderText="Mã đề thi" DataField="ma" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField HeaderText="Tên" DataField="ten" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField HeaderText="Ngày tạo đề" DataField="ngayd" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField HeaderText="so_id" DataField="so_id" />
                            </Columns>
                        </Cthuvien:GridX>
                    </div>
                    <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_khoitao_dthi_P_LKE('K')" />
                </div>
                <div class="b_right col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã đề thi<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" ten="Mã đề thi" kt_xoa="K" runat="server" CssClass="form-control css_ma" onchange="ns_dt_khoitao_dthi_P_KTRA('MA')" gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên đề thi<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" ten="Tên đề thi" kieu_unicode="true" runat="server" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Loại<span class="require"></span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="LOAI" runat="server" CssClass="form-control css_list" ten="Loại"
                                    tra="1,2" lke="Theo khóa học,Định kỳ" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Khóa đào tạo</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="khoadt" ten="Mã khóa học" ToolTip="Mã khóa học" onchange="ns_dt_tochuc_thi_P_KTRA('ma_kh')" kt_xoa="X" runat="server" CssClass="form-control css_ma"
                                    kieu_chu="true" BackColor="#f6f7f7" ktra="ns_dt_dxuat,ma,ten" f_tkhao="~/App_form/ns/dto/ns_dt_dxuat.aspx"
                                    placeholder="Nhấn F1" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Ngày tạo đề<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYD" runat="server" ten="Ngày tạo đề"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Đạt điểm<span class="require">*</span> </span>
                            <div class="input-group">
                                <Cthuvien:ma ID="DATDIEM" ten="Đạt điểm" runat="server" CssClass="form-control css_ma" kt_xoa="X" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="gridX" Width="100%" loai="N" cotAn="MA_CAUHOI,SO_ID_CH" cot="stt,ma_cauhoi,SO_ID_CH,cauhoi,loaithi,diem" hangKt="15">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="STT" HeaderText="STT" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="40px" />
                                    <asp:BoundField DataField="MA_CAUHOI" HeaderText="STT" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="SO_ID_CH" HeaderText="STT" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Câu hỏi(*)">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="cauhoi" placeholder="Nhấn F1" kt_xoa="G" kieu_chu="true" runat="server" Width="100%" CssClass="css_Gma"
                                                f_tkhao="~/App_form/ns/dto/ns_dt_thuvien_dthi.aspx" ktra="ns_dt_thuvien_dt,ma,cauhoi" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Loại(*)">
                                        <ItemTemplate>
                                           <%--<Cthuvien:DR_nhap ID="LOAITHI" ten="Loại" Height="22px" runat="server"
                                                CssClass="css_Glist" kieu="S" Width="100%">
                                                <asp:ListItem Selected="True" Value="" Text=""></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Trắc nghiệm"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Tự luận"></asp:ListItem>
                                            </Cthuvien:DR_nhap>--%>
                                              <Cthuvien:DR_lke ID="LOAITHI" ktra="DT_LOAITHI" runat="server" ten="Loại" CssClass="css_Glist" Width="100%" kt_xoa="X"></Cthuvien:DR_lke>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm(*)">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diem" kieu_so="true" runat="server" Width="100%" CssClass="css_Gso" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                          <ctr_khud_divL:ctr_khud_divL ID="GR_ct_slide" runat="server" loai="N" gridId="GR_ct" />
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_khoitao_dthi_sp_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_khoitao_dthi_sp_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_khoitao_dthi_sp_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn thêm dòng" onclick="return ns_dt_khoitao_dthi_sp_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_dt_khoitao_dthi_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_dt_khoitao_dthi_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_dt_khoitao_dthi_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Width="70px" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                    </div>


                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="920,680" />
    </div>
</asp:Content>
