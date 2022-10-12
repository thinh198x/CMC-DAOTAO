<%@ Page Title="ns_cb_qly_pd" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cb_qly_pd.aspx.cs" Inherits="f_ns_cb_qly_pd" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Phê duyệt thông tin CBNV" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_right col_100 inner" id="UPa_ct">
                    <div id="NPa" runat="server" class="navi_tabngang width_common">
                        <Cthuvien:tab ID="NPa_syll" runat="server" CssClass="css_tab_ngang_ac" Width="148px"
                            Height="20px" Text="Sơ yếu lý lịch" />
                        <Cthuvien:tab ID="NPa_qtct" runat="server" CssClass="css_tab_ngang_de" Width="270px"
                            Height="20px" Text="Quá trình công tác trước khi vào công ty" />
                        <Cthuvien:tab ID="NPa_bccm" runat="server" CssClass="css_tab_ngang_de" Width="148px"
                            Height="20px" Text="Bằng cấp chuyên môn" />
                        <Cthuvien:tab ID="NPa_cc" runat="server" CssClass="css_tab_ngang_de" Width="100px"
                            Height="20px" Text="Chứng chỉ" />
                        <Cthuvien:tab ID="NPa_qhnt" runat="server" CssClass="css_tab_ngang_de" Width="148px"
                            Height="20px" Text="Quan hệ nhân thân" />
                    </div>
                    <div>
                        <asp:Panel ID="Pa_syll" runat="server" Style="display: block;">
                            <div style="width: 100%; overflow-x: scroll">
                                <Cthuvien:GridX ID="GR_syll" cot="chon,so_the,ten,phong,ten_cdanh,dtnr,dtdd,ten_tt_honnhan,socmt9,ngay_cmt9,nc_cmt9,socmt,ngay_cmt,nc_cmt,dchi_thuongtru,ten_tt_thuongtru,ten_qh_thuongtru,ten_xp_thuongtru,dchi_tamtru,ten_tt_tamtru,ten_qh_tamtru,ten_xp_tamtru,hoten_ll,ten_quanhe_ll,sdt_ll,khican_ll,url"
                                    runat="server" hamRow="ns_cb_qly_pd_GR_lke_RowChange()" Width="100%" hangKt="20"
                                    cotAn="dtdd,ten_tt_honnhan,dchi_tamtru,ten_tt_tamtru,ten_qh_tamtru,ten_xp_tamtru,url"
                                    AutoGenerateColumns="false" PageSize="1" loai="X" CssClass="table gridX">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" ItemStyle-CssClass="css_Gma" />
                                        <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40">
                                            <ItemTemplate>
                                                <Cthuvien:kieu ID="chon" runat="server" lke="X," Width="40px" kt_xoa="X" ToolTip="X -" CssClass="css_Gma_c" Text="X" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Mã NV" DataField="so_the" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Họ tên" DataField="ten" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Phòng/ ban" DataField="phong" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Chức danh" DataField="ten_cdanh" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="ĐT nhà riêng" DataField="dtnr" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="ĐT di động" DataField="dtdd" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Hôn nhân" DataField="ten_tt_honnhan" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Điện thoại nhà riêng" DataField="dtnr" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Số CMT theo MST" DataField="socmt9" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Ngày cấp" DataField="ngay_cmt9" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Nơi cấp" DataField="nc_cmt9" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Số CMT mới nhất" DataField="socmt" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Ngày cấp" DataField="ngay_cmt" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Nơi cấp" DataField="nc_cmt" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Địa chỉ thường trú" DataField="dchi_thuongtru" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Tỉnh/Thành phố thường trú" DataField="ten_tt_thuongtru" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Quận/Huyện thường trú" DataField="ten_qh_thuongtru" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Xã/Phường thường trú" DataField="ten_xp_thuongtru" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Địa chỉ hiện tại" DataField="dchi_tamtru" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Tỉnh/Thành phố hiện tại" DataField="ten_tt_tamtru" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Quận/huyện hiện tại" DataField="ten_qh_tamtru" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Xã/phường hiện tại" DataField="ten_xp_tamtru" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" /> 
                                        <asp:BoundField HeaderText="Họ tên người liên hệ" DataField="hoten_ll" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Quan hệ" DataField="ten_quanhe_ll" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Số ĐT" DataField="sdt_ll" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Địa chỉ" DataField="khican_ll" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="File đính kèm" DataField="url" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_syll_slide" runat="server" loai="X" gridId="GR_syll" ham="ns_cb_qly_pd_P_LKE()" />
                        </asp:Panel>

                        <asp:Panel ID="Pa_qtct" runat="server" Style="display: none;">
                            <div style="width: 100%; overflow-x: scroll">
                                <Cthuvien:GridX ID="GR_qtct" hamRow="ns_cb_qly_pd_GR_khac_RowChange()" cotAn="so_id" cot="chon,so_the,ten,tencty,dccty,sodt,ngayd,ngayc,mucluong,cdanh,lydo,so_id" runat="server" hangKt="20" AutoGenerateColumns="false" PageSize="1" loai="X" CssClass="gridX">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" ItemStyle-CssClass="css_Gma" />
                                        <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40">
                                            <ItemTemplate>
                                                <Cthuvien:kieu ID="chon" runat="server" lke="X," Width="40px" kt_xoa="X" ToolTip="X -" CssClass="css_Gma_c" Text="X" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Mã NV" DataField="SO_THE" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Họ tên" DataField="TEN" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Tên công ty" DataField="tencty" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Địa chỉ" DataField="dccty" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="SĐT" DataField="sodt" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Ngày vào" DataField="ngayd" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Ngày nghỉ việc" DataField="ngayc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Mức lương" DataField="mucluong" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_r" />
                                        <asp:BoundField HeaderText="Chức danh" DataField="cdanh" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Lý do nghỉ việc" DataField="lydo" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField DataField="so_id" HeaderStyle-Width="10px" ItemStyle-CssClass="css_Gma" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_qtct_slide" runat="server" loai="X" gridId="GR_qtct" ham="ns_cb_qly_pd_P_LKE()" />
                        </asp:Panel>
                        <asp:Panel ID="Pa_bccm" runat="server" Style="display: none;">
                            <div style="width: 100%; overflow-x: scroll">
                                <Cthuvien:GridX ID="GR_bccm" hamRow="ns_cb_qly_pd_GR_khac_RowChange()" runat="server" cotAn="so_id"
                                    cot="chon,so_the,ten,thangd,thangc,nam_tn,ten_truong,ten_trinhdo,tinhtrang,hinhthuc,ten_cnganh,sohieu,ngaycap,so_id" hangKt="20" AutoGenerateColumns="false" PageSize="1" loai="X" CssClass="gridX">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" ItemStyle-CssClass="css_Gma" />
                                        <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40">
                                            <ItemTemplate>
                                                <Cthuvien:kieu ID="chon" runat="server" lke="X," Width="40px" kt_xoa="X" ToolTip="X -" CssClass="css_Gma_c" Text="X" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Mã NV" DataField="SO_THE" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Họ tên" DataField="TEN" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Từ tháng" DataField="THANGD" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Đến tháng" DataField="THANGC" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Năm TN" DataField="NAM_TN" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Tên trường" DataField="TEN_TRUONG" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Trình độ" DataField="TEN_TRINHDO" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Là bằng cấp chính" DataField="TINHTRANG" HeaderStyle-Width="70px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Hình thức ĐT" DataField="HINHTHUC" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Chuyên ngành ĐT" DataField="TEN_CNGANH" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Số hiệu bảng" DataField="SOHIEU" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Ngày cấp" DataField="NGAYCAP" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField DataField="so_id" HeaderStyle-Width="10px" ItemStyle-CssClass="css_Gma" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_bccm_slide" runat="server" loai="X" gridId="GR_bccm" ham="ns_cb_qly_pd_P_LKE()" />
                        </asp:Panel>
                        <asp:Panel ID="Pa_cc" runat="server" Style="display: none;">
                            <div style="width: 100%; overflow-x: scroll">
                                <Cthuvien:GridX ID="GR_cc" hamRow="ns_cb_qly_pd_GR_khac_RowChange()" runat="server" cotAn="so_id"
                                    cot="chon,so_the,ten,loai_cc,ten_cchi,noidung,sohieu,cs_dtao,tu_ngay,den_ngay,ngay_hl,ngay_hhl,ten_ccc,ngay_hl_ccc,ngay_hhl_ccc,cam_ket,so_tien,so_thang,mota,ten_cchn,so_cchn,ngay_cap,thang_cap,ten_vung,ten_ubck,ten_qtrr,so_id"
                                    hangKt="20" AutoGenerateColumns="false" PageSize="1" loai="X" CssClass="table gridX">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" ItemStyle-CssClass="css_Gma" />
                                        <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40">
                                            <ItemTemplate>
                                                <Cthuvien:kieu ID="chon" runat="server" lke="X," Width="40px" kt_xoa="X" ToolTip="X -" CssClass="css_Gma_c" Text="X" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Mã NV" DataField="SO_THE" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Họ tên" DataField="TEN" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Loại chứng chỉ" DataField="loai_cc" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Tên chứng chỉ" DataField="ten_cchi" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Nội dung" DataField="noidung" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Số hiệu" DataField="sohieu" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Cơ sở đào tạo" DataField="cs_dtao" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Từ ngày" DataField="tu_ngay" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Đến ngày" DataField="den_ngay" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay_hl" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Ngày hết hiệu lực" DataField="ngay_hhl" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />

                                        <asp:BoundField HeaderText="Tên chứng chỉ con" DataField="ten_ccc" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Ngày hiệu lực" DataField="ngay_hl_ccc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Ngày hết hiệu lực" DataField="ngay_hhl_ccc" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Cam kết đào tạo" DataField="cam_ket" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Số tiền cam kết" DataField="so_tien" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_r" />
                                        <asp:BoundField HeaderText="Thời gian cam kết" DataField="so_thang" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Mô tả" DataField="mota" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />

                                        <asp:BoundField HeaderText="Tên chứng hành nghề" DataField="ten_cchn" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Số chứng chỉ" DataField="so_cchn" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Ngày cấp chứng chỉ" DataField="ngay_cap" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Tháng phát sinh" DataField="thang_cap" HeaderStyle-Width="80px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Vùng miền" DataField="ten_vung" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Đối tượng UBCK" DataField="ten_ubck" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Đối tượng QTRR" DataField="ten_qtrr" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />

                                        <asp:BoundField DataField="so_id" HeaderStyle-Width="10px" ItemStyle-CssClass="css_Gma" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_cc_slide" runat="server" loai="X" gridId="GR_cc" ham="ns_cb_qly_pd_P_LKE()" />
                        </asp:Panel>
                        <asp:Panel ID="Pa_qhnt" runat="server" Style="display: none;">
                            <div style="width: 100%; overflow-x: scroll">
                                <Cthuvien:GridX ID="GR_qhnt" runat="server" hamRow="ns_cb_qly_pd_GR_qtct_RowChange()"
                                    cot="chon,so_the,ten_nv,ten,ten_lqh,ngaysinh,maso_thue,so_cmt,ngay_cmt,dchi,sdt,noi_ctac,diachi_thuongchu,n_ngh,so,quyenso,ten_nn,ten_tinhthanh,ten_quanhuyen,ten_phuongxa,phuthuoc,ngayd,ngayc,note,url,so_id"
                                    cotAn="so_id,url" hangKt="20" AutoGenerateColumns="false" PageSize="1" loai="X" CssClass="gridX">
                                    <Columns>
                                        <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" ItemStyle-CssClass="css_Gma" />
                                        <asp:TemplateField HeaderText="Chọn" HeaderStyle-Width="40">
                                            <ItemTemplate>
                                                <Cthuvien:kieu ID="chon" runat="server" lke="X," Width="40px" kt_xoa="X" ToolTip="X -" CssClass="css_Gma_c" Text="X" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Mã nhân viên" DataField="SO_THE" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Tên nhân viên" DataField="TEN_NV" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Họ tên nhân thân" DataField="TEN" HeaderStyle-Width="150px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Mối quan hệ" DataField="TEN_LQH" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Ngày sinh" DataField="NGAYSINH" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Mã số thuế NPT" DataField="MASO_THUE" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Số CMTND/Thẻ CC" DataField="SO_CMT" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Ngày cấp" DataField="NGAY_CMT" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Nơi cấp" DataField="DCHI" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Số điện thoại" DataField="SDT" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Nơi công tác" DataField="NOI_CTAC" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Địa chỉ thường chú" DataField="DIACHI_THUONGCHU" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Nghề nghiệp" DataField="N_NGH" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Số sổ hộ khẩu" DataField="SO" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Quyển số" DataField="QUYENSO" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Quốc tịch" DataField="TEN_NN" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Tỉnh thành" DataField="TEN_TINHTHANH" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Quận huyện" DataField="TEN_QUANHUYEN" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Xã phường" DataField="TEN_PHUONGXA" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField HeaderText="Đối tượng giảm trừ" DataField="PHUTHUOC" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Ngày bắt đầu giảm trừ" DataField="NGAYD" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Ngày kết thúc giảm trừ" DataField="NGAYC" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="Mô tả" DataField="NOTE" HeaderStyle-Width="120px" ItemStyle-CssClass="css_Gma_c" />
                                        <asp:BoundField HeaderText="File đính kèm" DataField="url" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma" />
                                        <asp:BoundField DataField="so_id" HeaderStyle-Width="10px" ItemStyle-CssClass="css_Gma" />
                                    </Columns>
                                </Cthuvien:GridX>
                            </div>
                            <ctr_khud_divL:ctr_khud_divL ID="GR_qhnt_slide" runat="server" loai="X" gridId="GR_qhnt" ham="ns_cb_qly_pd_P_LKE()" />
                        </asp:Panel>
                    </div>
                    <div class="list_bt_action lv2">
                        <div class="col_3_iterm width_common">
                            <div class="b_left form-group iterm_form">
                                <Cthuvien:nhap ID="pheduyet" runat="server" class="bt_action" anh="K" Text="Phê duyệt" OnClick="ns_cb_qly_pd_P_DUYET();form_P_LOI('');" />
                                <Cthuvien:nhap ID="kopheduyet" runat="server" class="bt_action" anh="K" Text="Không phê duyệt" OnClick="ns_cb_qly_pd_P_KO_DUYET();form_P_LOI('');" />
                                <Cthuvien:nhap ID="download" runat="server" class="bt_action" anh="K" Text="Download" OnClick="ns_cb_qly_pd_P_Download();form_P_LOI('');" />
                                <Cthuvien:nhap ID="download2" runat="server" class="bt_action" anh="K" Text="Download" OnClick="ns_cb_qly_pd_P_Download_QHTN();form_P_LOI('');" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="1250,790" />
    </div>
</asp:Content>
