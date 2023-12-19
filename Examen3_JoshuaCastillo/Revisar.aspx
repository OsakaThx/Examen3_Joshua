<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Revisar.aspx.cs" Inherits="TuNamespace.Revisar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Revisar Encuestas</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Encuestas Agregadas</h2>

        <asp:GridView ID="gvEncuestas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
        <asp:BoundField DataField="Edad" HeaderText="Edad" SortExpression="Edad" />
        <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
        <asp:BoundField DataField="Partido" HeaderText="Partido" SortExpression="Partido" />
    </Columns>
</asp:GridView>

    </div>
</asp:Content>
