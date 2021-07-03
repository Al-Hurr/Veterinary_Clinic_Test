using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinary_Clinic_Test.Models
{
    /// <summary>
    /// Прививка
    /// </summary>
    public class Vaccination
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Display(Name = "Название")]
        public string Name { get; set; }

        /// <summary>
        /// Длительность
        /// </summary>
        [Display(Name = "Длительность (дни)")]
        public int Duration { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        [DataType(DataType.Currency)]
        [Display(Name = "Стоимость")]
        public decimal Cost { get; set; }

        /// <summary>
        /// Доктор
        /// Доктор может назначить несколько прививок
        /// </summary>
        [Display(Name = "Доктор")]
        public Doctor Doctor { get; set; }

        /// <summary>
        /// Животное
        /// Одному животному может быть назначено несколько прививок
        /// </summary>
        [Display(Name = "Животное")]
        public Animal Animal { get; set; }

        /// <summary>
        /// Диагноз
        /// По одному диагнозу может быть назначено несколько прививок
        /// </summary>
        [Display(Name = "Диагноз")]
        public Diagnosis Diagnosis { get; set; }
    }
}
