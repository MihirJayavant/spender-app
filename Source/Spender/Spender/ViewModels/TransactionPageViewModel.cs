
using Core.Services;
using Core.Transactional;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Prism.Commands;
using System;
using System.Threading.Tasks;
using System.Globalization;
using Spender.Services;

namespace Spender.ViewModels
{
    
    public class TransactionPageViewModel : BindableBase
    {
        public ObservableCollection<TransactionComponentModel> TransactionList { get; } 
            = new ObservableCollection<TransactionComponentModel>();

        private string amountEntry;

        public string AmountEntry
        {
            get => amountEntry;
            set => SetProperty(ref amountEntry, value);
        }

        public DelegateCommand AddCommand { get; }
        readonly ITransactionService transactionService;
        readonly ILocalizationService localization;
        private int id = 0;

        public TransactionPageViewModel(ITransactionService transactionService, ILocalizationService localizationService)
        {
            this.transactionService = transactionService;
            localization = localizationService;
            AddCommand = new DelegateCommand(AddTrans);
        }

        public async Task SetId(int id)
        {
            this.id = id;
            var result = await transactionService.GetAll(id, 50, 0);
            var culture = new CultureInfo(localization.GetCurrency());
            if(result.IsLoaded)
            {
                foreach (var item in result.Data.Data)
                {
                    TransactionList.Add(new TransactionComponentModel(item, culture));
                }
            }
        }

        async void AddTrans()
        {
            int.TryParse(amountEntry, out int amount);
            AmountEntry = null;
            var culture = new CultureInfo(localization.GetCurrency());

            if (amount != 0)
            {
                var trans = new Transaction(0, "", amount, DateTime.Now);
                var result = await transactionService.Add(id, trans);

                if(result.IsLoaded)
                {
                    TransactionList.Add(new TransactionComponentModel(result.Data, culture));
                }
            }
        }

    }

    public class TransactionComponentModel
    {
        public int Id { get; }
        public string Title { get; }
        public double Amount { get; }
        public string HorizontalOptions { get; set; }
        public DateTime Date { get; }
        public string DisplayAmount { get; }
        public string DisplayDate => Date.ToString("d MMM, h:m tt");

        public TransactionComponentModel(Transaction trans, CultureInfo culture)
        {
            Id = trans.Id;
            Title = trans.Title;
            Amount = trans.Amount;
            Date = trans.Date;
            if (Amount < 0)
            {
                var amt = -Amount;
                DisplayAmount = amt.ToString("C", culture);
                HorizontalOptions = "End";
            }
            else
            {
                DisplayAmount = Amount.ToString("C", culture);
                HorizontalOptions = "Start";
            }
        }

        public Transaction toCore() => new Transaction(Id, Title, Amount, Date);
    }
}
