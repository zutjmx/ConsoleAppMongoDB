using ConsoleAppMongoDB.Util;

string opcion = "";
var mongoDBAdmin = new MongoDBAdmin();

do
{
    Console.Clear();
    Console.WriteLine("=== MENÚ PRINCIPAL ===");
    Console.WriteLine("1. Insertar un nuevo documento de cuenta");
    Console.WriteLine("2. Listar todos los documentos de cuenta");
    Console.WriteLine("3. Salir");
    Console.Write("\nElige una opción (1-3): ");

    opcion = Console.ReadLine()!;

    switch (opcion)
    {
        case "1":
            Console.Clear();

            // TODO: Aquí puedes agregar la lógica para insertar un nuevo documento de cuenta en MongoDB
            Console.WriteLine("Funcionalidad aún no implementada...");

            break;

        case "2":            
            mongoDBAdmin.ConsultarDocumentos();
            break;

        case "3":
            Console.WriteLine("\nSaliendo del programa. ¡Hasta luego!");
            break;

        default:
            Console.WriteLine("\nOpción no válida. Por favor, elige un número entre 1 y 3.");
            break;
    }

    if (opcion != "3")
    {
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

} while (opcion != "3");
