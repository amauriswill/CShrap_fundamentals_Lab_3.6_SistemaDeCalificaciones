using System.Globalization;
using System.Text;

ConfigurarConsola();

MostrarEncabezado();

string estudiante = LeerTexto("Ingrese el nombre del estudiante: ");
string notaEntrada = LeerTexto("Ingrese la calificación (0 - 100): ");

if (!ValidarEntradaNumerica(notaEntrada, out decimal calificacion))
{
    MostrarError("La calificación debe ser un valor numérico válido.");
    return;
}

if (!ValidarRangoCalificacion(calificacion))
{
    MostrarError("La calificación debe estar comprendida entre 0 y 100.");
    return;
}

Console.WriteLine($"Datos válidos: {estudiante} - {calificacion}");

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
    string normalizada = entrada.Replace(',', '.');
    return decimal.TryParse(normalizada, NumberStyles.Any, CultureInfo.InvariantCulture, out valor);
}

static bool ValidarRangoCalificacion(decimal calificacion)
{
    return calificacion >= 0 && calificacion <= 100;
}

static void MostrarError(string mensaje)
{
    Console.WriteLine();
    Console.WriteLine($"Error: {mensaje}");
}
