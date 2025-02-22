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
