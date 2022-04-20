using Bibliotec;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace HolaMundoMAUI;

public partial class AltaUsuarios : ContentPage
{
	PresenciaContext presenciaContext = new PresenciaContext();
	string NombreUsuario;
	DateTime dt = DateTime.Now;
	public AltaUsuarios(string user)
	{
		InitializeComponent();
		NombreUsuario = user;
	}

	public async void RegistrarNuevoUsuario(object sender, EventArgs e)
	{
		string Username = CampoUsuario.Text;                    //Recojo el usuario de la interfaz
		string Password = CampoContrasena.Text;                 //Recojo la contrase�a de la interfaz
		string CompruebaPassword = CampoRepiteContrasena.Text;  //Recojo la comprobacion de la contrase�a de la interfaz

		var us = presenciaContext.Usuarios
						.Where(b => b.Username == Username)
						.FirstOrDefault();

		if (us is not null)
		{
			if (CampoUsuario.Text == us.Username)
			{
				await DisplayAlert("Alert","El usuario "+Username+" ya existe, por favor pruebe otro","OK");
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
				bool inserta = OperacionesDBContext.insertaUsuario(Username, Password,esAdmin);
				presenciaContext.Logs.Add(new Log("A�adir", NombreUsuario + " ha a�adido grupo de trabajo " + Username + " - " + dt));
				presenciaContext.SaveChanges();
				if (inserta == true) 
				{
					//Activo label de aceptacion, se ha insertado.
					await DisplayAlert("Alert", "Usuario "+Username+" insertado correctamente.", "OK");
				}
                else
                {
					await DisplayAlert("Alert", "Error al insertar el usuario "+Username+".", "OK");
                }

			}
			else
			{
				//Activa label error, no coinciden las contrase�as
				await DisplayAlert("Alert", "Las contrase�as deben coincidir.", "OK");
			}
		}
	}   

	public void VolverAlMain(object sender, EventArgs e)
    {
		App.Current.MainPage = new NavigationPage(new PaginaAdmin(NombreUsuario));
	}
}