using System;
using Autofac;
using SharingFood.Services;
using SharingFood.Views.Login;
using Xamarin.Forms;

namespace SharingFood.Framework.Resolver
{
    public interface IResolver
    {
        T Get<T>();
    }

    public class Resolver : IResolver
    {
        private static IContainer _container;

        public static void Initialise()
        {
            if (_container != null)
                throw new InvalidOperationException($"Cannot initialize {nameof(Resolver)} multiple times");

            var builder = new ContainerBuilder();

            builder.RegisterType<NavigationService>().As<INavigationService>();

            builder.RegisterType<DialogService>().As<IDialogService>();

            builder.RegisterType<Resolver>().As<IResolver>();

            builder.RegisterType<Login>();

            builder.RegisterType<LoginViewModel>();

            _container = builder.Build();
        }

        /// <summary>
        /// Static member to resolve registered dependencies
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Resolve<T>();
        }

        T IResolver.Get<T>()
        {
            return Resolve<T>();
        }

        private static T Resolve<T>()
        {
            if (_container == null)
                throw new NullReferenceException($"{nameof(Resolver)} not initialized");

            return _container.Resolve<T>();
        }
    }
}
