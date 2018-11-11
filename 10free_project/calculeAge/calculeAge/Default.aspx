<%@ Page CodeFile="Default.aspx.cs"  Language="C#" Inherits="calculeAge.Default" %>
<%@ Register TagPrefix="nepalicalender" Namespace="NepaliCalender" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Age Calculator</title>
</head>
<body>
<form id="form1" runat="server">

   <nepalicalender id="nipali" runat="server"></nepalicalender>     
             
<asp:Calendar ID="calDOB" runat="server" OnSelectionChanged="calDOB_SelectionChanged" SelectionMode="DayWeekMonth"></asp:Calendar>
<br />
<asp:TextBox ID="tbxDOB" runat="server"></asp:TextBox>
</form>
</body>
</html>