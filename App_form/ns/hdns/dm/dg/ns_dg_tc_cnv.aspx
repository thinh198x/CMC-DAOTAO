<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_dg_tc_cnv.aspx.cs" Inherits="f_ns_dg_tc_cnv"
    Title="ns_dg_tc_cnv" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divC.ascx" TagName="ctr_khud_divC" TagPrefix="khud" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="khud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td colspan="2">
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td><Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thiết lập tiêu chí đánh giá cho từng loại nhân viên" /></td>
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
                            </table>                            
                        </td>                        
                    </tr>
                    <tr>
                        <td class="form_left" valign="top">
                            <div>
                                <div style="overflow-x: scroll; width: 600px" >
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                        CssClass="table gridX" loai="X" hangKt="12" cotAn="so_id,ma_kdg,ma_plnv,ma_capnv" hamRow="ns_dg_tc_cnv_GR_lke_RowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="40px">
                                                <ItemStyle CssClass="css_Gma_c" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Kỳ đánh giá" DataField="ky_dg" HeaderStyle-Width="140px">
                                                <ItemStyle CssClass="css_Gnd" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Phân loại NV" DataField="plnv" HeaderStyle-Width="90px">
                                                <ItemStyle CssClass="css_Gnd" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Cấp NV" DataField="cap_nv" HeaderStyle-Width="80px">
                                                <ItemStyle CssClass="css_Gnd" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Ngày áp dụng" DataField="ngay_adung" HeaderStyle-Width="80px">
                                                <ItemStyle CssClass="css_Gma_c" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Tổng nhóm tiêu chí" DataField="tong_nhom" HeaderStyle-Width="100px">
                                                <ItemStyle CssClass="css_Gma_c" />
                                            </asp:BoundField>  
                                            <asp:BoundField HeaderText="Tổng tiêu chí" DataField="tong_tc" HeaderStyle-Width="100px">
                                                <ItemStyle CssClass="css_Gma_c" />
                                            </asp:BoundField>    
                                            <asp:BoundField DataField="so_id"/>    
                                            <asp:BoundField DataField="ma_kdg"/>   
                                            <asp:BoundField DataField="ma_plnv"/>   
                                            <asp:BoundField DataField="ma_capnv"/>                                        
                                        </Columns>
                                    </Cthuvien:GridX>
                                </div>                                
                                <khud:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                    ham="ns_dg_tc_cnv_P_LKE()" />
                            </div>                                
                            <div style="text-align:center;">
                                <Cthuvien:nhap ID="excel" runat="server" Width="80px" Text="Xuất excel" OnServerClick="excel_Click" /> 
                            </div>
                        </td>
                        <td class="form_right" valign="top" align="center">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1" style="width:100%;">   
                                <tr style="display: none">
                                    <td></td><td></td><td></td>
                                    <td><Cthuvien:ma ID="so_id" runat="server" Width="0px" kt_xoa="X" /></td>
                                </tr>                             
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu">Năm</Cthuvien:bbuoc>
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_lke ID="NAM" ktra="TC_DG_CNV_KY_NAM" ten="Năm" runat="server" Width="200px" kt_xoa="G" onchange="ns_dg_tc_cnv_P_KTRA('NAM');"></Cthuvien:DR_lke> 
                                    </td>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Bbuoc4" runat="server" CssClass="css_gchu">Kỳ đánh giá</Cthuvien:bbuoc>
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_lke ID="MA_KDG" ktra="TC_DG_CNV_KY_KDG" ten="Kỳ đánh giá" runat="server" Width="200px" kt_xoa="G" onchange="ns_dg_tc_cnv_P_KTRA('MA_KDG');"></Cthuvien:DR_lke>
                                    </td>                                                
                                </tr>                                                                                       
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu">Phân loại NV</Cthuvien:bbuoc>
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_lke ID="MA_PLNV" ktra="TC_DG_CNV_KY_PLNV" ten="Phân loại NV" Width="200px" runat="server" kt_xoa="G" onchange="ns_dg_tc_cnv_P_KTRA('MA_PLNV');"></Cthuvien:DR_lke>                                                     
                                    </td>                                            
                                    <td align="left">
                                        <asp:Label ID="Label6" runat="server" CssClass="css_gchu">Cấp NV</asp:Label>                                        
                                    </td>
                                    <td align="left">
                                        <Cthuvien:DR_lke ID="ma_capnv" ktra="TC_DG_CNV_KY_CNV" ten="Cấp NV" Width="200px" runat="server" kt_xoa="G" onchange="ns_dg_tc_cnv_P_KTRA('MA_CAPNV');"></Cthuvien:DR_lke>  
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <Cthuvien:bbuoc ID="Bbuoc5" runat="server" CssClass="css_gchu" Text="Ngày áp dụng" />
                                    </td>
                                    <td align="left">                                                    
                                        <div class="ip-group date">
                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_ADUNG" ten="Ngày áp dụng" runat="server" CssClass="css_form_c" kt_xoa="X"
                                                ToolTip="Ngày áp dụng" Width="172px" onchange="ns_dg_tc_cnv_P_KTRA('NGAY_ADUNG');" />
                                            <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                        </div>
                                    </td>
                                    <td></td><td></td>
                                </tr>                                                                  
                            </table>
                            <table id="UPa_tchi" runat="server" cellpadding="1" cellspacing="1">
                                <tr>                                                
                                    <td align="left">
                                        <div class="css_divb" style="margin-right:20px;">
                                            <div class="css_divCn">
                                                <Cthuvien:GridX ID="GR_tc" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                    CssClass="table gridX" loai="N" cot="ma_nhom_tc,tso_nhom,ma_tc,tso_tc,dmuc_l1,dmuc_l2,luyke_kysau,so_id" cotAn="so_id" hangKt="8" hamUp="ns_dg_tc_cnv_GR_tc_Update">
                                                    <Columns>
                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />                                                
                                                        <asp:TemplateField HeaderText="Nhóm tiêu chí" HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:DR_nhap ID="ma_nhom_tc" DataValueField="ma" DataTextField="ten" runat="server" Width="100%" CssClass="css_Gdrop" kt_xoa="X"></Cthuvien:DR_nhap>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Trọng số nhóm tiêu chí" HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="tso_nhom" runat="server" Width="100%" CssClass="css_Gma_r" kt_xoa="X" MaxLength="3" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tiêu chí" HeaderStyle-Width="140px">
                                                            <ItemTemplate>
                                                                <Cthuvien:DR_nhap ID="ma_tc" DataValueField="ma" DataTextField="ten" runat="server" Width="100%" CssClass="css_Gdrop" kt_xoa="X"></Cthuvien:DR_nhap>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Trọng số tiêu chí" HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="tso_tc" runat="server" Width="100%" CssClass="css_Gma_r" kt_xoa="X" MaxLength="3" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Định mức L1" HeaderStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="dmuc_l1" runat="server" Width="100%" CssClass="css_Gma_r" kt_xoa="X" MaxLength="3" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Định mức L2" HeaderStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <Cthuvien:so ID="dmuc_l2" runat="server" Width="100%" CssClass="css_Gma_r" kt_xoa="X" MaxLength="3" co_dau="K" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Lũy kế kỳ sau" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">                                                    
                                                            <ItemTemplate>
                                                                <Cthuvien:kieu ID="luyke_kysau" runat="server" CssClass="css_Gma_c" Width="22px" lke="C,K" kt_xoa="X" ToolTip="Lũy kế kỳ sau: C-Có, K-Không"/>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="so_id" />                                                
                                                    </Columns>
                                                </Cthuvien:GridX>
                                            </div>
                                            <khud:ctr_khud_divC ID="GR_ct_slide" runat="server" gridId="GR_tc" />
                                        </div>   
                                    </td>
                                </tr>
                            </table>
                            <table id="UPa_nhap_GR_tc" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="center" valign="middle">
                                        <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_dg_tc_cnv_CatDong();" />
                                    </td>
                                    <td align="center" valign="middle">
                                        <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_dg_tc_cnv_ChenDong('C');" />
                                    </td>
                                </tr>
                            </table>
                            <table id="UPa_nhap" cellpadding="1" cellspacing="1" width="100%" style="margin-top:5px;">
                                <tr>
                                    <td align="center">
                                        <div class="box3 txCenter">
                                            <Cthuvien:nhap ID="moi" runat="server" Text="Làm mới" OnClick="return ns_dg_tc_cnv_P_MOI();form_P_LOI();" /> 
                                            <Cthuvien:nhap ID="nhap" runat="server" Width="80px" Text="Ghi" OnClick="return ns_dg_tc_cnv_P_NH();form_P_LOI();" />
                                            <Cthuvien:nhap ID="chon" runat="server" Width="80px" Text="Chọn" OnClick="return form_P_TRA_CHON('TEN,CAP,SO_ID');form_P_LOI();" />   
                                            <Cthuvien:nhap ID="xoa" runat="server" Width="80px" Text="Xóa" OnClick="return ns_dg_tc_cnv_P_XOA();form_P_LOI();" />
                                        </div>
                                    </td>                                               
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1490,640" />
</asp:Content>


