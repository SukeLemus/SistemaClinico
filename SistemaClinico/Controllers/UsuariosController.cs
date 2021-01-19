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

        //Enfermedad R
        public List<EnfermedadPaciente> listaEP()
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient log2 = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            List<EnfermedadPaciente> LE = new List<EnfermedadPaciente>();
            DataSet ds = log2.Select_EnfermedadesP();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_PADECIMIENTOS"].ToString());
                int idp = int.Parse(dr["ID_PACIENTE"].ToString());
                int ide = int.Parse(dr["ID_ENFERMEDAD"].ToString());
                string nombre = dr["NOMBRE_ENFERMEDAD"].ToString();

                EnfermedadPaciente enf = new EnfermedadPaciente();
                enf.ID = id;
                enf.ID_PACIENTE = idp;
                enf.ID_ENFERMEDAD = ide;
                enf.NOMBRE_ENFERMEDAD = nombre;

                LE.Add(enf);

            }
            return LE;
        }

        public int confrepetidoE(int idenf, int idsint)
        {

            List<EnfermedadPaciente> enfsint = listaEP();
            int datorep = 0;
            //var datopaciente = enfsint.Single(m => m.ID_ENFERMEDAD == idenf && m.ID_SINTOMA == idsint);
            try
            {
                var comprobando = enfsint.Single(m => m.ID_PACIENTE == idenf && m.ID_ENFERMEDAD == idsint);
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



        //Cirugias R
        public List<CirugiasPaciente> listaCP()
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient log2 = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            List<CirugiasPaciente> LC = new List<CirugiasPaciente>();
            DataSet ds = log2.Select_CirugiasP();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_CIRUGIA_PACIENTE"].ToString());
                int idp = int.Parse(dr["ID_PACIENTE"].ToString());
                int idc = int.Parse(dr["ID_CIRUGIA"].ToString());
                string nombre = dr["NOMBRE_CIRUGIA"].ToString();

                CirugiasPaciente cirug = new CirugiasPaciente();
                cirug.ID = id;
                cirug.ID_PACIENTE = idp;
                cirug.ID_CIRUGIA = idc;
                cirug.NOMBRE_CIRUGIA = nombre;

                LC.Add(cirug);

            }
            return LC;
        }

        public int confrepetidoC(int idenf, int idsint)
        {

            List <CirugiasPaciente> enfsint = listaCP();
            int datorep = 0;
            //var datopaciente = enfsint.Single(m => m.ID_ENFERMEDAD == idenf && m.ID_SINTOMA == idsint);
            try
            {
                var comprobando = enfsint.Single(m => m.ID_PACIENTE == idenf && m.ID_CIRUGIA == idsint);
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


        //Fracutras
        public List<FracturasPaciente> listaFP()
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient log2 = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            List<FracturasPaciente> LF = new List<FracturasPaciente>();
            DataSet ds = log2.Select_FracturasP();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_FRACTURA_PADECIDA"].ToString());
                int idp = int.Parse(dr["ID_PACIENTE"].ToString());
                int idf = int.Parse(dr["ID_FRACTURAS"].ToString());
                string nombre = dr["NOMBRE_FRACTURA"].ToString();

                FracturasPaciente fra = new FracturasPaciente();
                fra.ID = id;
                fra.ID_PACIENTE = idp;
                fra.ID_FRACTURAS = idf;
                fra.NOMBRE_FRACTURA = nombre;

                LF.Add(fra);

            }
            return LF;
        }

        public int confrepetidoF(int idenf, int idsint)
        {

            List<FracturasPaciente> enfsint = listaFP();
            int datorep = 0;
            //var datopaciente = enfsint.Single(m => m.ID_ENFERMEDAD == idenf && m.ID_SINTOMA == idsint);
            try
            {
                var comprobando = enfsint.Single(m => m.ID_PACIENTE == idenf && m.ID_FRACTURAS == idsint);
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

        //Alergias
        public List<AlergiasPaciente> listaAP()
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient log2 = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            List<AlergiasPaciente> listaS = new List<AlergiasPaciente>();
            DataSet ds = log2.Select_AlergiasP();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_ALERGIA_PADECIDA"].ToString());
                int idp = int.Parse(dr["ID_PACIENTE"].ToString());                               
                int ida = int.Parse(dr["ID_ALERGIA"].ToString());
                string nombre = dr["NOMBRE_ALERGIA"].ToString();

                AlergiasPaciente sint = new AlergiasPaciente();
                sint.ID = id;
                sint.ID_PACIENTE = idp;
                sint.ID_ALERGIA = ida;
                sint.NOMBRE_ALERGIA = nombre;

                listaS.Add(sint);

            }
            return listaS;
        }

        public int confrepetido(int idenf, int idsint)
        {

            List<AlergiasPaciente> enfsint = listaAP();
            int datorep = 0;
            //var datopaciente = enfsint.Single(m => m.ID_ENFERMEDAD == idenf && m.ID_SINTOMA == idsint);
            try
            {
                var comprobando = enfsint.Single(m => m.ID_PACIENTE == idenf && m.ID_ALERGIA == idsint);
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
        public ActionResult agregarA(int id)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient alerWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            //Lista Alergias
            /**************ALERGIAS ***************************************************/
            DataSet ds = alerWS.ListaAlergias();
            List<Alergias> listaAler = new List<Alergias>();
            var selectListAlergias = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int idAlergia = int.Parse(dr["ID_ALERGIA"].ToString());
                // string idAlergia = dr["ID_ALERGIA_PADECIDA"].ToString();
                string nombreAlergia = dr["NOMBRE_ALERGIA"].ToString();

                Alergias alerg = new Alergias();
                alerg.ID = idAlergia;
                alerg.NOMBRE_ALERGIA = nombreAlergia;
                listaAler.Add(alerg);

                selectListAlergias.Add(new SelectListItem
                {
                    Value = alerg.ID.ToString(),
                    Text = alerg.NOMBRE_ALERGIA
                });
            }

            ViewData["ListaAlergias"] = selectListAlergias;

            //sacando nombre paciente

            DataSet ds2 = alerWS.PacienteID(id);
            RegistroPacienteUsuario p = new RegistroPacienteUsuario();

            foreach (DataRow dr2 in ds2.Tables[0].Rows)
            {

                string nombre = dr2["NOMBRE"].ToString();
                string apellido = dr2["APELLIDO"].ToString();

                p.NOMBRE = nombre;
                p.APELLIDO = apellido;


            }

            ViewData["nombrep"] = p.NOMBRE + " " + p.APELLIDO;

            //Lista Alergia Tratamiento

            DataSet ds3 = alerWS.Select_AlergiasPaciente(id);
            List<AlergiasPaciente> listaAler3 = new List<AlergiasPaciente>();
            var selectListAlergias3 = new List<SelectListItem>();

            foreach (DataRow dr3 in ds3.Tables[0].Rows)
            {
                int idAlergia3 = int.Parse(dr3["ID_ALERGIA"].ToString());
                // string idAlergia = dr["ID_ALERGIA_PADECIDA"].ToString();
                string nombreAlergia3 = dr3["NOMBRE_ALERGIA"].ToString();

                AlergiasPaciente aler3 = new AlergiasPaciente();
                aler3.ID = idAlergia3;
                aler3.NOMBRE_ALERGIA = nombreAlergia3;
                listaAler3.Add(aler3);

                selectListAlergias3.Add(new SelectListItem
                {
                    Value = aler3.ID.ToString(),
                    Text = aler3.NOMBRE_ALERGIA
                });
            }

            ViewData["ListaAlergiasID"] = selectListAlergias3;
            ViewData["idpaciente"] = id;
            return View();
        }
        [HttpPost]

        public ActionResult agregarA(int id, FormCollection collection)
        {

            if (Session["Rol"] != null && Session["Rol"].Equals(3))
            {
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient alerWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();




                try
                {


                    int datorep = confrepetido(id, int.Parse(collection["ID_ALERGIA"].ToString()));
                    if (datorep == 0)
                    {
                        AlergiasPaciente aler = new Models.AlergiasPaciente();
                        aler.ID_PACIENTE = id;
                        aler.ID_ALERGIA = int.Parse(collection["ID_ALERGIA"]);
                        alerWS.insertar_AlergiasPaciente(aler.ID_PACIENTE, aler.ID_ALERGIA);
                    }
                    else
                    {
                        TempData["UserMessage"] = "ya existe esa alergia para este paciente";
                        return RedirectToAction("agregarA", "Usuarios", new { id = id });
                    }
                    
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
            return RedirectToAction("agregarA", "Usuarios", new { id = id});
        }

        public ActionResult agregarF(int id)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient alerWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            //Lista Alergias
            /**************ALERGIAS ***************************************************/
            DataSet ds = alerWS.ListaFracturas();
            List<Fracturas> listaF = new List<Fracturas>();
            var selectListF = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int idf = int.Parse(dr["ID_FRACTURAS"].ToString());
                // string idAlergia = dr["ID_ALERGIA_PADECIDA"].ToString();
                string nombref = dr["NOMBRE_FRACTURA"].ToString();

                Fracturas fa = new Fracturas();
                fa.ID = idf;
                fa.NOMBRE_FRACTURA = nombref;
                listaF.Add(fa);

                selectListF.Add(new SelectListItem
                {
                    Value = fa.ID.ToString(),
                    Text = fa.NOMBRE_FRACTURA
                });
            }

            ViewData["ListaFracturas"] = selectListF;

            //sacando nombre paciente

            DataSet ds2 = alerWS.PacienteID(id);
            RegistroPacienteUsuario p = new RegistroPacienteUsuario();

            foreach (DataRow dr2 in ds2.Tables[0].Rows)
            {

                string nombre = dr2["NOMBRE"].ToString();
                string apellido = dr2["APELLIDO"].ToString();

                p.NOMBRE = nombre;
                p.APELLIDO = apellido;


            }

            ViewData["nombrep"] = p.NOMBRE + " " + p.APELLIDO;

            //Lista Fractura paciente

            DataSet ds3 = alerWS.Select_FracturasPaciente(id);
            List<FracturasPaciente> listafrac = new List<FracturasPaciente>();
            var selectListfractura = new List<SelectListItem>();

            foreach (DataRow dr3 in ds3.Tables[0].Rows)
            {
                int idfrac = int.Parse(dr3["ID_FRACTURAS"].ToString());
                // string idAlergia = dr["ID_ALERGIA_PADECIDA"].ToString();
                string nombrefrac = dr3["NOMBRE_FRACTURA"].ToString();

                FracturasPaciente f = new FracturasPaciente();
                f.ID_FRACTURAS = idfrac;
                f.NOMBRE_FRACTURA = nombrefrac;
                listafrac.Add(f);

                selectListfractura.Add(new SelectListItem
                {
                    Value = f.ID_FRACTURAS.ToString(),
                    Text = f.NOMBRE_FRACTURA
                });
            }

            ViewData["ListaFracturasID"] = selectListfractura;
            ViewData["idpaciente"] = id;
            return View();
        }
        [HttpPost]

        public ActionResult agregarF(int id, FormCollection collection)
        {

            if (Session["Rol"] != null && Session["Rol"].Equals(3))
            {
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient alerWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();




                try
                {


                    int datorep = confrepetidoF(id, int.Parse(collection["ID_FRACTURAS"].ToString()));
                    if (datorep == 0)
                    {
                        FracturasPaciente frac = new Models.FracturasPaciente();
                        frac.ID_PACIENTE = id;
                        frac.ID_FRACTURAS = int.Parse(collection["ID_FRACTURAS"]);
                        alerWS.insertar_FracturasPaciente(frac.ID_PACIENTE, frac.ID_FRACTURAS);
                    }
                    else
                    {
                        TempData["UserMessage"] = "ya existe esa fractura para este paciente";
                        return RedirectToAction("agregarF", "Usuarios", new { id = id });
                    }

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
            return RedirectToAction("agregarF", "Usuarios", new { id = id });
        }

        //Cirugias

        public ActionResult agregarC(int id)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient alerWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            //Lista Alergias
            /**************ALERGIAS ***************************************************/
            DataSet ds = alerWS.ListaCirugias();
            List<Cirugias> listaC = new List<Cirugias>();
            var selectListC = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int idc = int.Parse(dr["ID_CIRUGIA"].ToString());
                // string idAlergia = dr["ID_ALERGIA_PADECIDA"].ToString();
                string nombrec = dr["NOMBRE_CIRUGIA"].ToString();

                Cirugias ci = new Cirugias();
                ci.ID = idc;
                ci.NOMBRE_CIRUGIA = nombrec;
                listaC.Add(ci);

                selectListC.Add(new SelectListItem
                {
                    Value = ci.ID.ToString(),
                    Text = ci.NOMBRE_CIRUGIA
                });
            }

            ViewData["ListaCirugias"] = selectListC;

            //sacando nombre paciente

            DataSet ds2 = alerWS.PacienteID(id);
            RegistroPacienteUsuario p = new RegistroPacienteUsuario();

            foreach (DataRow dr2 in ds2.Tables[0].Rows)
            {

                string nombre = dr2["NOMBRE"].ToString();
                string apellido = dr2["APELLIDO"].ToString();

                p.NOMBRE = nombre;
                p.APELLIDO = apellido;


            }

            ViewData["nombrep"] = p.NOMBRE + " " + p.APELLIDO;

            //Lista Fractura paciente

            DataSet ds3 = alerWS.Select_CirugiasPaciente(id);
            List<CirugiasPaciente> listaCirugia = new List<CirugiasPaciente>();
            var selectListCirugia = new List<SelectListItem>();

            foreach (DataRow dr3 in ds3.Tables[0].Rows)
            {
                int idCirugia = int.Parse(dr3["ID_CIRUGIA"].ToString());
                // string idAlergia = dr["ID_ALERGIA_PADECIDA"].ToString();
                string nombrecirugia = dr3["NOMBRE_CIRUGIA"].ToString();

                CirugiasPaciente c = new CirugiasPaciente();
                c.ID_CIRUGIA = idCirugia;
                c.NOMBRE_CIRUGIA = nombrecirugia;
                listaCirugia.Add(c);

                selectListCirugia.Add(new SelectListItem
                {
                    Value = c.ID_CIRUGIA.ToString(),
                    Text = c.NOMBRE_CIRUGIA
                });
            }

            ViewData["ListaCirugiaID"] = selectListCirugia;
            ViewData["idpaciente"] = id;
            return View();
        }
        [HttpPost]

        public ActionResult agregarC(int id, FormCollection collection)
        {

            if (Session["Rol"] != null && Session["Rol"].Equals(3))
            {
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient alerWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();




                try
                {


                    int datorep = confrepetidoC(id, int.Parse(collection["ID_CIRUGIA"].ToString()));
                    if (datorep == 0)
                    {
                        CirugiasPaciente frac = new Models.CirugiasPaciente();
                        frac.ID_PACIENTE = id;
                        frac.ID_CIRUGIA = int.Parse(collection["ID_CIRUGIA"]);
                        alerWS.insertar_CirugiasPaciente(frac.ID_PACIENTE, frac.ID_CIRUGIA);
                    }
                    else
                    {
                        TempData["UserMessage"] = "ya existe esa cirugia para este paciente";
                        return RedirectToAction("agregarC", "Usuarios", new { id = id });
                    }

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
            return RedirectToAction("agregarC", "Usuarios", new { id = id });
        }

        //Enfermedades 
        public ActionResult agregarE(int id)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient alerWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            //Lista Enfermedad
            /**************ENFERMEDAD ***************************************************/
            DataSet ds = alerWS.lista_enfermedades();
            List<Enfermedad> listaE = new List<Enfermedad>();
            var selectListE = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int ide = int.Parse(dr["ID_ENFERMEDAD"].ToString());
                // string idAlergia = dr["ID_ALERGIA_PADECIDA"].ToString();
                string nombree = dr["NOMBRE_ENFERMEDAD"].ToString();

                Enfermedad ef = new Enfermedad();
                ef.id = ide;
                ef.nombre_enfermedad = nombree;
                listaE.Add(ef);

                selectListE.Add(new SelectListItem
                {
                    Value = ef.id.ToString(),
                    Text = ef.nombre_enfermedad
                });
            }

            ViewData["ListaEnfermedad"] = selectListE;

            //sacando nombre paciente

            DataSet ds2 = alerWS.PacienteID(id);
            RegistroPacienteUsuario p = new RegistroPacienteUsuario();

            foreach (DataRow dr2 in ds2.Tables[0].Rows)
            {

                string nombre = dr2["NOMBRE"].ToString();
                string apellido = dr2["APELLIDO"].ToString();

                p.NOMBRE = nombre;
                p.APELLIDO = apellido;


            }

            ViewData["nombrep"] = p.NOMBRE + " " + p.APELLIDO;

            //Lista Enfermedad paciente

            DataSet ds3 = alerWS.Select_EnfermedadesPaciente(id);
            List<EnfermedadPaciente> listaEnfermedad = new List<EnfermedadPaciente>();
            var selectListEnfermedad = new List<SelectListItem>();

            foreach (DataRow dr3 in ds3.Tables[0].Rows)
            {
                int idenfermedad = int.Parse(dr3["ID_ENFERMEDAD"].ToString());
                // string idAlergia = dr["ID_ALERGIA_PADECIDA"].ToString();
                string nombreenfermedad = dr3["NOMBRE_ENFERMEDAD"].ToString();

                EnfermedadPaciente c = new EnfermedadPaciente();
                c.ID_ENFERMEDAD = idenfermedad;
                c.NOMBRE_ENFERMEDAD = nombreenfermedad;
                listaEnfermedad.Add(c);

                selectListEnfermedad.Add(new SelectListItem
                {
                    Value = c.ID_ENFERMEDAD.ToString(),
                    Text = c.NOMBRE_ENFERMEDAD
                });
            }

            ViewData["ListaEnfermedadID"] = selectListEnfermedad;
            ViewData["idpaciente"] = id;
            return View();
        }
        [HttpPost]

        public ActionResult agregarE(int id, FormCollection collection)
        {

            if (Session["Rol"] != null && Session["Rol"].Equals(3))
            {
                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient alerWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();




                try
                {


                    int datorep = confrepetidoE(id, int.Parse(collection["ID_ENFERMEDAD"].ToString()));
                    if (datorep == 0)
                    {
                        EnfermedadPaciente enfer = new Models.EnfermedadPaciente();
                        enfer.ID_PACIENTE = id;
                        enfer.ID_ENFERMEDAD = int.Parse(collection["ID_ENFERMEDAD"]);
                        alerWS.insertar_EnfermedadPaciente(enfer.ID_PACIENTE, enfer.ID_ENFERMEDAD);
                    }
                    else
                    {
                        TempData["UserMessage"] = "ya existe esa enfermedad para este paciente";
                        return RedirectToAction("agregarE", "Usuarios", new { id = id });
                    }

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
            return RedirectToAction("agregarE", "Usuarios", new { id = id });
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
                int idFractura = int.Parse(dr4["ID_FRACTURAS"].ToString());
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
