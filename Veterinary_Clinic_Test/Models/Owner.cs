using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinary_Clinic_Test.Models
{
    /// <summary>
    /// Хозяин
    /// </summary>
    public class Owner
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        [Display(Name = "Адрес")]
        public string Adress { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        public ICollection<Animal> Animals { get; set; }
    }
}
