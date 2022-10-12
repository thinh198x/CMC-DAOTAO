<%@ Page Title="tl_tlap_ngaynghi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_tlap_ngaynghi.aspx.cs" Inherits="f_tl_tlap_ngaynghi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Ngày nghỉ lễ" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <div class="acc">
                                            <ul>
                                                <li><a href="#" onclick="return form_dong();"><i class="fa fa-sign-out"></i></a></li>
                                                <li><a href="#" onclick="return form_GOP();"><i class="fa fa-envelope-o"></i></a></li>
                                                <li><a href="#" onclick="return form_HELP();"><i class="fa fa-question"></i></a></li>
                                                <%--  <li class="vline"></li>--%>
                                                <%-- <li><i class="fa fa-user blue maR5"></i><span class="sz12">
                                                    <Cthuvien:luu ID="nsd" runat="server" Text="" CssClass="css_nsd" dich="K" /></span></li>--%>
                                            </ul>
                                            <div class="clear"></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="L" hangKt="15" hamRow="tl_tlap_ngaynghi_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Ngày thiết lập" DataField="ngay_thietlap" HeaderStyle-Width="120px"
                                                    ItemStyle-CssClass="css_Gma_c" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="middle" class="form_right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Label6" runat="server" Text="Ngày thiết lập" Width="120px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_THIETLAP" ten="Ngày thiết lập" runat="server" CssClass="css_form" Width="120px" kt_xoa="X" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Trạng thái" Width="120px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="TT" ten="Trạng thái" runat="server" DataTextField="ten" DataValueField="ma"
                                                                    CssClass="css_form" kieu="S" Width="190">
                                                                    <asp:ListItem Selected="True" Text="Áp dụng" Value="A"></asp:ListItem>
                                                                    <asp:ListItem Text="Ngừng áp dụng" Value="N"></asp:ListItem>
                                                                </Cthuvien:DR_nhap>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="N" cot="ma_nl,ten_nl,ngayd,ngayc,noidung" cotAn="so_id"
                                                        hangKt="14">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:TemplateField HeaderText="Mã nghỉ lễ(*)" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="ma_nl" runat="server" Width="100px" CssClass="css_Gma_c" kieu_chu="true"
                                                                        ToolTip="Mã ngày nghỉ (*)" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Tên nghỉ lễ(*)" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="ten_nl" runat="server" Width="100px" ten="Nội dung" ToolTip="Tên ngày nghỉ (*)" Text="" CssClass="css_Gma" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Từ ngày(*)" HeaderStyle-Width="90px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" runat="server" Width="90px" CssClass="css_Gma_c" kieu_luu="I" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Tới ngày(*)" HeaderStyle-Width="90px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" runat="server" Width="90px" CssClass="css_Gma_c" kieu_luu="I" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Mô tả" HeaderStyle-Width="250px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="noidung" runat="server" Width="250px" ten="Nội dung" ToolTip="Nội dung ngày nghỉ" Text="" CssClass="css_Gma" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 10px">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="right">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return tl_tlap_ngaynghi_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return tl_tlap_ngaynghi_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return tl_tlap_ngaynghi_P_MOI();form_P_LOI();" class="bt bt-grey">Mới</a>
                                                        <a href="#" onclick="return dgnl_dm_n_nl_P_IN();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">X</span>uất excel</a>
                                                    </div>
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="2" class="css_border" align="left">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="960,680" />
    </div>
</asp:Content>
