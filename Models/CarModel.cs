using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Test.ViewModels
{

    /// <summary>
    /// Медель данных
    /// </summary>
    public class CarModel :ViewModelBase
    {
        private int _id;
        private string _nameModel;
        private string _dateOfIssue;
        private decimal _price;

        public CarModel(int id, string nameModel, string dateOfIssue, decimal price)
        {
            Id = id;
            NameModel = nameModel;
            DateOfIssue = dateOfIssue;
            Price = price;
        }

        public int Id
        {
            get => _id;
            set
            {
                if (value != _id)
                {
                    _id = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string NameModel
        {
            get => _nameModel;
            set
            {
                if (value != _nameModel)
                {
                    _nameModel = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string DateOfIssue
        {
            get => _dateOfIssue;
            set
            {
                if (value != _dateOfIssue)
                {
                    _dateOfIssue = value;
                    RaisePropertyChanged();
                }
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value != _price)
                {
                    _price = value;
                    RaisePropertyChanged();
                }
            }
        }
       
    }
}
