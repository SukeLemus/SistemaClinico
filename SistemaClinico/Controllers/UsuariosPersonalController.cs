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
        public ActionResult Details(int? id)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient dep = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            //Llenar lista de departamentos
            DataSet ds = dep.ListaDepa();

            var selectListDepa = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {


                selectListDepa.Add(new SelectListItem
                {
                    Value = dr["ID_DEPARTAMENTO"].ToString(),
                    Text = dr["NOMBRE_DEPARTAMENTO"].ToString()
                });
            }
            ViewData["listaDepartamentos"] = selectListDepa;

            //llenar lista de roles
            DataSet ds2 = dep.ListaRol();

            var selectListRol = new List<SelectListItem>();

            foreach (DataRow dr2 in ds2.Tables[0].Rows)
            {

                if (!dr2["ID_ROL"].ToString().Equals("1"))
                {
                    selectListRol.Add(new SelectListItem
                    {
                        Value = dr2["ID_ROL"].ToString(),
                        Text = dr2["NOMBRE_ROL"].ToString()
                    });
                }


            }
            ViewData["listaRoles"] = selectListRol;

            //Llenar una lista de muinicipios
            DataSet ds3 = dep.ListaDireccion();

            var selectListDir = new List<SelectListItem>();

            foreach (DataRow dr3 in ds3.Tables[0].Rows)
            {
                selectListDir.Add(new SelectListItem
                {
                    Value = dr3["ID_DIRECCION"].ToString(),
                    Text = dr3["MUNICIPIO"].ToString()
                });

            }
            ViewData["listaDirecciones"] = selectListDir;


            //lista de genero
            var selectListGen = new List<SelectListItem>();
            selectListGen.Add(new SelectListItem
            {
                Value = "MASCULINO",
                Text = "Masculino"
            });
            selectListGen.Add(new SelectListItem
            {
                Value = "FEMENINO",
                Text = "Femenino"
            });
            ViewData["listaGeneros"] = selectListGen;




            //Lista de consultorios
            DataSet ds4 = dep.ListaConsultorio();

            var selectListConsul = new List<SelectListItem>();

            foreach (DataRow dr4 in ds4.Tables[0].Rows)
            {
                selectListConsul.Add(new SelectListItem
                {
                    Value = dr4["ID_CONSULTORIO"].ToString(),
                    Text = dr4["NOMBRE_CONSULTORIO"].ToString()
                });

            }
            ViewData["listaConsultorios"] = selectListConsul;


            List<UsuarioPersonal> PaList = TodosPersonal();
            if (id.HasValue)
            {
                var p = PaList.Single(m => m.ID_PERSONAL == id);
                return View(p);
            }
            return View();

        }
        public ActionResult miperfil(int? id)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient dep = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            //Llenar lista de departamentos
            DataSet ds = dep.ListaDepa();

            var selectListDepa = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {


                selectListDepa.Add(new SelectListItem
                {
                    Value = dr["ID_DEPARTAMENTO"].ToString(),
                    Text = dr["NOMBRE_DEPARTAMENTO"].ToString()
                });
            }
            ViewData["listaDepartamentos"] = selectListDepa;

            //llenar lista de roles
            DataSet ds2 = dep.ListaRol();

            var selectListRol = new List<SelectListItem>();

            foreach (DataRow dr2 in ds2.Tables[0].Rows)
            {

                if (!dr2["ID_ROL"].ToString().Equals("1"))
                {
                    selectListRol.Add(new SelectListItem
                    {
                        Value = dr2["ID_ROL"].ToString(),
                        Text = dr2["NOMBRE_ROL"].ToString()
                    });
                }


            }
            ViewData["listaRoles"] = selectListRol;

            //Llenar una lista de muinicipios
            DataSet ds3 = dep.ListaDireccion();

            var selectListDir = new List<SelectListItem>();

            foreach (DataRow dr3 in ds3.Tables[0].Rows)
            {
                selectListDir.Add(new SelectListItem
                {
                    Value = dr3["ID_DIRECCION"].ToString(),
                    Text = dr3["MUNICIPIO"].ToString()
                });

            }
            ViewData["listaDirecciones"] = selectListDir;


            //lista de genero
            var selectListGen = new List<SelectListItem>();
            selectListGen.Add(new SelectListItem
            {
                Value = "MASCULINO",
                Text = "Masculino"
            });
            selectListGen.Add(new SelectListItem
            {
                Value = "FEMENINO",
                Text = "Femenino"
            });
            ViewData["listaGeneros"] = selectListGen;




            //Lista de consultorios
            DataSet ds4 = dep.ListaConsultorio();

            var selectListConsul = new List<SelectListItem>();

            foreach (DataRow dr4 in ds4.Tables[0].Rows)
            {
                selectListConsul.Add(new SelectListItem
                {
                    Value = dr4["ID_CONSULTORIO"].ToString(),
                    Text = dr4["NOMBRE_CONSULTORIO"].ToString()
                });

            }
            ViewData["listaConsultorios"] = selectListConsul;


            List<UsuarioPersonal> PaList = TodosPersonal();
            if (id.HasValue)
            {
                var p = PaList.Single(m => m.ID_PERSONAL == id);
                return View(p);
            }
            return View();

        }
        // GET: UsuariosPersonal/Create
        public ActionResult Create()
        {
            //llenar lista de roles
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient dep2 = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds2 = dep2.ListaRol();

            var selectListRol = new List<SelectListItem>();

            foreach (DataRow dr2 in ds2.Tables[0].Rows)
            {

                if (!dr2["ID_ROL"].ToString().Equals("1"))
                {
                    selectListRol.Add(new SelectListItem
                    {
                        Value = dr2["ID_ROL"].ToString(),
                        Text = dr2["NOMBRE_ROL"].ToString()
                    });
                }


            }
            ViewData["listaRoles2"] = selectListRol;

            return View();
        }

        // POST: UsuariosPersonal/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient swPer = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

                UsuarioPersonal nuevoPersonal = new UsuarioPersonal();
                nuevoPersonal.NOMBRES = collection["NOMBRES"];
                nuevoPersonal.APELLIDOS = collection["APELLIDOS"];
                nuevoPersonal.DUI = collection["DUI"];
                nuevoPersonal.NIT = collection["NIT"];
                nuevoPersonal.GENERO = collection["GENERO"];
                nuevoPersonal.ID_DEPARTAMENTO = int.Parse(collection["ID_DEPARTAMENTO"]);
                nuevoPersonal.TELEFONO = collection["TELEFONO"];
                nuevoPersonal.ID_ROL = int.Parse(collection["ID_ROL"]);
                nuevoPersonal.CORREO = collection["CORREO"];
                nuevoPersonal.ESTADO = collection["ESTADO"];
                nuevoPersonal.ID_DIRECCION = int.Parse(collection["ID_DIRECCION"]);
                nuevoPersonal.DIRECCION_COM = collection["DIRECCION_COM"];
                nuevoPersonal.ID_CONSULTORIO = int.Parse(collection["ID_CONSULTORIO"]);
                nuevoPersonal.USUARIO = collection["USUARIO"];
                nuevoPersonal.PASSWORD = collection["PASSWORD"];
                swPer.InsertPersonal(nuevoPersonal.NOMBRES, nuevoPersonal.APELLIDOS, nuevoPersonal.DUI, nuevoPersonal.NIT, nuevoPersonal.GENERO, nuevoPersonal.ID_DEPARTAMENTO, nuevoPersonal.TELEFONO,
                    nuevoPersonal.ID_ROL, nuevoPersonal.CORREO, nuevoPersonal.ESTADO, nuevoPersonal.ID_DIRECCION, nuevoPersonal.DIRECCION_COM, nuevoPersonal.ID_CONSULTORIO, nuevoPersonal.USUARIO, nuevoPersonal.PASSWORD);
                return RedirectToAction("Index", "UsuariosPersonal");
            }
            catch
            {
                // return View();
                return RedirectToAction("Index", "UsuariosPersonal");

            }
        }
       

        public static List<UsuarioPersonal> TodosPersonal()
        {
            List<UsuarioPersonal> listaS = new List<UsuarioPersonal>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient med = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = med.lista_personal();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_PERSONAL"].ToString());
                string nombre = dr["NOMBRES"].ToString();
                string apellido = dr["APELLIDOS"].ToString();
                string dui = dr["DUI"].ToString();
                string nit = dr["NIT"].ToString();
                string genero = dr["GENERO"].ToString();
                //string fecha = dr["FECHA_NACIMIENTO"].ToString();
                int id_departamento = int.Parse(dr["ID_DEPARTAMENTO"].ToString());
                string telefono = dr["TELEFONO"].ToString();
                int id_rol = int.Parse(dr["ID_ROL"].ToString());
                string correo = dr["CORREO"].ToString();
                string estado = dr["ESTADO"].ToString();
                int id_direccion = int.Parse(dr["ID_DIRECCION"].ToString());
                string direccion_com = dr["DIRECCION_COM"].ToString();
                int id_consultorio = int.Parse(dr["ID_CONSULTORIO"].ToString());
                string usuario = dr["USUARIO"].ToString();
                string password = dr["PASSWORD"].ToString();
                UsuarioPersonal US = new UsuarioPersonal();
                US.ID_PERSONAL = id;
                US.NOMBRES = nombre;
                US.APELLIDOS = apellido;
                US.DUI = dui;
                US.NIT = nit;
                US.GENERO = genero;
                //US.fecha = fecha;
                US.ID_DEPARTAMENTO = id_departamento;
                US.TELEFONO = telefono;
                US.ID_ROL = id_rol;
                US.CORREO = correo;
                US.ESTADO = estado;
                US.ID_DIRECCION = id_direccion;
                US.DIRECCION_COM = direccion_com;
                US.ID_CONSULTORIO = id_consultorio;
                US.USUARIO = usuario;
                US.PASSWORD = password;
                listaS.Add(US);
            }
            return listaS;

        }
        // GET: UsuariosPersonal/Edit/5
        public ActionResult Edit(int? id)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient dep = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            //Llenar lista de departamentos
            DataSet ds = dep.ListaDepa();

            var selectListDepa = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {


                selectListDepa.Add(new SelectListItem
                {
                    Value = dr["ID_DEPARTAMENTO"].ToString(),
                    Text = dr["NOMBRE_DEPARTAMENTO"].ToString()
                });
            }
            ViewData["listaDepartamentos"]= selectListDepa;

            //llenar lista de roles
            DataSet ds2 = dep.ListaRol();

            var selectListRol = new List<SelectListItem>();

            foreach (DataRow dr2 in ds2.Tables[0].Rows)
            {

                if (!dr2["ID_ROL"].ToString().Equals("1"))
                {
                    selectListRol.Add(new SelectListItem
                    {
                        Value = dr2["ID_ROL"].ToString(),
                        Text = dr2["NOMBRE_ROL"].ToString()
                    });
                }
                   
            
            }
            ViewData["listaRoles"] = selectListRol;

            //Llenar una lista de muinicipios
            DataSet ds3 = dep.ListaDireccion();

            var selectListDir = new List<SelectListItem>();

            foreach (DataRow dr3 in ds3.Tables[0].Rows)
            {
                     selectListDir.Add(new SelectListItem
                    {
                        Value = dr3["ID_DIRECCION"].ToString(),
                        Text = dr3["MUNICIPIO"].ToString()
                    });
           
            }
            ViewData["listaDirecciones"] = selectListDir;


            //lista de genero
            var selectListGen = new List<SelectListItem>();
            selectListGen.Add(new SelectListItem
            {
                Value = "MASCULINO",
                Text = "Masculino"
            });
            selectListGen.Add(new SelectListItem
            {
                Value = "FEMENINO",
                Text = "Femenino"
            });
            ViewData["listaGeneros"] = selectListGen;


            //lista de Estados
            var selectListEstado = new List<SelectListItem>();
            selectListEstado.Add(new SelectListItem
            {
                Value = "ACTIVO",
                Text = "Activo"
            });
            selectListEstado.Add(new SelectListItem
            {
                Value = "INACTIVO",
                Text = "Inactivo"
            });
            ViewData["listaEstados"] = selectListEstado;

            //Lista de consultorios
            DataSet ds4 = dep.ListaConsultorio();

            var selectListConsul = new List<SelectListItem>();

            foreach (DataRow dr4 in ds4.Tables[0].Rows)
            {
                selectListConsul.Add(new SelectListItem
                {
                    Value = dr4["ID_CONSULTORIO"].ToString(),
                    Text = dr4["NOMBRE_CONSULTORIO"].ToString()
                });

            }
            ViewData["listaConsultorios"] = selectListConsul;


            List<UsuarioPersonal> PaList = TodosPersonal();
            if (id.HasValue)
            {
                var p = PaList.Single(m => m.ID_PERSONAL == id);
                return View(p);
            }
            return View();
        }

        // POST: UsuariosPersonal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updatePaciente = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            try
            {
                // TODO: Add update logic here
                List<UsuarioPersonal> MedList = TodosPersonal();
                var nuevoPersonal = MedList.Single(m => m.ID_PERSONAL == id);
                if (TryUpdateModel(nuevoPersonal))
                {
                    updatePaciente.update_personal(nuevoPersonal.ID_PERSONAL, nuevoPersonal.NOMBRES, nuevoPersonal.APELLIDOS, nuevoPersonal.DUI, nuevoPersonal.NIT, nuevoPersonal.GENERO, nuevoPersonal.ID_DEPARTAMENTO, nuevoPersonal.TELEFONO,
                    nuevoPersonal.ID_ROL, nuevoPersonal.CORREO, nuevoPersonal.ESTADO, nuevoPersonal.ID_DIRECCION, nuevoPersonal.DIRECCION_COM, nuevoPersonal.ID_CONSULTORIO, nuevoPersonal.USUARIO, nuevoPersonal.PASSWORD);
                    return RedirectToAction("Index");
                }
                return View(nuevoPersonal);
            }
            catch
            {
                return View();
            }
        }
        //EDITAR PERFIL
        public ActionResult EditPerfil(int? id)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient dep = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            //Llenar lista de departamentos
            DataSet ds = dep.ListaDepa();

            var selectListDepa = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {


                selectListDepa.Add(new SelectListItem
                {
                    Value = dr["ID_DEPARTAMENTO"].ToString(),
                    Text = dr["NOMBRE_DEPARTAMENTO"].ToString()
                });
            }
            ViewData["listaDepartamentos"] = selectListDepa;

            //llenar lista de roles
            DataSet ds2 = dep.ListaRol();

            var selectListRol = new List<SelectListItem>();

            foreach (DataRow dr2 in ds2.Tables[0].Rows)
            {

                if (!dr2["ID_ROL"].ToString().Equals("1"))
                {
                    selectListRol.Add(new SelectListItem
                    {
                        Value = dr2["ID_ROL"].ToString(),
                        Text = dr2["NOMBRE_ROL"].ToString()
                    });
                }


            }
            ViewData["listaRoles"] = selectListRol;

            //Llenar una lista de muinicipios
            DataSet ds3 = dep.ListaDireccion();

            var selectListDir = new List<SelectListItem>();

            foreach (DataRow dr3 in ds3.Tables[0].Rows)
            {
                selectListDir.Add(new SelectListItem
                {
                    Value = dr3["ID_DIRECCION"].ToString(),
                    Text = dr3["MUNICIPIO"].ToString()
                });

            }
            ViewData["listaDirecciones"] = selectListDir;


            //lista de genero
            var selectListGen = new List<SelectListItem>();
            selectListGen.Add(new SelectListItem
            {
                Value = "MASCULINO",
                Text = "Masculino"
            });
            selectListGen.Add(new SelectListItem
            {
                Value = "FEMENINO",
                Text = "Femenino"
            });
            ViewData["listaGeneros"] = selectListGen;


            //lista de Estados
            var selectListEstado = new List<SelectListItem>();
            selectListEstado.Add(new SelectListItem
            {
                Value = "ACTIVO",
                Text = "Activo"
            });
            selectListEstado.Add(new SelectListItem
            {
                Value = "INACTIVO",
                Text = "Inactivo"
            });
            ViewData["listaEstados"] = selectListEstado;

            //Lista de consultorios
            DataSet ds4 = dep.ListaConsultorio();

            var selectListConsul = new List<SelectListItem>();

            foreach (DataRow dr4 in ds4.Tables[0].Rows)
            {
                selectListConsul.Add(new SelectListItem
                {
                    Value = dr4["ID_CONSULTORIO"].ToString(),
                    Text = dr4["NOMBRE_CONSULTORIO"].ToString()
                });

            }
            ViewData["listaConsultorios"] = selectListConsul;


            List<UsuarioPersonal> PaList = TodosPersonal();
            if (id.HasValue)
            {
                var p = PaList.Single(m => m.ID_PERSONAL == id);
                return View(p);
            }
            return View();
        }

        // POST: UsuariosPersonal/Edit/5
        [HttpPost]
        public ActionResult EditPerfil(int id, FormCollection collection)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updatePaciente = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            try
            {
                // TODO: Add update logic here
                List<UsuarioPersonal> MedList = TodosPersonal();
                var nuevoPersonal = MedList.Single(m => m.ID_PERSONAL == id);
                if (TryUpdateModel(nuevoPersonal))
                {
                    updatePaciente.update_personal(nuevoPersonal.ID_PERSONAL, nuevoPersonal.NOMBRES, nuevoPersonal.APELLIDOS, nuevoPersonal.DUI, nuevoPersonal.NIT, nuevoPersonal.GENERO, nuevoPersonal.ID_DEPARTAMENTO, nuevoPersonal.TELEFONO,
                    nuevoPersonal.ID_ROL, nuevoPersonal.CORREO, nuevoPersonal.ESTADO, nuevoPersonal.ID_DIRECCION, nuevoPersonal.DIRECCION_COM, nuevoPersonal.ID_CONSULTORIO, nuevoPersonal.USUARIO, nuevoPersonal.PASSWORD);
                    return RedirectToAction("miperfil", new { id = Session["id"] });
                }
                return View(nuevoPersonal);
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
