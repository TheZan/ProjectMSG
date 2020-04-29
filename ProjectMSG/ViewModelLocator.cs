using Microsoft.Extensions.DependencyInjection;
using ProjectMSG.Service;
using ProjectMSG.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMSG
{
    public class ViewModelLocator
    {
        private static ServiceProvider _provider;

        public static void Init()
        {
            var services = new ServiceCollection();

            services.AddTransient<MainViewModel>();
            services.AddTransient<AuthViewModel>();
            services.AddTransient<RegistrationViewModel>();
            services.AddScoped<ContentViewModel>();

            services.AddSingleton<PageService>();
            services.AddSingleton<EventBus>();
            services.AddSingleton<MessageBus>();



            _provider = services.BuildServiceProvider();

            foreach (var item in services)
            {
                _provider.GetRequiredService(item.ServiceType);
            }
        }

        public MainViewModel MainViewModel => _provider.GetRequiredService<MainViewModel>();
        public AuthViewModel AuthViewModel => _provider.GetRequiredService<AuthViewModel>();
        public RegistrationViewModel RegistrationViewModel => _provider.GetRequiredService<RegistrationViewModel>();
        public ContentViewModel ContentViewModel => _provider.GetRequiredService<ContentViewModel>();
    }
}
