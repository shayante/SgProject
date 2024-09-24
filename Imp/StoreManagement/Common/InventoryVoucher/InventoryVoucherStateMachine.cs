using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemGroup.Framework.StateManagement.ProtoType;

namespace SystemGroup.Training.StoreManagement.Common
{
    internal class InventoryVoucherStateMachine : StateMachine<InventoryVoucher, InventoryVoucherState>
    {
        protected override void DoChangeState(InventoryVoucher record, InventoryVoucherState state, StateChangeContext context)
        {
            record.State = state;
        }

        protected override InventoryVoucherState GetCurrentStateCodeAsEnum(InventoryVoucher record)
        {
            return record.State;
        }

        protected override void InitializeStates()
        {
            var registered = new State(InventoryVoucherState.Registered,"InventortyVoucher_registered");
            var confirmed = new State(InventoryVoucherState.Confirmed, "InventortyVoucher_confirmed");
            var invalidated = new State(InventoryVoucherState.Invalidated, "InventortyVoucher_invalidated");

            InitialState = registered;  
        }
    }
}
