<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrupoDatos.aspx.cs" Inherits="WebService.View.GrupoDatos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Grupo</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
</head>
<body>
    <div class="container">
        <div class="row justify-content-center">
            <div class="d-flex align-items-center flex-column my-4">
                <asp:Label runat="server" CssClass="h2" Text="Crear Grupo"></asp:Label>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="col-md-6">
                <form runat="server">
                    <div class="form-group">
                        <label for="lblNombre">Nombre de grupo</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtGrupoNombre"></asp:TextBox>
                    </div>
                    <asp:Button runat="server" CssClass="btn btn-outline-success btn-block mb-2" ID="BtnCreateGrupo"
                        Text="Crear" OnClick="BtnCreateGrupo_Click" />
                    <asp:Button runat="server" CssClass="btn btn-secondary btn-block" ID="BtnVolver" Text="Volver"
                        Visible="True" OnClick="BtnVolver_Click" />
                </form>
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
