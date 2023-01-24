﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BusquedaIndividual.aspx.cs" Inherits="GestionListasRestrictivas.BusquedaIndividual" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MasterPageHolder" runat="server">


    <link href="CSS/progress-wizard.css" rel="stylesheet" />

    <asp:ScriptManager ID="ScriptManager" runat="server" AsyncPostBackTimeout="360000"
        EnablePageMethods="true" ScriptMode="Release">
    </asp:ScriptManager>



    <script>

        function eventEnter() {
            debugger;

            document.getElementById("vfNHC").onkeypress = function (e) {
                if (!e) e = window.event;
                if (e.keyCode === '13') {
                    onSearch();
                    return false;
                }
            };

        }
    </script>



    <asp:UpdatePanel ID="upbusqueda_individual" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container ">
                <div class="row  display:flex flex-lg-wrap">
                    <div class="col-12">

                        <div class="row">
                            <div id="MensajeError" class="col-sm-6 mt-2 alert alert-danger text-nowrap text-sm-center w-25 p-0" style="display: none">
                                <asp:Label ID="vfmensajeError" runat="server" Text="" CssClass="line" EnableViewState="true"></asp:Label>

                            </div>
                        </div>

                        <div class="row mt-2">

                            <!-- COLUMNA 1 -->
                            <div class="col-6 border ">

                                <div class="row ">
                                    <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                        <label class="hi form-control-sm " for="primer_nombre">Primer Nombre</label>
                                    </div>
                                    <div class="col-6 col-sm-6 border border-white col-form-label-sm d-flex d-inline-flex">
                                        <input id="primer_nombre" type="text" class=" hi form-control form-control-sm" name="primer_nombre" onclick="Javascript: eventEnter() " />
                                    </div>
                                </div>

                                <div class="row ">
                                    <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                        <label class="hi form-control-sm " for="tercer_nombre">Tercer Nombre </label>
                                    </div>
                                    <div class="col-6 col-sm-6 border border-white col-form-label-sm">
                                        <input id="tercer_nombre" runat="server" type="text" class=" hi form-control form-control-sm" name="tercer_nombre" />
                                    </div>
                                </div>

                            </div>

                            <!-- COLUMNA 2 -->
                            <div class="col-6 border ">

                                <div class="row ">
                                    <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                        <label class="hi form-control-sm " for="segundo_nombre">Segundo Nombre </label>
                                    </div>
                                    <div class="col-6 col-sm-6 border border-white col-form-label-sm">
                                        <input id="Text1" runat="server" type="text" class=" hi form-control form-control-sm" name="segundo_nombre" />
                                    </div>
                                </div>

                                <div class="row ">
                                    <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                        <label class="hi form-control-sm " for="primer_apellido">Primer Apellido </label>
                                    </div>
                                    <div class="col-6 col-sm-6 border border-white col-form-label-sm">
                                        <input id="primer_apellido" runat="server" type="text" class=" hi form-control form-control-sm" name="primer_apellido" />
                                    </div>
                                </div>

                            </div>

                            <div class="col-6 border ">
                                <div class="row">
                                    <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                        <label class="hi form-control-sm " for="segundo_apellido">Segundo Apellido</label>
                                    </div>
                                    <div class="col-6 col-sm-6 border border-white col-form-label-sm">
                                        <input id="segundo_apellido" runat="server" type="text" class=" hi form-control form-control-sm"  />
                                    </div>
                                </div>

                             
                            </div>
                             <div class="col-6 border ">
                 

                                <div class="row">
                                    <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                        <label class="hi form-control-sm " for="apellido_casada">Apellido de Casada</label>
                                    </div>
                                    <div class="col-6 col-sm-6 border border-white col-form-label-sm">
                                        <input id="Text3" runat="server" type="text" class=" hi form-control form-control-sm" r />
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>

               
        </ContentTemplate>
    </asp:UpdatePanel>



    <%-- <script>
        $("#btnsearch").click(function (e)
        {
            debugger; e.preventDefault
            createModal();
           
                //new BstrapModal().Show();
//            onSearch();
            
        });

    </script>--%>
</asp:Content>