using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinary_Clinic_Test.Models
{
    /// <summary>
    /// Животное
    /// </summary>
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name = "Имя")]
        public string Name { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Порода
        /// </summary>
        [Display(Name = "Порода")]
        public string Breed { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        [Display(Name = "Пол")]
        public string Gender { get; set; }

        /// <summary>
        /// Хозяин
        /// У одного хозяина м.б. несколько животных
        /// </summary>
        [Display(Name = "Хозяин")]
        public Owner Owner { get; set; }

        /// <summary>
        /// Доктор
        /// Доктор может лечить несколько животных
        /// </summary>
        [Display(Name = "Лечащий доктор")]
        public Doctor Doctor { get; set; }

        /// <summary>
        /// Диагноз
        /// Один диагноз может быть назначен нескольким животным
        /// </summary>
        [Display(Name = "Диагноз")]
        public Diagnosis Diagnosis { get; set; }

        public ICollection<Vaccination> Vaccinations { get; set; }
    }
}
