<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="Examen3_JoshuaCastillo.Agregar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mx-auto text-center">
        <h2>Formulario de Encuesta</h2>

        <asp:Label ID="lblNumeroFormulario" runat="server" Text="Número de formulario: "></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese su nombre"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtEdad" runat="server" CssClass="form-control" placeholder="Ingrese su edad" type="number"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Ingrese su correo"></asp:TextBox>
        <br />
        <asp:GridView ID="gvPartidos" runat="server" AutoGenerateColumns="False" ShowHeader="False">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="rbPartido" runat="server" GroupName="Partidos" />
                        <asp:Label ID="lblPartido" runat="server" Text='<%# Eval("Partido") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary" Text="Agregar" OnClick="btnAgregar_Click" />
        <br />
        <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger" ForeColor="Red" Text=""></asp:Label>
    </div>
</asp:Content>
