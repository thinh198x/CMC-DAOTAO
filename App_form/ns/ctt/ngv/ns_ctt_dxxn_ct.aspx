<%@ Page Title="ns_ctt_dxxn_ct" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ctt_dxxn_ct.aspx.cs" Inherits="f_ns_ctt_dxxn_ct" %>
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
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Đề xuất xác nhận công tác" />
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
                        <td align="center" valign="top" class="form_left" width="350px">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left" id="Upa_tk" runat="server">
                                        <table cellpadding="1" cellspacing="1" id="UPa_tk" >
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Trạng thái xác nhận" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="trthai_xn" ktra="DT_TRTHAI_XN" runat="server" Width="120px"></Cthuvien:DR_lke>
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="tim" runat="server" Width="80px" Text="Tìm" OnClick="return ns_ctt_dxxn_ct_P_LKE();" />                                                    
                                                </td>
                                            </tr>                                            
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 15px" align="center">                                        
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" hangKt="15" cot="SO_ID,ngaynh,ngaygui_xn,tt_xn" cotAn="SO_ID" hamRow="ns_ctt_dxxn_ct_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField DataField="SO_ID" />                          
                                                <asp:BoundField HeaderText="Ngày nhập" DataField="ngaynh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField HeaderText="Ngày gửi" DataField="ngaygui_xn" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField HeaderText="Trạng thái" DataField="tt_xn" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />                                                                                                  
                                            </Columns>
                                        </Cthuvien:GridX>                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="return ns_ctt_dxxn_ct_P_LKE();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top" class="form_right">
                            
                            <table id="UPa_tt" border="0" cellpadding="1" cellspacing="1">
                                <tr><td>
                                    <div style="padding-top: 10px; padding-bottom: 10px">
                                            <asp:Label ID="Label4" Text="Thông tin xác nhận" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                            <hr width="100%" />
                                        </div>
                                    </td></tr>
                                <tr>
                                    <td align="center">                                        
                                        <div style="height:400px; overflow-y:scroll;">
                                        <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" Text="Số thẻ" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">                                                    
                                                    <Cthuvien:ma ID="so_the" ten="Mã nhân viên" runat="server" CssClass="css_form" kt_xoa="G" Width="160px" MaxLength="100" BackColor="#f6f7f7" Font-Bold="true" disabled ReadOnly="true"/>
                                                </td>    
                                                <td align="left">
                                                   <asp:Label ID="Label2" runat="server" Text="Họ tên" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">                                                    
                                                    <Cthuvien:ma ID="ten" ten="Họ tên nhân viên" runat="server" CssClass="css_form" kt_xoa="G" Width="160px" MaxLength="100" BackColor="#f6f7f7" Font-Bold="true" disabled ReadOnly="true"/>
                                                </td>                                                                                          
                                            </tr>
                                            <tr>                                                
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" Text="Địa chỉ thường trú" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td align="left" colspan="3">
                                                    <Cthuvien:ma ID="HKHAU" ten="Địa chỉ thường trú" runat="server" CssClass="css_form" kt_xoa="X" Width="100%" MaxLength="256"/>
                                                </td>   
                                            </tr>
                                            <tr>
                                                 <td align="left">
                                                    <asp:Label ID="Label21" runat="server" Text="Địa chỉ tạm trú" CssClass="css_gchu" />
                                                </td>
                                                <td align="left" colspan="3">
                                                    <Cthuvien:ma ID="DCHI" ten="Địa chỉ tạm trú" runat="server" CssClass="css_form" kt_xoa="X" Width="100%" MaxLength="256"/>
                                                </td>  
                                            </tr>
                                            <tr>                                                
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label13" runat="server" Text="Số CMND" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="SOCMT" ten="Số CMND" runat="server" CssClass="css_form" kt_xoa="X" Width="160px" MaxLength="50"/>
                                                </td>    
                                            
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Ngày cấp" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">                                                    
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_CMT" runat="server" Width="132px" CssClass="css_form_c" kt_xoa="X" ten="Ngày cấp CMND" />
                                                    </div>
                                                </td>                                                                                             
                                            </tr>                                            
                                            <tr>
                                                <td align="left">
                                                   <Cthuvien:bbuoc ID="Bbuoc4" runat="server" Text="Nơi cấp" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td align="left" colspan="3">
                                                      <Cthuvien:ma ID="NC_CMT" ten="Nơi cấp CMND" runat="server" CssClass="css_form" kt_xoa="X" Width="100%" MaxLength="100"/>
                                                </td> 
                                            </tr>                                            
                                            <tr>                                               
                                                <td align="left">
                                                    <asp:Label ID="Label20" runat="server" Text="Số điện thoại nhà" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="DTNR" ten="Số điện thoại nhà" runat="server" CssClass="css_form" kt_xoa="X" Width="160px" MaxLength="50"/> 
                                                </td>  
                                                <td align="left">
                                                    <asp:Label ID="Bbuoc3" runat="server" Text="Số ĐTDĐ" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="DTDD" ten="Số ĐTDĐ" runat="server" CssClass="css_form" Width="160px" kt_xoa="X" MaxLength="50" />
                                                </td>
                                            </tr>
                                            <tr>                                                
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc5" runat="server" Text="Hiện đang làm việc tại" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td align="left" colspan="3">
                                                    <Cthuvien:ma ID="CQUAN" ten="Hiện đang làm việc tại" runat="server" CssClass="css_form" kt_xoa="X" Width="100%" />
                                                </td>                                                        
                                            </tr>
                                           <tr>                                               
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc6" runat="server" Text="Chức danh/chức vụ" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td  align="left">
                                                    <Cthuvien:ma ID="CDANH" ten="Chức danh/chức vụ" runat="server" CssClass="css_form" kt_xoa="X" Width="160px" />
                                                </td>                              
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc7" runat="server" Text="Ngày vào làm việc" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td  align="left">
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_VAO" runat="server" Width="132px" CssClass="css_form_c" kt_xoa="X" ten="Ngày vào làm việc" />
                                                    </div>
                                                </td>                                                        
                                            </tr>
                                            <tr>                                                
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc8" runat="server" Text="Địa chỉ cơ quan" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td align="left" colspan="3">
                                                    <Cthuvien:ma ID="DCHI_CQ" ten="Địa chỉ cơ quan" runat="server" CssClass="css_form" kt_xoa="X" Width="100%" MaxLength="200" />
                                                </td>                                                        
                                            </tr>
                                            <tr>                                                
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc9" runat="server" Text="Điện thoại liên lạc" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="DTCQ" ten="Điện thoại liên lạc" runat="server" CssClass="css_form" kt_xoa="X" Width="160px" MaxLength="20" />
                                                </td>      
                                                <td></td><td></td>                                                  
                                            </tr>
                                            <tr>
                                               
                                                <td align="left">
                                                     <Cthuvien:bbuoc ID="Bbuoc10" runat="server" Text="Mục đích xác nhận" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td colspan="3">
                                                    <Cthuvien:nd ID="LYDO_XN" ten="Lý do xác nhận công tác" runat="server" kt_xoa="X" CssClass="css_form" Height="50px"
                                                        Width="100%" TextMode="MultiLine" MaxLength="200" />   
                                                </td>
                                                        
                                            </tr>
                                        </table>
                                        <table id="UPa_ph" border="0" cellpadding="1" cellspacing="1" style="display:none;">
                                            <tr>
                                                <td colspan="4">
                                                    <div style="padding-top: 10px; padding-bottom: 10px">
                                                        <asp:Label ID="Label3" Text="Thông tin phản hồi" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                                        <hr width="100%" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" width="130px">
                                                    <asp:Label ID="Label6" runat="server" Text="Trạng thái xác nhận" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">                                                    
                                                    <Cthuvien:ma ID="tt_xn" ten="Trạng thái xác nhận" runat="server" CssClass="css_form" kt_xoa="G" Width="160px" MaxLength="100" BackColor="#f6f7f7" Font-Bold="true" disabled ReadOnly="true"/>
                                                </td>    
                                                <td align="left" width="110px">
                                                    <asp:Label ID="Label7" runat="server" Text="Ngày trả kết quả" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">  
                                                     <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ma ID="NGAY_TRA_KQ" ten="Ngày trả kết quả" runat="server" CssClass="css_form_c" kt_xoa="G" Width="130px" MaxLength="100" BackColor="#f6f7f7" Font-Bold="true" disabled ReadOnly="true"/>
                                                    </div>
                                                </td>                                                                                          
                                            </tr>
                                            <tr>                                               
                                                <td>
                                                     <asp:Label ID="Label8" runat="server" Text="Lý do" CssClass="css_gchu" />
                                                </td>
                                                <td colspan="3">
                                                    <Cthuvien:nd ID="LYDO_TUCHOI" ten="Lý do từ chối" runat="server" kt_xoa="X" CssClass="css_form" Height="50px"
                                                        Width="100%" TextMode="MultiLine" MaxLength="200" BackColor="#f6f7f7" disabled ReadOnly="true"/>   
                                                </td>
                                                        
                                            </tr>
                                        </table>
                                        </div>
                                    </td>
                                </tr>                                
                               
                                <tr>
                                    <td>
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1" style="width: 100%;">
                                            <tr>
                                                <td style="padding-top: 20px">
                                                    <div class="box3 txCenter" style="width: 100%;">
                                                        <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" OnClick="return ns_ctt_dxxn_ct_P_MOI();" /> 
                                                        <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" OnClick="return ns_ctt_dxxn_ct_P_NH();" />
                                                        <Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" OnClick="return ns_ctt_dxxn_ct_P_XOA();" />
                                                        <Cthuvien:nhap ID="guixn" runat="server" Width="100px" Text="Gửi xác nhận" OnClick="return ns_ctt_dxxn_ct_P_PD();" />                                             
                                                    </div>
                                                </td>
                                                
                                            </tr>
                                        </table>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1080,700" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
    </div>
</asp:Content>

