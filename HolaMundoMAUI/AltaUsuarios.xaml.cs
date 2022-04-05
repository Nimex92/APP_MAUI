using Bibliotec;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace HolaMundoMAUI;

public partial class AltaUsuarios : ContentPage
{
	PresenciaContext presenciaContext = new PresenciaContext();
	public AltaUsuarios()
	{
		InitializeComponent();
	}

	public void RegistrarNuevoUsuario(object sender, EventArgs e)
	{
		string Username = CampoUsuario.Text;                    //Recojo el usuario de la interfaz
		string Password = CampoContrasena.Text;                 //Recojo la contraseņa de la interfaz
		string CompruebaPassword = CampoRepiteContrasena.Text;  //Recojo la comprobacion de la contraseņa de la interfaz

		var us = presenciaContext.Usuarios
						.Where(b => b.Username == Username)
						.FirstOrDefault();

		if (us is not null)
		{
			if (CampoUsuario.Text == us.Username)
			{
				//El usuario existe, activamos el label de error
				LabelAvisos.Text = "El nombre de usuario ya existe...";
				LabelAvisos.TextColor = Colors.Red;
				LabelAvisos.IsVisible = true;
			}
        }
        else
        {
			if (CampoContrasena.Text == CampoRepiteContrasena.Text)
			{
				bool esAdmin=false;
				if(BotonEsAdmin.IsChecked)
					esAdmin = true;

				//Inserto usuario
				OperacionesDBContext.insertaUsuario(Username, Password,esAdmin);
				//Activo label de aceptacion, se ha insertado.
				LabelAvisos.Text = "Usuario insertado correctamente.";
				LabelAvisos.TextColor = Colors.Green;
				LabelAvisos.IsVisible = true;
			}
			else
			{
				//Activa label error, no coinciden las contraseņas
				LabelAvisos.Text = "Las contraseņas deben coincidir.";
				LabelAvisos.TextColor = Colors.Red;
				LabelAvisos.IsVisible = true;
			}
		}
	}   

	public void VolverAlMain(object sender, EventArgs e)
    {
		App.Current.MainPage = new NavigationPage(new PaginaAdmin());

	}
}