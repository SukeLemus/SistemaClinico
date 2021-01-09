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
    public class SintomasController : Controller
    {      
        public static List<Sintoma> SintList()
        {
            List<Sintoma> listaS = new List<Sintoma>();     
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient sinto = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = sinto.lista_sintomas();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_SINTOMA"].ToString());
                string nombre = dr["NOMBRE_SINTOMA"].ToString();
                string descripcion = dr["DESCRIPCION_SINTOMA"].ToString();
                Sintoma sint = new Sintoma();
                sint.id = id;
                sint.nombre = nombre;
                sint.descripcion = descripcion;
                listaS.Add(sint);
            }
            return listaS;
        }
        // GET: Sintomas
        public ActionResult Index(int? i, string BuscarNombre)
        {
            var Sintoma = from e in SintList()
                              //orderby e.nombre
                          select e;
            if (!String.IsNullOrEmpty(BuscarNombre))
            {
                Sintoma = Sintoma.Where(c => c.nombre.ToLower().Contains(BuscarNombre.ToLower()));
            }
            return View(Sintoma.ToPagedList(i ?? 1, 3));
            //return View();
        }
        public ActionResult Reporte2(int? i, string BuscarNombre)
        {
            var Sintoma = from e in SintList()
                              //orderby e.nombre
                          select e;
            if (!String.IsNullOrEmpty(BuscarNombre))
            {
                Sintoma = Sintoma.Where(c => c.nombre.ToLower().Contains(BuscarNombre.ToLower()));
            }
            return new ViewAsPdf(Sintoma.ToPagedList(i ?? 1, 1000))
            {
                //PageSize = Rotativa.Options.Size.A4,
                FileName = "ReporteTodosLosSintomas.pdf" //para que se abra en otra pestaña y se baja
                //,PageMargins = new Rotativa.Options.Margins(40, 10, 10, 10)
            };
            //return View();
        }
        public ActionResult ReporteSintomas(int? i, string BuscarNombre)
        {
            var Sintoma = from e in SintList()
                              //orderby e.nombre
                          select e;
            if (!String.IsNullOrEmpty(BuscarNombre))
            {
                Sintoma = Sintoma.Where(c => c.nombre.ToLower().Contains(BuscarNombre.ToLower()));
            }
            return new ViewAsPdf(Sintoma.ToPagedList(i ?? 1, 50))
            {
                //PageSize = Rotativa.Options.Size.A4,
                FileName = "ReporteTodosLosSintomas.pdf" //para que se abra en otra pestaña y se baja
                //,PageMargins = new Rotativa.Options.Margins(40, 10, 10, 10)
            };
            //return View();
        }
        [NonAction]
        public List<Sintoma> TodosLosSintomas()
        {
            List<Sintoma> listaS = new List<Sintoma>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient sinto = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = sinto.lista_sintomas();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_SINTOMA"].ToString());
                string nombre = dr["NOMBRE_SINTOMA"].ToString();
                string descripcion = dr["DESCRIPCION_SINTOMA"].ToString();
                Sintoma sint = new Sintoma();
                sint.id = id;
                sint.nombre = nombre;
                sint.descripcion = descripcion;
                listaS.Add(sint);
            }
            return listaS;
        }
        // GET: Sintomas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: Sintomas/Create
        public ActionResult Create()
        {
            return View();
        }
        public void precargarCreate()
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
            }
        }
        // POST: Sintomas/Create
        [HttpPost]       
        public ActionResult Create(FormCollection collection)
        {         
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                try
                {
                    SistemaClinicoSoapWS.ClinicaWebServiceSoapClient sinto = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                    Sintoma nuevoSin = new Models.Sintoma();
                    nuevoSin.nombre = collection["nombre"];
                    nuevoSin.descripcion = collection["descripcion"];
                    sinto.insertar_sintomas(nuevoSin.nombre, nuevoSin.descripcion);                
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
        // GET: Sintomas/Edit/5
        public ActionResult Edit(int? id)
        {
            List<Sintoma> sintList = TodosLosSintomas();
            if (id.HasValue)
            {
                var sint = sintList.Single(m => m.id == id);
                return View(sint);
            }                
            return View();
        }
        // POST: Sintomas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {            
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updateSintoma = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            try
            {
                // REVISAR ESTP DESPUES
                List<Sintoma> sintList = SintList();
                var sint = sintList.Single(m => m.id == id);
                if (TryUpdateModel(sint))
                {
                    updateSintoma.actualizar_sintomas(sint.id, sint.nombre, sint.descripcion);
                    return RedirectToAction("Index");
                }
                return View(sint);
            }
            catch
            {
                return View();
            }
        }
        // GET: Sintomas/Delete/5
        public ActionResult Delete(int? id)
        {
            List<Sintoma> sintList = TodosLosSintomas();
            if(id.HasValue)
            {
                var sint = sintList.Single(m => m.id == id);
                return View(sint);
            }          
                       return View();
        }
        // POST: Sintomas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient sinto = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                List<Sintoma> sintList = SintList();
                var sint = sintList.Single(m => m.id == id);

                Sintoma nuevoSin = new Models.Sintoma();
                nuevoSin.nombre = sint.nombre.ToString();
                nuevoSin.descripcion = sint.descripcion.ToString();
                sinto.eliminar_sintomas(id);

                if (TryUpdateModel(sint))
                {
                    sinto.eliminar_sintomas(sint.id);
                    return RedirectToAction("Index");
                }
                return View(sint);
            }
            catch
            {
                return View();
            }
        }
    }
}
