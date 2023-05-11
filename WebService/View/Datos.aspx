<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Datos.aspx.cs" Inherits="WebService.View.Datos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Datos</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
</head>
<body>
    <div class="container">
        <div class="row justify-content-center">
            <div class="d-flex align-items-center flex-column my-4">
                 <asp:Label runat="server" CssClass="h2" ID="lbltitulo"></asp:Label>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="col-md-6">
                <form runat="server">
                    <div class="form-group">
                        <label for="lblNombre">Nombre</label>
                        <asp:TextBox runat="server" CssClass="form-control mb-2" ID="txtNombre"></asp:TextBox>
                        <asp:DropDownList ID="ddlGrupo" runat="server" CssClass="form-control" Visible="false" ></asp:DropDownList>
                    </div>
                    <asp:Button runat="server" CssClass="btn btn-outline-success btn-block mb-2" ID="BtnCreate" Text="Crear" Visible="false" OnClick="BtnCreate_Click" />
                    <asp:Button runat="server" CssClass="btn btn-outline-warning btn-block mb-2" ID="BtnUpdate" Text="Editar" Visible="false" OnClick="BtnUpdate_Click" />
                    <asp:Button runat="server" CssClass="btn btn-outline-danger btn-block mb-2" ID="BtnDelete" Text="Eliminar" Visible="false" OnClick="BtnDelete_Click" />
                    <asp:Button runat="server" CssClass="btn btn-secondary btn-block" ID="BtnVolver" Text="Volver" Visible="True" OnClick="BtnVolver_Click" />
                </form>
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
