using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using Test.ExportFile;
using Test.HelperClass;
using System.Collections;

namespace Test.ViewModels
{
    public class CarViewModel 
    {
        private ICommand _exportToCSV;
        private ICommand _exportToTXT;
        private ICommand _selectedRow;
        private ICommand _includeSelectionMode;
        private SelectionMode _selectMode;
        private IList BufferList = null;

        public ObservableCollection<CarModel> ListOfCar { get; } = new ObservableCollection<CarModel>();

        public CarViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            ListOfCar.Add(new CarModel(1, "Ferrari F12", new DateTime(2016, 1, 25).ToString("dd/MM/yyyy"), 250000));
            ListOfCar.Add(new CarModel(2, "Honda Civic", new DateTime(1998, 2, 16).ToString("dd/MM/yyyy"), 20000));
            ListOfCar.Add(new CarModel(3, "Chevrolet", new DateTime(2020, 10, 10).ToString("dd/MM/yyyy"), 18000));
            ListOfCar.Add(new CarModel(4, "Ford", new DateTime(2018, 5, 7).ToString("dd/MM/yyyy"), 24100));
            ListOfCar.Add(new CarModel(5, "Lada", new DateTime(2008, 3, 15).ToString("dd/MM/yyyy"), 7890));
            ListOfCar.Add(new CarModel(6, "Suzuki", new DateTime(1987, 4, 12).ToString("dd/MM/yyyy"), 45500));
            ListOfCar.Add(new CarModel(7, "Mercedec", new DateTime(2003, 9, 24).ToString("dd/MM/yyyy"), 10000));
            ListOfCar.Add(new CarModel(8, "B.M.W", new DateTime(2001, 12, 5).ToString("dd/MM/yyyy"), 13789));
        }

        /// <summary>
        /// Команда для экспорта в формат CSV
        /// </summary>
        public ICommand ExportToCSV
        {
            get
            {

                if (_exportToCSV is null)
                {
                    _exportToCSV = new RelayCommand(x => ExportToCSVFile(), x => true);
                }
                return _exportToCSV;
            }

        }

        /// <summary>
        /// Команда для Экспорта в TXT
        /// </summary>
        public ICommand ExportToTxt
        {
            get
            {
                if (_exportToTXT is null)
                {
                    _exportToTXT = new RelayCommand(x => ExportToTxtFile(), x => true);
                }
                return _exportToTXT;
            }

        }

        /// <summary>
        /// Команда принимает конкретную строку и передается списком
        /// </summary>
        public ICommand SelectedRowCommand
        {
            get
            {
                if (_selectedRow is null)
                {
                    _selectedRow = new RelayCommand(x => SelectedRow(x), x => true);
                }
                return _selectedRow;
            }
        }


        /// <summary>
        /// Команда для включения режима множественной выборки
        /// </summary>
        public ICommand IncludeSelectionModeCommand
        {
            get
            {
                if (_includeSelectionMode is null)
                {
                    _includeSelectionMode = new RelayCommand(param => IncludeSelectionMode((SelectionMode)param), param => true);
                }
                return _includeSelectionMode;
            }
        }

        /// <summary>
        /// Авто свойство изменяющее режим выборки
        /// </summary>
        public SelectionMode CurrentSelectMode
        {
            get => _selectMode;
            set
            {
                _selectMode = value;
            }
        }

        /// <summary>
        /// Метод оперделяет включет множественную выборку при нажатии на клавишу CTRL
        /// </summary>
        private void IncludeSelectionMode(SelectionMode mode)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                CurrentSelectMode = SelectionMode.Extended;
            }
        }

        /// <summary>
        /// Метод принимающий список из выбранных элементов
        /// </summary>
        private void SelectedRow(object obj)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                BufferList = obj as IList;
              

            }
        }

        /// <summary>
        /// Экспорт списка в формат CSV
        /// </summary>
        private async void ExportToCSVFile()
        {
           
            IExport export = new Export();
            if (BufferList != null && BufferList.Count > 0)
            {
                await export.CSV(BufferList);
            }

        }

        /// <summary>
        /// Экспорт списка в формат TXT
        /// </summary>
        private async void ExportToTxtFile()
        {
            IExport export = new Export();
            if (BufferList != null && BufferList.Count > 0)
            {
                await export.Txt(BufferList);
            }
        }
    }
}
