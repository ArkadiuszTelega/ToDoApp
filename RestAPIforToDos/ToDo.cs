using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Windows.Foundation.Metadata;

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

        [Required]
        [System.ComponentModel.DataAnnotations.Range(0, 100)]
        public int Complete { get; set; }

        [Required]
        [Column(TypeName = "boolean")]
        public bool Done { get; set; }

        // Parameterless constructor needed by EF Core
        public ToDo()
        {
            Title = string.Empty;
            Description = string.Empty;
            DateOfExpiry = DateTime.UtcNow.AddDays(1);
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
