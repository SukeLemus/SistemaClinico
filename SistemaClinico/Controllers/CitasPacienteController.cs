using SistemaClinico.Models;
using SistemaClinico.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using Twilio;
using Twilio.AspNet.Common;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using Twilio.Types;


namespace SistemaClinico.Controllers
{
    public class CitasPacienteController : TwilioController
    {
        //GET TODO LOS PACIENTES
        public static List<RegistroPacienteUsuario> TodosUsuarios()
        {
            List<RegistroPacienteUsuario> listaS = new List<RegistroPacienteUsuario>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient med = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = med.lista_paciente();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_PACIENTE"].ToString());
                string nombre = dr["NOMBRE"].ToString();
                string apellido = dr["APELLIDO"].ToString();
                string dui = dr["DUI"].ToString();
                string nit = dr["NIT"].ToString();
                string genero = dr["GENERO"].ToString();
                string fecha = dr["FECHA_NACIMIENTO"].ToString();
                string tipo_sangre = dr["TIPO_SANGRE"].ToString();
                string telefono = dr["TELEFONO"].ToString();
                string correo = dr["CORREO"].ToString();
                int id_direccion = int.Parse(dr["ID_DIRECCION"].ToString());
                string direccion_com = dr["DIRECCION_COM"].ToString();
                int id_rol = int.Parse(dr["ID_ROL"].ToString());
                string estado = dr["ESTADO"].ToString();
                string usuario = dr["USUARIO"].ToString();
                string password = dr["PASSWORD"].ToString();
                RegistroPacienteUsuario US = new RegistroPacienteUsuario();
                US.id = id;
                US.NOMBRE = nombre;
                US.APELLIDO = apellido;
                US.DUI = dui;
                US.NIT = nit;
                US.GENERO = genero;
                US.FECHA_NACIMIENTO = fecha;
                US.TIPO_SANGRE = tipo_sangre;
                US.TELEFONO = telefono;
                US.CORREO = correo;
                US.ID_DIRECCION = id_direccion;
                US.DIRECCION_COM = direccion_com;
                US.ID_ROL = id_rol;
                US.ESTADO = estado;
                US.USUARIO = usuario;
                US.PASSWORD = password;
                listaS.Add(US);
            }
            return listaS;

        }


        ////GET TODO LOS PACIENTES segun cita
        public static List<ListadoCitasPaciente> TodasLasCitasSegunpacienteFinalizada()
        {
            List<ListadoCitasPaciente> listaS = new List<ListadoCitasPaciente>();
        SistemaClinicoSoapWS.ClinicaWebServiceSoapClient citas = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
        DataSet ds = citas.lista_citas_comp_finalizada();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_CITAS"].ToString());
        int idpaciente = int.Parse(dr["ID_PACIENTE"].ToString());
        string nombrepaciente = dr["NOMBRE"].ToString();
        string apellidopaciente = dr["APELLIDO"].ToString();
        string telefono = dr["TELEFONO"].ToString();
        string correo = dr["CORREO"].ToString();
        string fecha = dr["FECHA"].ToString();
        string hora = dr["HORA"].ToString();
        string turno = dr["TURNO"].ToString();
        string tipocita = dr["TIPO_CITA"].ToString();
        int iddepa = int.Parse(dr["ID_DEPARTAMENTO"].ToString());
        string nombredepa = dr["NOMBRE_DEPARTAMENTO"].ToString();
        string descripcion = dr["DESCRIPCION"].ToString();
        string estado = dr["ESTADO"].ToString();
        ListadoCitasPaciente US = new ListadoCitasPaciente();
        US.ID = id;
                US.ID_PACIENTE = idpaciente;
                US.NOMBRE = nombrepaciente;
                US.APELLIDO = apellidopaciente;
                US.TELEFONO = telefono;
                US.CORREO = correo;
                US.FECHA = fecha.Remove(10);
                US.HORA = hora;
                US.TURNO = turno;
                US.TIPO_CITA = tipocita;
                US.ID_DEPARTAMENTO = iddepa;
                US.NOMBRE_DEPARTAMENTO = nombredepa;
                US.DESCRIPCION = descripcion;
                US.ESTADO = estado;
                listaS.Add(US);
            }
            return listaS;

        }

        public static List<ListadoCitasPaciente> TodasLasCitasSegunpacienteID(int idpa)
        {
            List<ListadoCitasPaciente> listaS = new List<ListadoCitasPaciente>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient citas = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            DataSet ds = citas.lista_citas_comp_segun_id(idpa);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_CITAS"].ToString());
                int idpaciente = int.Parse(dr["ID_PACIENTE"].ToString());
                string nombrepaciente = dr["NOMBRE"].ToString();
                string apellidopaciente = dr["APELLIDO"].ToString();
                string telefono = dr["TELEFONO"].ToString();
                string correo = dr["CORREO"].ToString();
                string fecha = dr["FECHA"].ToString();
                string hora = dr["HORA"].ToString();
                string turno = dr["TURNO"].ToString();
                string tipocita = dr["TIPO_CITA"].ToString();
                int iddepa = int.Parse(dr["ID_DEPARTAMENTO"].ToString());
                string nombredepa = dr["NOMBRE_DEPARTAMENTO"].ToString();
                string descripcion = dr["DESCRIPCION"].ToString();
                string estado = dr["ESTADO"].ToString();
                ListadoCitasPaciente US = new ListadoCitasPaciente();
                US.ID = id;
                US.ID_PACIENTE = idpaciente;
                US.NOMBRE = nombrepaciente;
                US.APELLIDO = apellidopaciente;
                US.TELEFONO = telefono;
                US.CORREO = correo;
                US.FECHA = fecha.Remove(10);
                US.HORA = hora;
                US.TURNO = turno;
                US.TIPO_CITA = tipocita;
                US.ID_DEPARTAMENTO = iddepa;
                US.NOMBRE_DEPARTAMENTO = nombredepa;
                US.DESCRIPCION = descripcion;
                US.ESTADO = estado;
                listaS.Add(US);
            }
            return listaS;

        }
        public static List<ListadoCitasPaciente> TodasLasCitasSegunCitaID(int idcita)
        {
            List<ListadoCitasPaciente> listaS = new List<ListadoCitasPaciente>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient citas = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            DataSet ds = citas.lista_citas_comp_id(idcita);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_CITAS"].ToString());
                int idpaciente = int.Parse(dr["ID_PACIENTE"].ToString());
                string nombrepaciente = dr["NOMBRE"].ToString();
                string apellidopaciente = dr["APELLIDO"].ToString();
                string telefono = dr["TELEFONO"].ToString();
                string correo = dr["CORREO"].ToString();
                string fecha = dr["FECHA"].ToString();
                string hora = dr["HORA"].ToString();
                string turno = dr["TURNO"].ToString();
                string tipocita = dr["TIPO_CITA"].ToString();
                int iddepa = int.Parse(dr["ID_DEPARTAMENTO"].ToString());
                string nombredepa = dr["NOMBRE_DEPARTAMENTO"].ToString();
                string descripcion = dr["DESCRIPCION"].ToString();
                string estado = dr["ESTADO"].ToString();
                ListadoCitasPaciente US = new ListadoCitasPaciente();
                US.ID = id;
                US.ID_PACIENTE = idpaciente;
                US.NOMBRE = nombrepaciente;
                US.APELLIDO = apellidopaciente;
                US.TELEFONO = telefono;
                US.CORREO = correo;
                US.FECHA = fecha.Remove(10);
                US.HORA = hora;
                US.TURNO = turno;
                US.TIPO_CITA = tipocita;
                US.ID_DEPARTAMENTO = iddepa;
                US.NOMBRE_DEPARTAMENTO = nombredepa;
                US.DESCRIPCION = descripcion;
                US.ESTADO = estado;
                listaS.Add(US);
            }
            return listaS;

        }

        public static List<ListadoCitasPaciente> TodasLasCitasSegunpacienteAceptada()
        {
            List<ListadoCitasPaciente> listaS = new List<ListadoCitasPaciente>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient citas = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = citas.lista_citas_comp_aceptada();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_CITAS"].ToString());
                int idpaciente = int.Parse(dr["ID_PACIENTE"].ToString());
                string nombrepaciente = dr["NOMBRE"].ToString();
                string apellidopaciente = dr["APELLIDO"].ToString();
                string telefono = dr["TELEFONO"].ToString();
                string correo = dr["CORREO"].ToString();
                string fecha = dr["FECHA"].ToString();
                string hora = dr["HORA"].ToString();
                string turno = dr["TURNO"].ToString();
                string tipocita = dr["TIPO_CITA"].ToString();
                int iddepa = int.Parse(dr["ID_DEPARTAMENTO"].ToString());
                string nombredepa = dr["NOMBRE_DEPARTAMENTO"].ToString();
                string descripcion = dr["DESCRIPCION"].ToString();
                string estado = dr["ESTADO"].ToString();
                ListadoCitasPaciente US = new ListadoCitasPaciente();
                US.ID = id;
                US.ID_PACIENTE = idpaciente;
                US.NOMBRE = nombrepaciente;
                US.APELLIDO = apellidopaciente;
                US.TELEFONO = telefono;
                US.CORREO = correo;
                US.FECHA = fecha.Remove(10);
                US.HORA = hora;
                US.TURNO = turno;
                US.TIPO_CITA = tipocita;
                US.ID_DEPARTAMENTO = iddepa;
                US.NOMBRE_DEPARTAMENTO = nombredepa;
                US.DESCRIPCION = descripcion;
                US.ESTADO = estado;
                listaS.Add(US);
            }
            return listaS;

        }
        
        public static List<ListadoCitasPaciente> TodasLasCitasSegunpaciente()
        {string nombrepaciente = "";
            List<ListadoCitasPaciente> listaS = new List<ListadoCitasPaciente>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient citas = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = citas.lista_citas_comp();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_CITAS"].ToString());
                int idpaciente = int.Parse(dr["ID_PACIENTE"].ToString());
                nombrepaciente = dr["NOMBRE"].ToString();
                string apellidopaciente = dr["APELLIDO"].ToString();
                string telefono = dr["TELEFONO"].ToString();
                string correo = dr["CORREO"].ToString();
                string fecha = dr["FECHA"].ToString();
                string hora = dr["HORA"].ToString();
                string turno = dr["TURNO"].ToString();
                string tipocita = dr["TIPO_CITA"].ToString();
                int iddepa = int.Parse(dr["ID_DEPARTAMENTO"].ToString());
                string nombredepa = dr["NOMBRE_DEPARTAMENTO"].ToString();
                string descripcion = dr["DESCRIPCION"].ToString();
                string estado = dr["ESTADO"].ToString();
                ListadoCitasPaciente US = new ListadoCitasPaciente();
                US.ID = id;
                US.ID_PACIENTE = idpaciente;
                US.NOMBRE = nombrepaciente;
                US.APELLIDO = apellidopaciente;
                US.TELEFONO = telefono;
                US.CORREO = correo;
                US.FECHA = fecha.Remove(10);
                US.HORA = hora;
                US.TURNO = turno;
                US.TIPO_CITA = tipocita;
                US.ID_DEPARTAMENTO = iddepa;
                US.NOMBRE_DEPARTAMENTO = nombredepa;
                US.DESCRIPCION = descripcion;
                US.ESTADO = estado;
                listaS.Add(US);
            }
            return listaS;

        }

        //TODAS LAS CITAS
        public static List<CitasPaciente> TodasLasCitas()
        {
            List<CitasPaciente> listaS = new List<CitasPaciente>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient citas = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = citas.ListaCitas();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_CITAS"].ToString());
                int idpaciente = int.Parse(dr["ID_PACIENTE"].ToString());
                string nombre = dr["NOMBRE"].ToString();
                string apellido = dr["APELLIDO"].ToString();
                string telefono = dr["TELEFONO"].ToString();
                string fecha = dr["FECHA"].ToString();
                string hora = dr["HORA"].ToString();
                string turno = dr["TURNO"].ToString();
                string tipocita = dr["TIPO_CITA"].ToString();
                int iddepa = int.Parse(dr["ID_DEPARTAMENTO"].ToString());
                string descripcion = dr["DESCRIPCION"].ToString();
                string estado = dr["ESTADO"].ToString();
                CitasPaciente US = new CitasPaciente();
                US.ID = id;
                US.ID_PACIENTE = idpaciente;
                US.NOMBRE = nombre;
                US.APELLIDO = apellido;
                US.TELEFONO = telefono;
                US.FECHA = fecha;
                US.HORA = hora;
                US.TURNO = turno;
                US.TIPO_CITA = tipocita;
                US.ID_DEPARTAMENTO = iddepa;
                US.DESCRIPCION = descripcion;
                US.ESTADO = estado;
                listaS.Add(US);
            }
            return listaS;

        }


        // GET: CitasPaciente
        public ActionResult Index(int? i, string BuscarNombre)
        {
            //List<ListadoCitasPaciente> listaS = new List<ListadoCitasPaciente>();
            //if (Session["Rol"] != null && Session["Rol"].Equals(1))
            //{
            //    //Mostrar citas



            //    listaS = TodasLasCitasSegunpaciente();
            //}
            if (Session["Rol"] != null && Session["Rol"].Equals(1))
            {
                int idpa = int.Parse(Session["id"].ToString());

                var citas = from e in TodasLasCitasSegunpacienteID(idpa)
                                //orderby e.nombre
                            select e;
                if (!String.IsNullOrEmpty(BuscarNombre))
                {
                    citas = citas.Where(c => c.NOMBRE.ToLower().Contains(BuscarNombre.ToLower()));
                }
                return View(citas.ToPagedList(i ?? 1, 1));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // GET: lista CITAS SEGUN PACIENTE
        public ActionResult ListadoCitasPaciente(int? i, string BuscarNombre)
        {

            if (Session["Rol"] != null && Session["Rol"].Equals(2))
            {
                var citas = from e in TodasLasCitasSegunpaciente()
                            select e;



                if (!String.IsNullOrEmpty(BuscarNombre))
                {
                    citas = citas.Where(c => c.NOMBRE.ToLower().Equals(BuscarNombre.ToLower()));
                }


                return View(citas.ToPagedList(i ?? 1, 3));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
            //return View();
        }

        public ActionResult ListadoCitasPacienteAceptada(int? i, string BuscarNombre)
        {

            if (Session["Rol"] != null && Session["Rol"].Equals(2))
            {
                var citas = from e in TodasLasCitasSegunpacienteAceptada()
                            select e;



                if (!String.IsNullOrEmpty(BuscarNombre))
                {
                    citas = citas.Where(c => c.NOMBRE.ToLower().Equals(BuscarNombre.ToLower()));
                }


                return View(citas.ToPagedList(i ?? 1, 3));
            }
            else if (Session["Rol"] != null && Session["Rol"].Equals(3))
            {
                var citas = from e in TodasLasCitasSegunpacienteAceptada()
                            select e;



                if (!String.IsNullOrEmpty(BuscarNombre))
                {
                    citas = citas.Where(c => c.NOMBRE.ToLower().Equals(BuscarNombre.ToLower()));
                }


                return View(citas.ToPagedList(i ?? 1, 3));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
            //return View();
        }
        public ActionResult AgendaCitaDoctor(int? i, string BuscarNombre)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(3))
            {
                var citas = from e in TodasLasCitasSegunpacienteAceptada()
                            select e;



                if (!String.IsNullOrEmpty(BuscarNombre))
                {
                    citas = citas.Where(c => c.NOMBRE.ToLower().Equals(BuscarNombre.ToLower()));
                }


                return View(citas.ToPagedList(i ?? 1, 3));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
            //return View();
        }
        public ActionResult ListadoCitasPacienteHistorial(int? i, string BuscarNombre)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(2))
            {
                var citas = from e in TodasLasCitasSegunpacienteFinalizada()
                            select e;



                if (!String.IsNullOrEmpty(BuscarNombre))
                {
                    citas = citas.Where(c => c.NOMBRE.ToLower().Equals(BuscarNombre.ToLower()));
                }


                return View(citas.ToPagedList(i ?? 1, 3));
            }
            else if (Session["Rol"] != null && Session["Rol"].Equals(3))
            {
                var citas = from e in TodasLasCitasSegunpacienteFinalizada()
                            select e;



                if (!String.IsNullOrEmpty(BuscarNombre))
                {
                    citas = citas.Where(c => c.NOMBRE.ToLower().Equals(BuscarNombre.ToLower()));
                }


                return View(citas.ToPagedList(i ?? 1, 3));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
            //return View();
        }

        // GET: CitasPaciente/Details/5
        public ActionResult Details(int id)
        {
            List<ListadoCitasPaciente> detallesConsulta = TodasLasCitasSegunCitaID(id);

            var cita = detallesConsulta.Single(m => m.ID == id);

            return View(cita);
        
        }
        public ActionResult DetailsCitaP(int? id2, int? id3)
        {

            if (Session["Rol"] != null && Session["Rol"].Equals(2))
            {
                //Lista de turnos de cita (AM o PM)
                List<SelectListItem> listaTurno = new List<SelectListItem>();
                listaTurno.Add(new SelectListItem
                {
                    Text = "Matutino",
                    Value = "Matutino"
                });
                listaTurno.Add(new SelectListItem
                {
                    Text = "Vespertino",
                    Value = "Vespertino"
                });
                ViewData["listaTurno"] = listaTurno;

                // lista de tipo de cita(consulta, emergencia)
                List<SelectListItem> listaTipo = new List<SelectListItem>();
                listaTipo.Add(new SelectListItem
                {
                    Text = "Consulta médica",
                    Value = "Consulta médica"
                });
                listaTipo.Add(new SelectListItem
                {
                    Text = "Control",
                    Value = "Control"
                });
                listaTipo.Add(new SelectListItem
                {
                    Text = "Emergencia",
                    Value = "Emergencia"
                });
                ViewData["listaTipo"] = listaTipo;
                //LISTA AREA
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient depaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                var selectList = new List<SelectListItem>();
                DataSet ds = depaWS.ListaAreas();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string id = dr["ID_AREA"].ToString();
                    string nombre_area = dr["NOMBRE_AREA"].ToString();

                    selectList.Add(new SelectListItem
                    {
                        Value = id,
                        Text = nombre_area,
                    });
                }
                ViewData["ListaNombreAreas"] = selectList;
                //LISTA DEPARTAMENTO
                var selectList2 = new List<SelectListItem>();
                DataSet ds2 = depaWS.ListaDepa();

                foreach (DataRow dr in ds2.Tables[0].Rows)
                {
                    string id = dr["ID_DEPARTAMENTO"].ToString();
                    string nombre_dpto = dr["NOMBRE_DEPARTAMENTO"].ToString();

                    selectList2.Add(new SelectListItem
                    {
                        Value = id,
                        Text = nombre_dpto,
                    });
                }
                ViewData["ListaNombreDeptos"] = selectList2;

                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updatecita = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();


                List<RegistroPacienteUsuario> PaList = TodosUsuarios();
                if (id3.HasValue)
                {
                    var p = PaList.Single(m => m.id == id3);
                    string nombre_paciente = p.NOMBRE;
                    string telefono = p.TELEFONO;
                    string correo = p.CORREO;
                    ViewData["NOMBRE"] = nombre_paciente;
                    ViewData["TELEFONO"] = telefono;
                    ViewData["CORREO"] = correo;
                    //return View(p);
                }

                List<CitasPaciente> deplist = TodasLasCitas();
                if (id2.HasValue)
                {
                    var depa = deplist.Single(m => m.ID == id2);
                    ViewData["FECHA"] = depa.FECHA.ToString().Remove(10);
                    return View(depa);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           

        }
        public ActionResult DetailsCitaAceptada(int? id2, int? id3)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(2))
            {
                //Lista de turnos de cita (AM o PM)
                List<SelectListItem> listaTurno = new List<SelectListItem>();
                listaTurno.Add(new SelectListItem
                {
                    Text = "Matutino",
                    Value = "Matutino"
                });
                listaTurno.Add(new SelectListItem
                {
                    Text = "Vespertino",
                    Value = "Vespertino"
                });
                ViewData["listaTurno"] = listaTurno;

                // lista de tipo de cita(consulta, emergencia)
                List<SelectListItem> listaTipo = new List<SelectListItem>();
                listaTipo.Add(new SelectListItem
                {
                    Text = "Consulta médica",
                    Value = "Consulta médica"
                });
                listaTipo.Add(new SelectListItem
                {
                    Text = "Control",
                    Value = "Control"
                });
                listaTipo.Add(new SelectListItem
                {
                    Text = "Emergencia",
                    Value = "Emergencia"
                });
                ViewData["listaTipo"] = listaTipo;
                //LISTA AREA
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient depaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                var selectList = new List<SelectListItem>();
                DataSet ds = depaWS.ListaAreas();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string id = dr["ID_AREA"].ToString();
                    string nombre_area = dr["NOMBRE_AREA"].ToString();

                    selectList.Add(new SelectListItem
                    {
                        Value = id,
                        Text = nombre_area,
                    });
                }
                ViewData["ListaNombreAreas"] = selectList;
                //LISTA DEPARTAMENTO
                var selectList2 = new List<SelectListItem>();
                DataSet ds2 = depaWS.ListaDepa();

                foreach (DataRow dr in ds2.Tables[0].Rows)
                {
                    string id = dr["ID_DEPARTAMENTO"].ToString();
                    string nombre_dpto = dr["NOMBRE_DEPARTAMENTO"].ToString();

                    selectList2.Add(new SelectListItem
                    {
                        Value = id,
                        Text = nombre_dpto,
                    });
                }
                ViewData["ListaNombreDeptos"] = selectList2;

                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updatecita = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();


                List<RegistroPacienteUsuario> PaList = TodosUsuarios();
                if (id3.HasValue)
                {
                    var p = PaList.Single(m => m.id == id3);
                    string nombre_paciente = p.NOMBRE;
                    string telefono = p.TELEFONO;
                    string correo = p.CORREO;
                    ViewData["NOMBRE"] = nombre_paciente;
                    ViewData["TELEFONO"] = telefono;
                    ViewData["CORREO"] = correo;
                    //return View(p);
                }

                List<CitasPaciente> deplist = TodasLasCitas();
                if (id2.HasValue)
                {
                    var depa = deplist.Single(m => m.ID == id2);
                    ViewData["FECHA"] = depa.FECHA.ToString().Remove(10);
                    return View(depa);
                }
                return View();
            }else if(Session["Rol"] != null && Session["Rol"].Equals(3))
            {
                //Lista de turnos de cita (AM o PM)
                List<SelectListItem> listaTurno = new List<SelectListItem>();
                listaTurno.Add(new SelectListItem
                {
                    Text = "Matutino",
                    Value = "Matutino"
                });
                listaTurno.Add(new SelectListItem
                {
                    Text = "Vespertino",
                    Value = "Vespertino"
                });
                ViewData["listaTurno"] = listaTurno;

                // lista de tipo de cita(consulta, emergencia)
                List<SelectListItem> listaTipo = new List<SelectListItem>();
                listaTipo.Add(new SelectListItem
                {
                    Text = "Consulta médica",
                    Value = "Consulta médica"
                });
                listaTipo.Add(new SelectListItem
                {
                    Text = "Control",
                    Value = "Control"
                });
                listaTipo.Add(new SelectListItem
                {
                    Text = "Emergencia",
                    Value = "Emergencia"
                });
                ViewData["listaTipo"] = listaTipo;
                //LISTA AREA
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient depaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                var selectList = new List<SelectListItem>();
                DataSet ds = depaWS.ListaAreas();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string id = dr["ID_AREA"].ToString();
                    string nombre_area = dr["NOMBRE_AREA"].ToString();

                    selectList.Add(new SelectListItem
                    {
                        Value = id,
                        Text = nombre_area,
                    });
                }
                ViewData["ListaNombreAreas"] = selectList;
                //LISTA DEPARTAMENTO
                var selectList2 = new List<SelectListItem>();
                DataSet ds2 = depaWS.ListaDepa();

                foreach (DataRow dr in ds2.Tables[0].Rows)
                {
                    string id = dr["ID_DEPARTAMENTO"].ToString();
                    string nombre_dpto = dr["NOMBRE_DEPARTAMENTO"].ToString();

                    selectList2.Add(new SelectListItem
                    {
                        Value = id,
                        Text = nombre_dpto,
                    });
                }
                ViewData["ListaNombreDeptos"] = selectList2;

                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updatecita = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();


                List<RegistroPacienteUsuario> PaList = TodosUsuarios();
                if (id3.HasValue)
                {
                    var p = PaList.Single(m => m.id == id3);
                    string nombre_paciente = p.NOMBRE;
                    string telefono = p.TELEFONO;
                    string correo = p.CORREO;
                    ViewData["NOMBRE"] = nombre_paciente;
                    ViewData["TELEFONO"] = telefono;
                    ViewData["CORREO"] = correo;
                    //return View(p);
                }

                List<CitasPaciente> deplist = TodasLasCitas();
                if (id2.HasValue)
                {
                    var depa = deplist.Single(m => m.ID == id2);
                    ViewData["FECHA"] = depa.FECHA.ToString().Remove(10);
                    return View(depa);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           

        }
        public ActionResult DetailsCitaFinalizada(int? id2, int? id3)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(2))
            {
                //Lista de turnos de cita (AM o PM)
                List<SelectListItem> listaTurno = new List<SelectListItem>();
                listaTurno.Add(new SelectListItem
                {
                    Text = "Matutino",
                    Value = "Matutino"
                });
                listaTurno.Add(new SelectListItem
                {
                    Text = "Vespertino",
                    Value = "Vespertino"
                });
                ViewData["listaTurno"] = listaTurno;

                // lista de tipo de cita(consulta, emergencia)
                List<SelectListItem> listaTipo = new List<SelectListItem>();
                listaTipo.Add(new SelectListItem
                {
                    Text = "Consulta médica",
                    Value = "Consulta médica"
                });
                listaTipo.Add(new SelectListItem
                {
                    Text = "Control",
                    Value = "Control"
                });
                listaTipo.Add(new SelectListItem
                {
                    Text = "Emergencia",
                    Value = "Emergencia"
                });
                ViewData["listaTipo"] = listaTipo;
                //LISTA AREA
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient depaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                var selectList = new List<SelectListItem>();
                DataSet ds = depaWS.ListaAreas();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string id = dr["ID_AREA"].ToString();
                    string nombre_area = dr["NOMBRE_AREA"].ToString();

                    selectList.Add(new SelectListItem
                    {
                        Value = id,
                        Text = nombre_area,
                    });
                }
                ViewData["ListaNombreAreas"] = selectList;
                //LISTA DEPARTAMENTO
                var selectList2 = new List<SelectListItem>();
                DataSet ds2 = depaWS.ListaDepa();

                foreach (DataRow dr in ds2.Tables[0].Rows)
                {
                    string id = dr["ID_DEPARTAMENTO"].ToString();
                    string nombre_dpto = dr["NOMBRE_DEPARTAMENTO"].ToString();

                    selectList2.Add(new SelectListItem
                    {
                        Value = id,
                        Text = nombre_dpto,
                    });
                }
                ViewData["ListaNombreDeptos"] = selectList2;

                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updatecita = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();


                List<RegistroPacienteUsuario> PaList = TodosUsuarios();
                if (id3.HasValue)
                {
                    var p = PaList.Single(m => m.id == id3);
                    string nombre_paciente = p.NOMBRE;
                    string telefono = p.TELEFONO;
                    string correo = p.CORREO;
                    ViewData["NOMBRE"] = nombre_paciente;
                    ViewData["TELEFONO"] = telefono;
                    ViewData["CORREO"] = correo;
                    //return View(p);
                }

                List<CitasPaciente> deplist = TodasLasCitas();
                if (id2.HasValue)
                {
                    var depa = deplist.Single(m => m.ID == id2);
                    ViewData["FECHA"] = depa.FECHA.ToString().Remove(10);
                    return View(depa);
                }
                return View();
            }
            else if (Session["Rol"] != null && Session["Rol"].Equals(3))
            {
                //Lista de turnos de cita (AM o PM)
                List<SelectListItem> listaTurno = new List<SelectListItem>();
                listaTurno.Add(new SelectListItem
                {
                    Text = "Matutino",
                    Value = "Matutino"
                });
                listaTurno.Add(new SelectListItem
                {
                    Text = "Vespertino",
                    Value = "Vespertino"
                });
                ViewData["listaTurno"] = listaTurno;

                // lista de tipo de cita(consulta, emergencia)
                List<SelectListItem> listaTipo = new List<SelectListItem>();
                listaTipo.Add(new SelectListItem
                {
                    Text = "Consulta médica",
                    Value = "Consulta médica"
                });
                listaTipo.Add(new SelectListItem
                {
                    Text = "Control",
                    Value = "Control"
                });
                listaTipo.Add(new SelectListItem
                {
                    Text = "Emergencia",
                    Value = "Emergencia"
                });
                ViewData["listaTipo"] = listaTipo;
                //LISTA AREA
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient depaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                var selectList = new List<SelectListItem>();
                DataSet ds = depaWS.ListaAreas();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string id = dr["ID_AREA"].ToString();
                    string nombre_area = dr["NOMBRE_AREA"].ToString();

                    selectList.Add(new SelectListItem
                    {
                        Value = id,
                        Text = nombre_area,
                    });
                }
                ViewData["ListaNombreAreas"] = selectList;
                //LISTA DEPARTAMENTO
                var selectList2 = new List<SelectListItem>();
                DataSet ds2 = depaWS.ListaDepa();

                foreach (DataRow dr in ds2.Tables[0].Rows)
                {
                    string id = dr["ID_DEPARTAMENTO"].ToString();
                    string nombre_dpto = dr["NOMBRE_DEPARTAMENTO"].ToString();

                    selectList2.Add(new SelectListItem
                    {
                        Value = id,
                        Text = nombre_dpto,
                    });
                }
                ViewData["ListaNombreDeptos"] = selectList2;

                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updatecita = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();


                List<RegistroPacienteUsuario> PaList = TodosUsuarios();
                if (id3.HasValue)
                {
                    var p = PaList.Single(m => m.id == id3);
                    string nombre_paciente = p.NOMBRE;
                    string telefono = p.TELEFONO;
                    string correo = p.CORREO;
                    ViewData["NOMBRE"] = nombre_paciente;
                    ViewData["TELEFONO"] = telefono;
                    ViewData["CORREO"] = correo;
                    //return View(p);
                }

                List<CitasPaciente> deplist = TodasLasCitas();
                if (id2.HasValue)
                {
                    var depa = deplist.Single(m => m.ID == id2);
                    ViewData["FECHA"] = depa.FECHA.ToString().Remove(10);
                    return View(depa);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           

        }
        // GET: CitasPaciente/Create
        public ActionResult Create(int? id2)
        {
            //Lista de turnos de cita (AM o PM)
            List<SelectListItem> listaTurno = new List<SelectListItem>();
            listaTurno.Add(new SelectListItem
            {
                Text = "Matutino",
                Value = "Matutino"
            });
            listaTurno.Add(new SelectListItem
            {
                Text = "Vespertino",
                Value = "Vespertino"
            });
            ViewData["listaTurno"]= listaTurno;

            // lista de tipo de cita(consulta, emergencia)
            List<SelectListItem> listaTipo = new List<SelectListItem>();
            listaTipo.Add(new SelectListItem
            {
                Text = "Consulta médica",
                Value = "Consulta médica"
            });
            listaTipo.Add(new SelectListItem
            {
                Text = "Control",
                Value = "Control"
            });
            listaTipo.Add(new SelectListItem
            {
                Text = "Emergencia",
                Value = "Emergencia"
            });
            ViewData["listaTipo"] = listaTipo;
            //LISTA AREA
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient depaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            var selectList = new List<SelectListItem>();
            DataSet ds = depaWS.ListaAreas();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string id = dr["ID_AREA"].ToString();
                string nombre_area = dr["NOMBRE_AREA"].ToString();

                selectList.Add(new SelectListItem
                {
                    Value = id,
                    Text = nombre_area,
                });
            }
            ViewData["ListaNombreAreas"] = selectList;
            //LISTA DEPARTAMENTO
            var selectList2 = new List<SelectListItem>();
            DataSet ds2 = depaWS.ListaDepa();

            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                string id = dr["ID_DEPARTAMENTO"].ToString();
                string nombre_dpto = dr["NOMBRE_DEPARTAMENTO"].ToString();

                selectList2.Add(new SelectListItem
                {
                    Value = id,
                    Text = nombre_dpto,
                });
            }
            ViewData["ListaNombreDeptos"] = selectList2;

            //obteniendo datos paciente
            List<RegistroPacienteUsuario> PaList = TodosUsuarios();
            if (id2.HasValue)
            {
                var p = PaList.Single(m => m.id == id2);
                string nombre_paciente = p.NOMBRE;
            string telefono = p.TELEFONO;
            string correo = p.CORREO;
                ViewData["NOMBRE"] = nombre_paciente;
                ViewData["TELEFONO"] = telefono;
                ViewData["CORREO"] = correo;
                //return View(p);
            }
            if (Session["Rol"] != null && Session["Rol"].Equals(1))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: CitasPaciente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(1))
            {
                try
                {
                    SistemaClinicoSoapWS.ClinicaWebServiceSoapClient depaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                    CitasPaciente nuevacita = new Models.CitasPaciente();
                    nuevacita.ID_PACIENTE = int.Parse(Session["id"].ToString());
                    nuevacita.FECHA = collection["FECHA"];
                    nuevacita.HORA = "00:00";
                    nuevacita.TURNO = collection["TURNO"];
                    nuevacita.TIPO_CITA = collection["TIPO_CITA"];
                    nuevacita.ID_DEPARTAMENTO = int.Parse(collection["ID_DEPARTAMENTO"].ToString());
                    nuevacita.DESCRIPCION = collection["DESCRIPCION"];
                    nuevacita.ESTADO = "PENDIENTE";

                    depaWS.InsertCita(nuevacita.ID_PACIENTE, nuevacita.FECHA, nuevacita.HORA, nuevacita.TURNO, nuevacita.TIPO_CITA, nuevacita.ID_DEPARTAMENTO, nuevacita.DESCRIPCION, nuevacita.ESTADO);
                   
                }
                catch
                {
                    // return View();
                    return RedirectToAction("Index");
                }

            }
            else
            {
                Response.Redirect("Index");
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: CitasPaciente/Edit/5
        public ActionResult Edit(int? id2, int? id3)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(2))
            {
                //Lista de turnos de cita (AM o PM)
                List<SelectListItem> listaTurno = new List<SelectListItem>();
                listaTurno.Add(new SelectListItem
                {
                    Text = "Matutino",
                    Value = "Matutino"
                });
                listaTurno.Add(new SelectListItem
                {
                    Text = "Vespertino",
                    Value = "Vespertino"
                });
                ViewData["listaTurno"] = listaTurno;

                // lista de tipo de cita(consulta, emergencia)
                List<SelectListItem> listaTipo = new List<SelectListItem>();
                listaTipo.Add(new SelectListItem
                {
                    Text = "Consulta médica",
                    Value = "Consulta médica"
                });
                listaTipo.Add(new SelectListItem
                {
                    Text = "Control",
                    Value = "Control"
                });
                listaTipo.Add(new SelectListItem
                {
                    Text = "Emergencia",
                    Value = "Emergencia"
                });
                ViewData["listaTipo"] = listaTipo;
                //LISTA AREA
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient depaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                var selectList = new List<SelectListItem>();
                DataSet ds = depaWS.ListaAreas();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string id = dr["ID_AREA"].ToString();
                    string nombre_area = dr["NOMBRE_AREA"].ToString();

                    selectList.Add(new SelectListItem
                    {
                        Value = id,
                        Text = nombre_area,
                    });
                }
                ViewData["ListaNombreAreas"] = selectList;
                //LISTA DEPARTAMENTO
                var selectList2 = new List<SelectListItem>();
                DataSet ds2 = depaWS.ListaDepa();

                foreach (DataRow dr in ds2.Tables[0].Rows)
                {
                    string id = dr["ID_DEPARTAMENTO"].ToString();
                    string nombre_dpto = dr["NOMBRE_DEPARTAMENTO"].ToString();

                    selectList2.Add(new SelectListItem
                    {
                        Value = id,
                        Text = nombre_dpto,
                    });
                }
                ViewData["ListaNombreDeptos"] = selectList2;

                //obteniendo datos paciente
                List<RegistroPacienteUsuario> PaList = TodosUsuarios();
                if (id3.HasValue)
                {
                    var p = PaList.Single(m => m.id == id3);
                    string nombre_paciente = p.NOMBRE;
                    string telefono = p.TELEFONO;
                    string correo = p.CORREO;
                    ViewData["NOMBRE"] = nombre_paciente;
                    ViewData["TELEFONO"] = telefono;
                    ViewData["CORREO"] = correo;
                    //return View(p);
                }
                List<CitasPaciente> deplist = TodasLasCitas();
                if (id2.HasValue)
                {
                    var depa = deplist.Single(m => m.ID == id2);
                    ViewData["FECHA"] = depa.FECHA.ToString().Remove(10);
                    return View(depa);
                }
                return View();
           
        }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: CitasPaciente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id2, int id3, FormCollection collection)
        {
            //string nombre = "";
            //string apellido = "";
            //string paciente = "";

            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updatecita = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            List<CitasPaciente> deplist = TodasLasCitas();
            //List<ListadoCitasPaciente> smsList = TodasLasCitasSegunpacienteID(id2);

            //DataSet datosPaciente = updatecita.PacienteID(id2);
            //foreach (DataRow dr in datosPaciente.Tables[0].Rows)
            //{
            //    nombre = dr["NOMBRE"].ToString();
            //    apellido = dr["APELLIDO"].ToString();
            //    paciente = nombre + " " + apellido;
            //    ViewData["paciente"] = paciente;
            //}


            try
                {
                var depa = deplist.Single(m => m.ID == id2);
                //var depa2 = smsList.Single(m => m.ID == id2);

                if (TryUpdateModel(depa))
                    {
                        updatecita.UpdateCita(id2, depa.ID_PACIENTE, depa.FECHA, depa.HORA, depa.TURNO, depa.TIPO_CITA, depa.ID_DEPARTAMENTO, depa.DESCRIPCION, "ACEPTADA");

                    /************************* SMS ******************************************/


                    var accountSid = "ACe61cf5016212b999fa489c6698bd7103";
                    var authToken = "4804d7e4d31eeaa1ea41b3d55c6543b1";

                    TwilioClient.Init(accountSid, authToken);

                    var messageOptions = new CreateMessageOptions(
                    new PhoneNumber("+503" + depa.TELEFONO));
                    messageOptions.From = new PhoneNumber("+17158008408");
                    messageOptions.Body = "Estimad@: " + depa.NOMBRE + " " + depa.APELLIDO + " su cita está confirmada para el día: " + depa.FECHA + " a la hora: " + depa.HORA;

                    var message = MessageResource.Create(messageOptions);
                    Console.WriteLine(message.Body);

                    /*********************** SMS ********************************************/


                    return RedirectToAction("ListadoCitasPaciente");

                    }

                //codigo para API de sms
                //string accountSid = Environment.GetEnvironmentVariable("ACff74ce0458777d0270f694481bf73641");
                //string authToken = Environment.GetEnvironmentVariable("469a8d4266ae6a9e0c81274f214cfed0");

                //TwilioClient.Init(accountSid, authToken);

                //var message = MessageResource.Create(
                //body: "Hola soy Datanet.",
                //from: new Twilio.Types.PhoneNumber("+18283684074"),
                //to: new Twilio.Types.PhoneNumber("+50360453391")
                //);

                //Console.WriteLine(message.Sid);

                



                return View(depa);
            }
                catch
                {
                    return View();
                }

            
         
        }
        public ActionResult RealizarConsulta(int? id2, int? id3)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(3))
            {
                //Lista de turnos de cita (AM o PM)
                List<SelectListItem> listaTurno = new List<SelectListItem>();
                listaTurno.Add(new SelectListItem
                {
                    Text = "Matutino",
                    Value = "Matutino"
                });
                listaTurno.Add(new SelectListItem
                {
                    Text = "Vespertino",
                    Value = "Vespertino"
                });
                ViewData["listaTurno"] = listaTurno;

                // lista de tipo de cita(consulta, emergencia)
                List<SelectListItem> listaTipo = new List<SelectListItem>();
                listaTipo.Add(new SelectListItem
                {
                    Text = "Consulta médica",
                    Value = "Consulta médica"
                });
                listaTipo.Add(new SelectListItem
                {
                    Text = "Control",
                    Value = "Control"
                });
                listaTipo.Add(new SelectListItem
                {
                    Text = "Emergencia",
                    Value = "Emergencia"
                });
                ViewData["listaTipo"] = listaTipo;
                //LISTA AREA
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient depaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                var selectList = new List<SelectListItem>();
                DataSet ds = depaWS.ListaAreas();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string id = dr["ID_AREA"].ToString();
                    string nombre_area = dr["NOMBRE_AREA"].ToString();

                    selectList.Add(new SelectListItem
                    {
                        Value = id,
                        Text = nombre_area,
                    });
                }
                ViewData["ListaNombreAreas"] = selectList;
                //LISTA DEPARTAMENTO
                var selectList2 = new List<SelectListItem>();
                DataSet ds2 = depaWS.ListaDepa();

                foreach (DataRow dr in ds2.Tables[0].Rows)
                {
                    string id = dr["ID_DEPARTAMENTO"].ToString();
                    string nombre_dpto = dr["NOMBRE_DEPARTAMENTO"].ToString();

                    selectList2.Add(new SelectListItem
                    {
                        Value = id,
                        Text = nombre_dpto,
                    });
                }
                ViewData["ListaNombreDeptos"] = selectList2;

                //obteniendo datos paciente
                List<RegistroPacienteUsuario> PaList = TodosUsuarios();
                if (id3.HasValue)
                {
                    var p = PaList.Single(m => m.id == id3);
                    string nombre_paciente = p.NOMBRE;
                    string telefono = p.TELEFONO;
                    string correo = p.CORREO;
                    ViewData["NOMBRE"] = nombre_paciente;
                    ViewData["TELEFONO"] = telefono;
                    ViewData["CORREO"] = correo;
                    //return View(p);
                }
                List<CitasPaciente> deplist = TodasLasCitas();
                if (id2.HasValue)
                {
                    var depa = deplist.Single(m => m.ID == id2);
                    ViewData["FECHA"] = depa.FECHA.ToString().Remove(10);
                    return View(depa);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

        // POST: CitasPaciente/Edit/5
        [HttpPost]
        public ActionResult RealizarConsulta(int id2, int id3, FormCollection collection)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(3))
            {
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updatecita = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

                List<CitasPaciente> deplist = TodasLasCitas();


                try
                {
                    var depa = deplist.Single(m => m.ID == id2);

                    if (TryUpdateModel(depa))
                    {
                        updatecita.UpdateCita(id2, depa.ID_PACIENTE, depa.FECHA.Remove(10), depa.HORA, depa.TURNO, depa.TIPO_CITA, depa.ID_DEPARTAMENTO, depa.DESCRIPCION, "FINALIZADA");
                        return RedirectToAction("Create", "Consultas", new { id = id2 });

                    }

                    return View(depa);
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           



        }

        public ActionResult FinalizarCita(int? id2, int? id3)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(2))
            {
                //Lista de turnos de cita (AM o PM)
                List<SelectListItem> listaTurno = new List<SelectListItem>();
                listaTurno.Add(new SelectListItem
                {
                    Text = "Matutino",
                    Value = "Matutino"
                });
                listaTurno.Add(new SelectListItem
                {
                    Text = "Vespertino",
                    Value = "Vespertino"
                });
                ViewData["listaTurno"] = listaTurno;

                // lista de tipo de cita(consulta, emergencia)
                List<SelectListItem> listaTipo = new List<SelectListItem>();
                listaTipo.Add(new SelectListItem
                {
                    Text = "Consulta médica",
                    Value = "Consulta médica"
                });
                listaTipo.Add(new SelectListItem
                {
                    Text = "Control",
                    Value = "Control"
                });
                listaTipo.Add(new SelectListItem
                {
                    Text = "Emergencia",
                    Value = "Emergencia"
                });
                ViewData["listaTipo"] = listaTipo;
                //LISTA AREA
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient depaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                var selectList = new List<SelectListItem>();
                DataSet ds = depaWS.ListaAreas();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string id = dr["ID_AREA"].ToString();
                    string nombre_area = dr["NOMBRE_AREA"].ToString();

                    selectList.Add(new SelectListItem
                    {
                        Value = id,
                        Text = nombre_area,
                    });
                }
                ViewData["ListaNombreAreas"] = selectList;
                //LISTA DEPARTAMENTO
                var selectList2 = new List<SelectListItem>();
                DataSet ds2 = depaWS.ListaDepa();

                foreach (DataRow dr in ds2.Tables[0].Rows)
                {
                    string id = dr["ID_DEPARTAMENTO"].ToString();
                    string nombre_dpto = dr["NOMBRE_DEPARTAMENTO"].ToString();

                    selectList2.Add(new SelectListItem
                    {
                        Value = id,
                        Text = nombre_dpto,
                    });
                }
                ViewData["ListaNombreDeptos"] = selectList2;

                //obteniendo datos paciente
                List<RegistroPacienteUsuario> PaList = TodosUsuarios();
                if (id3.HasValue)
                {
                    var p = PaList.Single(m => m.id == id3);
                    string nombre_paciente = p.NOMBRE;
                    string telefono = p.TELEFONO;
                    string correo = p.CORREO;
                    ViewData["NOMBRE"] = nombre_paciente;
                    ViewData["TELEFONO"] = telefono;
                    ViewData["CORREO"] = correo;
                    //return View(p);
                }
                List<CitasPaciente> deplist = TodasLasCitas();
                if (id2.HasValue)
                {
                    var depa = deplist.Single(m => m.ID == id2);
                    ViewData["FECHA"] = depa.FECHA.ToString().Remove(10);
                    return View(depa);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

        // POST: CitasPaciente/Edit/5
        [HttpPost]
        public ActionResult FinalizarCita(int id2, int id3, FormCollection collection)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updatecita = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            List<CitasPaciente> deplist = TodasLasCitas();


            try
            {
                var depa = deplist.Single(m => m.ID == id2);

                if (TryUpdateModel(depa))
                {
                    updatecita.UpdateCita(id2, depa.ID_PACIENTE, depa.FECHA.Remove(10), depa.HORA, depa.TURNO, depa.TIPO_CITA, depa.ID_DEPARTAMENTO, depa.DESCRIPCION, "FINALIZADA");
                    return RedirectToAction("ListadoCitasPacienteAceptada");

                }

                return View(depa);
            }
            catch
            {
                return View();
            }



        }
        // GET: CitasPaciente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CitasPaciente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
