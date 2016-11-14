using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableBuilder
{
    public class TransferActions
    {

        DataTable fromTable, toTable;
        int fromInitialBalance, fromAfterTransferBalance, toInitialBalance, toAfterTranferBalance;
        int fromIndex, toIndex;
        string fromAccountType, toAccountType;
        int transferAmount = 2;

        public TransferActions()
        {
            fromTable = toTable = DataTableUtilities.GenerateDataTable();
        }

        public void Transfer(string fromAccountType, string toAccountType, int transferAmount)
        {
            this.fromAccountType = fromAccountType;
            this.toAccountType = toAccountType;
            this.transferAmount = transferAmount;

            SelectFromAccount(fromAccountType);
            SelectToAccount(toAccountType);

            Console.WriteLine(string.Format("{0} Account Balance Before Transfer : {1}, and {2} Account Balance Before Transfer : {3}", fromAccountType, fromInitialBalance, toAccountType, toInitialBalance));
            
            TransferAmount();
            VerifyTransfer();

            Console.WriteLine(string.Format("{0} Acount Balance AFter Transfer : {1}, and {2} Account Balance After Transfer : {3}", fromAccountType, fromAfterTransferBalance, toAccountType, toAfterTranferBalance));
        }

        private void VerifyTransfer()
        {
            fromAfterTransferBalance = Int32.Parse(fromTable.Rows[fromIndex]["Balance"].ToString());
            toAfterTranferBalance = Int32.Parse(toTable.Rows[toIndex]["Balance"].ToString());

            if (fromInitialBalance - transferAmount == fromAfterTransferBalance && toInitialBalance + transferAmount == toAfterTranferBalance)
                Console.WriteLine("The Transfer is successful");
            else
                Console.WriteLine("The Transfer has an issue, look into it");

        }

        private void TransferAmount()
        {
            fromTable.Rows[fromIndex]["Balance"] = fromInitialBalance - transferAmount;
            toTable.Rows[toIndex]["Balance"] = toInitialBalance + transferAmount;

            Console.WriteLine(string.Format("Amount : {0} is transfered from {1} account to {2} account", transferAmount, fromAccountType, toAccountType));
        }

        private void SelectToAccount(string accountType)
        {
            toIndex = toTable.GetRowIndexByColumnValue("AccountType", accountType);
            Console.WriteLine(string.Format("Selected Index : {0} For AccountType : {1}", toIndex, accountType));
            toInitialBalance = Int32.Parse(toTable.Rows[toIndex]["Balance"].ToString());            
        }

        private void SelectFromAccount(string accountType)
        {
           fromIndex = fromTable.GetRowIndexByColumnValue("AccountType", accountType);
           Console.WriteLine(string.Format("Selected Index : {0} For AccountType : {1}", fromIndex, accountType));
           fromInitialBalance = Int32.Parse(fromTable.Rows[fromIndex]["Balance"].ToString());
        }

        

    }
}
