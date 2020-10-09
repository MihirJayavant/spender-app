using Spender.Configurations;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spender.Localization
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension<BindingBase>
    {
        public string Text { get; set; }
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }

        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding
            {
                Mode = BindingMode.OneWay,
                Path = $"[{Text}]",
                Source = AppContainer.Instance.Resolve<LocalizationResourceManager>(),
            };
            return binding;
        }
    }
}
