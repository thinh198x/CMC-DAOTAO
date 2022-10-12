<%@ Page Title="ns_dt_dsdaotao" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_dsdaotao.aspx.cs" Inherits="f_ns_dt_dsdaotao" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh sách đào tạo" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Tinh trạng</span>
                            <div class="input-group">
                                <Cthuvien:DR_list ID="tinhtrang" runat="server" CssClass="form-control css_list" onchange="ns_dt_dsdaotao_P_KTRA('tinhtrang')"
                                    ten="Tình trạng" tra="0,1" lke="Chưa phê duyệt,Đã phê duyệt" kt_xoa="X" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="N" hangKt="15" cotAn="so_id" Width="100%"
                                cot="chon,so_id,ma,ten,noidt,ngaytrinh,ngayd,ngayc,kinhphi,giatri,ykien">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn phê duyệt" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="so_id" DataField="so_id" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên khóa đào tạo" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Nơi đào tạo" DataField="noidt" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày trình" DataField="ngaytrinh" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Từ ngày" DataField="ngayd" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đến ngày" DataField="ngayc" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Nguồn kinh phí" DataField="kinhphi" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="Tiền" DataField="giatri" ItemStyle-CssClass="css_Gso" />
                                    <asp:TemplateField HeaderText="Ý kiến phản hồi" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ykien" runat="server" Width="100%" CssClass="css_Gma" kt_xoa="X" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_dsdaotao_P_LKE('K')" />

                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Width="70px" class="bt_action" anh="K" Text="Xem" OnClick="return ns_dt_dsdaotao_P_XEM();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Width="100px" class="bt_action" anh="K" Text="Phê duyệt" OnClick="return ns_dt_dsdaotao_P_PHEDUYET();form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Width="150px" class="bt_action" anh="K" Text="Không phê duyệt" OnClick="return ns_dt_dsdaotao_P_KOPHEDUYET();form_P_LOI();" />
                        <Cthuvien:nhap ID="Nhap1" runat="server" Width="120px" class="bt_action" anh="K" Text="Hủy phê duyệt" OnClick="return ns_dt_dsdaotao_P_HUYPHEDUYET();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1350,600" />
    </div>
</asp:Content>
