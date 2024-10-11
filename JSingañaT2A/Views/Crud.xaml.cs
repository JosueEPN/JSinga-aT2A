namespace JSingañaT2A.Views;

public partial class Crud : ContentPage
{
	public Crud()
	{
		InitializeComponent();
	}

    private void btn_calcularNotas_Clicked(object sender, EventArgs e)
    {

        // Validar las entradas
        if (!double.TryParse(Seguimiento1.Text, out double notaSeg1) || notaSeg1 < 0 || notaSeg1 > 10 ||
            !double.TryParse(Examen1.Text, out double notaEx1) || notaEx1 < 0 || notaEx1 > 10 ||
            !double.TryParse(Seguimiento2.Text, out double notaSeg2) || notaSeg2 < 0 || notaSeg2 > 10 ||
            !double.TryParse(Examen2.Text, out double notaEx2) || notaEx2 < 0 || notaEx2 > 10)
        {
            DisplayAlert("Error", "Por favor ingrese notas válidas entre 0 y 10.", "OK");
            return;
        }

        // Calcular las notas parciales
        double parcial1 = (notaSeg1 * 0.3) + (notaEx1 * 0.2);
        double parcial2 = (notaSeg2 * 0.3) + (notaEx2 * 0.2);
        double notaFinal = parcial1 + parcial2;

        // Determinar el estado final
        string estado;
        if (notaFinal >= 7)
            estado = "Aprobado";
        else if (notaFinal >= 5 && notaFinal < 7)
            estado = "Complementario";
        else
            estado = "Reprobado";

        // Mostrar los resultados en un DisplayAlert
        DisplayAlert("Resultado",
                     $"Nombre: {StudentPicker.SelectedItem}\n" +
                     $"Fecha: {FechaPicker.Date.ToString("d")}\n" +
                     $"Nota Parcial 1: {parcial1:F2}\n" +
                     $"Nota Parcial 2: {parcial2:F2}\n" +
                     $"Nota Final: {notaFinal:F2}\n" +
                     $"Estado: {estado}",
                     "OK");

    }
}