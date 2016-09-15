using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Entities
{

    //[Table("Car", Schema = "dbo")]
    public class Car
    {
        public enum Type
        {
            passenger,
            truck
        };

        public Car() 
        {
            Drivers = new HashSet<Driver>();
        }

        [Key]
        [Column("CarId")]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Model { get; set; }

        [Required]
        [MaxLength(10)]
        public string Mark { get; set; }

        public Type CarType { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public DateTime Year { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; }


    }
}
