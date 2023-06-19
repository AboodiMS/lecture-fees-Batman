<%@ Page Title="Add Lecture Price" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Project.ProjectSections.LecturePrices.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
        <h1>Add</h1>
            <form>
                <div class="mb-3">
                    <label for="Title" class="form-label">Title</label>
                    <input type="text" class="form-control" id="Title" Name="Title" required placeholder="Enter Title">
                </div>
                <div class="mb-3">
                    <label for="NumberOfHours" class="form-label">Number Of Hours</label>
                    <input type="number"  step="0.01" class="form-control" min="0" id="NumberOfHours" Name="NumberOfHours"  required placeholder="Enter Number Of Hours">
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
