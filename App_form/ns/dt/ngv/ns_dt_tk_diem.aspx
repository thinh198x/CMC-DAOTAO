<%@ Page Title="ns_dt_tk_diem" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_tk_diem.aspx.cs" Inherits="f_ns_dt_tk_diem" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="center">
                            <table cellpadding="1" width="100%" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Kết quả đào tạo" />
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
                            
                            <table id="UPa_tt" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center">
                                        <div style="padding-top: 10px; padding-bottom: 10px; text-align:left">
                                            <asp:Label ID="Label4" Text="Thông tin chung" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                            <hr width="100%" />
                                        </div>
                                        <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Năm" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="DR_nam" ktra="DT_NAM" runat="server" Width="80px" onchange="ns_dt_kh_ct_P_KTRA('DR_nam');"></Cthuvien:DR_lke> 
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label21" runat="server" Text="Tháng" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="DR_thang" ktra="DT_THANG" runat="server" Width="80px" onchange="ns_dt_kh_ct_P_KTRA('DR_thang');"></Cthuvien:DR_lke>                                                    
                                                </td>   
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" Text="Khóa đào tạo" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="DR_kdt" ktra="DT_KDT" runat="server" Width="160px" onchange="ns_dt_kh_ct_P_KTRA('DR_kdt');"></Cthuvien:DR_lke> 
                                                </td>                                             
                                            </tr>                                            
                                            <tr>
                                                
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc4" runat="server" Text="Lớp đào tạo" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="DR_lop" ktra="DT_LOPDT" runat="server" Width="160px" onchange="ns_dt_kh_ct_P_KTRA('DR_lop');"></Cthuvien:DR_lke>                                                     
                                                </td>          
                                                <td align="left">
                                                    <asp:Label ID="Label11" runat="server" Text="Lĩnh vực cha"  CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ten_lvcha" ten="Lĩnh vực cha" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
                                                </td>                                             
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" Text="Lĩnh vực con" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ten_lvcon" ten="Lĩnh vực con" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
                                                </td>
                                                 
                                            </tr>
                                            <tr>                                               
                                                <td align="left">
                                                    <asp:Label ID="Label24" runat="server" Text="Thời lượng đào tạo" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                     <Cthuvien:so ID="thluong" ten="Thời lượng đào tạo" runat="server" CssClass="css_form_c" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
                                                </td> 
                                                 <td align="left">
                                                    <asp:Label ID="Label7" runat="server" Text="Ngày bắt đầu" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_d" ten="Ngày bắt đầu" runat="server" CssClass="css_form_c" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label8" runat="server" Text="Ngày kết thúc" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngay_c" ten="Ngày kết thúc" runat="server" CssClass="css_form_c" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />                                                                                                      
                                                </td>
                                            </tr>                                                                                
                                                                                      
                                        </table>

                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label12" Text="Kết quả học viên" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                                        <hr width="100%" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>   
                                                    <div style="width:1200px; overflow-x:scroll;">
                                                        <Cthuvien:GridX ID="GR_kq" runat="server" AutoGenerateColumns="False" PageSize="1"
                                                            CssClass="table gridX" loai="N" hangKt="12" hamUp="ns_dt_tk_diem_GR_Update">
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
                                                                <asp:BoundField HeaderText="ĐTB" DataField="dtb" HeaderStyle-Width="80px">
                                                                    <ItemStyle CssClass="css_Gma_c" />
                                                                </asp:BoundField>                                            
                                                                <asp:TemplateField HeaderText="Kết quả chung" HeaderStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:DR_list ID="kq" ten="Kết quả chung" runat="server" kt_xoa="X" Width="100%" CssClass="css_drop" 
                                                                            DataTextField="ten" DataValueField="ma">                                                            
                                                                        </Cthuvien:DR_list>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CP hỗ trợ" HeaderStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:so ID="cp_htro" runat="server" Width="100%" CssClass="css_Gma_r" kieu_chu="False" kt_xoa="X" co_dau="K" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </div>  
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="GR_lke_td" runat="server" align="center">
                                                    <khud_slide:khud_slide ID="GR_kq_slide" runat="server" rong="200" loai="X" gridId="GR_kq"
                                                        ham="ns_dt_tk_tkb_P_LKE()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>                            
                            <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1" style="width: 100%;">
                                <tr>
                                    <td style="padding-top: 5px">                                        
                                        <div class="box3 txCenter" >                                            
                                            <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" OnClick="return ns_dt_tk_diem_P_NH();" />
                                            <Cthuvien:nhap ID="fileMau" runat="server" Text="File mẫu" OnServerClick="FileMau_Click" />
                                            <Cthuvien:nhap ID="import" runat="server" Text="Import" OnClick="return ns_dt_tk_diem_P_IMPORT();" />
                                        </div>
                                    </td>                                                
                                </tr>
                                <tr><td><Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" ForeColor="Red" Text="." /></td></tr>
                            </table>
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,780" />
        <Cthuvien:an ID="so_mon_max" runat="server" Value="0" />
         <Cthuvien:an ID="so_mon" runat="server" Value="0" />
         <Cthuvien:an ID="ten_mon" runat="server" Value="" />
    </div>
</asp:Content>

