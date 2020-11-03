
using Core.Services;
using Core.Transactional;
using Prism.Mvvm;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Spender.Services;
using Prism.Commands;
using System;

namespace Spender.ViewModels
{
    public class TransactionPageViewModel : BindableBase
    {
        public ObservableCollection<Transaction> TransactionList { get; } = new ObservableCollection<Transaction>();

        private string amountEntry;

        public string AmountEntry
        {
            get => amountEntry;
            set => SetProperty(ref amountEntry, value);
        }

        public DelegateCommand AddCommand { get; }
        readonly ITransactionService transactionService;

        public TransactionPageViewModel(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
            AddCommand = new DelegateCommand(AddTrans);
        }

        async void AddTrans()
        {
            int amount;
            int.TryParse(amountEntry, out amount);
            AmountEntry = null;
            if(amount != 0)
            {
                var result = await transactionService.Add(
                    new Transaction(0, "", amount, DateTime.Now)
                    );

                if(result.IsLoaded)
                {
                    TransactionList.Add(result.Data);
                }
            }
        }



    }
}
