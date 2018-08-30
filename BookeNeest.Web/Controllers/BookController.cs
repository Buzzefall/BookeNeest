using System.Web.Mvc;
using Unity.Attributes;

namespace BookeNeest.Web.Controllers
{
    public interface IBookService
    {
        object GetGenreNames();
        object GetGenreByName(string genre);
    }

    public class BookController : Controller
    {
        private IBookService service;

        [InjectionConstructor]
        public BookController(IBookService service)
        {
            this.service = service;
        }

        //
        // GET: /Store/
        //public ActionResult Index()
        //{
        //    // Create list of genres
        //    var genres = this.service.GetGenreNames();

        //    // Create your view model
        //    var viewModel = new StoreIndexViewModel
        //    {
        //        Genres = genres.ToList(),
        //        NumberOfGenres = genres.Count()
        //    };

        //    return View(viewModel);
        //}

        //
        // GET: /Store/Browse?genre=Disco
        //public ActionResult Browse(string genre)
        //{
        //    var genreModel = this.service.GetGenreByName(genre);

        //    var viewModel = new StoreBrowseViewModel()
        //    {
        //        Genre = genreModel,
        //        Albums = genreModel.Albums.ToList()
        //    };

        //    return View(viewModel);
        //}

        ////
        //// GET: /Store/Details/5
        //public ActionResult Details(int id)
        //{
        //    var album = this.service.GetAlbum(id);

        //    return View(album);
        //}
    }
}