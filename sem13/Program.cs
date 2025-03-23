using System;

public class Nodo
{
    public string Titulo { get; set; }
    public Nodo? Izquierda { get; set; }
    public Nodo? Derecha { get; set; }

    public Nodo(string titulo)
    {
        Titulo = titulo;
        Izquierda = null;
        Derecha = null;
    }
}

public class CatalogoRevistas
{
    public Nodo? raiz; 

    public CatalogoRevistas()
    {
        raiz = null;
    }

    public void Insertar(string titulo)
    {
        raiz = InsertarRecursivo(raiz, titulo);
    }

    private Nodo InsertarRecursivo(Nodo? nodo, string titulo)
    {
        if (nodo == null)
        {
            nodo = new Nodo(titulo);
            return nodo;
        }

        int comparacion = string.Compare(titulo, nodo.Titulo);

        if (comparacion < 0)
            nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, titulo);
        else if (comparacion > 0)
            nodo.Derecha = InsertarRecursivo(nodo.Derecha, titulo);

        return nodo;
    }

    public bool BuscarRecursivo(string titulo)
    {
        return BuscarRecursivo(raiz, titulo);
    }

    private bool BuscarRecursivo(Nodo? nodo, string titulo)
    {
        if (nodo == null)
            return false;

        int comparacion = string.Compare(titulo, nodo.Titulo);
        
        if (comparacion == 0)
            return true;
        else if (comparacion < 0)
            return BuscarRecursivo(nodo.Izquierda, titulo);
        else
            return BuscarRecursivo(nodo.Derecha, titulo);
    }

    public bool BuscarIterativo(string titulo)
    {
        Nodo? actual = raiz;

        while (actual != null)
        {
            int comparacion = string.Compare(titulo, actual.Titulo);

            if (comparacion == 0)
                return true;
            else if (comparacion < 0)
                actual = actual.Izquierda;
            else
                actual = actual.Derecha;
        }

        return false;
    }

    public void MostrarCatalogo(Nodo? actual)
    {
        if (actual == null)
            return;

        MostrarCatalogo(actual.Izquierda);
        Console.WriteLine(actual.Titulo);
        MostrarCatalogo(actual.Derecha);
    }
}

public class Program
{
    public static void Main()
    {
        CatalogoRevistas catalogo = new CatalogoRevistas();

        // Insertar 10 títulos al catálogo
        catalogo.Insertar("Revista A");
        catalogo.Insertar("Revista B");
        catalogo.Insertar("Revista C");
        catalogo.Insertar("Revista D");
        catalogo.Insertar("Revista E");
        catalogo.Insertar("Revista F");
        catalogo.Insertar("Revista G");
        catalogo.Insertar("Revista H");
        catalogo.Insertar("Revista I");
        catalogo.Insertar("Revista J");

        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("Catálogo de Revistas de Jorge Diaz");
            Console.WriteLine("1. Buscar título (recursivo)");
            Console.WriteLine("2. Buscar título (iterativo)");
            Console.WriteLine("3. Mostrar listado de revistas");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el título a buscar (recursivo): ");
                    string tituloRecursivo = Console.ReadLine();
                    bool encontradoRecursivo = catalogo.BuscarRecursivo(tituloRecursivo);
                    Console.WriteLine(encontradoRecursivo ? "Título encontrado" : "Título no encontrado");
                    break;

                case 2:
                    Console.Write("Ingrese el título a buscar (iterativo): ");
                    string tituloIterativo = Console.ReadLine();
                    bool encontradoIterativo = catalogo.BuscarIterativo(tituloIterativo);
                    Console.WriteLine(encontradoIterativo ? "Título encontrado" : "Título no encontrado");
                    break;

                case 3:
                    Console.WriteLine("Listado de Revistas:");
                    catalogo.MostrarCatalogo(catalogo.raiz);
                    break;

                case 4:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        } while (opcion != 4);
    }
}
