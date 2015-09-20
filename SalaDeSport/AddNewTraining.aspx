<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddNewTraining.aspx.cs" Inherits="SalaDeSport.AddNewTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="panel panel-info">
                <div class="panel-heading">
                    Add a new training
                </div>
                <div class="panel-body">
                    <div class="col-lg-3">
                        <div class="panel panel-info">
                            <div class="panel-heading">Add Time And Name of the training</div>
                            <div class="panel-body">
                                <div class="form-group">
                                     <label for="HourOT">Training Hour</label>
                                    <input type="number" runat="server" id="HourOT" class="form-control"  min="0" max="23" value="0" />
                                </div>
                                <div class="form-group">
                                    <label for="DayOfTheWeek">Training Day</label>
                                    <asp:DropDownList ID="DayOfTheWeek" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="Monday">Monday </asp:ListItem>
                                        <asp:ListItem Value="Tuesday">Tuesday </asp:ListItem>
                                        <asp:ListItem Value="Wednesday">Wednesday </asp:ListItem>
                                        <asp:ListItem Value="Thursday">Thursday </asp:ListItem>
                                        <asp:ListItem Value="Friday">Friday </asp:ListItem>
                                        <asp:ListItem Value="Saturday">Saturday </asp:ListItem>
                                        <asp:ListItem Value="Sunday">Sunday </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                     <label for="DayOfTheWeek">Training Name</label>
                                    <input type="text" runat="server" id="NameOfTraining" class="form-control" name="NameOfTraining" placeholder="Training Name" />
                                </div>
                                <div class="btn-group">
                                    <input type="submit" runat="server" class="btn btn-success" value="AddTraining" onserverclick="SubmitClick" />
                                    <input type="button" data-toggle="collapse" data-target="#AddExerciseCollapse" aria-expanded="false" aria-controls="AddExerciseCollapse" runat="server" class="btn btn-danger" value="AddExercise" />
                                </div>
                                 <br />
                                <div class="input-group">
                                    <div id="VforTime" runat="server" visible="false" class="alert alert-danger" role="alert">That time is occupied! </div>
                                </div>
                               

                            </div>

                        </div>
                        <div class="panel panel-info collapse" id="AddExerciseCollapse">
                            <div class="panel-heading">Add a new Exercise</div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <input type="text" runat="server" name="NewExerciceName" id="NewExerciceName" class="form-control" placeholder="Exercice name" />

                                </div>
                                <div class="form-group">
                                    <input type="button" runat="server" id="AddExerciseButton" onserverclick="AddExerciseButtonClick" class="btn btn-success" value="Add new Execise" />

                                </div>

                            </div>
                        </div>

                    </div>




                    <div class="col-lg-3">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                Warming
                            </div>
                            <div class="panel-body">

                                <div class="form-group">
                                    <label for="WrInputNumberOfSets">Number of sets of exercices:</label>
                                    <input type="number" class="form-control" id="WrNOS" runat="server" name="WarmingNumberOfSets" min="0" max="100" value="0" />


                                </div>
                                <div class="form-group">
                                    <label for="WrInputNumberOfExercices">Number of exercices:</label>
                                    <input type="number" id="WrNOE" runat="server" min="0" max="100" value="0" name="WarimingNumberOfExercices" class="form-control" />
                                </div>
                                <div class="form-group">
                                    <label for="WrInputNumberOfExercices">Exercice type: </label>
                                    <asp:DropDownList ID="WrTypeOfExercices" runat="server" min="0" max="100" value="0" CssClass="form-control"></asp:DropDownList>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                Skill
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <label for="SkInputNumberOfSets">Number of sets of exercices:</label>
                                    <input type="number" id="SkNOS" runat="server" class="form-control" min="0" max="100" value="0" />


                                </div>
                                <div class="form-group">
                                    <label for="SkInputNumberOfExercices">Number of exercices:</label>
                                    <input type="number" id="SkNOE" runat="server" name="SkillNumberOfExercices" min="0" max="100" value="0" class="form-control" />
                                </div>
                                <div class="form-group">
                                    <label for="WrInputNumberOfExercices">Exercice type: </label>
                                    <asp:DropDownList ID="SkTypeOfExercices" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                Wod
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <label for="WodInputNumberOfSets">Number of sets of exercices:</label>
                                    <input type="number" id="WodNOS" runat="server" class="form-control" name="WodNumberOfSets" min="0" max="100" value="0" />


                                </div>
                                <div class="form-group">
                                    <label for="WodInputNumberOfExercices">Number of exercices:</label>
                                    <input type="number" id="WodNOE" runat="server" name="WodNumberOfExercices" min="0" max="100" value="0"  class="form-control" />
                                </div>
                                <div class="form-group">
                                    <label for="WrInputNumberOfExercices">Exercice type: </label>
                                    <asp:DropDownList ID="WodTypeOfExercicies" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

        </div>


    </div>


</asp:Content>
