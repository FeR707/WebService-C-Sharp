<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebService.View._default" EnableEventValidation="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Web Service</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col align-self-end">
                    <div class="d-flex justify-content-center align-items-center my-4">
                        <h1 class="">Web Service</h1>
                        <div class="card-body d-flex justify-content-end align-items-center">
                            <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-md btn-outline-success"
                                Text="Crear un nuevo registro" OnClick="BtnCreate_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <hr />

            <div class="container row">
                <div class="table small">
                    <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:Button runat="server" Text="Editar" CssClass="btn form-control-sm btn-outline-warning" ID="BtnUpdate" OnClick="BtnUpdate_Click" />
                                    <asp:Button runat="server" Text="Eliminar" CssClass="btn form-control-sm btn-outline-danger" ID="BtnDelete" OnClick="BtnDelete_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
