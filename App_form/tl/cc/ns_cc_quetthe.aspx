<%@ Page Title="ns_cc_quetthe" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_cc_quetthe.aspx.cs" Inherits="f_ns_cc_quetthe" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Dữ liệu quẹt thẻ" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc line_55">
                <div class="b_left col_50 inner" id="UPa_tk">

                    <div class="grid_table width_common">
                        <div style="overflow: auto;">
                            <Cthuvien:GridX ID="GR_ct" runat="server" AutoGenerateColumns="false" PageSize="1"
                                CssClass="table gridX" loai="L"
                                hangKt="22" gchuId="gchu">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="21px" />
                                    <asp:BoundField HeaderText="Số TT" DataField="STT" HeaderStyle-Width="50px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Quẹt vân tay" DataField="VAN_TAY" HeaderStyle-Width="200px" ItemStyle-CssClass="css_Gma" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div id="GR_lke_td" runat="server" align="center">
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_ct" ham="ns_cc_quetthe_P_LKE('K')" /> 
                        </div>
                    </div>

                </div>
                <div class="b_right col_50 inner" id="UPa_ct">
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Số thẻ</span>
                        <div class="input-group">
                            <Cthuvien:ma ID="SO_THE" ten="Số thẻ" runat="server" CssClass="form-control css_ma" kieu_chu="True" BackColor="#f6f7f7" ReadOnly="true"
                                kt_xoa="K" Width="150px" />
                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Từ ngày</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYD" runat="server" CssClass="form-control icon_lich" Width="150px" />

                        </div>
                    </div>
                    <div class="b_left width_common form-group iterm_form">
                        <span class="standard_label lv2 b_left col_30">Đến ngày</span>
                        <div class="input-group">
                            <Cthuvien:ngay placeholder='dd/MM/yyyy' ID="NGAYC" runat="server" CssClass="form-control icon_lich" Width="150px" />

                        </div>
                    </div>
                    <div class="list_bt_action">
                        <button onclick="return ns_cc_quetthe_P_LKE('K');form_P_LOI();" class="bt_action"><span class="txUnderline">T</span>ìm</button>
                        <div style="display: none">
                            <Cthuvien:nhap ID="nhap" runat="server" Text="Nhập" CssClass="css_button" OnClick="return ns_cc_quetthe_P_NH();form_P_LOI();"
                                Width="70px" />
                        </div>
                        <div style="display: none">
                            <Cthuvien:nhap ID="moi" runat="server" Text="Mới" CssClass="css_button" OnClick="return ns_cc_quetthe_P_MOI();form_P_LOI();"
                                Width="70px" />
                        </div>
                        <div style="display: none">
                            <Cthuvien:nhap ID="xoa" runat="server" Text="Xóa" CssClass="css_button" OnClick="return ns_cc_quetthe_P_XOA();form_P_LOI();"
                                Width="70px" />
                        </div>
                        <div style="display: none">
                            <Cthuvien:nhap ID="chuyentien" runat="server" Text="In lệnh chuyển tiền" CssClass="css_button"
                                OnClick="return ns_cc_quetthe_P_CHUYEN_TIEN();form_P_LOI();" Width="150px" />
                        </div>
                        <div style="display: none">
                            <Cthuvien:nhap ID="in" runat="server" Text="In" CssClass="css_button" OnClick="return ns_cc_quetthe_P_IN();form_P_LOI();"
                                Width="70px" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="kthuoc" runat="server" Value="730,710" />
    </div>
</asp:Content>
