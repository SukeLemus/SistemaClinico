using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaClinico.Models;

namespace SistemaClinico.Controllers
{
    public class DepartamentoController : Controller
    {

        //public static List<Area> listaAreas(int id)
        //{
        //    List<Area> listaDepas = new List<Area>();
        //    SistemaClinicoSoapWS.ClinicaWebServiceSoapClient dptoWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
        //    DataSet ds = dptoWS.NombreArea_Departamento(id);
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        //    int id = int.Parse(dr["ID"].ToString());
        //        //    string nombre = dr["NOMBRE_AREA"].ToString();

        //        Area arre = new Area();
               
        //        arre.NOMBRE_AREA = dr["NOMBRE_AREA"].ToString();
                

        //        listaDepas.Add(arre);
        //    }
            
        //    return listaDepas;
        //}


        public static List<Departamento> ListaDepartamentos()
        {
            List<Departamento> listaDepas = new List<Departamento>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient dptoWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = dptoWS.ListaDepa();
            
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //    int id = int.Parse(dr["ID"].ToString());
                //    string nombre = dr["NOMBRE_AREA"].ToString();

                Departamento depa = new Departamento();
                depa.ID= int.Parse(dr["ID_DEPARTAMENTO"].ToString());
                depa.NOMBRE_DEPARTAMENTO = dr["NOMBRE_DEPARTAMENTO"].ToString();
                depa.DESCRIPCION= dr["DESCRIPCION"].ToString();
                depa.ESTADO= dr["ESTADO"].ToString();
                depa.ID_AREA= int.Parse(dr["ID_AREA"].ToString());
                //Area are = new Area();

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
        public ActionResult Index()
        {
            SistemaClinico.SistemaClinicoSoapWS.ClinicaWebServiceSoapClient swEnf = new SistemaClinico.SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            var Departamento = from e in ListaDepartamentos()
                            orderby e.NOMBRE_DEPARTAMENTO
                            select e;
            //List<Departamento> listaD = new List<Departamento>();

            //DataSet ds = swEnf.ListaDepa();
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    MaxIdEnfermedad = int.Parse(dr["MAX(ID_ENFERMEDAD)"].ToString());

            //}
            //DataSet ds2 = swEnf.nombreMax(MaxIdEnfermedad);
            //foreach (DataRow dr2 in ds2.Tables[0].Rows)
            //{
            //    nombreEnf = dr2["NOMBRE_ENFERMEDAD"].ToString();


            //}

            return View(Departamento);
        }

        // GET: Departamento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Departamento/Create
        public ActionResult Create()
        {
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Departamento/Edit/5
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

        // GET: Departamento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Departamento/Delete/5
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
