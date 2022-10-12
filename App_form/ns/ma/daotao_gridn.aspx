<%@ Page Language="C#" AutoEventWireup="true" CodeFile="daotao_gridn.aspx.cs" Inherits="f_daotao_gridn"
    Title="daotao_gridn" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Cthuvien:Gridx" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="grid_table width_common css_divb c_divC">
                        <div class="table gridX css_divCn">

                            <div>
                                <Cthuvien:GridX ID="GR_ct" runat="server" loai="N" hamUp="ns_hdct_P_Update" cotAn="co_bh" Width="100%"
                                    AutoGenerateColumns="false" hangKt="20" cot="ma_pc,ten,sotien,ngay_ad,ngay_kt,co_bh" PageSize="1" CssClass="table gridX">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                        <asp:TemplateField HeaderText="Mã phụ cấp" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <Cthuvien:ma ID="ma_pc" runat="server" placeholder="Nhấn (F1)" f_tkhao="~/App_form/ns/hdns/dm/ns_hdns_ma_htkhac.aspx"
                                                    CssClass="css_Gma" Width="100px" kt_xoa="K" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ten" HeaderText="Tên phụ cấp" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="150px" />
                                        <asp:TemplateField HeaderText="Số tiền" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <Cthuvien:so ID="sotien" runat="server" CssClass="css_Gma_r" Width="100%" kt_xoa="X" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ngày áp dụng" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_ad" runat="server" kieu_unicode="true" CssClass="css_Gma_c" Width="100%" kt_xoa="K" TaoValid="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ngày kết thúc" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay_kt" runat="server" kieu_unicode="true" CssClass="css_Gma_c" Width="100%" kt_xoa="K" TaoValid="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Đóng BH" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <Cthuvien:kieu ID="co_bh" runat="server" lke=",C" Width="80px" ToolTip="  - Không đóng bảo hiểm,X - Đóng bảo hiểm" CssClass="css_Gma_c" Text="" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_ct_slide" loai="N" runat="server" gridId="GR_ct" />
                        </div>
                        <div class="btex_luoi b_right" id="id_chensp">
                            <ul>
                                <li>
                                    <img alt="" src="/images/eDoc/len.png" title="Chuyển dòng lên" onclick="return daotao_gridn_HangLen();" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/xuong.png" title="Chuyển dòng xuống" onclick="return daotao_gridn_HangXuong();" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/cat.png" title="Cắt các dòng đã chọn" onclick="return daotao_gridn_CatDong();" />
                                </li>
                                <li>
                                    <img alt="" src="/images/eDoc/chen.png" title="Thêm 1 dòng mới" onclick="return daotao_gridn_ChenDong('C');" />
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="900,550" />
</asp:Content>
