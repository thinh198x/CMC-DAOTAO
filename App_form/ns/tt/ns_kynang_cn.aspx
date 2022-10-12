<%@ Page Title="ns_kynang_cn" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_kynang_cn.aspx.cs" Inherits="f_ns_kynang_cn" %>

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
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Kỹ năng cá nhân" />
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
                            <table runat="server" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left" class="form_right">
                                        <table cellspacing="0" id="UPa_ct">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" Text="Mã số CB" CssClass="css_gchu" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:ma ID="SO_THE" ten="Mã cán bộ" MaxLength="30" runat="server" CssClass="css_form" BackColor="#f6f7f7"
                                                                    ktra="ns_cb,so_the,ten" ToolTip="Mã số cán bộ" kieu_chu="true" Width="120px" placeholder="Nhấn (F1)"
                                                                    f_tkhao="~/App_form/ns/tt/ns_cb_chon.aspx" onchange="ns_kynang_cn_P_KTRA('so_the')" gchu="gchu" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="Ngày nhập" CssClass="css_gchu_c" Width="100px" />
                                                            </td>
                                                            <td>
                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayd" MaxLength="10" runat="server" kt_xoa="X" ten="Ngày nhập" CssClass="css_form_c" kieu_luu="S" Width="110px" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Ghi chú" CssClass="css_gchu" Width="60px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nd ID="ghichu" ten="Ghi chú" runat="server" MaxLength="250" kt_xoa="X" CssClass="css_form" Width="367px" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="N" cot="ma,ten,kinhnghiem,noidung" hangKt="9" gchuId="gchu" hamUp="ns_kynang_cn_Update">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:TemplateField HeaderText="Mã kỹ năng" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="ma" runat="server" Width="100px" CssClass="css_Gma"
                                                                        f_tkhao="~/App_form/ns/ma/ns_ma_kynang.aspx" MaxLength="10" ktra="ns_ma_kynang,ma,ten" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Tên kỹ năng" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                                            <asp:TemplateField HeaderText="Kinh nghiệm" HeaderStyle-Width="250px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="kinhnghiem" MaxLength="200" runat="server" Width="250px" CssClass="css_Gma" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Nội dung" HeaderStyle-Width="300px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:ma ID="noidung" MaxLength="250" runat="server" Width="300px" CssClass="css_Gma" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="Table1">
                                            <tr>
                                                <td>
                                                    <div class="box3 txRight2">
                                                        <a href="#" onclick="return ns_kynang_cn_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_kynang_cn_P_MOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_kynang_cn_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>

                                                    </div>
                                                </td>

                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height: 20px;">
                                                    <img id="Img3" runat="server" alt="" src="~/images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ns_kynang_cn_HangLen();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img id="Img4" runat="server" alt="" src="~/images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ns_kynang_cn_HangXuong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img id="Img5" runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_kynang_cn_CatDong();" />
                                                </td>
                                                <td style="border: gray 1px solid; width: 20px; height: 20px;" align="center" valign="middle">
                                                    <img id="Img6" runat="server" alt="" src="~/images/bitmaps/chen.gif" title="Chèn dòng" onclick="return ns_kynang_cn_ChenDong('C');" />
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
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="900,580" />
    </div>
</asp:Content>
