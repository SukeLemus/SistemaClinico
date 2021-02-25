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
    public class CirugiasController : Controller
    {

        public static List<Cirugias> ListaCirugias()
        {
            List<Cirugias> listaCirugias = new List<Cirugias>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient ciruWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = ciruWS.ListaCirugias();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_CIRUGIA"].ToString());
                string nombreciru = dr["NOMBRE_CIRUGIA"].ToString();
                string descri = dr["DESCRIPCION"].ToString();

                Cirugias ciru = new Cirugias();
                ciru.ID = id;
                ciru.NOMBRE_CIRUGIA = nombreciru;
                ciru.DESCRIPCION = descri;

                listaCirugias.Add(ciru);
            }
            return listaCirugias;
        }
        // GET: Cirugias
        public ActionResult Index(int? i, string BuscarNombre)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                var Ciru = from e in ListaCirugias()
                               //orderby e.nombre
                           select e;
                if (!String.IsNullOrEmpty(BuscarNombre))
                {
                    Ciru = Ciru.Where(c => c.NOMBRE_CIRUGIA.ToLower().Contains(BuscarNombre.ToLower()));
                }
                return View(Ciru.ToPagedList(i ?? 1, 3));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
          
        }

        // GET: Cirugias/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cirugias/Create
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

        // POST: Cirugias/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                try
                {
                    SistemaClinicoSoapWS.ClinicaWebServiceSoapClient CiruWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                    Cirugias ciru = new Models.Cirugias();
                    ciru.NOMBRE_CIRUGIA = collection["NOMBRE_CIRUGIA"];
                    ciru.DESCRIPCION = collection["DESCRIPCION"];
                    CiruWS.InsertCirugia(ciru.NOMBRE_CIRUGIA, ciru.DESCRIPCION);
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

        // GET: Cirugias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                List<Cirugias> listaCiru = ListaCirugias();
                if (id.HasValue)
                {
                    var ciru = listaCiru.Single(m => m.ID == id);
                    return View(ciru);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

        // POST: Cirugias/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updateCiru = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            try
            {
                // REVISAR ESTP DESPUES
                List<Cirugias> listciru = ListaCirugias();
                var ciru = listciru.Single(m => m.ID == id);
                if (TryUpdateModel(ciru))
                {
                    updateCiru.UpdateCirugia(ciru.ID, ciru.NOMBRE_CIRUGIA, ciru.DESCRIPCION);
                    return RedirectToAction("Index");
                }
                return View(ciru);
            }
            catch
            {
                return View();
            }
        }

        // GET: Cirugias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                List<Cirugias> listaCiru = ListaCirugias();
                if (id.HasValue)
                {
                    var ciru = listaCiru.Single(m => m.ID == id);
                    return View(ciru);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        
        }

        // POST: Cirugias/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient ciruWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                List<Cirugias> listaciru = ListaCirugias();
                var ciru = listaciru.Single(m => m.ID == id);

                Cirugias borraCiru = new Models.Cirugias();
                borraCiru.NOMBRE_CIRUGIA = ciru.NOMBRE_CIRUGIA.ToString();
                borraCiru.DESCRIPCION = ciru.DESCRIPCION.ToString();

                ciruWS.EliminarCirugia(id);

                if (TryUpdateModel(ciru))
                {
                    ciruWS.EliminarCirugia(ciru.ID);
                    return RedirectToAction("Index");
                }
                return View(ciru);
            }
            catch
            {
                return View();
            }
        }
    }
}
