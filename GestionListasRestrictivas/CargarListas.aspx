<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CargarListas.aspx.cs" Inherits="GestionListasRestrictivas.CargarListas" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MasterPageHolder" runat="server">


    <link href="CSS/progress-wizard.css" rel="stylesheet" />

    <asp:ScriptManager ID="ScriptManager" runat="server" AsyncPostBackTimeout="360000"
        EnablePageMethods="true" ScriptMode="Release">
    </asp:ScriptManager>


    <asp:UpdatePanel ID="up_cargar_listas" runat="server" UpdateMode="Conditional">
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
                            <div class="col-12 border ">

                                <div class="row ">
                                    <div class="col-4 col-sm-4 border border-white  label-primary  ">
                                        <label class="hi form-control-sm ">Cargar Lista ONU</label>
                                    </div>
                                    <div class="col-6 col-sm-6 border border-white col-form-label-sm d-flex d-inline-flex">

                                        <asp:FileUpload ID="FileUpload1"
                                            runat="server"></asp:FileUpload>
                                    </div>
                                    <div class="col-2 col-sm-2 border border-white col-form-label-sm d-flex d-inline-flex">

                                        <asp:Button ID="CargarListaONU"
                                            Text="Upload file"
                                            OnClick="CargarListaOFAC_Click"
                                            runat="server"></asp:Button>

                                        <asp:Label ID="UploadStatusLabel"
                                            runat="server">
                                        </asp:Label>
                                    </div>
                                </div>

                                <br />
                                <br />

                                <div class="row ">
                                    <div class="col-4 col-sm-4   border border-white  label-primary  ">
                                        <label class="hi form-control-sm ">Cargar lista OFAC </label>
                                    </div>
                                    <div class="col-6 col-sm-6 border border-white col-form-label-sm">
                                        <asp:FileUpload ID="FileUpload2"
                                            runat="server"></asp:FileUpload>
                                    </div>
                                    <div class="col-2 col-sm-2 border border-white col-form-label-sm">

                                        <asp:Button ID="CargarListaOFAC"
                                            Text="Upload file"
                                            OnClick="CargarListaONU_Click"
                                            runat="server"></asp:Button>

                                        <asp:Label ID="Label2"
                                            runat="server">
                                        </asp:Label>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="CargarListaONU" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
