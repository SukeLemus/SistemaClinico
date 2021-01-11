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
    public class AlergiasController : Controller
    {

        public static List<Alergias> ListaAlergias()
        {
            List<Alergias> listaAlergias = new List<Alergias>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient alerWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = alerWS.ListaAlergias();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_ALERGIA"].ToString());
                string nombrealer = dr["NOMBRE_ALERGIA"].ToString();
                string descri = dr["DESCRIPCION"].ToString();

                Alergias alergi = new Alergias();
                alergi.ID = id;
                alergi.NOMBRE_ALERGIA = nombrealer;
                alergi.DESCRIPCION = descri;

                listaAlergias.Add(alergi);
            }
            return listaAlergias;
        }
        // GET: Alergias
        public ActionResult Index(int? i, string BuscarNombre)
        {
            var Aler = from e in ListaAlergias()
                           //orderby e.nombre
                       select e;
            if (!String.IsNullOrEmpty(BuscarNombre))
            {
                Aler = Aler.Where(c => c.NOMBRE_ALERGIA.ToLower().Contains(BuscarNombre.ToLower()));
            }
            return View(Aler.ToPagedList(i ?? 1, 3));
        }

        // GET: Alergias/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Alergias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alergias/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                try
                {
                    SistemaClinicoSoapWS.ClinicaWebServiceSoapClient alerWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                    Alergias aler = new Models.Alergias();
                    aler.NOMBRE_ALERGIA = collection["NOMBRE_ALERGIA"];
                    aler.DESCRIPCION = collection["DESCRIPCION"];
                    alerWS.InsertAlergia(aler.NOMBRE_ALERGIA, aler.DESCRIPCION);
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

        // GET: Alergias/Edit/5
        public ActionResult Edit(int? id)
        {
            List<Alergias> listaAler = ListaAlergias();
            if (id.HasValue)
            {
                var aler = listaAler.Single(m => m.ID == id);
                return View(aler);
            }
            return View();
        }

        // POST: Alergias/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updateAler = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            try
            {
                // REVISAR ESTP DESPUES
                List<Alergias> listaAler = ListaAlergias();
                var aler = listaAler.Single(m => m.ID == id);
                if (TryUpdateModel(aler))
                {
                    updateAler.UpdateAlergias(aler.ID, aler.NOMBRE_ALERGIA, aler.DESCRIPCION);
                    return RedirectToAction("Index");
                }
                return View(aler);
            }
            catch
            {
                return View();
            }
        }

        // GET: Alergias/Delete/5
        public ActionResult Delete(int? id)
        {
            List<Alergias> listaAlergias = ListaAlergias();
            if (id.HasValue)
            {
                var aler = listaAlergias.Single(m => m.ID == id);
                return View(aler);
            }
            return View();
        }

        // POST: Alergias/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient alerWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                List<Alergias> listaAlergias = ListaAlergias();
                var aler = listaAlergias.Single(m => m.ID == id);

                Alergias borraAler = new Models.Alergias();
                borraAler.NOMBRE_ALERGIA = aler.NOMBRE_ALERGIA.ToString();
                borraAler.DESCRIPCION = aler.DESCRIPCION.ToString();

                alerWS.EliminarAlergia(id);

                if (TryUpdateModel(aler))
                {
                    alerWS.EliminarAlergia(aler.ID);
                    return RedirectToAction("Index");
                }
                return View(aler);
            }
            catch
            {
                return View();
            }
        }
    }
}
