using System;
using Autofac;
using SharingFood.Helpers;
using SharingFood.Services;
using SharingFood.Views.Filter;
using SharingFood.Views.Login;
using SharingFood.Views.Main;
using SharingFood.Views.Post;
using SharingFood.Views.Register;
using SharingFood.Views.User;
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

            builder.RegisterType<EntityService>().As<IEntityService>();

            builder.RegisterType<CryptographyService>().As<ICryptographyService>();

            builder.RegisterType<GeolocationService>().As<IGeolocationService>();

            builder.RegisterType<NavigationService>().As<INavigationService>();

            builder.RegisterType<DialogService>().As<IDialogService>();

            builder.RegisterType<MessengerService>().As<IMessengerService>();

            builder.RegisterType<Resolver>().As<IResolver>();

            builder.RegisterType<ShellManager>().As<IShellManager>();

            builder.RegisterType<Register>();

            builder.RegisterType<RegisterViewModel>();

            builder.RegisterType<Login>();

            builder.RegisterType<LoginViewModel>();

            builder.RegisterType<Main>();

            builder.RegisterType<MainViewModel>();

            builder.RegisterType<PostInfo>();

            builder.RegisterType<PostCreate>();

            builder.RegisterType<PostCreateViewModel>();

            builder.RegisterType<PostsToAccept>();

            builder.RegisterType<PostsToAcceptViewModel>();

            builder.RegisterType<User>();

            builder.RegisterType<UserViewModel>();

            builder.RegisterType<UserPosts>();

            builder.RegisterType<UserPostsViewModel>();

            builder.RegisterType<UserContactViewModel>();

            builder.RegisterType<Filter>();

            builder.RegisterType<FilterViewModel>();

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
