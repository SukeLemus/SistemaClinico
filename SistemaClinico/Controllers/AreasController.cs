using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Rotativa;
using SistemaClinico.Models;

namespace SistemaClinico.Controllers
{
    public class AreasController : Controller
    {
        cambios salvavida
        public static List<Area> ListaAreas()
        {
            List<Area> listaAreas = new List<Area>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient areaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = areaWS.ListaAreas();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_AREA"].ToString());
                string nombre = dr["NOMBRE_AREA"].ToString();
               
                Area area1 = new Area();
                area1.ID = id;
                area1.NOMBRE_AREA = nombre;
               
                listaAreas.Add(area1);
            }
            return listaAreas;
        }

        // GET: Areas
        public ActionResult Index(int? i, string BuscarNombre)
        {
            var Area = from e in ListaAreas()
                              //orderby e.nombre
                          select e;
            if (!String.IsNullOrEmpty(BuscarNombre))
            {
                Area = Area.Where(c => c.NOMBRE_AREA.ToLower().Contains(BuscarNombre.ToLower()));
            }
            return View(Area.ToPagedList(i ?? 1, 3));
      
        }

        // GET: Areas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Areas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Areas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                try
                {
                    SistemaClinicoSoapWS.ClinicaWebServiceSoapClient areaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                    Area area = new Models.Area();
                    area.NOMBRE_AREA = collection["NOMBRE_AREA"];     
                    areaWS.InsertArea(area.NOMBRE_AREA);
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

        // GET: Areas/Edit/5
        public ActionResult Edit(int? id)
        {
            List<Area> listaAreas = ListaAreas();
            if (id.HasValue)
            {
                var area = listaAreas.Single(m => m.ID == id);
                return View(area);
            }
            return View();
        }

        // POST: Areas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updateArea = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            try
            {
                // REVISAR ESTP DESPUES
                List<Area> listaAreas = ListaAreas();
                var area = listaAreas.Single(m => m.ID == id);
                if (TryUpdateModel(area))
                {
                    updateArea.UpdateAreas(area.ID, area.NOMBRE_AREA);
                    return RedirectToAction("Index");
                }
                return View(area);
            }
            catch
            {
                return View();
            }
        }

        // GET: Areas/Delete/5
        public ActionResult Delete(int? id)
        {
            List<Area> listaAreas = ListaAreas();
            if (id.HasValue)
            {
                var area = listaAreas.Single(m => m.ID == id);
                return View(area);
            }
            return View();
        }

        // POST: Areas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient areaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                List<Area> listaArea = ListaAreas();
                var area = listaArea.Single(m => m.ID == id);

                Area borraArea = new Models.Area();
                borraArea.NOMBRE_AREA = area.NOMBRE_AREA.ToString();
           
                areaWS.EliminarArea(id);

                if (TryUpdateModel(area))
                {
                    areaWS.EliminarArea(area.ID);
                    return RedirectToAction("Index");
                }
                return View(area);
            }
            catch
            {
                return View();
            }
        }
    }
}
