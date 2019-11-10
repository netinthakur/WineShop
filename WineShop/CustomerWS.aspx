<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerWS.aspx.cs" Inherits="WineShop.CustomerWS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal" style="margin-top: 25px;">
        <div class=" col-md-6">
            <div class="form-group">
                <label for="name">Name:</label>
                <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="submit" ControlToValidate="txtName" runat="server" ErrorMessage="Please enter name"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class=" col-md-6">
            <div class="form-group">
                <label for="age">Age:</label>
                <asp:TextBox ID="txtAge" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAge" ValidationGroup="submit" ControlToValidate="txtAge" runat="server" ErrorMessage="Please enter age"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class=" col-md-6">
            <div class="form-group">
                <label for="email">Email:</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" ValidationGroup="submit" ControlToValidate="txtEmail" runat="server" ErrorMessage="Please enter email"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class=" col-md-6">
            <div class="form-group">
                <label for="wine">Wine:</label>
                <asp:DropDownList ID="DropDownListWine" Style="margin-left: auto; margin-right: auto; text-align: center;" runat="server" CssClass="form-control" AutoPostBack="True">
                </asp:DropDownList>
            </div>
        </div>
        <div class=" col-md-6">
            <div class="form-group">
                <label for="ratelist">Rate List:</label>
                <asp:DropDownList ID="ddl_RateList" Style="margin-left: auto; margin-right: auto; text-align: center;" runat="server" CssClass="form-control" AutoPostBack="True">
                </asp:DropDownList>
            </div>
        </div>
        <asp:Button ID="btnSave" ValidationGroup="submit" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSave_Click" />
        <asp:Button ID="BtnDelete" runat="server" Text="Reset" class="btn btn-info" OnClick="BtnReset_Click" />
        <br />
        <br />
    </div>
    <div class="box-body">
        <div id="datatable-responsive_wrapper" class="dataTables_wrapper form-inline dt-bootstrap no-footer">
            <asp:GridView ID="grd" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" CaptionAlign="Top" AllowPaging="True"
                                    EnableSortingAndPagingCallbacks="True" PageSize="5" HorizontalAlign="Left" AllowSorting="True" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                                    <AlternatingRowStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="Age" HeaderText="Age" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
                                        <asp:BoundField DataField="WineID" HeaderText="Wine" />
                                        <asp:BoundField DataField="RateListID" HeaderText="RateList" />
                                    </Columns>
                                    <EditRowStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <EmptyDataRowStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <FooterStyle BackColor="White" ForeColor="#333333" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#336666" />
                                    <RowStyle BackColor="White" ForeColor="#333333" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <SortedAscendingCellStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#487575" />
                                    <SortedDescendingCellStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#275353" />
                                </asp:GridView>
        </div>
    </div>
</asp:Content>
