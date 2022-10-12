<%@ Page Title="ns_hdns_nlcdanh_dvi" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_hdns_nlcdanh_dvi.aspx.cs" Inherits="f_ns_hdns_nlcdanh_dvi" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Gán mức năng lực cho đơn vị" />
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
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                            loai="L" hangKt="16" cotAn="ma,ma_ct,nsd" hamRow="ns_hdns_nlcdanh_dvi_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã" DataField="xep" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Tên bộ phận" DataField="ten" HeaderStyle-Width="245px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField DataField="ma" />
                                                <asp:BoundField DataField="ma_ct" />
                                                <asp:BoundField DataField="nsd" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" rong="70" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_hdns_nlcdanh_dvi_P_KD_P_LKE()" />
                                    </td>
                                </tr>
                                
                            </table>
                        </td>
                        <td valign="top" class="form_right">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        
                                    </td>
                                </tr>
                                <%--<tr style="display:none">                                                        
                                                        <td>
                                                            <Cthuvien:ma ID="day" ten="Đơn vị của tập đoàn" runat="server" text="A"/>
                                                        </td>
                                          </tr>--%>
                                <tr>
                                    <td>
                                        <div style="height: 480px; width: 780px; overflow: scroll">
                                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1" loai="N" CssClass="table gridX" hangKt="19" hamUp="ns_hdns_nlcdanh_dvi_tinh" cotAn="so_id,ma_cdanh,so_id_dg" 
                                                cot="ten_cdanh,nhom_nl,tennl,mucnl,ghichu,ma_phong,SO_ID,so_id_dg,dvi">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:TemplateField HeaderText="Chức danh" HeaderStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="ten_cdanh" runat="server" kieu_chu="true" CssClass="css_Gma_c" guiId="dvi" kt_xoa="X" f_tkhao="~/App_form/ns/hdns/tl/hd_cdanh_dvi.aspx" ktra="ht_ma_phong,ma,ten" Width="100px" 
                                                                onchange="ns_hdns_nlcdanh_dvi_P_KD_P_KTRA('DONVI')" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>    
                                                    <asp:TemplateField HeaderText="Nhóm năng lực" HeaderStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="nhom_nl" runat="server" kieu_chu="true" CssClass="css_Gma_c" kt_xoa="X" f_tkhao="~/App_form/ns/hdns/dm/dgnl_dm_xd_td_nl.aspx" ktra="ns_ma_cdanh,ma,ten" Width="100px" 
                                                                onchange="ns_hdns_nlcdanh_dvi_P_KD_P_KTRA('CDANH')" guiId="day" />
                                                        </ItemTemplate>
                                                     </asp:TemplateField>                                                
                                                    <asp:TemplateField HeaderText="Tên năng lực" HeaderStyle-Width="150px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="tennl" runat="server" Width="150px" CssClass="css_Gma_c" Enabled="false" kieu_chu="true"/>                                                            
                                                        </ItemTemplate>
                                                     </asp:TemplateField>                                                   
                                                    <asp:TemplateField HeaderText="Mức năng lực" HeaderStyle-Width="225px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="mucnl" runat="server" Width="225px" CssClass="css_Gma" kieu_unicode="true" onchange="ns_hdns_nlcdanh_dvi_P_KD_P_KTRA('TEN')"/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>                                                  
                                                    <asp:TemplateField HeaderText="Nội dung năng lực" HeaderStyle-Width="225px">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma ID="ghichu" runat="server" Width="225px" CssClass="css_Gma" kieu_unicode="true" onchange="ns_hdns_nlcdanh_dvi_P_KD_P_KTRA('TEN')"/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField> 
                                                    <asp:BoundField DataField="ma_phong" HeaderStyle-Width="10px" />
                                                    <asp:BoundField DataField="so_id" HeaderStyle-Width="10px" />
                                                    <asp:BoundField DataField="so_id_dg" HeaderStyle-Width="10px" />
                                                    <asp:BoundField DataField="dvi" HeaderStyle-Width="10px" />
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <div class="box3 txCenter">
                                                        <a href="#" onclick="return ns_hdns_nlcdanh_dvi_P_KD_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_hdns_nlcdanh_dvi_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_hdns_nlcdanh_dvi_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <%--<a href="#" onclick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>--%>
                                                        <a href="#" onclick="return form_P_TRA_CHON_GRID('GR_ct:ma,GR_ct:ten');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                    </div>
                                                </td>

                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height:20px;">
                                                    <img runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_hdns_nlcdanh_dvi_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;height:20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_hdns_nlcdanh_dvi_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;height:20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_hdns_nlcdanh_dvi_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px;height:20px;" align="center" valign="middle">
                                                    <img runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_hdns_nlcdanh_dvi_ChenDong('C');" />
                                                </td>
                                            </tr>                                           
                                            <%--<tr>
                                                <td style="display: none">                                                    
                                                    <Cthuvien:nhap ID="btn_excel_mau" runat="server" Text="Mẫu excel" Width="70px" onserverclick="btn_excel_mau_Click" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                                                </td>
                                                <td align="center">
                                                     <div  class="box3 txRight">    
                                                        <a href="#" onclick="return ns_hdns_nlcdanh_dvi_FILE_Import();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">Nh</span>ập excel</a>
                                                        <a href="#" onclick="return ns_hdns_nlcdanh_dvi_P_IN();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">X</span>uất excel</a>
                                                        <a href="#" onclick="return ns_hdns_nlcdanh_dvi_P_MAU();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">E</span>xcel mẫu</a>
                                                    </div>
                                                </td>
                                            </tr>--%>
                                        </table>
                                        <div id="UPa_gchu" class="css_border" align="left">
                                            <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        
                    </tr>
                    <tr>
                        <td colspan="2" class="css_border" align="left">
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <div id="UPa_hi">
        <Cthuvien:an ID="dvi" runat="server" Value="" />
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,670" />
    </div>
</asp:Content>
