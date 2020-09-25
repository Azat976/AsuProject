using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AsuTest.Models
{
    public class Book
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Пустая строка")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Длина строки должна быть 20")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Пустая строка")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Длина строки должна быть 20")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Пустая строка")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Длина строки должна быть 80")]
        public string Description { get; set; }

        public string Status { get; set; }
    }
}
