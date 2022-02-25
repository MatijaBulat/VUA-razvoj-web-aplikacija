<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KupacEdit.aspx.cs" Inherits="MVC.KupacEdit" UnobtrusiveValidationMode="None" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title>EditKupac</title>
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li><a href="Index">Kupci</a></li>
                    <li><a href="../Kategorija/Index">Kategorije</a></li>
                    <li><a href="../Potkategorija/Index">Potkategorije</a></li>
                    <li><a href="../Proizvod/Index">Proizvodi</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container body-content">
        <form id="form1" runat="server">
            <div class="form-horizontal">
                <br />
                <br />
                <br />
                <br />
                <h4>Edit kupca</h4>
                <hr />

                <asp:ValidationSummary ID="validationSummary" runat="server" />
                <asp:Label ID="lbError" runat="server" ForeColor="Red" Visible="false" Text="Validation not passed" />

                <div class="form-group">
                    <label class="control-label col-md-2">Ime</label>
                    <div class="col-md-5">
                        <asp:TextBox runat="server" ID="tbIme" CssClass="form-control" />
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidatorIme"
                            runat="server"
                            ControlToValidate="tbIme"
                            Display="None"
                            ForeColor="Red"
                            ErrorMessage="Name was not entered." />
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-2">Prezime</label>
                    <div class="col-md-5">
                        <asp:TextBox runat="server" ID="tbPrezime" CssClass="form-control" />
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidatorPrezime"
                            runat="server"
                            Display="None"
                            ControlToValidate="tbPrezime"
                            ForeColor="Red"
                            ErrorMessage="Surname was not entered." />
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-2">Email</label>

                    <div class="col-md-5">
                        <asp:TextBox runat="server" ID="tbEmail" CssClass="form-control" />
                        <asp:RegularExpressionValidator
                            ID="RegularExpressionValidatorEmail"
                            runat="server"
                            ControlToValidate="tbEmail"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            EnableClientScript="true"
                            Display="None"
                            ForeColor="Red"
                            ErrorMessage="Wrong Email format" />
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-2">Telefon</label>

                    <div class="col-md-5">
                        <asp:TextBox runat="server" ID="tbTelefon" CssClass="form-control" />
                        <asp:RegularExpressionValidator
                            ID="RegularExpressionValidatorPhone"
                            runat="server"
                            ControlToValidate="tbTelefon"
                            ValidationExpression="[0-9]? ?(\([0-9]{2}\))? ?[0-9]{2,4}[ -]?[0-9]{3,4}[ -]?[0-9]{3,4}"
                            EnableClientScript="true"
                            Display="None"
                            ForeColor="Red"
                            ErrorMessage="Wrong phone number format" />
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-2">Drzava</label>

                    <div class="col-md-5">
                        <asp:DropDownList ID="ddlDrzave" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDrzave_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-2">Grad</label>

                    <div class="col-md-5">
                        <asp:DropDownList ID="ddlGradovi" CssClass="form-control" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>


                <div class="form-group">
                    <div class="col-md-offset-2 col-md-2">
                        <asp:Button ID="btnSave" runat="server"
                            CssClass="btn btn-primary" Text="Pošalji" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server"
                            CssClass="btn btn-danger" Text="Odustani" OnClick="btnCancel_Click" />
                    </div>
                </div>
                </div>
        </form>
    </div>
</body>
</html>
