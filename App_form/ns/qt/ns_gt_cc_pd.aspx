<%@ Page Title="ns_gt_cc_pd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_gt_cc_pd.aspx.cs" Inherits="f_ns_gt_cc_pd" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Phê duyệt thông tin giải trình chấm công của CBNV" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_5_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Phòng</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="PHONG" ktra="DT_PHONG" ten="Phòng" kt_xoa="X" runat="server" CssClass="form-control css_list"></Cthuvien:DR_lke>
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Từ ngày</span>
                            <div class="input-group">
                                <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYD" ten="Từ ngày" runat="server" CssClass="form-control icon_lich"
                                    kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Đến ngày</span>
                            <div class="input-group">
                                 <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYC" ten="Đến ngày" runat="server" CssClass="form-control icon_lich"
                                    kt_xoa="X" />
                            </div>
                        </div>
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Trạng thái</span>
                            <div class="input-group">
                                <Cthuvien:DR_nhap ID="tinhtrang" runat="server" kieu="U" CssClass="form-control">
                                    <asp:ListItem Value="0" Selected="True" Text="Chờ phê duyệt"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Đã phê duyệt"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Không phê duyệt"></asp:ListItem>
                                </Cthuvien:DR_nhap>
                            </div>
                        </div>
                        <div class="b_right form-group lv2 iterm_form">
                            <Cthuvien:nhap ID="tim" class="bt_action" anh="K" runat="server" Text="Tìm kiếm" Width="90px" OnClick="ns_gt_cc_pd_P_LKE();form_P_LOI('');" Title="Tìm kiếm" />
                        </div>
                    </div>
                    <div class="grid_table mgt10 width_common">
                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                            CssClass="table gridX" loai="N" hangKt="15" Width="100%" cotAn="SO_ID"
                            cot="SO_ID,chon,MA_NV,HO_TEN,TEN_CDANH,TEN_PHONG,NGAY_GT,MACC_NGHI,LY_DO,LYDO_LD">
                            <Columns>
                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="5px" />
                                <asp:BoundField DataField="SO_ID" ItemStyle-CssClass="css_Gma_c" />
                                <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                    <ItemTemplate>
                                        <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn phê duyệt" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Mã NV" DataField="MA_NV" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField HeaderText="Tên NV" DataField="ho_ten" HeaderStyle-Width="160px" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Chức danh" DataField="TEN_CDANH" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Phòng" DataField="TEN_PHONG" ItemStyle-CssClass="css_Gma" />
                                <asp:BoundField HeaderText="Ngày giải trình" DataField="NGAY_GT" ItemStyle-CssClass="css_Gma_c" />
                                <asp:BoundField HeaderText="Công giải trình" DataField="MACC_NGHI" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="160px" />
                                <asp:BoundField HeaderText="Lý do" DataField="LY_DO" ItemStyle-CssClass="css_Gma" HeaderStyle-Width="160px" />
                                <asp:TemplateField HeaderText="Lý do KPD(*)" ItemStyle-CssClass="css_Gma_c" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="LYDO_LD" runat="server" Width="200px" CssClass="css_Gma"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </Cthuvien:GridX>
                        <div id="GR_lke_td">
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_gt_cc_pd_P_LKE()" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="Nhap1" class="bt_action" anh="K" runat="server" Text="Phê duyệt" Width="120px" title="Phê duyệt" OnClick="return ns_gt_cc_pd_P_PHEDUYET('C');form_P_LOI();" />
                        <Cthuvien:nhap ID="thanhly" class="bt_action" anh="K" runat="server" Text="Không phê duyệt" Width="130px" title="Không phê duyệt" OnClick="return ns_gt_cc_pd_P_KOPHEDUYET();form_P_LOI();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1100,620" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="phongc" runat="server" />
    </div>
    <%-- KTRA--%>
</asp:Content>

