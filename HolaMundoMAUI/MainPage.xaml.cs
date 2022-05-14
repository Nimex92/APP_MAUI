using Persistencia;
using System.Diagnostics;

namespace HolaMundoMAUI;

public partial class MainPage : ContentPage
{	
	PresenciaContext presenciaContext = new PresenciaContext();
	string user;
	public MainPage()
	{
		InitializeComponent();
	}
	public async void CambiaFichar(object sender, EventArgs e)
    {
		string NombreUsuario = CampoUsuario.Text;
		string ContrasenaUsuario = CampoContraseña.Text;

        var usuario = presenciaContext.Usuarios
							.Where(b => b.Username == NombreUsuario && b.Password == ContrasenaUsuario).FirstOrDefault();
		
		if (usuario is not null) {
            if (usuario.esAdmin == true)
            {
				MensajeError.IsVisible = false;
				App.Current.MainPage = new NavigationPage(new PaginaAdmin(NombreUsuario));
				presenciaContext.Logs.Add(new Bibliotec.Log("Login", NombreUsuario + " ha iniciado sesion"));
				presenciaContext.SaveChanges();
				user = NombreUsuario;
			}
<<<<<<< Updated upstream
            else
            {
				MensajeError.IsVisible = false;
				App.Current.MainPage = new NavigationPage(new PaginaFichar(NombreUsuario));
				presenciaContext.Logs.Add(new Bibliotec.Log("Login", NombreUsuario + " ha iniciado sesion"));
				presenciaContext.SaveChanges();
=======
			p.SaveChanges();
		}
		
    }
	public async void CambiaFichar(object sender, EventArgs e)
    {
		try
		{
			string NombreUsuario = CampoUsuario.Text;
			string ContrasenaUsuario = CampoContraseña.Text;
			var usuario = p.Usuarios
								.Where(b => b.Username == NombreUsuario && b.Password == ContrasenaUsuario).FirstOrDefault();
			await irPaginaFichar.ScaleTo(1.3, 500, Easing.BounceIn);
			await irPaginaFichar.ScaleTo(1.0, 100, Easing.BounceOut);

			if (usuario is not null)
			{
				if (usuario.esAdmin == true)
				{
					
					CuerpoLogin.Background = Color.FromRgba("#1b5e3b");
					irPaginaFichar.Background = Color.FromRgba("#1b5e3b");
					ContrasenaOlvidada.Background = Color.FromRgba("#1b5e3b");
					await CuerpoLogin.TranslateTo(2000, 0, 1500);
                    App.Current.MainPage = new NavigationPage(new PaginaAdmin(NombreUsuario));
                    OperacionesDBContext.InsertaLog(new Log("Login", NombreUsuario + " ha iniciado sesion - " + dt));
				}
				else
				{
					CuerpoLogin.Background = Color.FromRgba("#1b5e3b");
					irPaginaFichar.Background = Color.FromRgba("#1b5e3b");
					ContrasenaOlvidada.Background = Color.FromRgba("#1b5e3b");
					await CuerpoLogin.TranslateTo(-2000, 0, 1500);
					App.Current.MainPage = new NavigationPage(new PaginaFichar(NombreUsuario));
					OperacionesDBContext.InsertaLog(new Log("Login", NombreUsuario + " ha iniciado sesion - " + dt));
				}
>>>>>>> Stashed changes
			}
			

        }
<<<<<<< Updated upstream
        else
        {
			MensajeError.Text = "El usuario o la contraseña son incorrectos.";
			usuario = new("", "");
			MensajeError.IsVisible = true;
			await DisplayAlert("Alert", "El usuario o la contraseña son incorrectos.", "OK");
		}
	}
	public void AltaUsuario(object sender, EventArgs e)
    {
		App.Current.MainPage = new NavigationPage(new AltaUsuarios(user));
=======
		catch(Exception ex)
        {
			Debug.WriteLine(ex.ToString());
			await CuerpoLogin.TranslateTo(0, 0, 1500);

		}
>>>>>>> Stashed changes
	}

}