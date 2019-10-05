<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NominationsRpt.aspx.cs" Inherits="SchoolManagementSystem.Report.NominationsRpt" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
           <%-- <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>--%>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" SizeToReportContent="True"
                ZoomMode="Percent" AsyncRendering="False" InteractivityPostBackMode="AlwaysAsynchronous"
                EnableViewState="True" ShowParameterPrompts="true" ShowPrintButton="true">
                <ServerReport ReportPath="/NHAMISReport/rptNominations" ReportServerUrl="http://41.204.161.195/ReportServer_rpt"
                    DisplayName="TX" />
            </rsweb:ReportViewer>

        </div>
    </form>
</body>
</html>
