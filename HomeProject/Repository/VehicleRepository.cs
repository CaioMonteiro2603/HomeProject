using HomeProject.Controllers;
using HomeProject.Data;
using HomeProject.Models;
using HomeProject.Repository.Interface;

namespace HomeProject.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly Context _context;

        public VehicleRepository(Context context)
        {
            _context = context;
        }
        public IList<VehicleModel> FindAll()
        {
            var vehicleRepository = _context.Vehicle.ToList();

            return vehicleRepository; 
        }

        public VehicleModel FindById(int id)
        {
            var vehicleRepository = _context.Vehicle.FirstOrDefault(vehicle => vehicle.VehicleId == id);

            return vehicleRepository; 
        }

        public int Insert(VehicleModel vehicle)
        {
            _context.Vehicle.Add(vehicle);
            _context.SaveChanges();

            return vehicle.VehicleId;
        }

        public void Update(VehicleModel vehicle)
        {
            VehicleModel vehicleDataBase = FindById(vehicle.VehicleId);

            if (vehicleDataBase == null) throw new Exception("Error, vehicle is null!");

            vehicleDataBase.VehicleName = vehicle.VehicleName;
            vehicleDataBase.VehicleColor = vehicle.VehicleColor;
            vehicleDataBase.VehicleYear = vehicle.VehicleYear;

            _context.Vehicle.Update(vehicleDataBase);
            _context.SaveChanges(); 
        }

        public bool Delete(int id)
        {
            var vehicleRepository = FindById(id);

            if (vehicleRepository == null) throw new Exception("Error, vehicle is null!"); 
            _context.Vehicle.Remove(vehicleRepository);
            _context.SaveChanges();

            return true; 
        }
    }
}
