﻿<%@ Page Title="Delete ScientificRank" Language="C#"  Async="true"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Project.ProjectSections.ScientificRanks.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Delete</h1>
    <h2 CssClass="text-denger">Are you sure to delete?</h2>
    <form>
    <div class="mb-3">
        <label for="Title" class="form-label">Title : </label>
        <lable  class="form-label"><%= Entity?.Title %></lable>
    </div>
    <div class="mb-3">
        <label for="Description" class="form-label">Description : </label>
        <lable  class="form-label"><%= Entity?.Description %></lable>
    </div>
    <div class="mb-3">
        <label for="Price" class="form-label">Price : </label>
        <lable  class="form-label"><%= Entity?.Price %></lable>
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
