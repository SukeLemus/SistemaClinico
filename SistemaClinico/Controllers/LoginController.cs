using Rotativa;
using SistemaClinico.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaClinico.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Print3()
        {
            return new ActionAsPdf("Login", new { nombre = "Pedrito2" })
            {
                FileName = "test2.pdf"
            };
        }
        public ActionResult LoginV()
        {
            return View();
        }
        public List<LoginPaciente> LlenandoPacientes()
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient log2 = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            List<LoginPaciente> listaS = new List<LoginPaciente>();
            DataSet ds = log2.TodoslosPacientes();
            DataSet ds2 = log2.TodosElPersonal();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_PACIENTE"].ToString());
                string nombre = dr["NOMBRE"].ToString();
                string apellido = dr["APELLIDO"].ToString();
                string dui = dr["DUI"].ToString();
                string nit = dr["NIT"].ToString();
                string genero = dr["GENERO"].ToString();
                //DateTime fecha = DateTime.Parse(dr["FECHA_NACIMIENTO"].ToString());
                string sangre = dr["TIPO_SANGRE"].ToString();
                string tel = dr["TELEFONO"].ToString();
                string correo = dr["CORREO"].ToString();
                int id_direccion = int.Parse(dr["ID_DIRECCION"].ToString());
                string dir_com = dr["DIRECCION_COM"].ToString();
                int id_rol = int.Parse(dr["ID_ROL"].ToString());
                string estado = dr["ESTADO"].ToString();
                string usu = dr["USUARIO"].ToString();
                string pass = dr["PASSWORD"].ToString();             
                LoginPaciente sint = new LoginPaciente();
                sint.ID_PACIENTE = id;
                sint.NOMBRE = nombre;
                sint.APELLIDO = apellido;
                sint.DUI = dui;
                sint.NIT = nit;
                sint.GENERO = genero;
                //sint.FECHA_NACIMIENTO = fecha;
                sint.TIPO_SANGRE = sangre;
                sint.TELEFONO = tel;
                sint.CORREO = correo;
                sint.ID_DIRECCION = id_direccion;
                sint.DIRECCION_COM = dir_com;
                sint.ID_ROL = id_rol;
                sint.ESTADO = dir_com;
                sint.DIRECCION_COM = estado;
                sint.USUARIO = usu;
                sint.PASSWORD = pass;
                         listaS.Add(sint);

            }
            return listaS;
        }
        public List<LoginPersonal> LlenandoPersonal()
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient log2 = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            List<LoginPersonal> listaS = new List<LoginPersonal>();
            DataSet ds = log2.TodosElPersonal();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_PERSONAL"].ToString());
                string nombre = dr["NOMBRES"].ToString();
                string apellido = dr["APELLIDOS"].ToString();
                string dui = dr["DUI"].ToString();
                string nit = dr["NIT"].ToString();
                string genero = dr["GENERO"].ToString();
                //DateTime fecha = DateTime.Parse(dr["FECHA_NACIMIENTO"].ToString());
                int id_departamento = int.Parse(dr["ID_DEPARTAMENTO"].ToString());
                string tel = dr["TELEFONO"].ToString();
                string correo = dr["CORREO"].ToString();
                int id_direccion = int.Parse(dr["ID_DIRECCION"].ToString());
                string dir_com = dr["DIRECCION_COM"].ToString();
                int id_consultorio = int.Parse(dr["ID_CONSULTORIO"].ToString());
                int id_rol = int.Parse(dr["ID_ROL"].ToString());
                string estado = dr["ESTADO"].ToString();
                string usu = dr["USUARIO"].ToString();
                string pass = dr["PASSWORD"].ToString();
                LoginPersonal sint = new LoginPersonal();
                sint.ID_PERSONAL = id;
                sint.NOMBRES = nombre;
                sint.APELLIDOS = apellido;
                sint.DUI = dui;
                sint.NIT = nit;
                sint.GENERO = genero;
                //sint.FECHA_NACIMIENTO = fecha;
                sint.ID_DEPARTAMENTO = id_departamento;
                sint.TELEFONO = tel;
                sint.CORREO = correo;
                sint.ID_DIRECCION = id_direccion;
                sint.DIRECCION_COM = dir_com;
                sint.ID_CONSULTORIO = id_consultorio;
                sint.ID_ROL2 = id_rol;
                sint.ESTADO = dir_com;
                sint.DIRECCION_COM = estado;
                sint.USUARIO2 = usu;
                sint.PASSWORD2 = pass;
                listaS.Add(sint);
            }
            return listaS;
        }
        [HttpPost]
        public int confirmarlogeo(string user, string password)
        {
            List<LoginPaciente> paciente = LlenandoPacientes();
            List<LoginPersonal> personal = LlenandoPersonal();
            int retornoRol = 0;
            try
            {
                try
                {
                    var datopaciente = paciente.Single(m => m.USUARIO == user && m.PASSWORD == password);
                    if (datopaciente != null)
                    {
                        if (datopaciente.ID_ROL.Equals(1))
                        {
                            Session["User"] = datopaciente.USUARIO;
                            Session["Nombre"] = datopaciente.NOMBRE;
                            Session["Apellido"] = datopaciente.APELLIDO;
                            Session["Rol"] = datopaciente.ID_ROL;
                            retornoRol = 1;
                            Url.Action("Index", "Home");
                        }
                        else
                        {
                            retornoRol = 0;
                        }
                    }
                }
                catch
                {
                    var datopersonal = personal.Single(m2 => m2.USUARIO2 == user && m2.PASSWORD2 == password);
                    if (datopersonal != null)
                    {
                        if (datopersonal.ID_ROL2.Equals(2))
                        {
                            Session["User"] = datopersonal.USUARIO2;
                            Session["Nombre"] = datopersonal.NOMBRES;
                            Session["Apellido"] = datopersonal.APELLIDOS;
                            Session["Rol"] = datopersonal.ID_ROL2;
                            retornoRol = 2;
                        }
                        else if (datopersonal.ID_ROL2.Equals(3))
                        {
                            Session["User"] = datopersonal.USUARIO2;
                            Session["Nombre"] = datopersonal.NOMBRES;
                            Session["Apellido"] = datopersonal.APELLIDOS;
                            Session["Rol"] = datopersonal.ID_ROL2;
                            retornoRol = 3;
                        }
                        else if (datopersonal.ID_ROL2.Equals(4))
                        {
                            Session["User"] = datopersonal.USUARIO2;
                            Session["Nombre"] = datopersonal.NOMBRES;
                            Session["Apellido"] = datopersonal.APELLIDOS;
                            Session["Rol"] = datopersonal.ID_ROL2;
                            retornoRol = 4;
                        }
                        else
                        {
                            retornoRol = 0;
                        }
                    }
                }
                }
                catch
                {
                    Content("Usuario o Contraseña incorrectos");
                }
                return retornoRol;           
        }      
        public ActionResult Salir()
        {
            Session.Contents.RemoveAll();
            return Redirect("~/Home/Index");
        }
    }
}