<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ns_tt_bh_cmccare.aspx.cs" Inherits="f_ns_tt_bh_cmccare"
    Title="ns_tt_bh_cmccare" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Thông tin bảo hiểm CMC Care" />
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
                        <td align="left" valign="top" style="height: 260px" class="form_left">
                            <table cellpadding="1" id="UPa_tk" cellspacing="1">
                                <tr>
                                    <td align="left" style="height: 60px">
                                        <table cellpadding="1" cellspacing="1" border="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label20" runat="server" Width="100px" Text="Mã/Tên nhân viên" CssClass="css_gchu_c" />
                                                </td>
                                                <td style="padding-bottom: 2px">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="so_the_tk" kt_xoa="X" runat="server" Width="170px" CssClass="css_form" ten="Mã nhân viên" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Bbuoc3" runat="server" CssClass="css_gchu_c" Width="100px">Gói BH</asp:Label>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="goi_bh_tk" BackColor="#f6f7f7" runat="server" Width="170px" CssClass="css_form" f_tkhao="~/App_form/ns/ma/ns_ma_chiphi_cmccare.aspx"
                                                                    ktra="ns_ma_chiphi_cmccare,ma,ten" kt_xoa="X" kieu_chu="true" ten="Gói BH" placeholder="Nhấn F1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label7" runat="server" Width="100px" Text="Ngày hiệu lực" CssClass="css_gchu_c" />
                                                </td>
                                                <td style="padding-bottom: 2px">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayc_tk" runat="server" Width="145px" CssClass="css_form_c" kieu_luu="S"
                                                                        kt_xoa="X" />
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label10" runat="server" Width="100px" CssClass="css_gchu_c">Ngày hết hiệu lực</asp:Label>
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd_tk" runat="server" Width="145px" CssClass="css_form_c" kieu_luu="S"
                                                                        kt_xoa="X" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td style="padding-top: 7px; padding-bottom: 7px">
                                                    <a href="#" onclick="return ns_tt_bh_cmccare_P_LKE();form_P_LOI();" class="bt bt-grey"><i class="fa fa-search"></i>Tìm kiếm</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="height: 360px; width: 600px; overflow-x: scroll">
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="10" cotAn="nsd,ngay_hl,ghichu,cdanh,phong,ngayd,phibh_nam" hamRow="ns_tt_bh_cmccare_GR_lke_RowChange()"
                                                cot="so_the,ten,ten_cdanh,ten_phong,nsinh,socmt,goi_bh,ngay_thamgia,songay_thamgia,mucphi,ngayd,phibh_nam,cdanh,phong">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="so_the" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gma" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="150px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="150px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Đơn vị">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma runat="server" ID="ten_phong" Enabled="false" ReadOnly="true" Width="150px" CssClass="css_Gma"></Cthuvien:ma>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Ngày sinh" DataField="nsinh" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gma_c" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Số CMND" DataField="socmt" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gma" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Gói bảo hiểm" DataField="goi_bh" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Ngày tham gia" DataField="ngay_thamgia" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gma_c" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Số ngày tham gia BH" DataField="songay_thamgia" HeaderStyle-Width="120px">
                                                        <ItemStyle CssClass="css_Gma_r" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Phí bảo hiểm" DataField="mucphi" HeaderStyle-Width="90px">
                                                        <ItemStyle CssClass="css_Gma_r" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Ngày hiệu lực theo chi phí" DataField="ngayd">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Mức phí theo gói" DataField="phibh_nam">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Mã chức danh" DataField="cdanh">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Mã phòng ban" DataField="phong">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>

                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" rong="50" loai="X" gridId="GR_lke"
                                            ham="ns_tt_bh_cmccare_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="height: 260px" class="form_right">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label2" runat="server" CssClass="css_gchu">Mã nhân viên</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="SO_THE" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true" placeholder="Nhấn (F1)"
                                                                    Width="150px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Mã nhân viên" MaxLength="30"
                                                                    onchange="ns_hd_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label38" runat="server" Text="Họ tên" CssClass="css_gchu_c" Width="90px"></asp:Label></td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="TEN" ten="Họ và tên" runat="server" Width="150px" BackColor="#f6f7f7" CssClass="css_form" kt_xoa="X" kieu_chu="true" Enabled="false" ReadOnly="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label40" runat="server" Text="Chức danh" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="ten_cdanh" runat="server" Width="150px" ten="Chức danh" CssClass="css_form" Enabled="false" ReadOnly="false" BackColor="#f6f7f7" kt_xoa="X" ToolTip="Chức danh" />
                                                                <Cthuvien:an ID="CDANH" runat="server" Value="" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label39" runat="server" Text="Phòng ban" CssClass="css_gchu_c" Width="90px"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="ten_phong" runat="server" CssClass="css_form" kt_xoa="X" Width="150px" ten="Phòng ban" BackColor="#f6f7f7" Enabled="false" ReadOnly="false"></Cthuvien:ma>
                                                                <Cthuvien:an ID="PHONG" runat="server" Value="" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" Text="Ngày sinh" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="nsinh" runat="server" Width="124px" CssClass="css_form_c" kieu_luu="S" Enabled="false" ReadOnly="false"
                                                                        kt_xoa="X" BackColor="#f6f7f7" />
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label8" runat="server" Text="Số CMND" CssClass="css_gchu_c" Width="90px"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="socmt" runat="server" CssClass="css_form" kt_xoa="X" Width="150px" ten="Số CMND" BackColor="#f6f7f7" Enabled="false" ReadOnly="false"></Cthuvien:ma>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" Text="Gói bảo hiểm" CssClass="css_gchu"></Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="GOI_BH" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true" placeholder="Nhấn (F1)"
                                                                    Width="150px" f_tkhao="~/App_form/ns/ma/ns_ma_chiphi_cmccare.aspx" gchu="gchu" ten="Gói bảo hiểm" MaxLength="30"
                                                                    onchange="ns_tt_bh_cmccare_tinhngay()" ktra="ns_ma_chiphi_cmccare,ma,ten" kt_xoa="X" />
                                                                <Cthuvien:an ID="ngayd" runat="server" Value="" />
                                                                <Cthuvien:an ID="phibh_nam" runat="server" Value="" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Label6" runat="server" Text="Ngày tham gia" Width="90px" CssClass="css_gchu_c"></Cthuvien:bbuoc>
                                                            </td>
                                                            <td align="left">
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_THAMGIA" runat="server" Width="124px" CssClass="css_form_c" kieu_luu="S"
                                                                        kt_xoa="X" onchange="ns_tt_bh_cmccare_tinhngay()" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label9" runat="server" Text="Số ngày tham gia" CssClass="css_gchu"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:so ID="songay_thamgia" runat="server" CssClass="css_form_r" kt_xoa="X" Width="150px" ten="Mức phí" BackColor="#f6f7f7"
                                                                    Enabled="false" ReadOnly="false"></Cthuvien:so>
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Label5" runat="server" Text="Mức phí" CssClass="css_gchu_c" Width="90px"></Cthuvien:bbuoc>
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:so ID="MUCPHI" runat="server" CssClass="css_form_r" kt_xoa="X" Width="150px" ten="Mức phí" BackColor="#f6f7f7" Enabled="false" ReadOnly="false"></Cthuvien:so>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-left: 20px">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1" class="box3 txRight">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_tt_bh_cmccare_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_tt_bh_cmccare_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_tt_bh_cmccare_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON('MA,TEN');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                        <a href="#" onclick="return ns_biendong_bh_Export();form_P_LOI();" class="bt bt-grey"><i class="fa fa-excel"></i><span class="txUnderline">X</span>uất excel</a>
                                                    </div>
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="nhap" runat="server" Width="70px" Text="File mẫu" OnServerClick="nhap_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="css_border" align="left" style="height: 19px">
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
    <Cthuvien:an ID="kthuoc" runat="server" Value="1200,650" />
</asp:Content>
