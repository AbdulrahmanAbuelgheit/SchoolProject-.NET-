using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepo _IRm;
        public RoomController(IRoomRepo IRm) { _IRm = IRm; }

        [HttpGet]
        public ActionResult Index()
        {
            List<Room> rooms = _IRm.GetAllRooms();
            return View(rooms);
        }
        [HttpGet]
        public ViewResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Room room)
        {
            if (room != null)
            {
                _IRm.Create(room);
            }
            List<Room> rooms = _IRm.GetAllRooms();
            return View("Index",rooms);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                _IRm.Delete(id);
            }
            List<Room> rooms = _IRm.GetAllRooms();
            return View("Index",rooms);
        }
    }
}
