﻿<%@ Page Title="Add Professor" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Project.ProjectSections.Professors.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
        <h1>Add</h1>
            <form>
                <div class="mb-3">
                    <label for="Name" class="form-label">Name</label>
                    <input type="text" class="form-control" id="Name" Name="Name" required placeholder="Enter Name">
                </div>
                <div class="mb-3">
                    <label for="ScientificRankCode" class="form-label">Scientific Rank</label>
                    <select class="form-select" id="ScientificRankCode" Name="ScientificRankCode" required>
                        <option value="">Select ...</option>
                        <% foreach (var Entity in ScientificRanks) { %>
                            <option value="<%= Entity.Code %>"><%= Entity.Title %></option>
                        <% } %>
                    </select>
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
