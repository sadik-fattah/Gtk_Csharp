<%@ Page Language="C#" Inherits="test.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
</head>
<body>
	<form id="form1" runat="server">
		<asp:Calendar id="calender" runat="server" OnSelectionChanged="calender_SelectionChang" SelectionMode="DayWeekMonth"></asp:Calendar>
            <asp:TextBox runat="server" id="tbx_calender_select"></asp:TextBox>
           
	</form>
</body>
</html>
