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
	public AltaUsuarios(string user,int actualiza)
	{
		InitializeComponent();
		NombreUsuario = user;
        switch (actualiza)
        {
			case 1:
				var usuario = presenciaContext.Usuarios.Where(x => x.Username == user).FirstOrDefault();
				CampoUsuario.Text = usuario.Username;
				CampoContrasena.Text = usuario.Password;
				CampoRepiteContrasena.Text = usuario.Password;
				BotonActualizarAdmin.IsEnabled = true;
				BotonActualizarAdmin.IsVisible = true;
				BotonRegistrarAdmin.IsEnabled = false;
				BotonRegistrarAdmin.IsVisible = false;
				LabelUsuario.Text = usuario.Username;
				LabelUsuario.IsVisible = true;
				LabelUsuario.IsEnabled = true;
				CampoUsuario.IsEnabled = false;
				CampoUsuario.IsVisible = false;
				break;
        }
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
				bool inserta = OperacionesDBContext.InsertaUsuario(new Usuarios(Username, Password,esAdmin));
				presenciaContext.Logs.Add(new Log("A�adir", NombreUsuario + " ha a�adido grupo de trabajo " + Username + " - " + dt));
				presenciaContext.SaveChanges();
				if (inserta == true) 
				{
					//Activo label de aceptacion, se ha insertado.
					await DisplayAlert("Alert", "Usuario "+Username+" insertado correctamente.", "OK");
					App.Current.MainPage = new NavigationPage(new PaginaAdmin(NombreUsuario,1));
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
		App.Current.MainPage = new NavigationPage(new PaginaAdmin(NombreUsuario,1));
	}
    private async void BotonActualizarAdmin_Clicked(object sender, EventArgs e)
    {
		string Username = CampoUsuario.Text;                    //Recojo el usuario de la interfaz
		string Password = CampoContrasena.Text;                 //Recojo la contrase�a de la interfaz
		string CompruebaPassword = CampoRepiteContrasena.Text;  //Recojo la comprobacion de la contrase�a de la interfaz

		var us = presenciaContext.Usuarios
						.Where(b => b.Username == Username)
						.FirstOrDefault();

		if (us is not null)
		{
			if (CampoContrasena.Text == CampoRepiteContrasena.Text)
			{
				bool esAdmin = false;
				if (BotonEsAdmin.IsChecked)
                {
					esAdmin = true;
                }
				us.Nombre = Username;
				us.Password = Password;
				us.esAdmin = esAdmin;
				//bool inserta = OperacionesDBContext.actualizaUsuario(us.Username, Username, Password, esAdmin);
				bool inserta = OperacionesDBContext.ActualizaUsuario(us);
				OperacionesDBContext.InsertaLog(new Log("Actualizar", NombreUsuario + " ha actualizado grupo de trabajo " + Username + " - " + dt));
				if (inserta == true)
				{ 
					//Activa popup aceptacion, inserta el usuario
					await DisplayAlert("Alert", "Usuario " + Username + " Actualizado correctamente.", "OK");
					App.Current.MainPage = new NavigationPage(new PaginaAdmin(NombreUsuario, 1));
				}
				else
				{
					//Activa popup error, si no puede inserta el usuario
					await DisplayAlert("Alert", "Error al insertar el usuario " + Username + ".", "OK");
				}

			}
			else
			{
				//Activa popup error, no coinciden las contrase�as
				await DisplayAlert("Alert", "Las contrase�as deben coincidir.", "OK");
			}
		}
	}
}