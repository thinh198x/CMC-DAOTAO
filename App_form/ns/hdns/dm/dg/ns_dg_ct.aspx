<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dg_ct.aspx.cs" Inherits="f_ns_dg_ct"
    Title="ns_dg_ct" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">        
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>                        
                        <td colspan="2">
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thiết lập công thức tính kết quả và xếp loại đánh giá" />
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
                        <td colspan="2" align="left">
                            <table id="UPa_tk" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu" Width="29px">Năm</Cthuvien:bbuoc>
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_lke ID="NAM_DR" ktra="TC_DG_CT_NAM" runat="server" ten="Năm" kt_xoa="G" Width="60px" onchange="ns_dg_ct_P_KTRA('NAM');"></Cthuvien:DR_lke> 
                                    </td>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Bbuoc4" runat="server" CssClass="css_gchu" Width="70px">Kỳ đánh giá</Cthuvien:bbuoc>
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_lke ID="MA_KDG_DR" ktra="TC_DG_CT_KY_KDG" runat="server" ten="Kỳ đánh giá" kt_xoa="G" Width="190px" onchange="ns_dg_ct_P_KTRA('MA_KDG');"></Cthuvien:DR_lke>
                                    </td>   
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu">Phân loại nhân viên</Cthuvien:bbuoc>
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_lke ID="MA_PLNV_DR" ten="Phân loại nhân viên" ktra="TC_DG_CT_PLNV" kt_xoa="G" Width="150px" runat="server" onchange="ns_dg_ct_P_KTRA('MA_PLNV');"></Cthuvien:DR_lke>                                                     
                                    </td>                                            
                                    <td align="left">
                                        <asp:Label ID="Label4" runat="server" CssClass="css_gchu">Cấp nhân viên</asp:Label>
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_lke ID="ma_cap_nv_dr" ktra="TC_DG_CT_CNV" kt_xoa="G" Width="150px" runat="server" onchange="ns_dg_ct_P_KTRA('MA_CAPNV');"></Cthuvien:DR_lke>  
                                    </td>                                                              
                                </tr>
                            </table>
                            <hr style="width:99%;" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width:50%; height:30px;"><asp:Label ID="Label5" runat="server" CssClass="css_gchu" Font-Bold="true">Các trường thông tin để thiết lập công thức</asp:Label></td>
                        <td align="left" style="width:50%; padding-left:10px;"><asp:Label ID="Label2" runat="server" CssClass="css_gchu" Font-Bold="true">Công thức</asp:Label></td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_truong" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="7" cot="chon,ten,field_name" cotAn="field_name" hamRow="ns_dg_ct_GR_truong_RowChange()" hamUp="ns_dg_ct_GR_truong_Update">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="35px">
                                                    <ItemTemplate>
                                                        <Cthuvien:kieu ID="chon" runat="server" Width="30px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Tên cột dữ liệu" DataField="ten" HeaderStyle-Width="353px" ItemStyle-Font-Bold="true"/>  
                                                <asp:BoundField DataField="field_name" />                                              
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>   
                            </table>
                        </td>
                        <td valign="top" align="center">                            
                            <table id="UPa_tchi" cellpadding="1" cellspacing="1">
                                <tr>                                                
                                    <td>
                                        <Cthuvien:GridX ID="GR_congthuc" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="7" cotAn="ma" cot="ma,ten" hamRow="ns_dg_ct_GR_congthuc_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã công thức" DataField="ma" ItemStyle-CssClass="css_ma" HeaderStyle-Width="120px" />
                                                <asp:BoundField HeaderText="Tên công thức tính" DataField="ten" HeaderStyle-Width="400px" ItemStyle-Font-Bold="true"/>                                                            
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                            </table>                            
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <div class="box3 txtCenter"> 
                                <Cthuvien:nhap ID="cong" runat="server" Width="80px" Text="Cộng" OnClick="return ns_dg_ct_cong();" /> 
                                <Cthuvien:nhap ID="tru" runat="server" Width="80px" Text="Trừ" OnClick="return ns_dg_ct_tru();" />
                                <Cthuvien:nhap ID="nhan" runat="server" Width="80px" Text="Nhân" OnClick="return ns_dg_ct_nhan();" />   
                                <Cthuvien:nhap ID="chia" runat="server" Width="80px" Text="Chia" OnClick="return ns_dg_ct_chia();" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left" style="height:30px;"><asp:Label ID="Label3" runat="server" CssClass="css_gchu" Font-Bold="true">Công thức tính</asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" id="UPa_ct">
                            <Cthuvien:nd ID="CONGTHUC" ToolTip="Công thức" Rows="8" runat="server" kieu="U" Width="98.5%"
                                            CssClass="css_ma" TextMode="MultiLine" kt_xoa="X"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <div class="box3 txCenter" style="padding-top:10px;">
                                <Cthuvien:nhap ID="moi" runat="server" Width="100px" Text="Làm mới" OnClick="return ns_dg_ct_P_MOI();form_P_LOI();" /> 
                                <Cthuvien:nhap ID="kiemtra" runat="server" Width="100px" Text="Kiểm tra" OnClick="return ns_dg_ct_P_KT();form_P_LOI();" /> 
                                <Cthuvien:nhap ID="luu" runat="server" Width="100px" Text="Ghi" OnClick="return ns_dg_ct_P_NH();form_P_LOI();" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="980,700" />
        <Cthuvien:an ID="so_id" runat="server" value="0" />
    </div>
</asp:Content>



