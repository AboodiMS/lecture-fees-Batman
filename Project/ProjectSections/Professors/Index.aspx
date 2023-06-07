<%@ Page Title="Professors List"  Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project.ProjectSections.Professors.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Professors List</h1>
    <div id="errorContainer" runat="server" class="alert alert-danger" style="display: none;"></div>
    <a class="btn btn-primary" href="Add">Add</a>
     <form id="filterForm">
        <div class="row">
          <div class="col-md-4">
            <div class="mb-3">
              <label for="FName" class="form-label">Name</label>
              <input type="text" runat="server" class="form-control" id="FName" placeholder="Enter name">
            </div>
          </div>
          <div class="col-md-4">
            <label for="FScientificRankCode" class="form-label">Scientific Rank</label>
            <asp:DropDownList runat="server" CssClass="form-select" id="FScientificRankCode">
            </asp:DropDownList>
          </div>
        </div>
        <div class="text-center">
          <button typed="button" runat="server" id="FilterButton" onclick="FilterButton_Click" class="btn btn-outline-dark">Filter</button>
        </div>
    </form>
    <table class="table table-striped table-bordered mt-2">
        <thead>
            <tr>
                <th>Name</th>
                <th>Scientific Rank</th>
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


