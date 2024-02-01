using System.ComponentModel.DataAnnotations;
using SayIt.Models.Base;
using SayIt.Models.Tables;

namespace SayIt.Models.Profile;

public class Profile : BaseEntity
{
   public string Description { get; set; }
   
   public string profilePic { get; set; }

   [Required] 
   public Guid UserId { get; set; }
   
   [Required]
   public virtual User CorespondingUser { get; set; }
}