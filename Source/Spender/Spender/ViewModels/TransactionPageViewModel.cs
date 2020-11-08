
using Core.Services;
using Core.Transactional;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Prism.Commands;
using System;
using System.Threading.Tasks;

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
        private int id = 0;

        public TransactionPageViewModel(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
            AddCommand = new DelegateCommand(AddTrans);
        }

        public async Task SetId(int id)
        {
            this.id = id;
            var result = await transactionService.GetAll(id, 50, 0);
            if(result.IsLoaded)
            {
                foreach (var item in result.Data.Data)
                {
                    TransactionList.Add(item);
                }
            }
        }

        async void AddTrans()
        {
            int.TryParse(amountEntry, out int amount);
            AmountEntry = null;
            if(amount != 0)
            {
                var trans = new Transaction(0, "", amount, DateTime.Now);
                var result = await transactionService.Add(id, trans);

                if(result.IsLoaded)
                {
                    TransactionList.Add(result.Data);
                }
            }
        }

    }
}
