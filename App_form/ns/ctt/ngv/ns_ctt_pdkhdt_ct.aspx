<%@ Page Title="ns_ctt_pdkhdt_ct" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ctt_pdkhdt_ct.aspx.cs" Inherits="f_ns_ctt_pdkhdt_ct" %>

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
                        <td align="left" valign="top" class="form_left">
                            <div style="height:600px; overflow-y:scroll;">
                            <table id="UPa_tt" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <div style="padding-top: 10px; padding-bottom: 10px">
                                            <asp:Label ID="Label4" Text="Thông tin chung" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                            <hr width="100%" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label19" runat="server" Text="Năm" CssClass="css_gchu" />
                                                </td>
                                                <td>                   
                                                    <Cthuvien:ma ID="nam" ten="Năm đào tạo" runat="server" CssClass="css_form" disabled ReadOnly="true" kt_xoa="X" Width="80px" />                                 
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label21" runat="server" Text="Tháng" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="thang" ten="Tháng đào tạo" runat="server" CssClass="css_form" disabled ReadOnly="true" kt_xoa="X" Width="80px" />   
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                
                                                <td align="left">
                                                    <asp:Label ID="Label23" runat="server" Text="Theo kế hoạch" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:kieu ID="kh_nam" runat="server" CssClass="css_ma_c" Width="22px" lke="C,K" Text="C" ToolTip="Theo kế hoạch năm: C-Có, K-Không" disabled ReadOnly="true" />
                                                    
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label5" runat="server" Text="Mã khóa đào tạo" CssClass="css_gchu" />
                                                    
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="MA_KDT" ten="Mã khóa đào tạo" runat="server" CssClass="css_form" kieu_chu="true" Width="160px" disabled ReadOnly="true"  />
                                                </td>
                                                        
                                            </tr>
                                            <tr>
                                                
                                                <td align="left">
                                                    <asp:Label ID="Label9" runat="server" Text="Tên khóa đào tạo" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ten_kdt" ten="Tên khóa đào tạo" runat="server" CssClass="css_form" disabled ReadOnly="true" kt_xoa="X" Width="160px" />
                                                </td>                                                    
                                                <td align="left">
                                                    <asp:Label ID="Label22" runat="server" Text="Version" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="vsion" ten="Version" runat="server" CssClass="css_form" disabled ReadOnly="true" kt_xoa="X" Width="160px" />
                                                </td>
                                                        
                                            </tr>
                                            <tr>
                                                
                                                <td align="left">
                                                    <asp:Label ID="Label11" runat="server" Text="Lĩnh vực cha"  CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ten_lvcha" ten="Lĩnh vực cha" runat="server" CssClass="css_form" disabled ReadOnly="true" kt_xoa="X" Width="160px" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" Text="Lĩnh vực con" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ten_lvcon" ten="Lĩnh vực con" runat="server" CssClass="css_form" disabled ReadOnly="true" kt_xoa="X" Width="160px" />
                                                </td>
                                                        
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" Text="Phân bổ ngân sách" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="phanbo_ns" ten="Phân bổ ngân sách" runat="server" CssClass="css_form" disabled ReadOnly="true" kt_xoa="X" Width="160px" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" Text="Lớp" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="lop" ten="Lớp" runat="server" CssClass="css_form" disabled ReadOnly="true" kt_xoa="X" Width="160px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                
                                                <td align="left">
                                                    <asp:Label ID="Label13" runat="server" Text="Ngày bắt đầu" CssClass="css_gchu" />                                                    
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_D" runat="server" Width="132px" CssClass="css_form_c" kt_xoa="X"
                                                            ten="Ngày bắt đầu"  disabled ReadOnly="true" />
                                                    </div>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label14" runat="server" Text="Ngày kết thúc" CssClass="css_gchu" />                                                    
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_C" runat="server" Width="132px" CssClass="css_form_c" kt_xoa="X"
                                                            ten="Ngày kết thúc"  disabled ReadOnly="true" />
                                                    </div>                                                    
                                                </td>
                                                        
                                            </tr>
                                            <tr>
                                                
                                                <td align="left">
                                                    <asp:Label ID="Bbuoc3" runat="server" Text="Địa điểm đào tạo" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ddiem" ten="Địa điểm đào tạo" runat="server" CssClass="css_form" Width="160px" kt_xoa="X" MaxLength="200"  disabled ReadOnly="true" />
                                                </td>

                                                <td align="left">
                                                    <asp:Label ID="Label24" runat="server" Text="Thời lượng đào tạo" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                     <Cthuvien:so ID="thluong" ten="Thời lượng đào tạo" runat="server" Width="160px" CssClass="css_form_c" kt_xoa="X" co_dau="K" disabled ReadOnly="true" />
                                                </td> 

                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label17" runat="server" Text="Hình thức đào tạo" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                     <Cthuvien:ma ID="hinhthuc" ten="Hình thức đào tạo" runat="server" CssClass="css_form" Width="160px" kt_xoa="X" MaxLength="200"  disabled ReadOnly="true" />                                                   
                                                </td>

                                                <td align="left">
                                                    <asp:Label ID="Label25" runat="server" Text="Số h.viên d.kiến" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                     <Cthuvien:so ID="sl_hvien" ten="Số lượng học viên dự kiến" runat="server" Width="160px" CssClass="css_form_c" kt_xoa="X"  disabled ReadOnly="true"/>
                                                </td> 

                                            </tr>
                                            <tr>
                                               
                                                <td align="left">
                                                    <asp:Label ID="Label20" runat="server" Text="Đối tượng học viên" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="3">
                                                    <Cthuvien:ma ID="dtg_hv" ten="Đối tượng học viên" runat="server" CssClass="css_form" Width="160px" kt_xoa="X" MaxLength="200" disabled ReadOnly="true" />
                                                   
                                                </td>
                                                        
                                            </tr>
                                            <tr>
                                               
                                                <td align="left">
                                                    <asp:Label ID="Label26" runat="server" Text="Nội dung đào tạo" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="3">
                                                    <Cthuvien:nd ID="ndung" ten="Đối tượng học viên" runat="server" kt_xoa="X" CssClass="css_form" Height="50px"
                                                        Width="99%" TextMode="MultiLine" MaxLength="2000"  disabled ReadOnly="true"/>   
                                                </td>
                                                        
                                            </tr>
                                            <tr>
                                                
                                                <td align="left">
                                                    <asp:Label ID="Label15" runat="server" Text="Trạng thái phê duyệt" CssClass="css_gchu" />        
                                                    
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="tt_pd" ten="Trạng thái phê duyệt" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="X" Width="160px" />
                                                </td>
                                                <td  align="left">
                                                    <asp:Label ID="Label10" runat="server" Text="Trạng thái lớp học" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="ten_tt_lop" ten="Trạng thái lớp học" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="X" Width="156px" />
                                                </td>
                                                        
                                            </tr>
                                           <tr>
                                               
                                                <td align="left">
                                                    <asp:Label ID="Label6" runat="server" Text="Ghi chú" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="3">
                                                    <Cthuvien:nd ID="ghichu" ten="Ghi chú" runat="server" kt_xoa="X" CssClass="css_form" Height="50px"
                                                        Width="99%" TextMode="MultiLine" MaxLength="2000" disabled ReadOnly="true"/>   
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
                                                    <div style="padding-top: 10px; padding-bottom: 10px">
                                                        <asp:Label ID="Label12" Text="Chi phí đào tạo" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                                        <hr width="100%" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">   
                                                                                                
                                                    <Cthuvien:GridX ID="GR_cpdt" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="X" hangKt="10" >
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />                                                            
                                                            
                                                            <asp:BoundField HeaderText="Hạng mục" DataField="ten_cp" HeaderStyle-Width="130px">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Đơn vị tính" DataField="dvi" HeaderStyle-Width="80px">
                                                                <ItemStyle CssClass="css_Gnd_c" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Đơn giá" DataField="dgia" HeaderStyle-Width="80px">
                                                                <ItemStyle CssClass="css_Gnd_r" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Số lượng" DataField="sluong" HeaderStyle-Width="80px">
                                                                <ItemStyle CssClass="css_Gnd_r" />
                                                            </asp:BoundField>      
                                                            <asp:BoundField HeaderText="Tổng" DataField="tong" HeaderStyle-Width="100px">
                                                                <ItemStyle CssClass="css_Gnd_r" />
                                                            </asp:BoundField>
                                                             <asp:BoundField HeaderText="Thuế (%)" DataField="thue" HeaderStyle-Width="80px">
                                                                <ItemStyle CssClass="css_Gnd_r" />
                                                            </asp:BoundField> 
                                                            <asp:BoundField HeaderText="Tổng hạng mục" DataField="tong_hm" HeaderStyle-Width="100px">
                                                                <ItemStyle CssClass="css_Gnd_r" />
                                                            </asp:BoundField>                                                             
                                                            <asp:BoundField HeaderText="Ghi chú" DataField="ghichu" HeaderStyle-Width="80px">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>                                                             
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                   
                                                </td>
                                            </tr>
                                            
                                            
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="left" valign="top">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td height="30px">
                                                    <div style="padding-top: 10px; padding-bottom: 10px">
                                                        <asp:Label ID="Label7" Text="Thời khóa biểu" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                                        <hr width="100%" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>                                                                                                   
                                                    <Cthuvien:GridX ID="GR_tkb" runat="server" AutoGenerateColumns="False" PageSize="1"
                                                        CssClass="table gridX" loai="X" hangKt="10">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px">
                                                                <HeaderStyle Width="10px"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Ngày" DataField="ngay" HeaderStyle-Width="100px">
                                                                <ItemStyle CssClass="css_Gnd_c" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Giờ" DataField="gio" HeaderStyle-Width="100px">
                                                                <ItemStyle CssClass="css_Gnd_c" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Chủ đề" DataField="chude" HeaderStyle-Width="200px">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Th. luong" DataField="thluong" HeaderStyle-Width="100px">
                                                                <ItemStyle CssClass="css_Gnd_c" />
                                                            </asp:BoundField>      
                                                            <asp:BoundField HeaderText="Giảng viên" DataField="gvien" HeaderStyle-Width="80px">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>
                                                             <asp:BoundField HeaderText="Loại hình g.dạy" DataField="ma_lhgd" HeaderStyle-Width="80px">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField> 
                                                            <asp:BoundField HeaderText="Địa điểm" DataField="ddiem" HeaderStyle-Width="80px">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </Cthuvien:GridX>                                                   
                                                </td>
                                            </tr>
                                            
                                            
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="center" valign="top">
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td height="30px">
                                                    <div style="padding-top: 10px; padding-bottom: 10px">
                                                        <asp:Label ID="Label8" Text="Môn thi" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                                        <hr width="100%" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">                                                                                                   
                                                    <Cthuvien:GridX ID="GR_mon" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="X" hangKt="10">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" /> 
                                                            
                                                            <asp:BoundField HeaderText="Mã môn" DataField="ma" HeaderStyle-Width="100px">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Tên môn" DataField="ten" HeaderStyle-Width="200px">
                                                                <ItemStyle CssClass="css_Gnd" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Trọng số" DataField="tr_so" HeaderStyle-Width="100px">
                                                                <ItemStyle CssClass="css_Gnd_c" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Ngày thi" DataField="ngay_thi" HeaderStyle-Width="100px">
                                                                <ItemStyle CssClass="css_Gnd_c" />
                                                            </asp:BoundField>                                       
                                                            
                                                        </Columns>
                                                    </Cthuvien:GridX>                                                  
                                                </td>
                                            </tr>
                                            
                                            
                                        </table>
                                    </td>
                                </tr>                                
                            </table>
                            </div>
                            <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1" style="width: 100%;">
                                <tr>
                                    <td style="padding-top: 20px">
                                        <div class="box3 txCenter" style="width: 100%;">
                                            <Cthuvien:nhap ID="nhap1" runat="server" Text="Phê duyệt" OnClick="return ns_ctt_pdkhdt_ct_P_NH(2)();" />
                                            <Cthuvien:nhap ID="nhap2" runat="server" Text="Không phê duyệt" OnClick="return ns_ctt_pdkhdt_ct_P_NH(3)();" />
                                            <Cthuvien:nhap ID="nhap3" runat="server" Text="Mở chờ phê duyệt" OnClick="return ns_ctt_pdkhdt_ct_P_NH(0)();" />                                      
                                        </div>
                                    </td>                                                
                                </tr>
                            </table>
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" ForeColor="Red" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1000,800" />
    </div>
</asp:Content>
