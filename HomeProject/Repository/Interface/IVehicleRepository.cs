using HomeProject.Controllers;
using HomeProject.Models;

namespace HomeProject.Repository.Interface
{
    public interface IVehicleRepository
    {
        public IList<VehicleModel> FindAll();

        public VehicleModel FindById(int id);

        public void Update(VehicleModel vehicle);

        public int Insert(VehicleModel vehicle);

        public bool Delete(int id);
    }
}
