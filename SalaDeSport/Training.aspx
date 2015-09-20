<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Training.aspx.cs" Inherits="SalaDeSport.Training" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="panel panel-default">
                <div class="panel-heading" >
                    <h3 runat="server" id="PanelTitle">

                    </h3>
                </div>
                <div class="panel-body">
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label for="TrainingName">Training name: </label>
                            <p runat="server" id="TrainingName"></p>
                        </div>
                        <div class="form-group">
                            <label for="TrainerName">Coach name: </label>
                            <p runat="server" id="TrainerName"></p>
                        </div>
                        <div class="form-group">
                            <label for="TrainingDay">Training Day: </label>
                            <p runat="server" id="TrainingDay"></p>
                        </div>
                        <div class="form-group">
                            <label for="TrainingHour">Training Hour: </label>
                            <p runat="server" id="TrainingHour"></p>
                        </div>

                        <div class="btn-group">
                            <input id="AttendB" runat="server" type="submit" onserverclick="AttendToTraining"  class="btn btn-success" value="Attend"/>
                            <input id="LeaveB" runat="server" type="submit" onserverclick="LeaveTraining"  class="btn btn-danger" value="Leave"/>
                            <a id="EditB" runat="server" class="btn btn-warning" href="#">Edit </a>
                            <input id="DeleteB" runat="server" type="submit" onserverclick="DeleteTraining"  class="btn btn-danger" value="Delete" />
                        </div>
                    </div>
                    <div class="col-sm-9">
                        <dl class="dl-horizontal">
                            <dt>Warming</dt>
                            <dd runat="server" id="WarmingP"></dd>
                        </dl>
                        <dl class="dl-horizontal">
                            <dt>Skill</dt>
                            <dd runat="server" id="SkillP"></dd>
                        </dl>
                        <dl class="dl-horizontal">
                            <dt>Wod</dt>
                            <dd runat="server" id="WodP">1</dd>
                        </dl>
                    </div>

                </div>
            </div>

        </div>


    </div>




</asp:Content>
