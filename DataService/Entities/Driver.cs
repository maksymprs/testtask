using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Entities
{
    public class Driver
    {
        public Driver()
        {
            Cars = new HashSet<Car>();
        }

        [Key]
        [Column("DriverId")]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(10)]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Experience { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

    }
}
