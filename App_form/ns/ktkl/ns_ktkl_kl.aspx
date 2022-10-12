<%@ Page Title="ns_ktkl_kl" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ktkl_kl.aspx.cs" Inherits="f_ns_ktkl_kl" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Kỷ luật" />
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
                                            CssClass="table gridX" loai="X" hangKt="12" cotAn="so_id" hamRow="ns_ktkl_kl_GR_lke_RowChange()">
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
                                            ham="ns_ktkl_kl_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label10" runat="server" Text=" Mã số CB" CssClass="css_gchu_a" Width="90px"></Cthuvien:bbuoc>
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" runat="server" CssClass="css_form" BackColor="#f6f7f7" ktra="ns_cb,so_the,ten" placeholder="Nhấn (F1)" kt_xoa="K" 
                                                        ToolTip="Mã số cán bộ" kieu_chu="true" Width="155px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_ktkl_kl_P_KTRA('SO_THE')" gchu="gchu" />
                                                </td>
                                                <td><Cthuvien:gchu ID="nsd" runat="server" CssClass="css_gchu2" kt_xoa="X" Font-Bold="true" /></td>
                                            </tr>
                                        </table>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label12" runat="server" Text="Tên" CssClass=" css_gchu_a" Width="90px"></Cthuvien:bbuoc>
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:ma ID="TEN" ten="Tên cán bộ" runat="server" CssClass="css_form" kt_xoa="K" 
                                                        ToolTip="Họ tên cán bộ" kieu_unicode="true" Width="277px" ReadOnly="true" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="phong" ten="Phòng" runat="server" CssClass="css_form" kt_xoa="K" 
                                                        ToolTip="Phòng ban" kieu_unicode="true" Width="155px" ReadOnly="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label2" runat="server" Text="Số quyết định" CssClass="css_gchu_a" ToolTip="Số quyết định"></Cthuvien:bbuoc>
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="SOQD" ten="Số quyết định" runat="server" kt_xoa="X" CssClass="css_form" Width="155px" kieu_chu="true" TaoValid="False" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label7" runat="server" Text=" Ngày quyết định" CssClass="css_gchu_c" Width="110px" ToolTip="Ngày quyết định"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
		                                                <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYQD" ten="Ngày quyết định" runat="server" Width="130px" CssClass="css_form_c" kt_xoa="X" kieu_luu="S" />
                                                        <//div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Cthuvien:bbuoc ID="Label3" runat="server" Text="Hình thức KL" CssClass="css_gchu_a" ToolTip="Hình thức kỷ luật"></Cthuvien:bbuoc>
                                    </td>

                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="HINHTHUC" ten="Hình thức kỷ luật" ToolTip="Hình thức kỷ luật" runat="server" placeholder="Nhấn (F1)"
                                                        CssClass="css_form" BackColor="#f6f7f7" ktra="ns_ma_htkl,ma,ten" kieu_chu="true" Width="155px" kt_xoa="X"
                                                        f_tkhao="~/App_form/ns/ktkl/ma/ns_ma_htkl.aspx" onfocusout="ns_ktkl_kl_P_KTRA('hinhthuc')" gchu="gchu" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label11" runat="server" Text=" Mức phạt" CssClass="css_gchu_c" Width="110px" ToolTip="Mức phạt"></Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:so ID="MUCPHAT" ten="Mức phạt" ToolTip="Mức phạt" runat="server"
                                                        kt_xoa="X" CssClass="css_form" Width="155px" ValueText="0" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 24px">
                                        <Cthuvien:bbuoc ID="Label6" runat="server" Text="Kỷ luật từ ngày" CssClass="css_gchu" ToolTip="Kỷ luật từ ngày"></Cthuvien:bbuoc>
                                    </td>
                                    <td align="left" style="height: 24px">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div class="ip-group date">
		                                                <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYD" ten="Kỷ luật từ ngày" runat="server" Width="130px" CssClass="css_form_c" kt_xoa="X" kieu_luu="I" />
                                                        </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Đến ngày" CssClass="css_gchu_c" Width="110px" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
		                                                <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>

                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" ten="Kỷ luật đến ngày" ToolTip="Kỷ luật đến ngày" runat="server" Width="130px" CssClass="css_form_c" kt_xoa="X" kieu_luu="I" />
                                                        </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label22" runat="server" Text="Lý do KL" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="lydo" ten="Lý do kỷ luật" ToolTip="Lý do kỷ luật" runat="server"
                                            kt_xoa="X" CssClass="css_form" Width="432px" kieu_unicode="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label4" runat="server" Text="Cấp kỷ luật" Width="105px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="cap_ktkl" ten="Cấp kỷ luật" ToolTip="Mã cấp kỷ luật" runat="server" placeholder="Nhấn (F1)"
                                                        CssClass="css_form" BackColor="#f6f7f7" ktra="ns_ma_cap_ktkl,ma,ten" kieu_chu="true" Width="155px" kt_xoa="X"
                                                        f_tkhao="~/App_form/ns/ktkl/ma/ns_ma_cap_ktkl.aspx" onfocusout="ns_ktkl_kl_P_KTRA('CAP_KTKL')" gchu="gchu" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" Text="Nơi kỷ luật" Width="110px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="noi_ktkl" ten="Nơi kỷ luật" ToolTip="Mã nơi kỷ luật" runat="server" placeholder="Nhấn (F1)"
                                                        CssClass="css_form" BackColor="#f6f7f7" ktra="ns_ma_noi_ktkl,ma,ten" kieu_chu="true" Width="155px" kt_xoa="X"
                                                        f_tkhao="~/App_form/ns/ktkl/ma/ns_ma_noi_ktkl.aspx" onfocusout="ns_ktkl_kl_P_KTRA('NOI_KTKL')" gchu="gchu" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label5" runat="server" Text="Người ký" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="nguoiky" ten="Người ký" ToolTip="Người ký quyết định" runat="server"
                                            kt_xoa="X" CssClass="css_form" Width="432px" kieu_unicode="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label9" runat="server" Text="Ghi chú" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="ghichu" ten="Ghi chú" ToolTip="Ghi chú" runat="server"
                                            kt_xoa="X" CssClass="css_form" Width="432px" kieu_unicode="true" TextMode="MultiLine" Height="50px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" class="tableButton">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight">
<%--                                                        <a href="#" onclick="return ns_ktkl_kl_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_ktkl_kl_P_MOI_FULL();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_ktkl_kl_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>--%>
                                                        <a href="#" onclick="return ns_ktkl_kl_P_IN();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">X</span>uất excel</a>      
<%--                                                        <a href="#" onclick="return nhap_file();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">F</span>ile</a>--%>
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
    <Cthuvien:an ID="so_id" runat="server" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="940,600" />
</asp:Content>
