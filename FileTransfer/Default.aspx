<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FileTransfer.Default" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 214px;
        }
        .auto-style2 {
            width: 299px;
        }
        .auto-style3 {
            width: 214px;
            height: 158px;
        }
        .auto-style4 {
            width: 299px;
            height: 158px;
        }
        .auto-style5 {
            height: 158px;
        }
        .auto-style6 {
            width: 214px;
            height: 131px;
        }
        .auto-style7 {
            width: 299px;
            height: 131px;
        }
        .auto-style8 {
            height: 131px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="ScriptManager1" runat="server" EnableTheming="True">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">From:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox1" runat="server" Width="289px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">To:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox2" runat="server" Width="287px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Message:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBox3" runat="server" Height="130px" Width="292px"></asp:TextBox>
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style6">Files:</td>
                <td class="auto-style7">
    
        <telerik:RadAsyncUpload ID="FileUploader" runat="server" Height="33px" Width="275px" MaxFileSize="2000000000" MultipleFileSelection="Automatic" OnFileUploaded="FileUploader_FileUploaded" TargetFolder="Uploaded" TemporaryFileExpiration="02:00:00" TemporaryFolder="Temp">
        </telerik:RadAsyncUpload>
                    <br />
    
                </td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="SendButton" runat="server" OnClick="SendButton_Click" Text="Send!" />
                    <br />
                </td>
                <td>
                    <asp:Panel ID="ValidFiles" Visible="false" runat="server" CssClass="qsf-success">
                    <h3>You successfully uploaded:</h3>
                    <ul class="qsf-list" runat="server" id="ValidFilesList"></ul>
                </asp:Panel>
 
                <asp:Panel ID="InvalidFiles" Visible="false" runat="server" CssClass="qsf-error">
                    <h3>The Upload failed for:</h3>
                    <ul class="qsf-list ruError" runat="server" id="InValidFilesList">
                        <li>
                            <p class="ruErrorMessage">The size of your overall upload exceeded the maximum of <asp:Label ID="MaxFileSizeLabel" runat="server" ></asp:Label> MB</p>
                        </li>
                    </ul>
                    </asp:Panel>
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
