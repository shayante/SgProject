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
            var registered = new State(InventoryVoucherState.Registered,"InventoryVoucher_registered");
            var confirmed = new State(InventoryVoucherState.Confirmed, "InventoryVoucher_confirmed");
            var invalidated = new State(InventoryVoucherState.Invalidated, "InventoryVoucher_invalidated");

            States.Add(registered);
            States.Add(confirmed);
            States.Add(invalidated);

            InitialState = registered;

            Transitions.Add(new ManualTransition(registered, confirmed, "Labels_ConfirmVoucher", securityKey: "Confirm"));
            Transitions.Add(new ManualTransition(registered, invalidated, "Labels_InvalidateVoucher", securityKey: "Invalidate"));
            Transitions.Add(new ManualTransition(confirmed, registered, "Labels_ReturnFromConfirmed", securityKey: "ReturnFromConfirmed"));

        }
    }
}
