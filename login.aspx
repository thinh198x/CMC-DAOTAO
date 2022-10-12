<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="f_login"
    Title="login" EnableEventValidation="false" MasterPageFile="~/trangnen.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="display: none;">
        <Cthuvien:luu ID="Luu1" runat="server" />
    </div>
    <div class="login-page">
        <div class="centered">
            <div class="login-default">
                <div class="login-body">
                    <form>
                        <div class="img-logo">
                            <img src="images/eDoc/logo.png" />
                        </div>
                        <div class="ver_pm">Phiên bản 2.1.9</div>
                        <Cthuvien:ma ID="MA_NSD" runat="server" CssClass="btn-input" kieu_chu="True" kt_xoa="X"
                            ToolTip="Mã người sử dụng" ten="mã NSD" Text="" />
                        <Cthuvien:ma ID="pas" runat="server" CssClass="btn-input" kt_xoa="X" TextMode="Password" PasswordMode="True" Text="CMCSoftw@re" />
                        <div class="remember_login">
                            <input type="checkbox" checked="checked">
                            <span>Nhớ mật khẩu</span>
                        </div>
                        <div class="submit_login">
                            <Cthuvien:nhap ID="log" runat="server" anh="K" Class="bt" Text="Đăng nhập" OnClick="return login_P_NH();" />
                        </div>
                        <div class="div_cm">
                            <span>Hệ thống quản trị nguồn nhân lực</span>
                        </div>
                        <div class="tbloi_dn" style="display: none">
                            <span>Bạn nhập sai mật khẩu</span>
                        </div>
                    </form>
                </div>
            </div>
            <div class="footer-login text-right ">
                <span class="b_left">Human Resources Management</span>
                <span class="b_right">© 1997-2018 by CMCSoftware. All rights reserved.</span>
            </div>
        </div>
    </div>
    <Cthuvien:an ID="tm" runat="server" />
    <script>
        function login_P_NH() {
            try {
                var b_nsd = C_NVL($get('<%=MA_NSD.ClientID%>').value).toUpperCase(), b_pas = $get('<%=pas.ClientID%>').value,
                    b_duyet = '<%=this.Request.Browser.Browser%>', b_tm = $get('<%=tm.ClientID%>').value;
                if (b_nsd == '') login_NH_KQ('loi:Nhập mã NSD:loi');
                else sht_ma.Fs_LOGIN('NS', b_nsd, b_pas, b_duyet, b_tm, login_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                return false;
            }
            catch (ex) { form_P_LOI(ex.message); }
        }
        function login_NH_KQ(b_kq) {
            if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
            else {
                form_P_DONG('', null);
                location.assign('<%=this.ResolveUrl("~/menuL.aspx")%>');
            }
        }
    </script>
</asp:Content>
