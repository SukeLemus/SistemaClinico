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
        public static List<DireccionesUsuario> ListaDirecciones()
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient direccionesWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = direccionesWS.SelectIdDireccion();
            List<DireccionesUsuario> listaDir = new List<DireccionesUsuario>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID"].ToString());
                string nombre = dr["MUNICIPIO"].ToString();

                DireccionesUsuario dir = new DireccionesUsuario();
                dir.ID = id;
                dir.Municipio = nombre;
                listaDir.Add(dir);
            }
            return listaDir;
        }

        public IEnumerable<SelectListItem> GetSelectListItems()
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient direccionesWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = direccionesWS.SelectIdDireccion();
            List<DireccionesUsuario> listaDir = new List<DireccionesUsuario>();
            var selectList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID"].ToString());
                string nombre = dr["MUNICIPIO"].ToString();
                DireccionesUsuario dir = new DireccionesUsuario();
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



        // GET: Usuarios
        public ActionResult Index(int? i, string BuscarNombre)
        {
            var usu = from e in TodosUsuarioMunicipio()
                          //orderby e.nombre
                      select e;
            //if (!String.IsNullOrEmpty(BuscarNombre))
            //{
            //    usu = usu.Where(c => c.NOMBRE.ToLower().Contains(BuscarNombre.ToLower()));
            //}
            return View(usu.ToPagedList(i ?? 1, 3));
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            List<RegistroPacienteUsuario> PaList = TodosUsuarios();
            if (id.HasValue)
            {
                var p = PaList.Single(m => m.id == id);

                return View(p);
            }
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            List<SelectListItem> listaSangre = new List<SelectListItem>();
            listaSangre.Add(new SelectListItem
            {
                Text = "No lo sé",
                Value = "NO SABE"
            });
            listaSangre.Add(new SelectListItem
            {
                Text = "O-",
                Value = "O-"
            });
            listaSangre.Add(new SelectListItem
            {
                Text = "O+",
                Value = "O+"
            });
            listaSangre.Add(new SelectListItem
            {
                Text = "A-",
                Value = "A-"
            });
            listaSangre.Add(new SelectListItem
            {
                Text = "A+",
                Value = "A+"
            });
            listaSangre.Add(new SelectListItem
            {
                Text = "AB-",
                Value = "AB-"
            });
            listaSangre.Add(new SelectListItem
            {
                Text = "AB+",
                Value = "AB+"
            });
            ViewData["listaSangre"] = listaSangre;

            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            
          
            try
            {
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient swEnf = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

                RegistroPacienteUsuario nuevoPaciente = new RegistroPacienteUsuario();
                nuevoPaciente.NOMBRE = collection["NOMBRE"];
                nuevoPaciente.APELLIDO = collection["APELLIDO"];
                nuevoPaciente.DUI = collection["DUI"];
                nuevoPaciente.NIT = collection["NIT"];
                nuevoPaciente.GENERO = collection["GENERO"];
                nuevoPaciente.TIPO_SANGRE = collection["TIPO_SANGRE"];
                nuevoPaciente.TELEFONO = collection["TELEFONO"];
                nuevoPaciente.CORREO = collection["CORREO"];
                nuevoPaciente.ID_DIRECCION = int.Parse(collection["ID_DIRECCION"]);
                nuevoPaciente.DIRECCION_COM = collection["DIRECCION_COM"];
                nuevoPaciente.ESTADO = "ACTIVO";
                nuevoPaciente.USUARIO = collection["USUARIO"];
                nuevoPaciente.PASSWORD = collection["PASSWORD"];
                swEnf.InsertPaciente(nuevoPaciente.NOMBRE, nuevoPaciente.APELLIDO, nuevoPaciente.DUI, nuevoPaciente.NIT, nuevoPaciente.GENERO, nuevoPaciente.TIPO_SANGRE, nuevoPaciente.TELEFONO,
                    nuevoPaciente.CORREO, nuevoPaciente.ID_DIRECCION, nuevoPaciente.DIRECCION_COM, nuevoPaciente.ESTADO, nuevoPaciente.USUARIO, nuevoPaciente.PASSWORD);
                return RedirectToAction("Index", "Usuarios");
            }
            catch
            {
                // return View();
                return RedirectToAction("Index", "Sintomas");

            }
        }
        public static List<RegistroPacienteUsuario> TodosUsuarios()
        {
            List<RegistroPacienteUsuario> listaS = new List<RegistroPacienteUsuario>();
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
                RegistroPacienteUsuario US = new RegistroPacienteUsuario();
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
        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            List<SelectListItem> listaSangre = new List<SelectListItem>();
            listaSangre.Add(new SelectListItem
            {
                Text = "No lo sé",
                Value = "NO SABE"
            });
            listaSangre.Add(new SelectListItem
            {
                Text = "O-",
                Value = "O-"
            });
            listaSangre.Add(new SelectListItem
            {
                Text = "O+",
                Value = "O+"
            });
            listaSangre.Add(new SelectListItem
            {
                Text = "A-",
                Value = "A-"
            });
            listaSangre.Add(new SelectListItem
            {
                Text = "A+",
                Value = "A+"
            });
            listaSangre.Add(new SelectListItem
            {
                Text = "AB-",
                Value = "AB-"
            });
            listaSangre.Add(new SelectListItem
            {
                Text = "AB+",
                Value = "AB+"
            });
            ViewData["listaSangre"] = listaSangre;
            List<SelectListItem> listaEstados = new List<SelectListItem>();

            listaEstados.Add(new SelectListItem
            {
                Text = "Activo",
                Value = "ACTIVO"
            });
            listaEstados.Add(new SelectListItem
            {
                Text = "Inactivo",
                Value = "INACTIVO"
            });


            List<RegistroPacienteUsuario> PaList = TodosUsuarios();
            if (id.HasValue)
            {
                var p = PaList.Single(m => m.id == id);

                ViewData["listaEstados"] = listaEstados;

                return View(p);
            }
            return View();
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updatePaciente = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            try
            {
                // TODO: Add update logic here
                List<RegistroPacienteUsuario> MedList = TodosUsuarios();
                var nuevoPaciente = MedList.Single(m => m.id == id);
                if (TryUpdateModel(nuevoPaciente))
                {
                    updatePaciente.update_paciente(nuevoPaciente.id, nuevoPaciente.NOMBRE, nuevoPaciente.APELLIDO, nuevoPaciente.DUI, nuevoPaciente.NIT, nuevoPaciente.GENERO, nuevoPaciente.TIPO_SANGRE, nuevoPaciente.TELEFONO,
                    nuevoPaciente.CORREO, nuevoPaciente.ID_DIRECCION, nuevoPaciente.DIRECCION_COM, nuevoPaciente.ESTADO, nuevoPaciente.USUARIO, nuevoPaciente.PASSWORD);
                    return RedirectToAction("Index");
                }
                return View(nuevoPaciente);
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            List<UsuarioMunicipio> sintList = TodosUsuarioMunicipio();
            if (id.HasValue)
            {
                var sint = sintList.Single(m => m.ID_PACIENTE == id);
                return View(sint);
            }
            return View();
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient EliminarPaciente = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                List<UsuarioMunicipio> MedList = TodosUsuarioMunicipio();
                var paciente = MedList.Single(m => m.ID_PACIENTE == id);
                UsuarioMunicipio MostrarDatos = new Models.UsuarioMunicipio();
                MostrarDatos.NOMBRE = paciente.NOMBRE.ToString();
                MostrarDatos.APELLIDO = paciente.APELLIDO.ToString();
                MostrarDatos.TELEFONO = paciente.TELEFONO.ToString();
                MostrarDatos.MUNICIPIO = paciente.MUNICIPIO.ToString();
                MostrarDatos.DIRECCION_COM = paciente.DIRECCION_COM.ToString();
                EliminarPaciente.eliminar_paciente(id);



                if (TryUpdateModel(paciente))
                {
                    EliminarPaciente.eliminar_paciente(paciente.ID_PACIENTE);
                    return RedirectToAction("Index");
                }
                return View(paciente);
            }
            catch
            {
                return View();
            }
        }









    }
}
