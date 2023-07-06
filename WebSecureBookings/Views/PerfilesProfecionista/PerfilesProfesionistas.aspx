<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PerfilesProfesionistas.aspx.cs" Inherits="WebSecureBookings.Views.Perfilesprofecionista.PerfilesProfesionistas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="PerfilesProfesionistas.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="row" style="width: 100%;">
        <div class="col-md-12 text-center">
            <h1 style="color: #3385d9">Profesionistas</h1>
        </div>
        <div class="col-md-12 center">
            <hr style="width: auto; height: 3px; background: #caebf2">
        </div>
    </div>

    <br />
    <div class="row" style="width: 100%;">
        <div class="col-md-4 text-center">
            <label><b>Profesión</b></label>
            <select class="form-select form-select-sm selectpicker" aria-label=".form-select-sm example" id="cboProfeciones">
            </select>
        </div>
        <div class="col-md-5 text-center">
            <label><b>Ciudad</b></label>
            <select class="form-select form-select-sm select2" aria-label=".form-select-sm example" id="cboCiudades">
            </select>
        </div>
        <div class="col-md-3 text-right">
            <br />
            <button id="btnBuscar" type="button" class="btn btn-used">Buscar</button>
            <button id="btnLimpiarFiltro" type="button" class="btn btn-secondary">Limpiar filtro</button>
        </div>
    </div>

    <div class="row" id="div-profesionales">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="modalDialog" runat="server">
</asp:Content>
