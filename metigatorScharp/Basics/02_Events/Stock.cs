using Basics._02_Events;
using System;
using static Basics._02_Events.clsEvents;

namespace Basics._02_Events
{
    public class Stock // Publisher
    {
        public event StockPriceChangeHandler OnPriceChanged;

        private string  _name;
        private decimal _price;

        public string Name => this._name;
        public decimal Price { get => this._price;  set => this._price = value ; }

        public Stock(string stockname)
        {
            this._name = stockname;
        }

        public void ChangeStockPriceBy(decimal percent)
        {
            decimal oldPrice = this.Price;

            this.Price += Math.Round(this.Price * percent, 2);

            if (OnPriceChanged != null) // make sure there is subscriber ** Listen
            {
                OnPriceChanged(this, oldPrice); // firing the event

            }

        }

    }
}
