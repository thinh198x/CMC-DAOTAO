<%@ Page Title="ns_ma_cdanh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ma_cdanh.aspx.cs" Inherits="f_ns_ma_cdanh" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh mục vị trí chức danh" />
                <img class="b_right" src="../../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_46">
                <div class="b_left col_40 inner" id="UPa_tk">
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" Width="100%" loai="X" hangKt="15" cotAn="so_id,tt,ghichu,nsd" hamRow="ns_ma_cdanh_GR_lke_RowChange()">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã  <br/> ngành nghề" HtmlEncode="false" DataField="ma_nnghe" HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mã  <br/> chuyên môn" HtmlEncode="false" DataField="ma_cmon" HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mã ngạch <br/> nghề nghiệp" HtmlEncode="false" DataField="ma_nnnghe" HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mã <br/>cấp bậc" HtmlEncode="false" DataField="ma_capbac" HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Mã chức danh" DataField="ma" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="css_Gma" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tên chức danh" DataField="ten" HeaderStyle-Width="150px">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Trạng thái" DataField="tthai">
                                        <ItemStyle CssClass="css_Gnd" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Phê <br/> duyệt" HtmlEncode="false" DataField="pduyet">
                                        <ItemStyle CssClass="css_ma_c" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="so_id" /> 
                                    <asp:BoundField DataField="tt" />
                                    <asp:BoundField DataField="ghichu" />
                                    <asp:BoundField DataField="nsd" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                         <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_ma_cdanh_P_LKE()" />
                    </div>
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="excel" runat="server" Text="Xuất excel" hoi="3"  class="bt_action" Width="100px" OnClick="return ns_ma_cdanh_P_IN();form_P_LOI();" />
                    </div>
                </div>

                 <div class="b_right col_60 inner" id="UPa_ct">
                     <div style="display:none">
                         <Cthuvien:DR_lke ID="MA_NNGHE" runat="server" kieu_chu="True" ten="Tên ngành nghề" MaxLength="30" kt_xoa="K" ktra="DT_NN" Width="120px" onchange="ns_ma_cdanh_P_KTRA('MA_NN')" />
                         <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu2" kt_xoa="X" Font-Bold="true" />
                         <Cthuvien:DR_lke ID="MA_CMON" runat="server" ktra="DT_CM" kieu_chu="True" ten="Tên chuyên môn" onchange="ns_ma_cdanh_P_KTRA('MA_CM')" Width="120px" kt_xoa="G" />
                         <Cthuvien:DR_lke ID="MA_NNNGHE" runat="server" kieu_chu="True" ten="Tên ngạch nghề nghiệp"
                                            kt_xoa="K" ktra="DT_NL" Width="120px" onchange="ns_ma_cdanh_P_KTRA('MA_NL')" />
                         <Cthuvien:DR_lke ID="MA_CAPBAC" runat="server" ktra="DT_CB" kieu_chu="True" ten="Tên cấp bậc nghề nghiệp" onchange="ns_ma_cdanh_P_KTRA('MA_CB')" Width="120px" kt_xoa="M" />

                     </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Nhóm chức danh</span>
                            <div class="input-group">
                                
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Tên Nhóm chức danh*</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="TEN" runat="server"  CssClass="form-control css_ma" kieu_unicode="True" kt_xoa="X" ten="Tên Nhóm chức danh"
                                                        MaxLength="255"></Cthuvien:ma>
                            </div>
                        </div>
                    </div> 
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Trạng thái*</span>
                            <div class="input-group">
                               <Cthuvien:DR_list ID="TT" ten="Trạng thái"  CssClass="form-control css_list" runat="server" lke="Áp dụng,Ngừng áp dụng" tra="A,N" />
                            </div>
                        </div>
                    </div>
                    <div class="width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mô tả</span>
                            <div class="input-group">
                               <Cthuvien:nd ID="ghichu" CssClass="form-control css_ma" runat="server" TextMode="MultiLine"  kt_xoa="X" Height="50px"
                                                         MaxLength="1000" kieu_unicode="true"></Cthuvien:nd>
                            </div>
                        </div>
                    </div> 
                    <div class="list_bt_action">
                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" hoi="4" class="bt_action" anh="K" Width="90px" OnClick="return ns_hdns_ma_nnn_P_MOI();form_P_LOI();" />
                        <Cthuvien:nhap ID="nhap" runat="server" Text="Ghi" Width="90px" class="bt_action" anh="K" OnClick="return ns_hdns_ma_nnn_P_NH();form_P_LOI();" />
                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" Width="90px" class="bt_action" anh="K" OnClick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" />
                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" Width="90px" class="bt_action" anh="K" OnClick="return ns_hdns_ma_nnn_P_XOA();form_P_LOI();" />
                    </div>
                </div>

            </div>
        </div>
    </div>

    
    <Cthuvien:an ID="kthuoc" runat="server" Value="1300,665" />
</asp:Content>
