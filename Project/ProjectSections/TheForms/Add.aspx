<%@ Page Title="Add TheForm" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Project.ProjectSections.TheForms.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <div class="container">
        <h1>Add</h1>
            <form>
                <div class="mb-3">
                    <label for="FormDate" class="form-label">Form Date</label>
                    <input type="date"  id="FormDate" name="FormDate" class="form-control" required >
                </div>
                <div class="mb-3">
                    <label for="ScientificRankCode" class="form-label">Subject</label>
                    <select class="form-select" id="SubjectCode" Name="SubjectCode" required>
                        <option value="">Select ...</option>
                        <% foreach (var Entity in Subjects) { %>
                            <option value="<%= Entity.Code %>"><%= Entity.Name %></option>
                        <% } %>
                    </select>
                </div>
                <div class="mb-3">
                    <label for="ProfessorId" class="form-label">Professor</label>
                    <select class="form-select" id="ProfessorId" Name="ProfessorId" required>
                        <option value="">Select ...</option>
                        <% foreach (var Entity in Professors) { %>
                            <option value="<%= Entity.Id %>"><%= Entity.Name %></option>
                        <% } %>
                    </select>
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
