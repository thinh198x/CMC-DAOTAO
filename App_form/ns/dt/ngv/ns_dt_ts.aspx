<%@ Page Title="ns_dt_ts" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_ts.aspx.cs" Inherits="f_ns_dt_ts" %>

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
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Tuyển sinh học viên" />
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
                            
                            <table id="UPa_tk" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center">
                                        <div style="padding-top: 10px; padding-bottom: 10px; text-align:left;">
                                            <asp:Label ID="Label4" Text="Thông tin chung" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                            <hr width="100%" />
                                        </div>

                                        <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label19" runat="server" Text="Năm" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">                                                    
                                                    <Cthuvien:DR_lke ID="nam_lst" ktra="DT_NAM" runat="server" Width="80px" onchange="P_cho('nam');"></Cthuvien:DR_lke> 
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label21" runat="server" Text="Tháng" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="thang_lst" ktra="DT_THANG" runat="server" Width="80px" onchange="P_cho('thang');"></Cthuvien:DR_lke>
                                                </td>   
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" Text="Khóa đào tạo" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="kdt_lst" ktra="DT_KDT" runat="server" Width="160px" onchange="P_cho('kdt');"></Cthuvien:DR_lke>
                                                </td>                                             
                                            </tr>    
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label13" runat="server" Text="Lớp đào tạo" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="lop_lst" ktra="DT_KDT_LOP" runat="server" Width="160px" onchange="P_cho('lop');"></Cthuvien:DR_lke>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label22" runat="server" Text="Version" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="vsion" ten="Version" runat="server" CssClass="css_form" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label24" runat="server" Text="Thời lượng" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td align="left">
                                                     <Cthuvien:so ID="thluong" ten="Thời lượng đào tạo" runat="server" CssClass="css_form_c" BackColor="#f6f7f7" disabled ReadOnly="true" kt_xoa="G" Width="160px" />
                                                </td> 
                                            </tr>                                       
                                                                                       
                                            <tr>
                                                
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" Text="Ngày bắt đầu" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_D" runat="server" Width="132px" CssClass="css_form_c" kt_xoa="X"
                                                            ten="Ngày bắt đầu" BackColor="#f6f7f7" disabled ReadOnly="true" />
                                                    </div>
                                                    
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" Text="Ngày kết thúc" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_C" runat="server" Width="132px" CssClass="css_form_c" kt_xoa="X"
                                                            ten="Ngày kết thúc" BackColor="#f6f7f7" disabled ReadOnly="true" />
                                                    </div>                                                    
                                                </td>    
                                                <td align="center" colspan="2">
                                                    <Cthuvien:nhap ID="tonghop" runat="server" Width="80px" Text="Tổng hợp" OnClick="return ns_dt_ts_P_TONGHOP();" />
                                                    <Cthuvien:nhap ID="hocvien" runat="server" Width="80px" Text="DS học viên" OnClick="return ns_dt_ts_P_LKE_HOCVIEN();" />
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
                                                    <asp:Label ID="Label12" Text="Danh sách học viên" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                                        <hr width="100%" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>   
                                                   <div style="width:1350px; height:450px; overflow:scroll;">                                          
                                                    <Cthuvien:GridX ID="GR_hv" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX" loai="N" hangKt="12" ctrS="nhap"
                                                        cot="chon,so_the,ten,phong,cdanh,dtdd,email,email_ql,ngaydk,ten_loai_ts,tchi1,tchi2,tchi3,kluan,ghichu,so_id_dx,loai_ts" cotAn="so_id_dx,loai_ts" >
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" /> 
                                                            <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn thêm" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>                                                           
                                                            <asp:BoundField DataField="so_the" HeaderText="Mã nhân viên" HeaderStyle-Width="70px"  />
                                                            <asp:BoundField DataField="ten" HeaderText="Họ và tên" HeaderStyle-Width="120px"  />
                                                            <asp:BoundField DataField="phong"  HeaderText="Đơn vị" HeaderStyle-Width="80px" />
                                                            <asp:BoundField DataField="cdanh"  HeaderText="Chức vụ" HeaderStyle-Width="80px" />
                                                            <asp:BoundField DataField="dtdd"  HeaderText="Số đt" HeaderStyle-Width="80px" />
                                                            <asp:BoundField DataField="email" HeaderText="Email"  HeaderStyle-Width="80px" />
                                                            <asp:BoundField DataField="email_ql"  HeaderText="Email QL" HeaderStyle-Width="80px" />
                                                            <asp:BoundField DataField="ngaydk"  HeaderText="Ngày ĐK" HeaderStyle-Width="80px" />          
                                                            <asp:BoundField DataField="ten_loai_ts"  HeaderText="Loại" HeaderStyle-Width="80px" />                                                             
                                                            <asp:TemplateField HeaderText="Tiêu chí 1" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="tchi1" runat="server" CssClass="css_Gma" kt_xoa="X" Width="100%" MaxLength="100" />                                                                    
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Tiêu chí 2" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="tchi2" runat="server" CssClass="css_Gma" kt_xoa="X" Width="100%" MaxLength="100" />                                                                    
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Tiêu chí 3" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="tchi3" runat="server" CssClass="css_Gma" kt_xoa="X" Width="100%" MaxLength="100" />                                                                    
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Kết luận" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:DR_list ID="kluan" ten="Kết luận tuyển sinh" runat="server" kt_xoa="X" Width="100%" CssClass="css_drop" 
                                                                        DataTextField="ten" DataValueField="ma">                                                            
                                                                    </Cthuvien:DR_list>                                                                    
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="ghichu" runat="server" Width="100%" CssClass="css_Gma" kt_xoa="X" MaxLength="100" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:BoundField DataField="so_id_dx" />
                                                             <asp:BoundField DataField="loai_ts" />
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                   </div>  
                                                </td>
                                            </tr>   
                                            <tr>
                                                <td id="GR_lke_td" runat="server" align="center">                                                    
                                                    <khud_slide:khud_slide ID="GR_hv_slide" runat="server" rong="100" loai="X" gridId="GR_hv" ham="P_cho('slide')" />
                                                </td>
                                            </tr>                                        
                                        </table>
                                    </td>
                                </tr>
                                
                            </table>
                           
                            <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1" style="width: 100%;">
                                <tr>
                                    <td style="padding-top: 10px">
                                        <div class="box3 txCenter" style="width: 100%;">                                            
                                            <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" OnClick="return ns_dt_ts_P_NH();" />
                                            <Cthuvien:nhap ID="them" runat="server" Width="80px" Text="Thêm" OnClick="return ns_dt_ts_P_THEM();" />
                                            <Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" OnClick="return ns_dt_ts_P_XOA();" />
                                            <Cthuvien:nhap ID="fileMau" runat="server" Text="File mẫu"  OnServerClick="FileMau_Click" />
                                            <Cthuvien:nhap ID="import" runat="server" Text="Import" OnClick="return ns_dt_ts_P_IMPORT();" />
                                            <Cthuvien:nhap ID="email" runat="server" Width="80px" Text="Gửi email" OnClick="return ns_dt_ts_P_EMAIL();" />
                                            <Cthuvien:nhap ID="excel" runat="server" Width="80px" Text="Xuất excel" OnClick="return ns_dt_ts_P_EXCEL();" />                                          
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1400,800" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
    </div>
</asp:Content>

