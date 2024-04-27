using HomeProject.Models;
using HomeProject.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HomeProject.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vehicleController = _vehicleRepository.FindAll();
            return View(vehicleController);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(VehicleModel vehicleModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _vehicleRepository.Insert(vehicleModel);
                    TempData["SucessMessage"] = "Vehicle has been add";
                    return RedirectToAction(nameof(Index));
                }

                return View(vehicleModel);

            } catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Error to finally this operation, details about error: {ex.Message}";
                return RedirectToAction(nameof(Index)); 
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var vehicleController = _vehicleRepository.FindById(id);

            if(vehicleController == null)
            {
                return NotFound();
            }

            return View(vehicleController);
        }

        [HttpPost]
        public IActionResult Edit(VehicleModel vehicleModel)
        {
            _vehicleRepository.Update(vehicleModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var vehicleController = _vehicleRepository.FindById(id);

            return View(vehicleController);
        }

        [HttpGet]
        public IActionResult Delete(VehicleModel vehicleModel)
        {
            try
            {
                bool vehicleDeleted = _vehicleRepository.Delete(vehicleModel.VehicleId);
                if(vehicleDeleted)
                {
                    TempData["SucessMessage"] = "Deleted!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = ""; 
                    return RedirectToAction(nameof(Index));
                }
            } catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro, something went wrong to delete vehicle. More about error: {ex.Message}";
                return RedirectToAction(nameof(Index)); 
            }
        }

    }
}
