<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_tl_ma_nl.aspx.cs" Inherits="f_ns_tl_ma_nl"
    Title="ns_tl_ma_nl" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh mục ngành nghề" />
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
                        <td class="form_left" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false"
                                            CssClass="table gridX" loai="X" hangKt="10" cotAn="ma_nn,so_id,tt,nsd" hamRow="ns_tl_ma_nl_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Tên ngành nghề" DataField="ten_nn" HeaderStyle-Width="150px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Mã chuyên môn" DataField="ma" HeaderStyle-Width="150px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tên chuyên môn" DataField="ten" HeaderStyle-Width="150px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Trạng thái" DataField="ten_tt" HeaderStyle-Width="100px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ma_nn" />
                                                <asp:BoundField DataField="so_id" />
                                                <asp:BoundField DataField="tt" />
                                                <asp:BoundField DataField="nsd" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" rong="70" loai="X" gridId="GR_lke"
                                            ham="ns_tl_ma_nl_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr style="display: none">
                                                <td>
                                                    <Cthuvien:ma ID="so_id" runat="server" kt_xoa="X" /></td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Ngành nghề" Width="80px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="MA_NN" ten="Mã ngành nghề" runat="server" Width="270px" ktra="DT_NN" onchange="ns_tl_ma_nl_P_KTRA('MA')" kt_xoa="G" />
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Mã chuyên môn" />
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="MA" runat="server" CssClass="css_form" kieu_chu="True" ten="Mã ngành nghề"
                                                                    kt_xoa="L" MaxLength="3" onchange="ns_tl_ma_nl_P_KTRA('MA')" Width="150px" />
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
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu" Text="Tên ngành nghề" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" ten="Tên ngành nghề"
                                                        Width="270px" MaxLength="500"></Cthuvien:ma>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Trạng thái" Width="70px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_list ID="TT" ten="Trạng thái" runat="server" Width="270px" lke="Áp dụng,Ngừng áp dụng" tra="A,N" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu">Ghi chú</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:nd ID="ghichu" runat="server" TextMode="MultiLine" CssClass="css_form" kt_xoa="X" Height="50px"
                                                        Width="270px" MaxLength="1000"></Cthuvien:nd>
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
                                                    <div class="box3 txCenter">
                                                        <a href="#" onclick="return ns_tl_ma_nl_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" onclick="return ns_tl_ma_nl_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_tl_ma_nl_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                    </div>
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="FileMau" runat="server" Text="Mẫu excel" Width="70px" OnServerClick="FileMau_Click" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="XuatExcel" runat="server" Width="100px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_tl_ma_nl_P_EXCEL();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">X</span>uất excel</a>
                                                        <a href="#" onclick="return ns_tl_ma_nl_P_MAU();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">E</span>xcel mẫu</a>
                                                        <a href="#" onclick="return ns_tl_ma_nl_FILE_IMPORT();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">Nh</span>ập excel</a>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1100,500" />
</asp:Content>
