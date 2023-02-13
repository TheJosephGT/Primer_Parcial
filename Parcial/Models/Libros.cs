using System.ComponentModel.DataAnnotations;

public class Libros{

    [Key]

    public int LibroId {get; set;}
    [Required(ErrorMessage = "Este campo es necesario")]

    public string? Titulo {get; set;}

    public int precio {get; set;}


}