using First_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace First_MVC.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "The Name Is Required")]
        //  [RegularExpression(pattern: "[a-z A-Z]{3,}", ErrorMessage = "The name Must Be Char And Than More 2 Char ")]
        [Remote(action:"Name_Exist",controller:"Stud",ErrorMessage ="This Name Is Alredy Exist ",AdditionalFields ="Id")] //text change//هتشتغل حتي مع كل حرف بيتكتب 
        public string ?Name { get; set; }

        [Required(ErrorMessage = "The Adress Is Required")]
       // [MaxLength(50)]
        public int Adress { get; set; }
        
        public string ?Image { get; set; }
        [Required(ErrorMessage = "The Age Is Required")]
        [Range(minimum: 20, maximum: 30)]
        [AgeValidation(info = 5)]      ///custom vaildation     Server Side Only
        public int Age { get; set; }
        [ForeignKey("Department")]
        public int Dept { get; set; }
        public Department? Department { get; set; }


    }
}
