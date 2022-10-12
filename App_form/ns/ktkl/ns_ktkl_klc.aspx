<%@ Page Title="ns_ktkl_klc" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_ktkl_klc.aspx.cs" Inherits="f_ns_ktkl_klc" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Kỷ luật chung" />
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
                        <td align="left" valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="21" hamRow="ns_ktkl_klc_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Số QĐ" DataField="soqd" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Ngày QĐ" DataField="ngayqd" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke"
                                            ham="ns_ktkl_klc_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc5" runat="server" Text="Số quyết định" CssClass="css_gchu" ToolTip="Số quyết định"></Cthuvien:bbuoc>
                                                </td>

                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="SOQD" ten="Số quyết định" runat="server" kt_xoa="K" CssClass="css_form" Width="155px" kieu_chu="true" onchange="return ns_ktkl_klc_P_KTRA('SOQD')" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Ngày quyết định" CssClass="css_gchu_c" Width="120px" ToolTip="Ngày quyết định"></Cthuvien:bbuoc>
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAYQD" ten="Ngày quyết định" onchange="ns_ktkl_klc_P_KTRA('NGAYQD')" runat="server" Width="155px" CssClass="css_form_c" kt_xoa="X" kieu_luu="S" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" Text="Hình thức KL" CssClass="css_gchu" ToolTip="Hình thức KL"></Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="HINHTHUC" ten="Hình thức kỷ luật" ToolTip="Hình thức kỷ luật" runat="server" placeholder="Nhấn (F1)"
                                                                    CssClass="css_form" BackColor="#f6f7f7" ktra="ns_ma_htkl,ma,ten" kieu_chu="true" Width="155px" kt_xoa="X"
                                                                    f_tkhao="~/App_form/ns/ktkl/ma/ns_ma_htkl.aspx" onfocusout="ns_ktkl_klc_P_KTRA('hinhthuc')" gchu="gchu" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label6" runat="server" Text="Kỷ luật từ ngày" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" ten="Kỷ luật từ ngày" runat="server" Width="129px" CssClass="css_form_c" kt_xoa="X" kieu_luu="S" />
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="Đến ngày" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc" ten="Kỷ luật đến ngày" ToolTip="Kỷ luật đến ngày" runat="server" Width="155px" CssClass="css_form_c" kt_xoa="X" kieu_luu="S" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" Text="Cấp kỷ luật" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="cap_ktkl" ten="Cấp kỷ luật" ToolTip="Mã cấp kỷ luật" runat="server" placeholder="Nhấn (F1)"
                                                                    CssClass="css_form" BackColor="#f6f7f7" ktra="ns_ma_cap_ktkl,ma,ten" kieu_chu="true" Width="155px" kt_xoa="X"
                                                                    f_tkhao="~/App_form/ns/ktkl/ma/ns_ma_cap_ktkl.aspx" onfocusout="ns_ktkl_klc_P_KTRA('CAP_KTKL')" gchu="gchu" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label8" runat="server" Text="Nơi kỷ luật" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="noi_ktkl" ten="Nơi kỷ luật" ToolTip="Mã nơi kỷ luật" runat="server" placeholder="Nhấn (F1)"
                                                                    CssClass="css_form" BackColor="#f6f7f7" ktra="ns_ma_noi_ktkl,ma,ten" kieu_chu="true" Width="180px" kt_xoa="X"
                                                                    f_tkhao="~/App_form/ns/ktkl/ma/ns_ma_noi_ktkl.aspx" onfocusout="ns_ktkl_klc_P_KTRA('NOI_KTKL')" gchu="gchu" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label5" runat="server" Text="Người ký" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="nguoiky" ten="Người ký" ToolTip="Người ký quyết định" runat="server"
                                                        kt_xoa="X" CssClass="css_form" Width="467px" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                            <%-- <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label22" runat="server" Text="Ghi chú" Width="90px" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:ma ID="ghichu" runat="server"
                                                        kt_xoa="X" CssClass="css_ma" Width="350px" kieu_unicode="true" />
                                                </td>
                                            </tr>--%>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left" valign="top">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                    CssClass="table gridX" loai="N" cot="so_the,ten,phong,lydo,mucphat,ghichu" hangKt="15" hamUp="ns_ktkl_klc_Update">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                        <asp:TemplateField HeaderText="Mã cán bộ(*)" HeaderStyle-Width="100px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="so_the" runat="server" Width="100px" CssClass="css_Gma_c" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx"
                                                                                    ktra="ns_cb,so_the,ten" kieu_chu="true" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="Tên cán bộ(*)" DataField="ten" HeaderStyle-Width="200px"
                                                                            ItemStyle-CssClass="css_Gma" />
                                                                        <asp:BoundField HeaderText="Phòng" DataField="phong" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                                                        <asp:TemplateField HeaderText="Lý do" HeaderStyle-Width="282px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="lydo" runat="server" Width="282px" CssClass="css_Gma" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Mức phạt" HeaderStyle-Width="70px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:so ID="mucphat" runat="server" Width="70px" CssClass="css_Gso" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Ghi chú" HeaderStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="ghichu" runat="server" Width="150px" CssClass="css_Gma" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </Cthuvien:GridX>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td>
                                                    <a href="#" onclick="return ns_ktkl_klc_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                    <a href="#" onclick="return ns_ktkl_klc_P_MOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                    <a href="#" class="bt bt-grey" onclick="return ns_ktkl_klc_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                    <a href="#" onclick="return nhap_file();" class="bt bt-grey"><span class="txUnderline">F</span>ile</a>
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
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="so_id" runat="server" value="0" />
    <Cthuvien:an ID="kthuoc" runat="server" Value="1350,805" />
</asp:Content>
