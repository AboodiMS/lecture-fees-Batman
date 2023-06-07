<%@ Page Title="Add ScientificRank" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Project.ProjectSections.ScientificRanks.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <div class="container">
        <h1>Add</h1>
            <form>
                <div class="mb-3">
                    <label for="Title" class="form-label">Title</label>
                    <input type="text" class="form-control" id="Title" Name="Title" required placeholder="Enter Title">
                </div>
                <div class="mb-3">
                    <label for="Description" class="form-label">Description</label>
                    <input type="text" aria-multiline="true" class="form-control" id="Description" Name="Description" required placeholder="Enter Description">
                </div>
                <div id="errorContainer" runat="server" class="alert alert-danger" style="display: none;"></div>
                <asp:Button ID="SubmitButton" runat="server" Text="Add" CssClass="btn btn-primary" EnableEventValidation="false"  OnClick="SubmitButton_Click" />
                <a href='<%= ResolveUrl("Index") %>' class="btn btn-link">Back To List</a>
            </form>
    </div>
        <script>
    $(document).ready(function() {
        $('#errorContainer').click(function() {
            $(this).hide();
        });
    });
        </script>
</asp:Content>
