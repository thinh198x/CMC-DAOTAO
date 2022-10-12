<%@ Page Title="ns_danhsach" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_danhsach.aspx.cs" Inherits="f_ns_danhsach" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<%@ Register Src="~/App_ctr/khud/ctr_khud_ttt.ascx" TagName="khud_ttt" TagPrefix="khud_ttt" %>
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
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh sách cán bộ " />
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
                        <td align="left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <table id="Upa_tk" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label13" runat="server" Width="120px" Text="Tiêu chí thông tin" CssClass="css_link_nhom" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label20" runat="server" Width="60px" Text="Phòng" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="phong_tk" ten="Phòng" runat="server" DataTextField="ten" DataValueField="ma"
                                                                    CssClass="css_form" kieu="S" Width="350px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label26" runat="server" Width="60px" Text="Mã CB" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="so_the_tk" ten="Mã CB tìm kiếm" runat="server" kt_xoa="K" CssClass="css_form" kieu_chu="true" Width="200px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label25" runat="server" Width="60px" Text="Tên" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="ten_tk" ten="Tên tìm kiếm" runat="server" kt_xoa="K" CssClass="css_form" kieu_unicode="true" Width="200px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label1" runat="server" Width="60px" Text="Ngày vào" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <div class="ip-group date">
                                                                                <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayvaod" ten="Ngày vào từ" runat="server" CssClass="css_form_c" kieu="I" Width="104px" />
                                                                            </div>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label3" runat="server" Width="40px" Text="Đến" CssClass="css_gchu_c" />
                                                                        </td>
                                                                        <td>
                                                                            <div class="ip-group date">
                                                                                <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngayvaoc" ten="Ngày vào đến" runat="server" CssClass="css_form_c" kieu="I" Width="104px" />
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label4" runat="server" Width="60px" Text="Ngày sinh" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <div class="ip-group date">
                                                                                <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngaysinhd" ten="Ngày sinh từ" runat="server" CssClass="css_form_c" kieu="I" Width="104px" />
                                                                            </div>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label6" runat="server" Width="40px" Text="Đến" CssClass="css_gchu_c" />
                                                                        </td>
                                                                        <td>
                                                                            <div class="ip-group date">
                                                                                <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                                <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="ngaysinhc" ten="Ngày sinh đến" runat="server" CssClass="css_form_c" kieu="I" Width="104px" />
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label7" runat="server" Width="60px" Text="Giới tính" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="gioitinh" ten="giới tính" runat="server" CssClass="css_form" kieu="S" Width="108px">
                                                                    <asp:ListItem Text="Tất cả" Value="TATCA" />
                                                                    <asp:ListItem Text="Nam" Value="NAM" />
                                                                    <asp:ListItem Text="Nữ" Value="NU" />
                                                                </Cthuvien:DR_nhap>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label2" runat="server" Width="60px" Text="Địa chỉ" CssClass="css_gchu" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:ma ID="dchi" ten="Địa chỉ" runat="server" kt_xoa="K" CssClass="css_form" kieu_unicode="true" Width="210px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label8" runat="server" Width="90px" Text="Loại hợp đồng" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:DR_nhap ID="lhd" ten="Loại hợp đồng" runat="server" DataTextField="ten" DataValueField="ma"
                                                                                CssClass="css_form" kieu="S" Width="150px" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label9" runat="server" Width="90px" Text="Chức vụ" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:DR_nhap ID="cvu" ten="Chức vụ" runat="server" DataTextField="ten" DataValueField="ma"
                                                                                CssClass="css_form" kieu="S" Width="150px" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label10" runat="server" Width="100px" Text="Nhóm chức danh" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:DR_nhap ID="ncdanh" ten="Nhóm chức danh" runat="server" DataTextField="ten" DataValueField="ma"
                                                                                CssClass="css_form" kieu="S" Width="150px" onchange="ns_danhsach_P_NCDANH();" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label11" runat="server" Width="90px" Text="Chức danh" CssClass="css_gchu" />
                                                                        </td>
                                                                        <td>
                                                                            <Cthuvien:DR_nhap ID="cdanh" ten="Chức danh" runat="server" DataTextField="ten" DataValueField="ma"
                                                                                CssClass="css_form" kieu="S" Width="150px" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
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
                                                                <asp:Label ID="Label5" runat="server" Width="120px" Text="Tiêu chí kỹ năng" CssClass="css_link_nhom" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                    CssClass="table gridX" loai="N" cot="dk,ma,ten,tu,den" hangKt="3" gchuId="gchu">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                        <asp:TemplateField HeaderText="Điều kiện" HeaderStyle-Width="40px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:kieu ID="dk" runat="server" lke="OR,AND" Width="40px" CssClass="css_Gma_c" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Mã kỹ năng" HeaderStyle-Width="60px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="ma" kieu_chu="true" runat="server" Width="60px" CssClass="css_Gma"
                                                                                    f_tkhao="~/App_form/ns/ma/ns_ma_kynang.aspx" ktra="ns_ma_kynang,ma,ten" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="Tên kỹ năng" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                                                        <asp:TemplateField HeaderText="Từ (Năm)" HeaderStyle-Width="60px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="tu" runat="server" Width="60px" CssClass="css_Gma_c" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Đến (Năm)" HeaderStyle-Width="60px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="den" runat="server" Width="60px" CssClass="css_Gma_c" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </Cthuvien:GridX>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="border: gray 1px solid; width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_danhsach_ct_CatDong();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td align="left" valign="top">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label12" runat="server" Width="170px" Text="Tiêu chí chứng chỉ đào tạo" CssClass="css_link_nhom" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:GridX ID="GR_cc" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                    CssClass="table gridX" loai="N" cot="dk,cc,ten" hangKt="3" gchuId="gchu">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                        <asp:TemplateField HeaderText="Điều kiện" HeaderStyle-Width="40px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:kieu ID="dk" runat="server" lke="OR,AND" Width="40px" CssClass="css_Gma_c" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Mã chứng chỉ" HeaderStyle-Width="80px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="cc" kieu_chu="true" runat="server" Width="60px" CssClass="css_Gma"
                                                                                    f_tkhao="~/App_form/ns/ma/ns_ma_vb.aspx" ktra="ns_ma_vb,ma,ten" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="Tên chứng chỉ" DataField="ten" HeaderStyle-Width="155px" ItemStyle-CssClass="css_Gnd" />
                                                                    </Columns>
                                                                </Cthuvien:GridX>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="border: gray 1px solid; width: 60px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_danhsach_cc_CatDong();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td align="left" valign="top">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label14" runat="server" Width="170px" Text="Tiêu chí tham gia dự án" CssClass="css_link_nhom" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:GridX ID="GR_da" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                                    CssClass="table gridX" loai="N" cot="dk,da,ten_da" hangKt="3" gchuId="gchu">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                        <asp:TemplateField HeaderText="Điều kiện" HeaderStyle-Width="40px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:kieu ID="dk" runat="server" lke="OR,AND" Width="40px" CssClass="css_Gma_c" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Mã dự án" HeaderStyle-Width="60px">
                                                                            <ItemTemplate>
                                                                                <Cthuvien:ma ID="da" kieu_chu="true" runat="server" Width="60px" CssClass="css_Gma"
                                                                                    f_tkhao="~/App_form/lamviec/ma/ns_ts_duan.aspx" ktra="ns_ts_duan,ma,ten" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="Tên dự án" DataField="ten_da" HeaderStyle-Width="155px" ItemStyle-CssClass="css_Gnd" />
                                                                    </Columns>
                                                                </Cthuvien:GridX>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="border: gray 1px solid; width: 60px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ns_danhsach_cc_CatDong();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="1" cellspacing="1">
                                                        <tr>
                                                            <td style="padding-top: 1px">
                                                                <div class="box3  txCenter" style="vertical-align:top">
                                                                    <a href="#" onclick="return ns_danhsach_TIM();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">T</span>ìm kiếm</a>
                                                                    <a href="#" class="bt bt-grey" onclick="return ns_danhsach_P_IN();form_P_LOI();"><span class="txUnderline">I</span>n</a>
                                                                    <a href="#" class="bt bt-grey" onclick="return ns_menu_tbao_ct_P_CB();form_P_LOI();"><span class="txUnderline">C</span>hi tiết</a>
                                                                </div>
                                                            </td>
                                                            <%--<td>
                                                                <Cthuvien:nhap ID="tim" runat="server" Text="Tìm kiếm" Width="101px" class="css_button_l"
                                                                    title="Thêm mã thông tin" OnClick="return ns_danhsach_TIM();form_P_LOI();" />--%>

                                                            <%--title="Thêm mã thông tin" OnClick="return ns_kynang_cn_P_TIM();form_P_LOI();" />--%>
                                                            <%--</td>--%>
                                                            <%--<td align="center" style="display: none">
                                                                <Cthuvien:nhap ID="chon" runat="server" CssClass="css_button" Font-Bold="True" Width="70px"
                                                                    Text="Chọn" OnClick="return form_P_TRA_CHON_GRID('GR_lke:so_the,GR_lke:ten,GR_lke:phong,GR_lke:dtdd,GR_lke:email');form_P_LOI();" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:nhap ID="in" runat="server" Text="In" CssClass="css_button" OnClick="return ns_danhsach_P_IN();form_P_LOI();"
                                                                    Width="70px" />
                                                            </td>
                                                            <td align="center">
                                                                <Cthuvien:nhap ID="chitiet" runat="server" Text="Chi tiết" Width="90px" OnClick="return ns_menu_tbao_ct_P_CB();form_P_LOI();" />
                                                            </td>--%>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <div style="height: 380px; width: 1250px; overflow: scroll">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="X" hangKt="17" cotAn="PHONG">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:BoundField HeaderText="T.tự" DataField="SOTT" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Số Thẻ" DataField="SO_THE" HeaderStyle-Width="120px"
                                                                    ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Họ Tên" DataField="TEN" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Tên phòng" DataField="TEN_PHONG" HeaderStyle-Width="300px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Vị trí" DataField="CDANH" HeaderStyle-Width="300px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Số ĐT" DataField="DTDD" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Email" DataField="EMAIL" HeaderStyle-Width="190px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Phòng" DataField="PHONG" />
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
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
            <td colspan="2" class="css_border" align="left">
                <div id="UPa_gchu">
                    <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                </div>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" value="0" />
        <Cthuvien:an ID="ten_phong" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1330,725" />
    </div>
</asp:Content>
