using System.ComponentModel.DataAnnotations;
using SayIt.Models.Base;
using SayIt.Models.Tables;

namespace SayIt.Models.Profile;

public class Profile : BaseEntity
{
   public string? Description { get; set; }
   
   public string? ProfilePic { get; set; }

   [Required] 
   public Guid UserId { get; set; }
   
   [Required]
   public virtual User CorrespondingUser { get; set; }
}