using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomService.Model;

[Table("ROOMS")]
public class Room 
{
    [Column("ROOM_ID")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoomId { get; set; }
    
    [Column("NAME")]
    [StringLength(3)]
    [Required]
    public string? RoomNumber { get; set; }
}