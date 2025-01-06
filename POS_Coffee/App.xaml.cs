using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using POS_Coffee.Data;
using POS_Coffee.Repositories;
using POS_Coffee.Utilities;
using POS_Coffee.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using CommunityToolkit.WinUI.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace POS_Coffee
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF1cWGhIYVZpR2Nbek5xdV9EZVZSTGYuP1ZhSXxXd0djX35fdHJVT2dZU0U=");
            this.InitializeComponent();
            Services = ConfigureServices();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            var window = new MainWindow();
            window.Activate();
            mainWindow = window;
        }
        public static MainWindow mainWindow { get; private set; }
        public static Window Window => mainWindow;
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<INavigation, NavigationService>();

            services.AddSingleton<IStockDAO, SqlStockDao>();

            services.AddSingleton<IFoodDao, SqlFoodDao>();
            services.AddSingleton<IPaymentDao, SqlPaymentDao>();
            services.AddSingleton<IAccountDao, SqlAccountDao>();
            services.AddSingleton<IPaymentDetailDao, SqlPaymentDetailDao>();
            services.AddSingleton<IPromotionDao,SqlPromotionDao>();
            services.AddSingleton<IMembersDao, SqlMemberDao>();

            services.AddTransient<MainViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<StockViewModel>();
            services.AddTransient<FoodViewModel>();
            services.AddTransient<CartItemViewModel>();
            services.AddTransient<PaymentViewModel>();
            services.AddTransient<ReportViewModel>();
            services.AddTransient<PromotionViewModel>();
            services.AddTransient<CreatePromotionViewModel>();
            services.AddTransient<UpdatePromotionViewModel>();
            services.AddTransient<EmployeeViewModel>();
            services.AddTransient<SalaryViewModel>();
            services.AddTransient<MembersViewModel>();
            services.AddTransient<AddEmployeeViewModel>();


            services.AddDbContext<PosDbContext>(option =>
            option.UseSqlServer("Server=localhost;Database=PosCoffeeDb;Trusted_Connection=True;TrustServerCertificate=True"));

            return services.BuildServiceProvider();
        }
    }
}
