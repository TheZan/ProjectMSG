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
            services.AddSingleton<ContentViewModel>();
            services.AddSingleton<TestingViewModel>();
            services.AddTransient<ProfileViewModel>();
            services.AddSingleton<AdminViewModel>();
            services.AddSingleton<AdminSectionViewModel>();
            services.AddSingleton<AdminArticleViewModel>();
            services.AddSingleton<AdminTestViewModel>();

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
        public TestingViewModel TestingViewModel => _provider.GetRequiredService<TestingViewModel>();
        public ProfileViewModel ProfileViewModel => _provider.GetRequiredService<ProfileViewModel>();
        public AdminViewModel AdminViewModel => _provider.GetRequiredService<AdminViewModel>();
        public AdminSectionViewModel AdminSectionViewModel => _provider.GetRequiredService<AdminSectionViewModel>();
        public AdminArticleViewModel AdminArticleViewModel => _provider.GetRequiredService<AdminArticleViewModel>();
        public AdminTestViewModel AdminTestViewModel => _provider.GetRequiredService<AdminTestViewModel>();
    }
}
