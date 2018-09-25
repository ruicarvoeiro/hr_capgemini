<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddCandidato.aspx.cs" Inherits="GestaoCandidatos.AddCandidato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <br />
        <br />
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

        <div class="row">
            <div class="col-md-2">
                <div class="form-group">
                    <label>Nif: </label>
                </div>
            </div>
            <div class="col-md-10">
                <div class="form-group">
                    <asp:TextBox ID="tb_Nif" runat="server" TextMode="Number" MaxLength="9"></asp:TextBox><br />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-2">
                <div class="form-group">
                    <label>Data: </label>
                </div>
            </div>
            <div class="col-md-10">
                <div class="form-group">
                    <asp:TextBox ID="tb_Data" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-2">
                <div class="form-group">
                    <label>Tipo de Escolaridade: </label>
                </div>
            </div>
            <div class="col-md-10">
                <div class="form-group">
                    <asp:DropDownList runat="server" ID="dl_Escolaridade"></asp:DropDownList>
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
                    <asp:Button ID="submeter" runat="server" class="btn btn-block btn-danger" Text="Adicionar" OnClick="submeter_Click"/>
                </div>
            </div>
            <div class="col-md-5">
                <div class="form-group">
                    <asp:Button ID="sair" runat="server" class="btn btn-block btn-danger" Text="Cancelar" OnClick="sair_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
