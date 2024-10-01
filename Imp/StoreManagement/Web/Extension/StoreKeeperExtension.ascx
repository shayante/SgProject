<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StoreKeeperExtension.ascx.cs"
Inherits="SystemGroup.Training.StoreManagement.Web.Extension.StoreKeeperExtension" %>
<%@ Register TagPrefix="sg" Namespace="SystemGroup.Web.UI.Controls" Assembly="SystemGroup.Web" %>

<sg:SgUpdatePanel ID="updStoreKeeper" runat="server">
    <ContentTemplate>
        <sg:SgFieldSet runat="server">
            <sg:SgCheckBox ID="chkStoreKeeper" runat="server" TextKey="StoreKeeper_StoreKeeper"/>
        </sg:SgFieldSet>
    </ContentTemplate>
</sg:SgUpdatePanel>