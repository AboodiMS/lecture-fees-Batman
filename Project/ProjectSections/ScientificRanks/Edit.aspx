<%@ Page Title="Edit ScientificRank" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Project.ProjectSections.ScientificRanks.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Edit</h1>
            <form>
                <div class="mb-3">
                    <label for="Title" class="form-label">Title</label>
                    <input type="text" class="form-control" id="Title" value="<%= Entity?.Title %>" Name="Title" required placeholder="Enter Title">
                </div>
                <div class="mb-3">
                    <label for="Description" class="form-label">Description</label>
                    <input type="text" aria-multiline="true" value="<%= Entity?.Description %>" class="form-control" id="Description" Name="Description" required placeholder="Enter Description">
                </div>
                <div class="mb-3">
                    <label for="Price" class="form-label">Price</label>
                    <input type="number" min="0" step="0.01" class="form-control" id="Price" Name="Price" value="<%= Entity?.Price %>" required placeholder="Enter Price">
                </div>
                <div id="Div1" runat="server" class="alert alert-danger" style="display: none;"></div>
                <div id="errorContainer" runat="server" class="alert alert-danger" style="display: none;"></div>
                <asp:Button ID="SubmitButton" runat="server" Text="Edit" CssClass="btn btn-secondary" EnableEventValidation="false"  OnClick="SubmitButton_Click" />
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
