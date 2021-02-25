using PagedList;
using SistemaClinico.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaClinico.Controllers
{
    public class DireccionController : Controller
    {
        public static List<Direccion> ListaDireccion()
        {
            List<Direccion> listaDireccion = new List<Direccion>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient direcWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = direcWS.ListaDireccion();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_DIRECCION"].ToString());
                string pais = dr["PAIS"].ToString();
                string depa = dr["DEPARTAMENTO"].ToString();
                string muni = dr["MUNICIPIO"].ToString();

                Direccion direc = new Direccion();
                direc.ID = id;
                direc.PAIS = pais;
                direc.DEPARTAMENTO = depa;
                direc.MUNICIPIO = muni;

                listaDireccion.Add(direc);
            }
            return listaDireccion;
        }

        // GET: Direccion
        public ActionResult Index(int? i, string BuscarNombre)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                var Direc = from e in ListaDireccion()
                                //orderby e.nombre
                            select e;
                if (!String.IsNullOrEmpty(BuscarNombre))
                {
                    Direc = Direc.Where(c => c.PAIS.ToLower().Contains(BuscarNombre.ToLower()) || c.DEPARTAMENTO.ToLower().Contains(BuscarNombre.ToLower()) || c.MUNICIPIO.ToLower().Contains(BuscarNombre.ToLower()));
                }
                return View(Direc.ToPagedList(i ?? 1, 3));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

        // GET: Direccion/Details/5
        public ActionResult Details(int id)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // GET: Direccion/Create
        public ActionResult Create()
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // POST: Direccion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                try
                {
                    SistemaClinicoSoapWS.ClinicaWebServiceSoapClient DirecWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                    Direccion direc = new Models.Direccion();
                    direc.PAIS = collection["PAIS"];
                    direc.DEPARTAMENTO = collection["DEPARTAMENTO"];
                    direc.MUNICIPIO = collection["MUNICIPIO"];
                    DirecWS.InsertDireccion(direc.PAIS, direc.DEPARTAMENTO, direc.MUNICIPIO);
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

        // GET: Direccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                List<Direccion> listaDirec = ListaDireccion();
                if (id.HasValue)
                {
                    var dire = listaDirec.Single(m => m.ID == id);
                    return View(dire);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
    

        // POST: Direccion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updateDirec = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            try
            {
                // REVISAR ESTP DESPUES
                List<Direccion> listdirecc = ListaDireccion();
                var direc = listdirecc.Single(m => m.ID == id);
                if (TryUpdateModel(direc))
                {
                    updateDirec.UpdateDireccion(direc.ID, direc.PAIS, direc.DEPARTAMENTO, direc.MUNICIPIO);
                    return RedirectToAction("Index");
                }
                return View(direc);
            }
            catch
            {
                return View();
            }
        }

        // GET: Direccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                List<Direccion> listadirec = ListaDireccion();
                if (id.HasValue)
                {
                    var dire = listadirec.Single(m => m.ID == id);
                    return View(dire);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // POST: Direccion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient direcWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                List<Direccion> listadirec = ListaDireccion();
                var dire = listadirec.Single(m => m.ID == id);

                Direccion borradire = new Models.Direccion();
                borradire.PAIS = dire.PAIS.ToString();
                borradire.DEPARTAMENTO = dire.DEPARTAMENTO.ToString();
                borradire.MUNICIPIO = dire.MUNICIPIO.ToString();

                direcWS.EliminarDireccion(id);

                if (TryUpdateModel(dire))
                {
                    direcWS.EliminarDireccion(dire.ID);
                    return RedirectToAction("Index");
                }
                return View(dire);
            }
            catch
            {
                return View();
            }
        }
    }
}
