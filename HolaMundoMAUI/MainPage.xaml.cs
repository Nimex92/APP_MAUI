using Bibliotec;
using Persistencia;
using System.Diagnostics;

namespace HolaMundoMAUI;

public partial class MainPage : ContentPage
{	
	PresenciaContext p = new PresenciaContext();
	DateTime dt = DateTime.Now;
	DateTime Today = DateTime.Today;
	public MainPage()
	{
		InitializeComponent();
		CompruebaTurnos();	
	}
	public void CompruebaTurnos()
    {
		var Turnos = p.Turno.ToList();
		foreach(Turno t in Turnos)
        {
            if (t.ValidoDesde<=Today)
            {
				t.Activo = true;

            }
			if(t.ValidoHasta<Today)
            {
				t.Activo = false;
				t.Eliminado = true;
			}
			p.SaveChanges();
		}
		
    }
	public async void CambiaFichar(object sender, EventArgs e)
    {
		try
		{
			string NombreUsuario = CampoUsuario.Text;
			string ContrasenaUsuario = CampoContraseņa.Text;
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
			}
			else
			{
				CuerpoLogin.Background = Color.FromRgba("#5e1b1b");
				irPaginaFichar.Background = Color.FromRgba("#5e1b1b");
				ContrasenaOlvidada.Background = Color.FromRgba("#5e1b1b");

				await CuerpoLogin.TranslateTo(-20, 0, 200);
				await CuerpoLogin.TranslateTo(20, 0, 200);
				await CuerpoLogin.TranslateTo(-20, 0, 200);
				await CuerpoLogin.TranslateTo(20, 0, 200);
				await CuerpoLogin.TranslateTo(-20, 0, 200);
				await  CuerpoLogin.TranslateTo(20, 0, 200);
				await CuerpoLogin.TranslateTo(0, 0, 200);
				CuerpoLogin.Background = Color.FromRgba("#2B282D");
				irPaginaFichar.Background = Color.FromRgba("#2B282D");
				ContrasenaOlvidada.Background = Color.FromRgba("#2B282D");


				DisplayAlert("Error de credenciales", "El usuario o la contraseņa son incorrectos.", "Vale");
			}
		}catch(NullReferenceException ex)
        {
			Debug.WriteLine(ex.ToString());
        }
	}

}