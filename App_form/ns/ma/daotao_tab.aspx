<%@ Page Language="C#" AutoEventWireup="true" CodeFile="daotao_tab.aspx.cs" Inherits="f_daotao_tab"
    Title="daotao_tab" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Cthuvien:tab" />
                <img class="b_right" src="../../../../images/eDoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">


                    <div id="TPa" runat="server" class="navi_tabngang width_common">
                        <Cthuvien:tab ID="TPa_tab1" runat="server" CssClass="css_tab_ngang_ac" Width="100px" Text="Tab 1" />
                        <Cthuvien:tab ID="TPa_tab2" runat="server" CssClass="css_tab_ngang_de" Width="100px" Text="Tab 2" />
                        <Cthuvien:tab ID="TPa_tab3" runat="server" CssClass="css_tab_ngang_de" Width="100px" Text="Tab 3" />
                    </div>

                    <div>
                        <asp:Panel ID="Pa_tab1" runat="server" Style="display: block;">
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label lv2 b_left col_30">Ghi chú tab 1</span>
                                <div class="input-group">
                                    <Cthuvien:nd ID="ghichu" runat="server" CssClass="form-control css_nd" kt_xoa="X"
                                        MaxLength="2000" kieu_unicode="true" ten="Ghi chú" ToolTip="Ghi chú"></Cthuvien:nd>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="Pa_tab2" runat="server" Style="display: none;">
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label lv2 b_left col_30">Ghi chú tab2</span>
                                <div class="input-group">
                                    <Cthuvien:nd ID="Nd1" runat="server" CssClass="form-control css_nd" kt_xoa="X"
                                        MaxLength="2000" kieu_unicode="true" ten="Ghi chú" ToolTip="Ghi chú"></Cthuvien:nd>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="Pa_tab3" runat="server" Style="display: none;">
                            <div class="b_left form-group iterm_form">
                                <span class="standard_label lv2 b_left col_30">Ghi chú tab3</span>
                                <div class="input-group">
                                    <Cthuvien:nd ID="Nd2" runat="server" CssClass="form-control css_nd" kt_xoa="X"
                                        MaxLength="2000" kieu_unicode="true" ten="Ghi chú" ToolTip="Ghi chú"></Cthuvien:nd>
                                </div>
                            </div>
                        </asp:Panel>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="kthuoc" runat="server" Value="900,550" />
</asp:Content>
