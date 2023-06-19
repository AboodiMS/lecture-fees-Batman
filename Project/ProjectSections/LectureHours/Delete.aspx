<%@ Page Title="Delete Lecture Price" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Project.ProjectSections.LecturePrices.Delete" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<h1>Delete</h1>
    <h2 CssClass="text-denger">Are you sure to delete?</h2>
    <form>
    <div class="mb-3">
        <label for="Name" class="form-label">Name : </label>
        <lable  class="form-label"><%= Entity?.Title %></lable>
    </div>
    <div class="mb-3">
        <label for="Price" class="form-label">Number Of Hours : </label>
        <lable  class="form-label"><%= Entity?.NumberOfHours %></lable>
    </div>
    <div id="errorContainer" runat="server" class="alert alert-danger" style="display: none;"></div>
    <asp:Button ID="SubmitButton" runat="server" Text="Delete" CssClass="btn btn-danger" EnableEventValidation="false"  OnClick="SubmitButton_Click" />
    <a href='<%= ResolveUrl("Index") %>' class="btn btn-link">Back To List</a>
</form>
    <script>
    $(document).ready(function() {
        $('#errorContainer').click(function() {
            $(this).hide();
        });
    });
    </script>
</asp:Content>
