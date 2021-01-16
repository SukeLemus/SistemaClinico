using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaClinico.Models;
using PagedList;

namespace SistemaClinico.Controllers
{
    public class ConsultasController : Controller
    {
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

        public static List<ConsultaPac> TodasLasConsultasSegunpacienteID(int idpa)
        {
            List<ConsultaPac> listaS = new List<ConsultaPac>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient citas = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            DataSet ds = citas.lista_consultas_comp_segun_id(idpa);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //int id = int.Parse(dr["ID_CITAS"].ToString());
                //int idpaciente = int.Parse(dr["ID_PACIENTE"].ToString());
                string nombrepaciente = dr["NOMBRE"].ToString();
                string apellidopaciente = dr["APELLIDO"].ToString();
                string nombreDoctor = dr["NOMBRES"].ToString();
                string apellidoDoctor = dr["APELLIDOS"].ToString();
                string fecha = dr["FECHA"].ToString();
                string hora = dr["HORA"].ToString();
                string tipoCita = dr["TIPO_CITA"].ToString();
                string descripcion = dr["DESCRIPCION"].ToString();
                string diagnostico = dr["DIAGNOSTICO"].ToString();


                ConsultaPac consultaPac = new ConsultaPac();
                consultaPac.NOMBRE = nombrepaciente;
                consultaPac.APELLIDO = apellidopaciente;
                consultaPac.NOMBRES = nombreDoctor;
                consultaPac.APELLIDOS = apellidoDoctor;
                consultaPac.FECHA = fecha.ToString().Remove(10);
                consultaPac.HORA = hora;
                consultaPac.TIPO_CITA = tipoCita;
                consultaPac.DESCRIPCION = descripcion;
                consultaPac.DIAGNOSTICO = diagnostico;
           
                listaS.Add(consultaPac);
            }
            return listaS;

        }

        // GET: Consultas
        public ActionResult Index(int? i, string BuscarNombre)
        {


            int idpa = int.Parse(Session["id"].ToString());

            var citas = from e in TodasLasConsultasSegunpacienteID(idpa)
                            //orderby e.nombre
                        select e;
            if (!String.IsNullOrEmpty(BuscarNombre))
            {
                citas = citas.Where(c => c.NOMBRE.ToLower().Contains(BuscarNombre.ToLower()));
            }
            return View(citas.ToPagedList(i ?? 1, 3));
        }

        // GET: Consultas/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Consultas/Create
        public ActionResult Create(int? id)
        {

            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient medicamentosWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();


            //lista con todos los medicamentos
            DataSet ds = medicamentosWS.lista_medicamentos();
            List<Medicamento> listaMedicamentos = new List<Medicamento>();
            var selectList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id_medicamento = int.Parse(dr["ID_MEDICAMENTO"].ToString());
                string nombre_medicamento = dr["NOMBRE_MEDICAMENTO"].ToString();
                    
                //Medicamento medicamento = new Medicamento();
                //medicamento.id = id_medicamento;
                //medicamento.NOMBRE_MEDICAMENTO = nombre_medicamento;
                //listaMedicamentos.Add(medicamento);
                selectList.Add(new SelectListItem
                {
                    Value = id_medicamento.ToString(),
                    Text = nombre_medicamento
                });
            }
            ViewData["listaMedicamentos"] = selectList;

            //lista con tipos de medicamentos
            List<SelectListItem> listaViaAdministracion = new List<SelectListItem>();
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Oral",
                Value = "Oral"
            });
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Sublingual",
                Value = "Sublingual"
            });
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Tópica",
                Value = "Tópica"
            });
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Transdérmica",
                Value = "Transdérmica"
            });
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Oftalmológica",
                Value = "Oftalmológica"
            });
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Inhalatoria",
                Value = "Inhalatoria"
            });
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Rectal",
                Value = "Rectal"
            });
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Vaginal",
                Value = "Vaginal"
            });
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Tópica",
                Value = "Tópica"
            });
            ViewData["listaTipoAdministracion"] = listaViaAdministracion;
            //********************************************************************

            var citas = from e in TodasLasCitasSegunpacienteFinalizada()
                        select e;

            var c = citas.Single(m => m.ID == id);

            string nomMedico = Session["Nombre"].ToString() + Session["Apellido"].ToString();
            string nomPaci = c.NOMBRE.ToString() + c.APELLIDO.ToString();
            string f = c.FECHA;

            ViewData["NombreP"] = nomPaci;
            ViewData["TelefonoP"] = c.TELEFONO;
            ViewData["CorreoP"] = c.CORREO;
            ViewData["ID_PACIENTE"] = c.ID_PACIENTE;
            ViewData["Medico"] = nomMedico;
            ViewData["ID_PERSONAL"] = Session["id"];
            ViewData["fecha"] = f/*.ToString().Remove(10)*/;
            ViewData["hora"] = c.HORA;
            ViewData["DESCRIPCION"] = c.DESCRIPCION;
            ViewData["ID_CITAS"] = c.ID;



            return View();
        }

        // POST: Consultas/Create
        [HttpPost]
        public ActionResult Create(int id,FormCollection collection)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(3))
            {
                try
                {
                    var citas = from e in TodasLasCitasSegunpacienteFinalizada()
                                select e;

                    var c = citas.Single(m => m.ID == id);

                    int idmedico = int.Parse(Session["id"].ToString());

                    string f = c.FECHA;

                    SistemaClinicoSoapWS.ClinicaWebServiceSoapClient WS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                    Consulta consulta = new Models.Consulta();
                    consulta.ID_PACIENTE = c.ID_PACIENTE;
                    consulta.ID_PERSONAL = idmedico;
                    consulta.FECHA = c.FECHA;
                    consulta.HORA = c.HORA;
                    consulta.ID_CITAS = c.ID;
                    consulta.DIAGNOSTICO = collection["DIAGNOSTICO"];
                    

                    WS.InsertConsulta(consulta.ID_PACIENTE, consulta.ID_PERSONAL, consulta.FECHA, consulta.HORA, consulta.ID_CITAS, consulta.DIAGNOSTICO);

                    //sacar el MAX de consulta
                    DataSet dsX = WS.MaxIdConsulta();
                    int idMax = 0;

                    foreach (DataRow dr in dsX.Tables[0].Rows)
                    {                      
                       idMax= int.Parse(dr["MAX(ID_CONSULTA)"].ToString());
                    }

                    WS.InsertConstancia(idMax);
                }
                catch
                {
                    // return View();
                    return RedirectToAction("Index","Home");
                }
            }
            else
            {
                Response.Redirect("Index");
            }
            return RedirectToActionPermanent("AgregandoMedica", "Consultas", new { id = id});
        }

        // GET: Consultas/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: Consultas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AgregandoMedica(int id)
        {

            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient medicamentosWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();


            //lista con todos los medicamentos
            DataSet ds = medicamentosWS.lista_medicamentos();
            List<Medicamento> listaMedicamentos = new List<Medicamento>();
            var selectList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id_medicamento = int.Parse(dr["ID_MEDICAMENTO"].ToString());
                string nombre_medicamento = dr["NOMBRE_MEDICAMENTO"].ToString();

                //Medicamento medicamento = new Medicamento();
                //medicamento.id = id_medicamento;
                //medicamento.NOMBRE_MEDICAMENTO = nombre_medicamento;
                //listaMedicamentos.Add(medicamento);
                selectList.Add(new SelectListItem
                {
                    Value = id_medicamento.ToString(),
                    Text = nombre_medicamento
                });
            }
            ViewData["listaMedicamentos"] = selectList;

            //lista con tipos de medicamentos
            List<SelectListItem> listaViaAdministracion = new List<SelectListItem>();
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Oral",
                Value = "Oral"
            });
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Sublingual",
                Value = "Sublingual"
            });
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Tópica",
                Value = "Tópica"
            });
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Transdérmica",
                Value = "Transdérmica"
            });
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Oftalmológica",
                Value = "Oftalmológica"
            });
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Inhalatoria",
                Value = "Inhalatoria"
            });
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Rectal",
                Value = "Rectal"
            });
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Vaginal",
                Value = "Vaginal"
            });
            listaViaAdministracion.Add(new SelectListItem
            {
                Text = "Tópica",
                Value = "Tópica"
            });
            ViewData["listaTipoAdministracion"] = listaViaAdministracion;

            var citas = from e in TodasLasCitasSegunpacienteFinalizada()
                        select e;

            var c = citas.Single(m => m.ID == id);

            string nomMedico = Session["Nombre"].ToString() + Session["Apellido"].ToString();
            string nomPaci = c.NOMBRE.ToString() + c.APELLIDO.ToString();
            string f = c.FECHA;

            ViewData["NombreP"] = nomPaci;
            ViewData["TelefonoP"] = c.TELEFONO;
            ViewData["CorreoP"] = c.CORREO;
            ViewData["ID_PACIENTE"] = c.ID_PACIENTE;
            ViewData["Medico"] = nomMedico;
            ViewData["ID_PERSONAL"] = Session["id"];
            ViewData["fecha"] = f/*.ToString().Remove(10)*/;
            ViewData["hora"] = c.HORA;
            ViewData["DESCRIPCION"] = c.DESCRIPCION;
            ViewData["ID_CITAS"] = c.ID;

            return View();
        }

        // POST: Consultas/Edit/5
        [HttpPost]
        public ActionResult AgregandoMedica(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient WS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

                Prescripcion prescripcion = new Models.Prescripcion();

                prescripcion.ID_MEDICAMENTO = int.Parse(collection["ID_MEDICAMENTO"]);
                prescripcion.CICLO_CONSUMO = collection["CICLO_CONSUMO"];
                prescripcion.VIA_ADMI = collection["VIA_ADMI"];
                prescripcion.INSTRUCCIONES_AD = collection["INSTRUCCIONES_AD"];


                DataSet dsX = WS.MaxIdConsulta();
                int idMax = 0;

                foreach (DataRow dr in dsX.Tables[0].Rows)
                {
                    idMax = int.Parse(dr["MAX(ID_CONSULTA)"].ToString());
                }



                WS.InsertPrescripcion(idMax, prescripcion.ID_MEDICAMENTO, prescripcion.CICLO_CONSUMO, prescripcion.VIA_ADMI, prescripcion.INSTRUCCIONES_AD);

                return RedirectToAction("AgregandoMedica","Consultas", new { id = id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Consultas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Consultas/Delete/5
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
