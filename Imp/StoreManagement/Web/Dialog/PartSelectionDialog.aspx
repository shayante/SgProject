<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartSelectionDialog.aspx.cs" Inherits="SystemGroup.Training.StoreManagement.Web.Dialog.PartSelectionDialog" %>
<%@ Register TagPrefix="sg" Namespace="SystemGroup.Web.UI.Controls" Assembly="SystemGroup.Web" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <sg:SgScriptManager runat="server" ID="scriptManager">
            <Scripts>
                <asp:ScriptReference Path="~/Training/StoreManagement/StorePages/Edit.js" />
            </Scripts>
            
        </sg:SgScriptManager>
        <sg:SgUpdatePanel runat="server" ID="updMain">
            <ContentTemplate>
                <sg:SgDialogLayout runat="server" ID="dlgPartSelection" width="800" height="381">
                    <sg:SgTableRow    >
                        <sg:SgTableCell >
                            <sg:SgEntityList ID="elParts" runat="server" AllowMultiRowSelection="true"
                                ComponentName="SystemGroup.Training.StoreManagement" EntityName="Part" 
                                
                                
                                ViewName="AvailablePartForStore" >
                                <ViewParameters>
                                    <sg:SgViewParameter Name="igonreIDs"  />
                                </ViewParameters>
    
                            </sg:SgEntityList>
                        </sg:SgTableCell>
                    </sg:SgTableRow>
                    <sg:SgTableRow>
                        <sg:SgTableCell>
                            <sg:SgButton ID="btnOk" runat="server" TextKey="Labels_ApplySelection" OnClick="btnOK_Click"  /> 
               
                            <sg:SgButton ID="btnCancel" runat="server" TextKey="Labels_CancelSelection" OnClientClick="btnCancel_ClientClick(event)"  />

                            <sg:SgHiddenField ID="hiddenFieldPartIdSelection" runat="server" ValueTypeName="System.String" />
               
                            
                        </sg:SgTableCell>
                    </sg:SgTableRow>
                </sg:SgDialogLayout>
            </ContentTemplate>
        </sg:SgUpdatePanel>
    </form>
</body>
</html>
