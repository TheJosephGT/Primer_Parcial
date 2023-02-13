using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class LibrosBLL {
    public Contexto _contexto;

    public LibrosBLL(Contexto contexto){
        _contexto = contexto;
    }

    public bool Existe(int LibroId)
    {
        return _contexto.Libros.Any(o => o.LibroId == LibroId);
    }

    private bool Insertar(Libros libro)
    {
        _contexto.Libros.Add(libro);

        
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Libros libro)
    {
        _contexto.Entry(libro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;


        return _contexto.SaveChanges() > 0;
    }

    public bool Guardar(Libros libro)
    {
        if (!Existe(libro.LibroId))
            return this.Insertar(libro);


        else{
            return this.Modificar(libro);
        }
            
    }

    public Libros? Buscar(int LibroId)
    {
        return _contexto.Libros.Where(o => o.LibroId == LibroId).AsNoTracking().SingleOrDefault();
    }

    public List<Libros> GetList(Expression<Func<Libros, bool>> criterio)
    {
        
        
        return _contexto.Libros.AsNoTracking().Where(criterio).ToList();
    }






}