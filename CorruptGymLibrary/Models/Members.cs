using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorruptGymLibrary.Models
{
    public class Members
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string First_Name { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;
        
        public bool Active { get; set; }
        
        [Required]
        [Display(Name = "Membership Type")]
        public int Membership_Type_Id { get; set; }
        
        [Required]
        [Display(Name = "Center")]
        public int Center_Id { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        
        
        public DateOnly Birthday_Member { 
            get => ConvertDateTimeToDateOnly(Birthday);
            set => Birthday = ConvertDateOnlyToDateTime(value);
        }


        DateOnly ConvertDateTimeToDateOnly(DateTime dateTime)
        {
            return DateOnly.FromDateTime(dateTime);
        }

        DateTime ConvertDateOnlyToDateTime(DateOnly dateOnly)
        {
            return dateOnly.ToDateTime(TimeOnly.MinValue);
        }

    }
}