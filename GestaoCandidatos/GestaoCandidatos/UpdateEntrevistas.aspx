<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UpdateEntrevistas.aspx.cs" Inherits="GestaoCandidatos.UpdateEntrevistas" %>
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
                </div>
            </div>
            <div class="col-md-5">
                <div class="form-group">
                    <asp:Button ID="submeter" runat="server" class="btn btn-block btn-danger" Text="Atualizar" OnClick="submeter_Click"/>
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
