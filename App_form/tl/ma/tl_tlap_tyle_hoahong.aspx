<%@ Page Title="tl_tlap_tyle_hoahong" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_tlap_tyle_hoahong.aspx.cs" Inherits="f_tl_tlap_tyle_hoahong" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập tỷ lệ hoa hồng theo phí giao dịch" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%" cotAn="so_id"
                                CssClass="table gridX" loai="X" hangKt="20" hamRow="tl_tlap_tyle_hoahong_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField DataField="so_id" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay" ItemStyle-CssClass="css_Gma_c" headerstyle-Width="120px" />
                                    <asp:BoundField HeaderText="Biểu mẫu" DataField="bmau" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="tl_tlap_tyle_hoahong_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label  b_left col_30">Ngày hiệu lực</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAY" runat="server" ten="Ngày hiệu lực" CssClass="form-control icon_lich css_ngay" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Biểu mẫu</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="bmau" runat="server" ten="Biểu mẫu" CssClass="form-control css_ma" kieu_unicode="true" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="overflow-x: scroll">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" cot="stt,dtnv,phi_tu,phi_den,tyle" hangKt="20" gchuId="gchu" Width="100%" hamUp="tl_tlap_tyle_hoahong_CT_Update()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="STT" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="stt" runat="server" kt_xoa="X" CssClass="css_Gma_c" Width="100%" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Đối tượng nhân viên" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <Cthuvien:DR_list ID="dtnv" runat="server" kieu_chu="true" kt_xoa="X" CssClass="css_Glist" lke=",Khối IB,Khối BB,Khối BS, Khối CS,Cộng tác viên" tra=",IB,BB,BS,CS,CTV" ten="Đối tượng"
                                                ToolTip="Đối tượng" Width="100%"></Cthuvien:DR_list>
                                            <%--<Cthuvien:ma ID="dtnv" runat="server" CssClass="css_Gma" Width="100%" gchu="Tỷ lệ xuất sắc (A*)" />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mức phí giao dịch từ" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="phi_tu" runat="server" Width="100%" kt_xoa="X" CssClass="css_Gso" ToolTip="Mức phí giao dịch từ" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mức phí giao dịch đến" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="phi_den" runat="server" Width="100%" kt_xoa="X" CssClass="css_Gso" ToolTip="Mức phí giao dịch đến" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tỷ lệ hoa hồng" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <Cthuvien:so ID="tyle" runat="server" Width="100%" kt_xoa="X" CssClass="css_Gso" ToolTip="Tỷ lệ hoa hồng" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="b_right form-group iterm_form">
                        <span class="standard_label b_left col_15">Mô tả</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="ghichu" runat="server" kieu_unicode="true" ten="Mô tả" ToolTip="Mô tả" CssClass="form-control css_ma" kt_xoa="X" TextMode="MultiLine" Rows="3" MaxLength="1000" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" class="bt_action" OnClick="return tl_tlap_tyle_hoahong_P_NH();form_P_LOI();" Width="70px" anh="K" />
                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" class="bt_action" OnClick="return tl_tlap_tyle_hoahong_P_MOI();form_P_LOI();" Width="70px" anh="K" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" class="bt_action" OnClick="return tl_tlap_tyle_hoahong_P_XOA();form_P_LOI();" Width="70px" anh="K" />
                    </div>
                </div>
            </div>


        </div>
    </div>
    <div id="UPa_hidden">
        <Cthuvien:an ID="kthuoc" runat="server" Value="600,540" />
    </div>
</asp:Content>
