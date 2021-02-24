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
    public class ConsultoriosController : Controller
    {
        public static List<Consultorio> ListaConsultorios()
        {
            List<Consultorio> listaConsu = new List<Consultorio>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient consuWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = consuWS.ListaConsultorio();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Consultorio consu = new Consultorio();

                consu.ID = int.Parse(dr["ID_CONSULTORIO"].ToString());
                consu.ID_DEPARTAMENTO = int.Parse(dr["ID_DEPARTAMENTO"].ToString());
                consu.NOMBRE_CONSULTORIO = dr["NOMBRE_CONSULTORIO"].ToString();
                consu.NIVEL = int.Parse(dr["NIVEL"].ToString());
                consu.ESTADO = dr["ESTADO"].ToString();


                DataSet ds2 = consuWS.NombreDptoConsultorios(consu.ID_DEPARTAMENTO);


                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                {
                    //are.NOMBRE_AREA = dr2["NOMBRE_AREA"].ToString();
                    consu.NOM = dr2["NOMBRE_DEPARTAMENTO"].ToString();
                }
                listaConsu.Add(consu);
            }



            return listaConsu;
        }

        // GET: Consultorios
        public ActionResult Index(int? i, string BuscarActivo)
        {

            List<SelectListItem> listaEstados = new List<SelectListItem>();

            listaEstados.Add(new SelectListItem
            {
                Text = "Activo",
                Value = "ACTIVO"
            });
            listaEstados.Add(new SelectListItem
            {
                Text = "Inactivo",
                Value = "INACTIVO"
            });

            ViewData["listaEstado"] = listaEstados;

            var Consultorio = from e in ListaConsultorios()
                               select e;



            if (!String.IsNullOrEmpty(BuscarActivo))
            {
                Consultorio = Consultorio.Where(c => c.ESTADO.ToLower().Equals(BuscarActivo.ToLower()));
            }
            //ViewData["listaEstado"] = listaEstados;


            return View(Consultorio.ToPagedList(i ?? 1, 3));

        }

        // GET: Consultorios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Consultorios/Create
        public ActionResult Create()
        {
           

            //lista de nombres de Departamentos
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient depaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            var selectList = new List<SelectListItem>();
            DataSet ds = depaWS.ListaDepa();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string id = dr["ID_DEPARTAMENTO"].ToString();
                string nombre_dpto = dr["NOMBRE_DEPARTAMENTO"].ToString();

                selectList.Add(new SelectListItem
                {
                    Value = id,
                    Text = nombre_dpto,
                });
            }
            ViewData["ListaNombreDeptos"] = selectList;


            return View();
        }

        // POST: Consultorios/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                try
                {
                    SistemaClinicoSoapWS.ClinicaWebServiceSoapClient consuWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                    Consultorio consu = new Consultorio();

                  
                    consu.ID_DEPARTAMENTO = int.Parse(collection["ID_DEPARTAMENTO"].ToString());
                    consu.NOMBRE_CONSULTORIO = collection["NOMBRE_CONSULTORIO"].ToString();
                    consu.NIVEL = int.Parse(collection["NIVEL"].ToString());
                   

                    consuWS.InsertConsultorio(consu.ID_DEPARTAMENTO, consu.NOMBRE_CONSULTORIO, consu.NIVEL, "ACTIVO");
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
            return RedirectToActionPermanent("Index");
        }

        // GET: Consultorios/Edit/5
        public ActionResult Edit(int? id)
        {
            List<SelectListItem> listaEstados = new List<SelectListItem>();
            List<SelectListItem> listaDepa = new List<SelectListItem>();

            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient depaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = depaWS.ListaDepa();

            listaEstados.Add(new SelectListItem
            {
                Text = "Activo",
                Value = "ACTIVO"
            });
            listaEstados.Add(new SelectListItem
            {
                Text = "Inactivo",
                Value = "INACTIVO"
            });

            ViewData["estados"] = listaEstados;

            List<Consultorio> consultlist = ListaConsultorios();
            if (id.HasValue)
            {
                var consul = consultlist.Single(m => m.ID == id);
                ViewData["estados"] = listaEstados;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string idDepa = dr["ID_DEPARTAMENTO"].ToString();
                    string nombre = dr["NOMBRE_DEPARTAMENTO"].ToString();


                    listaDepa.Add(new SelectListItem
                    {
                        Text = nombre,
                        Value = idDepa
                    });
                }

                ViewData["listaDepa"] = listaDepa;

                return View(consul);
            }



            return View();
        }

        // POST: Consultorios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updateEnfermedad = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();



            try
            {
                List<Consultorio> consultList = ListaConsultorios();
                var consul = consultList.Single(m => m.ID == id);

                if (TryUpdateModel(consul))
                {
                    updateEnfermedad.UpdateConsultorio(consul.ID, consul.ID_DEPARTAMENTO, consul.NOMBRE_CONSULTORIO, consul.NIVEL, consul.ESTADO);
                    return RedirectToAction("Index", new { id = id });

                }
                return View(consul);

            }
            catch
            {
                return View();
            }

        }

        // GET: Consultorios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Consultorios/Delete/5
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
