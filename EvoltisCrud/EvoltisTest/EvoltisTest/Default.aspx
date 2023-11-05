<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EvoltisTest._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <h3>Gestion Empleados</h3>

    <div class="row">
        <div class="col-12" style="margin-bottom: 15px; margin-top: 15px">
            <asp:Button ID="btnAdd" runat="server" OnClick="nuevo_Click" CssClass="btn btn-primary" Text="Nuevo" CausesValidation="false" />
        </div>
    </div>

    <div class="row">
        <div class="col-12">
            <asp:GridView ID="GVEmpleados" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" >
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Salario" HeaderText="Salario" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButtonEditar" OnClick="Editar_Click" CausesValidation="false" CssClass="btn btn-sm btn-primary" runat="server" CommandArgument='<%# Eval("Id") %>'>Editar</asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonElimniar" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-danger" OnClick="Eliminar_Click" OnClientClick="return confirm('Desea eliminar el empleado?')" CommandArgument='<%# Eval("Id") %>'>Eliminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <div>
                <asp:TextBox ID="txtBuscar" runat="server" Width="213px"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" CausesValidation="false" />
            </div>

        </div>
    </div>

    <asp:Panel ID="ModalAdd" runat="server" Style="display: none; background-color: #D5E989; border: 1px solid #0489B1; padding: 3px; align-items: flex-start; justify-content: left">
        <div style="display: flex; flex-direction: column; justify-content: left; align-items: center; width: 340px; margin-bottom: 10px; height: 230px">

            <div style="margin-bottom: 20px; margin-top: 10px">
                <span class="input-group-text" id="lblNombre" runat="server">Nombre</span>
                <asp:TextBox ID="txtNombre1" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtNombre1"
                    ErrorMessage="El nombre es requerido." InitialValue="" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div style="margin-bottom: 20px">
                <span class="input-group-text" id="lblApellido" runat="server">Apellido</span>
                <input type="text" id="txtApellido" runat="server" />
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtApellido"
                    ErrorMessage="El Apellido es requerido." InitialValue="" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div style="margin-bottom: 20px">
                <span class="input-group-text" id="lblEmail" runat="server">Email</span>
                <input type="email" id="txtEmail" placeholder="ejemplo@domain.com" runat="server" />
                <br />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                    ErrorMessage="Ingrese una dirección de correo electrónico válida." ValidationExpression="^[\w\.-]+@[\w-]+\.\w{2,4}$" CssClass="text-danger"></asp:RegularExpressionValidator>
            </div>
            <div style="margin-bottom: 20px">
                <span class="input-group-text">Salario</span>
                <input runat="server" type="text" id="txtSalario" />
                <br />
                <asp:RequiredFieldValidator ID="rfvSalary" runat="server" ControlToValidate="txtSalario" Display="Dynamic"
                    ErrorMessage="El salario es requerido." CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revSalary" runat="server" ControlToValidate="txtSalario" Display="Dynamic"
                    ErrorMessage="Ingrese un salario válido, solo se permite 2 decimales y 10 digitos en total." ValidationExpression="^\d{1,8}([,.]\d{1,2})?$" CssClass="text-danger"></asp:RegularExpressionValidator>
            </div>
        </div>

        <asp:Button ID="btnSave" class="btn btn-success" runat="server" Text="Guardar" OnClick="btnSave_Click" Style="margin-left: 5px; margin-right: 10px;" CausesValidation="true" />
        <asp:Button ID="BtCloseMdl" class="btn btn-secondary" runat="server" Text="Cancelar" CausesValidation="false" />
    </asp:Panel>

    <asp:Button ID="BtnVMdl" runat="server" Text="Ver Modal" Style="display: none;" CausesValidation="false" />
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Modal" OnClick="btnSave_Click" Style="display: none;" CausesValidation="false" />

    <ajaxtoolkit:ModalPopupExtender ID="AjaxVtM" runat="server" OkControlID="btnGuardar" CancelControlID="BtCloseMdl" TargetControlID="btnGuardar" PopupControlID="ModalAdd" BackgroundCssClass="background-color: #ECF2E2; opacity:0.4;">
    </ajaxtoolkit:ModalPopupExtender>
    
</asp:Content>
