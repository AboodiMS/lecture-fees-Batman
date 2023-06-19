<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pay.aspx.cs" Inherits="Project.ProjectSections.TheForms.Pay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Pay</h1>
    <form>
    <div class="mb-3">
        <label for="Name" class="form-label">Form Date : </label>
        <lable  class="form-label"><%= Entity?.FormDate.ToString("yyyy/MM/dd") %></lable>
    </div>
     <div class="mb-3">
        <label for="ScientificRankCode" class="form-label">Subject : </label>
        <lable  class="form-label"><%= Entity?.Subject.Name %></lable>
    </div>
    <div class="mb-3">
        <label for="ScientificRankCode" class="form-label">Professor : </label>
        <lable  class="form-label"><%= Entity?.Professor.Name %></lable>
    </div>
    <div class="mb-3">
        <label for="ScientificRankCode" class="form-label">Scientific Rank : </label>
        <lable  class="form-label"><%= Entity?.ScientificRank.Title %></lable>
    </div>
    <div class="mb-3">
        <label for="LecturePriceId" class="form-label">Lecture Hours : </label>
        <lable  class="form-label"><%= Entity?.LectureHours.Title %></lable>
    </div>
    <div class="mb-3">
        <label for="Price" class="form-label">Price : </label>
        <lable  class="form-label"><%= Entity?.Price %></lable>
    </div>
    <div class="mb-3">
        <label for="NumberOfHours" class="form-label">Number Of Hours : </label>
        <lable  class="form-label"><%= Entity?.NumberOfHours %></lable>
    </div>
    <div class="mb-3">
        <label for="IsPaid" class="form-label">Is Paid :</label>
        <% if(Entity?.IsPaied==true) { %>
             <input type="checkbox" id="IsPaid" name="IsPaid" class="form-check-input" checked/>
        <% } else { %>
             <input type="checkbox"  id="IsPaid" name="IsPaid" class="form-check-input" />
        <% } %>
    </div>
    <div id="errorContainer" runat="server" class="alert alert-danger" style="display: none;"></div>
    <asp:Button ID="SubmitButton" runat="server" Text="Edit Pay" CssClass="btn btn-danger" EnableEventValidation="false"  OnClick="SubmitButton_Click" />

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
