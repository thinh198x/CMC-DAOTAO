<%@ Page Title="ti_tkiem" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ti_tkiem.aspx.cs" Inherits="f_ti_tkiem" %>

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
                                        <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Tìm kiếm cán bộ " />
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
                            <table id="UPa_ct" runat="server" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <table cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Nhóm điều kiện" CssClass="css_gchu" Width="100px" />
                                                </td>
                                                <td>
                                                    <table border="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:DR_nhap ID="NHOM" runat="server" kieu="U" Width="200px" CssClass="css_form"
                                                                    onchange="ti_tkiem_P_KTRA('NHOM')" DataTextField="ten" DataValueField="ma" />
                                                            </td>
                                                            <td>
                                                                <table border="0" cellspacing="0" cellpadding="0" width="100%">
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
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <table id="NPa" runat="server" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_dk" runat="server" CssClass="css_tab_ngang_ac" Width="150px"
                                                                    Height="20px" Text="Điều kiện tìm kiếm" ham="ti_tkiem_P_NPA('dk')" />
                                                            </td>
                                                            <td style="width: 1px;" />
                                                            <td>
                                                                <Cthuvien:tab ID="NPa_kq" runat="server" CssClass="css_tab_ngang_de" Width="150px"
                                                                    Height="20px" Text="Chọn kết quả hiển thị" ham="ti_tkiem_P_NPA('kq')" />
                                                            </td>
                                                            <td style="border-bottom: 1px solid #cccccc; width: 10%">&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" class="tab_content">
                                                    <asp:Panel ID="Pa_dk" runat="server" Style="display: block;">
                                                        <%--width: 490px; height: 470px;--%>
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="left">
                                                                    <div style="height: 400px; width: 252px; overflow: scroll">
                                                                        <Cthuvien:GridX ID="GR_gtrdk" runat="server" loai="L" hamRow="ti_tkiem_GR_gtrdk_CHUYEN()"
                                                                            AutoGenerateColumns="false" hangKt="18" PageSize="1" CssClass="table gridX" cotAn="ma,loai,ktra,f_tkhao">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                <asp:BoundField HeaderText="Nhóm" DataField="nhom" HeaderStyle-Width="60px" ItemStyle-CssClass="css_Gma" />
                                                                                <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="18px" ItemStyle-CssClass="css_Gma" />
                                                                                <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="155px" ItemStyle-CssClass="css_Gma" />
                                                                                <asp:BoundField HeaderText="loại" DataField="loai" HeaderStyle-Width="155px" ItemStyle-CssClass="css_Gma" />
                                                                                <asp:BoundField HeaderText="Kiểm tra" DataField="ktra" HeaderStyle-Width="155px" ItemStyle-CssClass="css_Gma" />
                                                                                <asp:BoundField HeaderText="f_tkhao" DataField="f_tkhao" HeaderStyle-Width="155px" ItemStyle-CssClass="css_Gma" />
                                                                            </Columns>
                                                                        </Cthuvien:GridX>
                                                                    </div>
                                                                </td>

                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <asp:Label ID="Label2" runat="server" Text=">>>" CssClass="css_gchu_c" Width="50px" />
                                                                        </tr>
                                                                        <tr>
                                                                            <asp:Label ID="Label3" runat="server" Text=">>>" CssClass="css_gchu_c" Width="50px" />
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td align="left">
                                                                    <div style="height: 400px; width: 505px; overflow: scroll">
                                                                        <table cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <Cthuvien:GridX ID="GR_ct" runat="server" loai="N" AutoGenerateColumns="false" PageSize="1" hamUp="ti_tkiem_Update"
                                                                                        cotAn="ma,loai,ktra,f_tkhao" CssClass="table gridX" hangKt="18" cot="f1,nhom,ma,ten,loai,ktra,f_tkhao,gtri_tu,gtri_toi">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                            <asp:BoundField HeaderText="F1" DataField="f1" HeaderStyle-Width="40px" ItemStyle-CssClass="css_Gma_c" />
                                                                                            <asp:BoundField HeaderText="Nhóm" DataField="nhom" HeaderStyle-Width="60px" />
                                                                                            <asp:BoundField HeaderText="Mã" DataField="ma" />
                                                                                            <asp:BoundField HeaderText="Tên" DataField="ten" HeaderStyle-Width="157px" ItemStyle-CssClass="css_Gma" />
                                                                                            <asp:BoundField HeaderText="loại" DataField="loai" HeaderStyle-Width="155px" ItemStyle-CssClass="css_Gma" />
                                                                                            <asp:BoundField HeaderText="Kiểm tra" DataField="ktra" HeaderStyle-Width="155px" ItemStyle-CssClass="css_Gma" />
                                                                                            <asp:BoundField HeaderText="f_tkhao" DataField="f_tkhao" HeaderStyle-Width="155px" ItemStyle-CssClass="css_Gma" />
                                                                                            <asp:TemplateField HeaderText="Giá trị từ" HeaderStyle-Width="100px">
                                                                                                <ItemTemplate>
                                                                                                    <Cthuvien:ma ID="gtri_tu" runat="server" Width="100px" CssClass="css_Gma_c" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Giá trị tới" HeaderStyle-Width="100px">
                                                                                                <ItemTemplate>
                                                                                                    <Cthuvien:ma ID="gtri_toi" runat="server" Width="100px" CssClass="css_Gma_c" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </Cthuvien:GridX>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Pa_kq" runat="server" Style="display: none;">
                                                        <div style="height: 400px; width: 865px; overflow: scroll">
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <div id="UPa_lke">
                                                                            <Cthuvien:GridX ID="GR_lke" runat="server" loai="N" AutoGenerateColumns="false" PageSize="1"
                                                                                hangKt="18" CssClass="table gridX" cot="chon,nhom,ma,ten,dkthem,cot" cotAn="nhom,ma,dkthem,cot">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                                                    <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40px">
                                                                                        <ItemTemplate>
                                                                                            <Cthuvien:kieu ID="chon" runat="server" Width="40px" CssClass="css_Gma_c" Text="" lke="X," ToolTip="Chọn dữ liệu" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField HeaderText="Nhóm" DataField="nhom" HeaderStyle-Width="18px" />
                                                                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="40px" />
                                                                                    <asp:BoundField HeaderText="Dữ liệu hiển thị" DataField="ten" HeaderStyle-Width="786px" ItemStyle-CssClass="css_Gma" />
                                                                                    <asp:BoundField HeaderText="" DataField="dkthem" />
                                                                                    <asp:BoundField HeaderText="" DataField="cot" />
                                                                                </Columns>
                                                                            </Cthuvien:GridX>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
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
                                                <td id="id_check" runat="server">
                                                    <table cellpadding="0" cellspacing="1" style="display: inline">
                                                        <tr>
                                                            <td align="center" valign="middle" style="border: gray 1px solid; width: 20px;">
                                                                <img alt="" src="../../images/bitmaps/dong.png" title="Chọn tất cả" onclick="return ti_tkiem_CHON();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight2">
                                                        <a href="#" class="bt bt-grey" onclick="return ti_tkiem_P_TIM();form_P_LOI();"><span class="txUnderline">T</span>ìm Kiếm</a>
                                                    </div>
                                                </td>
                                                <%--<td>
                                                    <Cthuvien:nhap ID="tim" runat="server" Text="Tìm Kiếm" CssClass="css_button" OnClick="return ti_tkiem_P_TIM();form_P_LOI();"
                                                        Width="100px" />
                                                </td>--%>
                                                <td id="id_tk" runat="server">
                                                    <table cellpadding="0" cellspacing="1" style="display: inline">
                                                        <tr>
                                                            <td align="center" valign="middle" style="border: gray 1px solid; width: 20px; height:20px">
                                                                <img alt="" src="../../images/bitmaps/len.gif" title="Chuyển dòng lên" onclick="return ti_tkiem_HangLen();" />
                                                            </td>
                                                            <td style="border: gray 1px solid; width: 20px; height:20px;" align="center" valign="middle">
                                                                <img alt="" src="../../images/bitmaps/xuong.gif" title="Chuyển dòng xuống" onclick="return ti_tkiem_HangXuong();" />
                                                            </td>
                                                            <td style="border: gray 1px solid; width: 20px; height:20px;" align="center" valign="middle">
                                                                <img alt="" src="../../images/bitmaps/cat.gif" title="Cắt các dòng đã chọn" onclick="return ti_tkiem_CatDong();" />
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="950,620" />
    </div>
    <script language="javascript" type="text/javascript">
        var ti_timkiem_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_nhomId, b_so_idId, b_kq = 'NS_CB',
            b_ctr, b_hang, b_f_tkhao, ti_tkiem_choAct = 0;
        function ti_timkiem_P_KD() {
            ti_timkiem_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
            b_gtrdkId = form_Fs_VUNG_ID('GR_gtrdk'); b_td_dkId = form_Fs_VUNG_ID('id_tk'); b_td_checkId = form_Fs_VUNG_ID('id_check');
            b_slideId = b_grlkeId + '_slide';
            ti_tkiem_P_NPA('dk');
            b_nhomId = form_Fs_TEN_ID(b_vungId, 'NHOM');
            b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
            b_gchuId = form_Fs_VTEN_ID('', 'gchu');
            ti_timkiem_lkeCho = setInterval('ti_timkiem_P_LKE_CHO()', 200);
        }

        function ti_tkiem_P_NPA(b_nv) {
            if (b_nv != "dk") {
                $get(b_td_dkId).style.display = "none";
                $get(b_td_checkId).style.display = "inline";
            }
            else {
                $get(b_td_dkId).style.display = "inline";
                $get(b_td_checkId).style.display = "none";
            }
        }
        function P_KET_QUA(b_dtuong, a_tso) {
            try {
                if (b_dtuong == null || b_dtuong == "") return;
                b_dtuong = b_dtuong.toUpperCase();
                var b_kq = a_tso[0];
                if (b_dtuong.indexOf("GTRI_TU") >= 0) {
                    var b_hang = GridX_Fi_timHangA(b_grctId);
                    if (b_hang > -1) { GridX_datGtri(b_grctId, b_hang, "gtri_tu", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
                }
                if (b_dtuong.indexOf("GTRI_TOI") >= 0) {
                    var b_hang = GridX_Fi_timHangA(b_grctId);
                    if (b_hang > -1) { GridX_datGtri(b_grctId, b_hang, "gtri_toi", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
                }
            }
            catch (err) { form_P_LOI(err); }
        }

        function ti_tkiem_Update(b_event) {
            try {
                b_ctr = form_Fctr_event(b_event);
                b_hang = GridX_Fi_timHangA(b_grctId);
                var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase(), b_ktra = b_ctr.getAttribute('ktra');
                b_f_tkhao = b_ctr.getAttribute('f_tkhao');
                var b_ten = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "ten"));
                if (b_f_tkhao == null) return false;
                if (b_value != "") {
                    if (b_cot == "GTRI_TU" || b_cot == "GTRI_TOI") {
                        skhac.Fs_MA_LOI(form_Fs_nsd(), b_ten, b_value, b_ktra, ti_tkiem_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                    }
                }
                if (b_value != "") GridX_ThemHang(b_grctId);
                return false;
            }
            catch (err) { form_P_LOI(err); }
        }
        function ti_tkiem_P_DatGchu(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) {
                form_P_LOI(b_kq.substring(0, b_kq.length - 4) + ",Vui lòng nhấn F1 để lựa chọn:loi");
                GridX_datA(b_grctId, b_hang, b_ctr.getAttribute('ten_goc'));
                b_ctr.value = "";
                return false;
            }
            $get(b_gchuId).innerHTML = b_kq;
        }
        var b_mnhom = ["NS_CB"];
        var b_dk = 0;
        function ti_tkiem_P_KTRA(b_maTen) {
            try {
                var b_maId = "";
                b_maTen = b_maTen.toUpperCase();
                switch (b_maTen) {
                    case "NHOM": b_maId = b_nhomId; break;
                }
                var b_ma = $get(b_maId);
                if (b_ma == null || C_NVL(b_ma.value) == "") return;
                if (b_maTen == "NHOM") {
                    var b_kq = b_ma.value;
                    ti_tkiem_P_LKE_CT(b_kq);
                    ti_tkiem_P_LKE_HIENTHI(b_kq);
                    //ti_tkiem_CHECKNHOM(b_kq);
                }
            }
            catch (err) { form_P_LOI(err); }
        }
        function ti_tkiem_CHECKNHOM(b_kq) {
            try {
                for (var i = 0; i < b_mnhom.length; i++) {
                    if (b_kq == b_mnhom[i]) {
                        b_dk = 1;
                    }
                }
                if (b_dk == 0) {
                    ti_tkiem_P_LKE_CT(b_kq);
                    ti_tkiem_P_LKE_HIENTHI(b_kq);
                    var i = b_mnhom.length;
                    b_mnhom[i] = b_kq;
                    return;
                } else return;
            }
            catch (err) { form_P_LOI(err); }
        }
        function ti_timkiem_P_LKE_CHO() {
            if ($get(b_grlkeId) != null) { clearTimeout(ti_timkiem_lkeCho); ti_timkiem_P_LKE(); }
        }
        function ti_timkiem_P_LKE() {
            var b_nhom = $get(b_nhomId).value;
            ti_tkiem_P_LKE_CT(b_nhom);
            ti_tkiem_P_LKE_HIENTHI(b_nhom);
        }
        function ti_tkiem_P_LKE_CT(b_nhom) {
            try {
                var a_cot = GridX_Fas_tenCot(b_gtrdkId);
                sti_ch.Fs_NS_TK_LKE_CT(b_nhom, a_cot, ti_tkiem_P_LKE_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            catch (err) { form_P_LOI(err); }
        }

        function ti_tkiem_P_LKE_CT_KQ(b_kq) {
            b_dt_dk = GridX_Fdt_cotGtri(b_grctId);
            var a_kq = Fas_ChMang(b_kq, '#');
            if (a_kq[0] == "") GridX_datTrang(b_gtrdkId);
            else {
                //var b_hang = GridX_Fi_timHangT(b_gtrdkId);
                //if (b_hang == 1) { GridX_datBang(b_gtrdkId, a_kq[0]); }
                //else {
                //    var b_hangkt = GridX_Fi_hangKt(b_gtrdkId);
                //    b_hang = GridX_Fi_timHangT(b_gtrdkId);
                //    var hangdem = a_kq[1];
                //    if (b_hang + hangdem > b_hangkt){
                //          GridX_dat_hangkt(b_gtrdkId,a_kq[1]);
                //    }
                //    GridX_chenBang(b_gtrdkId, b_hang, a_kq[0]);
                //}
                GridX_dat_hangkt(b_gtrdkId, a_kq[1]);
                GridX_datBang(b_gtrdkId, a_kq[0]);
            }
        }

        function ti_tkiem_P_LKE_HIENTHI(b_nhom) {
            try {
                var a_cot = GridX_Fas_tenCot(b_grlkeId);
                sti_ch.Fs_NS_MA_KQ_HIENTHI_CT(b_nhom, a_cot, ti_tkiem_P_LKE_HIENTHI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                return false;
            }
            catch (err) { form_P_LOI(err); }
        }
        function ti_tkiem_P_LKE_HIENTHI_KQ(b_kq) {
            var b_dt_dk = GridX_Fdt_cotGtri(b_grlkeId);
            var a_kq = Fas_ChMang(b_kq, '#');
            if (b_kq[0] == "") GridX_datTrang(b_grlkeId);
            else {
                GridX_dat_hangkt(b_grlkeId, a_kq[1]);
                GridX_datBang(b_grlkeId, a_kq[0]);
                //var b_hang = GridX_Fi_timHangT(b_grlkeId);
                //if (b_hang == 1) { GridX_datBang(b_grlkeId, a_kq[0]); }
                //else {
                //var b_hangkt = GridX_Fi_hangKt(b_grlkeId);
                //b_hang = GridX_Fi_timHangT(b_grlkeId);
                //var hangdem = a_kq[1];
                //if (b_hang + hangdem > b_hangkt) {
                //    GridX_dat_hangkt(b_grlkeId, b_hang + hangdem);
                //}
                //GridX_chenBang(b_grlkeId, b_hang, a_kq[0]);
                //}
            }
        }
        function ti_tkiem_P_TIM() {
            var a_cot = Array(), j = 1; a_cot[0] = "sott";
            var b_ktra = GridX_Fdt_cotGtri(b_grlkeId, ["chon", "nhom", "ma"]);
            var b_gt = b_ktra[1];
            for (var i = 0; i < b_gt.length; i++) {
                if (b_gt[i][0] == "X") {
                    a_cot[j] = b_gt[i][2];
                    j++;
                }
            }

            if (j == 1) { alert("Chưa chọn dữ liệu hiển thị!"); return false; }
            else {
                var b_dt_dk = GridX_Fdt_cotGtri(b_grctId);
                var b_dt_kq = GridX_Fdt_cotGtri(b_grlkeId);
                sti_ch.Fs_NS_TIMKIEM2(b_dt_dk, b_dt_kq, a_cot, ti_tkiem_P_TIM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                return false;
            }
        }
        function ti_tkiem_P_TIM_KQ(b_kq) {
            var tencot = "";
            var b_ktra = GridX_Fdt_cotGtri(b_grlkeId, ["chon", "nhom", "ma"]);
            var b_gt = b_ktra[1];
            for (var i = 0; i < b_gt.length; i++) {
                if (b_gt[i][0] == "X") {
                    tencot = tencot + "," + b_gt[i][2];
                }
            }
            tencot = "sott" + tencot;
            form_P_MO("ti_ketqua_tk.aspx", null, ["KQ", [b_kq, tencot]]);
        }

        function ti_tkiem_GR_gtrdk_ActiveRowChange(gridId, rowId) {
            if (ti_tkiem_choAct != 0) { clearTimeout(ti_tkiem_choAct); ti_tkiem_choAct = 0; }
            ti_tkiem_choAct = setTimeout("ti_tkiem_GR_gtrdk_P_CHO()", 300);
            return true;
        }
        function ti_tkiem_GR_gtrdk_CHUYEN() {
            var b_f1 = "";
            var b_i = GridX_Fi_timHangA(b_gtrdkId);
            var b_nhom = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "nhom")),
                b_ma = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "ma")),
                b_ten = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "ten")),
                b_loai = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "loai")),
                b_ktra = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "ktra")),
                b_f_tkhao = C_NVL(GridX_Fas_layGtri(b_gtrdkId, b_i, "f_tkhao"));
            var b_hang = GridX_Fi_timHangT(b_grctId);
            if (b_hang < 0) { GridX_ThemHang(b_grctId); b_hang = GridX_Fi_timHangT(b_grctId); }
            else GridX_chenHang(b_grctId, b_hang);
            b_ctr_gtu = GridX_Fctr_TimCtr(b_grctId, b_hang, "gtri_tu");
            b_ctr_gtoi = GridX_Fctr_TimCtr(b_grctId, b_hang, "gtri_toi");
            if (b_f_tkhao != "") {
                b_ctr_gtu.setAttribute("f_tkhao", form_Fs_TM() + b_f_tkhao);
                b_ctr_gtoi.setAttribute("f_tkhao", form_Fs_TM() + b_f_tkhao);
                b_f1 = "(F1)";
            }
            if (b_ktra != "") {
                b_ctr_gtu.setAttribute("ktra", b_ktra);
                b_ctr_gtoi.setAttribute("ktra", b_ktra);
            }
            switch (b_loai) {
                case "C":
                    b_ctr_gtu.setAttribute("kieu_unicode", "C");
                    break;
                case "H":
                    b_ctr_gtu.setAttribute("kieu_chu", "C");
                    break;
                case "S":
                    b_ctr_gtu.setAttribute("kieu_so", "C");
                    break;
                case "N":
                    b_ctr_gtu.setAttribute("kieu_date", "C");
                    break;
            }
            GridX_datGtri(b_grctId, b_hang, ["f1", "nhom", "ma", "ten", "loai", "ktra", "f_tkhao"], [b_f1, b_nhom, b_ma, b_ten, b_loai, b_ktra, b_f_tkhao]);
            GridX_datA(b_grctId, b_hang, "gtri_tu");
            GridX_boChon(b_gtrdkId);
        }
        function ti_tkiem_CatDong() {
            var b_active = GridX_Fi_timHangA(b_grctId);
            GridX_datA(b_grctId, b_active);
            var b_nhom = C_NVL(GridX_Fas_layGtriA(b_grctId, "nhom")),
               b_ma = C_NVL(GridX_Fas_layGtriA(b_grctId, "ma")),
               b_ten = C_NVL(GridX_Fas_layGtriA(b_grctId, "ten")),
               b_loai = C_NVL(GridX_Fas_layGtriA(b_grctId, "loai")),
                b_ktra = C_NVL(GridX_Fas_layGtriA(b_grctId, "ktra")),
                b_f_tkhao = C_NVL(GridX_Fas_layGtriA(b_grctId, "f_tkhao"));
            var b_hang = GridX_Fi_timHangT(b_gtrdkId);
            if (b_hang < 0) { GridX_ThemHang(b_gtrdkId); b_hang = GridX_Fi_timHangT(b_gtrdkId); }
            GridX_datGtri(b_gtrdkId, b_hang, ["nhom", "ma", "ten", "loai", "ktra", "f_tkhao"], [b_nhom, b_ma, b_ten, b_loai, b_ktra, b_f_tkhao]);
            GridX_thoiA(b_gtrdkId);
            GridX_boChon(b_grctId);
            return false;
        }

        function ti_tkiem_HangLen() {
            GridX_chuyenHang(b_grctId, -1);
            return false;
        }
        function ti_tkiem_HangXuong() {
            GridX_chuyenHang(b_grctId, 1);
            return false;
        }
        function ti_tkiem_CHON() {
            var j = 0;
            var b_ktra = GridX_Fdt_cotGtri(b_grlkeId, ["chon", "nhom"]);
            var b_gt = b_ktra[1];
            for (var i = 0; i < b_gt.length; i++) {
                if (b_gt[i][0] == "X") { j++; }
            }
            if (j == 0) {
                for (var i = 0; i < b_gt.length; i++) {
                    if (b_gt[i][1] != "") {
                        GridX_datGtri(b_grlkeId, i + 1, ["chon"], ["X"]);
                    }
                }
            }
            else {
                for (var i = 0; i < b_gt.length; i++) {
                    GridX_datGtri(b_grlkeId, i + 1, ["chon"], [""]);
                }
            }
        }

        function GridX_Fctr_TimCtr(gridId, b_hang, b_cot) {
            try {
                var a_cot = GridX_Fas_tenCot(gridId);
                var b_icot = Fi_vtri_mang(a_cot, b_cot) + 1;
                var b_cell = $get(gridId).rows[b_hang].cells[b_icot], b_kq = null
                var a_ctr = b_cell.getElementsByTagName('input');
                if (a_ctr.length > 0) b_kq = a_ctr[0];
                else {
                    a_ctr = b_cell.getElementsByTagName('select');
                    if (a_ctr.length > 0) b_kq = a_ctr[0];
                    else {
                        a_ctr = b_cell.getElementsByTagName('span');
                        if (a_ctr.length > 0) b_kq = a_ctr[0];
                    }
                }
                return b_kq;
            }
            catch (err) { return null; }
        }

        function GridX_dat_hangkt(b_gridx, sodong) {
            try {
                var b_grid = $get(b_gridx);
                b_grid.setAttribute('hangKt', '18');
                var b_hangkt = GridX_Fi_hangKt(b_gridx);
                if (sodong > b_hangkt) {
                    b_grid.setAttribute('hangKt', sodong - b_hangkt + 19);
                }
                return false;
            } catch (err) { form_P_LOI(err); }
        }

        function form_dong() {
            location.reload(false);
        }
    </script>
</asp:Content>
