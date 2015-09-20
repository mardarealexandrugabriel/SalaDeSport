<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SalaDeSport.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
     <div class="container">
        <div class="row">
            <div class="col-lg-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title panel-success">Register!</div>
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
                        <div id="VforUn" runat="server" visible="false" class="alert alert-danger" role="alert">Username already taken! </div>
                        <div class="form-group">
                            <div class="input-group">
                                <input type="password" class="form-control" id="Password" name="Password" runat="server" placeholder="Password" />
                                <span class="input-group-addon"><span class="glyphicon glyphicon glyphicon-lock"></span></span>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator ID="RFVFP" runat="server" ControlToValidate="password" Display="Dynamic">
                            <div class="alert alert-danger" role="alert">Password Required! </div>
                        </asp:RequiredFieldValidator>
                       
                        <div class="form-group">
                            <div class="input-group">
                                <input type="password" class="form-control" id="RPassword" name="RPassword" runat="server" placeholder="Retype Password" />
                                <span class="input-group-addon"><span class="glyphicon glyphicon glyphicon-lock"></span></span>
                            </div>

                        </div>
                         <asp:RequiredFieldValidator ID="RFVFP2" runat="server" ControlToValidate="RPassword" Display="Dynamic">
                            <div class="alert alert-danger" role="alert">Password Required! </div>
                        </asp:RequiredFieldValidator>
                         <asp:CompareValidator ID="CV1" runat="server" ControlToValidate="Rpassword" ControlToCompare="password" Display="Dynamic">
                            <div class="alert alert-danger" role="alert">Both passwords must mach! </div>
                        </asp:CompareValidator>
                        <div class="form-group">

                            <div class="input-group">
                                <input type="text" class="form-control" id="FirstName" name="FirstName" runat="server" placeholder="FirstName" />
                                <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator ID="RFVFFN" runat="server" Display="Dynamic" ControlToValidate="FirstName">
                             <div class="alert alert-danger" role="alert">Firstname Required!</div>
                        </asp:RequiredFieldValidator>
                        <div class="form-group">

                            <div class="input-group">
                                <input type="text" class="form-control" id="LastName" name="LastName" runat="server" placeholder="LastName" />
                                <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator ID="RFVFLN" runat="server" ControlToValidate="LastName" Display="Dynamic">
                            <div class="alert alert-danger" role="alert">Lastname Required!</div>
                        </asp:RequiredFieldValidator>
                        <div class="form-group" id="TypeOfUser" runat="server">
                            <label for="sel1">Register as:</label>
                            <select class="form-control" runat="server" id="sel1">
                                <option value="0">Trainer</option>
                                <option value="1">Gymnast</option>
                                
                            </select>
                        </div>

                        <input type="submit" name="submit"  id="submit" value="Register" runat="server" onserverclick="RegisterClick" class="btn btn-success pull-right" />
                    </div>


                </div>
            </div>

        </div>
    </div>
         
</asp:Content>
