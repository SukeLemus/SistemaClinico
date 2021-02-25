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
    public class EnfermedadesController : Controller
    {

        [NonAction]
        public List<EnfermedadSintoma> TodosLosEnfSint()
        {
            List<EnfermedadSintoma> listaE = new List<EnfermedadSintoma>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient SWEnf = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = SWEnf.lista_enfermedades_sintomas_detail();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id_enfsint = int.Parse(dr["ID_ENF_SINTOMAS"].ToString());
                int id_enf = int.Parse(dr["ID_ENFERMEDAD"].ToString());
                int id_sint = int.Parse(dr["ID_SINTOMA"].ToString());

                EnfermedadSintoma ef = new EnfermedadSintoma();
                ef.ID_ENF_SINTOMAS = id_enfsint;
                ef.ID_ENFERMEDAD = id_enf;
                ef.ID_SINTOMA = id_sint;
                listaE.Add(ef);
            }
            return listaE;
        }
        [NonAction]
        public List<Enfermedad> TodosLosEnfermedades()
        {
            List<Enfermedad> listaE = new List<Enfermedad>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient SWEnf = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = SWEnf.lista_enfermedades();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_ENFERMEDAD"].ToString());
                string nombre = dr["NOMBRE_ENFERMEDAD"].ToString();
                string descripcion = dr["DESCRIPCION"].ToString();
                Enfermedad ef = new Enfermedad();
                ef.id = id;
                ef.nombre_enfermedad = nombre;
                ef.descripcion = descripcion;
                listaE.Add(ef);
            }
            return listaE;
        }
        // GET: Enfermedades
        public ActionResult Index(int? i, string BuscarNombre)
        {
            var Enfermedad = from e in SintList()
                                 //orderby e.nombre
                             select e;
            if (!String.IsNullOrEmpty(BuscarNombre))
            {
                Enfermedad = Enfermedad.Where(c => c.nombre_enfermedad.ToLower().Contains(BuscarNombre.ToLower()));
            }
            return View(Enfermedad.ToPagedList(i ?? 1, 5));
        }
        // GET: Enfermedades/Details/5
        public ActionResult Details(int id)
        {


            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient sinto = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = sinto.lista_enfermedades_sintomas_nombres(id);
            DataSet ds2 = sinto.nombreMax(id);
            string nom = "";

            List<Sintoma> nombreSintomas = new List<Sintoma>();


            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Sintoma sintomaX = new Sintoma();
                sintomaX.nombre = dr["NOMBRE_SINTOMA"].ToString();

                nombreSintomas.Add(sintomaX);

            }

            foreach (DataRow dr2 in ds2.Tables[0].Rows)
            {
                nom = dr2["NOMBRE_ENFERMEDAD"].ToString();
            }

            ViewData["Sintomas"] = nombreSintomas;
            ViewData["Enfermedad"] = nom;
            ViewBag.sint = nombreSintomas;

            return View();

        }
        // GET: Enfermedades/Create
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
        public ActionResult DeleteSintEnf(int? id, int? idenf, string nSint, string nEnf)
        {
            //int iid = int.Parse(id.ToString());
            List<EnfermedadSintoma> sintList = TodosLosEnfSint();
            if (id.HasValue)
            {
                var sint = sintList.Single(m => m.ID_ENFERMEDAD == idenf & m.ID_SINTOMA == id);
                ViewData["nombreSint"] = nSint;
                ViewData["nombreEnf"] = nEnf;
                return View(sint);
            }
            return View();
        }
        [HttpPost]
        public ActionResult DeleteSintEnf(int id, int idenf, string nSint, string nEnf, FormCollection collection)
        {
            try
            {
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient sinto = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                List<EnfermedadSintoma> sintList = TodosLosEnfSint();
                var sint = sintList.Single(m => m.ID_SINTOMA == id & m.ID_ENFERMEDAD == idenf);
                EnfermedadSintoma nuevoSin = new Models.EnfermedadSintoma();
                nuevoSin.ID_ENF_SINTOMAS = sint.ID_ENF_SINTOMAS;
                nuevoSin.ID_ENFERMEDAD = sint.ID_ENFERMEDAD;
                nuevoSin.ID_SINTOMA = sint.ID_SINTOMA;

                sinto.eliminar_enfermedad_sintoma(id);
                if (TryUpdateModel(sintList))
                {
                    sinto.eliminar_enfermedad_sintoma(sint.ID_ENF_SINTOMAS);
                    //DeleteSintEnf(sint.ID_ENFERMEDAD);
                    return RedirectToAction("Index");
                }
                return View(sint);
            }
            catch
            {
                return View();
            }

        }

        public ActionResult EditarEfnSint(int id)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient sinto = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = sinto.lista_enfermedades_sintomas_nombres(id);
            DataSet ds2 = sinto.nombreMax(id);
            string nom = "";
            int idenf = 0;

            List<Sintoma> nombreSintomas = new List<Sintoma>();


            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Sintoma sintomaX = new Sintoma();
                sintomaX.nombre = dr["NOMBRE_SINTOMA"].ToString();
                sintomaX.id = int.Parse(dr["ID_SINTOMA"].ToString());

                nombreSintomas.Add(sintomaX);

            }

            foreach (DataRow dr2 in ds2.Tables[0].Rows)
            {
                nom = dr2["NOMBRE_ENFERMEDAD"].ToString();
                idenf = id;
            }

            ViewData["Sintomas"] = nombreSintomas;
            ViewData["Enfermedad"] = nom;
            ViewData["idenf"] = idenf;
            ViewBag.sint = nombreSintomas;

            //return RedirectToAction("Create", "EnfermedadesSintomas", new { id = idenf, nombre = nombreSintomas });
            return View();
        }
        // POST: Enfermedades/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            DataSet dataSetUltimaEnfermedad = new DataSet();//va tener el id de la ultima enfermedad ingresada
            int MaxIdEnfermedad = 0;
            string nombreEnfermedad = "";

            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                try
                {
                    SistemaClinicoSoapWS.ClinicaWebServiceSoapClient swEnf = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

                    Enfermedad nuevoSin = new Enfermedad();
                    nuevoSin.nombre_enfermedad = collection["NOMBRE_ENFERMEDAD"];
                    nuevoSin.descripcion = collection["DESCRIPCION"];

                    nombreEnfermedad = collection["NOMBRE_ENFERMEDAD"];

                    /*dataSetUltimaEnfermedad = */
                    swEnf.insertar_enfermedad(nuevoSin.nombre_enfermedad, nuevoSin.descripcion);




                    // return RedirectToAction("Create", "EnfermedadesSintomas", new { @id = MaxIdEnfermedad });

                }
                catch
                {
                    // return View();
                    // return RedirectToAction("Create", "EnfermedadesSintomas", new { @id = MaxIdEnfermedad });
                    Response.Redirect("Index");

                }

            }// fin del if

            else
            {
                Response.Redirect("Index");
            }

            return RedirectToActionPermanent("Create", "EnfermedadesSintomas", new { id = MaxIdEnfermedad, nombre = nombreEnfermedad });
        }
        // GET: Enfermedades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                List<Enfermedad> enfList = TodosLosEnfermedades();
                if (id.HasValue)
                {
                    var enfe = enfList.Single(m => m.id == id);
                    return View(enfe);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
          
        }
        // POST: Enfermedades/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updateEnfermedad = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            try
            {
                List<Enfermedad> enfList = TodosLosEnfermedades();
                var enfe = enfList.Single(m => m.id == id);

                if (TryUpdateModel(enfe))
                {
                    updateEnfermedad.actualizar_enfermedad(enfe.id, enfe.nombre_enfermedad, enfe.descripcion);
                    return RedirectToAction("EditarEfnSint", new { id = id });
                }
                return View(enfe);
            }
            catch
            {
                return View();
            }
        }
        public static List<Enfermedad> SintList()
        {
            List<Enfermedad> listaS = new List<Enfermedad>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient sinto = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = sinto.lista_enfermedades();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_ENFERMEDAD"].ToString());
                string nombre = dr["NOMBRE_ENFERMEDAD"].ToString();
                string descripcion = dr["DESCRIPCION"].ToString();
                Enfermedad sint = new Enfermedad();
                sint.id = id;
                sint.nombre_enfermedad = nombre;
                sint.descripcion = descripcion;
                listaS.Add(sint);
            }
            return listaS;
        }
        // GET: Enfermedades/Delete/5
        public ActionResult Delete(int? Id)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(4))
            {
                List<Enfermedad> sintList2 = TodosLosEnfermedades();
                if (Id.HasValue)
                {
                    var sint2 = sintList2.Single(m => m.id == Id);
                    return View(sint2);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }
        // POST: Enfermedades/Delete/5
        [HttpPost]
        public ActionResult Delete(int Id, FormCollection collection)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient swEnf = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            try
            {
                List<Enfermedad> EnftList = SintList();
                var enf = EnftList.Single(m => m.id == Id);
                Enfermedad nuevoEnf = new Enfermedad();
                //////nuevoEnf.Id = nuevoEnf.Id;
                nuevoEnf.nombre_enfermedad = enf.nombre_enfermedad.ToString();
                nuevoEnf.descripcion = enf.descripcion.ToString();
                swEnf.eliminar_enfermedad(enf.id);
                if (TryUpdateModel(enf))
                {
                    swEnf.eliminar_enfermedad(enf.id);
                    return RedirectToAction("Index");
                }
                return View(enf);
            }
            catch
            {
                return View();
            }
        }
        //[NonAction]
    }
}
