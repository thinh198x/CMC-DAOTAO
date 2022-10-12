<%@ Page Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ti_bc_files.aspx.cs" Inherits="f_ti_bc_files" Title="ti_bc_files" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpPa_chon_file" UpdateMode="Conditional" runat="server">
        <ContentTemplate>

            <table cellpadding="1" cellspacing="2" class="tbl_form" width="480px">
                <tr>
                    <td colspan="2" class="fr_title" width="100%" align="left">
                        <img width="20" height="22" align="absmiddle" style="padding-top: 2px; padding-left: 5px;"
                            class="png" src="../../images/vnpt_ico.png">
                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieude" Text="Quản lý files" />
                    </td>
                </tr>
                <tr>
                    <td align="left" style="border: #b9b9b9 1px solid;">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table id="Upa_ct" border="0" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:RadioButtonList ID="rdo_files" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="T" Text="Thay đổi files" />
                                                    <asp:ListItem Value="K" Text="Không thay đổi files" />
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <asp:Label ID="Label1" runat="server" CssClass="css_gchu" Text="Tên BC" Width="60px" />
                                            </td>
                                            <td>
                                                <Cthuvien:ma ID="tenbc" ten="tên báo cáo" runat="server" CssClass="css_nd" kieu_unicode="True"
                                                    kt_xoa="X" Width="270px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <asp:Label ID="Label3" runat="server" CssClass="css_gchu" Text="Files" />
                                            </td>
                                            <td align="left">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Image ID="Throbber" ImageUrl="~/images/Loading.gif" runat="server" Width="24px"
                                                                Height="24px" />
                                                        </td>
                                                        <td>
                                                            <AjaxTk:AsyncFileUpload ID="AsyncFileUpload1" runat="server" OnUploadedComplete="AsyncFileUpload1_UploadedComplete"
                                                                Width="300px" ThrobberID="Throbber" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="left">
                                                            <asp:Label ID="loai" runat="server" Text="Files hợp lệ: .xml" CssClass="css_gchu" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label4" runat="server" CssClass="css_gchu" Text="Tải files: " />
                                            </td>
                                            <td>
                                                <asp:HyperLink ID="xem_file" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <div id="Upa_bt">
                                        <table cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td style="width: 100px;" />
                                                <td>
                                                    <Cthuvien:nhap ID="nhap" runat="server" CssClass="css_button" Width="70px" Text="Nhập" OnServerClick="nhap_ServerClick" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="moi" runat="server" CssClass="css_button" Width="70px" Text="Mới"
                                                        OnClick="return ti_bc_files_P_MOI();" />
                                                </td>
                                                <td>
                                                    <Cthuvien:nhap ID="xoa" runat="server" CssClass="css_button" Width="70px" Text="Xóa"
                                                        OnClick="return ti_bc_files_P_XOA();" />
                                                </td
                                                
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                        CssClass="table gridX" loai="X" hangKt="10" cotAn="url,so_id,ma" hamRow="ti_bc_files_GR_lke_ActiveRowChange()">
                                        <Columns>
                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                            <asp:BoundField HeaderText="" DataField="ma" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Tên báo cáo" DataField="tenbc" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="Tên file" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="url" DataField="url" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                            <asp:BoundField HeaderText="" DataField="so_id" HeaderStyle-Width="180px" ItemStyle-CssClass="css_Gma" />
                                        </Columns>
                                    </Cthuvien:GridX>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td align="left" colspan="2">
                        <div id="UPa_gchu">
                            <Cthuvien:gchu ID="gchu" runat="server" kt_xoa="K" CssClass="css_gchu" />
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="insert" />
        </Triggers>
    </asp:UpdatePanel>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" Value ="0" />
        <Cthuvien:an ID="ma" runat="server" />
        <Cthuvien:an ID="link" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="850,350" />
    </div>
    <%-- Ket Qua--%>
    <script language="javascript" type="text/javascript">
        var ti_bc_files_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_nhomId;
        function ti_bc_files_P_KD() {
            ti_bc_files_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
            b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
            b_xem_fileId = '<%=xem_file.ClientID %>';
            b_gchuId = form_Fs_VTEN_ID('', 'gchu');
            b_maId = form_Fs_VTEN_ID('', 'ma');
            b_slideId = b_grlkeId + '_slide';
        }
        function P_KET_QUA(b_dtuong, a_tso) {
            try {
                if (b_dtuong == null || b_dtuong == "") return true;
                b_dtuong = b_dtuong.toUpperCase(); var b_kq = a_tso[0];
                if (b_dtuong.indexOf("MA") >= 0) {
                    $get(b_maId).value = b_kq;
                    $get(b_gchuId).value = a_tso[1];
                    ti_bc_files_P_LKE();
                }
            }
            catch (err) { form_P_LOI(err); }
        }

        function ti_bc_files_P_LKE() {
            try {
                var b_ma = $get(b_maId).value;
                var a_cot = GridX_Fas_tenCot(b_grlkeId);
                sti_ch.Fs_FILES_LKE(b_ma, a_cot, ti_bc_files_P_LKE_XLY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            catch (err) { form_P_LOI(err); }
        }
        function ti_bc_files_P_LKE_XLY_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            if (b_kq == "") GridX_datTrang(b_grlkeId);
            else GridX_datBang(b_grlkeId, b_kq);
        }
        function ti_bc_files_GR_lke_ActiveRowChange(gridId, rowId) {
            if (ti_bc_files_choAct != 0) { clearTimeout(ti_bc_files_choAct); ti_bc_files_choAct = 0; }
            ti_bc_files_choAct = setTimeout("ti_bc_files_P_CHUYEN_HANG()", 300);
            return true;
        }
        var ti_bc_files_choAct = 0;
        function ti_bc_files_P_LKE_CHO() {
            if ($get(b_grlkeId) != null) { clearTimeout(ti_bc_files_lkeCho); ti_bc_files_P_LKE(); }
        }
        // moi form
        function ti_bc_files_P_MOI() {
            GridX_thoiA(b_grlkeId);
            form_P_MOI(b_vungId, "GXL");
        }
        // xoa doi tuong
        function ti_bc_files_P_XOA() {
            try {
                var b_hang = GridX_Fi_timHangA(b_grlkeId);
                if (b_hang < 1) return;
                var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
                var b_ma = $get(b_maId).value;
                if (b_so_id == 0) ti_bc_files_P_MOI();
                else sti_ch.Fs_FILES_XOA(b_ma,b_so_id, ti_bc_files_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                return false;
            }
            catch (err) { form_P_LOI(err); }
        }
        function ti_bc_files_P_XOA_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
            else {
                var b_hang = GridX_Fi_timHangA(b_grlkeId);
                if (b_hang > 1) b_hang--;
                else b_hang = GridX_Fi_hangSo(b_grlkeId);
                if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ti_bc_files_P_MOI();
                else { GridX_datA(b_grlkeId, b_hang); ti_bc_files_P_CHUYEN_HANG(); }
            }
        }

        function ti_bc_files_P_CHUYEN_HANG() {
            try {
                var b_hang = GridX_Fi_timHangA(b_grlkeId);
                var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
                if (b_so_id == 0 || b_so_id == null) ti_bc_files_P_MOI();
                else form_P_GridX_TEXT(b_vungId, b_grlkeId);
                var b_url = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "url")),
                    b_ten = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten"));
                $get('<%=xem_file.ClientID %>').href = b_url + b_ten;
                $get('<%=xem_file.ClientID %>').innerHTML = b_ten;
                
            }
            catch (err) { throw (err); }
        }
    </script>
</asp:Content>
