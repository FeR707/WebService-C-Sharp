<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebService.View._default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Web Service</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="~/assets/css/Style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="title">Web Service</h1>
            <div class="form-group ">
                <label for="txtNombre" class="lbl-Text">Nombre</label>
                <div class="d-flex">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese su nombre"></asp:TextBox>
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                </div>
            </div>

            <hr />

            <asp:GridView runat="server" AutoGenerateColumns="false" ID="GridView1" CssClass="table table-striped table-bordered table-hover" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:CommandField HeaderText="Acciones" ButtonType="Image" ShowEditButton="True" ShowDeleteButton="True"
                        EditImageUrl="~/assets/icons/pen-to-square-solid.svg" DeleteImageUrl="~/assets/icons/trash-solid.svg" ItemStyle-CssClass="actions-column" EditText="Editar" DeleteText="Eliminar" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
