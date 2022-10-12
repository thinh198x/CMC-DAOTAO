<%@ Page Title="ns_td_hsuv_online" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_hsuv_online.aspx.cs" Inherits="f_ns_td_hsuv_online" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center" >
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Hồ sơ ứng viên " />
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
                        <td align="left">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:bbuoc ID="Label3" runat="server" Text="Vị trí ứng tuyển" Width="137px" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <Cthuvien:DR_nhap ID="CDANH" runat="server" Width="250px" onchange="ns_td_hsuv_online_P_KTRA('CDANH')" CssClass="css_form" kt_xoa="G" DataTextField="ten" DataValueField="ma">
                                                                </Cthuvien:DR_nhap>
                                                            </td>
                                                            <td align="left" style="display: none">
                                                                <Cthuvien:ma ID="dot" runat="server" Width="250px" CssClass="css_drop" kt_xoa="K" Text="1" />

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
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_tt" runat="server" CssClass="css_tab_ngang_ac" Width="150px"
                                                                    Height="20px" Text="Thông tin chung" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_td" runat="server" CssClass="css_tab_ngang_de" Width="150px"
                                                                    Height="20px" Text="Trình độ" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_hdct" runat="server" CssClass="css_tab_ngang_de" Width="150px"
                                                                    Height="20px" Text="Hoạt động công tác" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_tc" runat="server" CssClass="css_tab_ngang_de" Width="150px"
                                                                    Height="20px" Text="Thông tin khác" />
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    <asp:Panel ID="Pa_tt" runat="server" Style="width: 650px;">
                                                        <table id="id_tt" runat="server" cellpadding="1" cellspacing="1" class="form_right">
                                                            <tr>
                                                                <td>
                                                                    <table runat="server" cellpadding="1" cellspacing="1">
                                                                        <tr>
                                                                            <td class="css_border" style="display: none; width: 110px; height: 146px">
                                                                                <img id="iurl" runat="Server" alt=" ảnh thẻ" title="Anh the" src="~/images/no_image.png" style="width: 110px; height: 146px" />
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <table id="Upa_tt" runat="server" cellpadding="1" cellspacing="1">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <Cthuvien:bbuoc ID="Label14" runat="server" Text="Số CMT" Width="160px" CssClass="css_gchu" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <table cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <Cthuvien:ma ID="CMT" runat="server" kt_xoa="G" onchange="ns_td_hsuv_online_P_KTRA('cmt');" CssClass="css_form" ten="Số CMT"
                                                                                                            ToolTip="Số chứng minh thư" Width="210px" MaxLength="13" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label8" runat="server" Text="Họ tên khai sinh" Width="160px" CssClass="css_gchu_c" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <Cthuvien:ma ID="ten" runat="server" kt_xoa="X" CssClass="css_form" ten="Họ tên khai sinh"
                                                                                                            ToolTip="Họ tên khai sinh" Width="210px" kieu_unicode="true" MaxLength="50" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label9" runat="server" Text="Giới tính" Width="160px" CssClass="css_gchu" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <table cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <Cthuvien:DR_nhap ID="gtinh" runat="server" kt_xoa="X" CssClass="css_form" ten="Giới tính"
                                                                                                            ToolTip="Giới tính" Width="210px">
                                                                                                            <asp:ListItem Value="NAM" Text="Nam" />
                                                                                                            <asp:ListItem Value="NU" Text="Nữ" />
                                                                                                        </Cthuvien:DR_nhap>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label18" runat="server" Text="Tình trạng hôn nhân" Width="160px" CssClass="css_gchu_c" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <Cthuvien:DR_nhap ID="honnhan" runat="server" kt_xoa="X" CssClass="css_form" ten="Giới tính"
                                                                                                            ToolTip="Tình trạng hôn nhân" Width="210px">
                                                                                                            <asp:ListItem Value="DT" Text="Độc thân" />
                                                                                                            <asp:ListItem Value="GD" Text="Đã có gia đinh" />
                                                                                                        </Cthuvien:DR_nhap>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label11" runat="server" Text="Ngày sinh" Width="160px" CssClass="css_gchu" Height="16px" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <table cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <div class="ip-group date">
                                                                                                            <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                                            <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="nsinh" runat="server" kt_xoa="X" CssClass="css_form_c" ten="Ngày sinh"
                                                                                                                ToolTip="Ngày sinh" Width="184px" />
                                                                                                            </div>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label12" runat="server" Text="Nơi sinh" Width="160px" CssClass="css_gchu_c" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <Cthuvien:ma ID="noisinh" runat="server" kt_xoa="X" CssClass="css_form" ten="Nơi sinh"
                                                                                                            ToolTip="Nơi sinh" Width="210px" kieu_unicode="true" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label13" runat="server" Text="Quê quán" Width="160px" CssClass="css_gchu" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <table cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <Cthuvien:ma ID="quequan" runat="server" kt_xoa="X" CssClass="css_form" ten="Quê quán"
                                                                                                            ToolTip="Quê quán" Width="210px" kieu_unicode="true" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label5" runat="server" Text="Quốc tịch" Width="160px" CssClass="css_gchu_c" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <Cthuvien:ma ID="quoctich" runat="server" kt_xoa="X" CssClass="css_form" ten="Quê quán"
                                                                                                            ToolTip="Quê quán" Width="210px" kieu_unicode="true" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label16" runat="server" Text="Dân tộc" Width="160px" CssClass="css_gchu" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <table cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <Cthuvien:ma ID="dantoc" runat="server" kt_xoa="X" CssClass="css_form" ten="Dân tộc"
                                                                                                            ToolTip="Dân tộc" Width="210px" kieu_unicode="true" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label17" runat="server" Text="Tôn giáo" Width="160px" CssClass="css_gchu_c" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <Cthuvien:ma ID="tongiao" runat="server" kt_xoa="X" CssClass="css_form" ten="Tôn giáo"
                                                                                                            ToolTip="Tôn giáo" Width="210px" kieu_unicode="true" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label6" runat="server" Text="Điện thoại liên hệ" Width="160px" CssClass="css_gchu" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <table cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <Cthuvien:ma ID="dtlienhe" runat="server" kt_xoa="X" CssClass="css_form" kieu_so="true" ten="Số điện thoại"
                                                                                                            ToolTip="Số điện thoại" Width="210px" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="Label7" runat="server" Text="Email" Width="160px" CssClass="css_gchu_c" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <Cthuvien:ma ID="email" runat="server" kt_xoa="X" CssClass="css_form" ten="Địa chỉ email"
                                                                                                            ToolTip="Địa chỉ email" Width="210px" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label10" runat="server" Text="Địa chỉ thường trú" Width="160px" CssClass="css_gchu" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <Cthuvien:ma ID="dcthuongtru" runat="server" kt_xoa="X" CssClass="css_form" ten="Nơi ở"
                                                                                                ToolTip="Nơi ở" Width="592px" kieu_unicode="true" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label15" runat="server" Text="Nơi ở hiện nay" Width="160px" CssClass="css_gchu" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <Cthuvien:ma ID="noiohiennay" runat="server" kt_xoa="X" CssClass="css_form" ten="Nơi ở"
                                                                                                ToolTip="Nơi ở" Width="592px" kieu_unicode="true" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="display: none">
                                                                                        <td>
                                                                                            <asp:Label ID="Label20" runat="server" Text="Blacklist" Width="160px" CssClass="css_gchu" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <Cthuvien:kieu Width="60px" ID="is_blacklist" runat="server" Text="K" lke="C,K" ToolTip="K - Không, C - Có" CssClass="css_ma_c" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" colspan="2">
                                                                                            <asp:Label ID="Label1" runat="server" Text="Quan hệ thân nhân" Font-Italic="true" Font-Bold="true" ForeColor="Red" />
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
                                                                    <Cthuvien:GridX ID="GR_gd" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                        CssClass="table gridX" loai="N" cot="ten,qhe,gtinh,nsinh,nghenghiep,gchu" hangKt="13" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                            <asp:TemplateField HeaderText="Họ tên" HeaderStyle-Width="180px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="ten" runat="server" Width="180px" kieu_unicode="true" CssClass="css_Gma" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Quan hệ" HeaderStyle-Width="60px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="qhe" runat="server" kieu_unicode="true" Width="60px" CssClass="css_Gma" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Giới tính" HeaderStyle-Width="60px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="gtinh" kieu_unicode="true" runat="server" Width="60px" CssClass="css_Gma" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Năm sinh" HeaderStyle-Width="50px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="nsinh" kieu_so="true" runat="server" Width="50px" CssClass="css_Gma" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Nghề nghiệp, chức danh, chức vụ, đơn vị, công tác, học tập"
                                                                                HeaderStyle-Width="230px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="nghenghiep" runat="server" Width="230px" kieu_unicode="true" CssClass="css_Gma" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="ghi chú" HeaderStyle-Width="150px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="gchu" runat="server" Width="150px" kieu_unicode="true" CssClass="css_Gma" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </Cthuvien:GridX>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pa_td" runat="server" Style="width: 650px; display: none;">
                                                        <table cellpadding="0" cellspacing="0" class="form_right">
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    <table id="Upa_td" cellpadding="1" cellspacing="1">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label46" runat="server" Text="Giáo dục phổ thông" Width="160px" CssClass="css_gchu" />
                                                                            </td>
                                                                            <td>
                                                                                <table cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <Cthuvien:ma ID="gdphothong" runat="server" kt_xoa="X" CssClass="css_form" ten="Giáo dục phổ thông"
                                                                                                ToolTip="Giáo dục phổ thông" Width="210px" kieu_unicode="true" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label47" runat="server" Text="Học hàm/học vị cao nhất" Width="160px" CssClass="css_gchu_c" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <Cthuvien:ma ID="hocham" runat="server" kt_xoa="X" CssClass="css_form" ten="Học hàm/ Học vị" kieu_unicode="true"
                                                                                                ToolTip="Học hàm/ Học vị" Width="210px" />
                                                                                        </td>

                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label49" runat="server" Text="Ngoại ngữ" Width="160px" CssClass="css_gchu" />
                                                                            </td>
                                                                            <td>
                                                                                <table cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <Cthuvien:ma ID="ngoaingu" runat="server" kt_xoa="X" CssClass="css_form" ten="Ngoại ngữ"
                                                                                                ToolTip="Ngoại ngữ" Width="210px" kieu_unicode="true" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label2" runat="server" Text="Tin học" Width="160px" CssClass="css_gchu_c" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <Cthuvien:ma ID="tinhoc" runat="server" kt_xoa="X" CssClass="css_form" ten="Ngoại ngữ"
                                                                                                ToolTip="Ngoại ngữ" Width="210px" kieu_unicode="true" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label19" runat="server" Text="Các kỹ năng khác" Width="160px" CssClass="css_gchu" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:nd ID="kynang" runat="server" kt_xoa="X" CssClass="css_form" ten="Kỹ năng khác"
                                                                                    ToolTip="Kỹ năng khác" Width="592px" kieu_unicode="true" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2">
                                                                    <asp:Label ID="Label4" runat="server" Text="Thông tin chi tiết" Font-Italic="true" Font-Bold="true" ForeColor="Red" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <Cthuvien:GridX ID="GR_td" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                        CssClass="table gridX" loai="N" cot="tentruong,nganh,thoigian,hinhthuc,vanbang" hangKt="18" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                            <asp:TemplateField HeaderText="Tên trường" HeaderStyle-Width="150px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="tentruong" kieu_unicode="true" runat="server" Width="150px" CssClass="css_Gma" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Ngành học hoặc tên lớp" HeaderStyle-Width="206px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="nganh" runat="server" Width="206px" kieu_unicode="true" CssClass="css_Gma" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="thời gian học" HeaderStyle-Width="126px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="thoigian" runat="server" Width="126px" kieu_unicode="true" CssClass="css_Gma" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Hình thức học" HeaderStyle-Width="126px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="hinhthuc" runat="server" Width="126px" kieu_unicode="true" CssClass="css_Gma" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="văn bằng chứng chỉ, trình độ gì" HeaderStyle-Width="126px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="vanbang" runat="server" Width="126px" kieu_unicode="true" CssClass="css_Gma" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </Cthuvien:GridX>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pa_hdct" runat="server" Style="width: 650px; display: none;">
                                                        <table cellpadding="0" cellspacing="0">

                                                            <tr>
                                                                <td>
                                                                    <Cthuvien:GridX ID="GR_hdct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                        CssClass="table gridX" loai="N" cot="tuthang,toithang,congty,congviec,lydonghi" hangKt="23" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                            <asp:TemplateField HeaderText="Từ tháng" HeaderStyle-Width="100px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:thang  placeholder='MM/yyyy' ID="tuthang" runat="server" Width="100px" CssClass="css_Gma_c" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Đến tháng" HeaderStyle-Width="100px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:thang  placeholder='MM/yyyy' ID="toithang" runat="server" Width="100px" CssClass="css_Gma_c" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Công ty" HeaderStyle-Width="174px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="congty" runat="server" Width="174px" kieu_unicode="true" CssClass="css_Gma" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Công việc đã làm" HeaderStyle-Width="180px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="congviec" runat="server" Width="180px" kieu_unicode="true" CssClass="css_Gma" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Lý do nghỉ" HeaderStyle-Width="180px">
                                                                                <ItemTemplate>
                                                                                    <Cthuvien:ma ID="lydonghi" runat="server" Width="180px" kieu_unicode="true" CssClass="css_Gma" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </Cthuvien:GridX>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pa_tc" runat="server" Style="width: 650px; display: none;">
                                                        <table cellpadding="0" cellspacing="0" class="form_right">
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    <table id="Upa_ttk" cellpadding="1" cellspacing="1">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label30" runat="server" Text="Mức lương mong muốn" Width="160px" CssClass="css_gchu" />
                                                                            </td>
                                                                            <td>

                                                                                <Cthuvien:so ID="luongmuon" runat="server" kt_xoa="X" CssClass=" css_form_r" ten="Ngày tham gia cách mạng"
                                                                                    ToolTip="Mức lương mong muốn" Width="210px" />

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label31" runat="server" Text="Mong muốn về công việc" Width="160px" CssClass="css_gchu" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:nd ID="cvmuon" runat="server" kt_xoa="X" kieu_unicode="true" CssClass="css_form" ten="Công việc mong muốn"
                                                                                    ToolTip="Công việc mong muốn" Width="590px" TextMode="MultiLine" Rows="7" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label33" runat="server" Text="Điểm mạnh" Width="160px" CssClass="css_gchu" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:nd ID="diemmanh" runat="server" kt_xoa="X" CssClass="css_form" kieu_unicode="true" ten="Điểm mạnh"
                                                                                    ToolTip="Điểm mạnh" Width="590px" TextMode="MultiLine" Rows="7" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label32" runat="server" Text="Điểm yếu" Width="160px" CssClass="css_gchu" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:nd ID="diemyeu" runat="server" kt_xoa="X" CssClass="css_form" kieu_unicode="true" ten="Điểm yếu"
                                                                                    ToolTip="Điểm yếu" Width="590px" TextMode="MultiLine" Rows="7" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label34" runat="server" Text="Nguồn thẩm tra" Width="160px" CssClass="css_gchu" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:nd ID="nguonthamtra" runat="server" kt_xoa="X" Rows="7" CssClass="css_form" kieu_unicode="true" ten="Ngày vào đảng"
                                                                                    ToolTip="Nguồn thẩm tra" Width="590px" />

                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" style="padding-top: 15px">
                                        <div class="box3  txCenter">
                                            <a href="#" onclick="return ns_td_hsuv_online_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                            <a href="#" class="bt bt-grey" onclick="return ns_td_hsuv_online_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                        </div>
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
        <Cthuvien:an ID="so_id" runat="server" Value="0" />
        <Cthuvien:an ID="fileanh" runat="server" value="0" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="852,900" />
    </div>
</asp:Content>
