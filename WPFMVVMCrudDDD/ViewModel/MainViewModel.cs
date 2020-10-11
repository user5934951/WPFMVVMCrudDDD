using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WPFMVVMCrudDDD.Domain.Contracts;
using WPFMVVMCrudDDD.Domain.Models;

namespace WPFMVVMCrudDDD.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IProductService _productService;
        private ICommand _adder;
        private ICommand _deleter;
        private ICommand _updater;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Product> _products;
        private Product _selectedProduct;
        private string _addName;
        private string _addCount;

        public string AddName
        {
            get { return _addName; }
            set { _addName = value; 
                OnPropertyChanged("AddName"); }
        }

        public string AddCount
        {
            get { return _addCount; }
            set { _addCount = value;
                OnPropertyChanged("AddCount");
            }
        }

        public MainViewModel(IProductService productService)
        {
            _productService = productService;
            Products = new ObservableCollection<Product>(_productService.GetAllItems().ToList());
        }

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged("Products");
            }
        }

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    OnPropertyChanged("SelectedProduct");
                }
            }
        }

        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if (_adder == null)
                    _adder = new Adder(AddProduct, CanAddProduct);
                return _adder;
            }
            set
            {
                _adder = value;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleter == null)
                    _deleter = new Deleter(DeleteProduct, CanDeleteProduct);
                return _deleter;
            }
            set
            {
                _deleter = value;
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                if (_updater == null)
                    _updater = new Deleter(UpdateProduct, CanUpdateProduct);
                return _updater;
            }
            set
            {
                _updater = value;
            }
        }

        private void AddProduct(object parameter)
        {
            Product newProduct = new Product() { Name = AddName, Count = int.Parse(AddCount) };
            _productService.Add(newProduct);
            AddName = null;
            AddCount = null;
            Products = new ObservableCollection<Product>(_productService.GetAllItems().ToList());
        }

        private void DeleteProduct(object parameter)
        {
            _productService.Remove(SelectedProduct.Id);
            Products = new ObservableCollection<Product>(_productService.GetAllItems().ToList());
        }

        private void UpdateProduct(object parameter)
        {
            Product existing = _productService.GetById(SelectedProduct.Id);
            existing.Name = SelectedProduct.Name;
            existing.Count = SelectedProduct.Count;
            _productService.Update(existing);
            Products = new ObservableCollection<Product>(_productService.GetAllItems().ToList());
        }

        private bool CanAddProduct(object parameter)
        {
            Regex regex = new Regex("^[0-9]*$");
            if (string.IsNullOrEmpty(AddCount))
                return false;
            return regex.IsMatch(AddCount);
        }

        private bool CanDeleteProduct(object parameter)
        {
            return SelectedProduct != null;
        }

        private bool CanUpdateProduct(object parameter)
        {
            return SelectedProduct != null;
        }
    }

    public class Adder : ICommand
    {
        Action<object> _execteMethod;
        Func<object, bool> _canexecuteMethod;

        public Adder(Action<object> execteMethod, Func<object, bool> canexecuteMethod)
        {
            _execteMethod = execteMethod;
            _canexecuteMethod = canexecuteMethod;
        }
        #region ICommand Members  

        public bool CanExecute(object parameter)
        {
            if (_canexecuteMethod != null)
            {
                return _canexecuteMethod(parameter);
            }
            else
            {
                return false;
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execteMethod(parameter);
        }
        #endregion
    }

    public class Deleter : ICommand
    {
        Action<object> _execteMethod;
        Func<object, bool> _canexecuteMethod;

        public Deleter(Action<object> execteMethod, Func<object, bool> canexecuteMethod)
        {
            _execteMethod = execteMethod;
            _canexecuteMethod = canexecuteMethod;
        }
        #region ICommand Members  

        public bool CanExecute(object parameter)
        {
            if (_canexecuteMethod != null)
            {
                return _canexecuteMethod(parameter);
            }
            else
            {
                return false;
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execteMethod(parameter);
        }
        #endregion
    }
}
