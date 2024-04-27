using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeProject.Models
{
    [Table("Vehicle")]
    public class VehicleModel
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "Vehicle's name is required!")]
        public string VehicleName { get; set; }

        [Required(ErrorMessage = "Vehicle's color is required!")]
        public string VehicleColor { get; set; }

        [Required(ErrorMessage = "Vehicle's year is required!")]
        public int VehicleYear { get; set; }

        public VehicleModel()
        {

        }

        public VehicleModel(int vehicleId, string vehicleName, string vehicleColor, int vehicleYear)
        {
            VehicleId = vehicleId;
            VehicleName = vehicleName;
            VehicleColor = vehicleColor;
            VehicleYear = vehicleYear;
        }
        
    }
}
