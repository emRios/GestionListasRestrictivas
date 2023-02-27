<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ComparacionDataListas.aspx.cs" Inherits="GestionListasRestrictivas.ComparacionDataListas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MasterPageHolder" runat="server">


    <link href="CSS/progress-wizard.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>


    <asp:ScriptManager ID="ScriptManager" runat="server" AsyncPostBackTimeout="360000"
        EnablePageMethods="true" ScriptMode="Release">
    </asp:ScriptManager>

    <script type="text/javascript">
        $(function () {
            $('[id*=datepicker]').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                language: "tr",
                autoclose: true,
                todayHighlight: true,
                weekStart: 1,
                daysOfWeekHighlighted: "6,0"
            });
        });

        $(function () {
            $("#datepicker").datepicker();
            $("#datepicker").on("change", function () {
                var selected = $(this).val();
                alert(selected);
            });
        });

    </script>

    <style>
        .programlist {
            width: 150px;
            margin: 0 15px 0 0;
            font: 12px tahoma;
            max-height: 200px;
            overflow-y: scroll;
            position: relative;
        }
    </style>

    <asp:UpdatePanel ID="upbusqueda_individual" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container ">

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
                                    <label class="hi form-control-sm " for="ramo_procesar">Ramo a procesar</label>
                                </div>
                                <div class="col-6 col-sm-6 border border-white col-form-label-sm d-flex d-inline-flex">

                                    <asp:DropDownList ID="ramo_procesar"
                                        runat="server"
                                        CssClass="programlist">
                                        <asp:ListItem Enabled="true" Text="Elegir Ramo" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="VIDA" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="COLECTIVO" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="AUTOS" Value="3"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>
                        </div>

                        <!-- COLUMNA 2 -->
                        <div class="col-6 border ">

                            <div class="row ">
                                <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                    <label class="hi form-control-sm " for="primer_nombre">Fecha Programación</label>
                                </div>
                                <div id="datetimepicker" class="col-6 col-sm-6 border border-white col-form-label-sm d-flex d-inline-flex " style="width: 100px; max-width: 100px">
                                    <asp:TextBox ID="datepicker" runat="server"     Style="width: 120px; position: relative"></asp:TextBox>
                                    
                            

                                    <%-- <input type="text" value="9/23/2009" style="width: 100px;" readonly="readonly" name="Date" id="Date" class="hasDatepicker"/>--%>
                                    <%-- <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>--%>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mt-2">

                        <!-- COLUMNA 1 -->
                        <div class="col-6 border ">

                            <div class="row ">
                                <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                    <label class="hi form-control-sm " for="correo_usuario">Usuario Notificación</label>
                                </div>
                                <div class="col-6 col-sm-6 border border-white col-form-label-sm">
                                    <input id="correo_usuario" runat="server" tabindex="3" type="text" class=" hi form-control form-control-sm" name="correo_usuario" />
                                </div>
                            </div>
                        </div>

                        <!-- COLUMNA 2 -->
                        <div class="col-6 border ">

                            <div class="row ">
                                <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                    <label class="hi form-control-sm " for="correoTecnologia">Usuario Tecnologia</label>
                                </div>
                                <div class="col-6 col-sm-6 border border-white col-form-label-sm">
                                    <input id="correoTecnologia" runat="server" tabindex="3" type="text" class=" hi form-control form-control-sm" name="correoTecnologia" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mt-2">

                        <!-- COLUMNA 1 -->
                        <div class="col-12 border ">

                            <div class="row ">
                                <div class="col-3 col-sm-3   border border-white  label-primary  ">
                                    <label class="hi form-control-sm " for="descripcion_proceso">Descripcion proceso</label>
                                </div>
                                <div class="col-9 col-sm-9 border border-white col-form-label-sm">
                                    <input id="descripcion_proceso" runat="server" tabindex="3" type="text" class=" hi form-control form-control-sm" name="descripcion_proceso" />
                                </div>
                            </div>
                        </div>

                    </div>


                    <div class="row">
                        <div class="col-4 col-sm-4 border border-white col-form-label-sm">
                            <asp:Button ID="btn_ProgramarProc" CssClass="btn btn-primary"
                                TabIndex="9"
                                runat="server" Text="Programar" OnClick="btn_ProgramarProc_Click" />
                        </div>

                    </div>

                </div>
        </ContentTemplate>

    </asp:UpdatePanel>


</asp:Content>

