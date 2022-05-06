using Bibliotec;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System.Diagnostics;

namespace HolaMundoMAUI;

public partial class BorraTrabajadorDeGrupo : ContentPage
{
	PresenciaContext p = new PresenciaContext();
	string nombreUsuario;
	EquipoTrabajo equipoTrabajo;
	public BorraTrabajadorDeGrupo(string user,EquipoTrabajo eq)
	{
		nombreUsuario = user;
		equipoTrabajo = eq;
		InitializeComponent();
		SetPickers();
	}

	private void SetPickers()
	{
		var equipos = p.EquipoTrabajo;
		var trabajadores = p.Trabajador.Where(x=>x.equipo.Contains(equipoTrabajo)).ToList();

		//Recojo todos los Turnos de la tabla de MySql
		//Creo una lista para guardar todos los turnos existentes
		var ListaGrupos = new List<string>();
		var ListaTrabajador = new List<string>();
		//Para cada lista que haya en la seleccion Turno, a�ado al selector (Picker de la interfaz) El nombre del turno
		SelectorTareas.Items.Add("-- Selecciona Trabajador.");
		
		SelectorGruposTrabajo.Items.Add(equipoTrabajo.Nombre);
		
		foreach (Trabajador t in trabajadores)
		{
			SelectorTareas.Items.Add(t.nombre);
		}
		SelectorGruposTrabajo.SelectedIndex = 0;
		SelectorTareas.SelectedIndex = 0;
	}

    private void BotonVolver_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new NavigationPage(new PaginaAdmin(nombreUsuario, 6));
    }

    private async void BotonRegistrar_Clicked(object sender, EventArgs e)
    {
		string BuscaEquipo = SelectorGruposTrabajo.SelectedItem.ToString();
		string BuscaTrabajador = SelectorTareas.SelectedItem.ToString();
		var EquipoTrabajo = p.EquipoTrabajo.Where(x => x.Nombre == BuscaEquipo).Include(x=>x.Trabajadores).FirstOrDefault();
		var Trabajador = p.Trabajador.Where(x => x.nombre == BuscaTrabajador).Include(x=>x.equipo).FirstOrDefault();
		var Equipos = EquipoTrabajo.Trabajadores;
		Trabajador.perteneceaturnos = "";

		Trabajador.equipo.Remove(EquipoTrabajo);
		await DisplayAlert("Alert", BuscaTrabajador + " ya no pertenece a " + BuscaEquipo, "Vale");
		foreach (EquipoTrabajo eq in Trabajador.equipo)
		{
			Trabajador.perteneceaturnos += eq.Nombre;
			
			var trabajadores = p.Trabajador.Where(x => x.equipo.Contains(equipoTrabajo)).ToList();
			
			foreach (Trabajador t in trabajadores)
			{
				SelectorTareas.Items.Add(t.nombre);
			}
		}
		p.SaveChanges();


	}
}