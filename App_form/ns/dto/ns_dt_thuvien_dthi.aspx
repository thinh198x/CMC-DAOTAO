<%@ Page Title="ns_dt_thuvien_dthi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_thuvien_dthi.aspx.cs" Inherits="f_ns_dt_thuvien_dthi" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thư viện câu hỏi đề thi" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,loai" hamRow="ns_dt_thuvien_dthi_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="MA" HeaderStyle-Width="30%" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Câu hỏi" DataField="cauhoi" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                    <asp:BoundField HeaderText="loai" DataField="loai" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_thuvien_dthi_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Mã đào tạo<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA_NHUCAU" placeholder="Nhấn F1" kt_xoa="K" ten="Mã đào tạo" BackColor="#f6f7f7"  runat="server" CssClass="form-control css_ma"
                                    f_tkhao="~/App_form/ns/dto/ns_dt_nhucau_dt.aspx" ktra="ns_dt_nhucau_dt,ma,ten" />
                                <%--onchange="ns_dt_thuvien_dthi_P_KTRA('MA_NHUCAU')" onfocusout="ns_dt_thuvien_dthi_P_KTRA('MA')" --%>
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Mã câu hỏi</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="MA" ten="Mã câu hỏi" kieu_chu="false" kt_xoa="G" runat="server" CssClass="form-control css_ma" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Nội dung câu hỏi <span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:nd ID="CAUHOI" ten="Câu hỏi" Height="50px" kieu_unicode="true" kt_xoa="X" runat="server" CssClass="form-control css_nd" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_20">Loại<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="loai" runat="server" CssClass="form-control css_list" ten="Đối tượng cư trú"
                                    tra="1,2" lke="Trắc nghiệm,Tự luận" kt_xoa="X"  onchange="checkanhien()"/>
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common"  id="show">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="gridX" Width="100%" loai="N" cotAn="MA_CAUHOI" cot="STT,traloi,dapan" hangKt="6" hamUp="ns_dt_thuvien_dthi_sp_Update">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="STT" HeaderText="STT" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="40px" />
                                    <asp:TemplateField HeaderText="Đáp án(*)">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="traloi" kieu_unicode="true" runat="server" Width="100%" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Trả lời(*)">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="dapan" runat="server" lke="X," Width="100%" kt_xoa="X" ToolTip="X - Đáp án đúng,  - Đáp án sai" CssClass="css_Gma_c" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div class="btex_luoi b_right">
                            <ul>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return ns_dt_thuvien_dthi_sp_HangLen();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return ns_dt_thuvien_dthi_sp_HangXuong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return ns_dt_thuvien_dthi_sp_CatDong();" />
                                </li>
                                <li>
                                    <img runat="server" alt="" src="~/images/eDoc/chen.png" title="Chèn thêm dòng" onclick="return ns_dt_thuvien_dthi_sp_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="100px" class="bt_action" anh="K" Text="Làm mới" OnClick="return ns_dt_thuvien_dthi_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="70px" class="bt_action" anh="K" Text="Ghi" OnClick="return ns_dt_thuvien_dthi_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="70px" class="bt_action" anh="K" Text="Xóa" OnClick="return ns_dt_thuvien_dthi_P_XOA();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Width="70px" class="bt_action" anh="K" Text="Chọn" OnClick="return form_P_TRA_CHON_GRID('GR_lke:ma,GR_lke:cauhoi,GR_lke:loai,GR_lke:so_id');form_P_LOI();" />
                    </div>
                    <div style="display: none">
                        <Cthuvien:nhap ID="Nhap2" runat="server" Width="70px" Text="Xuất excel" OnServerClick="nhap_Click" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="970,670" />
    </div>
</asp:Content>
