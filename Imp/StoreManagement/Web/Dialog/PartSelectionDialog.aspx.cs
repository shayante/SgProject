using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SystemGroup.Framework.Extensions;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.Utilities;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Training.StoreManagement.Web.StorePages;
using SystemGroup.Web;
using SystemGroup.Web.UI;

namespace SystemGroup.Training.StoreManagement.Web.Dialog
{
    public partial class PartSelectionDialog : SgPage
    {
        #region Methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            elParts.ViewParameters[0].Value = ShortTermSessionState.Current[Request.QueryString["partsKey"]];
        }


        protected void btnSelectAll_Click(object sender, EventArgs e)
        {

            var metaView = (IMetaSimpleView)MetadataService.GetMetaEntity<Part>().Views[elParts.ViewName];
            var filterExpr = elParts.MakeFilterExpression();
            var inlineFilters = elParts.InlineFilterExpression.Convert();
            var sortExpr = elParts.SortExpression.Convert();


            elParts.ViewParameters[0].Value = ShortTermSessionState.Current[Request.QueryString["partsKey"]];
            var parameterValues = elParts.ViewParameters.Select(p => p.Value).ToArray();

            IQueryable filteredQuery = metaView.GetFilteredQuery(filterExpr, null, inlineFilters, sortExpr, 0, 0, parameterValues);
            //.ToArray();


            //var selectedIDs = new List<long>();


            //foreach (var item in filteredQuery)
            //{
            //    var id = new ObjectWrapper(item).ValueOf("ID").As<long>();
            //    selectedIDs.Add(id);
            //    //if (!partIDs.Contains(id))
            //    //    partIDs.Add(id);
            //}

            //var selectedIDs = filteredQuery;

            var exp = filteredQuery.Expression as MethodCallExpression;
            filteredQuery = filteredQuery.Provider.CreateQuery(exp.Arguments[0]);

            var param = Expression.Parameter(filteredQuery.ElementType);

            var selectedIDs = filteredQuery.Provider.CreateQuery<long>(
                Expression.Call(
                    typeof(Queryable),
                    "Select",
                    new Type[] { filteredQuery.ElementType, typeof(long) },
                    filteredQuery.Expression,
                    Expression.Lambda(
                        Expression.Property(
                            param,
                            "ID"
                        ),
                       param
                    )
                )
            ).ToArray();

            var key = ShortTermSessionState.Current.Add(selectedIDs);
            System.Web.UI.ScriptManager.RegisterStartupScript(
                this,
                typeof(EditStore),
                "PartSelection_OnClientClose",
                $"btnOK_ClientClick('{key}')",
                true);
        }


        protected void btnOK_Click(object sender, EventArgs e)
        {
            var selectedIDs = elParts.SelectedRecordIDs;
            var key = ShortTermSessionState.Current.Add(selectedIDs);
            System.Web.UI.ScriptManager.RegisterStartupScript(
                this,
                typeof(EditStore),
                "PartSelection_OnClientClose",
                $"btnOK_ClientClick('{key}')",
                true);
        }


        #endregion
    }
}