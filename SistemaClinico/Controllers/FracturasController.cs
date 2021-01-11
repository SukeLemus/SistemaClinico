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
    public class FracturasController : Controller
    {

        public static List<Fracturas> ListaFracturas()
        {
            List<Fracturas> listaFracturas = new List<Fracturas>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient fracWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = fracWS.ListaFracturas();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_FRACTURAS"].ToString());
                string nombrefrac = dr["NOMBRE_FRACTURA"].ToString();
                string descri = dr["DESCRIPCION"].ToString();

                Fracturas ciru = new Fracturas();
                ciru.ID = id;
                ciru.NOMBRE_FRACTURA = nombrefrac;
                ciru.DESCRIPCION = descri;

                listaFracturas.Add(ciru);
            }
            return listaFracturas;
        }
        // GET: Fracturas
        public ActionResult Index(int? i, string BuscarNombre)
        {
            var frac = from e in ListaFracturas()
                           //orderby e.nombre
                       select e;
            if (!String.IsNullOrEmpty(BuscarNombre))
            {
                frac = frac.Where(c => c.NOMBRE_FRACTURA.ToLower().Contains(BuscarNombre.ToLower()));
            }
            return View(frac.ToPagedList(i ?? 1, 3));
        }

        // GET: Fracturas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Fracturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fracturas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                try
                {
                    SistemaClinicoSoapWS.ClinicaWebServiceSoapClient fracWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                    Fracturas frac = new Models.Fracturas();
                    frac.NOMBRE_FRACTURA = collection["NOMBRE_FRACTURA"];
                    frac.DESCRIPCION = collection["DESCRIPCION"];
                    fracWS.InsertFracturas(frac.NOMBRE_FRACTURA, frac.DESCRIPCION);
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

        // GET: Fracturas/Edit/5
        public ActionResult Edit(int? id)
        {
            List<Fracturas> listafrac = ListaFracturas();
            if (id.HasValue)
            {
                var frac = listafrac.Single(m => m.ID == id);
                return View(frac);
            }
            return View();
        }

        // POST: Fracturas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updatefrac = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            try
            {
                // REVISAR ESTP DESPUES
                List<Fracturas> listafrac = ListaFracturas();
                var frac = listafrac.Single(m => m.ID == id);
                if (TryUpdateModel(frac))
                {
                    updatefrac.UpdateFracturas(frac.ID, frac.NOMBRE_FRACTURA, frac.DESCRIPCION);
                    return RedirectToAction("Index");
                }
                return View(frac);
            }
            catch
            {
                return View();
            }
        }

        // GET: Fracturas/Delete/5
        public ActionResult Delete(int? id)
        {
            List<Fracturas> listafrac = ListaFracturas();
            if (id.HasValue)
            {
                var frac = listafrac.Single(m => m.ID == id);
                return View(frac);
            }
            return View();
        }

        // POST: Fracturas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient fracWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                List<Fracturas> listafrac = ListaFracturas();
                var frac = listafrac.Single(m => m.ID == id);

                Fracturas borraFrac = new Models.Fracturas();
                borraFrac.NOMBRE_FRACTURA = frac.NOMBRE_FRACTURA.ToString();
                borraFrac.DESCRIPCION = frac.DESCRIPCION.ToString();

                fracWS.EliminarFracturas(id);

                if (TryUpdateModel(frac))
                {
                    fracWS.EliminarFracturas(frac.ID);
                    return RedirectToAction("Index");
                }
                return View(frac);
            }
            catch
            {
                return View();
            }
        }
    }
}
