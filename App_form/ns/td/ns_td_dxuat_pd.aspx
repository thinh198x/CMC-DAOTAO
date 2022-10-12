<%@ Page Title="ns_td_dxuat_pd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_dxuat_pd.aspx.cs" Inherits="f_ns_td_dxuat_pd" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Phê duyệt đề xuất tuyển dụng" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_ct">
                    <div class="col_3_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Tình trạng</span>
                            <div class="input-group">
                                <Cthuvien:DR_nhap ID="tinhtrang" ten="Tình trạng" runat="server" DataTextField="ten" DataValueField="ma"
                                    CssClass="form-control" onchange="ns_td_dxuat_pd_P_KTRA('tinhtrang')">
                                    <asp:ListItem Text="Chờ phê duyệt" Value="0" />
                                    <asp:ListItem Text="Đã phê duyệt" Value="1" />
                                    <asp:ListItem Text="Không phê duyệt" Value="2" />
                                </Cthuvien:DR_nhap>
                            </div>
                        </div>

                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="N" cot="chon,so_id,phong,phong_ten,cdanh,Cdanh_ten,db_duocduyet,ngay_dexuat,soluong_td,ykien_ld"
                                hangKt="10" cotAn="phong,so_id,cdanh" hamRow="ns_td_dexuat_pd_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn phê duyệt" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Số id" DataField="so_id" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã phòng" DataField="phong" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Phòng ban" DataField="phong_ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Mã chức danh" DataField="cdanh" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Chức danh" DataField="Cdanh_ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Số lượng được tuyển" DataField="db_duocduyet" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:BoundField HeaderText="Ngày đề xuất" DataField="ngay_dexuat" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Số lượng tuyển" DataField="soluong_td" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_r" />
                                    <asp:TemplateField HeaderText="Ý kiến" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <Cthuvien:ma ID="ykien_ld" runat="server" Width="200px" CssClass="css_Gnd" kieu_unicode="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_td_dxuat_pd_P_LKE('K')" />

                    </div>
                    <div class="b_left width_common mgt10 form-group iterm_form">
                        <span class="standard_label b_left col_10">Nội dung</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="noidung" ten="Nội dung" runat="server" kt_xoa="X" CssClass="form-control css_ma" kieu_unicode="true"
                                TextMode="MultiLine" ReadOnly="true" Rows="10" Height="200px" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                         <img style="padding-top: 5px;" runat="server" alt="" src="~/images/bitmaps/dong.png" title="Chọn tất cả" onclick="return ns_td_dxuat_CHON();" />
                        <button onclick="return ns_td_dxuat_pd_P_PHEDUYET();form_P_LOI();" class="bt_action"><span class="txUnderline">P</span>hê duyệt</button>
                        <button onclick="return ns_td_dxuat_pd_P_KOPHEDUYET();form_P_LOI();" class="bt_action"><span class="txUnderline">K</span>hông phê duyệt</button>

                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1023,800" />
    </div>
</asp:Content>
