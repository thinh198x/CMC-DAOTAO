<%@ Page Language="C#" AutoEventWireup="true" CodeFile="file_import_chung.aspx.cs" Inherits="f_file_import_chung"
    Title="file_import_chung" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPa_chon_file" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div id="main_content" class="container_content hide_sbar">
                <div class="r_c_content b_right">
                    <div class="title_dmuc width_common">
                        <Cthuvien:luu ID="tenForm" runat="server" Text="" />
                        <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
                    </div>
                    <div class="width_common auto_sc">
                        <div class="b_left col_50 inner" id="UPa_tk">
                            <div class="grid_table width_common">
                                <div>
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                        CssClass="table gridX" loai="X" hangKt="15" cot="ten_file,ngay,url,so_id,ten" cotAn="so_id,ten" hamRow="file_import_chung_GR_lke_RowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField HeaderText="Tên file" DataField="ten_file"
                                                ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Ngày nhập" DataField="ngay" HeaderStyle-Width="100px"
                                                ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField HeaderText="URL" DataField="url" HeaderStyle-Width="100px"
                                                ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField DataField="so_id" />
                                            <asp:BoundField DataField="ten" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>
                                <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="file_import_chung_P_LKE('K')" />

                            </div>
                        </div>
                        <div class="b_right col_50 inner" id="UPa_ct">
                            <div class="b_left width_common form-group iterm_form">
                                <span class="standard_label b_left col_30">Ngày nhập</span>
                                <div class="input-group">
                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay" runat="server" CssClass="form-control icon_lich" />

                                </div>
                            </div>
                            <div class="b_left width_common form-group iterm_form">
                                <span class="standard_label b_left col_30">Tên File <span class="require">*</span></span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="TEN_FILE" runat="server" CssClass="form-control css_ma" kieu_unicode="true" ten="Tên file" kt_xoa="X" />

                                </div>
                            </div>
                            <div class="b_left width_common form-group iterm_form">
                                <span class="standard_label b_left col_30">Chọn File <span class="require">*</span></span>
                                <div class="input-group">
                                    <asp:FileUpload ID="chon_file" runat="server" CssClass="form-control css_ma" />

                                </div>
                            </div>
                            <div class="b_left width_common form-group iterm_form">
                                <div class="input-group">
                                    <Cthuvien:luu ID="ten" runat="server" CssClass="css_link_X" />
                                </div>
                            </div>
                            <div class="list_bt_action">
                                <button id="nhap" style="text-align: center; padding-top: 5px; padding-bottom: 4px; padding-right: 12px; padding-left: 10px; font-size: 13px;" onclick="return file_import_chung_P_NH();form_P_LOI();" class="bt_action">Nhập</span></button>
                                <button id="xoa" style="text-align: center; padding-top: 5px; padding-bottom: 4px; padding-right: 12px; padding-left: 10px; font-size: 13px;" onclick="return file_import_chung_P_XOA();form_P_LOI();" class="bt_action">Xóa</span></button>
                                <button id="download" style="padding-left: 29px; text-align: center; text-align: center; padding-top: 5px; padding-bottom: 5px;" onclick="return file_import_chung_Download();form_P_LOI();" class="bt_action"><span style="text-align: center; padding-right: 15px;">Download</span></button>
                                <div style="display: none">
                                    <Cthuvien:nhap ID="nhap2" runat="server" Width="70px" Text="Nhập" OnServerClick="nhap_Click" giu="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="nhap2" />
        </Triggers>
    </asp:UpdatePanel>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="850,380" />
        <Cthuvien:an ID="ten_mh" runat="server" Value="" />
        <Cthuvien:an ID="ten_form" runat="server" Value="" />
        <Cthuvien:an ID="nv" runat="server" Value="" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="ten_kq" runat="server" Value="" />
        <Cthuvien:an ID="tra_dong" runat="server" Value="FILE_HTOAN" />
        <Cthuvien:an ID="url" runat="server" Value="" />
        <Cthuvien:an ID="tmuc" runat="server" />
        <Cthuvien:an ID="loai" runat="server" />
        <Cthuvien:an ID="ma_dvi" runat="server" />
        <Cthuvien:an ID="ten_lhd" runat="server" />
        <Cthuvien:an ID="nd" runat="server" />
        <Cthuvien:an ID="tra_luu" runat="server" />
        <Cthuvien:an ID="ten_files" runat="server" />
    </div>
</asp:Content>
