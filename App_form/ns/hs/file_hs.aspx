<%@ Page Language="C#" AutoEventWireup="true" CodeFile="file_hs.aspx.cs" Inherits="f_file_hs"
    Title="file_hs" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPa_chon_file" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div id="main_content" class="container_content hide_sbar">
                <div class="r_c_content b_right">
                    <div class="title_dmuc width_common">
                        <Cthuvien:luu ID="tenmanhinh" runat="server"  Text="" />
                        <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
                    </div>
                    <div class="width_common auto_sc line_55">
                        <div class="b_left col_50 inner" id="UPa_tk">
                            <div class="grid_table width_common">
                                <div>
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                        CssClass="table gridX" loai="X" hangKt="5" cotAn="url,so_id,ten" hamRow="file_hs_GR_lke_RowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField HeaderText="Tên file" DataField="ten_file" 
                                                ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Ngày nhập" DataField="ngay" HeaderStyle-Width="120px"
                                                ItemStyle-CssClass="css_Gma_c" />
                                            <asp:BoundField HeaderText="url" DataField="url" HeaderStyle-Width="100px"
                                                ItemStyle-CssClass="css_Gnd" />
                                            <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                            <asp:BoundField HeaderText="ten" DataField="ten" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                    <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="file_hs_P_LKE('K')" /> 
                                </div>
                            </div>
                        </div>
                        <div class="b_right col_50 inner" id="UPa_ct">
                            <div class="b_left form-group iterm_form" style="display: none;">
                                <span class="standard_label b_left col_30">Ngày</span>
                                <div class="input-group">
                                    <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="ngay" runat="server" CssClass="form-control icon_lich" Width="120px" />

                                </div>
                            </div>
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_30">Tên File</span>
                                <div class="input-group">
                                    <Cthuvien:ma ID="TEN_FILE" runat="server" CssClass="form-control css_ma" ten="Tên file" kt_xoa="X" />

                                </div>
                            </div>
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label b_left col_30">Chọn file</span>
                                <div class="input-group">
                                    <asp:FileUpload ID="CHON_FILE" runat="server" CssClass="form-control" />

                                </div>
                                <div>
                                    <Cthuvien:luu ID="ten" runat="server" CssClass="css_link_X" />
                                </div>
                            </div>
                            <div class="list_bt_action">
                                <button onclick="return file_hs_P_NH();form_P_LOI();" class="bt_action">Nhập</button>
                                <button onclick="return file_hs_P_XOA();form_P_LOI();" class="bt_action">Xóa</button>
                                <button onclick="return dowload_file();form_P_LOI();" class="bt_action">Download</button>
                            </div>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="850,350" />
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
