<%@ Page Title="ns_td_hsuv" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_hsuv.aspx.cs" Inherits="f_ns_td_hsuv" %>

<%@ Register Src="~/App_ctr/khud/khud_slide.ascx" TagName="khud_slide" TagPrefix="khud_slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left">
                            <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Hồ sơ ứng viên" />
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
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="X" hangKt="15" hamRow="ns_td_hsuv_GR_lke_RowChange()">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="CMT/Hộ chiếu" DataField="cmt" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Họ tên ứng viên" DataField="ten" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Đợt" DataField="dot" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Mã chức danh" DataField="ma_cdanh" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gnd" />
                                            </Columns>
                                        </Cthuvien:GridX>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="GR_lke_td" runat="server" align="center">
                                        <khud_slide:khud_slide ID="GR_lke_slide" runat="server" loai="X" rong="150" gridId="GR_lke"
                                            ham="ns_td_hsuv_P_LKE()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="form_right">
                            <table id="UPa_ct" runat="Server" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" Text="CMT/Hộ chiếu" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="CMT" runat="server" ten="Số CMT/hộ chiếu" kieu_chu="true" CssClass="css_form"
                                                        Width="137px" onchange="ns_td_hsuv_P_KTRA('CMT')" ToolTip="Số Chứng minh thư hoặc hộ chiếu" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Họ tên" Width="70px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="TEN" ten="Họ tên ứng viên" ToolTip="Họ tên ứng viên" runat="server"
                                                        kt_xoa="X" CssClass="css_form" Width="137px" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label10" runat="server" Text="Năm" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <Cthuvien:ma ID="NAM" ten="Năm tuyển dụng" ToolTip="Năm tuyển dụng" runat="server"
                                                        CssClass="css_form_r " onchange="ns_td_hsuv_P_KTRA('NAM')" Width="137px"
                                                        kieu_so="true" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" Text="Đợt" CssClass="css_gchu_c" Width="70px" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="DOT" ten="Đợt tuyển dụng" ToolTip="Đợt tuyển dụng" runat="server"
                                                        CssClass="css_form" Width="137px" gchu="gchu" kieu_unicode="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Nhóm công việc" Width="110px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="NHOM_CDANH" runat="server" ten="Nhóm công việc" BackColor="#f6f7f7"
                                                        ktra="ns_ma_ncdanh,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_ncdanh.aspx" kieu_chu="true"
                                                        CssClass="css_form" Width="137px" onchange="ns_td_hsuv_P_KTRA('NHOM_CDANH')" placeholder="Nhấn F1" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label13" runat="server" Text="Mã vị trí" Width="70px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="MA_CDANH" runat="server" ten="Mã vị trí cần tuyển" ToolTip="Mã vị trí cần tuyển"
                                                        BackColor="#f6f7f7" ktra="ns_ma_cdanh,ncdanh,ma,ten" f_tkhao="~/App_form/ns/ma/ns_ma_cdanh.aspx"
                                                        kieu_chu="true" CssClass="css_form" Width="137px" onchange="ns_td_hsuv_P_KTRA('MA_CDANH')" placeholder="Nhấn F1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label5" runat="server" Text="Giới tính" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:DR_nhap ID="gtinh" ten="Giới tính" runat="server" kieu="U" CssClass="css_form"
                                                        Width="137px" DataTextField="ten" DataValueField="ma" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Ngày sinh" Width="70px" CssClass="css_gchu_c" />
                                                </td>
                                                <td>
                                                    <div class="ip-group date">
                                                        <span class="ip-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                                        <Cthuvien:ngay  placeholder='dd/MM/yyyy' ID="nsinh" ten="Ngày sinh" runat="server" CssClass="css_form_c" kieu_luu="I"
                                                            Width="111px" kt_xoa="X" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label14" runat="server" Text="Trình độ" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="trinh_do" ten="Trình độ" runat="server" kt_xoa="X" CssClass="css_form"
                                            Width="350px" kieu_unicode="true" TextMode="MultiLine" Height="50px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label3" runat="server" Text="Kinh nghiệm" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="kinh_nghiem" ten="Kinh nghiệm" runat="server" kt_xoa="X" CssClass="css_form"
                                            Width="350px" kieu_unicode="true" TextMode="MultiLine" Rows="2" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label7" runat="server" Text="Kỹ năng" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:ma ID="ky_nang" ten="Kỹ năng" runat="server" kt_xoa="X" CssClass="css_form"
                                            Width="350px" kieu_unicode="true" TextMode="MultiLine" Rows="2" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label8" runat="server" Text="Ghi chú" Width="90px" CssClass="css_gchu" />
                                    </td>
                                    <td align="left">
                                        <Cthuvien:nd ID="note" ten="Ghi chú" runat="server" kt_xoa="X" CssClass="css_form"
                                            Width="350px" kieu_unicode="true" TextMode="MultiLine" Height="50px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table id="UPa_nhap" cellpadding="1" cellspacing="1" class="box3 txRight">
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    <div class="box3 txRight">
                                                        <a href="#" onclick="return ns_td_hsuv_P_NH();form_P_LOI();" class="bt bt-grey"><i class="fa fa-save"></i><span class="txUnderline">N</span>hập</a>
                                                        <a href="#" onclick="return ns_td_hsuv_P_MOI();form_P_LOI();" class="bt bt-grey"><span class="txUnderline">M</span>ới</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_td_hsuv_P_XOA();form_P_LOI();"><i class="fa fa-trash-o"></i><span class="txUnderline">X</span>óa</a>
                                                        <a href="#" onclick="return form_P_TRA_CHON('CMT,TEN,NSINH,TRINH_DO,KINH_NGHIEM,KY_NANG,NOTE');form_P_LOI();" class="bt bt-grey"><span class="txUnderline">C</span>họn</a>
                                                        <a href="#" id="A1" runat="server" class="bt bt-grey" onclick="return nhap_file();form_P_LOI();"><span class="txUnderline">F</span>ile</a>
                                                        <a href="#" class="bt bt-grey" onclick="return ns_td_hsuv_LICHSU();form_P_LOI();"><span class="txUnderline">L</span>ịch sử</a>
                                                    </div>
                                                </td>
                                                <%--<td>
                                        <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_td_hsuv_P_NH();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_td_hsuv_P_MOI();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_td_hsuv_P_XOA();form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="chon" runat="server" Text="Chọn" CssClass="css_button" OnClick="return form_P_TRA_CHON('CMT,TEN,NSINH,TRINH_DO,KINH_NGHIEM,KY_NANG,NOTE');form_P_LOI();"
                                            Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="file" runat="server" Text="File" CssClass="css_button" Width="70px" />
                                    </td>
                                    <td>
                                        <Cthuvien:nhap ID="lichsu" runat="server" Text="Lịch sử" CssClass="css_button" OnClick="return ns_td_hsuv_LICHSU();form_P_LOI();"
                                            Width="70px" />
                                    </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div id="UPa_gchu" class="css_border" align="left" style="margin-top: 110px;">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K"  />
                            </div>
                        </td>

                    </tr>
                    <%--<tr>
                        <td colspan="2" class="css_border" align="left">
                            <div id="UPa_gchu">
                                <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                            </div>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
    </table>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1050,500" />
    </div>

    <script language="javascript" type="text/javascript">
        var ns_td_hsuv_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_nhom_cdanhId, b_ma_cdanhId, b_timId, b_gchuId = '<%=gchu.ClientID%>';
        function ns_td_hsuv_P_KD() {
            ns_td_hsuv_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
            b_gocId = form_Fs_TEN_ID(b_vungId, 'CMT'),
            b_nhom_cdanhId = form_Fs_TEN_ID(b_vungId, 'NHOM_CDANH'), b_ma_cdanhId = form_Fs_TEN_ID(b_vungId, 'MA_CDANH');
            b_slideId = b_grlkeId + '_slide';
            ns_td_hsuv_lkeCho = setInterval('ns_td_hsuv_P_LKE_CHO()', 200);
        }

        function P_KET_QUA(b_dtuong, a_tso) {
            try {
                if (b_dtuong == null || b_dtuong == "") return;
                b_dtuong = b_dtuong.toUpperCase();
                var b_kq = a_tso[0];
                if (b_dtuong.indexOf("NHOM_CDANH") >= 0) {
                    $get(b_nhom_cdanhId).value = b_kq;
                    $get(b_gchuId).innerHTML = a_tso[1];
                    $get(b_ma_cdanhId).focus();
                }
                else if (b_dtuong.indexOf("MA_CDANH") >= 0) {
                    var b_nhom_cdanh = $get(b_nhom_cdanhId).value;
                    if (b_nhom_cdanh != a_tso[2]) {
                        alert("Vi tri cong viec khong thuoc nhom cong viec da chon");
                    }
                    else {
                        $get(b_ma_cdanhId).value = b_kq;
                        $get(b_gchuId).innerHTML = a_tso[1];
                        $get(b_gocId).focus();
                    }
                }
            }
            catch (err) { form_P_LOI(err); }
        }

        function ns_td_hsuv_P_KTRA(b_maTen) {
            try {
                var b_maId = "";
                b_maTen = b_maTen.toUpperCase();
                switch (b_maTen) {
                    case "NHOM_CDANH": b_maId = b_nhom_cdanhId; form_P_MOI("", "XGL"); break;
                    case "MA_CDANH": b_maId = b_ma_cdanhId; break;
                    case "CMT": b_maId = b_gocId; break;
                }
                var b_ma = $get(b_maId);
                if (b_ma == null || C_NVL(b_ma.value) == "") return;
                if (b_maTen == "NHOM_CDANH") {
                    skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_td_hsuv_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                }
                else if (b_maTen == "MA_CDANH") {
                    var b_nhom_cdanh = $get(b_nhom_cdanhId).value;
                    sns_ma_ch.Fs_NS_MA_CDANH_HOI(b_nhom_cdanh, b_ma.value, ns_td_hsuv_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                }
                else if (b_maTen == "CMT") {
                    var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
                    b_hang = GridX_Fi_timHangD(b_grlkeId, "CMT", b_ma.value);
                    if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_td_hsuv_P_MA_KTRA(); }
                    else { GridX_datA(b_grlkeId, b_hang); ns_td_hsuv_P_CHUYEN_HANG(); }
                    b_ten.focus();
                }
                else { GridX_thoiA(b_grlkeId); form_P_MOI("", "X"); }
            }
            catch (err) { form_P_LOI(err); }
        }
        function ns_td_hsuv_P_DatGchu(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
            else {
                var a_kq = Fas_ChMang(b_kq, '#');
                if (a_kq.length > 1) { $get(b_gchuId).value = a_kq[1]; $get(b_ma_cdanhId).value = a_kq[0]; }
                else form_P_DatGchu(b_gchuId, b_kq);
            }
        }
        function ns_td_hsuv_P_MA_KTRA() {
            try {
                var b_ma = C_NVL($get(b_gocId).value);
                if (b_ma != "") {
                    var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
                    sns_td.Fs_NS_TD_HSUV_MA(b_ma, b_TrangKt, a_cot, ns_td_hsuv_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                }
            }
            catch (err) { form_P_LOI(err); }
        }
        function ns_td_hsuv_P_MA_KTRA_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var a_kq = Fas_ChMang(b_kq, '#');
            var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
            GridX_datBang(b_grlkeId, a_kq[3]);
            slide_P_MOI(b_slideId, b_trang, b_soDong);
            if (b_hang < 1) form_P_MOI(b_vungId, "X");
            else { GridX_datA(b_grlkeId, b_hang); ns_td_hsuv_P_CHUYEN_HANG(); }
        }

        var ns_td_hsuv_choAct = 0;
        function ns_td_hsuv_GR_lke_RowChange() {
            if (ns_td_hsuv_choAct != 0) clearTimeout(ns_td_hsuv_choAct);
            ns_td_hsuv_choAct = setTimeout("ns_td_hsuv_P_CHUYEN_HANG()", 300);
            return false;
        }

        function ns_td_hsuv_P_LKE_CHO() {
            if ($get(b_grlkeId) != null) { clearTimeout(ns_td_hsuv_lkeCho); ns_td_hsuv_P_LKE(); }
        }

        function ns_td_hsuv_P_NH() {
            var b_loi = form_Fs_TEXT_KTRA(b_vungId);
            if (b_loi != "") { form_P_LOI(b_loi); return false; }
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_td.Fs_NS_TD_HSUV_NH(b_TrangKt, a_dt_ct, a_cot, ns_td_hsuv_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        function ns_td_hsuv_P_NH_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
            else {
                var a_kq = Fas_ChMang(b_kq, '#');
                var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
                slide_P_MOI(b_slideId, b_trang, b_soDong);
                GridX_datBang(b_grlkeId, a_kq[3]);
                if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
                $get(b_gocId).focus();
            }
        }
        function ns_td_hsuv_P_MOI() {
            form_P_MOI(b_vungId, "GXL");
            $get(b_gocId).focus();
        }

        function ns_td_hsuv_P_XOA() {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            var b_loi = form_Fs_TEXT_KTRA(b_vungId);
            if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

            var message = confirm("Bạn có chắc chắn xóa không?");
            if (message == false) { return false; }
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang < 1) return;
            var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "cmt");
            if (b_ma == "") ns_td_hsuv_P_MOI();
            else {
                var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
                sns_td.Fs_NS_TD_HSUV_XOA(b_ma, a_tso, a_cot, ns_td_hsuv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            return false;
        }
        function ns_td_hsuv_P_XOA_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
            else {
                var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
                if (b_hang > 1) b_hang--;
                else b_hang = GridX_Fi_hangSo(b_grlkeId);
                slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
                if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_td_hsuv_P_MOI();
                else { GridX_datA(b_grlkeId, b_hang); ns_td_hsuv_P_CHUYEN_HANG(); }
            }
        }
        function ns_td_hsuv_P_CHUYEN_HANG() {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang < 1) return;
            var b_cmt = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "cmt"));
            if (b_cmt == "") form_P_MOI(b_vungId, "XGL");
            else sns_td.Fs_NS_TD_HSUV_CT(b_cmt, ns_td_hsuv_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        function ns_td_hsuv_P_CHUYEN_HANG_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            form_P_CH_TEXT(b_vungId, b_kq);
        }

        function ns_td_hsuv_P_LKE() {
            try {
                var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
                sns_td.Fs_NS_TD_HSUV_LKE(a_tso, a_cot, ns_td_hsuv_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            catch (err) { form_P_LOI(err); }
        }

        function ns_td_hsuv_P_LKE_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
            var a_kq = Fas_ChMang(b_kq, '#');
            slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
            GridX_datBang(b_grlkeId, a_kq[1]);
        }
        function form_dong() {
            location.reload(false);
        }
    </script>
</asp:Content>
