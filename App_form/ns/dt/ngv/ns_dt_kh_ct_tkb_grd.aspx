<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dt_kh_ct_tkb_grd.aspx.cs" Inherits="f_ns_dt_kh_ct_tkb_grd"
    Title="ns_dt_kh_ct_tkb_grd" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="khud" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="khud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thời khóa biểu kế hoạch đào tạo" />
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
                                        <asp:Label ID="Label12" Text="Lớp: " runat="server" CssClass="css_gchu"></asp:Label>
                                        <Cthuvien:gchu ID="ttin_kdt" runat="server" CssClass="css_gchu2" kt_xoa="G" Font-Bold="true" />
                                    </td>
                                </tr>                                
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="False" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="10" hamRow="ns_dt_kh_ct_tkb_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px">
                                                    <HeaderStyle Width="10px"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Ngày" DataField="ngay" HeaderStyle-Width="200px">
                                                    <ItemStyle CssClass="css_Gma" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Số chủ đề" DataField="so_chude" HeaderStyle-Width="100px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_dt_kh_ct_tkb_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right" valign="top">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Ngày học" />
                                    </td>
                                    <td align="left">    
                                        <div class="ip-group date">
                                            <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>                                                
                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY" runat="server" Width="130px" CssClass="css_form_c" kt_xoa="L"
                                                ten="Ngày đào tạo" onchange="ns_dt_kh_ct_tkb_P_KTRA('NGAY')"/>   
                                        </div>      
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <div class="css_divb" style="margin-right:20px;">
                                            <div class="css_divCn">
                                                <Cthuvien:GridX ID="GR_tkb" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                    CssClass="table gridX" loai="N" cot="ma_cp,ten_cp,dvi,dgia,sluong,tong,thue,tong_hm,ghichu" cotAn="ma_cp" hangKt="5" 
                                                    ctrS="nhap"  hamUp="ns_dt_kh_ct_GR_Update">
                                                    <Columns>
                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />                                                            
                                                        <asp:BoundField DataField="ma_cp" />
                                                        <asp:TemplateField HeaderText="Chủ đề" HeaderStyle-Width="140px">
                                                            <ItemTemplate>
                                                                <Cthuvien:ma ID="CHUDE" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" ten="Chủ đề"
                                                                     Width="270px" MaxLength="50"></Cthuvien:ma>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Đơn vị tính" HeaderStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <Cthuvien:ma ID="dvi" runat="server" CssClass="css_Gma_c" kt_xoa="X" Width="100%" MaxLength="10" />                                                                    
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Đơn giá" HeaderStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="dgia" runat="server" Width="100%" CssClass="css_Gma_r" kt_xoa="X" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Số lượng" HeaderStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="sluong" runat="server" Width="100%" CssClass="css_Gma_r" kt_xoa="X" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="tong"  HeaderText="Tổng" HeaderStyle-Width="100px" ItemStyle-CssClass="css_ma_r"/>
                                                        <asp:TemplateField HeaderText="Thuế" HeaderStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="thue" runat="server" Width="100%" CssClass="css_Gma_r" kieu_chu="False" kt_xoa="X" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="tong_hm"  HeaderText="Tổng hạng mục" HeaderStyle-Width="100px" ItemStyle-CssClass="css_ma_r"/>
                                                        <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:ma ID="ghichu" runat="server" Width="100%" CssClass="css_Gma" kt_xoa="X" MaxLength="250" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </Cthuvien:GridX>    
                                            </div>
                                            <khud:ctr_khud_divC ID="Ctr_khud_divC1" runat="server" gridId="GR_tkb" />
                                        </div>  
                                    </td>
                                </tr>
                            </table>
                            <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1" style="width: 100%;">
                                <tr>
                                    <td align="center">
                                        <div class="box3 txCenter">
                                            <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" OnClick="return ns_dt_kh_ct_tkb_P_MOI();" />   
                                            <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" OnClick="return ns_dt_kh_ct_tkb_P_NH();" />
                                            <Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" OnClick="return ns_dt_kh_ct_tkb_P_XOA();" />                                                                                                     
                                        </div>
                                    </td>                                                
                                </tr>
                            </table>
                            <div id="UPa_gchu" class="css_border" align="left">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" ForeColor="Red" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>   
    <div id="UPa_hi">
         <Cthuvien:an ID="kthuoc" runat="server" Value="1240,540"/>
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
    </div>
</asp:Content>


