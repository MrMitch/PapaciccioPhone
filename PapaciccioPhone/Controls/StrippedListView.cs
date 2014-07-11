using System.Collections.Generic;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// Pour en savoir plus sur le modèle d'élément Contrôle basé sur un modèle, consultez la page http://go.microsoft.com/fwlink/?LinkId=234235

namespace PapaciccioPhone.Controls
{
    public sealed class StrippedListView : ListView
    {
        public static DependencyProperty ColorsProperty = DependencyProperty.Register(
            "Colors",
            typeof(IEnumerable<Color>),
            typeof(StrippedListView),
            new PropertyMetadata(new List<Color>()));

        public IEnumerable<Color> Colors
        {
            get { return (IEnumerable<Color>) GetValue(ColorsProperty); }
            set { SetValue(ColorsProperty, value); }
        }
        

        public StrippedListView()
        {
            this.DefaultStyleKey = typeof(ListView);
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            var count = Colors.Count();
            var index = Items.IndexOf(item) % (count > 0 ? count : 1);

            element.SetValue(BackgroundProperty, new SolidColorBrush(this.Colors.ElementAtOrDefault(index)));
        }
    }
}
