<%@ Page Language="C#" AutoEventWireup="true" CodeFile="file_anh.aspx.cs" Inherits="f_file_anh"
    Title="file_anh" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPa_chon_file" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div id="main_content" class="container_content hide_sbar">
                <div class="r_c_content b_right">
                    <div class="title_dmuc width_common">
                        <Cthuvien:luu ID="tenForm" runat="server" Text="Upload ảnh" />
                        <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
                    </div>

                    <div class="width_common auto_sc">
                        <div class="b_right col_100 inner" id="UPa_ct">
                            <div class="b_left width_common form-group iterm_form">
                                <span class="standard_label b_left col_20">Chọn File</span>
                                <div class="input-group">
                                    <asp:FileUpload ID="chon_file" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div style="display: none">
                                <Cthuvien:luu ID="Luu1" runat="server" Text="File ảnh phải nhỏ hơn 1 MB" CssClass="css_phude" />
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" />
                                <Cthuvien:nhap ID="mo" runat="server" Width="70px" Text="Lưu" OnServerClick="mo_ServerClick" />
                            </div>
                            <div class="list_bt_action">
                                <button onclick="return file_anh_P_DAT();form_P_LOI('');" class="bt_action">Nhập</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="mo" />
        </Triggers>
    </asp:UpdatePanel>
    <Cthuvien:an ID="kthuoc" runat="server" Value="550,220" />
    <div id="UPa_hi">
        <Cthuvien:an ID="tmuc" runat="server" />
        <Cthuvien:an ID="ten" runat="server" />
        <Cthuvien:an ID="loai" runat="server" />
        <Cthuvien:an ID="ma_dvi" runat="server" />
        <Cthuvien:an ID="nd" runat="server" />
        <Cthuvien:an ID="tra_luu" runat="server" />
        <Cthuvien:an ID="tra_dong" runat="server" />
        <Cthuvien:an ID="b_link" runat="server" />
        <Cthuvien:an ID="b_form" runat="server" />
    </div>
</asp:Content>
