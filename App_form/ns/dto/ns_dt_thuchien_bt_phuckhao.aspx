<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dt_thuchien_bt_phuckhao.aspx.cs" Inherits="f_ns_dt_thuchien_bt_phuckhao"
    Title="ns_dt_thuchien_bt_phuckhao" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<%--<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Phúc khảo bài thi" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_thoat();" />
                <%--<img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_GOP();" />
                 <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_HELP();" />--%>
            </div>
            <div class="width_common auto_sc">
                <div class="col_60 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common" style="display:none;">
                        <div class="b_left iterm_form" id="tdThoigian">
                            <div class="standard_label b_left col_40">
                                <asp:Label ID="ltlthoigian" runat="server" Text="Thời gian còn lại:" Width="120px" CssClass="css_gchu" />
                            </div>
                        </div>
                        <div class="form-group iterm_form" style="display:none;">
                            <div class="standard_label b_left col_40">
                                <asp:Label ID="thoigian" runat="server" Text="Mã nhân viên" Font-Bold="true" Width="90px" CssClass="css_gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Mã nhân viên" runat="server" Enabled="false" ReadOnly="true" CssClass="form-control css_ma" Width="150px"
                                    onchange="ns_dt_phieu_ks_P_KTRA('SO_THE')"  gchu="gchu" />
                            </div>
                        </div>
                        <div class="b_left iterm_form">
                            <span class="standard_label b_left col_40">Họ tên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ho_ten" ten="Họ Tên nhân viên" runat="server" Enabled="false" ReadOnly="true" CssClass="form-control css_ma" Width="250px"
                                    onchange="ns_dt_phieu_ks_P_KTRA('SO_THE')" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Tên kỳ thi</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_kythi" ten="Tên kỳ thi" runat="server" Enabled="false" ReadOnly="true" CssClass="form-control css_ma" Width="514px"
                                    onchange="ns_dt_phieu_ks_P_KTRA('SO_THE')" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display:none;">
                        <div class="b_left iterm_form" id="trCauHoi">
                            <span class="standard_label b_left" style="margin-right:80px;">Câu hỏi số</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="cauhoi_so" ten="Câu hỏi số" Text="1" runat="server" Enabled="false" ReadOnly="true" CssClass="form-control css_ma" Width="40px"
                                    onchange="ns_dt_phieu_ks_P_KTRA('SO_THE')" gchu="gchu" />
                                <Cthuvien:an ID="loai_ch" runat="server" />
                                <Cthuvien:an ID="so_id" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display:none;">
                        <div class="b_left form-group iterm_form" id="trNoidung">
                            <span class="standard_label b_left col_40">Câu hỏi</span>
                            <div>
                                <Cthuvien:nd ID="noidung" ten="Nội dung" runat="server" Height="100px" kieu_unicode="true" CssClass="form-control css_nd" Rows="5" Width="640px"
                                    onchange="ns_dt_phieu_ks_P_KTRA('SO_THE')" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common" style="display:none;">
                        <div class="b_left form-group iterm_form">
                            <div id="trHoanThanh" style="display: none;">
                                <span class="standard_label b_left col_40">Bạn đã hoàn thành</span>
                            </div>
                            <div class="input-group" id="trHoanThanh2" style="display: none;">
                                <Cthuvien:gchu ID="hoanthanh" runat="server" Font-Bold="true" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <div id="trDapan" style="display: none;">
                                <span class="standard_label b_left col_40">Điểm</span>
                            </div>
                            <div class="input-group" id="trDapan2" style="display: none;">
                                <Cthuvien:gchu ID="diem" runat="server" Font-Bold="true" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_40">Nội dung</span>
                            <div>
                                <Cthuvien:nd ID="noidung_phuckhao" ten="Nội dung" runat="server" kieu_unicode="true" CssClass="form-control css_nd" Rows="5" Width="640px" gchu="gchu" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common" id="GR_v2">
                        <div id="trtraloi">
                            <div id="tdlbl" style="display: none">
                                <asp:Label ID="Label1" runat="server" Text="Nội dung" Width="90px" CssClass="css_gchu" />
                            </div>
                            <div style="display:none;">
                                <div id="bt_grid">
                                    <div style="overflow-x:scroll;">
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                            CssClass="gridX" loai="X" hangKt="5" cot="so_id,STT,traloi,dapan" cotAn="so_id,nsd"
                                            onchange="ns_dt_thuchien_bt_phuckhao_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField DataField="so_id" HeaderStyle-Width="10px" />
                                                <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="true" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="40px" />
                                                <asp:TemplateField HeaderText="Nội dung" HeaderStyle-Width="350px" HeaderStyle-Height="80px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="traloi" ReadOnly="true" CssClass="css_Gma" runat="server" Width="350px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Câu trả lời đúng" HeaderStyle-Width="120px">
                                                    <ItemTemplate>
                                                        <Cthuvien:kieu ID="dapan" disabled ReadOnly="true" runat="server" lke="X," Width="120px" kt_xoa="X" ToolTip="X - Đáp án đúng,  - Đáp án sai" CssClass="css_Gma_c" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </div>
                                    <div id="trphantrang" style="display:none;">
                                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_thuchien_bt_phuckhao1_P_TRALOI()" />
                                    </div>
                                </div>

                                <div id="bt_noidung" style="display: none">
                                    <Cthuvien:nd ID="noidung_cauhoi" ten="Nội dung" kieu_unicode="true" runat="server" Height="120px" CssClass="form-control css_nd" Width="640px" gchu="gchu" />
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="list_bt_action" id="UPa_nhap">
                        <Cthuvien:nhap ID="btnsend" runat="server" Width="100px" class="bt_action" anh="K" Text="Phúc khảo" OnClick="return ns_dt_thuchien_bt_phuckhao1_P_SEND()();form_P_LOI();" />
                      <%--  <Cthuvien:nhap ID="btntieptheo" runat="server" Width="100px" class="bt_action" anh="K" Text="Tiếp theo" OnClick="return ns_dt_thuchien_bt_xemlai_P_TIEPTHEO_TIEPTHEO();form_P_LOI();" />--%>
                        <%--<Cthuvien:nhap ID="btnnopbai" runat="server" Width="100px" class="bt_action" anh="K" Text="Nộp bài" OnClick="return ns_dt_thuchien_bt_xemlai_P_NOPBAI();form_P_LOI();" />--%>
                        <%--<Cthuvien:nhap ID="btnclose" runat="server" Width="70px" class="bt_action" anh="K" Text="Đóng" OnClick="return ns_dt_thuchien_bt_xemlai_P_DONG();form_P_LOI();" />--%>
                         <%--<Cthuvien:nhap ID="Nhap1" runat="server" Width="100px" class="bt_action" anh="K" Text="Quay lại" OnClick="return ns_dt_thuchien_bt_P_TIEPTHEO_QUAYLAI();form_P_LOI();" />--%>
                       <%-- <a id="btnquaylai" href="#" class="bt_action" onclick="return ns_dt_thuchien_bt_xemlai_P_TIEPTHEO_QUAYLAI();form_P_LOI();"><i class="fa fa-start"></i>Quay lại</a>
                        <a id="btntieptheo" class="bt_action" href="#" onclick="return ns_dt_thuchien_bt_xemlai_P_TIEPTHEO_TIEPTHEO();form_P_LOI();"><i class="fa fa-view"></i>Tiếp theo</a>--%>
                       <%-- <a id="btnnopbai" class="bt_action" href="#" onclick="return ns_dt_thuchien_bt_P_NOPBAI();form_P_LOI();" ><i class="fa fa-firefox"></i>Nộp bài</a>
                        <a id="btnclose" class="bt_action" style="display: none" href="#" onclick="return ns_dt_thuchien_bt_P_DONG();form_P_LOI();"><i class="fa fa-firefox"></i>Đóng</a>--%>
                    </div>

                </div>
                <div id="UPa_gchu">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                </div>
            </div>
        </div>

    </div>

    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="830,860" />
        <Cthuvien:an ID="BAITHI" runat="server" />
    </div>
</asp:Content>
