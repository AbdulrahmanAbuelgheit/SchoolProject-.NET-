using SchoolProject.Context;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public class RoomRepo : IRoomRepo
    {
        private readonly MyDbContext _db;
        public RoomRepo(MyDbContext db) { _db = db; }

        public void Create(Room room)
        {
            _db.Rooms.Add(room);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Room room = (from RmObjs in _db.Rooms
                               where RmObjs.RoomId == id
                               select RmObjs).FirstOrDefault();
            _db.Rooms.Remove(room);
            _db.SaveChanges();
        }

        public List<Room> GetAllRooms()
        {
            List<Room> rooms = (from RmObjs in _db.Rooms
                                      select RmObjs).ToList();
            return rooms;
        }
    }
}
