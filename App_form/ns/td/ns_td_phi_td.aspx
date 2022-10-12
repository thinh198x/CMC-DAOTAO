<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_td_phi_td.aspx.cs" Inherits="f_ns_td_phi_td"
    Title="ns_td_phi_td" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Quản lý chi phí tuyển dụng" />
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
                        <td align="left" valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 234px">
                                        <table id="Upa_tk" cellpadding="1" cellspacing="1" width="100%">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label9" runat="server" Width="65px" Text="Năm" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <table cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="nam_tk" runat="server" CssClass="css_form" kieu_chu="True" kt_xoa="G"
                                                                    ToolTip="Năm yêu cầu tuyển dụng" Width="120px" ten="Năm yêu cầu" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Bbuoc4" runat="server" Width="65px" Text="Mã yêu cầu" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <table cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="ma_yc_tk" placeholder="Nhấn (F1)" runat="server" Width="120px" CssClass="css_form"
                                                                    BackColor="#f6f7f7" kieu_chu="true" f_tkhao="~/App_form/ns/td/ns_td_khct.aspx"
                                                                    kt_xoa="X" onchange="ns_td_kq_P_LKE_DS()" ktra="ns_td_khct,ma,ma" ToolTip="Mã yêu cầu tuyển dụng" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label10" runat="server" Width="70px" Text="Vị trí TD" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="cdanh_tk" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="True" f_tkhao="~/App_form/ns/hdns/tl/ns_ma_cdanh.aspx"
                                                                    kt_xoa="X" ktra="ns_ma_cdanh,ma,ten" ToolTip="Vị trí TD" Width="120px" ten="Vị trí TD" placeholder="Nhấn (F1)" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Bbuoc2" runat="server" Width="70px" Text="Đơn vị" CssClass="css_gchu" />
                                                </td>
                                                <td> 
                                                    <Cthuvien:DR_lke ID="phong_tk" kt_xoa="X" ten="Đơn vị" ktra="DT_PHONG" runat="server" Width="322px">                                                                                
                                                    </Cthuvien:DR_lke>
                                                </td>
                                                <td style="padding-top: 5px; padding-bottom: 5px">
                                                    <a href="#" onclick="return ns_td_phi_td_P_LKE();form_P_LOI();" class="bt bt-grey"><i class="fa fa-search"></i>Tìm kiếm</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="height: 400px; width: 600px; overflow: scroll">
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="12" cotAn="nsd,cdanh,phong,ghichu," hamRow="ns_td_phi_td_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gma" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Mã tuyển dụng" DataField="ma_yc" HeaderStyle-Width="200px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Vị trí TD" DataField="ten_cdanh" HeaderStyle-Width="200px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Đơn vị TD" DataField="ten_phong" HeaderStyle-Width="200px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Số lượng TD" DataField="sl_tuyendung" HeaderStyle-Width="200px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Tên hạng mục" DataField="ten_hangmuc" HeaderStyle-Width="200px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Số tiền chi phí" DataField="tien_cphi" HeaderStyle-Width="200px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="cdanh" DataField="cdanh">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="phong" DataField="phong">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Ghi chú" DataField="ghichu">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="nsd" DataField="nsd">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" rong="100" loai="X" gridId="GR_lke"
                                            ham="ns_td_phi_td_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu">Năm TD</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="NAM" ten="Năm tuyển dụng" kieu_so="true" runat="server" CssClass="css_form_r" kt_xoa="X" Width="150px" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Label4" runat="server" Width="100px" CssClass="css_gchu_c">Mã TD</Cthuvien:bbuoc>
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="ma_yc" placeholder="Nhấn (F1)" runat="server" Width="150px" CssClass="css_form"
                                                                    BackColor="#f6f7f7" kieu_chu="true" f_tkhao="~/App_form/ns/td/ns_td_khct.aspx"
                                                                    kt_xoa="X" ktra="ns_td_khct,ma,ma" ToolTip="Mã yêu cầu tuyển dụng" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label5" runat="server" CssClass="css_gchu">Vị trí TD</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="cdanh" ten="vị trí tuyển dụng" runat="server" CssClass="css_form" kt_xoa="X" Width="150px" Enabled="false" ReadOnly="false" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Label6" runat="server" Width="100px" CssClass="css_gchu_c">Đơn vị TD</Cthuvien:bbuoc>
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="phong" ten="đơn vị tuyển dụng" runat="server" CssClass="css_form" kt_xoa="X" Width="150px" Enabled="false" ReadOnly="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label7" runat="server" CssClass="css_gchu">Số lượng TD</asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="sl_tuyendung" ten="vị trí tuyển dụng" runat="server" CssClass="css_form" kt_xoa="X" Width="150px" Enabled="false" ReadOnly="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label1" runat="server" CssClass="css_gchu">Tên hạng mục</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="TEN_HANGMUC" ten="Tên hạng mục" runat="server" CssClass="css_form" kieu_unicode="True"
                                                                    kt_xoa="X" Width="150px" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Label3" runat="server" CssClass="css_gchu_c" Width="100px">Số tiền chi phí</Cthuvien:bbuoc>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:so ID="TIEN_CPHI" ten="Số tiền chi phí" runat="server" CssClass="css_form_r" kt_xoa="X" Width="150px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label8" runat="server" Text="Ghi chú" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nd ID="ghichu" runat="server" kt_xoa="X" CssClass="css_form" Width="410px"
                                                        kieu_unicode="true" ToolTip="Ghi chú" TextMode="MultiLine" Height="50px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="center" style="padding-left: 20px">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1" class="box3 txRight">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_td_phi_td_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_td_phi_td_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return ns_td_phi_td_P_IN();form_P_LOI();" class="bt bt-grey"><i class="fa fa-excel"></i><span class="txUnderline">X</span>uất excel</a>
                                                    </div>
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="XuatExcel" runat="server" Width="100px" Text="Xuất excel" OnServerClick="XuatExcel_Click" />
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
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="phongtk" runat="server" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1200,700" />
</asp:Content>
