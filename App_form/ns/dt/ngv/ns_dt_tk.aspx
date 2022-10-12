<%@ Page Title="ns_dt_tk" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_tk.aspx.cs" Inherits="f_ns_dt_tk" %>

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
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Triển khai lớp đào tạo" />
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
                            <div style="height:550px; overflow-y:scroll;">
                            <table id="UPa_tt" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center">
                                        <div style="padding-top: 10px; padding-bottom: 10px">
                                            <asp:Label ID="Label4" Text="Thông tin chung" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                            <hr width="100%" />
                                        </div>

                                        <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label19" runat="server" Text="Năm" CssClass="css_gchu" />
                                                </td>
                                                <td>                                                    
                                                    <Cthuvien:ma ID="nam" ten="Năm đào tạo" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label21" runat="server" Text="Tháng" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="thang" ten="Tháng đào tạo" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
                                                </td>   
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" Text="Mã khóa đào tạo" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ma_kdt" ten="Mã khóa đào tạo" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
                                                </td>                                             
                                            </tr>                                            
                                            <tr>
                                                
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label13" runat="server" Text="Tên khóa đào tạo" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ten_kdt" ten="Tên khóa đào tạo" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
                                                </td>                                                    
                                                <td align="left">
                                                    <asp:Label ID="Label22" runat="server" Text="Version" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="vsion" ten="Version" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label11" runat="server" Text="Lĩnh vực cha"  CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ten_lvcha" ten="Lĩnh vực cha" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
                                                </td>    
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" Text="Lĩnh vực con" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ten_lvcon" ten="Lĩnh vực con" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" Text="Phân bổ ngân sách" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="phanbo_ns" ten="Phân bổ ngân sách" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" Text="Lớp" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="lop" ten="Lớp" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
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
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Ngày bắt đầu" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_D" runat="server" Width="132px" CssClass="css_form_c" kt_xoa="X"
                                                            ten="Ngày bắt đầu" onchange="ns_dt_tk_P_KTRA('NGAY_D');" />
                                                    </div>
                                                    
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc4" runat="server" Text="Ngày kết thúc" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_C" runat="server" Width="132px" CssClass="css_form_c" kt_xoa="X"
                                                            ten="Ngày kết thúc" onchange="ns_dt_tk_P_KTRA('NGAY_C');" />
                                                    </div>                                                    
                                                </td>
                                                        
                                            </tr>
                                            <tr>
                                                
                                                <td align="left">
                                                    <asp:Label ID="Bbuoc3" runat="server" Text="Địa điểm đào tạo" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ddiem" ten="Địa điểm đào tạo" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label17" runat="server" Text="Hình thức đào tạo" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="hinhthuc" ten="Hình thức đào tạo" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
                                                </td>

                                                <td align="left">
                                                    <asp:Label ID="Label25" runat="server" Text="Số h.viên t.tế" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                     <Cthuvien:so ID="sl_hvien_tt" ten="Số lượng học viên thực tế" runat="server" CssClass="css_form_c" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
                                                </td> 

                                            </tr>
                                            <tr>
                                               
                                                <td align="left">
                                                    <asp:Label ID="Label26" runat="server" Text="Nội dung đào tạo" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="5">
                                                    <Cthuvien:nd ID="ndung" ten="Đối tượng học viên" runat="server" kt_xoa="X" CssClass="css_form" Height="50px"
                                                        Width="100%" TextMode="MultiLine" disabled/>   
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
                                                    <asp:Label ID="Label12" Text="Chi phí đào tạo" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                                        <hr width="100%" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>   
                                                                                                
                                                    <Cthuvien:GridX ID="GR_cpdt" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="N" cot="ma_cp,ten_cp,dvi,dgia,sluong,tong,thue,tong_hm,cp_tt,ghichu" cotAn="ma_cp" hangKt="5" 
                                                        ctrS="nhap"  hamUp="ns_dt_tk_GR_Update">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />                                                            
                                                            <asp:BoundField DataField="ma_cp" />
                                                            <asp:TemplateField HeaderText="Hạng mục" HeaderStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="ten_cp" ten="Hạng mục chi phí" runat="server" kieu_chu="true" kt_xoa="X" Width="100%" f_tkhao="~/App_form/ns/dt/dm/ns_dt_ma_cp.aspx" ktra="ns_dt_ma_cp,ma,ten" CssClass="css_Gma" ToolTip="Ấn F1 để chọn hạng mục chi phí" BackColor="#f6f7f7">
                                                                        </Cthuvien:ma>
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
                                                            <asp:TemplateField HeaderText="CP thực tế" HeaderStyle-Width="80px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:so ID="cp_tt" runat="server" Width="100%" CssClass="css_Gma_r" kieu_chu="False" kt_xoa="X" co_dau="K" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="ghichu" runat="server" Width="100%" CssClass="css_Gma" kt_xoa="X" MaxLength="250" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                   
                                                </td>
                                            </tr>
                                            <tr>                                           
                                                <td align="center" style="padding-top: 5px;">
                                                    <table id="UPa_nhap_grd_cp" border="0" cellpadding="1" cellspacing="1">
                                                        <tr>
                                                            <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height: 20px;">
                                                                <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_dt_tk_HangLen();" />
                                                            </td>
                                                            <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_dt_tk_HangXuong();" />
                                                            </td>
                                                            <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_dt_tk_CatDong();" />
                                                            </td>
                                                            <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_dt_tk_ChenDong('C');" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table id="UPa_total">
                                                        <tr>
                                                            <td width="130px" align="left">
                                                                <asp:Label ID="Label14" runat="server" Text="Tổng chi phí thực tế" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="tong_cp" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="X" Width="160px" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label15" runat="server" Text="Chi phí 1 học viên thực tế" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="cp_hv" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="X" Width="160px" />
                                                            </td>                                                
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top: 5px;">
                                        
                                    </td>
                                </tr>
                                
                            </table>
                            </div>
                            <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1" style="width: 100%;">
                                <tr>
                                    <td style="padding-top: 20px">
                                        <div class="box3 txCenter" style="width: 100%;">                                            
                                            <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" OnClick="return ns_dt_tk_P_MOI();" />
                                            <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" OnClick="return ns_dt_tk_P_NH();" />
                                            <Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" OnClick="return ns_dt_tk_P_XOA();" />
                                            <Cthuvien:nhap ID="tkb" runat="server" Text="Thời khóa biểu" OnClick="return ns_dt_tk_P_TT('TKB');" />
                                            <Cthuvien:nhap ID="diemdanh" runat="server" Width="80px" Text="Điểm danh" OnClick="return ns_dt_tk_P_TT('DD');" />                                           
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1150,800" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
    </div>
</asp:Content>
