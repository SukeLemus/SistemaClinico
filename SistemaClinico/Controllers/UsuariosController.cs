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
    public class UsuariosController : Controller
    {
        public static List<UsuarioMunicipio> TodosUsuarioMunicipio()
        {
            List<UsuarioMunicipio> listaS = new List<UsuarioMunicipio>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient med = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = med.SelectIdDireccionPaciente();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id_paciente = int.Parse(dr["ID_PACIENTE"].ToString());
                int id_direccion = int.Parse(dr["ID_DIRECCION"].ToString());
                string nombre = dr["NOMBRE"].ToString();
                string apellido = dr["APELLIDO"].ToString();
                string telefono = dr["TELEFONO"].ToString();
                string municipio = dr["MUNICIPIO"].ToString();
                string direccion_com = dr["DIRECCION_COM"].ToString();

                UsuarioMunicipio US = new UsuarioMunicipio();
                US.ID_PACIENTE = id_paciente;
                US.ID_DIRECCION = id_direccion;
                US.NOMBRE = nombre;
                US.APELLIDO = apellido;
                US.TELEFONO = telefono;
                US.DIRECCION_COM = direccion_com;
                US.MUNICIPIO = municipio;

                listaS.Add(US);
            }
            return listaS;

        }

        public static List<Usuario> TodosUsuarios()
        {
            List<Usuario> listaS = new List<Usuario>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient med = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = med.lista_paciente();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_PACIENTE"].ToString());
                string nombre = dr["NOMBRE"].ToString();
                string apellido = dr["APELLIDO"].ToString();
                string dui = dr["DUI"].ToString();
                string nit = dr["NIT"].ToString();
                string genero = dr["GENERO"].ToString();
                //string fecha = dr["FECHA_NACIMIENTO"].ToString();
                string tipo_sangre = dr["TIPO_SANGRE"].ToString();
                string telefono = dr["TELEFONO"].ToString();
                string correo = dr["CORREO"].ToString();
                int id_direccion = int.Parse(dr["ID_DIRECCION"].ToString());
                string direccion_com = dr["DIRECCION_COM"].ToString();
                int id_rol = int.Parse(dr["ID_ROL"].ToString());
                string estado = dr["ESTADO"].ToString();
                string usuario = dr["USUARIO"].ToString();
                string password = dr["PASSWORD"].ToString();
                Usuario US = new Usuario();
                US.id = id;
                US.NOMBRE = nombre;
                US.APELLIDO = apellido;
                US.DUI = dui;
                US.NIT = nit;
                US.GENERO = genero;
                //US.fecha = fecha;
                US.TIPO_SANGRE = tipo_sangre;
                US.TELEFONO = telefono;
                US.CORREO = correo;
                US.ID_DIRECCION = id_direccion;
                US.DIRECCION_COM = direccion_com;
                US.ID_ROL = id_rol;
                US.ESTADO = estado;
                US.USUARIO = usuario;
                US.PASSWORD = password;
                listaS.Add(US);
            }
            return listaS;

        }

        // GET: Usuarios
        public ActionResult Index(int? i, string BuscarNombre)
        {
            var usu = from e in TodosUsuarioMunicipio()
                                  //orderby e.nombre
                              select e;
            if (!String.IsNullOrEmpty(BuscarNombre))
            {
                usu = usu.Where(c => c.NOMBRE.ToLower().Contains(BuscarNombre.ToLower()));
            }
            return View(usu.ToPagedList(i ?? 1, 3));
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
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

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuarios/Edit/5
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

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
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
