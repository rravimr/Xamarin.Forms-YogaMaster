using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace YogaMaster.Shared.Controls
{
    public class CustomStepper : StackLayout
    {
        Button PlusBtn;
        Button MinusBtn;
        Entry Entry;

        public static readonly BindableProperty TextProperty =
          BindableProperty.Create(
             propertyName: "Text",
              returnType: typeof(int),
              declaringType: typeof(CustomStepper),
              defaultValue: 1,
              defaultBindingMode: BindingMode.TwoWay);

        public int Text
        {
            get { return (int)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public CustomStepper()
        {
            PlusBtn = new Button { Text = "+", WidthRequest = 40, FontAttributes = FontAttributes.Bold, FontSize = 15 };
            MinusBtn = new Button { Text = "-", WidthRequest = 40, FontAttributes = FontAttributes.Bold, FontSize = 15 };

            Orientation = StackOrientation.Horizontal;
            PlusBtn.Clicked += PlusBtn_Clicked;
            MinusBtn.Clicked += MinusBtn_Clicked;

            Entry = new Entry
            {   
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Keyboard = Keyboard.Numeric,
                MaxLength = 3,
                FontSize = 15,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };
            if(Device.RuntimePlatform == Device.Android)
            {
                Entry.WidthRequest = 50;
            }
            Entry.SetBinding(Entry.TextProperty, new Binding(nameof(Text), BindingMode.TwoWay, source: this));
            Entry.TextChanged += Entry_TextChanged;
            Children.Add(PlusBtn);
            Children.Add(Entry);
            Children.Add(MinusBtn);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue) && System.Text.RegularExpressions.Regex.IsMatch(e.NewTextValue, "^[0-9]+$"))
            {
                this.Text = int.Parse(e.NewTextValue);
            }
        }

        private void MinusBtn_Clicked(object sender, EventArgs e)
        {
            if (Text > 1)
                Text--;
        }

        private void PlusBtn_Clicked(object sender, EventArgs e)
        {
            Text++;
        }

    }
}
