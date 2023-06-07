<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="Login.aspx.cs" Inherits="Project.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form runat="server">
        <div class="container">
            <div class="row justify-content-center mt-5">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="text-center">Login</h4>
                        </div>
                        <div class="card-body">
                            <div class="mb-3">
                                <label for="userName" class="form-label">User Name</label>
                                <input type="text" class="form-control" id="userName" value="admin" placeholder="Enter your user name" runat="server">
                            </div>
                            <div class="mb-3">
                                <label for="password" class="form-label">Password</label>
                                <input type="password" class="form-control" id="password" value="admin" placeholder="Enter your password" runat="server">
                            </div>
                            <div class="text-center">
                                <div id="errorContainer" runat="server" class="alert alert-danger" style="display: none;"></div>
                                <asp:Button ID="SubmitButton" name="SubmitButton" runat="server" Text="Login" CssClass="btn btn-primary" EnableEventValidation="false" OnClick="SubmitButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script>
        $(document).ready(function () {
            $('#errorContainer').click(function () {
                $(this).hide();
            });
        });
    </script>
</body>
</html>