<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dt_ma_cp_cha.aspx.cs" Inherits="f_ns_dt_ma_cp_cha"
    Title="ns_dt_ma_cp_cha" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left"><%-- style="width: 553px">--%>
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục hạng mục chi phí cha" />
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
                                            </ul>
                                            <div class="clear"></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="form_left" valign="top"><%--style="height: 273px; width: 553px">--%>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="False" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="10" cotAn="nsd,tt,mota" hamRow="ns_dt_ma_cp_cha_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px">
                                                    <HeaderStyle Width="10px"></HeaderStyle>
                                                </asp:BoundField>

                                                <asp:BoundField HeaderText="Mã hạng mục cha" DataField="ma" HeaderStyle-Width="120px">
                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                    <ItemStyle CssClass="css_Gma_c" />
                                                </asp:BoundField>

                                                <asp:BoundField HeaderText="Tên hạng mục cha" DataField="ten" HeaderStyle-Width="130px">
                                                    <HeaderStyle Width="130px"></HeaderStyle>
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>

                                                <asp:BoundField HeaderText="Trạng thái" DataField="ten_tt" HeaderStyle-Width="120px">
                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="tt" />
                                                <asp:BoundField DataField="mota" />


                                                <asp:BoundField HeaderText="nsd" DataField="nsd">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>

                                            </Columns>
                                        </Cthuvien:GridX>


                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" rong="70" loai="X" gridId="GR_lke"
                                            ham="ns_dt_ma_cp_cha_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right"><%--style="height: 273px">--%>
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Mã hạng mục cha" />
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="MA" runat="server" CssClass="css_form" kieu_chu="True" ten="Mã hạng mục cha"
                                                                    kt_xoa="G" onchange="ns_dt_ma_cp_cha_P_KTRA('MA')" Width="150px" MaxLength="30" />
                                                            </td>
                                                            <td style="width: 100px">
                                                                <Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu2" kt_xoa="X" Font-Bold="true" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Tên hạng mục cha" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" ten="Tên hạng mục cha"
                                                        Width="270px"></Cthuvien:ma>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Trạng thái" />
                                                </td>
                                                <td align="left">
                                                    <%--<Cthuvien:kieu ID="tt" runat="server" lke="A,N" Width="30px" ToolTip="A - Áp dụng, N - Ngừng áp dụng" CssClass="css_form_c" Text="A" />--%>
                                                    <Cthuvien:DR_nhap ID="TT" ten="Trạng thái" runat="server" DataTextField="ten" DataValueField="ma" 
                                                        CssClass="css_form" kieu="S" Width="270px">
                                                        <asp:ListItem Selected="True" Text="Chọn trạng thái" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="Áp dụng" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="Ngừng áp dụng" Value="N"></asp:ListItem>
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu">Mô tả</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="mota" runat="server" TextMode="MultiLine" CssClass="css_form" kt_xoa="X" Height="50px"
                                                        Width="270px" ten="Mô tả"></Cthuvien:nd>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" runat="server" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td align="center">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_dt_ma_cp_cha_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_dt_ma_cp_cha_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                        <a href="#" onclick="return ns_dt_ma_cp_cha_P_IN();form_P_LOI();" class="bt bt-grey"><i class="fa fa-excel"></i><span class="txUnderline">X</span>uất excel</a>
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
                            <div id="UPa_gchu" class="css_border" align="left">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="900,500"/>
</asp:Content>

