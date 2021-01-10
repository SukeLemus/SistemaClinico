using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data;
using SistemaClinico.Models;

namespace SistemaClinico.Controllers
{
    public class UsuariosPersonalController : Controller
    {

        public static List<UsuarioPersonalJoin> TodosElPersonal()
        {
            List<UsuarioPersonalJoin> listaS = new List<UsuarioPersonalJoin>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient per = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = per.lista_personal2();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_PERSONAL"].ToString());
                string nombres = dr["NOMBRES"].ToString();
                string apellidos = dr["APELLIDOS"].ToString();
                string municipio = dr["MUNICIPIO"].ToString();
                string nombre_consultorio = dr["NOMBRE_CONSULTORIO"].ToString();
                string nombre_departamento = dr["NOMBRE_DEPARTAMENTO"].ToString();
                string nombre_area = dr["NOMBRE_AREA"].ToString();
                string nombre_rol = dr["NOMBRE_ROL"].ToString();
                UsuarioPersonalJoin US = new UsuarioPersonalJoin();
                US.ID_PERSONAL = id;
                US.NOMBRES = nombres;
                US.APELLIDOS = apellidos;
                US.MUNICIPIO = municipio;
                US.NOMBRE_CONSULTORIO = nombre_consultorio;
                US.NOMBRE_DEPARTAMENTO = nombre_departamento;
                US.NOMBRE_AREA = nombre_area;
                US.NOMBRE_ROL = nombre_rol;
                listaS.Add(US);
            }
            return listaS;

        }

        //public static List<UsuarioPersonal> TodosMedicamentos()
        //{
        //    List<UsuarioPersonal> listaS = new List<UsuarioPersonal>();
        //    SistemaClinicoSoapWS.ClinicaWebServiceSoapClient per = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
        //    DataSet ds = per.lista_personal();
        //    DataSet ds2 = per.SelectIdDireccionPaciente();
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        int id = int.Parse(dr["ID_PERSONAL"].ToString());
        //        string nombres = dr["NOMBRES"].ToString();
        //        string apellidos = dr["APELLIDOS"].ToString();
        //        string dui = dr["DUI"].ToString();
        //        string nit = dr["NIT"].ToString();
        //        string genero = dr["GENERO"].ToString();
        //        string fecha = dr["FECHA_NACIMIENTO"].ToString();
        //        string id_departamento = dr["ID_DEPARTAMENTO"].ToString();
        //        string telefono = dr["TELEFONO"].ToString();

        //        int id_rol = int.Parse(dr["ID_ROL"].ToString());
        //        string correo = dr["CORREO"].ToString();
        //        string estado = dr["ESTADO"].ToString();
        //        int id_direccion = int.Parse(dr["ID_DIRECCION"].ToString());
        //        string direccion_com = dr["DIRECCION_COM"].ToString();
        //        int id_consultorio = int.Parse(dr["ID_CONSULTORIO"].ToString());

        //        string usuario = dr["USUARIO"].ToString();
        //        string password = dr["PASSWORD"].ToString();
        //        UsuarioPersonal US = new UsuarioPersonal();
        //        US.id = id;
        //        US.NOMBRES = nombres;
        //        US.APELLIDOS = apellidos;
        //        US.DUI = dui;
        //        US.NIT = nit;
        //        US.GENERO = genero;
        //        US.fecha = fecha;
        //        US.ID_DEPARTAMENTO = id_departamento;
        //        US.TELEFONO = telefono;
        //        US.ID_ROL = id_rol;
        //        US.CORREO = correo;
        //        US.ESTADO = estado;
        //        US.ID_DIRECCION = id_direccion;
        //        US.DIRECCION_COM = direccion_com;
        //        US.ID_CONSULTORIO = id_consultorio;
        //        US.USUARIO = usuario;
        //        US.PASSWORD = password;
        //        listaS.Add(US);
        //    }
        //    return listaS;

        //}
        // GET: UsuariosPersonal
        public ActionResult Index(int? i, string BuscarNombre)
        {
            var personal = from e in TodosElPersonal()
                                  //orderby e.nombre
                              select e;
            if (!String.IsNullOrEmpty(BuscarNombre))
            {
                personal = personal.Where(c => c.NOMBRES.ToLower().Contains(BuscarNombre.ToLower()));
            }
            return View(personal.ToPagedList(i ?? 1, 3));
        }

        // GET: UsuariosPersonal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuariosPersonal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosPersonal/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosPersonal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuariosPersonal/Edit/5
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

        // GET: UsuariosPersonal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuariosPersonal/Delete/5
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
