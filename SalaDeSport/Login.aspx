<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SalaDeSport.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title panel-success">
                            Login!
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="input-group">
                                <input type="text" class="form-control" name="Username" id="Username" runat="server" placeholder="Username" />
                                <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator ID="RFVUsername" runat="server" ControlToValidate="Username" Display="Dynamic">
                            <div class="alert alert-danger" role="alert">Username Required! </div>
                        </asp:RequiredFieldValidator>
                         <div id="VUsername" runat="server" visible="false" class="alert alert-danger" role="alert">Invalid Username </div>
                        <div class="form-group">
                            <div class="input-group">
                                <input type="password" class="form-control" id="Password" name="Password" runat="server" placeholder="Password" />
                                <span class="input-group-addon"><span class="glyphicon glyphicon glyphicon-lock"></span></span>
                            </div>
                        </div>
                        <div id="VPassword" runat="server" visible="false" class="alert alert-danger" role="alert">Invalid Password </div>
                        <asp:RequiredFieldValidator ID="RFVFP" runat="server" ControlToValidate="password" Display="Dynamic">
                            <div class="alert alert-danger" role="alert">Password Required! </div>
                        </asp:RequiredFieldValidator>
                        <input type="submit" name="submit"  id="submit" value="Login" runat="server" onserverclick="LoginClick" class="btn btn-success pull-right" />

                    </div>
                </div>


            </div>
        </div>

    </div>


</asp:Content>
