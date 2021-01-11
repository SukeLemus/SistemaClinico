using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SistemaClinico.Models;

namespace SistemaClinico.Controllers
{
    public class DepartamentoController : Controller
    {

        public static List<Departamento> ListaDepartamentos()
        {
            List<Departamento> listaDepas = new List<Departamento>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient dptoWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = dptoWS.ListaDepa();
            
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                Departamento depa = new Departamento();
                depa.ID= int.Parse(dr["ID_DEPARTAMENTO"].ToString());
                depa.NOMBRE_DEPARTAMENTO = dr["NOMBRE_DEPARTAMENTO"].ToString();
                depa.DESCRIPCION= dr["DESCRIPCION"].ToString();
                depa.ESTADO= dr["ESTADO"].ToString();
                depa.ID_AREA= int.Parse(dr["ID_AREA"].ToString());

                DataSet ds2 = dptoWS.NombreArea_Departamento(int.Parse(dr["ID_AREA"].ToString()));
               

                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                {
                    //are.NOMBRE_AREA = dr2["NOMBRE_AREA"].ToString();
                    depa.NOM = dr2["NOMBRE_AREA"].ToString();
                }
                listaDepas.Add(depa);
            }

          
            return listaDepas;
        }


        // GET: Departamento
        public ActionResult Index(int? i, string BuscarActivo)
        {
            SistemaClinico.SistemaClinicoSoapWS.ClinicaWebServiceSoapClient swEnf = new SistemaClinico.SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            List<SelectListItem> listaEstados = new List<SelectListItem>();
            listaEstados.Add(new SelectListItem
            {
                Text = "Todos",
                Value = ""
            });
            listaEstados.Add(new SelectListItem
            {
                Text = "Activos",
                Value = "ACTIVO"
            });
            listaEstados.Add(new SelectListItem
            {
                Text = "Inactivos",
                Value = "INACTIVO"
            });


            var Departamento = from e in ListaDepartamentos()
                               select e;

            

            if (!String.IsNullOrEmpty(BuscarActivo))
            {
                Departamento = Departamento.Where(c => c.ESTADO.ToLower().Equals(BuscarActivo.ToLower()));
            }
            ViewData["listaEstado"] = listaEstados;


            return View(Departamento.ToPagedList(i ?? 1, 3));
        }

        // GET: Departamento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Departamento/Create
        public ActionResult Create()
        {
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

         



            return View();
        }

        // POST: Departamento/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                try
                {
                    SistemaClinicoSoapWS.ClinicaWebServiceSoapClient depaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                    Departamento depaNuevo = new Models.Departamento();
                    depaNuevo.NOMBRE_DEPARTAMENTO = collection["NOMBRE_DEPARTAMENTO"];
                    depaNuevo.DESCRIPCION = collection["DESCRIPCION"];
                    depaNuevo.ESTADO = "ACTIVO";
                    depaNuevo.ID_AREA = int.Parse(collection["ID_AREA"]);

                    depaWS.InsertDepa(depaNuevo.NOMBRE_DEPARTAMENTO, depaNuevo.DESCRIPCION, depaNuevo.ESTADO, depaNuevo.ID_AREA);
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

        // GET: Departamento/Edit/5
        public ActionResult Edit(int? id)
        {
            List<SelectListItem> listaEstados = new List<SelectListItem>();
            List<SelectListItem> listaArea = new List<SelectListItem>();

            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient depaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = depaWS.ListaAreas();

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

            //ViewData["estados"] = listaEstados;

            List<Departamento> deplist = ListaDepartamentos();
            if (id.HasValue)
            {
                var depa = deplist.Single(m => m.ID == id);
                ViewData["estados"] = listaEstados;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string idArea = dr["ID_AREA"].ToString();
                    string nombre = dr["NOMBRE_AREA"].ToString();


                    listaArea.Add(new SelectListItem
                    {
                        Text = nombre,
                        Value = idArea
                    });  
                }

                ViewData["listaAreas"] = listaArea;

                return View(depa);
            }

            

            return View();
        }

        // POST: Departamento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updateEnfermedad = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();



            try
            {
                List<Departamento> deplist = ListaDepartamentos();
                var depa = deplist.Single(m => m.ID == id);

                if (TryUpdateModel(depa))
                {
                    updateEnfermedad.UpdateDepa(depa.ID, depa.NOMBRE_DEPARTAMENTO, depa.DESCRIPCION, depa.ESTADO, depa.ID_AREA);
                    return RedirectToAction("Index", new { id = id });

                }
                return View(depa);

            }
            catch
            {
                return View();
            }


        }

        // GET: Departamento/Delete/5
        public ActionResult Inactivo(int? id)
        {
            List<Departamento> listDepa = ListaDepartamentos();
            if (id.HasValue)
            {
                var depa = listDepa.Single(m => m.ID == id);
                return View(depa);
            }
            return View();
        }

        // POST: Departamento/Delete/5
        [HttpPost]
        public ActionResult Inactivo(int id, FormCollection collection)
        {
            try
            {
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient depaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                List<Departamento> listaDepa = ListaDepartamentos();
                var depa = listaDepa.Single(m => m.ID == id);

                Departamento borraDepa = new Models.Departamento();
                borraDepa.NOMBRE_DEPARTAMENTO = depa.NOMBRE_DEPARTAMENTO.ToString();
                

                depaWS.UpdateEstadoDpartamento(id, "INACTIVO");

                if (TryUpdateModel(depa))
                {
                    depaWS.UpdateEstadoDpartamento(depa.ID, "INACTIVO");
                    return RedirectToAction("Index");
                }
                return View(depa);
            }
            catch
            {
                return View();
            }
        }
    }
}
