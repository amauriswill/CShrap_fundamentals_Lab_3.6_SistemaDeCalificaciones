using System.Globalization;
using System.Text;

ConfigurarConsola();
MostrarEncabezado();

string estudiante = LeerTexto("Ingrese el nombre del estudiante: ");
string notaEntrada = LeerTexto("Ingrese la calificación (0 - 100): ");

if (!ValidarEntradaNumerica(notaEntrada, out decimal calificacion))
{
    MostrarError("La entrada ingresada no es un número válido.");
    return;
}

if (!ValidarRangoCalificacion(calificacion))
{
    MostrarError("La calificación debe estar comprendida entre 0 y 100.");
    return;
}

string clasificacion = DeterminarClasificacion(calificacion);
string condicion = DeterminarCondicion(calificacion);

MostrarResultado(estudiante, calificacion, clasificacion, condicion);

static void ConfigurarConsola()
{
    Console.OutputEncoding = Encoding.UTF8;
    Console.InputEncoding = Encoding.UTF8;
}

static void MostrarEncabezado()
{
    Console.WriteLine("========================================");
    Console.WriteLine("  SISTEMA DE CALIFICACIONES ACADÉMICAS  ");
    Console.WriteLine("========================================");
    Console.WriteLine();
}

static string LeerTexto(string mensaje)
{
    Console.Write(mensaje);
    return Console.ReadLine()?.Trim() ?? string.Empty;
}

static bool ValidarEntradaNumerica(string entrada, out decimal valor)
{
    string normalizada = entrada.Replace(',', '.').Trim();
    return decimal.TryParse(normalizada, NumberStyles.Any, CultureInfo.InvariantCulture, out valor);
}

static bool ValidarRangoCalificacion(decimal calificacion)
{
    return calificacion >= 0 && calificacion <= 100;
}

static string DeterminarClasificacion(decimal calificacion)
{
    if (calificacion >= 90)
    {
        return "Excelente";
    }
    else if (calificacion >= 80)
    {
        return "Muy bueno";
    }
    else if (calificacion >= 70)
    {
        return "Aprobado";
    }
    else
    {
        return "Reprobado";
    }
}

static string DeterminarCondicion(decimal calificacion)
{
    if (calificacion >= 70)
    {
        return "Aprobado";
    }
    else
    {
        return "Reprobado";
    }
}

static void MostrarResultado(string estudiante, decimal calificacion, string clasificacion, string condicion)
{
    Console.WriteLine();
    Console.WriteLine("========================================");
    Console.WriteLine("         RESULTADO ACADÉMICO            ");
    Console.WriteLine("========================================");
    Console.WriteLine();
    Console.WriteLine($"Estudiante:    {estudiante}");
    Console.WriteLine($"Calificación:  {calificacion.ToString("N2", CultureInfo.InvariantCulture)}");
    Console.WriteLine($"Clasificación: {clasificacion}");
    Console.WriteLine($"Condición:     {condicion}");
    Console.WriteLine();
    Console.WriteLine("========================================");
}

static void MostrarError(string mensaje)
{
    Console.WriteLine();
    Console.WriteLine($"Error: {mensaje}");
}
