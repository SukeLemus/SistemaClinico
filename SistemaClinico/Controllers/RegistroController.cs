using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaClinico.Models;

namespace SistemaClinico.Controllers
{
    public class RegistroController : Controller
    {
        public static List<Direcciones> ListaDirecciones()
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient direccionesWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = direccionesWS.SelectIdDireccion();
            List<Direcciones> listaDir = new List<Direcciones>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID"].ToString());
                string nombre = dr["MUNICIPIO"].ToString();

                Direcciones dir = new Direcciones();
                dir.ID = id;
                dir.Municipio = nombre;
                listaDir.Add(dir);
            }
            return listaDir;
        }
        // GET: Registro2
        public ActionResult Index()
        {           
            return View();
        }
        public IEnumerable<SelectListItem> GetSelectListItems()
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient direccionesWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = direccionesWS.SelectIdDireccion();
            List<Direcciones> listaDir = new List<Direcciones>();
            var selectList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID"].ToString());
                string nombre = dr["MUNICIPIO"].ToString();
                Direcciones dir = new Direcciones();
                dir.ID = id;
                dir.Municipio = nombre;
                listaDir.Add(dir);
                selectList.Add(new SelectListItem
                {
                    Value = id.ToString(),
                    Text = nombre
                });
            }
            return selectList;
        }
        // GET: Registro2/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: Registro2/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Registro2/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, string Municipio)
        {         
            try
            {
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient swEnf = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                
                RegistroPaciente2 nuevoPaciente = new RegistroPaciente2();
                nuevoPaciente.NOMBRE = collection["NOMBRE"];
                nuevoPaciente.APELLIDO = collection["APELLIDO"];
                nuevoPaciente.DUI = collection["DUI"];
                nuevoPaciente.NIT = collection["NIT"];
                nuevoPaciente.GENERO = collection["GENERO"];
                nuevoPaciente.FECHA_NACIMIENTO = DateTime.Parse(collection["FECHA_NACIMIENTO"]);
                nuevoPaciente.TIPO_SANGRE = collection["TIPO_SANGRE"];
                nuevoPaciente.TELEFONO = collection["TELEFONO"];
                nuevoPaciente.CORREO = collection["CORREO"];
                nuevoPaciente.ID_DIRECCION = int.Parse(collection["Municipio"]);               
                nuevoPaciente.DIRECCION_COM = collection["DIRECCION_COM"];
                nuevoPaciente.ID_ROL = 1;
                nuevoPaciente.ESTADO = "ACTIVO";
                nuevoPaciente.USUARIO = collection["USUARIO"];
                nuevoPaciente.PASSWORD = collection["PASSWORD"];
                swEnf.InsertPaciente(nuevoPaciente.NOMBRE, nuevoPaciente.APELLIDO, nuevoPaciente.DUI, nuevoPaciente.NIT, nuevoPaciente.GENERO, nuevoPaciente.FECHA_NACIMIENTO, nuevoPaciente.TIPO_SANGRE, nuevoPaciente.TELEFONO,
                    nuevoPaciente.CORREO, nuevoPaciente.ID_DIRECCION, nuevoPaciente.DIRECCION_COM, nuevoPaciente.ESTADO, nuevoPaciente.USUARIO, nuevoPaciente.PASSWORD);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                // return View();
                return RedirectToAction("Index", "Home");

            }
        }
        // GET: Registro2/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        // POST: Registro2/Edit/5
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
        // GET: Registro2/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        // POST: Registro2/Delete/5
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
