<%@ Page Title="ns_ktkl_kt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ktkl_kt.aspx.cs" Inherits="f_ns_ktkl_kt" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Khen thưởng" />
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
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="15" cotAn="so_id" hamRow="ns_ktkl_kt_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Số TT" DataField="sott" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Số QĐ" DataField="soqd" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Ngày QĐ" DataField="ngayqd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                <asp:BoundField HeaderText="so_id" DataField="so_id" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="150" gridId="GR_lke"
                                            ham="ns_ktkl_kt_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label10" runat="server" Text=" Mã số CB"></Cthuvien:bbuoc>
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_form" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten" placeholder="Nhấn (F1)" kt_xoa="K" 
                                                        ToolTip="Mã số cán bộ" kieu_chu="true" Width="120px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_ktkl_kt_P_KTRA('SO_THE')" gchu="gchu" />
                                                </td>
                                                <td><Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu2" kt_xoa="X" Font-Bold="true" /></td>
                                                

                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label9" runat="server" Text="Tên" CssClass=" css_gchu_a"></Cthuvien:bbuoc>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:ma ID="ten" ten="Tên cán bộ" runat="server" CssClass="css_form" kt_xoa="K" 
                                                        ToolTip="Họ tên cán bộ" kieu_unicode="true" Width="242px" ReadOnly="true" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="phong" ten="Phòng" runat="server" CssClass="css_form" kt_xoa="K" 
                                                        ToolTip="Phòng ban" kieu_unicode="true" Width="120px" ReadOnly="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label2" runat="server" Text="Số quyết định" CssClass="css_gchu" />
                                    </td>

                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="SOQD" ten="Số quyết định" runat="server" kt_xoa="X" CssClass="css_form" Width="120px" kieu_chu="true" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label7" runat="server" Text="Ngày quyết định" Width="110px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYQD" ten="Ngày quyết định" runat="server" Width="120px" CssClass="css_form_c" kt_xoa="X" kieu_luu="S" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label3" runat="server" Text="Hình thức KT" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="hinhthuc" ten="Hình thức khen thưởng" ToolTip="Hình thức khen thưởng" runat="server" placeholder="Nhấn (F1)"
                                                        CssClass="css_form" BackColor="#f6f7f7" ktra="ns_ma_htkt,ma,ten" kieu_chu="true" Width="120px" kt_xoa="X"
                                                        f_tkhao="~/App_form/ns/ktkl/ma/ns_ma_htkt.aspx" onfocusout="ns_ktkl_kt_P_KTRA('hinhthuc')" gchu="gchu" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label6" runat="server" Text="Mức thưởng" Width="110px" CssClass="css_gchu_c" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:so ID="mucthuong" ten="Mức thưởng" ToolTip="Mức thưởng" runat="server"
                                                        kt_xoa="X" CssClass="css_form_r" Width="120px" ValueText="0" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label22" runat="server" Text="Lý do KT" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="lydo" ten="Lý do khen thưởng" ToolTip="Lý do khen thưởng" runat="server"
                                            kt_xoa="X" CssClass="css_form" Width="362px" kieu_unicode="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label4" runat="server" Text="Cấp khen thưởng" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="cap_ktkl" ten="Cấp khen thưởng" ToolTip="Mã cấp khen thưởng" runat="server" placeholder="Nhấn (F1)"
                                                        CssClass="css_form" BackColor="#f6f7f7" ktra="ns_ma_cap_ktkl,ma,ten" kieu_chu="true" Width="120px" kt_xoa="X"
                                                        f_tkhao="~/App_form/ns/ktkl/ma/ns_ma_cap_ktkl.aspx" onfocusout="ns_ktkl_kt_P_KTRA('CAP_KTKL')" gchu="gchu" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label8" runat="server" Text="Nơi khen thưởng" Width="110px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="noi_ktkl" ten="Nơi khen thưởng" ToolTip="Mã nơi khen thưởng" runat="server" placeholder="Nhấn (F1)"
                                                        CssClass="css_form" BackColor="#f6f7f7" ktra="ns_ma_noi_ktkl,ma,ten" kieu_chu="true" Width="120px" kt_xoa="X"
                                                        f_tkhao="~/App_form/ns/ktkl/ma/ns_ma_noi_ktkl.aspx" onfocusout="ns_ktkl_kt_P_KTRA('NOI_KTKL')" gchu="gchu" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label5" runat="server" Text="Người ký" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="nguoiky" ten="Người ký" ToolTip="Người ký quyết định" runat="server"
                                            kt_xoa="X" CssClass="css_form" Width="362px" kieu_unicode="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label1" runat="server" Text="Ghi chú" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="ghichu" ten="Ghi chú" ToolTip="Ghi chú" runat="server"
                                            kt_xoa="X" CssClass="css_form" Width="362px" kieu_unicode="true" TextMode="MultiLine" Height="50px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight">
                                                        <%--<a href="#" onclick="return ns_ktkl_kt_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_ktkl_kt_P_MOI_FULL();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_ktkl_kt_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>--%>
                                                        <a href="#" onclick="return ns_ktkl_kt_P_IN();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">X</span>uất excel</a>                                                        
<%--                                                        <a href="#" onclick="return nhap_file();" class="bt bt-grey"><span class="txUnderline">F</span>ile</a>--%>
                                                    </div>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="display: none">                                                    
                                                                                              
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
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
    <Cthuvien:an ID="so_id" runat="server" value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="900,650" />
</asp:Content>
