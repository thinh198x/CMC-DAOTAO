﻿<%@ Page Title="ns_dt_kh_ct_tk" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_kh_ct_tk.aspx.cs" Inherits="f_ns_dt_kh_ct_tk" %>


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
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Kế hoạch đào tạo chi tiết" />
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
                        <td align="left" valign="top" class="form_left" width="500px">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="center" id="Upa_tk" runat="server">
                                        <table cellpadding="1" cellspacing="1" id="UPa_tk" width="50%">

                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label16" runat="server" Text="Năm" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="nam_lst" ktra="DT_NAM" runat="server" Width="80px"></Cthuvien:DR_lke> 
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label18" runat="server" Text="Tháng" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="thang_lst" ktra="DT_THANG" runat="server" Width="80px"></Cthuvien:DR_lke>
                                                </td>                                                
                                            </tr>                                            
                                            <tr>
                                                <td align="center" colspan="4">
                                                    <Cthuvien:nhap ID="tim" runat="server" Width="80px" Text="Tìm" OnClick="return ns_dt_kh_ct_tk_P_LKE();" />  
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 15px">                                        
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" hangKt="10" cot="SO_ID,MA_KDT,NAM,THANG,TEN,LOP,NGAY_D,NGAY_C,THLUONG,SL_HVIEN,cphi_dk" 
                                                    cotAn="SO_ID,MA_KDT">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField DataField="SO_ID" />
                                                    <asp:BoundField DataField="MA_KDT" />
                                                    <asp:BoundField HeaderText="Năm" DataField="NAM" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Tháng" DataField="THANG" HeaderStyle-Width="40px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Khóa ĐT" DataField="TEN" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:BoundField HeaderText="Lớp" DataField="LOP" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                                    <asp:BoundField HeaderText="Ngày BĐ" DataField="NGAY_D" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Ngày KT" DataField="NGAY_C" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Th.lượng" DataField="THLUONG" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Số h.viên" DataField="SL_HVIEN" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="C.phí dự kiến" DataField="cphi_dk" HeaderStyle-Width="120px"  ItemStyle-CssClass="css_Gnd_r" ItemStyle-HorizontalAlign="Center" />                                                    
                                                </Columns>
                                            </Cthuvien:GridX>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" 
                                            ham="ns_dt_kh_ct_tk_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                       
                    </tr>
                    <tr>
                        <td style="padding-top: 20px">
                            <div class="box3 txCenter" style="width: 100%;">
                                <Cthuvien:nhap ID="trienkhai" runat="server" Width="80px" Text="Triển khai" OnClick="return ns_dt_kh_ct_tk_P_TK();" /> 
                                <Cthuvien:nhap ID="excel" runat="server" Width="80px" Text="Xuất excel" OnClick="return ns_dt_kh_ct_tk_P_EXCEL();" /> 
                            </div>
                        </td>
                                                
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1050,600" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
    </div>
</asp:Content>
