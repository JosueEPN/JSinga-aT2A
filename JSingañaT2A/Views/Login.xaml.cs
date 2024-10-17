namespace JSingañaT2A.Views;

public partial class Login : ContentPage
{

    // Vectores de usuarios y contraseñas
    string[] usuarios = { "Carlos", "Ana", "Jose" };
    string[] contraseñas = { "carlos123", "ana123", "jose123" };

    public Login()
	{
		InitializeComponent();
	}

    private void btnIniciar_Clicked(object sender, EventArgs e)
    {

        // Obtener valores ingresados
        string usuarioIngresado = txtUsuario.Text;
        string contraseñaIngresada = txtContrasena.Text;

        // Variable para validar si se encontró un usuario válido
        bool usuarioValido = false;

        // Bucle for para verificar credenciales
        for (int i = 0; i < usuarios.Length; i++)
        {
            if (usuarioIngresado == usuarios[i] && contraseñaIngresada == contraseñas[i])
            {
                usuarioValido = true;
                // Mostrar mensaje de bienvenida
                DisplayAlert("Bienvenido", $"Bienvenido, {usuarios[i]}", "OK");

                // Navegar a la página Crud enviando el nombre del usuario
                Navigation.PushAsync(new Views.Crud(usuarios[i]));
                break;
            }
        }

        // Si no se encontró un usuario válido, mostrar error
        if (!usuarioValido)
        {
            DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
        }
    }
}