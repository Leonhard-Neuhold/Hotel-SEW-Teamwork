using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomService.Model;

public class Room 
{
    [Key]
    public int RoomId { get; set; }
    
    [Required]
    public string? RoomNumber { get; set; }
    
    [Required] 
    public double Price { get; set; }

    public string? Description { get; set; }
}