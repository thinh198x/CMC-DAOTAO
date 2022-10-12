<%@ Page Title="ns_ctt_dxdt_ql_pd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ctt_dxdt_ql_pd.aspx.cs" Inherits="f_ns_ctt_dxdt_ql_pd" %>
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
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Phê duyệt đề xuất đào tạo của CBQL" />
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
                        <td align="left" valign="top" class="form_left" >
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left" id="Upa_tk" runat="server">
                                        <table cellpadding="1" cellspacing="1" id="UPa_tk" >
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Trạng thái phê duyệt" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_lke ID="DR_trthai_pd" ktra="DT_TRTHAI_PD" runat="server" Width="120px"></Cthuvien:DR_lke>
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="tim" runat="server" Width="80px" Text="Tìm" OnClick="return ns_ctt_dxdt_ql_pd_P_LKE();" />  
                                                </td>
                                            </tr>                                            
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 15px">   
                                                                     
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" hangKt="15" cot="SO_ID,NAM,THANG,DVI,NGUOI_DX,KDT,SL_HVIEN,CP_DK" cotAn="SO_ID" hamRow="ns_ctt_dxdt_ql_pd_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField DataField="SO_ID" />                          
                                                <asp:BoundField HeaderText="Năm" DataField="NAM" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField HeaderText="Tháng" DataField="THANG" HeaderStyle-Width="40px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField HeaderText="Đơn vị" DataField="DVI" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Người đề xuất" DataField="NGUOI_DX" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Khóa ĐT" DataField="KDT" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="SL học viên" DataField="SL_HVIEN" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField HeaderText="Chi phí dự kiến" DataField="CP_DK" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gnd_c" ItemStyle-HorizontalAlign="Center" />                                               
                                            </Columns>
                                        </Cthuvien:GridX>    
                                                                         
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_ctt_dxdt_ql_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top" class="form_right">
                            <div style="height:600px;overflow-y:auto;">
                            <table id="UPa_tt" border="0" cellpadding="1" cellspacing="1" width="100%">
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
                                        <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1" >          
                                            <tr>                                                
                                                <td align="left">
                                                    <asp:Label ID="Label7" runat="server" Text="Đơn vị" CssClass="css_gchu" />
                                                </td>
                                                <td align="left" colspan="3">
                                                    <Cthuvien:ma ID="dvi" ten="Đơn vị" runat="server" CssClass="css_form" BackColor="#f6f7f7" Font-Bold="true" disabled ReadOnly="true" kt_xoa="X" Width="100%" />
                                                </td>                                                        
                                            </tr>                                  
                                            <tr>
                                                <td align="left" width="130px;">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" Text="Năm" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td align="left" >                                                    
                                                    <Cthuvien:ma ID="NAM" ten="Năm" runat="server" CssClass="css_form" kt_xoa="X" Width="80px" BackColor="#f6f7f7" disabled ReadOnly="true"/>
                                                </td>  
                                                <td align="left" width="120px;" >
                                                    <asp:Label ID="Label23" runat="server" Text="Chọn KĐT" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:kieu ID="kdt_ht" runat="server" CssClass="css_ma_c" Width="22px" disabled ReadOnly="true" lke="C,K" Text="C" ToolTip="Khóa đào tạo trong DM: C-Có, K-Không" onchange="ns_ctt_dxdt_ql_P_KDT_HT();"/>
                                                </td>                                                                                             
                                            </tr>                                           
                                            <tr>
                                                 <td align="left">
                                                    <asp:Label ID="Label21" runat="server" Text="Khóa ĐT trong DM" CssClass="css_gchu" />
                                                </td>
                                                <td align="left" colspan="3">
                                                    <Cthuvien:ma ID="ten_kdt" ten="Khóa đào tạo trong danh mục" runat="server" CssClass="css_form" kt_xoa="X" Width="100%" MaxLength="100" BackColor="#f6f7f7" disabled ReadOnly="true"/>
                                                </td>  
                                            </tr>
                                            <tr>                                                
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label13" runat="server" Text="Khóa ĐT ngoài DM" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td colspan="3">
                                                    <Cthuvien:ma ID="kdt" ten="Khóa đào tạo ngoài danh mục" runat="server" CssClass="css_form" kt_xoa="X" Width="100%" MaxLength="100" BackColor="#f6f7f7" disabled ReadOnly="true"/>
                                                </td>     
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Tháng mong muốn" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">                                                    
                                                    <Cthuvien:ma ID="THANG" ten="Tháng mong muốn" runat="server" CssClass="css_form" kt_xoa="X" Width="80px" BackColor="#f6f7f7" disabled ReadOnly="true"/>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label24" runat="server" Text="Thời lượng đào tạo" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td align="left">
                                                     <Cthuvien:so ID="thluong" ten="Thời lượng đào tạo" runat="server" Width="160px" CssClass="css_form_c" kt_xoa="X" co_dau="K" BackColor="#f6f7f7" disabled ReadOnly="true"/>
                                                </td> 
                                            </tr>                                            
                                            <tr>                                               
                                                <td align="left">
                                                    <asp:Label ID="Label20" runat="server" Text="Mục tiêu sau ĐT" CssClass="css_gchu" />
                                                </td>
                                                <td align="left" colspan="3">
                                                    <Cthuvien:nd ID="muctieu" ten="Mục tiêu sau ĐT" runat="server" kt_xoa="X" CssClass="css_form" Height="50px"
                                                        Width="100%" TextMode="MultiLine" MaxLength="200" BackColor="#f6f7f7" disabled ReadOnly="true"/>   
                                                </td>                                                        
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Bbuoc3" runat="server" Text="Địa điểm đào tạo" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td align="left" colspan="3">
                                                    <Cthuvien:ma ID="ddiem" ten="Địa điểm đào tạo" runat="server" CssClass="css_form" Width="100%" kt_xoa="X" MaxLength="200" BackColor="#f6f7f7" disabled ReadOnly="true"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" Text="Số lượng HV" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td align="left">
                                                     <Cthuvien:so ID="sl_hvien" ten="Số lượng học viên" runat="server" Width="160px" CssClass="css_form_c" kt_xoa="X" co_dau="K" BackColor="#f6f7f7" disabled ReadOnly="true"/>
                                                </td>                                             
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" Text="Chi phí dự kiên" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td align="left">
                                                     <Cthuvien:so ID="cp_dk" ten="Chi phí dự kiên" runat="server" Width="160px" CssClass="css_form_c" kt_xoa="X" co_dau="K" BackColor="#f6f7f7" disabled ReadOnly="true"/>
                                                </td> 
                                            </tr>  
                                            <tr>                                                
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc5" runat="server" Text="Trạng thái phê duyệt" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td align="left" colspan="3">
                                                    <Cthuvien:ma ID="tt_pd" ten="Trạng thái phê duyệt" runat="server" CssClass="css_form" BackColor="#f6f7f7" Font-Bold="true" disabled ReadOnly="true" kt_xoa="X" Width="160px" />
                                                </td>                                                        
                                            </tr>
                                           <tr>                                               
                                                <td align="left">
                                                    <asp:Label ID="Label6" runat="server" Text="Mô tả" CssClass="css_gchu" />
                                                </td>
                                                <td  align="left" colspan="3">
                                                    <Cthuvien:nd ID="mota" ten="Mô tả" runat="server" kt_xoa="X" CssClass="css_form" Height="50px"
                                                        Width="100%" TextMode="MultiLine" MaxLength="2000" BackColor="#f6f7f7" disabled ReadOnly="true"/>   
                                                </td>                                                        
                                            </tr>
                                            <tr>                                               
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" Text="Lý do không PD" CssClass="css_gchu" />
                                                </td>
                                                <td align="left" colspan="3">
                                                    <Cthuvien:nd ID="lydo" ten="Lý do không PD" runat="server" kt_xoa="X" CssClass="css_form" Height="50px"
                                                        Width="100%" TextMode="MultiLine" MaxLength="2000" />   
                                                </td>                                                  
                                            </tr>
                                        </table>
                                    </td>                                     
                                </tr>    
                                <tr>
                                    <td>
                                        <div style="padding-top: 10px; padding-bottom: 10px">
                                            <asp:Label ID="Label8" Text="Danh sách đề xuất đào tạo" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                            <hr width="100%" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="center">
                                        <div style="width:400px;height:300px;overflow-y:auto;">
                                            <Cthuvien:GridX ID="GR_dx" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="10" cot="so_the,ten">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />                                                                
                                                    <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />                                                                
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                    </td>
                                </tr>                                 
                            </table>
                            </div>                                                        
                            <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1" style="width: 100%;">
                                <tr>
                                    <td style="padding-top: 20px">
                                        <div class="box3 txCenter" style="width: 100%;">                                                        
                                            <Cthuvien:nhap ID="pheduyet" runat="server" Width="80px" Text="Phê duyệt" OnClick="return ns_ctt_dxdt_ql_pd_P_PD(2);" />
                                            <Cthuvien:nhap ID="tuchoi" runat="server" Width="120px" Text="Không phê duyệt" OnClick="return ns_ctt_dxdt_ql_pd_P_PD(3);" />                                              
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1320,820" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
    </div>
</asp:Content>


