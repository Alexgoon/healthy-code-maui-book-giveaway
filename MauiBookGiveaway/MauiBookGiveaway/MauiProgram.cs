using DevExpress.Maui;
using DevExpress.Maui.Core;
using SkiaSharp.Views.Maui.Controls.Hosting;
using CommunityToolkit.Maui;

namespace MauiBookGiveaway;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        ThemeManager.ApplyThemeToSystemBars = true;
        var builder = MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            .UseDevExpress(useLocalization: false)
            .UseDevExpressControls()
            .UseDevExpressCharts()
            .UseDevExpressTreeView()
            .UseDevExpressCollectionView()
            .UseDevExpressEditors()
            .UseDevExpressDataGrid()
            .UseDevExpressScheduler()
            .UseDevExpressGauges()
            .UseSkiaSharp()
            .UseMauiCommunityToolkit()
            .RegisterAppServices()
            .RegisterViewModels()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
                fonts.AddFont("roboto-medium.ttf", "Roboto-Medium");
                fonts.AddFont("roboto-regular.ttf", "Roboto");
            });
        return builder.Build();
    }

    static MauiAppBuilder RegisterViewModels(this MauiAppBuilder appBuilder) {
        appBuilder.Services.AddTransient<ViewModels.MvvmViewModel>();
        return appBuilder;
    }
    static MauiAppBuilder RegisterAppServices(this MauiAppBuilder appBuilder) {
        appBuilder.Services.AddSingleton<Domain.Services.IDataService, Infrastructure.Services.DataService>();
        return appBuilder;
    }
}
