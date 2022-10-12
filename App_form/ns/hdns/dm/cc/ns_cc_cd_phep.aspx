<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_cc_cd_phep.aspx.cs" Inherits="f_ns_cc_cd_phep"
    Title="ns_cc_cd_phep" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="khud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thiết lập phép đặc biệt theo chức danh" />
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
                            </table>
                        </td>
                    </tr>                    
                    <tr>
                        <td class="form_left" valign="top">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <div>                                        
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="12" cot="ma,ngay_hl" hamRow="ns_cc_cd_phep_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gma" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay_hl" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>                                                                                           
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                        <div>
                                            <khud:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_cc_cd_phep_P_LKE()" />
                                        </div>
                                    </td>
                                </tr> 
                            </table>
                        </td>
                        <td class="form_right" valign="top">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">                                            
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label1" runat="server" CssClass="css_gchu" Text="Mã" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="MA" runat="server" CssClass="css_form" kt_xoa="G" ten="Mã" kieu_chu="true"
                                                        Width="317px" MaxLength="30" onchange="ns_cc_cd_phep_P_KTRA('MA');"></Cthuvien:ma>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" Width="120px" CssClass="css_gchu">Ngạch nghề nghiệp</asp:Label>                                                    
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="ma_nnn" ten="Ngạch nghề nghiệp" ktra="NS_CC_CD_PHEP_NNN" runat="server" Width="317px" kt_xoa="X" onchange="ns_cc_cd_phep_P_KTRA('MA_NNN');"></Cthuvien:DR_lke>                                                     
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label4" runat="server" CssClass="css_gchu" Text="Chức danh" />
                                                </td>
                                                <td align="left">
                                                    <div style="height:200px; overflow-y:auto;">
                                                    <Cthuvien:GridX ID="GR_nh" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="N" cot="ma_cd,ten,ma_nnn" cotAn="ma_nnn" hangKt="5">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:TemplateField HeaderText="Mã chức danh" HeaderStyle-Width="80px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="ma_cd" runat="server" ReadOnly="true" Width="80px" CssClass="css_Gma" kt_xoa="X"
                                                                        kieu_chu="True" f_tkhao="~/App_form/ns/hdns/dm/cdanh/ns_hdns_cdanh_tk.aspx" guiId="ma_nnn_day" placeholder="Nhấn (F1)" BackColor="#f6f7f7" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Tên chức danh" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />                                                            
                                                            <asp:BoundField DataField="ma_nnn" />
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td align="right">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_cc_cd_phep_CatDong();" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Số phép đặc biệt" />
                                                </td>
                                                <td align="left">   
                                                    <Cthuvien:so runat="server" ID="PHEP" ten="Số phép đặc biệt" co_dau="K" CssClass="css_form_c" Width="317px" kt_xoa="X" MaxLength="2" />                                                 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu" Text="Ngày hiệu lực" />
                                                </td>
                                                <td align="left">
                                                     <div class="ip-group date">
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_HL" runat="server" kt_xoa="X" ten="Ngày hiệu lực" CssClass="css_form_c" Width="289px" />
                                                         <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center">
                                                    <div class="box3 txCenter">
                                                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" OnClick="return ns_cc_cd_phep_P_MOI();form_P_LOI();" /> 
                                                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" OnClick="return ns_cc_cd_phep_P_NH();form_P_LOI();" />
                                                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" OnClick="return ns_cc_cd_phep_P_XOA();form_P_LOI();" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="860,580" />
        <Cthuvien:an ID="ma_nnn_day" runat="server" />
    </div>
</asp:Content>

