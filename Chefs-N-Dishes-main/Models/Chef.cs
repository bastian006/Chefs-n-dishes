#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models;

public class Chef
{
    [Key]
    public int ChefId { get; set; }
    
    [Required(ErrorMessage = "First Name is required.")]
    [MaxLength(45)]
    [DisplayName("First Name:")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required.")]
    [MaxLength(45)]
    [DisplayName("Last Name:")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "DOB is required.")]
    [DataType(DataType.Date)]
    public DateTime DOB { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    // Chef's List of Dishes
    public List<Dish> OneChefsDishes { get; set; } = new();
}
