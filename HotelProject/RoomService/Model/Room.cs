using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomService.Model;

public class Room 
{
    [Key, Column("RoomId")]
    public int RoomId { get; set; }
    
    [Required, Column("RoomNumber")]
    public string? RoomNumber { get; set; }
    
    [Required, Column("Price")] 
    public double Price { get; set; }
    
    [Required, Column("Description")]
    public string? Description { get; set; }
}