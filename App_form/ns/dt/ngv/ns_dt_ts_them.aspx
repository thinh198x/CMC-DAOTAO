<%@ Page Title="ns_dt_ts_them" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_ts_them.aspx.cs" Inherits="f_ns_dt_ts_them" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>

                        <td align="center" colspan="2">
                            <table cellpadding="1" width="100%" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Thêm học viên ngoài đề xuất" />
                                    </td>
                                    <td align="right">
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
                                    <td align="left" id="Upa_tk" runat="server">
                                        <table cellpadding="1" cellspacing="1" id="UPa_tk" >
                                            <tr>
                                                <td style="height:25px;"><asp:Label ID="Label1" runat="server" Text="Lớp" CssClass="css_gchu" /></td>
                                                <td><Cthuvien:gchu ID="ttin_lop" runat="server" CssClass="css_gchu2" kt_xoa="G" Font-Bold="true" /></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Đơn vị" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="dvi_lke" ktra="DT_PHONG" runat="server" Width="200px" onchange="return ns_dt_ts_them_P_DR_CHANGE();"></Cthuvien:DR_lke>
                                                </td>                                                
                                            </tr>                                            
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 15px">                                        
                                        <table id="UPa_taat" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center"><b>Danh sách cán bộ nhân viên</b></td>
                                                <td align="center"></td>
                                                <td align="center"><b>Danh sách thêm đào tạo</b></td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <div style="width:380px;height:330px;overflow-y:auto;">
                                                        <Cthuvien:GridX ID="GR_nv" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" hangKt="10" cot="chon,so_the,ten">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn thêm" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="190px" ItemStyle-CssClass="css_Gma" />
                                                           </Columns>
                                                        </Cthuvien:GridX>
                                                    </div>
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="ts" runat="server" Width="40px" Text=">>" OnClick="return ns_dt_ts_them_P_THEMTS();return false;" />
                                                    <br /><br />
                                                    <Cthuvien:nhap ID="bo" runat="server" Width="40px" Text="<<" OnClick="return ns_dt_ts_them_P_XOATS();return false;" />
                                                </td>
                                                <td align="center">
                                                    <div style="width:380px;height:330px;overflow-y:auto;">
                                                        <Cthuvien:GridX ID="GR_dx" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" hangKt="10" cot="chon,so_the,ten">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn xóa" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="190px" ItemStyle-CssClass="css_Gma" />
                                                           </Columns>
                                                        </Cthuvien:GridX>
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
                <div id="UPa_gchu" class="css_border" align="left">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" ForeColor="Red" />
                </div>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1000,600" />
        <Cthuvien:an ID="so_id_kh" runat="server" Value="0" />
        <Cthuvien:an ID="ngay_ht" runat="server" Value="0" />
    </div>
</asp:Content>


