<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dt_tk_dd.aspx.cs" Inherits="f_ns_dt_tk_dd"
    Title="ns_dt_tk_dd" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh sách điểm danh học viên" />
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
                        <td class="form_left" valign="top" colspan="2">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height:30px;">                                        
                                        <asp:Label ID="Label12" Text="Lớp: " runat="server" CssClass="css_gchu"></asp:Label>
                                        <Cthuvien:gchu ID="ttin_kdt" runat="server" CssClass="css_gchu2" kt_xoa="G" Font-Bold="true" />
                                    </td>
                                </tr>                                
                                <tr>
                                    <td>
                                        <div style="width:1250px; overflow-x:scroll;">
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="False" PageSize="1"
                                            CssClass="table gridX" loai="N" hangKt="15" hamUp="ns_dt_tk_dd_GR_Update">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px">
                                                    <HeaderStyle Width="10px"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="80px">
                                                    <ItemStyle CssClass="css_Gma" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="130px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>      
                                                 <asp:BoundField HeaderText="Đơn vị" DataField="phong" HeaderStyle-Width="80px">
                                                    <ItemStyle CssClass="css_Gma_c" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tel" DataField="dtdd" HeaderStyle-Width="80px">
                                                    <ItemStyle CssClass="css_Gma_c" />
                                                </asp:BoundField> 
                                                <asp:BoundField HeaderText="Email" DataField="email" HeaderStyle-Width="100px">
                                                    <ItemStyle CssClass="css_Gma_c" />
                                                </asp:BoundField> 
                                                <asp:BoundField HeaderText="Tỷ lệ t.gia" DataField="tl" HeaderStyle-Width="80px">
                                                    <ItemStyle CssClass="css_Gma_c" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Kết quả" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:DR_list ID="kq" ten="Kết quả điểm danh" runat="server" kt_xoa="X" Width="100%" CssClass="css_drop" 
                                                            DataTextField="ten" DataValueField="ma">                                                            
                                                        </Cthuvien:DR_list>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="ghichu" runat="server" Width="100%" CssClass="css_Gma" kt_xoa="X" MaxLength="100" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" rong="200" loai="X" gridId="GR_lke"
                                            ham="ns_dt_tk_tkb_P_LKE()" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="center" id="UPa_nhap" style="padding-top: 20px">
                                        <div class="box3 txCenter">
                                            <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" ForeColor="Red" />
                                            <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" OnClick="return ns_dt_tk_dd_P_MOI();return false;" /> 
                                            <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" OnClick="return ns_dt_tk_dd_P_NH();return false;" />
                                            <Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" OnClick="return ns_dt_tk_dd_P_XOA();return false;" />                                                                                           
                                        </div>
                                    </td>                                                
                                </tr>
                                <tr>
                                    <td>
                                        <div id="UPa_gchu" class="css_border" align="left">
                                            <Cthuvien:gchu ID="gchu1" runat="server" CssClass="css_gchu" kt_xoa="K" ForeColor="Red" Text="." />
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
    <div id="UPa_hi">
         <Cthuvien:an ID="kthuoc" runat="server" Value="1300,750"/>
    </div>
</asp:Content>


