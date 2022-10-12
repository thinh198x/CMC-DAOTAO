<%@ Page Title="ns_td_lichsu" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_td_lichsu.aspx.cs" Inherits="f_ns_td_lichsu" %>
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
                     <Cthuvien:luu ID="Luu1" runat="server" CssClass="css_tieudeM" Text="Lịch sử tuyển dụng" />
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
            <td valign="middle" class="form_right">
                <table id="UPa_ct" runat="server" cellpadding="1" cellspacing="1" >
                    <tr>
                        <td align="left">
                            <table cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Số CMT/ Hộ chiếu" Width="150px" CssClass="css_gchu" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <Cthuvien:ma ID="CMT" ten="Số chứng minh thư hoặc hộ chiếu" runat="server" CssClass="css_form"
                                                        Width="100px" onchange="ns_td_lichsu_P_KTRA('CMT')" ToolTip="Số chưng minh thư hoặc hộ chiếu"
                                                        f_tkhao="~/App_form/ns/td/ns_td_hsuv.aspx" BackColor="#f6f7f7" placeholder="Nhấn F1"
                                                        ktra="ns_td_hsuv,cmt,ten" />
                                                </td>
                                                <td>
                                                    <Cthuvien:ma ID="TEN" ten="tên" ToolTip="Họ tên" kieu_so="true" runat="server" CssClass="css_form"
                                                        Width="150px" kt_xoa="K" ReadOnly="true" />
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
                                        <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1"
                                            CssClass="table gridX" loai="L" hangKt="13">
                                            <Columns>
                                                <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                                <asp:BoundField HeaderText="Năm" DataField="nam" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                                <asp:BoundField HeaderText="Đợt" DataField="dot" HeaderStyle-Width="30px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Ngày phỏng vấn" DataField="ngaypv" HeaderStyle-Width="90px"
                                                    ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Mã Chức danh" DataField="ma_cdanh" HeaderStyle-Width="90px"
                                                    ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Trình độ" DataField="trinhdo" HeaderStyle-Width="150px"
                                                    ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Kinh nghiệm" DataField="kinhnghiem" HeaderStyle-Width="150px"
                                                    ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Kỹ năng" DataField="kynang" HeaderStyle-Width="150px"
                                                    ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="ghi chú" DataField="note" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gnd" />
                                                <asp:BoundField HeaderText="Kết quả" DataField="ketqua" HeaderStyle-Width="90px"
                                                    ItemStyle-CssClass="css_Gnd" />
                                            </Columns>
                                        </Cthuvien:GridX>
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
        <Cthuvien:an ID="kthuoc" runat="server" Value="1080,450" />
    </div>
    <script language="javascript" type="text/javascript">
        var ns_td_lichsu_lkeCho, b_vungId, b_grlkeId, b_slideId,
        b_so_idId = '<%=so_id.ClientID%>', b_gchuId = '<%=gchu.ClientID%>';

        function ns_td_lichsu_P_KD() {
            ns_td_lichsu_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
            b_cmtId = form_Fs_TEN_ID(b_vungId, 'CMT'), b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'),
            b_slideId = b_grlkeId + '_slide';
        }
        function P_KET_QUA(b_dtuong, a_tso) {
            try {
                if (b_dtuong == null || b_dtuong == "") return;
                b_dtuong = b_dtuong.toUpperCase();
                if (b_dtuong.indexOf("CMT") >= 0) {
                    $get(b_cmtId).value = a_tso[0];
                    $get(b_tenId).value = a_tso[1];
                    ns_td_lichsu();
                }
            }
            catch (err) { form_P_LOI(err); }
        }
        function ns_td_lichsu_P_KTRA(b_maTen) {
            try {
                var b_maId = "";
                b_maTen = b_maTen.toUpperCase();
                switch (b_maTen) {
                    case "CMT": b_maId = b_cmtId; break;
                }
                var b_ma = $get(b_maId);
                if (b_ma == null || C_NVL(b_ma.value) == "") return;
                if (b_maTen == "CMT") {
                    skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_td_lichsu_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
                    ns_td_lichsu();
                }
            }
            catch (err) { form_P_LOI(err); }
        }

        function ns_td_lichsu_P_DatGchu(b_kq) { $get(b_tenId).value = b_kq; return; }

        function ns_td_lichsu() {
            var b_cmt = $get(b_cmtId).value,
                a_cot_ct = GridX_Fas_tenCot(b_grlkeId);
            sns_td.Fs_NS_TD_KQ_LICHSU(b_cmt, a_cot_ct, ns_td_lichsu_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        function ns_td_lichsu_KQ(b_kq) {
            if (b_kq == "") GridX_datTrang(b_grlkeId);
            else GridX_datBang(b_grlkeId, b_kq);
        }
        function form_dong() {
            location.reload(false);
        }
    </script>
</asp:Content>
