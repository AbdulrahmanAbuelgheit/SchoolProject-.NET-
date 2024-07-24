using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public interface IRoomRepo
    {
        public List<Room> GetAllRooms();
        public void Create(Room room);
        public void Delete(int id);
    }
}
