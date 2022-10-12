<%@ Page Title="import_cc_nagase" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="import_cc_nagase.aspx.cs" Inherits="f_import_cc_nagase" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<%@ Register Src="~/App_ctr/khud/khud_scrl.ascx" TagName="khud_scrl" TagPrefix="khud_scrl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr class="css_tieudeN">
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Chấm công chi tiết Nagase Viet Nam" />
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
                                                                    onchange="import_cc_nagase_P_KTRA('PHONG')" DataTextField="ten" DataValueField="ma" />
                                                            </td>
                                                            <td style="width: 20px;" align="center" valign="middle">
                                                                <img runat="server" alt="" src="~/images/icon/phai.png" title="Lựa chọn" onclick="return import_cc_nagase_phong();" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text="Tháng tạm ứng" Width="120px" CssClass="css_gchu_c" />
                                                            </td>
                                                            <td>
                                                                <Cthuvien:thang  placeholder='MM/yyyy' ID="THANGCC" runat="server" Width="100px" CssClass="css_ma_c" kt_xoa="G"
                                                                    kieu_luu="S" onchange="import_cc_nagase_P_KTRA('THANG')" />
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
                                                            CssClass="table gridX" loai="N" cot="id_cc,ten,ngay_cc,giovao,giove,time_lam,dimuon,vesom,noi_lv,ngay_cc_thu,ngay,thang,nam,ngay_cc_th,dimuon_gb,vesom_gb,thoigian_vesom,thoigian_dimuon,themgio,tong_time" hangKt="24" gchuId="gchu"
                                                            cotAn="ngay_cc_thu,ngay,thang,nam,ngay_cc_th,dimuon_gb,vesom_gb,thoigian_vesom,thoigian_dimuon,themgio,tong_time"
                                                            ctrT="so_tt" ctrS="nhap">
                                                            <Columns>
                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                <asp:BoundField HeaderText="ID" DataField="id_cc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gnd" />
                                                                <asp:BoundField HeaderText="Name" DataField="ten" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gnd" />
                                                                <asp:BoundField HeaderText="Date" DataField="ngay_cc" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField HeaderText="Attendance" DataField="giovao" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField HeaderText="Leaving" DataField="giove" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField HeaderText="Work Time" DataField="time_lam" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField HeaderText="Late IN" DataField="dimuon" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField HeaderText="Early OUT" DataField="vesom" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField HeaderText="Department" DataField="noi_lv" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                                                <asp:BoundField DataField="ngay_cc_thu"/>
                                                                <asp:BoundField DataField="ngay"/>
                                                                <asp:BoundField DataField="thang"/>
                                                                <asp:BoundField DataField="nam"/>
                                                                <asp:BoundField DataField="ngay_cc_th"/>
                                                                <asp:BoundField DataField="dimuon_gb"/>
                                                                <asp:BoundField DataField="vesom_gb"/>
                                                                <asp:BoundField DataField="thoigian_vesom"/>
                                                                <asp:BoundField DataField="thoigian_dimuon"/>
                                                                <asp:BoundField DataField="themgio"/>
                                                                <asp:BoundField DataField="tong_time"/>
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
                                                    <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return import_cc_nagase_P_NH();form_P_LOI();"
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
                                            CssClass="table gridX" loai="X" hangKt="24" hamRow="import_cc_nagase_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Tháng chấm công" DataField="thangcc" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
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
