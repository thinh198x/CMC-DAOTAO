<%@ Page Title="tl_ct_luong" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_ct_luong.aspx.cs" Inherits="f_tl_ct_luong" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                     <tr>
                        <td align="center">
                            <table cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td align="left">
                                        <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Thiết lập công thức lương" />
                                    </td>
                                    <td align="right">
                                        <div class="acc">
                                            <ul>
                                                <li><a href="#" onclick="return form_dong();"><i class="fa fa-sign-out"></i></a></li>
                                                <li><a href="#" onclick="return form_GOP();"><i class="fa fa-envelope-o"></i></a></li>
                                                <li><a href="#" onclick="return form_HELP();"><i class="fa fa-question"></i></a></li>
                                                <%--  <li class="vline"></li>--%>
                                                <%-- <li><i class="fa fa-user blue maR5"></i><span class="sz12">
                                                    <Cthuvien:luu ID="nsd" runat="server" Text="" CssClass="css_nsd" dich="K" /></span></li>--%>
                                            </ul>
                                            <div class="clear"></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Nhóm lương" Width="80px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <Cthuvien:DR_nhap Width="260px" ID="nluong" CssClass="css_form" DataTextField="TEN" Height="20px" DataValueField="MA" onchange="tl_ct_luong_P_KTRA('nluong');" runat="server" ten="Nhóm lương">
                                                    </Cthuvien:DR_nhap>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <table id="NPa" runat="server" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_ct" runat="server" CssClass="css_tab_ngang_ac" Width="110px"
                                                                    Height="20px" Text="Cột công thức" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="X" hangKt="12" cot="stt,macl,tencl,congthuc,TT" cotAn="macl,congthuc,TT" hamRow="tl_ct_luong2_GR_lke_RowChange()">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:BoundField DataField="STT" HeaderText="STT" HeaderStyle-Width="40px" ItemStyle-CssClass="css_ma_c" />
                                                            <asp:BoundField HeaderText="Mã cột lương" DataField="macl" HeaderStyle-Width="1px"></asp:BoundField>
                                                            <asp:BoundField HeaderText="Tên cột lương" DataField="tencl" HeaderStyle-Width="405px"></asp:BoundField>
                                                            <asp:BoundField DataField="congthuc" HeaderStyle-Width="10px" />
                                                            <asp:BoundField DataField="TT" HeaderStyle-Width="10px" />
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td id="Td1" runat="server" align="center">
                                                    <khud_slide:khud_slide ID="GR_ct_slide" runat="server" loai="X" rong="50" gridId="GR_ct"
                                                        ham="tl_ct_luong_P_LKE()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <table id="Table1" runat="server" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_dl" runat="server" CssClass="css_tab_ngang_ac" Width="110px"
                                                                    Height="20px" Text="Cột đầu vào" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="X" hangKt="12" cotAn="macl" cot="chon,tencl,macl" hamRow="tl_ct_luong_GR_lke_RowChange()">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:TemplateField HeaderStyle-Width="40px" HeaderText="Chọn">
                                                                <ItemTemplate>
                                                                    <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Tên dữ liệu" DataField="tencl" HeaderStyle-Width="405px" />
                                                            <asp:BoundField HeaderText="Mã cl" DataField="macl" />
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="GR_lke_td" runat="server" align="center">
                                                    <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="50" gridId="GR_lke"
                                                        ham="tl_ct_luong_P_DV_LKE()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle">
                                        <table cellpadding="0" cellspacing="0" id="Upa_tinh">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbltt" runat="server" Text="Thứ tự" Width="50px"></asp:Label>
                                                </td>
                                                <td>
                                                    <Cthuvien:ma runat="server" ID="tt" ten="Thứ tự" Text="0" kieu_so="true" CssClass="css_form_c" Width="30px"></Cthuvien:ma></td>
                                                
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table>
                                            <tr>
                                                <td>
                                                    <Cthuvien:nd ID="ct" ToolTip="Công thức" Rows="8" runat="server" kieu="U" Width="780px"
                                                        CssClass="css_ma" TextMode="MultiLine" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="left" valign="middle">
                                        <table cellpadding="0" cellspacing="0" id="Upa_nhap">
                                            <tr>
                                                <td align="left">
                                                    <div class="box3 txRight"  style="width:179px">
                                                        <a href="#" onclick="return tl_ct_luong_P_KT();form_P_LOI();" class="bt bt-grey">Kiểm tra CT</a>
                                                        <a href="#" onclick="return tl_ct_luong_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i>Lưu</a>

                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="vline"></div>
                                                </td>
                                                <td align="left">
                                                    <div class="box3 txRight" style="text-align:left; padding-left:50px;">
                                                        <a href="#" onclick="return tl_ct_luong_cong();" class="bt bt-grey">Cộng</a>
                                                        <a href="#" onclick="return tl_ct_luong_tru();" class="bt bt-grey">Trừ</a>
                                                        <a href="#" onclick="return tl_ct_luong_nhan();" class="bt bt-grey">Nhân</a>
                                                        <a href="#" onclick="return tl_ct_luong_chia();" class="bt bt-grey">Chia</a>
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
                        <td colspan="2" class="css_border" align="left">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu_nl" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1020,850" />
    </div>
</asp:Content>
