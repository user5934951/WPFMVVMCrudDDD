using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMVVMCrudDDD.Domain.Contracts;
using WPFMVVMCrudDDD.Domain.Repositories;
using WPFMVVMCrudDDD.Domain.Services;
using WPFMVVMCrudDDD.Repository;
using WPFMVVMCrudDDD.ViewModel;

namespace WPFMVVMCrudDDD
{
    class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<ApplicationDbContext>().ToSelf().InSingletonScope().WithConstructorArgument("connString", ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString); // Reuse same storage every time
            Bind<IProductRepository>().To<ProductRepository>().InTransientScope();
            Bind<IProductService>().To<ProductService>().InTransientScope();
            Bind<MainViewModel>().ToSelf().InSingletonScope();
        }
    }
}
