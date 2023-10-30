#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models;

public class Dish
{
    [Key]
    public int DishId { get; set; }
    
    [Required(ErrorMessage = "Dish Name is required.")]
    [MaxLength(45)]
    [DisplayName("Dish Name:")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Tastiness Rating is required.")]
    [Range(1, 5)]
    [DisplayName("Tastiness Rating:")]
    public int? Tastiness { get; set; }

    [Required(ErrorMessage = "Calorie Amount is required.")]
    [Range(1, 2000, ErrorMessage = "Calories must be between 1 and 2000.")]
    [DisplayName("Total Calories:")]
    public int? Calories { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    //------- One to Many Relationship -------

    // Foreign Key
    [Required(ErrorMessage = "Chef is required.")]
    [DisplayName("Chef:")]
    public int? ChefId { get; set; }

    // Navigation Property
    public Chef? Creator { get; set; }
}
