using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinary_Clinic_Test.Models
{
    /// <summary>
    /// Диагноз
    /// </summary>
    public class Diagnosis
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Display(Name = "Название")]
        public string Name { get; set; }

        /// <summary>
        /// Дата назначения
        /// </summary>
        [Display(Name = "Дата назначения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProductionDate { get; set; }

        /// <summary>
        /// Доктор
        /// Доктор может назначить несколько диагнозов
        /// </summary>
        [Display(Name = "Доктор")]
        public Doctor Doctor { get; set; }

        public ICollection<Animal> Animals { get; set; }
        public ICollection<Vaccination> Vaccinations { get; set; }
    }
}
