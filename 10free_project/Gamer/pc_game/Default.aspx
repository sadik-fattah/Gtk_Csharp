<%@ Page Language="C#" Inherits="pc_game.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
       <style>
            .tb
            {
            margin-top: 40px;
            }
            .btn_save
            {
            background: rgb(28, 184, 65);
            margin-left:30px;
            }
            .btn_clear
            {
               background: rgb(223, 117, 20);
                margin-left:30px;
            }
        </style>
        <meta name="viewport" content="width=device-width,initial-scale=1">
        <link rel="stylesheet" href="https://unpkg.com/purecss@1.0.0/build/pure-min.css" integrity="sha384-nn4HPE8lTHyVtfCBi5yW9d20FjT8BJwUXyWZT9InLYax14RDjBj46LmSztkmNP9w" crossorigin="anonymous"/>
</head>
<body>
	<form id="form1" runat="server" class="pure-form pure-form-stacked">
            <div class="pure-g">
            <asp:Label runat="server" id="lb_id" CssClass="pure-u-1-1"/><asp:TextBox runat="server" id="txt_id" CssClass=""></asp:TextBox>
            <asp:Label runat="server" id="lb_name" CssClass="pure-u-1-1"/><asp:TextBox runat="server" id="txt_name" CssClass=""></asp:TextBox>
            <asp:Label runat="server" id="lb_image" CssClass="pure-u-1-1"/><asp:TextBox runat="server" id="txt_image" CssClass=""></asp:TextBox>
            <asp:Label runat="server" id="lb_link" CssClass="pure-u-1-1"/><asp:TextBox runat="server" id="txt_link" CssClass=""></asp:TextBox>
            <asp:Label runat="server" id="lb_type" CssClass="pure-u-1-1"/><asp:TextBox runat="server" id="txt_type" CssClass=""></asp:TextBox>
            </div>
            <asp:Button runat="server" id="btn_save" Text="Save" CssClass="pure-button btn_save" OnClick="btn_save_Click"></asp:Button>
           <asp:Button runat="server" id="btn_clear" Text="Clear" CssClass="pure-button btn_clear" OnClick="btn_Clear_Click"></asp:Button>
<table class="pure-table tb">
                <tr class="pure-table-odd">
                    <td align="center">
                        <asp:PlaceHolder id="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>
                    </td>
       </tr>
            </table>
        <asp:GridView ID="Grid" runat="server" CssClass="pure-table tb" OnRowDeleting="Grid_RowDeleting" OnRowEditing="Grid_RowEditing" OnRowCancelingEdit="Grid_RowCancelingEdit" OnRowUpdating="Grid_RowUpdating">
                <Columns>
                    <asp:CommandField ButtonType="Link" HeaderText="Edit/Delete" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="100" />
                </Columns>
            </asp:GridView>	
        </form>
</body>
</html>
