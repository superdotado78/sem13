using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Catálogo de revistas
        List<string> catalogo = new List<string>
        {
            "National Geographic",
            "Scientific American",
            "Time",
            "Forbes",
            "Nature",
            "The Economist",
            "Popular Science",
            "IEEE Spectrum",
            "Harvard Business Review",
            "Smithsonian"
        };

        while (true)
        {
            Console.WriteLine("\n--- Menú del Catálogo de Revistas ---");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Mostrar la lista de revistas");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            
            string? opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.Write("\nIngrese el título de la revista a buscar: ");
                string? titulo = Console.ReadLine();

                // Validar que el título no sea nulo o vacío
                if (!string.IsNullOrWhiteSpace(titulo))
                {
                    // Llamada a la función de búsqueda iterativa
                    bool encontrado = BuscarTitulo(catalogo, titulo);

                    Console.WriteLine(encontrado ? "Resultado: Encontrado" : "Resultado: No encontrado");
                }
                else
                {
                    Console.WriteLine("Error: El título no puede estar vacío.");
                }
            }
            else if (opcion == "2")
            {
                Console.WriteLine("\n--- Lista de Revistas Disponibles ---");
                foreach (string revista in catalogo)
                {
                    Console.WriteLine("- " + revista);
                }
            }
            else if (opcion == "3")
            {
                Console.WriteLine("Saliendo del programa...");
                break;
            }
            else
            {
                Console.WriteLine("Opción no válida, intente nuevamente.");
            }
        }
    }

    // Método para buscar un título en el catálogo de forma iterativa
    static bool BuscarTitulo(List<string> catalogo, string titulo)
    {
        foreach (string revista in catalogo)
        {
            if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
}