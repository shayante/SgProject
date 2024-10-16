<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="SystemGroup.Training.Pricing.Web.InventoryVoucherPricingPages.Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <sg:SgScriptManager runat="server" ID="scriptManager">
            <Scripts>
                <asp:ScriptReference Path="~/Training/Pricing/InventoryVoucherPricingPages/Edit.js" />
            </Scripts>
        </sg:SgScriptManager>
        <sg:SgUpdatePanel runat="server" ID="updMain">
            <ContentTemplate>

                <sg:SgToolBar ID="toolbar" runat="server" OnButtonClick="toolbar_Click" >
                    <Items>
                        <sg:SgToolBarButton imageurl="~/Icons/Save.gif" value="Save" ToolTipKey="s:SgPage_Save" ShortKey="(Ctrl+S)" />
                        <sg:SgToolBarButton imageurl="~/Icons/SaveAndClose.gif" value="SaveAndClose"  ToolTipKey="s:SgPage_SaveAndClose" ShortKey="(Ctrl+Shift+B)"/>
                    </Items>
                </sg:SgToolBar>

                <sg:SgFieldSet runat="server" LegendKey="Training.StoreManagement:Labels_InventoryInfo">
                    <sg:SgDynamicFieldLayout runat="server" NumberOfColumn="2">
                        <sg:SgDynamicTableRow>
                            <sg:SgTableCell>
                                <sg:SgFieldLabel runat="server" TextKey="Training.StoreManagement:InventoryVoucher_Number"/>
                            </sg:SgTableCell>
                            
                            <sg:SgTableCell>
                                <sg:SgTextBox runat="server" ReadOnly="true" ID="txtNumber"/>
                            </sg:SgTableCell>
                        </sg:SgDynamicTableRow>

                        <sg:SgDynamicTableRow>
                            <sg:SgTableCell>
                                <sg:SgFieldLabel runat="server" TextKey="Training.StoreManagement:InventoryVoucher_StoreRef"/>
                            </sg:SgTableCell>
    
                            <sg:SgTableCell>
                                <sg:SgTextBox runat="server" ReadOnly="true" ID="txtStore"/>
                            </sg:SgTableCell>
                        </sg:SgDynamicTableRow>

                        
                        <sg:SgDynamicTableRow>
                            <sg:SgTableCell>
                                <sg:SgFieldLabel runat="server" TextKey="Training.StoreManagement:InventoryVoucher_StoreKeeperRef"/>
                            </sg:SgTableCell>
    
                            <sg:SgTableCell>
                                <sg:SgTextBox runat="server" ReadOnly="true" ID="txtStoreKeeper"/>
                            </sg:SgTableCell>
                        </sg:SgDynamicTableRow>

                        
                        <sg:SgDynamicTableRow>
                            <sg:SgTableCell>
                                <sg:SgFieldLabel runat="server" TextKey="Training.StoreManagement:InventoryVoucher_Date"/>
                            </sg:SgTableCell>
    
                            <sg:SgTableCell>
                                <sg:SgDatePicker runat="server" ReadOnly="true" ID="dpDate"/>
                            </sg:SgTableCell>
                        </sg:SgDynamicTableRow>

                        
                        <sg:SgDynamicTableRow>
                            <sg:SgTableCell>
                                <sg:SgFieldLabel runat="server" TextKey="Training.StoreManagement:InventoryVoucher_Type"/>
                            </sg:SgTableCell>
    
                            <sg:SgTableCell>
                                <sg:SgTextBox runat="server" ReadOnly="true" ID="txtType"/>
                            </sg:SgTableCell>
                        </sg:SgDynamicTableRow>

                        
                        
                        <sg:SgDynamicTableRow>
                            <sg:SgTableCell>
                                <sg:SgFieldLabel runat="server" TextKey="Training.StoreManagement:InventoryVoucher_State"/>
                            </sg:SgTableCell>
    
                            <sg:SgTableCell>
                                <sg:SgTextBox runat="server" ReadOnly="true" ID="txtState"/>
                            </sg:SgTableCell>
                        </sg:SgDynamicTableRow>
                    </sg:SgDynamicFieldLayout>
                </sg:SgFieldSet>


                <sg:SgFieldSet runat="server" LegendKey="Training.StoreManagement:Labels_ItemGrid">
                    <sg:SgGrid ID="grdPricing" runat="server" AllowDelete="false" AllowInsert="false" width="770" 
                        AllowEdit="true" AllowScroll="true"  GridType="ClientSide" ToolBarVisibility="Hidden" 
                        DataSourceID="dsItems" ValidationGroup="vgGrid">
                        
                        <Columns>
                            <sg:SgTextGridColumn HeaderText="Training.StoreManagement:InventoryVoucherItem_PartTitle" AllowEdit="false" PropertyName="PartTitle"  />
                            <sg:SgTextGridColumn HeaderText="Training.StoreManagement:InventoryVoucherItem_UnitTitle" AllowEdit="false" PropertyName="UnitTitle"  />
                            <sg:SgDecimalGridColumn HeaderText="Training.StoreManagement:InventoryVoucherItem_Quantity" GroupSize="3" Precision="3" PropertyName="Quantity" AllowEdit="false" />

                            <sg:SgDecimalGridColumn HeaderText="Labels_Price"  GroupSize="3" Precision="2" PropertyName="EditablePrice" AllowEdit="true" >
                                <EditItemTemplate>
                                    <sg:SgDecimalInput runat="server" ID="decPrice" GroupSize="3" Precision="2"   CbValue="{binding EditablePrice}" />
                                    <sg:SgCompareValidator ErrorMessageKey="Messages_GreaterThanZiro" runat="server"
                                        ValidationGroup="vgGrid" ValueToCompare="0"
                                        ControlToValidate="decPrice" Operator="GreaterThan"/>
                                </EditItemTemplate>
                            </sg:SgDecimalGridColumn>
                        </Columns>

                    </sg:SgGrid>
                </sg:SgFieldSet>
            </ContentTemplate>
        </sg:SgUpdatePanel>
    </form>
</body>
</html>
