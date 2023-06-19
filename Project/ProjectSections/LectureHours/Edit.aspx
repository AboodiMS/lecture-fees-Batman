<%@ Page Title="Edit Lecture Price" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Project.ProjectSections.LecturePrices.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <div class="container">
        <h1>Edit</h1>
            <form>
                <div class="mb-3">
                    <label for="Title" class="form-label">Title</label>
                    <input type="text" class="form-control" id="Title" Name="Title" value="<%= Entity?.Title %>" required placeholder="Enter Title">
                </div>

                <div class="mb-3">
                    <label for="NumberOfHours" class="form-label">Number Of Hours</label>
                    <input type="number" min="0"  step="0.01" class="form-control" id="NumberOfHours" Name="NumberOfHours" value="<%= Entity?.NumberOfHours %>" required placeholder="Enter Number Of Hours">
                </div>
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
