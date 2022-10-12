<%@ Page Title="ti_thaydoi_tt" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ti_thaydoi_tt.aspx.cs" Inherits="f_ti_thaydoi_tt" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Cập nhập thông tin cá nhân" />
                        </td>
                        <td align="right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="center" style="width: 50px;">
                                        <img id="Anh3" runat="server" alt="" src="~/images/nen/ke_va_ca.jpg" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img1" runat="server" alt="" src="~/images/icon/help.png" title="hướng dẫn sử dụng" onclick="return form_HELP();" />
                                    </td>
                                    <td style="padding-right: 10px;" class="css_lket_dat">
                                        <img id="Img2" runat="server" alt="" src="~/images/icon/gop.png" title="Góp ý" onclick="return form_GOP();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
        <tr>
            <td valign="middle">
                <table border="0" cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <table id="UPa_ct" runat="server" cellspacing="0">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label3" runat="server" Text="Mã CB" Width="50px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:ma ID="SO_THE" runat="server" Width="117px" CssClass="css_tong" kt_xoa="K" ReadOnly="true" disabled="true" />
                                                </td>
                                                <td align="right">
                                                    <Cthuvien:luu ID="status" runat="server" Text="" ForeColor="Red" Font-Bold="true" Font-Italic="true" />
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
                                                    <Cthuvien:tab ID="NPa_gd" runat="server" CssClass="css_tab_ngang_de" Width="150px"
                                                        Height="20px" Text="Gia đình" />
                                                </td>

                                                <td>
                                                    <Cthuvien:tab ID="NPa_hdct" runat="server" CssClass="css_tab_ngang_de" Width="150px"
                                                        Height="20px" Text="Hoạt động công tác" />
                                                </td>

                                                <td>
                                                    <Cthuvien:tab ID="NPa_tc" runat="server" CssClass="css_tab_ngang_de" Width="150px"
                                                        Height="20px" Text="Hoạt động tổ chức" />
                                                </td>

                                                <td>
                                                    <Cthuvien:tab ID="NPa_td" runat="server" CssClass="css_tab_ngang_de" Width="150px"
                                                        Height="20px" Text="Trình độ" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" class="tab_content">
                                        <asp:Panel ID="Pa_tt" runat="server" Style="width: 680px; height: 300px; display: block;">
                                            <table id="id_tt" runat="server" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label8" runat="server" Text="Họ tên khai sinh" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="htks" runat="server" kt_xoa="X" CssClass="css_ma" ten="Họ tên khai sinh"
                                                                                    ToolTip="Họ tên khai sinh" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label9" runat="server" Text="Giới tính" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:DR_nhap ID="gtinh" runat="server" kt_xoa="X" CssClass="css_drop" ten="Giới tính"
                                                                                    ToolTip="Họ tên khai sinh" Width="216px">
                                                                                    <asp:ListItem Value="NAM" Text="Nam" />
                                                                                    <asp:ListItem Value="NU" Text="Nữ" />
                                                                                </Cthuvien:DR_nhap>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label10" runat="server" Text="Tên gọi khác" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="tenkhac" runat="server" kt_xoa="X" CssClass="css_ma" ten="Tên gọi khác"
                                                                                    ToolTip="Tên gọi khác" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label11" runat="server" Text="Ngày sinh" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="nsinh" runat="server" kt_xoa="X" CssClass="css_ma_c" ten="Ngày sinh"
                                                                                    ToolTip="Ngày sinh" Width="210px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label12" runat="server" Text="Nơi sinh" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="noisinh" runat="server" kt_xoa="X" CssClass="css_ma" ten="Nơi sinh"
                                                                                    ToolTip="Nơi sinh" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label13" runat="server" Text="Quê quán" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="qquan" runat="server" kt_xoa="X" CssClass="css_ma" ten="Quê quán"
                                                                                    ToolTip="Quê quán" Width="210px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label14" runat="server" Text="Số CMT" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="cmt" runat="server" kt_xoa="X" CssClass="css_ma" ten="Số CMT"
                                                                                    ToolTip="Số chứng minh thư" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label15" runat="server" Text="Nơi ở hiện nay" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="noio" runat="server" kt_xoa="X" CssClass="css_ma" ten="Nơi ở"
                                                                                    ToolTip="Nơi ở" Width="210px" />
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
                                                                                <Cthuvien:ma ID="dtoc" runat="server" kt_xoa="X" CssClass="css_ma" ten="Dân tộc"
                                                                                    ToolTip="Dân tộc" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label17" runat="server" Text="Tôn giáo" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="tongiao" runat="server" kt_xoa="X" CssClass="css_ma" ten="Tôn giáo"
                                                                                    ToolTip="Tôn giáo" Width="210px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label18" runat="server" Text="Tình trạng sức khỏe" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="skhoe" runat="server" kt_xoa="X" CssClass="css_ma" ten="Tình trạng sức khỏe"
                                                                                    ToolTip="Tình trạng sức khỏe" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label19" runat="server" Text="Chiều cao" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="cao" runat="server" kt_xoa="X" CssClass="css_ma" ten="Chiều cao"
                                                                                    ToolTip="Chiều cao" Width="210px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label20" runat="server" Text="Cân nặng" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="can" runat="server" kt_xoa="X" CssClass="css_ma" ten="Cân nặng"
                                                                                    ToolTip="Cân nặng" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label21" runat="server" Text="Nhóm máu" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="nhommau" runat="server" kt_xoa="X" CssClass="css_ma" ten="Nhóm máu"
                                                                                    ToolTip="Nhóm máu" Width="210px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>

                                        <asp:Panel ID="Pa_gd" runat="server" Style="width: 680px; height: 300px; display: none;">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label51" runat="server" Text="Thu nhập chính" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="thunhap_chinh" runat="server" kt_xoa="X" CssClass="css_ma" ten="Thu nhập chính"
                                                                                    ToolTip="Thu nhập chính" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label52" runat="server" Text="Các nguồn thu nhập khác" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="thunhap_khac" runat="server" kt_xoa="X" CssClass="css_ma" ten="Thu nhập khác"
                                                                                    ToolTip="Thu nhập khác" Width="210px" />
                                                                            </td>

                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label54" runat="server" Text="Loại nhà đc cấp,thuê" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="loainha_cap" runat="server" kt_xoa="X" CssClass="css_ma" ten="Loại nhà được cấp"
                                                                                    ToolTip="Loại nhà được cấp" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label55" runat="server" Text="Diện tích (m2)" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="dientich_nhacap" runat="server" kt_xoa="X" CssClass="css_ma" ten="Diện tích nhà cấp"
                                                                                    ToolTip="Diện tích nhà được cấp" Width="210px" />
                                                                            </td>

                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label57" runat="server" Text="Loại nhà tự mua,xây" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="loainha_mua" runat="server" kt_xoa="X" CssClass="css_ma" ten="Loại nhà mua"
                                                                                    ToolTip="Loại nhà được mua" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label58" runat="server" Text="Diện tích (m2)" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="dientich_mua" runat="server" kt_xoa="X" CssClass="css_ma" ten="Diện tích nhà mua"
                                                                                    ToolTip="Diện tích nhà mua" Width="210px" />
                                                                            </td>

                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label60" runat="server" Text="Đất được cấp" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="dat_cap" runat="server" kt_xoa="X" CssClass="css_ma" ten="Đất được cấp"
                                                                                    ToolTip="Đất được cấp" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label61" runat="server" Text="Diện tích (m2)" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="dientich_datcap" runat="server" kt_xoa="X" CssClass="css_ma" ten="Diện tích đất cấp"
                                                                                    ToolTip="Diện tích đất cấp" Width="210px" />
                                                                            </td>


                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        <asp:Label ID="Label1" runat="server" Text="Quan hệ thân nhân" Font-Italic="true" Font-Bold="true" ForeColor="Red" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <Cthuvien:GridX ID="GR_gd" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" cot="so_the,congviec,nsinhqh,thongtin" hangKt="6" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:TemplateField HeaderText="Gia đình" HeaderStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="giadinh" kieu_chu="true" runat="server" Width="100px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Quan hệ" HeaderStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="lqhe" kieu_chu="true" runat="server" Width="50px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Họ tên" HeaderStyle-Width="130px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="ten" runat="server" Width="130px" kieu_unicode="true" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Năm sinh" HeaderStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="tuoi" kieu_so="true" runat="server" Width="50px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Nghề nghiệp, chức danh, chức vụ, đơn vị, công tác, học tập"
                                                                    HeaderStyle-Width="250px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="thongtin" runat="server" Width="250px" kieu_unicode="true" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ghi chú" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="note" runat="server" Width="150px" kieu_unicode="true" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td>
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                                                    <img alt="" src="../../images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ti_thaydoi_tt_HangLen('GD');" />
                                                                </td>
                                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                                    <img alt="" src="../../images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ti_thaydoi_tt_HangXuong('GD');" />
                                                                </td>
                                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                                    <img alt="" src="../../images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ti_thaydoi_tt_CatDong('GD');" />
                                                                </td>
                                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                                    <img alt="" src="../../images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ti_thaydoi_tt_ChenDong('C','GD');" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>

                                                </tr>
                                            </table>
                                        </asp:Panel>

                                        <asp:Panel ID="Pa_hdct" runat="server" Style="width: 650px; height: 300px; display: none;">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label22" runat="server" Text="Nghề nghiệp trước tuyển dụng" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="nghe" runat="server" kt_xoa="X" CssClass="css_ma" ten="Nghề nghiệp trước tuyển dụng"
                                                                                    ToolTip="Nghề nghiệp trước tuyển dụng" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label23" runat="server" Text="Ngày tuyển dụng" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngaytd" runat="server" kt_xoa="X" CssClass="css_ma_c" ten="Ngày tuyển dụng"
                                                                                    ToolTip="Ngày tuyển dụng" Width="210px" />
                                                                            </td>


                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label36" runat="server" Text="Vào cơ quan nào,ở đâu" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="coquan" runat="server" kt_xoa="X" CssClass="css_ma" ten="Vào cơ quan nào, ở đâu"
                                                                                    ToolTip="Vào cơ quan nào, ở đâu" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label24" runat="server" Text="Ngày vào cơ quan hiện tại" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayvao" runat="server" kt_xoa="X" CssClass="css_ma_c" ten="Ngày vào cơ quan hiện tại"
                                                                                    ToolTip="Ngày vào cơ quan hiện tại" Width="210px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label25" runat="server" Text="Chức vụ" Width="160px" CssClass="css_gchu" />
                                                                </td>

                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="cvu" runat="server" kt_xoa="X" CssClass="css_ma" ten="Chức vụ"
                                                                                    ToolTip="Họ tên khai sinh" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label37" runat="server" Text="Hệ số chức vụ" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="hsocvu" runat="server" kt_xoa="X" CssClass="css_ma" ten="Hệ số chức vụ"
                                                                                    ToolTip="Hệ số chức vụ" Width="210px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label26" runat="server" Text="Công tác chính đang làm" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="ctacchinh" runat="server" kt_xoa="X" CssClass="css_ma" ten="Công tác chính đang làm"
                                                                                    ToolTip="Công tác chính đang làm" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label27" runat="server" Text="Ngạch công chức" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="ngach" runat="server" kt_xoa="X" CssClass="css_ma" ten="Ngạch công chức"
                                                                                    ToolTip="Ngạch công chức" Width="210px" />
                                                                            </td>


                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label38" runat="server" Text="Bậc lương" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="bac" runat="server" kt_xoa="X" CssClass="css_ma" ten="Bậc lương"
                                                                                    ToolTip="Bậc lương" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label28" runat="server" Text="Hệ số" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="hsol" runat="server" kt_xoa="X" CssClass="css_ma" ten="Hệ số lương"
                                                                                    ToolTip="Hệ số lương" Width="210px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label29" runat="server" Text="Từ tháng" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>


                                                                            <td>
                                                                                <Cthuvien:thang  placeholder='MM/yyyy' ID="thang" runat="server" kt_xoa="X" CssClass="css_ma" ten="Từ tháng"
                                                                                    ToolTip="Từ tháng" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label39" runat="server" Text="Sở trường công tác" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="sotruong" runat="server" kt_xoa="X" CssClass="css_ma" ten="Sở trường công tác"
                                                                                    ToolTip="Sở trường công tác" Width="210px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        <asp:Label ID="Label2" runat="server" Text="Thông tin chi tiết" Font-Italic="true" Font-Bold="true" ForeColor="Red" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <Cthuvien:GridX ID="GR_hdct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" cot="tuthang,denthang,congviec" hangKt="4" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:TemplateField HeaderText="Từ tháng" HeaderStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:thang  placeholder='MM/yyyy' ID="tuthang" kieu_chu="true" runat="server" Width="100px" CssClass="css_Gma_c" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Đến tháng" HeaderStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:thang  placeholder='MM/yyyy' ID="denthang" kieu_chu="true" runat="server" Width="100px" CssClass="css_Gma_c" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Công việc đã làm" HeaderStyle-Width="540px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="congviec" runat="server" Width="540px" kieu_unicode="true" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                                                    <img alt="" src="../../images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ti_thaydoi_tt_HangLen('HDCT');" />
                                                                </td>
                                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                                    <img alt="" src="../../images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ti_thaydoi_tt_HangXuong('HDCT');" />
                                                                </td>
                                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                                    <img alt="" src="../../images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ti_thaydoi_tt_CatDong('HDCT');" />
                                                                </td>
                                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                                    <img alt="" src="../../images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ti_thaydoi_tt_ChenDong('C','HDCT');" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>

                                        <asp:Panel ID="Pa_tc" runat="server" Style="width: 650px; height: 300px; display: none;">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label30" runat="server" Text="Ngày tham gia cách mạng" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngaycachmang" runat="server" kt_xoa="X" CssClass="css_ma_c" ten="Ngày tham gia cách mạng"
                                                                                    ToolTip="Ngày tham gia cách mạng" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label31" runat="server" Text="Ngày nhập ngũ" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngaynhapngu" runat="server" kt_xoa="X" CssClass="css_ma_c" ten="Ngày nhập ngũ"
                                                                                    ToolTip="Ngày nhập ngũ" Width="210px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label32" runat="server" Text="Ngày xuất ngũ" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayxuatngu" runat="server" kt_xoa="X" CssClass="css_ma_c" ten="Ngày xuất ngũ"
                                                                                    ToolTip="Ngày xuất ngũ" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label33" runat="server" Text="Quân hàm, chức vụ cao nhất" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="quanham" runat="server" kt_xoa="X" CssClass="css_ma" ten="Quân hàm, chức vụ cao nhất"
                                                                                    ToolTip="Quân hàm, chức vụ cao nhất" Width="210px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label34" runat="server" Text="Ngày vào đảng" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngaydang" runat="server" kt_xoa="X" CssClass="css_ma_c" ten="Ngày vào đảng"
                                                                                    ToolTip="Ngày vào đảng" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label35" runat="server" Text="Ngày chính thức" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngaycthuc" runat="server" kt_xoa="X" CssClass="css_ma_c" ten="Ngày chính thức"
                                                                                    ToolTip="Ngày chính thức" Width="210px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label40" runat="server" Text="Cấp ủy hiện tại" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="capuy" runat="server" kt_xoa="X" CssClass="css_ma" ten="Cấp ủy hiện tại"
                                                                                    ToolTip="Cấp ủy hiện tại" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label41" runat="server" Text="Cấp ủy kiêm" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="uykiem" runat="server" kt_xoa="X" CssClass="css_ma" ten="Cấp ủy kiêm"
                                                                                    ToolTip="Cấp ủy kiêm nhiệm" Width="210px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label42" runat="server" Text="Khen thưởng" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="khen" runat="server" kt_xoa="X" CssClass="css_ma" ten="Khen thưởng"
                                                                                    ToolTip="Khen thưởng" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label43" runat="server" Text="Kỷ luật" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="kyluat" runat="server" kt_xoa="X" CssClass="css_ma" ten="Kỷ luật"
                                                                                    ToolTip="Kỷ luật" Width="210px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label44" runat="server" Text="Thương binh loại: " Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="thuongbinh" runat="server" kt_xoa="X" CssClass="css_ma" ten="Loại thương binh"
                                                                                    ToolTip="Loại thương binh" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label45" runat="server" Text="Gia đình liệt sĩ" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="giadinhlsi" runat="server" kt_xoa="X" CssClass="css_ma" ten="Thuộc gia đình liệt sĩ"
                                                                                    ToolTip="Thuộc gia đình liệt sĩ" Width="210px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>

                                        <asp:Panel ID="Pa_td" runat="server" Style="width: 650px; height: 300px; display: none;">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label46" runat="server" Text="Giáo dục phổ thông" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="gdpt" runat="server" kt_xoa="X" CssClass="css_ma" ten="Giáo dục phổ thông"
                                                                                    ToolTip="Giáo dục phổ thông" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label47" runat="server" Text="Học hàm/học vị cao nhất" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="hocham" runat="server" kt_xoa="X" CssClass="css_ma_c" ten="Học hàm/ Học vị"
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
                                                                                <Cthuvien:ma ID="ngoaingu" runat="server" kt_xoa="X" CssClass="css_ma" ten="Ngoại ngữ"
                                                                                    ToolTip="Ngoại ngữ" Width="210px" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label50" runat="server" Text="Danh hiệu được phong" Width="160px" CssClass="css_gchu_c" />
                                                                            </td>
                                                                            <td>
                                                                                <Cthuvien:ma ID="dhieu" runat="server" kt_xoa="X" CssClass="css_ma" ten="Danh hiệu được phong"
                                                                                    ToolTip="Danh hiệu được phong" Width="210px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label48" runat="server" Text="Lý luận chính trị" Width="160px" CssClass="css_gchu" />
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <Cthuvien:ma ID="llct" runat="server" kt_xoa="X" CssClass="css_ma" ten="Lý luận chính trị"
                                                                                    ToolTip="Lý luận chính trị" Width="210px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
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
                                                            CssClass="table gridX" loai="N" cot="tentruong,congviec,vitri,hinhthuc,heso" hangKt="7" gchuId="gchu" ctrT="so_tt" ctrS="nhap">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:TemplateField HeaderText="Tên trường" HeaderStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="tentruong" kieu_chu="true" runat="server" Width="150px" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Ngành học hoặc tên lớp" HeaderStyle-Width="230px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="congviec" runat="server" Width="230px" kieu_unicode="true" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="thời gian học" HeaderStyle-Width="120px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="vitri" runat="server" Width="120px" kieu_unicode="true" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Hình thức học" HeaderStyle-Width="120px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:ma ID="hinhthuc" runat="server" Width="120px" kieu_unicode="true" CssClass="css_Gma" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="văn bằng chứng chỉ, trình độ gì" HeaderStyle-Width="120px">
                                                                    <ItemTemplate>
                                                                        <Cthuvien:so ID="heso" runat="server" Width="120px" so_tp="2" CssClass="css_Gso" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                                                    <img alt="" src="../../images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ti_thaydoi_tt_HangLen('TD');" />
                                                                </td>
                                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                                    <img alt="" src="../../images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ti_thaydoi_tt_HangXuong('TD');" />
                                                                </td>
                                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                                    <img alt="" src="../../images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ti_thaydoi_tt_CatDong('TD');" />
                                                                </td>
                                                                <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                                    <img alt="" src="../../images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ti_thaydoi_tt_ChenDong('C','TD');" />
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
                        <td align="center">
                            <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ti_thaydoi_tt_P_NH();form_P_LOI();"
                                            Width="85px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Hủy" CssClass="css_button" OnClick="return ti_thaydoi_tt_P_XOA();form_P_LOI();"
                                            Width="85px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="pheduyet" runat="server" Text="Phê duyệt" CssClass="css_button" OnClick="return ti_thaydoi_tt_P_PD();form_P_LOI();"
                                            Width="85px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="kopheduyet" runat="server" Text="Ko phê duyệt" CssClass="css_button" OnClick="return ti_thaydoi_tt_P_KPD();form_P_LOI();"
                                            Width="85px" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="955,525" />
    </div>
</asp:Content>
