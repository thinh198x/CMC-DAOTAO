<%@ Page Title="ns_td_ds_uvien" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_ds_uvien.aspx.cs" Inherits="f_ns_td_ds_uvien" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Danh sách ứng viên" />
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
                        <td valign="top" class="form_left">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="22" hamRow="ns_td_ds_ct_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Vòng thi/phỏng vấn" DataField="vong" HeaderStyle-Width="150px"
                                                    ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Ngày" DataField="ngay_thi" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="90" gridId="GR_lke"
                                            ham="ns_td_ds_P_CHUYEN_HANG_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td valign="middle" align="left">
                                        <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Nhóm chức danh" Width="140px" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_nhap ID="ncdanh" ten="Nhóm chức danh" runat="server" DataTextField="ten" DataValueField="ma"
                                                        CssClass="css_form" Width="180px" onchange="ns_td_ds_uvien_P_KTRA('ncdanh')" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Chức danh" Width="100px" CssClass="css_gchu" />
                                                </td>
                                                <td align="left">
                                                    <Cthuvien:DR_nhap ID="cdanh" ten="Chức danh" runat="server" DataTextField="ten" DataValueField="ma"
                                                        CssClass="css_form" Width="180px" onchange="ns_td_ds_uvien_P_KTRA('cdanh')" />
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
                                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                        CssClass="table gridX" loai="N" cot="chon,so_id,cmt,ten,tinhtrang,lan,tongdiem"
                                                        hamRow="ns_td_ds_GR_lke_RowChange()" hangKt="10" cotAn="so_id">
                                                        <Columns>
                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                            <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                                                <ItemTemplate>
                                                                    <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn phê duyệt" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Số CMT" DataField="so_id" />
                                                            <asp:BoundField HeaderText="Số CMT/Hộ chiếu" DataField="cmt" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                                            <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                                            <asp:BoundField HeaderText="Tình trạng" DataField="tinhtrang" HeaderStyle-Width="245px" ItemStyle-CssClass="css_Gma" />
                                                            <asp:BoundField HeaderText="Số lần đã thi/pv" DataField="lan" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                            <asp:BoundField HeaderText="Tổng điểm" DataField="tongdiem" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                                        </Columns>
                                                    </Cthuvien:GridX>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>

                                                <td align="left">
                                                    <Cthuvien:ma ID="noidung" ten="Nội dung" runat="server" kt_xoa="X" CssClass="css_form" Width="480px" kieu_unicode="true"
                                                        TextMode="MultiLine" Rows="15" ReadOnly="true" />
                                                </td>
                                                <td>
                                                    <table id="UPa_tt" runat="server" cellpadding="1" cellspacing="1">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:bbuoc ID="Bbuoc5" runat="server" Text="Vòng thi/phỏng vấn" CssClass="css_gchu_c" ToolTip="Vòng thi/phỏng vấn"></Cthuvien:bbuoc>
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:so ID="VONG" ten="Vòng thi/phỏng vấn" runat="server" kt_xoa="X" CssClass="css_form_r" Width="300px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:bbuoc ID="Bbuoc1" runat="server" Text="Ngày thi/phỏng vấn" CssClass="css_gchu_c" ToolTip="Ngày thi/phỏng vấn"></Cthuvien:bbuoc>
                                                            </td>
                                                            <td align="left">

                                                                <div class="ip-group date">
                                                                    <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                                    <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="NGAY_THI" ten="Ngày thi/phỏng vấn" runat="server" kt_xoa="X" CssClass="css_form_c" Width="272px" />
                                                                    </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" Text="Người phỏng vấn" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="nguoipv" ten="Người phỏng vấn" runat="server" kt_xoa="X" CssClass="css_form" Width="300px" kieu_unicode="true" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label7" runat="server" Text="Điểm đánh giá" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:so ID="diem" ten="Điểm đánh giá" runat="server" kt_xoa="X" CssClass="css_form" Width="300px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text="Nhận xét" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="nhanxet" ten="Nhận xét" runat="server" kt_xoa="X" CssClass="css_form" Width="300px" kieu_unicode="true" TextMode="MultiLine" Rows="3" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label5" runat="server" Text="Đề xuất công việc" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td align="left">
                                                                <Cthuvien:ma ID="dexuat" ten="Đề xuất công việc" runat="server" kt_xoa="X" CssClass="css_form" Width="300px" kieu_unicode="true" TextMode="MultiLine" Rows="3" />
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
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                                    <img runat="server" alt="" src="~/images/bitmaps/dong.png" title="Chọn tất cả" onclick="return ns_td_dxuat_CHON();" />
                                                </td>
                                                <td style="display: none">
                                                    <Cthuvien:nhap ID="xem" runat="server" giu="false" anh="" Text="Xem" CssClass="css_button" OnClick="return ns_td_ds_uvien_P_XEM();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <%--<td>
                                        <Cthuvien:nhap ID="nhap" runat="server" giu="false" anh="" Text="Nhập" CssClass="css_button" OnClick="return ns_td_ds_uvien_P_NH();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                     <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" giu="false" anh="" Text="Xóa" CssClass="css_button" OnClick="return ns_td_ds_uvien_P_XOA();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="pheduyet" runat="server" giu="false" Text="Tuyển Dụng" CssClass="css_button" OnClick="return ns_td_ds_uvien_P_PHEDUYET();form_P_LOI();"
                                            Width="90px" />
                                    </td>--%>
                                                <td style="padding-top: 5px">
                                                    <%--<Cthuvien:nhap ID="nhap" runat="server" CssClass="css_button" Font-Bold="True" Width="70px"
                                                    Text="Nhập" OnClick="return ns_cb_P_NH();form_P_LOI();" />--%>
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_td_ds_uvien_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_td_ds_uvien_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_td_ds_uvien_P_PHEDUYET();form_P_LOI();"><span class="txUnderline">T</span>uyển dụng</a>
                                                    </div>
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
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,710" />
    </div>
</asp:Content>
