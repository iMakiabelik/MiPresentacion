# MiPresentacion - Aplicación de Escritorio con Avalonia UI 11

Aplicación gráfica de escritorio desarrollada en **C# (.NET)** utilizando **Avalonia UI 11**, diseñada para capturar los datos básicos de una persona (nombre, apellido y edad), validar la información ingresada y generar un mensaje de presentación personalizado en tiempo real.

---

## Controles utilizados (XAML)

* **`Window`:** Contenedor principal de la ventana con tamaño fijo (`480x500`) y centrada en pantalla (`CenterScreen`).
* **`StackPanel`:** Contenedor de diseño utilizado en orientación vertical para apilar los campos del formulario (aplicando `Margin` y `Spacing`) y en orientación horizontal para alinear los tres botones de acción.
* **`TextBlock`:** Empleado para mostrar el título principal (*«Mi primera aplicación gráfica»*), las etiquetas de cada campo y el área dinámica de resultados y advertencias (`TxtResultado`).
* **`TextBox`:** Tres cajas de entrada de texto (`TxtNombre`, `TxtApellido` y `TxtEdad`) configuradas con `Watermark` para guiar al usuario sobre el dato esperado.
* **`Button`:** Tres botones interactivos (`BtnPresentarme`, `BtnCambiarSaludo` y `BtnLimpiar`) enlazados a sus respectivos manejadores de eventos `Click`.
* **`Border`:** Marco visual con bordes redondeados y relleno (`Padding`) que resalta el mensaje de salida en la parte inferior.

---

## Funcionamiento de los eventos y validaciones (C#)

1. **Botón `Presentarme` (`BtnPresentarme_Click`):**
   * Obtiene el texto de los tres `TextBox` limpiando espacios en los extremos con `.Trim()`.
   * Valida con `string.IsNullOrWhiteSpace()` que el nombre y el apellido no estén vacíos; si fallan, muestra una advertencia en color rojo (`Brushes.Crimson`) y devuelve el cursor al campo correspondiente con `.Focus()`.
   * Verifica mediante `int.TryParse()` que la edad sea un número entero válido y comprueba que sea mayor que cero (`edad > 0`).
   * Si todas las validaciones pasan, construye y muestra el mensaje de presentación en `TxtResultado`.

2. **Botón `Cambiar saludo` (`BtnCambiarSaludo_Click` - Reto adicional):**
   * Alterna una bandera booleana (`_usarSaludoAlternativo`) entre dos formatos distintos de presentación (uno clásico y otro formal) sin necesidad de cerrar ni reiniciar la aplicación. Si ya hay datos válidos escritos en el formulario, actualiza el texto en pantalla al instante.

3. **Botón `Limpiar` (`BtnLimpiar_Click`):**
   * Borra el contenido de `TxtNombre`, `TxtApellido` y `TxtEdad`, restablece el color y el texto inicial en `TxtResultado` y posiciona el foco nuevamente en `TxtNombre` mediante `TxtNombre.Focus()`.

---

## Pregunta de reflexión

**¿Cuál es la función de `MainWindow.axaml` y `MainWindow.axaml.cs`, y cómo se relacionan mediante `x:Name` y los eventos `Click` para permitir que el usuario interactúe con la aplicación?**

`MainWindow.axaml` cumple la función de definir toda la parte visual y estructural de la interfaz gráfica (qué controles existen, cómo están organizados dentro de los `StackPanel`, sus tamaños, textos y márgenes), mientras que `MainWindow.axaml.cs` contiene la lógica del programa en C#, es decir, las decisiones, validaciones y cálculos que ocurren detrás de escena. 

Ambos archivos pertenecen a la misma clase parcial (`partial class MainWindow`) y se conectan en dos direcciones: primero, el atributo `x:Name` asignado en el XAML (como `TxtNombre` o `TxtResultado`) crea una referencia directa que permite leer o modificar esos controles desde el código C#; segundo, el atributo `Click` en los botones vincula la acción física del usuario al hacer clic con un método específico en `MainWindow.axaml.cs` (como `BtnPresentarme_Click`), logrando que la interfaz responda dinámicamente a cada interacción.

---

## Evidencias de ejecución

### 1. Formulario inicial
![Formulario inicial](evidencias/1_formulario.png)

### 2. Presentación válida (y cambio de saludo)
![Presentación correcta](evidencias/2_presentacion.png)

### 3. Validación de datos incorrectos
![Mensaje de validación](evidencias/3_validacion.png)

---

## Instrucciones de ejecución

### Requisitos previos
* [.NET SDK 8.0 / 10.0](https://dotnet.microsoft.com/download)

### Pasos para ejecutar
1. Clonar el repositorio:
   ```bash
   git clone [https://github.com/iMakiabelik/MiPresentacion.git](https://github.com/iMakiabelik/MiPresentacion.git)
   cd MiPresentacion