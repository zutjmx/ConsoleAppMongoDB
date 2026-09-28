using ConsoleAppMongoDB.Util;

string opcion = "";
var mongoDBAdmin = new MongoDBAdmin();

do
{
    Console.Clear();
    Console.WriteLine("=== MENÚ PRINCIPAL ===");
    Console.WriteLine("1. Insertar un nuevo documento de cuenta");
    Console.WriteLine("2. Listar todos los documentos de cuenta");
    Console.WriteLine("3. Listar bases de datos");
    Console.WriteLine("4. Salir");
    Console.Write("\nElige una opción (1-4): ");

    opcion = Console.ReadLine()!;

    switch (opcion)
    {
        case "1":
            Console.Clear();

            mongoDBAdmin.InsertarDocumentos();

            break;

        case "2":            
            mongoDBAdmin.ConsultarDocumentos();
            break;

        case "3":
            mongoDBAdmin.ListarBasesDeDatos();
            break;

        case "4":
            Console.WriteLine("\nSaliendo del programa. ¡Hasta luego!");
            break;

        default:
            Console.WriteLine("\nOpción no válida. Por favor, elige un número entre 1 y 4.");
            break;
    }

    if (opcion != "4")
    {
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

} while (opcion != "4");
