using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAPIforToDos
{
    public class ToDo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "timestamp")]
        public DateTime DateOfExpiry { get; set; }


        public int Complete { get; set; }

        [Required]
        [Column(TypeName = "boolean")]
        public bool Done { get; set; }

        // Parameterless constructor needed by EF Core
        public ToDo()
        {
            Title = string.Empty;
            Description = string.Empty;
            DateOfExpiry = DateTime.MinValue;
            Complete = 0;
            Done = false;
        }

        public ToDo(string title, string description, DateTime dateOfExpiry)
        {
            Title = title;
            Description = description;
            DateOfExpiry = dateOfExpiry;
            Complete = 0;
            Done = false;
        }

        public override string ToString()
        {
            if (Done)
            {
                return Title + " - Done";
            }
            else
            {
                return Title + $" {100 - Complete}% to be done";
            }
        }
    }

}
