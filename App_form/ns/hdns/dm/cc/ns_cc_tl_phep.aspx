<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_cc_tl_phep.aspx.cs" Inherits="f_ns_cc_tl_phep"
    Title="ns_cc_tl_phep" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="khud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thiết lập thông số phép, bù" />
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
                            <div>
                                <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                    CssClass="table gridX" loai="X" hangKt="10" cotAn="so_id,thnien_tang,so_ph_tang,ng_cat_ph,ng_cat_nghi_bu,cth_tu" hamRow="ns_cc_tl_phep_GR_lke_RowChange()">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />                                                
                                        <asp:BoundField HeaderText="Công ty" DataField="ten_dvi" HeaderStyle-Width="300px">
                                            <ItemStyle CssClass="css_Gnd" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay_hl" HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="css_Gma_c" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="so_id"/>
                                        <asp:BoundField DataField="dvi"/>
                                        <asp:BoundField DataField="thnien_tang"/>
                                        <asp:BoundField DataField="so_ph_tang"/>
                                        <asp:BoundField DataField="ng_cat_ph"/>
                                        <asp:BoundField DataField="ng_cat_nghi_bu"/>
                                        <asp:BoundField DataField="cth_tu"/>
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <div>
                                <khud:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_tl_phep_P_LKE()" />
                            </div>                            
                        </td>
                        <td class="form_right" valign="top">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                   <Cthuvien:bbuoc ID="Label2" runat="server" Text="Công ty" Width="60px" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="DVI" ten="Công ty" runat="server" Width="250px" ktra="NS_CC_TL_PHEP_DVI" onchange="ns_cc_tl_phep_P_KTRA('DVI')" kt_xoa="G" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label4" runat="server" CssClass="css_gchu">Ngày hiệu lực</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <div class="ip-group date">
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_HL" runat="server" kt_xoa="G" ten="Ngày hiệu lực" CssClass="css_form_c" Width="222px" onchange="ns_cc_tl_phep_P_KTRA('NGAY_HL');" />
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label7" runat="server" Text="Thâm niên tăng phép (năm)"></asp:Label>                                                    
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:so runat="server" ID="thnien_tang" ten="Thâm niên tăng phép" co_dau="K" CssClass="css_form_c" Width="250px" kt_xoa="X" MaxLength="2" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label6" runat="server" Text="Số phép tăng"></asp:Label>
                                                </td>
                                                <td align="left">   
                                                    <Cthuvien:so runat="server" ID="so_ph_tang" ten="Số phép tăng" co_dau="K" CssClass="css_form_c" Width="250px" kt_xoa="X" MaxLength="2" />                                                 
                                                </td>
                                            </tr>
                                           <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label5" runat="server" Text="Ngày cắt phép"></asp:Label>                                                    
                                                </td>
                                                <td align="left">
                                                    <div class="ip-group date">
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ng_cat_ph" runat="server" kt_xoa="X" ten="Ngày cắt phép" CssClass="css_form_c" Width="222px" />
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" Text="Ngày cắt nghỉ bù"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <div class="ip-group date">
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ng_cat_nghi_bu" runat="server" kt_xoa="X" ten="Ngày cắt nghỉ bù" CssClass="css_form_c" Width="222px" />
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" Text="Chính thức được sử dụng phép từ"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_list ID="cth_tu" runat="server" Width="250px" lke="Chính thức,Thử việc" tra="CT,TV" ten="Chính thức được sử dụng phép từ"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txCenter">
                                                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" OnClick="return ns_cc_tl_phep_P_MOI();form_P_LOI();" /> 
                                                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" OnClick="return ns_cc_tl_phep_P_NH();form_P_LOI();" />
                                                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" OnClick="return ns_cc_tl_phep_P_XOA();form_P_LOI();" />
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
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="990,510" />
    </div>
</asp:Content>
