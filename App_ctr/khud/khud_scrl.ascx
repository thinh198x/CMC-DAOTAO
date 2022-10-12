<%@ Control Language="C#" AutoEventWireup="true" CodeFile="khud_scrl.ascx.cs" Inherits="khud_scrl" className="khud_scrl" %>

<table cellpadding="0" cellspacing="0">
    <tr>
        <td align="center">
            <img id="len" runat="server" alt="" src="~/images/bitmaps/len.gif" />
        </td>
    </tr>
    <tr>
        <td class="css_scrl">
            <asp:TextBox ID="an" runat="server" Text="1" />
            <AjaxTk:SliderExtender ID="slide" runat="server" TargetControlID="an" BoundControlID="hien" 
                Minimum="1" Maximum="1" EnableHandleAnimation="true" Orientation="Vertical" />
            <label id="hien" runat="server" style="display:none;">1</label>
            <label id="trang" runat="server" style="display:none;">1</label>
        </td>
    </tr>
    <tr>
        <td align="center" valign="middle" style="height:16px;">
            <img id="xuong" runat="server" alt="" src="~/images/bitmaps/xuong.gif" />
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
