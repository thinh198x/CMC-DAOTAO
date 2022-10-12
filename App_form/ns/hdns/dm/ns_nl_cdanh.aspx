<%@ Page Title="ns_nl_cdanh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_nl_cdanh.aspx.cs" Inherits="f_ns_nl_cdanh" %>

<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td>
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Gán năng lực cho chức danh" />
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
                        <td>
                            <table id="UPa_ct" runat="server" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Chức danh" CssClass="css_gchu" Width="70px" />
                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="0">
                                                        <tr>
                                                            <td>                                                               
                                                                <Cthuvien:ma ID="NHOM" runat="server" kieu_chu="true" CssClass="css_form" kt_xoa="X" f_tkhao="~/App_form/ns/hdns/tl/ns_ma_cdanh.aspx" ktra="ns_ma_cdanh,ma,ten" Width="130px" 
                                                                onchange="ns_nl_cdanh_P_KTRA('NHOM')" placeholder="Nhấn (F1)" gchu="gchu" ten="vị trí chức danh" BackColor="#f6f7f7" />                                                              
                                                            </td>
                                                            <td>
                                                                <Cthuvien:bbuoc ID="Label1" runat="server" Text="Nhóm năng lực" CssClass="css_gchu_c" Width="90px" />
                                                            </td>
                                                            <td>
                                                                 <Cthuvien:DR_lke ID="nhom_nl" runat="server" Width="130px" ktra="DT_NHOM_NL" onchange="ns_nl_cdanh_P_KTRA('NHOM_NL')" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text="Năng lực" CssClass="css_gchu_c" Width="70px" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:DR_list ID="nang_luc" Enabled="true" runat="server" Width="219px" ten="năng lực" ReadOnly="true" onchange="ns_nl_cdanh_P_KTRA('NANG_LUC')"  />                                                                
                                                            </td>
                                                            <td>
                                                                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <table id="NPa" runat="server" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <%--<td>
                                                                <Cthuvien:tab ID="NPa_dk" runat="server" CssClass="css_tab_ngang_ac" Width="150px"
                                                                    Height="20px" Text="Điều kiện tìm kiếm" ham="ns_nl_cdanh_P_NPA('dk')" />
                                                            </td>
                                                            <td style="width: 1px;" />
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_kq" runat="server" CssClass="css_tab_ngang_de" Width="150px"
                                                                    Height="20px" Text="Chọn kết quả hiển thị" ham="ns_nl_cdanh_P_NPA('kq')" />
                                                            </td>--%>
                                                            
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" class="tab_content">
                                                    <asp:Panel ID="Pa_dk" runat="server" Style="display: block;">
                                                        <%--width: 490px; height: 470px;--%>
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="left">
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td style="height: 40px;"><asp:Label ID="Label5" runat="server" Text="Năng lực chưa được gán" CssClass="css_gchu_c" Font-Bold="true"  /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div style="height: 400px; width: 580px; overflow: scroll">
                                                                                    <Cthuvien:GridX ID="GR_gtrdk" runat="server" loai="L" hamRow="ns_nl_cdanh_GR_gtrdk_CHUYEN()"
                                                                                        AutoGenerateColumns="false" hangKt="18" PageSize="1" CssClass="table gridX" cotAn="nhom_nl,nang_luc" >
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                            <asp:BoundField HeaderText="Nhóm năng lực" DataField="ten_nhom_nl" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                                                                            <asp:BoundField HeaderText="Tên năng lực" DataField="ten_nang_luc" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                                                            <asp:BoundField HeaderText="Mức năng lực" DataField="muc_nl" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                                                            <asp:BoundField HeaderText="Nội dung năng lực" DataField="mota_theomuc" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gma" /> 
                                                                                            <asp:BoundField DataField="nhom_nl" /> 
                                                                                            <asp:BoundField DataField="nang_luc" />                                                                                                   
                                                                                        </Columns>
                                                                                    </Cthuvien:GridX>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    
                                                                </td>

                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <asp:Label ID="Label2" runat="server" Text=">>>" CssClass="css_gchu_c" Width="20px" />
                                                                        </tr>
                                                                        <tr>
                                                                            <asp:Label ID="Label3" runat="server" Text="<<<" CssClass="css_gchu_c" Width="20px" />
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td align="left">
                                                                    <table cellpadding="0" cellspacing="0">
                                                                         <tr>
                                                                            <td style="height: 40px;">
                                                                                <asp:Label ID="Label7" runat="server" CssClass="css_gchu_c" Text="Năng lực đã được gán" Font-Bold="true"  />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                 <div style="height: 400px; width: 580px; overflow: scroll">
                                                                        <table cellpadding="0" cellspacing="0">
                                                                           
                                                                            <tr>
                                                                                <td>
                                                                                    <Cthuvien:GridX ID="GR_ct" runat="server" loai="L" AutoGenerateColumns="false" PageSize="1"  hamRow="ns_nl_cdanh_GR_ct_CHUYEN()"
                                                                                        cotAn="nhom_nl,nang_luc" CssClass="table gridX" hangKt="18" cot="">
                                                                                       
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                            <asp:BoundField HeaderText="Nhóm năng lực" DataField="ten_nhom_nl" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                                                                            <asp:BoundField HeaderText="Tên năng lực" DataField="ten_nang_luc" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                                                            <asp:BoundField HeaderText="Mức năng lực" DataField="muc_nl" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                                                            <asp:BoundField HeaderText="Nội dung năng lực" DataField="mota_theomuc" HeaderStyle-Width="140px" ItemStyle-CssClass="css_Gma" /> 
                                                                                            <asp:BoundField DataField="nhom_nl" /> 
                                                                                            <asp:BoundField DataField="nang_luc" />                                                                                            
                                                                                        </Columns>
                                                                                        
                                                                                    </Cthuvien:GridX>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                   
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pa_kq" runat="server" Style="display: none;">
                                                        <div style="height: 400px; width: 865px; overflow: scroll">
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <div id="UPa_lke">
                                                                            <Cthuvien:GridX ID="GR_lke" runat="server" loai="N" AutoGenerateColumns="false" PageSize="1"
                                                                                hangKt="18" CssClass="table gridX" cot="chon,nhom,ma,ten,dkthem,cot" cotAn="nhom,ma,dkthem,cot">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                    <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                                                                        <ItemTemplate>
                                                                                            <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField HeaderText="Nhóm" DataField="nhom" HeaderStyle-Width="18px" />
                                                                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="40px" />
                                                                                    <asp:BoundField HeaderText="Dữ liệu hiển thị" DataField="ten" HeaderStyle-Width="786px" ItemStyle-CssClass="css_Gma" />
                                                                                    <asp:BoundField HeaderText="" DataField="dkthem" />
                                                                                    <asp:BoundField HeaderText="" DataField="cot" />
                                                                                </Columns>
                                                                            </Cthuvien:GridX>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <%--<td id="id_check" runat="server">
                                                    <table cellpadding="0" cellspacing="1" style="display: inline">
                                                        <tr>
                                                            <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                                                <img alt="" src="../../images/bitmaps/dong.png" title="Chọn tất cả" onclick="return ns_nl_cdanh_CHON();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>--%>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight2">
                                                        <a href="#" class="bt bt-grey" onclick="return ns_nl_cdanh_P_NH();form_P_LOI();"><span class="txUnderline">N</span>hập</a>
                                                    </div>
                                                </td>                                                
                                                <%--<td id="id_tk" runat="server">
                                                    <table cellpadding="0" cellspacing="1" style="display: inline">
                                                        <tr>
                                                            <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height:20px">
                                                                <img alt="" src="../../images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_nl_cdanh_HangLen();" />
                                                            </td>
                                                            <td style="border: gray 1px solid; width: 20px; height:20px;" align="center" valign="middle">
                                                                <img alt="" src="../../images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_nl_cdanh_HangXuong();" />
                                                            </td>
                                                            <td style="border: gray 1px solid; width: 20px; height:20px;" align="center" valign="middle">
                                                                <img alt="" src="../../images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_nl_cdanh_CatDong();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="css_border" align="left">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1300,620" />
    </div>
    
</asp:Content>
