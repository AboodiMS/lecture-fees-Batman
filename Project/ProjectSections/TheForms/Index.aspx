<%@ Page Title="The Forms List" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project.ProjectSections.TheForms.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>The Forms List</h1>
            <div id="errorContainer" runat="server" class="alert alert-danger" style="display: none;"></div>
    <a class="btn btn-primary" href="Add">Add</a>
     <form id="filterForm">
        <div class="row">
          <div class="col-md-4">
            <label for="FProfessorId" class="form-label">Professor</label>
            <asp:DropDownList runat="server" CssClass="form-select" id="FProfessorId">
            </asp:DropDownList>
          </div>
         <div class="col-md-4">
            <label for="FScientificRankCode" class="form-label">Scientific Rank</label>
            <asp:DropDownList runat="server" CssClass="form-select" id="FScientificRankCode">
            </asp:DropDownList>
          </div>
          <div class="col-md-4">
            <label for="FSubjectCode" class="form-label">Subject</label>
            <asp:DropDownList runat="server" CssClass="form-select" id="FSubjectCode">
            </asp:DropDownList>
          </div>
           <div class="col-md-4">
            <label for="FFromFormDate" class="form-label">From Form Date</label>
            <input type="date" runat="server" id="FFromFormDate" class="form-control">
           </div>
          <div class="col-md-4">
            <label for="FToFormDate" class="form-label">To Form Date</label>
            <input type="date" runat="server" id="FToFormDate" class="form-control">
           </div>
        </div>


        <div class="text-center">
          <button typed="button" runat="server" id="FilterButton" onclick="FilterButton_Click" class="btn btn-outline-dark mt-2">Filter</button>
        </div>
    </form>
    <table class="table table-striped table-bordered mt-2">
        <thead>
            <tr>
                <th>Professor</th>
                <th>Scientific Rank</th>
                <th>Subject</th>
                <th>Form Date</th>
                <th>Edit</th>
                <th>Delete</th>
            </tr>
        </thead>
        <tbody>
             <%= PopulateTable() %>
        </tbody>
    </table>
    <script>
        $(document).ready(function () {
            $('#errorContainer').click(function () {
                $(this).hide();
            });
        });
    </script>
</asp:Content>
