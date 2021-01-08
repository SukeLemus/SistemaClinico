using SistemaClinico.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;

namespace SistemaClinico.Controllers
{
    public class EnfermedadesSintomasController : Controller
    {
        //[NonAction]
        //public List<EnfermedadSintoma> TodosLosEnfSint()
        //{
        //    List<EnfermedadSintoma> listaE = new List<EnfermedadSintoma>();
        //    SistemaClinicoSoapWS.ClinicaWebServiceSoapClient SWEnf = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
        //    DataSet ds = SWEnf.lista_enfermedades_sintomas();
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        int id = int.Parse(dr["ID_ENF_SINTOMAS"].ToString());
        //        int id_enf = int.Parse(dr["ID_ENFERMEDAD"].ToString());
        //        int id_sint = int.Parse(dr["ID_SINTOMA"].ToString());

        //        EnfermedadSintoma ef = new EnfermedadSintoma();
        //        ef.ID_ENF_SINTOMAS = id;
        //        ef.ID_ENFERMEDAD = id_enf;
        //        ef.ID_SINTOMA = id_sint;
        //        listaE.Add(ef);
        //    }
        //    return listaE;
        //}
        public List<EnfermedadSintoma> listaEF()
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient log2 = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            List<EnfermedadSintoma> listaS = new List<EnfermedadSintoma>();
            DataSet ds = log2.lista_enfermedades_sintomas_detail();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_ENF_SINTOMAS"].ToString());
                int idenf = int.Parse(dr["ID_ENFERMEDAD"].ToString());
                int idsint = int.Parse(dr["ID_SINTOMA"].ToString());

                EnfermedadSintoma sint = new EnfermedadSintoma();
                sint.ID_ENF_SINTOMAS = id;
                sint.ID_ENFERMEDAD = idenf;
                sint.ID_SINTOMA = idsint;
              
                listaS.Add(sint);

            }
            return listaS;
        }
        [HttpPost]
        public int confrepetido(int idenf, int idsint)
        {

            List<EnfermedadSintoma> enfsint = listaEF();
            int datorep = 0;
            //var datopaciente = enfsint.Single(m => m.ID_ENFERMEDAD == idenf && m.ID_SINTOMA == idsint);
            try
            {
                var comprobando = enfsint.Single(m => m.ID_ENFERMEDAD == idenf && m.ID_SINTOMA == idsint);
                if (comprobando != null)
                {
                    datorep = 1;
                }
                else
                {
                    datorep = 0;
                }
            }
            catch
            {
                    datorep = 0;

            }
            return datorep;


        }

        // GET: EnfermedadesSintomas
        public ActionResult Index()
        {
           
            return View();
        }

        // GET: EnfermedadesSintomas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EnfermedadesSintomas/Create
        public ActionResult Create()
        {

            //List<EnfermedadSintoma> listaE = new List<EnfermedadSintoma>();
            //SistemaClinicoSoapWS.ClinicaWebServiceSoapClient SWEnf = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            //DataSet ds6 = SWEnf.lista_enfermedades_sintomas();
            //foreach (DataRow dr6 in ds6.Tables[0].Rows)
            //{
            //    int id = int.Parse(dr6["ID_ENF_SINTOMAS"].ToString());
            //    int id_enf = int.Parse(dr6["ID_ENFERMEDAD"].ToString());
            //    int id_sint = int.Parse(dr6["ID_SINTOMA"].ToString());

            //    EnfermedadSintoma ef = new EnfermedadSintoma();
            //    ef.ID_ENF_SINTOMAS = id;
            //    ef.ID_ENFERMEDAD = id_enf;
            //    ef.ID_SINTOMA = id_sint;
            //    listaE.Add(ef);
            //}



            string nombreEnf = "";
            int MaxIdEnfermedad = 0;
            SistemaClinico.SistemaClinicoSoapWS.ClinicaWebServiceSoapClient swEnf = new SistemaClinico.SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            //SistemaClinicoSoapWS.ClinicaWebServiceSoapClient swEnf = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            DataSet ds = swEnf.MaxIdEnfermedad();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MaxIdEnfermedad = int.Parse(dr["MAX(ID_ENFERMEDAD)"].ToString());

            }

            DataSet ds2 = swEnf.nombreMax(MaxIdEnfermedad);
            foreach (DataRow dr2 in ds2.Tables[0].Rows)
            {
                nombreEnf = dr2["NOMBRE_ENFERMEDAD"].ToString();


            }
            DataSet ds3 = swEnf.lista_sintomas2();

            var selectList = new List<SelectListItem>();


            foreach (DataRow dr3 in ds3.Tables[0].Rows)
            {

                string id = dr3["ID_SINTOMA"].ToString();
                string name_sintoma = dr3["NOMBRE_SINTOMA"].ToString();


                selectList.Add(new SelectListItem
                {
                    Value = id,
                    Text = name_sintoma,



                }); ;


            }
            DataSet ds9 = swEnf.lista_enfermedades_sintomas_nombres(MaxIdEnfermedad);
           
            var selectList2 = new List<SelectListItem>();


            foreach (DataRow dr9 in ds9.Tables[0].Rows)
            {

                string nombre = dr9["NOMBRE_SINTOMA"].ToString();


                
                selectList2.Add(new SelectListItem
                {
                    //Value = id,
                    Text = nombre.ToString(),



                });

                
            }
            //DataSet ds10 = swEnf.lista_enfermedades_sintomas_nombres(int.Parse(selectList2.ToString()));
            //var selectList3 = new List<SelectListItem>();


            //foreach (DataRow dr10 in ds10.Tables[0].Rows)
            //{

            //    int id_sintoma3 = int.Parse(dr10["ID_SINTOMA"].ToString());
            //    string nombre = dr10["NOMBRE_SINTOMA"].ToString();


            //    selectList3.Add(new SelectListItem
            //    {
            //        //Value = id,
            //        Text = nombre.ToString(),



            //    }); 


            //}
            ViewData["chompipollo"] = selectList;
            ViewData["chompipollo2"] = selectList2;
            ViewData["max"] = MaxIdEnfermedad;
            ViewData["nombreEnf"] = nombreEnf;
            //ViewBag.ListaE = listaE;
            return View();
        }

        // POST: EnfermedadesSintomas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            //string nombreEnf = "";
            //int MaxIdEnfermedad = 0;
            SistemaClinico.SistemaClinicoSoapWS.ClinicaWebServiceSoapClient swEnf = new SistemaClinico.SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            ////SistemaClinicoSoapWS.ClinicaWebServiceSoapClient swEnf = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            //DataSet ds = swEnf.MaxIdEnfermedad();
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    MaxIdEnfermedad = int.Parse(dr["MAX(ID_ENFERMEDAD)"].ToString());
            //    ViewData["max"] = MaxIdEnfermedad;
            //}

            //DataSet ds2 = swEnf.nombreMax(MaxIdEnfermedad);
            //foreach (DataRow dr2 in ds2.Tables[0].Rows)
            //{
            //    nombreEnf = dr2["NOMBRE_ENFERMEDAD"].ToString();
            //    ViewData["nombreEnf"] = nombreEnf;

            //}



            //Agregando la lista sintomas
            //DataSet ds3 = swEnf.lista_sintomas2();

            //var selectList = new List<SelectListItem>();


            //foreach (DataRow dr3 in ds3.Tables[0].Rows)
            //{

            //    string id = dr3["ID_SINTOMA"].ToString();
            //    string name_sintoma = dr3["NOMBRE_SINTOMA"].ToString();


            //    selectList.Add(new SelectListItem
            //    {
            //        Value = id,
            //        Text = name_sintoma,



            //    }); ;
            //    ViewData["chompipollo"] = selectList;

            //}

           
            

            try
            {


                // TODO: Add insert logic here
                //SistemaClinicoSoapWS.ClinicaWebServiceSoapClient swEnf = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                int datorep = confrepetido(int.Parse(collection["ID_ENFERMEDAD"].ToString()), int.Parse(collection["ID_SINTOMA"].ToString()));
                if (datorep == 0)
                {
                    EnfermedadSintoma nuevosintoenfermedad = new EnfermedadSintoma();
                    nuevosintoenfermedad.ID_ENFERMEDAD = int.Parse(collection["ID_ENFERMEDAD"].ToString());
                    nuevosintoenfermedad.ID_SINTOMA = int.Parse(collection["ID_SINTOMA"].ToString());
                    swEnf.insertar_enfermedad_sintomas(nuevosintoenfermedad.ID_ENFERMEDAD, nuevosintoenfermedad.ID_SINTOMA);
                    return RedirectToAction("Create", "EnfermedadesSintomas");
                }else
                {
                    TempData["UserMessage"] = "ya existe ese sintoma en la enfermedad";
                    return RedirectToAction("Create", "EnfermedadesSintomas");

                }



            }
            catch
            {
                return View();
            }

        }

        // GET: EnfermedadesSintomas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EnfermedadesSintomas/Edit/5
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

        // GET: EnfermedadesSintomas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EnfermedadesSintomas/Delete/5
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
        public ActionResult Agregar(int id, string nombreEnf)
        {



            string nombreEnfer = "";

            SistemaClinico.SistemaClinicoSoapWS.ClinicaWebServiceSoapClient swEnf = new SistemaClinico.SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();


            DataSet ds2 = swEnf.nombreMax(id);
            foreach (DataRow dr2 in ds2.Tables[0].Rows)
            {
                nombreEnfer = dr2["NOMBRE_ENFERMEDAD"].ToString();


            }
            DataSet ds3 = swEnf.lista_sintomas2();

            var selectList = new List<SelectListItem>();


            foreach (DataRow dr3 in ds3.Tables[0].Rows)
            {

                string idsint = dr3["ID_SINTOMA"].ToString();
                string name_sintoma = dr3["NOMBRE_SINTOMA"].ToString();


                selectList.Add(new SelectListItem
                {
                    Value = idsint,
                    Text = name_sintoma,



                }); ;


            }
            DataSet ds9 = swEnf.lista_enfermedades_sintomas_nombres(id);

            var selectList2 = new List<SelectListItem>();


            foreach (DataRow dr9 in ds9.Tables[0].Rows)
            {

                string nombre = dr9["NOMBRE_SINTOMA"].ToString();



                selectList2.Add(new SelectListItem
                {
                    //Value = id,
                    Text = nombre.ToString(),



                });


            }

            ViewData["chompipollo"] = selectList;
            ViewData["chompipollo2"] = selectList2;
            ViewData["max"] = id;
            ViewData["nombreEnf"] = nombreEnfer;
            //ViewBag.ListaE = listaE;
            return View();
        }

        // POST: EnfermedadesSintomas/Create
        [HttpPost]
        public ActionResult Agregar(int id, string nombreEnf, FormCollection collection)
        {


            SistemaClinico.SistemaClinicoSoapWS.ClinicaWebServiceSoapClient swEnf = new SistemaClinico.SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            ViewData["idenf"] = id;
            ViewData["Enfermedad"] = nombreEnf;

            try
            {
                int datorep = confrepetido(int.Parse(collection["ID_ENFERMEDAD"].ToString()), int.Parse(collection["ID_SINTOMA"].ToString()));
                if (datorep == 0)
                {

                    EnfermedadSintoma nuevosintoenfermedad = new EnfermedadSintoma();
                nuevosintoenfermedad.ID_ENFERMEDAD = int.Parse(collection["ID_ENFERMEDAD"].ToString());
                nuevosintoenfermedad.ID_SINTOMA = int.Parse(collection["ID_SINTOMA"].ToString());
                swEnf.insertar_enfermedad_sintomas(nuevosintoenfermedad.ID_ENFERMEDAD, nuevosintoenfermedad.ID_SINTOMA);
                return RedirectToAction("Agregar", "EnfermedadesSintomas", new { id = ViewData["idenf"], nombreEnf = ViewData["Enfermedad"] });
                }
                else
                {
                    TempData["UserMessage"] = "ya existe ese sintoma en la enfermedad";
                    return RedirectToAction("Agregar", "EnfermedadesSintomas", new { id = ViewData["idenf"], nombreEnf = ViewData["Enfermedad"] });
                }
            }
            catch
            {
                return View();
            }

        }
    }
    
}
