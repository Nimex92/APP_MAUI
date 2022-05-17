using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace HolaMundoMAUI;


public partial class TrabajadoresEnTurno : ContentPage
{
	PresenciaContext presenciaContext = new PresenciaContext();
	string NombreUsuario;

	public TrabajadoresEnTurno(string user)
	{
		InitializeComponent();
		SetListView();
		NombreUsuario = user;
	}
	private void actualiza()
	{
		App.Current.MainPage = new NavigationPage(new TrabajadoresEnTurno(NombreUsuario));
	}
	public void SetListView()
	{
		var trabajador = presenciaContext.TrabajadorEnTurno.Include(x => x.trabajador).Include(x=>x.trabajador.Equipo).Include(x=>x.trabajador.Usuario).ToList();
		ListViewUsuarios.ItemsSource = trabajador;
	}
	public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		
	}

    private void BotonVolver_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new NavigationPage(new PaginaAdmin(NombreUsuario));
    }
}