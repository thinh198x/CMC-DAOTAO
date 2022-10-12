<%@ Control Language="C#" AutoEventWireup="true" CodeFile="khud_slide.ascx.cs" Inherits="khud_slide" className="khud_slide" %>

<table cellpadding="0" cellspacing="0">
    <tr class="css_slide" >
        <td align="center" valign="middle" style="width:20px;">
            <img id="trai" runat="server" alt="" src="~/images/Left_n3.png" />
        </td>
        <td>
            <asp:TextBox ID="an" runat="server" Text="1" />
            <AjaxTk:SliderExtender ID="slide" runat="server" TargetControlID="an" BoundControlID="hien" 
                Minimum="1" Maximum="1" EnableHandleAnimation="true" />
        </td>
        <td align="right" valign="middle" style="width:30px;">
            <label id="hien" runat="server" class="css_gchu_a" />
        </td>
        <td valign="middle" style="width:5px;">
            <label class="css_gchu_a">/</label>
        </td>
        <td align="left" valign="middle" style="width:30px;">
            <label id="trang" runat="server" class="css_gchu_a">1</label>
        </td>
        <td align="center" valign="middle" style="width:20px;">
            <img id="phai" runat="server" alt="" src="~/images/Right_n3.png" />
        </td>
    </tr>
</table>
<script>
    Sys.UI.DomElement.setLocation = function Sys$UI$DomElement$setLocation(element, x, y) {
        x = Math.round(x);
        y = Math.round(y);
        var e = Function._validateParams(arguments, [
            { name: "element", domElement: true },
            { name: "x", type: Number, integer: true },
            { name: "y", type: Number, integer: true }
        ]);
        if (e) throw e;
        var style = element.style;
        style.position = 'absolute';
        style.left = x + "px";
        style.top = y + "px";
    }
    Sys.Extended.Deprecated = function (oldMethodName, properMethodName) {
    }
</script>
