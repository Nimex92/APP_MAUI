using Bibliotec;
using ClassLibrary1;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System.Diagnostics;
using Color = Microsoft.Maui.Graphics.Color;

namespace HolaMundoMAUI;

public partial class PaginaAdmin : ContentPage
{
    private string nombreUsuario;
    PresenciaContext p = new PresenciaContext();
    DateTime dt = DateTime.Now;
    Trabajador tr;
    Turno gr;
    Zonas zn;
    Tareas ta;
    EquipoTrabajo Et;
    Calendario cal;
    Dia dia;
    Boolean TrActivo, GrActivo, ZnActivo, TaActivo, EtActivo, DiActivo, NmActivo, ProblemActivo, VacacionesActivo;

    public PaginaAdmin(string nombreUsuario)
    {
        TrActivo = false;
        GrActivo = false;
        ZnActivo = false;
        TaActivo = false;
        EtActivo = false;
        NmActivo = false;
        ProblemActivo = false;
        VacacionesActivo = false;

        InitializeComponent();
        SetListViewTrabajadores();
        SetListViewGruposTrabajo();
        SetListViewTareas();
        SetListViewZonas();
        SetListViewEquiposTrabajo();
        CompruebaIncidencias();
        this.nombreUsuario = nombreUsuario;
        LabelNameUser.Text = nombreUsuario;
    }
    public PaginaAdmin(string nombreUsuario, int interfaz)
    {
        TrActivo = false;
        GrActivo = false;
        ZnActivo = false;
        TaActivo = false;
        EtActivo = false;
        NmActivo = false;
        ProblemActivo = false;
        VacacionesActivo = false;

        InitializeComponent();
        SetListViewTrabajadores();
        SetListViewGruposTrabajo();
        SetListViewZonas();
        SetListViewTareas();
        SetListViewEquiposTrabajo();
        CompruebaIncidencias();

        this.nombreUsuario = nombreUsuario;
        LabelNameUser.Text = nombreUsuario;
        switch (interfaz)
        {
            case 2:
                ListViewWorkers.IsVisible = true;
                ListViewWorkers.IsEnabled = true;
                TrActivo = true;
                LabelTitulo2.Text = "Tech Talent" + Environment.NewLine + "gesti�n de trabajadores";
                break;
            case 3:
                ListViewGroups.IsVisible = true;
                ListViewGroups.IsEnabled = true;
                GrActivo = true;
                LabelTitulo3.Text = "Tech Talent" + Environment.NewLine + "gesti�n de equipos de trabajo";
                break;
            case 4:
                ListViewZones.IsVisible = true;
                ListViewZones.IsEnabled = true;
                ZnActivo = true;
                LabelTitulo4.Text = "Tech Talent" + Environment.NewLine + "gesti�n de Zonas de trabajo";
                break;
            case 5:
                ListViewTasks.IsVisible = true;
                ListViewTasks.IsEnabled = true;
                TaActivo = true;
                LabelTitulo5.Text = "Tech Talent" + Environment.NewLine + "gesti�n de tareas";
                break;
            case 6:
                ListViewTeams.IsVisible = true;
                ListViewTeams.IsEnabled = true;
                EtActivo = true;
                LabelTitulo5.Text = "Tech Talent" + Environment.NewLine + "gesti�n de turnos de trabajo";
                break;
            case 7:
                ListViewCalendar.IsVisible = true;
                ListViewCalendar.IsEnabled = true;
                DiActivo = true;
                LabelTitulo7.Text = "Tech Talent" + Environment.NewLine + "gesti�n de dias libres";
                break;
            case 8:

                break;
            case 9:

                break;
        }

    }
    //Settear ListViews de la ventana ////////////////////////////////////////////////////////////
    public void SetListViewGruposTrabajo()
    {
        PresenciaContext presenciaContext = new PresenciaContext();
        var turnos = presenciaContext.Turno.Where(x => x.Eliminado == false).OrderBy(x => x.Nombre).ToList();
        ListViewGrupos.ItemsSource = turnos;
        if (turnos.Count > 0)
            ListViewGrupos.SelectedItem = turnos[0];
    }
    public void SetListViewTrabajadores()
    {
        PresenciaContext p = new PresenciaContext();
        var workers = p.Trabajador.Include(x => x.Usuario).ToList();
        ListViewTrabajadores.ItemsSource = workers;
        if (workers.Count > 0)
            ListViewTrabajadores.SelectedItem = workers[0];
    }
    public void SetListViewZonas()
    {
        PresenciaContext presenciaContext = new PresenciaContext();
        var zones = presenciaContext.Zonas.ToList();
        ListViewZonas.ItemsSource = zones;
        if (zones.Count > 0)
            ListViewZonas.SelectedItem = zones[0];
    }
    public void SetListViewTareas()
    {
        PresenciaContext presenciaContext = new PresenciaContext();
        var tareas = presenciaContext.Tareas.ToList();
        ListViewTareas.ItemsSource = tareas;
        if (tareas.Count > 0)
        {
            ListViewTareas.SelectedItem = tareas[0];
        }
    }
    public void SetListViewEquiposTrabajo()
    {
        PresenciaContext presenciaContext = new PresenciaContext();
        var equipos = presenciaContext.EquipoTrabajo.ToList();
        ListViewEquipos.ItemsSource = equipos;
        if (equipos.Count > 0)
        {
            ListViewEquipos.SelectedItem = equipos[0];
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////

    ///////// Lo que sucede cuando pulsamos en cada uno de los list view /////////////////////////
    public void OnItemSelectedTrabajadores(object sender, SelectedItemChangedEventArgs e)
    {
        Trabajador item = e.SelectedItem as Trabajador;
        tr = item;
        cal = p.Calendario.Where(x => x.Trabajador == item).Include(x => x.Trabajador).FirstOrDefault();

    }
    public void OnItemSelectedGruposTrabajo(object sender, SelectedItemChangedEventArgs e)
    {
        Turno item = e.SelectedItem as Turno;
        gr = item;
    }
    public void OnItemSelectedEquiposTrabajo(object sender, SelectedItemChangedEventArgs e)
    {
        EquipoTrabajo item = e.SelectedItem as EquipoTrabajo;
        Et = item;
    }
    public void OnItemSelectedZonas(object sender, SelectedItemChangedEventArgs e)
    {
        Zonas item = e.SelectedItem as Zonas;
        zn = item;
    }
    public void OnItemSelectedCalendario(object sender, SelectedItemChangedEventArgs e)
    {
        Dia item = e.SelectedItem as Dia;
        dia = item;
    }
    public void OnItemSelectedTareas(object sender, SelectedItemChangedEventArgs e)
    {
        Tareas item = e.SelectedItem as Tareas;
        ta = item;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////

    /////////// Funciones Menu lateral ///////////////////////////////////////////////////////////
    private void BtnTrabajadores_Clicked(object sender, EventArgs e)
    {
        if (TrActivo == false)
        {
            ListViewWorkers.IsVisible = true;
            ListViewWorkers.IsEnabled = true;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewCalendar.IsVisible = false;
            ListViewCalendar.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewIssues.IsVisible = false;




            BotonTrabajador.BackgroundColor = Color.FromRgba("#84677D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");


            TrActivo = true;
            GrActivo = false;
            ZnActivo = false;
            TaActivo = false;
            EtActivo = false;
            CompruebaIncidencias();

            LabelTitulo2.Text = "Tech Talent" + Environment.NewLine + "gesti�n de trabajadores";
        }
        else
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewIssues.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");


            TrActivo = false;
            GrActivo = false;
            ZnActivo = false;
            TaActivo = false;
            EtActivo = false;
            CompruebaIncidencias();
        }
    }
    private void BtnGruposTrabajo_Clicked(object sender, EventArgs e)
    {
        if (GrActivo == false)
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewGroups.IsVisible = true;
            ListViewGroups.IsEnabled = true;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewCalendar.IsVisible = false;
            ListViewCalendar.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewIssues.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#84677D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");


            GrActivo = true;
            TrActivo = false;
            TaActivo = false;
            ZnActivo = false;
            EtActivo = false;
            CompruebaIncidencias();
        }
        else
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewIssues.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");


            GrActivo = false;
            TrActivo = false;
            TaActivo = false;
            ZnActivo = false;
            EtActivo = false;
            CompruebaIncidencias();
        }
    }
    private void BtnEquiposTrabajo_Clicked(object sender, EventArgs e)
    {
        if (EtActivo == false)
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
            ListViewTeams.IsVisible = true;
            ListViewTeams.IsEnabled = true;
            ListViewCalendar.IsVisible = false;
            ListViewCalendar.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewIssues.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#84677D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");


            GrActivo = false;
            TrActivo = false;
            TaActivo = false;
            ZnActivo = false;
            EtActivo = true;
            NmActivo = false;
            CompruebaIncidencias();

        }
        else
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewIssues.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");


            GrActivo = false;
            TrActivo = false;
            TaActivo = false;
            ZnActivo = false;
            EtActivo = false;
            NmActivo = false;
            CompruebaIncidencias();

        }
    }
    private void BtnZonas_Clicked(object sender, EventArgs e)
    {
        if (ZnActivo == false)
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = true;
            ListViewZones.IsEnabled = true;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewCalendar.IsVisible = false;
            ListViewCalendar.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewIssues.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#84677D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");


            ZnActivo = true;
            GrActivo = false;
            TrActivo = false;
            TaActivo = false;
            EtActivo = false;
            NmActivo = false;
            CompruebaIncidencias();
        }
        else
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewIssues.IsVisible = false;

            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");

            ZnActivo = false;
            GrActivo = false;
            TrActivo = false;
            TaActivo = false;
            EtActivo = false;
            NmActivo = false;
            CompruebaIncidencias();
        }
    }
    private void BtnTareas_Clicked(object sender, EventArgs e)
    {
        if (TaActivo == false)
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = true;
            ListViewTasks.IsEnabled = true;
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewCalendar.IsVisible = false;
            ListViewCalendar.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewIssues.IsVisible = false;

            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#84677D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");

            ZnActivo = false;
            GrActivo = false;
            TrActivo = false;
            TaActivo = true;
            EtActivo = false;
            NmActivo = false;
            CompruebaIncidencias();
        }
        else
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewIssues.IsVisible = false;

            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");

            TaActivo = false;
            ZnActivo = false;
            GrActivo = false;
            TrActivo = false;
            EtActivo = false;
            NmActivo = false;
            CompruebaIncidencias();
        }
    }
    private void BtnNominas_Clicked(object sender, EventArgs e)
    {
        if (NmActivo == false)
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewCalendar.IsVisible = false;
            ListViewCalendar.IsEnabled = false;
            ListViewNominas.IsVisible = true;
            ListViewIssues.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#84677D"); ;

            ZnActivo = false;
            GrActivo = false;
            TrActivo = false;
            TaActivo = false;
            EtActivo = false;
            NmActivo = true;
        }
        else
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewIssues.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");

            TaActivo = false;
            ZnActivo = false;
            GrActivo = false;
            TrActivo = false;
            EtActivo = false;
            NmActivo = false;
            CompruebaIncidencias();
        }
    }
    private void BtnProblemas_Clicked(object sender, EventArgs e)
    {
        if (NmActivo == false)
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewCalendar.IsVisible = false;
            ListViewCalendar.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewIssues.IsVisible = true;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#84677D"); ;

            ZnActivo = false;
            GrActivo = false;
            TrActivo = false;
            TaActivo = false;
            EtActivo = false;
            NmActivo = true;
        }
        else
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewIssues.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");

            TaActivo = false;
            ZnActivo = false;
            GrActivo = false;
            TrActivo = false;
            EtActivo = false;
            NmActivo = false;
            CompruebaIncidencias();
        }
    }
    private void BotonNominas_Clicked(object sender, EventArgs e)
    {
        GeneraNominaPdf(tr);
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////

    /////// Metodos de las funciones de a�adir ////////////////////////////////////////////////////
    private void BotonAnadeZona_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaZona(nombreUsuario, "", 0));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'A�adir zonas de trabajo " + "-" + dt));
    }
    private void BtnAnadeTarea_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaTareaTrabajo(nombreUsuario));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'A�adir tareas de trabajo" + " - " + dt));
    }
    private void BtnAnadeDias_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadeDiaCalendario(nombreUsuario, cal, 0, dia));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'A�adir dias al calendario" + " - " + dt));

    }
    private void BtnAnadeTareaGrupoTrabajo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadeTareasGrupoTrabajo(nombreUsuario));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'A�adir tarea a grupo de trabajo:'" + ta.NombreTarea + " - " + dt));
    }
    private void AddZonasGrupos_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadirZonaGrupoTrabajo(nombreUsuario));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'A�adir zonasa grupo de trabajo:'" + zn.Nombre + " - " + dt));
    }
    private void BtnAnadeEquipos_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaGrupoTrabajo(nombreUsuario, "", 0));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " ha accedido a \"Registrar nuevo equipo de trabajo\" - " + dt));
    }
    private void BtnAnadeTrabajadorAEquipo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadeTrabajadorEquipoTrabajo(nombreUsuario));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'A�adir trabajador a un grupo de trabajo" + " - " + dt));

    }
    private void AddGruposEquipoTrabajo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadirTurnoEquipoTrabajo(nombreUsuario, gr.Nombre, 0));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'A�adir turno a equipo de trabajo' - " + dt));
    }
    public void NuevoUsuario(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaUsuarios(nombreUsuario));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'Registrar usuario' - " + dt));
    }
    public void NuevoTrabajador(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaTrabajador(nombreUsuario, 0));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'Registrar trabajador' - " + dt));
    }
    public void NuevoGrupoTrabajo(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaTurno(nombreUsuario, 0));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'Registrar grupo de trabajo' - " + dt));
    }
    public async void VolverAlMainAdmin(object sender, EventArgs e)
    {
        await DisplayAlert("Alert", "Hasta luego, " + nombreUsuario, "OK");
        App.Current.MainPage = new NavigationPage(new MainPage());
        OperacionesDBContext.InsertaLog(new Log("Logout", nombreUsuario + " ha cerrado sesion -" + dt));

    }
    private void RegistrarNuevaTareaTrabajo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaTareaTrabajo(nombreUsuario));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'A�adir tareas de trabajo' - " + dt));
    }
    private void RegistrarNuevaZona_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaZona(nombreUsuario));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'A�adir zona de trabajo' - " + dt));
    }
    private void AnadeTareasGrupo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadeTareasGrupoTrabajo(nombreUsuario));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'A�adir Tareas a grupo' - " + dt));
    }
    private void AnadirZonaGrupo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadirZonaGrupoTrabajo(nombreUsuario));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'A�adir zona de trabajo' - " + dt));
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////

    /////// Metodos de las funciones de modificar /////////////////////////////////////////////////
    private void BotonEditarZonas_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaZona(nombreUsuario, zn.Nombre, 1));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'Editar zonas de trabajo" + " - " + dt));

    }
    private void BotonEditarEquiposTrabajo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaGrupoTrabajo(nombreUsuario, Et.Nombre, 1));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'Editar equipo de trabajo '+" + ta.NombreTarea + " - " + dt));
    }
    private void BotonActualizaDias_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadeDiaCalendario(nombreUsuario, cal, 1, dia));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'A�adir dias al calendario" + " - " + dt));

    }
    private void BotonEditarTareas_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaTareaTrabajo(nombreUsuario, ta.NombreTarea, 1));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'Editar tarea de trabajo '+" + ta.NombreTarea + " - " + dt));
    }
    private void BotonEditarGruposTrabajo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaTurno(nombreUsuario, gr.Nombre, 1));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'Editar grupo de trabajo' " + gr.Nombre + " - " + dt));
    }
    private void BotonEditarTrabajadores_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaTrabajador(tr.Nombre, 1));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'Editar trabajador '+" + tr.Nombre + " - " + dt));
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////
    /////// Metodos de las funciones de borrado ///////////////////////////////////////////////////
    private async void BotonBorrarTrabajadores_Clicked(object sender, EventArgs e)
    {
        try
        {
            bool answer = await DisplayAlert("Question?", "�Estas seguro de borrar el trabajador \"" + tr.Nombre + "\"?", "Si", "No");
            if (tr is not null && answer == true)
            {
                OperacionesDBContext.BorraTrabajador(tr);
                OperacionesDBContext.InsertaLog(new Log("Eliminar", nombreUsuario + " ha eliminado trabajador \"" + tr.Nombre + "\" - " + dt));
                App.Current.MainPage = new NavigationPage(new PaginaAdmin(nombreUsuario, 2));
            }
            else
            {
                await DisplayAlert("Alert", "No se han producido cambios.", "Vale");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alert", "Error inesperado " + ex.StackTrace, "Vale");
        }
    }
    private async void BotonBorrarGruposTrabajo_Clicked(object sender, EventArgs e)
    {
        try
        {
            bool answer = await DisplayAlert("Question?", "�Estas seguro de borrar el grupo \"" + gr.Nombre + "\"?", "Si", "No");
            if (answer == true)
            {
                Turno turno = gr;
                OperacionesDBContext.BorraTurno(turno);
                OperacionesDBContext.InsertaLog(new Log("Eliminar", nombreUsuario + " ha eliminado grupo de trabajo " + gr.Nombre + " - " + dt));
                await DisplayAlert("Alert", "Se ha eliminado correctamente.", "Vale");

                App.Current.MainPage = new NavigationPage(new PaginaAdmin(nombreUsuario, 3));

            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alert", "Error inesperado " + ex.Message, "Vale");
        }
    }
    private async void BotonBorrarZonas_Clicked(object sender, EventArgs e)
    {
        if (zn is not null)
        {
            bool answer = await DisplayAlert("Question?", "�Desea Borrar la zona \"" + zn.Nombre + "\"?", "Si", "No");
            if (answer == true)
            {
                await DisplayAlert("Alert", "Se ha borrado correctamente " + zn.Nombre, "OK");
                OperacionesDBContext.BorraZona(zn);
                OperacionesDBContext.InsertaLog(new Log("Eliminar", nombreUsuario + " ha eliminar " + zn.Nombre + " - " + dt));
                App.Current.MainPage = new NavigationPage(new PaginaAdmin(nombreUsuario, 4));
            }
            else
            {
                await DisplayAlert("Alert", "No se han realizado cambios ", "OK");
            }
        }
        else
        {
            await DisplayAlert("Alert", "Por favor, Seleccione un elemento primero", "OK");
        }
    }
    private void BotonQuitarTrabajadorDeGrupo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new BorraTrabajadorDeGrupo(nombreUsuario, Et));
    }
    private void RemoveGruposEquipoTrabajo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadirTurnoEquipoTrabajo(nombreUsuario, gr.Nombre, 1));
        p.Logs.Add(new Log("Acceso", nombreUsuario + " Accede a 'A�adir turno a equipo de trabajo' - " + dt));
        p.SaveChanges();
    }
    private async void BotonBorrarDias_Clicked(object sender, EventArgs e)
    {

        bool respuesta = await DisplayAlert("Question?", "�Deseas eliminar este dia?", "Si", "No");
        if (respuesta == true)
        {
            p.DiaLibre.Remove(dia);
            p.SaveChanges();
            await DisplayAlert("Alert", "Se ha eliminado correctamente", "Vale");
            App.Current.MainPage = new NavigationPage(new PaginaAdmin(nombreUsuario, 2));
        }
        else
        {
            await DisplayAlert("Alert", "No se realizaron cambios.", "Vale");
        }
    }
    private async void BotonBorrarTareas_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Question?", "�Estas seguro de borrar la tarea \"" + ta.NombreTarea + "\"?", "Si", "No");
        if (answer == true)
        {
            if (ta is not null)
            {
                OperacionesDBContext.BorraTarea(ta);
                OperacionesDBContext.InsertaLog(new Log("Eliminar", nombreUsuario + " ha eliminado la tarea " + ta.NombreTarea + " - " + dt));
                App.Current.MainPage = new NavigationPage(new PaginaAdmin(nombreUsuario, 5));
            }
            else
            {
                await DisplayAlert("Alert", "Error!", "OK");
            }
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////

    /////////// Otras funciones //////////////////////////////////////////////////////////////////
    private async void BotonCalendario_Clicked(object sender, EventArgs e)
    {
        ListViewCalendar.IsVisible = true;
        ListViewCalendar.IsEnabled = true;
        ListViewWorkers.IsVisible = false;
        ListViewWorkers.IsEnabled = false;

        var ExisteCalendario = p.Calendario.Where(x => x.Trabajador == tr).Include(x => x.DiasDelCalendario).FirstOrDefault();
        if (ExisteCalendario is not null)
        {
            var ListaDias = ExisteCalendario.DiasDelCalendario.ToList();
            ListViewCalendario.ItemsSource = ListaDias;
            if (ListaDias.Count > 0)
                ListViewCalendario.SelectedItem = ListaDias[0];
        }
        else
        {
            await DisplayAlert("Alert", "El trabajador no dispone de calendario, se procede a crearlo", "Vale");
            var trabajador = p.Trabajador.Where(x => x.NumeroTarjeta == tr.NumeroTarjeta).FirstOrDefault();
            var calendario = new Calendario(trabajador);
            p.Calendario.Add(calendario);
            p.SaveChanges();
            await DisplayAlert("Alert", "Calendario creado con exito", "Vale");
        }
        CompruebaDias(tr);
    }
    private void VolverATrabajadores_Clicked(object sender, EventArgs e)
    {
        ListViewCalendar.IsVisible = false;
        ListViewCalendar.IsEnabled = false;
        ListViewWorkers.IsVisible = true;
        ListViewWorkers.IsEnabled = true;
    }
    private async void BotonCerrarSesion_Clicked(object sender, EventArgs e)
    {
        //BotonCerrarSession.BackgroundColor = Color.FromRgba("#2B282D");
        bool answer = await DisplayAlert("Logout", "�Deseas cerrar sesi�n?", "Si", "No");
        if (answer == true)
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
    private async void CompruebaDias(Trabajador tr)
    {
        var ListaFichajes = p.Fichajes.Where(x => x.Trabajador == tr).ToList();
        var CalendarioTrabajador = p.Calendario.Where(x => x.Trabajador == tr).Include(x => x.DiasDelCalendario).FirstOrDefault();
        var ListaDiasLibres = CalendarioTrabajador.DiasDelCalendario.ToList();
        var FechasFichajes = Fichajes.GetFechas(ListaFichajes);
        var FechasFestivos = Dia.GetFechas(ListaDiasLibres);
        foreach (DateTime d in FechasFestivos)
        {
            if (FechasFichajes.Contains(d))
            {

                var ListaDias = p.DiaLibre.ToList();
                foreach (Dia di in ListaDias)
                {
                    if (di.CalendarioPertenece == CalendarioTrabajador && di.Fecha == d)
                    {
                        di.Disfrutado = true;
                        p.DiaLibre.Update(di);
                        p.SaveChanges();
                    }
                    else
                    {
                        di.Disfrutado = false;
                        p.DiaLibre.Update(di);
                    }
                }


            }

        }
    }
    private void TrabajadoresEnTurno_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new TrabajadoresEnTurno(nombreUsuario));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'Trabajadores en turno' - " + dt));
    }
    public async void CompruebaIncidencias()
    {
        try
        {
            var ListaIncidencias = p.Incidencias.Where(x => x.Justificada == false).Include(x => x.Trabajador).ToList();
            ListViewIncidencias.ItemsSource = ListaIncidencias;
            if (ListaIncidencias.Count > 0)
            {
                BtnProblemas.Source = "problemasactivo.png";
                ListViewIncidencias.SelectedItem = ListaIncidencias[0];
            }
            else
            {
                BtnProblemas.Source = "problemas.png";
            }
        }
        catch (NullReferenceException ex)
        {
            Debug.WriteLine(ex.ToString());
        }
    }
    public void GeneraNominaPdf(Trabajador tr)
    {
        try
        {
            PdfWriter writer = new PdfWriter("C:\\Users\\jesus\\Desktop\\HolaMundoMAUI\\Nominas\\demo2.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            Paragraph header = new Paragraph("Nomina mensual")
               .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
               .SetFontSize(20);
            BetterTable DatosEmpresa = GeneraTabla(3, 2);
            DatosEmpresa.SetColorHeader(ColorConstants.LIGHT_GRAY);
            DatosEmpresa.ChangeTableFontSize(8);
            DatosEmpresa.SetNextText("Empresa");
            DatosEmpresa.SetNextText("Direccion");
            DatosEmpresa.SetNextText("CIF");
            DatosEmpresa.SetNextText("TTI Ventures");
            DatosEmpresa.SetNextText(" C. Paletillas,6,Calahorra");
            DatosEmpresa.SetNextText("B26557397");
            BetterTable DatosTrabajador = GeneraTabla(5, 2);
            DatosTrabajador.SetColorHeader(ColorConstants.LIGHT_GRAY);
            DatosTrabajador.ChangeTableFontSize(8);
            DatosTrabajador.SetNextText("Trabajador");
            DatosTrabajador.SetNextText("Categoria");
            DatosTrabajador.SetNextText("N� Matricula");
            DatosTrabajador.SetNextText("Antiguedad");
            DatosTrabajador.SetNextText("D.N.I");
            DatosTrabajador.SetNextText(tr.Nombre);
            DatosTrabajador.SetNextText(tr.Categoria);
            DatosTrabajador.SetNextText("");
            DatosTrabajador.SetNextText((dt - tr.FechaDeContratacion).Days.ToString());
            DatosTrabajador.SetNextText(tr.Dni);
            BetterTable OtrosDatos = GeneraTabla(7, 2);
            OtrosDatos.SetColorHeader(ColorConstants.LIGHT_GRAY);
            OtrosDatos.ChangeTableFontSize(8);
            OtrosDatos.SetNextText("N� Afiliaci�n S.S");
            OtrosDatos.SetNextText("Tarifa");
            OtrosDatos.SetNextText("Cod C.T.");
            OtrosDatos.SetNextText("Secci�n");
            OtrosDatos.SetNextText("Nro.");
            OtrosDatos.SetNextText("Periodo");
            OtrosDatos.SetNextText("D�as");
            OtrosDatos.SetNextText(tr.NumeroSeguridadSocial);
            var diasTrabajador = p.Fichajes.Where(x => x.Trabajador == tr).Where(x => x.Entrada_Salida == "Entrada").OrderBy(x => x.FechaFichaje).ToList();
            var diastotal = diasTrabajador.Count;
            var lapso = diasTrabajador.First().FechaFichaje.Date + "-" + diasTrabajador.Last().FechaFichaje.Date;
            OtrosDatos[1,6].SetText(lapso.ToString());
            OtrosDatos[1,5].SetText(diastotal.ToString());
            BetterTable CuerpoNomina = GeneraTabla(5, 8);
            CuerpoNomina.SetColorHeader(ColorConstants.LIGHT_GRAY);
            CuerpoNomina.ChangeTableFontSize(10);
            CuerpoNomina.RemoveBorder(1);
            CuerpoNomina.AddTableBorder(1);
            CuerpoNomina.SetNextText("Cuant�a");
            CuerpoNomina.SetNextText("Precio");
            CuerpoNomina.SetNextText("Concepto");
            CuerpoNomina.SetNextText("Devengos");
            CuerpoNomina.SetNextText("Deducciones");
            BetterTable PieNomina1 = GeneraTabla(7, 2);
            PieNomina1.SetColorHeader(ColorConstants.LIGHT_GRAY);
            PieNomina1.ChangeTableFontSize(8);
            PieNomina1.SetNextText("Rem. Total");
            PieNomina1.SetNextText("P.P. Extras");
            PieNomina1.SetNextText("Base S.S.");
            PieNomina1.SetNextText("Base A.T y DES");
            PieNomina1.SetNextText("Base I.R.P.F");
            PieNomina1.SetNextText("T. Devengo");
            PieNomina1.SetNextText("T. a deducir");
            Paragraph SubPieNomina1 = new Paragraph("* Percepciones salariales sujetas a Cot. S.S.\t\t\t\t\t\t\t\t *Percepciones no salariales excluidas Cot. S.S.")
               .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
               .SetFontSize(6);
            BetterTable PieNomina2 = GeneraTabla(4, 5);
            PieNomina2.ChangeTableFontSize(6);
            PieNomina2.RemoveBorder(1);
            PieNomina2.AddTableBorder(1);
            PieNomina2.SetNextText("Fecha");
            PieNomina2.SetNextText("Sello empresa");
            PieNomina2.SetNextText("Recibi");
            PieNomina2[0, 0].SetText("16 de Mayo de 2022");
            PieNomina2[4, 0].SetText("SWIFT/BIC: 789456258");
            PieNomina2[4, 0].SetText("IBAN: ES45678912324");
            PieNomina2[4, 0].SetTextAlign("START");
            PieNomina2[1, 3].SetText("Total a percibir");
            PieNomina2[1, 3].AddAllBorders();
            PieNomina2[2, 3].SetText("1245.74�");
            PieNomina2[2, 3].AddAllBorders();
            PieNomina2.AddTableBorder(1);
            BetterTable CabeceraPieNomina3 = GeneraTabla(1, 1);
            CabeceraPieNomina3.ChangeTableFontSize(8);
            CabeceraPieNomina3.RemoveBorder(2);
            CabeceraPieNomina3.TableConjunctionDown();
            CabeceraPieNomina3.SetNextText("DETERMINACION DE LA B. DE COTIZACION A LA S.S. Y CONCEPTOS DE RECAUCACION CONJUNTA Y APORTACION A LA EMPRESA");
            BetterTable PieNomina3 = GeneraTabla(5, 8);
            PieNomina3.TableConjunctionUp();
            PieNomina3.ChangeTableFontSize(8);
            PieNomina3.RemoveBorder(1);
            PieNomina3.AddTableBorder(1);
            PieNomina3[0, 0].SetText("Concepto");
            PieNomina3[0, 0].SetTextAlign("END");
            PieNomina3[0, 2].SetText("Base");
            PieNomina3[0, 3].SetText("Tipo");
            PieNomina3[0, 4].SetText("Aportacion Empresarial");
            PieNomina3[1, 0].SetText("1. Contingencias comunes");
            PieNomina3[1, 1].SetText("......................");
            PieNomina3[1, 2].SetText("1475.00");
            PieNomina3[1, 3].SetText("23.60");
            PieNomina3[1, 4].SetText("348.10");
            PieNomina3[2, 0].SetText("2. Contingencias profesionales");
            PieNomina3[2, 1].SetText("AT Y EP................");
            PieNomina3[2, 2].SetText("1475.00");
            PieNomina3[2, 3].SetText("1.00");
            PieNomina3[2, 4].SetText("14.75");
            PieNomina3[3, 0].SetText(" y conceptos de reaudacion");
            PieNomina3[3, 1].SetText("Desempleo--............");
            PieNomina3[3, 2].SetText("1475.00");
            PieNomina3[3, 3].SetText("5.50");
            PieNomina3[3, 4].SetText("81.13");
            PieNomina3[4, 0].SetText("Conjunta");
            PieNomina3[4, 1].SetText("Formacion profesional..");
            PieNomina3[4, 2].SetText("1475.00");
            PieNomina3[4, 3].SetText("5.50");
            PieNomina3[4, 4].SetText("71.13");
            PieNomina3[5, 1].SetText("Fondo garantia salarial");
            PieNomina3[5, 2].SetText("1475.00");
            PieNomina3[5, 3].SetText("0.62");
            PieNomina3[5, 4].SetText("5.85");
            PieNomina3[6, 0].SetText("3. Cotizaci�n horas extraordinarias");
            PieNomina3[6, 1].SetText(".................");
            PieNomina3[6, 2].SetText(".................");
            PieNomina3[6, 3].SetText(".................");
            PieNomina3[6, 4].SetText(".................");

            document.Add(header);
            document.Add(DatosEmpresa.Table);
            document.Add(DatosTrabajador.Table);
            document.Add(OtrosDatos.Table);
            document.Add(CuerpoNomina.Table);
            document.Add(PieNomina1.Table);
            document.Add(SubPieNomina1);
            document.Add(PieNomina2.Table);
            document.Add(CabeceraPieNomina3.Table);
            document.Add(PieNomina3.Table);
            document.Close();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }
    }
    public BetterTable GeneraTabla(int numeroColumnas, int numeroFilas)
    {
        BetterTable b = new BetterTable(numeroColumnas, numeroFilas);
        return b;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////
}