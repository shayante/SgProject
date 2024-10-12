<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PartSelectionDialog.ascx.cs"
    Inherits="SystemGroup.Training.StoreManagement.Web.Dialog.PartSelectionDialog" %> 
 

<%@ Register TagPrefix="sg" Namespace="SystemGroup.Web.UI.Controls" Assembly="SystemGroup.Web" %>

<sg:SgUpdatePanel runat="server" ID="updDialog" ClientIDMode="Static">
    <ContentTemplate >
        <sg:SgDialogLayout runat="server" ID="dlgPartSelection" width="800" height="381" ClientIDMode="Static">
            <sg:SgTableRow  runat="server"  >
                <sg:SgTableCell runat="server" >
                    <sg:SgEntityList ID="elParts" runat="server" AllowMultiRowSelection="true"
                        ComponentName="SystemGroup.Training.StoreManagement" EntityName="Part" 
                        AllowGrouping="false"
                        
                        ViewName="AllParts" >
    
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
