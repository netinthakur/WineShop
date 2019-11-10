<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WineUpdateWS.aspx.cs" Inherits="WineShop.WineUpdateWS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal" style="margin-top: 25px;">
        <div class=" col-md-6">
            <div class="form-group">
                <label for="wine">Wine:</label>
                <asp:DropDownList ID="DropDownListWine" Style="margin-left: auto; margin-right: auto; text-align: center;" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListWine_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div class=" col-md-6">
            <div class="form-group">
                <label for="name">Name:</label>
                <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" ValidationGroup="submit" ControlToValidate="txtName" runat="server" ErrorMessage="Please enter name"></asp:RequiredFieldValidator>
            </div>
        </div>
        <asp:Button ID="btnUpdate" ValidationGroup="submit" runat="server" Text="Update" class="btn btn-primary" OnClick="btnUpdate_Click" />
        <asp:Button ID="BtnDelete" runat="server" Text="Delete" class="btn btn-info" OnClick="BtnDelete_Click" />
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
