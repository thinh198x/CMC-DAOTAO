<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tl_khenthuong.aspx.cs" Inherits="f_tl_khenthuong"
    Title="tl_khenthuong" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu5" runat="server" CssClass="css_tieudeM" Text="Khai báo giữ lương" />
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
                        <td align="left" valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0" id="UPa_tk">
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc10" runat="server" CssClass="css_gchu_c" Width="60px">Ngày hiệu lực từ</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY1" runat="server" ten="ngày thanh toán" Width="160px" CssClass="css_form_c" kieu_luu="S" kt_xoa="X">  </Cthuvien:ngay>
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
                                    <td>
                                        <table>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc12" runat="server" CssClass="css_gchu_c" Width="60px">Đến</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY2" runat="server" ten="ngày thanh toán" Width="160px" CssClass="css_form_c" kieu_luu="S" kt_xoa="X">  </Cthuvien:ngay>
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
                                    <td>
                                        <table>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc22" runat="server" CssClass="css_gchu_c" Width="60px">Nhân viên nghỉ việc</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:kieu ID="Kieu1" runat="server" CssClass="css_form_c" Width="40px" ten="ten_kieu"
                                                                    Text="C" lke="C,K" ToolTip="C-Có, K-Không" />
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>

                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="padding-top: 10px; padding-bottom: 10px">
                                            <tr>
                                                <td style="width: 72px"></td>
                                                <td>
                                                    <div class="box3 txLeft">
                                                        <a href="#" onclick="return tl_khenthuong_P_LKE();form_P_LOI();" class="bt bt-grey"><i class="fa fa-search"></i>Tìm kiếm</a>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>

                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <div style="height: 200px; width: 334px;     overflow-y: scroll;">
                                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" CssClass="table gridX"
                                            loai="L" hangKt="10" cotAn="ma,ma_ct,nsd" hamRow="ht_maph_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Mã" DataField="xep" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Tên bộ phận" DataField="ten" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField DataField="ma" />
                                                <asp:BoundField DataField="ma_ct" />
                                                <asp:BoundField DataField="nsd" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                        </div>
                                    </td>
                                </tr>
                                 <tr style="height:10px;">
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" rong="70" runat="server" loai="X" gridId="GR_lke"
                                            ham="ht_maph_P_LKE()" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="height: 200px; width: 334px; overflow: scroll">
                                            <Cthuvien:GridX ID="GR_lke1" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                CssClass="table gridX" loai="X" hangKt="5" cotAn="CDANH,PHONG,KYLUONGID,GHICHU" cot="SO_THE,TEN,CDANH,CDANH_TEN,PHONG,TEN_PHONG,KYLUONGID,TEN_KYLUONG,TIEN_LUONG,TIEN_LUONG_HOLD,NGAY_THANHTOAN,GHICHU"
                                                hamRow="tl_khenthuong_GR_lke_RowChange()">
                                                <Columns>
                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                    <asp:BoundField HeaderText="Mã nhân viên" DataField="SO_THE" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gma" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Tên nhân viên">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma runat="server" ID="TEN" Enabled="false" ReadOnly="true" Width="150px" CssClass="css_Gma"></Cthuvien:ma>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Mã chức danh" DataField="CDANH" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gma_r" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Chức danh">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma runat="server" ID="CDANH_TEN" Enabled="false" ReadOnly="true" Width="150px" CssClass="css_Gma"></Cthuvien:ma>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Mã phòng" DataField="PHONG" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gma_r" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Phòng ban">
                                                        <ItemTemplate>
                                                            <Cthuvien:ma runat="server" ID="TEN_PHONG" Enabled="false" ReadOnly="true" Width="150px" CssClass="css_Gma"></Cthuvien:ma>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Mã kỳ lương" DataField="KYLUONGID" HeaderStyle-Width="150px">
                                                        <ItemStyle CssClass="css_Gma" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Kỳ lương" DataField="TEN_KYLUONG" HeaderStyle-Width="150px">
                                                        <ItemStyle CssClass="css_Gma" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Tiền Lương" DataField="TIEN_LUONG" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gma_r" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Tiền bị giữ" DataField="TIEN_LUONG_HOLD" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gma_r" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Ngày thanh toán" DataField="NGAY_THANHTOAN" HeaderStyle-Width="100px">
                                                        <ItemStyle CssClass="css_Gma_c" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Ghi chú" DataField="GHICHU">
                                                        <ItemStyle CssClass="css_Gnd" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </Cthuvien:GridX>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td2" runat="server" align="center" style="padding-top: 10px">
                                        <khud_slide:khud_slide ID="GR_lke_slide1" rong="150" runat="server" loai="X" gridId="GR_lke"
                                            ham="tl_khenthuong_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <div style="padding-top: 20px">
                                            <asp:Label ID="lbl1" Text="Thông tin quyết định khen thưởng" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                        </div>
                                        <hr width="100%" />
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc1" runat="server" CssClass="css_gchu">Ngày hiệu lực</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY4" runat="server" ten="ngày thanh toán" Width="160px" CssClass="css_form_c" kieu_luu="S" kt_xoa="X">  </Cthuvien:ngay>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Bbuoc3" runat="server" CssClass="css_gchu_c" Width="110px">Ngày hết hiệu lực</Cthuvien:bbuoc>
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY5" runat="server" ten="ngày thanh toán" Width="160px" CssClass="css_form_c" kieu_luu="S" kt_xoa="X">  </Cthuvien:ngay>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc4" runat="server" CssClass="css_gchu">Số quyết định</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="CDANH" ten="chức danh" runat="server" CssClass="css_form" kieu_chu="True" 
                                                                    kt_xoa="X" Width="186px" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Bbuoc5" runat="server" CssClass="css_gchu_c" Width="110px">Người ký</Cthuvien:bbuoc>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="PHONG" ten="phòng ban" runat="server" CssClass="css_form" kieu_chu="True" 
                                                                    kt_xoa="X" Width="186px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc6" runat="server" CssClass="css_gchu">Chức danh</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="Ma5" runat="server" CssClass="css_form" BackColor="#f6f7f7" kieu_chu="true"
                                                                    Width="186px" f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" gchu="gchu" ten="Số thẻ cán bộ"
                                                                    onchange="tl_khenthuong_P_KTRA('SO_THE')" ktra="ns_cb,so_the,ten,cdanh,phong" placeholder="Nhấn (F1)" />

                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Bbuoc7" runat="server" CssClass="css_gchu_c" Width="110px">Ngày ban hành</Cthuvien:bbuoc>
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY6" runat="server" ten="ngày thanh toán" Width="160px" CssClass="css_form_c" kieu_luu="S" kt_xoa="X">  </Cthuvien:ngay>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc8" runat="server" CssClass="css_gchu">Trạng thái</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="trangthai" ten="Trạng thái" runat="server" DataTextField="ten" DataValueField="ma"
                                                                    CssClass="css_form" kieu="S" Width="186px">
                                                                    <asp:ListItem Selected="True" Text="Áp dụng" Value="A"></asp:ListItem>
                                                                    <asp:ListItem Text="Ngừng áp dụng" Value="N"></asp:ListItem>
                                                                </Cthuvien:DR_nhap>
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="padding-top: 20px">
                                            <asp:Label ID="Label1" Text="Thông tin khen thưởng" runat="server" Font-Bold="true" Width="100%"></asp:Label>
                                        </div>
                                        <hr width="100%" />
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc11" runat="server" CssClass="css_gchu">Đối tượng khen thưởng</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="DR_nhap3" ten="kỳ lương" runat="server" DataTextField="ten" DataValueField="so_id"
                                                                    CssClass="css_form_c" kieu="S" Width="136px">
                                                                    <asp:ListItem Selected="True" Text="Cá nhân" Value="C"></asp:ListItem>
                                                                    <asp:ListItem Text="Tập thể" Value="T"></asp:ListItem>
                                                                </Cthuvien:DR_nhap>
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Bbuoc13" runat="server" CssClass="css_gchu_c" Width="110px">Mã nhân viên</Cthuvien:bbuoc>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="Ma2" ten="tên nhân viên" runat="server" Enabled="false" CssClass="css_form" kieu_unicode="True"
                                                                    kt_xoa="X" Width="184px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc14" runat="server" CssClass="css_gchu">Họ tên</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="Ma3" ten="chức danh" runat="server" CssClass="css_form" kieu_chu="True" Enabled="false"
                                                                    kt_xoa="X" Width="136px" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Bbuoc15" runat="server" CssClass="css_gchu_c" Width="110px">Chức danh</Cthuvien:bbuoc>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="Ma4" ten="phòng ban" runat="server" CssClass="css_form" kieu_chu="True" Enabled="false"
                                                                    kt_xoa="X" Width="184px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc16" runat="server" CssClass="css_gchu">Đơn vị</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="Ma1" ten="chức danh" runat="server" CssClass="css_form" kieu_chu="True" Enabled="false"
                                                                    kt_xoa="X" Width="136px" />

                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Bbuoc17" runat="server" CssClass="css_gchu_c" Width="110px">Bộ phận</Cthuvien:bbuoc>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:so ID="So1" ten="tiên lương" runat="server" ReadOnly="true" Enabled="false" CssClass="css_form_r" kieu_chu="True"
                                                                    kt_xoa="X" Width="184px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc18" runat="server" CssClass="css_gchu">Cấp khen thưởng</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="DR_nhap1" ten="kỳ lương" runat="server" DataTextField="ten" DataValueField="so_id"
                                                                    CssClass="css_form_c" kieu="S" Width="136px" onchange="tl_khenthuong_load_luong()" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Bbuoc19" runat="server" CssClass="css_gchu_c" Width="110px">Số tiền</Cthuvien:bbuoc>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:so ID="So2" ten="tiên lương" runat="server" ReadOnly="true" Enabled="false" CssClass="css_form_r" kieu_chu="True"
                                                                    kt_xoa="X" Width="184px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc2" runat="server" CssClass="css_gchu">Hình thức khen thưởng</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="DR_nhap4" ten="kỳ lương" runat="server" DataTextField="ten" DataValueField="so_id"
                                                                    CssClass="css_form_c" kieu="S" Width="136px" onchange="tl_khenthuong_load_luong()" />
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="css_gchu">Lý do khen thưởng</asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <Cthuvien:nd ID="Nd1" ten="Ghi chú" runat="server" TextMode="MultiLine" Rows="3" CssClass="css_form" kieu_unicode="True" kt_xoa="X"
                                                        Height="50px" Width="443px"></Cthuvien:nd>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Bbuoc20" runat="server" CssClass="css_gchu">Có cộng vào lương</Cthuvien:bbuoc>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:kieu ID="chiuthue" runat="server" CssClass="css_form_c" Width="40px" ten="ten_kieu"
                                                                    Text="C" lke="C,K" ToolTip="C-Có, K-Không" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Bbuoc21" runat="server" CssClass="css_gchu_c">Năm</Cthuvien:bbuoc>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:so ID="So3" ten="tiên lương" runat="server" ReadOnly="true" Enabled="false" CssClass="css_form_r" kieu_chu="True"
                                                                    kt_xoa="X" Width="125px" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:bbuoc ID="Bbuoc9" runat="server" CssClass="css_gchu_c">Kỳ lương</Cthuvien:bbuoc>
                                                            </td>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="DR_nhap2" ten="kỳ lương" runat="server" DataTextField="ten" DataValueField="so_id"
                                                                    CssClass="css_form_c" kieu="S" Width="169px" onchange="tl_khenthuong_load_luong()" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-left: 40px; padding-top: 5px;">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1" class="tableButton">
                                            <tr>
                                                <td align="right">
                                                    <div class="box3 txRight2">
                                                        <a href="#" onclick="return tl_khenthuong_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return tl_khenthuong_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return tl_khenthuong_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return tl_khenthuong_P_IN();form_P_LOI();" class="bt bt-grey"><i class="fa fa-excel"></i><span class="txUnderline">X</span>uất excel</a>
                                                    </div>
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="Nhap2" runat="server" Width="100px" Text="Xuất excel" OnServerClick="nhap_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>

                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <Cthuvien:an ID="kthuoc" runat="server" Value="1270,700" />
    </table>
</asp:Content>
