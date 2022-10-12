<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dt_tk_tkb.aspx.cs" Inherits="f_ns_dt_tk_tkb"
    Title="ns_dt_tk_tkb" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thời khóa biểu lớp đào tạo thực tế" />
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
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label16" runat="server" Text="Ngày" CssClass="css_gchu" style="float:left;" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="dr_ngay" ten="Ngày đào tạo" runat="server" kt_xoa="G" Width="175px" CssClass="css_form"
                                                        DataTextField="ngay" DataValueField="ngay" onchange="ns_dt_tk_tkb_P_DR_CHANGE()" style="float:left;">
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                                <td align="left"><asp:Label ID="Label9" runat="server" Text="Đổi sang ngày" CssClass="css_gchu" /></td>
                                                <td>    
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>                                                
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="doi_ngay" runat="server" Width="130px" CssClass="css_form_c" kt_xoa="X"
                                                                ten="Đổi ngày đào tạo" ToolTip="Đổi TKB từ ngày cũ sang ngày mới"/>   
                                                     </div>      
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="doi" runat="server" Width="80px" Text="Đổi" OnClick="return ns_dt_tk_tkb_P_DOI_NGAY();" />  
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="False" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="10" cotAn="so_id" hamRow="ns_dt_tk_tkb_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px">
                                                    <HeaderStyle Width="10px"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Chủ đề" DataField="chude" HeaderStyle-Width="200px">
                                                    <ItemStyle CssClass="css_Gma" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Th. luong" DataField="thluong" HeaderStyle-Width="100px">
                                                    <ItemStyle CssClass="css_Gnd" />
                                                </asp:BoundField>      
                                                 <asp:BoundField HeaderText="Giờ b.đầu" DataField="gio_d" HeaderStyle-Width="80px">
                                                    <ItemStyle CssClass="css_Gma_c" />
                                                </asp:BoundField>
                                                 <asp:BoundField HeaderText="Giờ k.thúc" DataField="gio_c" HeaderStyle-Width="80px">
                                                    <ItemStyle CssClass="css_Gma_c" />
                                                </asp:BoundField> 
                                                <asp:BoundField DataField="so_id" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_dt_tk_tkb_P_LKE()" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="height:30px; vertical-align:bottom;">
                                        <Cthuvien:nhap ID="copy" runat="server" Text="Sao chép từ KHĐT chi tiết" OnClick="return ns_dt_tk_tkb_P_COPY();" />  
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right" valign="top">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu" Text="Ngày học" />
                                                </td>
                                                <td align="left">    
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>                                                
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY" runat="server" Width="130px" CssClass="css_form_c" kt_xoa="G"
                                                                ten="Ngày đào tạo" onchange="ns_dt_tk_tkb_P_KTRA('NGAY')"/>   
                                                     </div>      
                                                </td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu" Text="Chủ đề" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="CHUDE" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" ten="Chủ đề"
                                                        Width="270px" MaxLength="50"></Cthuvien:ma>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" CssClass="css_gchu">Thời lượng</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:so ID="thluong" ten="Thời lượng đào tạo" runat="server" Width="150px" CssClass="css_form_c" kt_xoa="X"  onchange="ns_dt_tk_tkb_P_KTRA('THLUONG')"/>
                                                </td>
                                            </tr>                                            
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="css_gchu">Nội dung</asp:Label>
                                                </td>
                                                <td align="left" colspan="3">
                                                    <Cthuvien:nd ID="ndung" runat="server" TextMode="MultiLine" CssClass="css_form" kt_xoa="X" Height="50px"
                                                        Width="100%" ten="Nội dung" MaxLength="250"></Cthuvien:nd>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="css_gchu">Loại GV</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:kieu ID="loai_gv" runat="server" CssClass="css_ma_c" Width="22px" lke="NB,NG" Text="NB" ToolTip="Loại GV: NB-Nội bộ, NG-Ngoài" onchange="ns_dt_tk_tkb_P_KTRA('LOAI_GV')"/>
                                               </td>
                                                <td align="left">
                                                    <asp:Label ID="Label5" runat="server" CssClass="css_gchu">Giảng viên</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="gvien" runat="server" CssClass="css_form" kt_xoa="X" ten="Giảng viên"
                                                        Width="150px" onchange="ns_dt_tk_tkb_P_KTRA('GVIEN')" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" ktra="NS_CB,ma,ten" ToolTip="Ấn F1 để chọn GV" BackColor="#f6f7f7"></Cthuvien:ma>
                                                    <Cthuvien:ma ID="SO_ID_GV" runat="server" CssClass="css_form" kt_xoa="X" ten="Giảng viên"
                                                        Width="0px" style="display:none;"></Cthuvien:ma>
                                                </td>
                                            </tr>    
                                            
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label6" runat="server" CssClass="css_gchu">Loại hình gd</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_lke ID="lgv" ktra="DT_MA_LGV" runat="server" Width="160px"></Cthuvien:DR_lke>                                                    
                                                 </td>
                                                <td align="left">                                                    
                                                </td>
                                                <td align="left">                                                    
                                                </td>
                                            </tr>   

                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu" Text="Giờ b.đầu" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="GIO_D" runat="server" CssClass="css_form_c" kt_xoa="X" ten="Giờ b.đầu"
                                                        Width="160px" MaxLength="5" onchange="ns_dt_tk_tkb_P_KTRA('GIO_D')"></Cthuvien:ma>
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc4" runat="server" CssClass="css_gchu" Text="Giờ k.thúc" />                                                    
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="GIO_C" runat="server" CssClass="css_form_c" kt_xoa="X" ten="Giờ k.thúc"
                                                        Width="150px" MaxLength="5" onchange="ns_dt_tk_tkb_P_KTRA('GIO_C')"></Cthuvien:ma>
                                                </td>
                                            </tr>   

                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label7" runat="server" CssClass="css_gchu">Địa điểm</asp:Label>
                                                </td>
                                                <td align="left" colspan="3">
                                                    <Cthuvien:ma ID="DDIEM" runat="server" CssClass="css_form" kieu_unicode="True" kt_xoa="X" ten="Địa điểm"
                                                        Width="100%" MaxLength="250"></Cthuvien:ma>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label8" runat="server" CssClass="css_gchu">Ghi chú</asp:Label>
                                                </td>
                                                <td align="left" colspan="3">
                                                    <Cthuvien:nd ID="NOTE" runat="server" TextMode="MultiLine" CssClass="css_form" kt_xoa="X" Height="50px"
                                                        Width="100%" ten="Ghi chú" MaxLength="250"></Cthuvien:nd>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        
                                    </td>
                                </tr>
                            </table>
                            <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1" style="width: 100%;">
                                <tr>
                                    <td style="padding-top: 20px">
                                        <div class="box3 txCenter" style="width: 100%;">                                                   
                                            <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" OnClick="return ns_dt_tk_tkb_P_MOI();" />  
                                            <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" OnClick="return ns_dt_tk_tkb_P_NH();" />
                                            <Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" OnClick="return ns_dt_tk_tkb_P_XOA();" />                                                                                                     
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
         <Cthuvien:an ID="kthuoc" runat="server" Value="1200,550"/>
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
    </div>
</asp:Content>

