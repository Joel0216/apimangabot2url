using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JaveragesLibrary.Domain.Entities
{
    [Table("Mangas")]
    public class Manga
    {
        [Key]
        public int Id { get; set; }

        public string? Titulo { get; set; } // antes era string sin ?
        public string? Autor { get; set; }
        public int? Capitulos { get; set; } // si puede ser NULL, ponle ?

        // Agrega solo lo que esté en tu base. Si no hay columnas extra, no pongas más.
    }
}