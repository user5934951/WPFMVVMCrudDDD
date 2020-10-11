using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMVVMCrudDDD.ViewModel;

namespace WPFMVVMCrudDDD
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel
        {
            get { return IocKernel.Get<MainViewModel>(); }
        }
    }
}
