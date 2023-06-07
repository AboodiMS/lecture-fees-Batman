<%@ Page Title="Edit Professor" Language="C#" Async="true"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Project.ProjectSections.Professors.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <div class="container">
        <h1>Edit</h1>
            <form>
                <div class="mb-3">
                    <label for="Name" class="form-label">Name</label>
                    <input type="text" class="form-control" id="Name" Name="Name" value="<%= Entity?.Name %>" required placeholder="Enter Name">
                </div>
                <div class="mb-3">
                    <label for="ScientificRankCode" class="form-label">Scientific Rank</label>
                    <select class="form-select" id="ScientificRankCode" Name="ScientificRankCode" required>
                        <option value="<%= Entity?.ScientificRankCode %>"><%= Entity?.ScientificRank.Title %></option>
                        <% foreach (var Entity in ScientificRanks) { %>
                            <option value="<%= Entity.Code %>"><%= Entity.Title %></option>
                        <% } %>
                    </select>
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
