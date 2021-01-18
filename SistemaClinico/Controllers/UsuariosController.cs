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

        public ActionResult InformacionMedica(int id)
        {
            //agregar listas viewdata de paciente


            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient WS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            /**************ALERGIAS ***************************************************/
            DataSet ds = WS.Select_AlergiasPaciente(id);
            List<Alergias> listaAler = new List<Alergias>();
            var selectListAlergias = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int idAlergia = int.Parse(dr["ID_ALERGIA"].ToString());
                // string idAlergia = dr["ID_ALERGIA_PADECIDA"].ToString();
                string nombreAlergia = dr["NOMBRE_ALERGIA"].ToString();

                Alergias aler = new Alergias();
                aler.ID = idAlergia;
                aler.NOMBRE_ALERGIA = nombreAlergia;
                listaAler.Add(aler);

                selectListAlergias.Add(new SelectListItem
                {
                    Value = aler.ID.ToString(),
                    Text = aler.NOMBRE_ALERGIA
                });
            }

            ViewData["ListaAlergias"]= selectListAlergias;
            /*******************************************************************************/

            /************** ENFERMEDADES ***************************************************/
            DataSet ds2 = WS.Select_EnfermedadesPaciente(id);
            List<Enfermedad> listaEnfer = new List<Enfermedad>();
            var selectListEnfermedades = new List<SelectListItem>();
            foreach (DataRow dr2 in ds2.Tables[0].Rows)
            {
                int idEnfermedad = int.Parse(dr2["ID_ENFERMEDAD"].ToString());
                string nombreEnfermedad = dr2["NOMBRE_ENFERMEDAD"].ToString();

                Enfermedad enfer = new Enfermedad();
                enfer.id = idEnfermedad;
                enfer.nombre_enfermedad = nombreEnfermedad;

                listaEnfer.Add(enfer);

                selectListEnfermedades.Add(new SelectListItem
                {
                    Value = enfer.id.ToString(),
                    Text = enfer.nombre_enfermedad
                });
            }
            ViewData["ListaEnfermedades"] = selectListEnfermedades;
            /*******************************************************************************/

            /************** CIRUGIAS *******************************************************/
            DataSet ds3 = WS.Select_CirugiasPaciente(id);
            List<Cirugias> listaCirug = new List<Cirugias>();
            var selectListCirugias = new List<SelectListItem>();
            foreach (DataRow dr3 in ds3.Tables[0].Rows)
            {
                int idCirugia = int.Parse(dr3["ID_CIRUGIA"].ToString());
                string nombreCirugia = dr3["NOMBRE_CIRUGIA"].ToString();

                Cirugias ciru = new Cirugias();
                ciru.ID = idCirugia;
                ciru.NOMBRE_CIRUGIA = nombreCirugia;

                listaCirug.Add(ciru);

                selectListCirugias.Add(new SelectListItem
                {
                    Value = ciru.ID.ToString(),
                    Text = ciru.NOMBRE_CIRUGIA
                });
            }
            ViewData["ListaCirugias"] = selectListCirugias;
            /*******************************************************************************/

            /************** FRACTURAS ******************************************************/
            DataSet ds4 = WS.Select_FracturasPaciente(id);
            List<Fracturas> listaFract = new List<Fracturas>();
            var selectListFracturas = new List<SelectListItem>();
            foreach (DataRow dr4 in ds4.Tables[0].Rows)
            {
                int idFractura = int.Parse(dr4["ID_FRACTURA"].ToString());
                string nombreFractura = dr4["NOMBRE_FRACTURA"].ToString();

                Fracturas fractu = new Fracturas();
                fractu.ID = idFractura;
                fractu.NOMBRE_FRACTURA = nombreFractura;

                listaFract.Add(fractu);

                selectListFracturas.Add(new SelectListItem
                {
                    Value = fractu.ID.ToString(),
                    Text = fractu.NOMBRE_FRACTURA
                });
            }
            ViewData["ListaFracturas"] = selectListFracturas;
            /*******************************************************************************/

            /************** TRATAMIENTOS ***************************************************/
            DataSet ds5 = WS.Select_TratamientosPaciente(id);
            List<Tratamiento> listaTratamiento = new List<Tratamiento>();
            var selectListTratamiento = new List<SelectListItem>();
            foreach (DataRow dr5 in ds5.Tables[0].Rows)
            {
                int idTratamiento = int.Parse(dr5["ID_MEDICAMENTO"].ToString());
                string nombreTratamiento = dr5["NOMBRE_MEDICAMENTO"].ToString();

                Tratamiento trata = new Tratamiento();
                trata.ID = idTratamiento;
                trata.NOMBRE_MEDICAMENTO = nombreTratamiento;

                listaTratamiento.Add(trata);

                selectListFracturas.Add(new SelectListItem
                {
                    Value = trata.ID.ToString(),
                    Text = trata.NOMBRE_MEDICAMENTO
                });
            }
            ViewData["ListaTratamiento"] = selectListTratamiento;
            /*******************************************************************************/


            var usu = from e in TodosUsuarios()
                          //orderby e.nombre
                      select e;

            var p = usu.Single(m => m.id == id);

            return View(p);
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
            return View(usu.ToPagedList(i ?? 1, 10));
        }

        public ActionResult IndexPacientesAgregar(int? i, string BuscarNombre)
        {
            var usu = from e in TodosUsuarios()
                          //orderby e.nombre
                      select e;
            //if (!String.IsNullOrEmpty(BuscarNombre))
            //{
            //    usu = usu.Where(c => c.NOMBRE.ToLower().Contains(BuscarNombre.ToLower()));
            //}
            return View(usu.ToPagedList(i ?? 1, 10));
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            List<RegistroPacienteUsuario> PaList = TodosUsuarios();
            if (id.HasValue)
            {
                var p = PaList.Single(m => m.id == id);
                string f = p.FECHA_NACIMIENTO.ToString().Remove(10);
                ViewData["FECHA_NACIMIENTO"] = f.ToString();
                return View(p);
            }
            return View();
        }
        public ActionResult miperfil(int? id)
        {
            List<RegistroPacienteUsuario> PaList = TodosUsuarios();
            if (id.HasValue)
            {
                var p = PaList.Single(m => m.id == id);
                string f = p.FECHA_NACIMIENTO.ToString().Remove(10);
                ViewData["FECHA_NACIMIENTO"] = f.ToString();
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
                nuevoPaciente.FECHA_NACIMIENTO = collection["FECHA_NACIMIENTO"];
                nuevoPaciente.TIPO_SANGRE = collection["TIPO_SANGRE"];
                nuevoPaciente.TELEFONO = collection["TELEFONO"];
                nuevoPaciente.CORREO = collection["CORREO"];
                nuevoPaciente.ID_DIRECCION = int.Parse(collection["ID_DIRECCION"]);
                nuevoPaciente.DIRECCION_COM = collection["DIRECCION_COM"];
                nuevoPaciente.ESTADO = "ACTIVO";
                nuevoPaciente.USUARIO = collection["USUARIO"];
                nuevoPaciente.PASSWORD = collection["PASSWORD"];
                swEnf.InsertPaciente(nuevoPaciente.NOMBRE, nuevoPaciente.APELLIDO, nuevoPaciente.DUI, nuevoPaciente.NIT, nuevoPaciente.GENERO, nuevoPaciente.FECHA_NACIMIENTO, nuevoPaciente.TIPO_SANGRE, nuevoPaciente.TELEFONO,
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
                string fecha = dr["FECHA_NACIMIENTO"].ToString();
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
                US.FECHA_NACIMIENTO = fecha;
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
                string f = p.FECHA_NACIMIENTO.ToString().Remove(10);
                ViewData["FECHA_NACIMIENTO"] = f.ToString();
                ViewData["listaEstados"] = listaEstados;
                string pass = p.PASSWORD;
                ViewData["pass"] = pass;
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
                    updatePaciente.update_paciente(nuevoPaciente.id, nuevoPaciente.NOMBRE, nuevoPaciente.APELLIDO, nuevoPaciente.DUI, nuevoPaciente.NIT, nuevoPaciente.GENERO, nuevoPaciente.FECHA_NACIMIENTO, nuevoPaciente.TIPO_SANGRE, nuevoPaciente.TELEFONO,
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
        //EditarPERFIL
        public ActionResult EditPerfil(int? id)
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
                string f = p.FECHA_NACIMIENTO.ToString().Remove(10);
                ViewData["FECHA_NACIMIENTO"] = f.ToString();
                ViewData["listaEstados"] = listaEstados;
                string pass = p.PASSWORD;
                ViewData["pass"] = pass;
                return View(p);
            }
            return View();
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult EditPerfil(int id, FormCollection collection)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updatePaciente = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            try
            {
                // TODO: Add update logic here
                List<RegistroPacienteUsuario> MedList = TodosUsuarios();
                var nuevoPaciente = MedList.Single(m => m.id == id);
                if (TryUpdateModel(nuevoPaciente))
                {
                    updatePaciente.update_paciente(nuevoPaciente.id, nuevoPaciente.NOMBRE, nuevoPaciente.APELLIDO, nuevoPaciente.DUI, nuevoPaciente.NIT, nuevoPaciente.GENERO, nuevoPaciente.FECHA_NACIMIENTO, nuevoPaciente.TIPO_SANGRE, nuevoPaciente.TELEFONO,
                    nuevoPaciente.CORREO, nuevoPaciente.ID_DIRECCION, nuevoPaciente.DIRECCION_COM, nuevoPaciente.ESTADO, nuevoPaciente.USUARIO, nuevoPaciente.PASSWORD);
                    return RedirectToAction("miperfil", new { id = Session["id"] });
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
