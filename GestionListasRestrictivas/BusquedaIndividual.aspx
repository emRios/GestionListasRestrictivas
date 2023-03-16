<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BusquedaIndividual.aspx.cs" Inherits="GestionListasRestrictivas.BusquedaIndividual" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function eventEnter() {
            document.getElementById("vfNHC").onkeypress = function (e) {
                if (!e) e = window.event;
                if (e.keyCode === '13') {
                    onSearch();
                    return false;
                }
            };
        }

        //$(document).ready(function () {
        //    $('[id*=fecha_busqueda]').datepicker({
        //        changeMonth: true,
        //        changeYear: true,
        //        format: "dd/mm/yyyy",
        //        language: "tr",
        //        autoclose: true,
        //        todayHighlight: true,
        //        weekStart: 1,
        //        daysOfWeekHighlighted: "6,0",
        //        onClose: function () {
        //            $(this).removeClass("hasDatepicker");
        //        }
        //    });
        //});

    </script>

    <style>
        .label_text {
            display: inline-block;
            font-weight: bold;
            font-size: medium
        }

        .span12 {
            -moz-box-shadow: 0 0 2px black;
            -webkit-box-shadow: 0 0 2px black;
            box-shadow: 0 0 2px black;
        }
    </style>


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
            $('[id*=fecha_busqueda]').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                language: "tr",
                autoclose: true,
                todayHighlight: true,
                weekStart: 1,
                daysOfWeekHighlighted: "6,0",
                altField: "#fecha_busqueda",
                onClose: function (dateText, inst) {
                    $(this).removeClass("hasDatepicker");
                    inst.inline = false;
                },
                onSelect: function (dateText, inst) {
                    inst.inline = true;
                }
            });
        });

        $(function () {
            $("#fecha_busqueda").datepicker();
            $("#fecha_busqueda").on("change", function () {
                var selected = $(this).val();
                alert(selected);
            });
        });

    </script>
    --

    <asp:UpdatePanel ID="upbusqueda_individual" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <div class="container ">
                <%--             <div class="row  display:flex flex-lg-wrap">--%>
                <div class="col-12">

                    <div class="row">
                        <div id="MensajeError" runat="server" class="col-12 col-sm-12  text-nowrap text-sm-center w-25 p-0" style="display: block">
                            <asp:Label ID="vfmensajeError" runat="server" Text="" CssClass="line hi label_text" EnableViewState="true"></asp:Label>
                        </div>
                    </div>
                    <div class="row">

                        <!-- COLUMNA 1 -->
                        <div class="col-6 border ">

                            <div class="row ">
                                <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                    <label class="hi form-control-sm " for="primer_nombre">Primer Nombre</label>
                                </div>
                                <div class="col-6 col-sm-6 border border-white col-form-label-sm d-flex d-inline-flex">
                                    <input id="primer_nombre" runat="server" tabindex="1" type="text" class=" hi form-control form-control-sm" name="primer_nombre" onclick="Javascript: eventEnter() " />
                                </div>
                            </div>

                            <div class="row ">
                                <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                    <label class="hi form-control-sm " for="tercer_nombre">Tercer Nombre </label>
                                </div>
                                <div class="col-6 col-sm-6 border border-white col-form-label-sm">
                                    <input id="tercer_nombre" runat="server" tabindex="3" type="text" class=" hi form-control form-control-sm" name="tercer_nombre" />
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                    <label class="hi form-control-sm " for="segundo_apellido">Segundo Apellido</label>
                                </div>
                                <div class="col-6 col-sm-6 border border-white col-form-label-sm">
                                    <input id="segundo_apellido" runat="server" tabindex="5" type="text" class=" hi form-control form-control-sm" />
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                    <label class="hi form-control-sm " for="codigo_asegurado">Codigo Asegurado</label>
                                </div>
                                <div class="col-6 col-sm-6 border border-white col-form-label-sm">
                                    <input id="codigo_asegurado" runat="server" tabindex="7" type="text" class=" hi form-control form-control-sm" />
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
                                    <input id="segundo_nombre" runat="server" tabindex="2" type="text" class=" hi form-control form-control-sm" name="segundo_nombre" />
                                </div>
                            </div>

                            <div class="row ">
                                <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                    <label class="hi form-control-sm " for="primer_apellido">Primer Apellido </label>
                                </div>
                                <div class="col-6 col-sm-6 border border-white col-form-label-sm">
                                    <input id="primer_apellido" runat="server" tabindex="4" type="text" class=" hi form-control form-control-sm" name="primer_apellido" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                    <label class="hi form-control-sm " for="apellido_casada">Apellido de Casada</label>
                                </div>
                                <div class="col-6 col-sm-6 border border-white col-form-label-sm">
                                    <input id="apellido_casada" runat="server" tabindex="6" type="text" class=" hi form-control form-control-sm" r />
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                    <label class="hi form-control-sm " for="documento_identificacion">Num.Documento</label>
                                </div>
                                <div class="col-6 col-sm-6 border border-white col-form-label-sm">
                                    <input id="documento_identificacion" runat="server" tabindex="8" type="text" class=" hi form-control form-control-sm" />
                                </div>
                            </div>

                        </div>

                    </div>

                    <div id="hisconoptions" runat="server">
                        <div class="row mt-2">
                            <div class="col-12 ">
                                <h6>Valores de Busqueda</h6>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-6 border ">

                                <div class="row ">
                                    <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                        <label class="hi form-control-sm " for="fecha_busqueda">Fecha de busqueda</label>
                                    </div>
                                    <div id="datetimepicker" class="col-8 col-sm-8 border border-white col-form-label-sm d-flex d-inline-flex " style="width: 100px; max-width: 100px">
                                        <asp:TextBox ID="fecha_busqueda" runat="server" Style="width: 120px; position: relative"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="col-6 border ">
                                <div class="row ">
                                    <div class="col-6 col-sm-6   border border-white  label-primary  ">
                                        <label class="hi form-control-sm " for="usuario_busqueda">Usuario busqueda </label>
                                    </div>
                                    <div class="col-6 col-sm-6 border border-white col-form-label-sm">
                                        <input id="usuario_busqueda" runat="server" tabindex="2" type="text" class=" hi form-control form-control-sm" name="usuario_busqueda" />
                                    </div>
                                </div>

                            </div>

                        </div>
                    </div>

                    <div class="row">

                        <div class="col-3 col-sm-3 border border-white col-form-label-sm">
                            <asp:Button ID="btn_Registrar" CssClass="btn btn-primary"
                                TabIndex="9"
                                runat="server" Text="Registrar Valores" OnClick="btn_Registrar_Click" />
                        </div>

                        <div class="col-3 col-sm-3 border border-white col-form-label-sm">
                            <asp:Button ID="btn_conResultados" type="button" class="button" CssClass="btn btn-primary"
                                TabIndex="9" runat="server" Text="Consultar Resultados" OnClick="btn_conResultados_Click"></asp:Button>
                        </div>

                        <div class="col-3 col-sm-3 border border-white col-form-label-sm">
                            <asp:Button ID="btn_Limpiar" type="button" class="button" CssClass="btn btn-primary"
                                TabIndex="9" runat="server" Text="Limpiar Datos Consultas" OnClick="btn_Limpiar_Click"></asp:Button>
                        </div>

                        <div class="col-3 col-sm-3 border border-white col-form-label-sm">
                            <asp:Button ID="btn_busqueda_dprev" type="button" class="button" CssClass="btn btn-primary"
                                TabIndex="9" runat="server" Text="Consultar His. validaciones" OnClick="btn_busqueda_dprev_Click"></asp:Button>
                        </div>
                    </div>

                </div>

                <%--DIV COL END--%>
                <%-- <div class="row flex-lg-row">--%>
                <%-- <div class="col-12 flex-column">--%>
                <div class="table-responsive table-responsive-md display:flex overflow:hidden;">
                    <asp:Panel runat="server" ID="pnlContainer" ScrollBars="Vertical" Height="100%" Width="100%">
                        <asp:GridView ID="gvResultadosValidacion" runat="server"
                            CellPadding="0"
                            ForeColor="#333333"
                            GridLines="both"
                            BorderColor="#a0acc0"
                            BorderStyle="solid"
                            BorderWidth="1px"
                            AutoGenerateColumns="false"
                            CssClass="table table-bordered mt-4 mb-1 mb-4 overflow : hidden"
                            EnableModelValidation="True" Width="100%" ShowFooter="False">

                            <PagerStyle
                                Height="10"
                                Font-Size="Medium"
                                HorizontalAlign="Center" />
                            <HeaderStyle
                                Height="10px" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />

                            <Columns>

                                <asp:TemplateField HeaderText="Nro." HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="Small">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="numR" runat="server" CssClass="linkbutton" OnClientClick="return imprimirPdfLR()" CommandName="Select" Text='<%# Eval("NUMR")%>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="10px" Height="5px" CssClass="text-md-left text-white" />
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="Small">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lkb_nombre" runat="server" CssClass="linkbutton" CommandName="Select" Text='<%# Bind("NOMBRE") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" Height="5px" CssClass="text-md-left text-white" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Num. Poliza" HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="Small">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lkb_numpol" runat="server" CssClass="linkbutton" CommandName="Select" Text='<%# Bind("NRO_POL") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" Height="5px" CssClass="text-md-left text-white" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Cod.asegurado" HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="Small">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lkb_codaseg" runat="server" CssClass="linkbutton" CommandName="Select" Text='<%# Bind("COD_ASEG") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="10px" Height="5px" CssClass="text-md-left text-white" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="IdLista" HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="Small">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lkb_idlista" runat="server" CssClass="linkbutton" CommandName="Select" Text='<%# Bind("ID_LISTA") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" Height="5px" CssClass="text-md-left text-white" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Lista" HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="Small">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lkb_lsita" runat="server" CssClass="linkbutton" CommandName="Select" Text='<%# Bind("LISTA") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" Height="5px" CssClass="text-md-left text-white" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Por.Comparacion" HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="Small">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lkb_pcomp" runat="server" CssClass="linkbutton" CommandName="Select" Text='<%# Bind("PERC_COMP") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" Height="5px" CssClass="text-md-left text-white" />
                                </asp:TemplateField>

                                <%-- <asp:TemplateField HeaderText="Op" HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="Small">
                                            <ItemTemplate>
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" Height="5px" CssClass="text-md-left text-white" />
                                        </asp:TemplateField>--%>
                            </Columns>

                            <HeaderStyle BackColor="#5D7A9C" Font-Bold="False" Font-Size="Smaller" />
                            <PagerStyle BackColor="#5D7A9C" ForeColor="White" CssClass="col-12 flex-lg-column form-control-lg  " Height="20px" />
                            <RowStyle BackColor="#EFF3FB" />
                        </asp:GridView>
                    </asp:Panel>
                </div>
                <%--  </div>--%>
                <%-- </div>--%>
                <%--   </div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script src="Scripts/rpt_hits_lr.js"></script>

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
