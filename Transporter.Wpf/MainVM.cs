using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Transporter.Wpf
{
    class MainVM : ViewModelBase
    {
        private MainLogic logic;
        private CustomerVM selectedCustomer;
        private ObservableCollection<CustomerVM> allCustomers;

        public ObservableCollection<CustomerVM> AllCustomers
        {
            get { return allCustomers; }
            set { Set(ref allCustomers, value); }
        }

        public CustomerVM SelectedCustomer
        {
            get { return selectedCustomer; }
            set { Set(ref selectedCustomer, value); }
        }

        public ICommand AddCmd { get; private set; }
        public ICommand DelCmd { get; private set; }
        public ICommand ModCmd { get; private set; }
        public ICommand LoadCmd { get; private set; }

        public Func<CustomerVM, bool> Editorfunc { get; set; }

        public MainVM()
        {
            logic = new MainLogic();

            DelCmd = new RelayCommand(() => logic.ApiDelCustomer(selectedCustomer));
            AddCmd = new RelayCommand(() => logic.EditCustomer(null, Editorfunc));
            ModCmd = new RelayCommand(() => logic.EditCustomer(selectedCustomer, Editorfunc));
            LoadCmd = new RelayCommand(() => AllCustomers = new ObservableCollection<CustomerVM>(logic.ApiGetCustomers()));
        }


    }
}
