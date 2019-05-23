using System.Web.Mvc;
using WebServices.Models;

namespace WebServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ReservationRepository _repo = ReservationRepository.Current;

        public ViewResult Index()
        {
            return View(_repo.GetAll());
        }

        public ActionResult Add(Reservation item)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(item);

                return RedirectToAction("Index");
            }

            return View("Index");
        }

        public ActionResult Remove(int id)
        {
            _repo.Remove(id);

            return RedirectToAction("Index");
        }

        public ActionResult Update(Reservation item)
        {
            if (ModelState.IsValid && _repo.Update(item))
            {
                return RedirectToAction("Index");
            }

            return View("Index");
        }
    }
}