using Persistencia;
using Bibliotec;
using Microsoft.EntityFrameworkCore;

namespace HolaMundoMAUI;

public partial class PaginaAdmin : ContentPage
{
    private string nombreUsuario;
    PresenciaContext presenciaContext = new PresenciaContext();
    DateTime dt = DateTime.Now;
    Usuarios us;
    Trabajador tr;
    Turnos gr;
    Zonas zn;
    Tareas ta;
<<<<<<< Updated upstream
    Boolean UsActivo,TrActivo,GrActivo,ZnActivo,TaActivo;
    int UsersActivos;

=======
    EquipoTrabajo Et;
    Calendario cal;
    Dia dia;
    Incidencia inci;
    Boolean TrActivo,GrActivo,ZnActivo,TaActivo,EtActivo,DiActivo, NmActivo,ProblemActivo,SolicitarVacaciones;
>>>>>>> Stashed changes

    public PaginaAdmin(string nombreUsuario)
    {
        UsActivo = false;
        TrActivo = false;
        GrActivo = false;
        ZnActivo = false;
        TaActivo = false;
<<<<<<< Updated upstream
=======
        EtActivo = false;
        NmActivo = false;
        DiActivo = false;
        ProblemActivo = false;
        SolicitarVacaciones = false;
>>>>>>> Stashed changes
        
        InitializeComponent();
        SetListViewUsuarios();
        SetListViewTrabajadores();
        SetListViewGruposTrabajo();
        SetListViewTareas();
        SetListViewZonas();
<<<<<<< Updated upstream

=======
        SetListViewEquiposTrabajo();
        CompruebaIncidencias();
        SetListViewEquiposTrabajo();
>>>>>>> Stashed changes
        this.nombreUsuario = nombreUsuario;
        Label_NameUser.Text = "Bienvenid@, " + Environment.NewLine + nombreUsuario;
    }
    public PaginaAdmin(string nombreUsuario,int interfaz)
    {
        UsActivo = false;
        TrActivo = false;
        GrActivo = false;
        ZnActivo = false;
<<<<<<< Updated upstream
        TaActivo=false;
=======
        TaActivo = false;
        EtActivo = false;
        NmActivo = false;
        DiActivo = false;
        ProblemActivo = false;
        SolicitarVacaciones = false;
>>>>>>> Stashed changes

        InitializeComponent();
        SetListViewUsuarios();
        SetListViewTrabajadores();
        SetListViewGruposTrabajo();
        SetListViewZonas();
        SetListViewTareas();
<<<<<<< Updated upstream
=======
        SetListViewEquiposTrabajo();
        CompruebaIncidencias();
        SetListViewEquiposTrabajo();
>>>>>>> Stashed changes
        this.nombreUsuario = nombreUsuario;
        Label_NameUser.Text = "Bienvenid@,"+ Environment.NewLine +""+ nombreUsuario;
        switch (interfaz)
        {
            case 1:
                ListViewUsers.IsVisible = true;
                ListViewUsers.IsEnabled = true;
                UsActivo = true;
                LabelTitulo.Text = "Tech Talent" + Environment.NewLine + "gestíon de usuarios";
                break;
            case 2:
                ListViewWorkers.IsVisible = true;
                ListViewWorkers.IsEnabled = true;
                TrActivo = true;
                LabelTitulo2.Text = "Tech Talent" + Environment.NewLine + "gestión de trabajadores";
                break;
            case 3:
                ListViewGroups.IsVisible = true;
                ListViewGroups.IsEnabled = true;
                GrActivo = true;
                LabelTitulo3.Text = "Tech Talent" + Environment.NewLine + "gestión de grupos de trabajo";
                break;
            case 4:
                ListViewZones.IsVisible = true;
                ListViewZones.IsEnabled = true;
                ZnActivo = true;
                LabelTitulo4.Text = "Tech Talent" + Environment.NewLine + "gestión de Zonas de trabajo";
                break;
            case 5:
                ListViewTasks.IsVisible = true;
                ListViewTasks.IsEnabled = true;
                TaActivo = true;
                LabelTitulo5.Text = "Tech Talent" + Environment.NewLine + "gestión de Zonas de tareas";
                break;
            case 8:
                ListViewIssues.IsVisible = true;
                ProblemActivo = true;
                LabelTitulo8.Text = "Tech Talent" + Environment.NewLine + "gestión de incidencias";
                break;
            case 9:
                ListViewPedirVacaciones.IsVisible = true;
                SolicitarVacaciones = true;
                //LabelTitulo9.Text = "Tech Talent" + Environment.NewLine + "gestión de incidencias";
                break;
        }
    }
    public void NuevoUsuario(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaUsuarios(nombreUsuario));
        presenciaContext.Logs.Add(new Log("Acceso", nombreUsuario + " Accede a 'Registrar usuario' - " + dt));
        presenciaContext.SaveChanges();
    }
    public void NuevoTrabajador(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaTrabajador(nombreUsuario,0));
        presenciaContext.Logs.Add(new Log("Acceso", nombreUsuario + " Accede a 'Registrar trabajador' - " + dt));
        presenciaContext.SaveChanges();
    }
    public void NuevoGrupoTrabajo(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaGrupoTrabajo(nombreUsuario));
        presenciaContext.Logs.Add(new Log("Acceso", nombreUsuario + " Accede a 'Registrar grupo de trabajo' - " + dt));
        presenciaContext.SaveChanges();
    }
    public async void VolverAlMainAdmin(object sender, EventArgs e)
    {
        await DisplayAlert("Alert", "Hasta luego, "+nombreUsuario, "OK");
        App.Current.MainPage = new NavigationPage(new MainPage());
        presenciaContext.Logs.Add(new Log("Logout", nombreUsuario + " ha cerrado sesion -"+dt ));
        presenciaContext.SaveChanges();

    }
    private void RegistrarNuevaTareaTrabajo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaTareaTrabajo(nombreUsuario));
        presenciaContext.Logs.Add(new Log("Acceso", nombreUsuario + " Accede a 'Añadir tareas de trabajo' - " + dt));
        presenciaContext.SaveChanges();
    }
    private void RegistrarNuevaZona_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaZona(nombreUsuario));
        presenciaContext.Logs.Add(new Log("Acceso", nombreUsuario + " Accede a 'Añadir zona de trabajo' - " + dt));
        presenciaContext.SaveChanges();
    }
    private void AnadeTareasGrupo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadeTareasGrupoTrabajo(nombreUsuario));
        presenciaContext.Logs.Add(new Log("Acceso", nombreUsuario + " Accede a 'Añadir Tareas a grupo' - " + dt));
        presenciaContext.SaveChanges();
    }
    private void AnadirZonaGrupo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadirZonaGrupoTrabajo(nombreUsuario));
        presenciaContext.Logs.Add(new Log("Acceso", nombreUsuario + " Accede a 'Añadir zona de trabajo' - " + dt));
        presenciaContext.SaveChanges();
    }
    private void BotonSinNada_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new TrabajadoresEnTurno(nombreUsuario));
        presenciaContext.Logs.Add(new Log("Acceso", nombreUsuario + " Accede a 'Trabajadores en turno' - " + dt));
        presenciaContext.SaveChanges();
    }
    public void SetListViewUsuarios()
    {
        PresenciaContext presenciaContext = new PresenciaContext();
        var users = presenciaContext.Usuarios.ToList();
        ListViewUsuarios.ItemsSource = users;
        if(users.Count > 0)
        ListViewUsuarios.SelectedItem = users[0];
    }
    public void SetListViewGruposTrabajo()
    {
        PresenciaContext presenciaContext = new PresenciaContext();
        var grupos = presenciaContext.Grupo_Trabajo.ToList();
        ListViewGrupos.ItemsSource = grupos;
        if(grupos.Count > 0)
        ListViewGrupos.SelectedItem = grupos[0];
    }
    public void SetListViewTrabajadores()
    {
        PresenciaContext presenciaContext = new PresenciaContext();
        var workers = presenciaContext.Trabajador.Include(x => x.grupo).Include(x => x.usuario).ToList();
        ListViewTrabajadores.ItemsSource = workers;
        if(workers.Count > 0)
        ListViewTrabajadores.SelectedItem = workers[0];
    }
    public void SetListViewZonas()
    {
        PresenciaContext presenciaContext = new PresenciaContext();
        var zones = presenciaContext.Zonas.ToList();
        ListViewZonas.ItemsSource = zones;
        if(zones.Count > 0)
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
    public void OnItemSelectedUsuarios(object sender, SelectedItemChangedEventArgs e)
    {
        Usuarios item = e.SelectedItem as Usuarios;
        us = item;
    }
<<<<<<< Updated upstream
    public void OnItemSelectedTrabajadores(object sender, SelectedItemChangedEventArgs e)
=======
    public void SetListViewIncidencias()
    {
        PresenciaContext presenciaContext = new PresenciaContext();
        var incidencias = presenciaContext.Incidencias.Where(x=>x.Justificada==false).ToList();
        ListViewIncidencias.ItemsSource = incidencias;
        ListViewIncidencias.SelectedItem = incidencias[0];
        if (incidencias.Count > 0)
        {
            ListViewIncidencias.SelectedItem = incidencias[0];
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////

    ///////// Lo que sucede cuando pulsamos en cada uno de los list view /////////////////////////
    public  void OnItemSelectedTrabajadores(object sender, SelectedItemChangedEventArgs e)
>>>>>>> Stashed changes
    {
        Trabajador item = e.SelectedItem as Trabajador;
        tr = item;
    }
    public void OnItemSelectedGruposTrabajo(object sender, SelectedItemChangedEventArgs e)
    {
        Turnos item = e.SelectedItem as Turnos;
        gr = item;
    }
    public void OnItemSelectedZonas(object sender, SelectedItemChangedEventArgs e)
    {
        Zonas item = e.SelectedItem as Zonas;
        zn = item;
    }
    public void OnItemSelectedTareas(object sender, SelectedItemChangedEventArgs e)
    {
        Tareas item = e.SelectedItem as Tareas;
        ta = item;
    }
<<<<<<< Updated upstream
    private void BtnUsuarios_Clicked(object sender, EventArgs e)
    {
        if (UsActivo == false)
        {
            ListViewUsers.IsVisible = true;
            ListViewUsers.IsEnabled = true;
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;

            BotonUser.BackgroundColor = Color.FromRgba("#ffa73b");
            BotonTrabajador.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTareas.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonZonas.BackgroundColor = Color.FromRgba("#b9b6bf");

            UsActivo = true;
            TrActivo = false;
            GrActivo = false;
            ZnActivo = false;
            TaActivo = false;

            LabelTitulo.Text="Tech Talent"+ Environment.NewLine+ "gestión de usuarios";
        }
        else
        {
            ListViewUsers.IsVisible = false;
            ListViewUsers.IsEnabled = false;
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;


            BotonUser.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTrabajador.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTareas.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonZonas.BackgroundColor = Color.FromRgba("#b9b6bf");


            UsActivo = false;
            TrActivo = false;
            GrActivo = false;
            ZnActivo = false;
            TaActivo = false;

            LabelTitulo.Text = "";
        }
    }
=======
    public void OnItemSelectedProblemas(object sender, SelectedItemChangedEventArgs e)
    {
        Incidencia item = e.SelectedItem as Incidencia;
        inci = item;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////

    /////////// Funciones Menu lateral ///////////////////////////////////////////////////////////
>>>>>>> Stashed changes
    private void BtnTrabajadores_Clicked(object sender, EventArgs e)
    {
        if (TrActivo == false)
        {
            ListViewWorkers.IsVisible = true;
            ListViewWorkers.IsEnabled = true;
            ListViewUsers.IsVisible = false;
            ListViewUsers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
<<<<<<< Updated upstream


            BotonUser.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTrabajador.BackgroundColor = Color.FromRgba("#ffa73b");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTareas.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonZonas.BackgroundColor = Color.FromRgba("#b9b6bf");

=======
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewCalendar.IsVisible = false;
            ListViewCalendar.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewNominas.IsVisible = false;
            ListViewPedirVacaciones.IsVisible = false;



            BotonTrabajador.BackgroundColor = Color.FromRgba("#84677D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonVacaciones.BackgroundColor = Color.FromRgba("#2B282D");
>>>>>>> Stashed changes

            TrActivo = true;
            UsActivo = false;
            GrActivo = false;
            ZnActivo = false;
            TaActivo = false;

            LabelTitulo.Text = "Tech Talent" + Environment.NewLine + "gestión de trabajadores";
        }
        else
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewUsers.IsVisible = false;
            ListViewUsers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
<<<<<<< Updated upstream

            BotonUser.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTrabajador.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTareas.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonZonas.BackgroundColor = Color.FromRgba("#b9b6bf");

=======
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewNominas.IsVisible = false;
            ListViewPedirVacaciones.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonVacaciones.BackgroundColor = Color.FromRgba("#2B282D");
>>>>>>> Stashed changes

            TrActivo = false;
            UsActivo = false;
            GrActivo = false;
            ZnActivo = false;
            TaActivo = false;

            LabelTitulo.Text = "";
        }
    }
    private void BtnGruposTrabajo_Clicked(object sender, EventArgs e)
    {
        if (GrActivo == false)
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewUsers.IsVisible = false;
            ListViewUsers.IsEnabled = false;
            ListViewGroups.IsVisible = true;
            ListViewGroups.IsEnabled = true;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
<<<<<<< Updated upstream

            BotonUser.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTrabajador.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#ffa73b");
            BotonTareas.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonZonas.BackgroundColor = Color.FromRgba("#b9b6bf");

=======
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewCalendar.IsVisible = false;
            ListViewCalendar.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewNominas.IsVisible = false;
            ListViewPedirVacaciones.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#84677D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonVacaciones.BackgroundColor = Color.FromRgba("#2B282D");
>>>>>>> Stashed changes

            GrActivo = true;
            UsActivo = false;
            TrActivo = false;
            TaActivo = false;
            ZnActivo = false;

            LabelTitulo.Text = "Tech Talent" + Environment.NewLine + "gestión de trabajadores";
        }
        else
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewUsers.IsVisible = false;
            ListViewUsers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
<<<<<<< Updated upstream

            BotonUser.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTrabajador.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTareas.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonZonas.BackgroundColor = Color.FromRgba("#b9b6bf");

=======
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewNominas.IsVisible = false;
            ListViewPedirVacaciones.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonVacaciones.BackgroundColor = Color.FromRgba("#2B282D");
>>>>>>> Stashed changes

            GrActivo = false;
            TrActivo = false;
            UsActivo = false;
            TaActivo = false;
            ZnActivo = false;

            LabelTitulo.Text = "";
        }
    }
    private void BtnZonas_Clicked(object sender, EventArgs e)
    {
        if (ZnActivo == false)
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewUsers.IsVisible = false;
            ListViewUsers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = true;
            ListViewZones.IsEnabled = true;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
<<<<<<< Updated upstream

            BotonUser.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTrabajador.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTareas.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonZonas.BackgroundColor = Color.FromRgba("#ffa73b");

=======
            ListViewTeams.IsVisible = true;
            ListViewTeams.IsEnabled = true;
            ListViewCalendar.IsVisible = false;
            ListViewCalendar.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewNominas.IsVisible = false;
            ListViewPedirVacaciones.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#84677D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonVacaciones.BackgroundColor = Color.FromRgba("#2B282D");
>>>>>>> Stashed changes

            ZnActivo = true;
            GrActivo = false;
            UsActivo = false;
            TrActivo = false;
            TaActivo = false;

            LabelTitulo.Text = "Tech Talent" + Environment.NewLine + "gestión de zonas de trabajo";
        }
        else
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewUsers.IsVisible = false;
            ListViewUsers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
<<<<<<< Updated upstream

            BotonUser.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTrabajador.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTareas.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonZonas.BackgroundColor = Color.FromRgba("#b9b6bf");
=======
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewNominas.IsVisible = false;
            ListViewPedirVacaciones.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonVacaciones.BackgroundColor = Color.FromRgba("#2B282D");
>>>>>>> Stashed changes

            ZnActivo = false;
            GrActivo = false;
            TrActivo = false;
            UsActivo = false;
            TaActivo = false;

            LabelTitulo.Text = "";
        }
<<<<<<< Updated upstream
    }
    private void BtnTareas_Clicked(object sender, EventArgs e)
=======
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
                ListViewNominas.IsVisible = false;
                ListViewPedirVacaciones.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
                BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
                BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
                BotonZonas.BackgroundColor = Color.FromRgba("#84677D");
                BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
                BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");
                BotonVacaciones.BackgroundColor = Color.FromRgba("#2B282D");

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
                ListViewNominas.IsVisible = false;
                ListViewPedirVacaciones.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
                BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
                BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
                BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
                BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
                BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");
                BotonVacaciones.BackgroundColor = Color.FromRgba("#2B282D");

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
                ListViewNominas.IsVisible = false;
                ListViewPedirVacaciones.IsVisible = false;


                BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
                BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
                BotonTareas.BackgroundColor = Color.FromRgba("#84677D");
                BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
                BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
                BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");
                BotonVacaciones.BackgroundColor = Color.FromRgba("#2B282D");

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
                ListViewNominas.IsVisible = false;
                ListViewPedirVacaciones.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
                BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
                BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
                BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
                BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
                BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");
                BotonVacaciones.BackgroundColor = Color.FromRgba("#2B282D");

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
>>>>>>> Stashed changes
    {
        if (TaActivo == false)
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewUsers.IsVisible = false;
            ListViewUsers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
<<<<<<< Updated upstream
            ListViewTasks.IsVisible = true;
            ListViewTasks.IsEnabled = true;

            BotonUser.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTrabajador.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTareas.BackgroundColor = Color.FromRgba("#ffa73b");
            BotonZonas.BackgroundColor = Color.FromRgba("#b9b6bf");
=======
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewCalendar.IsVisible = false;
            ListViewCalendar.IsEnabled = false;
            ListViewNominas.IsVisible = true;
            ListViewNominas.IsVisible = false;
            ListViewPedirVacaciones.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#84677D");
            BotonVacaciones.BackgroundColor = Color.FromRgba("#2B282D");
>>>>>>> Stashed changes

            ZnActivo = false;
            GrActivo = false;
            UsActivo = false;
            TrActivo = false;
            TaActivo = true;

            LabelTitulo.Text = "Tech Talent" + Environment.NewLine + "gestión de zonas de trabajo";
        }
        else
        {
            ListViewWorkers.IsVisible = false;
            ListViewWorkers.IsEnabled = false;
            ListViewUsers.IsVisible = false;
            ListViewUsers.IsEnabled = false;
            ListViewGroups.IsVisible = false;
            ListViewGroups.IsEnabled = false;
            ListViewZones.IsVisible = false;
            ListViewZones.IsEnabled = false;
            ListViewTasks.IsVisible = false;
            ListViewTasks.IsEnabled = false;
<<<<<<< Updated upstream

            BotonUser.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTrabajador.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonTareas.BackgroundColor = Color.FromRgba("#b9b6bf");
            BotonZonas.BackgroundColor = Color.FromRgba("#b9b6bf");
=======
            ListViewTeams.IsVisible = false;
            ListViewTeams.IsEnabled = false;
            ListViewNominas.IsVisible = false;
            ListViewPedirVacaciones.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonVacaciones.BackgroundColor = Color.FromRgba("#2B282D");
>>>>>>> Stashed changes

            TaActivo = false;
            ZnActivo = false;
            GrActivo = false;
            TrActivo = false;
<<<<<<< Updated upstream
            UsActivo = false;
=======
            EtActivo = false;
            NmActivo = false;
            CompruebaIncidencias();
        }
    }
    private void BtnProblemas_Clicked(object sender, EventArgs e)
    {
        if(ProblemActivo == false)
        {
            ListViewIssues.IsVisible = true;
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
            ListViewPedirVacaciones.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#84677D");
            BotonVacaciones.BackgroundColor = Color.FromRgba("#2B282D");

            ZnActivo = false;
            GrActivo = false;
            TrActivo = false;
            TaActivo = false;
            EtActivo = false;
            NmActivo = false;
            ProblemActivo = true;
        }
        else
        {
            ListViewIssues.IsVisible = false;
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
            ListViewPedirVacaciones.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#84677D"); ;
            BotonVacaciones.BackgroundColor = Color.FromRgba("#2B282D");

            ZnActivo = false;
            GrActivo = false;
            TrActivo = false;
            TaActivo = false;
            EtActivo = false;
            NmActivo = false;
            ProblemActivo = false;
        }
    }
    private void BotonNominas_Clicked(object sender, EventArgs e)
    {
        if (ProblemActivo == false)
        {
            ListViewIssues.IsVisible = true;
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
            ListViewPedirVacaciones.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#84677D");
            BotonVacaciones.BackgroundColor = Color.FromRgba("#2B282D");


            ZnActivo = false;
            GrActivo = false;
            TrActivo = false;
            TaActivo = false;
            EtActivo = false;
            NmActivo = false;
            ProblemActivo = true;
            SolicitarVacaciones = false;
        }
        else
        {
            ListViewIssues.IsVisible = false;
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
            ListViewPedirVacaciones.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonVacaciones.BackgroundColor = Color.FromRgba("#2B282D");

            ZnActivo = false;
            GrActivo = false;
            TrActivo = false;
            TaActivo = false;
            EtActivo = false;
            NmActivo = false;
            ProblemActivo = false;
            SolicitarVacaciones = false;
        }
    }
    private void BtnSolicitudVacaciones_Clicked(object sender, EventArgs e)
    {
        if (SolicitarVacaciones == false)
        {
            ListViewIssues.IsVisible = false;
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
            ListViewPedirVacaciones.IsVisible = true;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonVacaciones.BackgroundColor = Color.FromRgba("#84677D");

            ZnActivo = false;
            GrActivo = false;
            TrActivo = false;
            TaActivo = false;
            EtActivo = false;
            NmActivo = false;
            ProblemActivo = false;
            SolicitarVacaciones = true;
        }
        else
        {
            ListViewIssues.IsVisible = false;
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
            ListViewPedirVacaciones.IsVisible = false;


            BotonTrabajador.BackgroundColor = Color.FromRgba("#2B282D");
            BotonGrupoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonTareas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonZonas.BackgroundColor = Color.FromRgba("#2B282D");
            BotonEquipoTrabajo.BackgroundColor = Color.FromRgba("#2B282D");
            BotonNominas.BackgroundColor = Color.FromRgba("#2B282D"); 
            BotonVacaciones.BackgroundColor = Color.FromRgba("#2B282D");

            ZnActivo = false;
            GrActivo = false;
            TrActivo = false;
            TaActivo = false;
            EtActivo = false;
            NmActivo = false;
            ProblemActivo = false;
            SolicitarVacaciones = false;
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////

    /////// Metodos de las funciones de añadir ////////////////////////////////////////////////////
    private void BotonAnadeZona_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaZona(nombreUsuario, "", 0));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'Añadir zonas de trabajo " + "-" + dt));
    }
    private void BtnAnadeTarea_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaTareaTrabajo(nombreUsuario));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'Añadir tareas de trabajo" + " - " + dt));
    }
    private void BtnAnadeDias_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadeDiaCalendario(nombreUsuario, cal, 0, dia));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'Añadir dias al calendario" + " - " + dt));

    }
    private void BtnAnadeTareaGrupoTrabajo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadeTareasGrupoTrabajo(nombreUsuario));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'Añadir tarea a grupo de trabajo:'" + ta.NombreTarea + " - " + dt));
    }
    private void AddZonasGrupos_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadirZonaGrupoTrabajo(nombreUsuario));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'Añadir zonasa grupo de trabajo:'" + zn.Nombre + " - " + dt));
    }
    private void BtnAnadeEquipos_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaGrupoTrabajo(nombreUsuario, "", 0));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " ha accedido a \"Registrar nuevo equipo de trabajo\" - " + dt));
    }
    private void BtnAnadeTrabajadorAEquipo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadeTrabajadorEquipoTrabajo(nombreUsuario));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'Añadir trabajador a un grupo de trabajo" + " - " + dt));

    }
    private void AddGruposEquipoTrabajo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadirTurnoEquipoTrabajo(nombreUsuario, gr.Nombre, 0));
        OperacionesDBContext.InsertaLog(new Log("Acceso", nombreUsuario + " Accede a 'Añadir turno a equipo de trabajo' - " + dt));
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
>>>>>>> Stashed changes

            LabelTitulo.Text = "";
        }
    }
    private async void BotonBorrarUsuarios_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Question?", "¿Estas seguro de eliminar el trabajador \""+nombreUsuario+"\"?", "Si", "No");
        var IdUser = us.IdUser;
        
        
        if (answer == true)
        {
            bool inserta = OperacionesDBContext.borraUsuario(IdUser);
            presenciaContext.Logs.Add(new Log("Eliminar", nombreUsuario + " ha eliminado tarea " + us.Username + " - " + dt));
            presenciaContext.SaveChanges();
            if (inserta == true)
            {
                App.Current.MainPage = new NavigationPage(new PaginaAdmin(nombreUsuario,1));
            }
            else
            {
                await DisplayAlert("Alert", "Debe seleccionar un usuario", "OK");
            }
        }
    }
    private void BotonEditarUsuarios_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaUsuarios(us.Username,1));
    }
    private async void BotonBorrarTrabajadores_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Question?", "¿Estas seguro de borrar el trabajador \"" + tr.nombre + "\"?", "Si", "No");
        if (tr is not null && answer == true)
        {
            var NumeroTarjeta = tr.numero_tarjeta;
            OperacionesDBContext.borraTrabajador(NumeroTarjeta);
            presenciaContext.Logs.Add(new Log("Eliminar", nombreUsuario + " ha eliminado trabajador \"" + tr.nombre + "\" - " + dt));
            presenciaContext.SaveChanges();
            App.Current.MainPage = new NavigationPage(new PaginaAdmin(nombreUsuario,2));
        }
        else
        {
            await DisplayAlert("Alert", "Error!", "OK");
        }
    }
    private async void BotonBorrarGruposTrabajo_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Question?", "¿Estas seguro de borrar el grupo \"" + gr.Turno + "\"?", "Si", "No");
        if (answer == true)
        {
            OperacionesDBContext.borraGrupoTrabajo(gr.IdGrupo);
            presenciaContext.Logs.Add(new Log("Eliminar", nombreUsuario + " ha eliminado grupo de trabajo " + gr.Turno + " - " + dt));
            presenciaContext.SaveChanges();
            App.Current.MainPage = new NavigationPage(new PaginaAdmin(nombreUsuario,3));
        }
    }
    private void BotonEditarZonas_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaZona(nombreUsuario,zn.Nombre,1));
    }
    private async void BotonBorrarZonas_Clicked(object sender, EventArgs e)
    {
        if (zn is not null)
        {
            bool answer = await DisplayAlert("Question?", "¿Desea Borrar la zona \"" + zn.Nombre + "\"?", "Si", "No");
            if (answer == true)
            {
                await DisplayAlert("Alert", "Se ha borrado correctamente " + zn.Nombre, "OK");
                presenciaContext.Logs.Add(new Log("Eliminar", nombreUsuario + " ha eliminar " + zn.Nombre + " - " + dt));
                presenciaContext.SaveChanges();
                OperacionesDBContext.BorraZona(zn.IdZona);
                App.Current.MainPage = new NavigationPage(new PaginaAdmin(nombreUsuario,4));
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
    private void BotonAnadeZona_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaZona(nombreUsuario,"",0));
        presenciaContext.Logs.Add(new Log("Acceso", nombreUsuario + " Accede a 'Añadir zonas de trabajo:'" + zn.Nombre + " - " + dt));
        presenciaContext.SaveChanges();
    }
    private void BtnAnadeTarea_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaTareaTrabajo(nombreUsuario));
        presenciaContext.Logs.Add(new Log("Acceso", nombreUsuario + " Accede a 'Añadir tareas de trabajo:'" + ta.NombreTarea + " - " + dt));
        presenciaContext.SaveChanges();
    }
    private void BotonCopiar_Clicked(object sender, EventArgs e)
    {
        if (us.Password != "")
            Clipboard.SetTextAsync(us.Password);
            presenciaContext.Logs.Add(new Log("Password", nombreUsuario + " ha copiado la contraseña del usuario:'" + tr.nombre + " - " + dt));
            presenciaContext.SaveChanges();
    }
    private void BtnAnadeTareaGrupoTrabajo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadeTareasGrupoTrabajo(nombreUsuario));
        presenciaContext.Logs.Add(new Log("Acceso", nombreUsuario + " Accede a 'Añadir tarea a grupo de trabajo:'" + ta.NombreTarea + " - " + dt));
        presenciaContext.SaveChanges();
    }
    private void AddZonasGrupos_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AnadirZonaGrupoTrabajo(nombreUsuario));
        presenciaContext.Logs.Add(new Log("Acceso", nombreUsuario + " Accede a 'Añadir zonasa grupo de trabajo:'" + zn.Nombre + " - " + dt));
        presenciaContext.SaveChanges();
    }
    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        BotonCerrarSession.BackgroundColor = Color.FromRgba("#b9b6bf");
        bool answer = await DisplayAlert("Question?","¿Deseas cerrar sesión?","Si","No");
        if(answer == true)
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
    private async void BotonBorrarTareas_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Question?", "¿Estas seguro de borrar la tarea \"" + ta.NombreTarea + "\"?", "Si", "No");
        if (answer == true)
        {
            if (ta is not null)
            {
                presenciaContext.Tareas.Remove(ta);
                presenciaContext.Logs.Add(new Log("Eliminar", nombreUsuario + " ha eliminado la tarea " + ta.NombreTarea + " - " + dt));
                presenciaContext.SaveChanges();
                App.Current.MainPage = new NavigationPage(new PaginaAdmin(nombreUsuario, 5));
            }
            else
            {
                await DisplayAlert("Alert", "Error!", "OK");
            }
        }
    }
<<<<<<< Updated upstream
    private void BotonEditarTareas_Clicked(object sender, EventArgs e)
=======


    ///////////////////////////////////////////////////////////////////////////////////////////////

    /////////// Otras funciones //////////////////////////////////////////////////////////////////
    private async void BotonCalendario_Clicked(object sender, EventArgs e)
    {
        ListViewCalendar.IsVisible = true;
        ListViewCalendar.IsEnabled = true;
        ListViewWorkers.IsVisible = false;
        ListViewWorkers.IsEnabled = false;

        var ExisteCalendario = p.Calendario.Where(x => x.Trabajador == tr).Include(x=>x.Trabajador).Include(x=>x.DiasDelCalendario).FirstOrDefault();
        if(ExisteCalendario is not null)
        {
            var ListaDias = ExisteCalendario.DiasDelCalendario.ToList();
            ListViewCalendario.ItemsSource = ListaDias;
            if(ListaDias.Count > 0)
            ListViewCalendario.SelectedItem = ListaDias[0];
        }
        else
        {
            await DisplayAlert("Alert", "El trabajador no dispone de calendario, se procede a crearlo", "Vale");
            var trabajador = p.Trabajador.Where(x => x.numero_tarjeta == tr.numero_tarjeta).FirstOrDefault();
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
        bool answer = await DisplayAlert("Logout","¿Deseas cerrar sesión?","Si","No");
        if(answer == true)
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
    private async void CompruebaDias(Trabajador tr)
>>>>>>> Stashed changes
    {
        App.Current.MainPage = new NavigationPage(new AltaTareaTrabajo(nombreUsuario,ta.NombreTarea,1));
        presenciaContext.Logs.Add(new Log("Acceso", nombreUsuario + " Accede a 'Editar tarea de trabajo '+" + ta.NombreTarea + " - " + dt));
        presenciaContext.SaveChanges();
    }
    private void BotonEditarGruposTrabajo_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new AltaGrupoTrabajo(nombreUsuario,gr.Turno,1));
        presenciaContext.Logs.Add(new Log("Acceso", nombreUsuario + " Accede a 'Editar grupo de trabajo' "+gr.Turno+" - " + dt));
        presenciaContext.SaveChanges();
    }
    private void BotonEditarTrabajadores_Clicked(object sender, EventArgs e)
    {
<<<<<<< Updated upstream
        App.Current.MainPage = new NavigationPage(new AltaTrabajador(tr.nombre, 1));
        presenciaContext.Logs.Add(new Log("Acceso", nombreUsuario + " Accede a 'Editar trabajador '+" + tr.nombre + " - " + dt));
        presenciaContext.SaveChanges();
    }
=======
        try
        {
            var ListaIncidencias = p.Incidencias.Where(x=>x.Justificada==false).Include(x=>x.Trabajador).ToList();
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
        }catch(NullReferenceException ex)
        {
            Debug.WriteLine(ex.ToString());
        }
    }
    private void BotonAceptarIncidencia_Clicked(object sender, EventArgs e)
    {
        Incidencia i = inci;
        i.Justificada = true;
        p.Update(i);
        p.SaveChanges();
        App.Current.MainPage = new NavigationPage(new PaginaAdmin(nombreUsuario,8));
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
>>>>>>> Stashed changes
}