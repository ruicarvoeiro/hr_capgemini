<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddClassificacao.aspx.cs" Inherits="GestaoCandidatos.AddClassificacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
        <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
        <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
        <script lang="javascript" type="text/javascript">
            $(function () {
                var availableTags = [
                    "c++", "java", "php", "coldfusion", "javascript", "asp", "ruby"
                ];
                $('#<%=tb_Nome.ClientID%>').autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "AddClassificacao.aspx/GetEntidades",
                            data: "{ 'pre':'" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response(data.d)
                            },
                            source: availableTags,
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert(errorThrown);
                            }
                        });
                    }
                });
            });
        </script>
    <div class="container">
        <br />
        <br />
        <br />
        <div class="row">
            <div class="row">
                <div class="col-md-2">
                    <div class="form-group">
                        <label>Nome: </label>
                    </div>
                </div>
                <div class="col-md-10">
                    <div class="form-group">
                        <asp:TextBox ID="tb_Nome" runat="server"></asp:TextBox><br />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="row">
                <div class="col-md-2">
                    <div class="form-group">
                        <label>ID: </label>
                    </div>
                </div>
                <div class="col-md-10">
                    <div class="form-group">
                        <asp:TextBox ID="tb_ID" runat="server" TextMode="Number"></asp:TextBox><br />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="row">
                <div class="col-md-2">
                    <div class="form-group">
                        <label>Nota: </label>
                    </div>
                </div>
                <div class="col-md-10">
                    <div class="form-group">
                        <asp:DropDownList runat="server" ID="dl_Nota"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2">
                    <div class="form-group">
                        <label>Comentário: </label>
                    </div>
                </div>
                <div class="col-md-10">
                    <div class="form-group">
                        <asp:TextBox ID="tb_Comentario" runat="server"></asp:TextBox><br />
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2">
                    <div class="form-group">
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="form-group">
                        <asp:Button ID="submeter" runat="server" class="btn btn-block btn-danger" Text="Adicionar" OnClick="submeter_Click" />
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="form-group">
                        <asp:Button ID="sair" runat="server" class="btn btn-block btn-danger" Text="Cancelar" OnClick="sair_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
