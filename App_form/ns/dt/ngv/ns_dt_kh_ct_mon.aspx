<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dt_kh_ct_mon.aspx.cs" Inherits="f_ns_dt_kh_ct_mon"
    Title="ns_dt_kh_ct_mon" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>


<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh sách môn thi" />
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
                        <td>
                            <asp:Label ID="Label12" Text="Lớp: " runat="server" CssClass="css_gchu"></asp:Label>
                            <Cthuvien:gchu ID="ttin_kdt" runat="server" CssClass="css_gchu2" kt_xoa="G" Font-Bold="true" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="center" colspan="2">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div style="height:320px; overflow-y:scroll;">
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="N" cot="ma,ten,tr_so,ngay_thi" hangKt="10" ctrS="nhap" hamUp="ns_dt_kh_ct_mon_GR_Update">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />                                                            
                                                <asp:TemplateField HeaderText="Mã môn" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ma ID="ma" ten="Mã môn" runat="server" kt_xoa="X" Width="100%" f_tkhao="~/App_form/ns/dt/dm/ns_dt_ma_mon.aspx" ktra="NS_DT_MA_MON,ma,ten" CssClass="css_Gma" kieu_chu="true" ToolTip="Ấn F1 để chọn môn" BackColor="#f6f7f7">
                                                        </Cthuvien:ma>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="Tên môn" DataField="ten" HeaderStyle-Width="200px">
                                                    <HeaderStyle Width="200px"></HeaderStyle>
                                                    <ItemStyle CssClass="css_Gma" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="Trọng số" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:so ID="tr_so" runat="server" Width="100%" CssClass="css_Gma_r" kieu_chu="False" kt_xoa="X" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Ngày thi" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_thi" runat="server" Width="100px" CssClass="css_Gma_c" kt_xoa="X"
                                                            ten="Ngày thi" />   
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                        </div>
                                    </td>
                                </tr>
                                <tr>                                           
                                    <td align="center" style="padding-top: 5px;">
                                        <table id="UPa_nhap_grd_cb" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height: 20px;">
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_dt_kh_ct_mon_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_dt_kh_ct_mon_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_dt_kh_ct_mon_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_dt_kh_ct_mon_ChenDong('C');" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                                
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <div>
                                                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" OnClick="return ns_dt_kh_ct_mon_P_MOI();" />
                                                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" OnClick="return ns_dt_kh_ct_mon_P_NH();" />
                                                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" OnClick="return ns_dt_kh_ct_mon_P_XOA();" />                                                        
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="700,540"/>
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="so_id_kh" runat="server" Value="0" />
    </div>
</asp:Content>

