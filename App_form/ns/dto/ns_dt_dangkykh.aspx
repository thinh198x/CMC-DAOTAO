<%@ Page Title="ns_dt_dangkykh" Language="C#" MasterPageFile="~/trangnen.master" AutoEventWireup="true"
    CodeFile="ns_dt_dangkykh.aspx.cs" Inherits="f_ns_dt_dangkykh" %>

<%@ Register Src="~/App_ctr/khud/ctr_khud_divL.ascx" TagName="ctr_khud_divL" TagPrefix="ctr_khud_divL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content" class="container_content hide_sbar">
        <div class="r_c_content b_right">
            <div class="title_dmuc width_common">
                <Cthuvien:luu ID="tenForm" runat="server" Text="Danh sách khóa học" />
                <img class="b_right" src="../../../images/edoc/icon_close.png" alt="" onclick="return form_dong();" />
            </div>
            <div class="width_common auto_sc">
                <div class="b_left col_100 inner" id="UPa_tk">
                    <div class="col_2_iterm width_common">
                        <div class="b_left form-group iterm_form">
                            <span class="standard_label b_left col_30">Tình trạng</span>
                            <div class="input-group">
                                <Cthuvien:DR_nhap ID="tinhtrang" ten="Tình trạng" runat="server" DataTextField="ten" DataValueField="ma"
                                    CssClass="form-control" kieu="S" onchange="ns_dt_dangkykh_P_KTRA('tinhtrang')">
                                    <asp:ListItem Text="Đang cho đăng ký" Value="1" />
                                    <asp:ListItem Text="Đã đủ học viên/Đóng ĐK" Value="2" />
                                    <asp:ListItem Text="Đang học" Value="3" />
                                    <asp:ListItem Text="Đã kết thúc" Value="4" />
                                </Cthuvien:DR_nhap>
                            </div>
                        </div>
                        <div class="b_right form-group iterm_form">
                        </div>
                    </div>
                    <div class="grid_table width_common">
                        <div>
                            <Cthuvien:GridX ID="GR_lke" runat="server" AutoGenerateColumns="false" PageSize="1" Width="100%"
                                CssClass="table gridX" loai="L" hangKt="15">
                                <Columns>
                                    <asp:BoundField DataField="leGrid" HeaderStyle-Width="10px" />
                                    <asp:BoundField HeaderText="Mã" DataField="ma" HeaderStyle-Width="100px" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Tên khóa đào tạo" DataField="ten" HeaderStyle-Width="50%" ItemStyle-CssClass="css_Gma" />
                                    <asp:BoundField HeaderText="Ngày tạo" DataField="ngaytrinh" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Từ ngày" DataField="ngayd" ItemStyle-CssClass="css_Gma_c" />
                                    <asp:BoundField HeaderText="Đến ngày" DataField="ngayc" ItemStyle-CssClass="css_Gma_c" />
                                </Columns>
                            </Cthuvien:GridX>
                        </div>
                        <div id="GR_lke_td" runat="server">
                            <ctr_khud_divL:ctr_khud_divL ID="GR_lke_slide" runat="server" loai="X" gridId="GR_lke" ham="ns_dt_dangkykh_P_LKE('K')" />
                        </div>
                    </div>
                    <div class="list_bt_action">
                        <button class="bt_action" onclick="return ns_dt_dangkykh_P_XEM();form_P_LOI();"><span class="txUnderline">X</span>em</button>
                        <button class="bt_action" onclick="return ns_dt_dangkykh_P_DANGKY();form_P_LOI();"><span class="txUnderline">Đ</span>ăng ký</button>
                        <button class="bt_action" onclick="return ns_dt_dangkykh_P_HUYDANGKY();form_P_LOI();"><span class="txUnderline">H</span>ủy đăng ký</button>

                    </div>
                    <div id="UPa_gchu">
                        <Cthuvien:gchu ID="gchu" runat="server" CssClass="css_gchu" kt_xoa="K" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="UPa_hi">
        <Cthuvien:an ID="so_id" runat="server" />
        <Cthuvien:an ID="kthuoc" runat="server" Value="1190,570" />
    </div>
</asp:Content>
