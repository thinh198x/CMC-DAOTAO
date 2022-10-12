<%@ Page Title="tl_qd_xl_dg" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_qd_xl_dg.aspx.cs" Inherits="f_tl_qd_xl_dg" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Thiết lập quy định xếp loại đánh giá" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_37">
                <div class="b_left col_30 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id,loai_dg" hamRow="tl_qd_xl_dg_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngayhieuluc" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Loại đánh giá" DataField="loai_dg" />
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="tl_qd_xl_dg_P_LKE('K')" />
                    </div>
                </div>
                <div class="b_right col_70 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Ngày hiệu lực<span class="require">*</span></span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYHIEULUC" runat="server" ten="Ngày hiệu lực"
                                    CssClass="form-control icon_lich" MaxLength="10" kieu_chu="true" kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Loại đánh giá</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="loai_dg" ten="Loại đánh giá" CssClass="form-control css_list"
                                    runat="server" kieu="S" tra="0,1" lke="Đánh giá theo tháng,Đánh giá theo năm" onchange="check_anhien();"/>
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="N"
                                cotAn="so_idct" cot="diemdanhgia_tu,diemdanhgia_den,XEPLOAI,heso,mota,so_idct" hangKt="15" gchuId="gchu" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Điểm đánh giá từ">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diemdanhgia_tu" onkeyup="tl_qd_xl_dg_P_xeploai()" runat="server" CssClass="css_Gma" kieu_so="true"></Cthuvien:ma>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Điểm đánh giá đến">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="diemdanhgia_den" onkeyup="tl_qd_xl_dg_P_xeploai()" runat="server" CssClass="css_Gma" kieu_so="true"></Cthuvien:ma>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Xếp loại">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="XEPLOAI" runat="server" CssClass="css_Gma"></Cthuvien:ma>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Hệ số">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="heso" runat="server" CssClass="css_Gma" onkeyup="Check_sothapphan(event)"></Cthuvien:ma>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mô tả">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="mota" runat="server" CssClass="css_Gma"></Cthuvien:ma>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số id chi tiết">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="so_idct" runat="server" CssClass="css_Gma" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" class="bt_action" anh="K" Text="Làm mới" OnClick="return tl_qd_xl_dg_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" class="bt_action" anh="K" Text="Ghi" OnClick="return tl_qd_xl_dg_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" class="bt_action" anh="K" Text="Xóa" OnClick="return tl_qd_xl_dg_P_XOA();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="UPa_hidden">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1200,550" />
    </div>
</asp:Content>
