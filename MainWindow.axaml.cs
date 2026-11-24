using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace MiPresentacion;

public partial class MainWindow : Window
{
    private bool _usarSaludoAlternativo = false;
    private const string MensajeInicial = "Completa tus datos y presiona 'Presentarme'.";

    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnPresentarme_Click(object? sender, RoutedEventArgs e)
    {
        string nombre = TxtNombre.Text?.Trim() ?? string.Empty;
        string apellido = TxtApellido.Text?.Trim() ?? string.Empty;
        string edadTexto = TxtEdad.Text?.Trim() ?? string.Empty;

        // Caso 2: Validar nombre vacío
        if (string.IsNullOrWhiteSpace(nombre))
        {
            MostrarAdvertencia("Advertencia: Por favor, ingresa tu nombre (no puede estar vacío).");
            TxtNombre.Focus();
            return;
        }

        // Caso 3: Validar apellido vacío
        if (string.IsNullOrWhiteSpace(apellido))
        {
            MostrarAdvertencia("Advertencia: Por favor, ingresa tu apellido (no puede estar vacío).");
            TxtApellido.Focus();
            return;
        }

        // Caso 4: Validar que la edad sea numérica
        if (!int.TryParse(edadTexto, out int edad))
        {
            MostrarAdvertencia("Advertencia: La edad debe ser un valor numérico entero.");
            TxtEdad.Focus();
            return;
        }

        // Caso 5: Validar que la edad sea positiva (> 0)
        if (edad <= 0)
        {
            MostrarAdvertencia("Advertencia: La edad debe ser un número entero positivo mayor que cero.");
            TxtEdad.Focus();
            return;
        }

        // Caso 1: Datos válidos -> Mostrar presentación
        MostrarPresentacion(nombre, apellido, edad);
    }

    private void BtnCambiarSaludo_Click(object? sender, RoutedEventArgs e)
    {
        // Alternar entre los dos estilos de saludo sin reiniciar la app
        _usarSaludoAlternativo = !_usarSaludoAlternativo;

        string nombre = TxtNombre.Text?.Trim() ?? string.Empty;
        string apellido = TxtApellido.Text?.Trim() ?? string.Empty;
        string edadTexto = TxtEdad.Text?.Trim() ?? string.Empty;

        // Si ya hay datos válidos escritos, actualiza el saludo en pantalla al instante
        if (!string.IsNullOrWhiteSpace(nombre) &&
            !string.IsNullOrWhiteSpace(apellido) &&
            int.TryParse(edadTexto, out int edad) &&
            edad > 0)
        {
            MostrarPresentacion(nombre, apellido, edad);
        }
        else
        {
            TxtResultado.ClearValue(TextBlock.ForegroundProperty);
            string modo = _usarSaludoAlternativo ? "Saludo 2 (Formal)" : "Saludo 1 (Clásico)";
            TxtResultado.Text = $"Estilo cambiado a: {modo}. Completa tus datos y presiona 'Presentarme'.";
        }
    }

    private void BtnLimpiar_Click(object? sender, RoutedEventArgs e)
    {
        // Caso 6: Vaciar campos, restaurar mensaje inicial y enfocar nombre
        TxtNombre.Text = string.Empty;
        TxtApellido.Text = string.Empty;
        TxtEdad.Text = string.Empty;

        TxtResultado.ClearValue(TextBlock.ForegroundProperty);
        TxtResultado.Text = MensajeInicial;

        TxtNombre.Focus();
    }

    private void MostrarPresentacion(string nombre, string apellido, int edad)
    {
        TxtResultado.ClearValue(TextBlock.ForegroundProperty);

        if (!_usarSaludoAlternativo)
        {
            TxtResultado.Text =
                $"¡Hola! Mi nombre es {nombre} {apellido},\n" +
                $"tengo {edad} años y estoy aprendiendo\n" +
                $"a desarrollar interfaces gráficas con C#.";
        }
        else
        {
            TxtResultado.Text =
                $"Mucho gusto, soy {nombre} {apellido} ({edad} años).\n" +
                $"Esta es mi aplicación de escritorio construida con Avalonia UI 11 y .NET.";
        }
    }

    private void MostrarAdvertencia(string mensaje)
    {
        TxtResultado.Foreground = Brushes.Crimson;
        TxtResultado.Text = mensaje;
    }
}