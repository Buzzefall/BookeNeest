using System;
using Unity;

using BookeNeest.Domain;
using BookeNeest.Domain.Contracts.Repositories;
using BookeNeest.Domain.Contracts.Services;
using BookeNeest.Data.DB;
using BookeNeest.Data.DB.Repositories;
using BookeNeest.LogicLayer.Services;

namespace BookeNeest.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            container.RegisterType<IBookRepository, BookRepository>();
            container.RegisterType<IGenreRepository, GenreRepository>();
            container.RegisterType<IAuthorRepository, AuthorRepository>();
            container.RegisterType<IReviewRepository, ReviewRepository>();
            container.RegisterType<ITagRepository, TagRepository>();



            container.RegisterType<IBookService, BookService>();
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
        }
    }
}