<%@ Page Title="cc_cn_ct_hal" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="cc_cn_ct_hal.aspx.cs" Inherits="f_cc_cn_ct_hal" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Chấm công chi tiết HAL" />
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
                        <td class="C_out">
                            <table border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table id="UPa_ct" runat="server" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Phòng" CssClass="css_gchu" Width="100px" />
                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="PHONG" runat="server" kieu="U" Width="300px" CssClass="css_drop"
                                                                    onchange="import_cc_hal_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />
                                                            </td>
                                                            <td style="width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return import_cc_hal_phong();" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text="Tháng chấm công" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:thang  placeholder='MM/yyyy' ID="THANG" runat="server" Width="100px" CssClass="css_ma_c" kt_xoa="G"
                                                                    kieu_luu="S" onchange="import_cc_hal_P_KTRA('THANG')" />
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
                                        <div style="height: 500px; width: 960px; overflow: scroll">
                                            <table cellpadding="0" cellspacing="0" width="200px">
                                                <tr>
                                                    <td>
                                                        <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                                            CssClass="table gridX" loai="N" cot="id,no,name,time,state,exception,operation" hangKt="24" gchuId="gchu"
                                                            ctrT="so_tt" ctrS="nhap">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:BoundField HeaderText="Ac-No." DataField="id" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gnd" />
                                                                <asp:BoundField HeaderText="No." DataField="no" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gnd" />
                                                                <asp:BoundField HeaderText="Name" DataField="name" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                                                <asp:BoundField HeaderText="Time" DataField="time" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField HeaderText="State" DataField="state" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField HeaderText="Exception" DataField="exception" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField HeaderText="Operation" DataField="operation" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                                            </Columns>
                                                        </Cthuvien:GridX>
                                                    </td>
                                                    <%-- <td class="css_scrl_td">
                                                    <khud_scrl:khud_scrl ID="GR_ct_slide" runat="server" loai="N" gridId="GR_ct" ham="ns_tl_tu_lke_ct();" />
                                                </td>--%>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table id="UPa_nhap" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return import_cc_hal_P_NH();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return import_cc_nagase_P_MOI();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return import_cc_nagase_P_XOA();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="file" runat="server" Text="File" CssClass="css_button" OnClick="return cc_cn_ct_P_FILES();form_P_LOI();"
                                                        Width="70px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="24" hamRow="import_cc_hal_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Tháng chấm công" DataField="thang" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="20" gridId="GR_lke"
                                            ham="import_cc_nagase_P_LKE()" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1200,700" />
    </div>
</asp:Content>
