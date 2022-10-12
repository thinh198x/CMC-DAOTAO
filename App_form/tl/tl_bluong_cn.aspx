<%@ Page Title="tl_bluong_cn" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="tl_bluong_cn.aspx.cs" Inherits="f_tl_bluong_cn" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Phiếu Lương" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_ct">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Năm</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="NAM" ten="Năm" runat="server" onchange="tl_bluong_cn_P_NAM();" CssClass="form-control css_list" ktra="DT_NAM" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Kỳ lương</span>
                            <div class="input-group">
                                <Cthuvien:DR_lke ID="KYLUONG" ten="Bảng lương" runat="server" CssClass="form-control css_list"
                                    onchange="tl_bluong_cn_P_LKE()" ktra="DT_KY" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Mã nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="SO_THE" ten="Số thẻ" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    kt_xoa="K" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Tên nhân viên</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ho_ten" ten="Số thẻ" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    kt_xoa="K" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Chức danh</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_cdanh" ten="Chức danh" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    kt_xoa="K" Enabled="false" />
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                            <span class="standard_label lv2 b_left col_30">Đơn vị</span>
                            <div class="input-group">
                                <Cthuvien:ma ID="ten_phong" ten="Đơn vị" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    kt_xoa="K" Enabled="false" />
                            </div>
                            <div class="input-group" style="display: none">
                                <Cthuvien:ma ID="CO_LANHDAO" ten="Đối tượng" runat="server" CssClass="form-control css_ma" BackColor="#f6f7f7"
                                    kt_xoa="K" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div style="height: 600px; overflow-y: scroll;">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="L"
                                hangKt="60" gchuId="gchu" cotAn="DVT">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                    <asp:BoundField HeaderText="Số TT" DataField="SOTT" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Nội dung" DataField="TEN" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Giá trị" DataField="LUONG" HeaderStyle-Width="130px" ItemStyle-CssClass="css_Gso" />
                                    <asp:BoundField HeaderText="ĐVT" DataField="DVT" HeaderStyle-Width="250px" ItemStyle-CssClass="css_Gma_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>

                    </div>
                    <div class="width_common" style="margin: 20px 20px 20px 20px;">
                        <Cthuvien:gchu ID="lbllienhe" runat="server" CssClass="css_gchu" kt_xoa="K"
                            Text="Anh/chị có thắc mắc về lương tháng ...... vui lòng phản hồi lại BP DVNS để được giải đáp trước ngày ........." />
                        <Cthuvien:gchu ID="lblthacmac" runat="server" CssClass="css_gchu" kt_xoa="K"
                            Text="Mọi thắc mắc xin liên hệ : Nguyễn Thị Điệp - 09121 99 486 - diepnt@chgroup.vn" />
                    </div>
                    <div class="list_bt_action" id="UPa_nhap" style="display: none">
                        <div style="display: none">
                            <Cthuvien:nhap ID="chuyentien" runat="server" Text="In lệnh chuyển tiền" CssClass="css_button"
                                OnClick="return tl_bluong_cn_P_CHUYEN_TIEN();form_P_LOI();" Width="150px" />
                        </div>
                        <button class="bt_action" onclick="return tl_bluong_cn_P_IN();form_P_LOI();"><span class="txUnderline">I</span>n</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="900,800" />
    </div>
</asp:Content>
