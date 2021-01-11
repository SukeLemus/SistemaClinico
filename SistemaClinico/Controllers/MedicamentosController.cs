using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaClinico.Models;
using PagedList;
using System.Data;

namespace SistemaClinico.Controllers
{
    public class MedicamentosController : Controller
    {

        public static List<Medicamento> MedtList()
        {
            List<Medicamento> listaS = new List<Medicamento>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient med = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = med.lista_medicamentos();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_MEDICAMENTO"].ToString());
                string nombre = dr["NOMBRE_MEDICAMENTO"].ToString();
                string descripcion = dr["DESCRIPCION_MEDICAMENTO"].ToString();
                int cantidad = int.Parse(dr["CANTIDAD"].ToString());
                string presentacion = dr["PRESENTACION"].ToString();
                double precio = double.Parse(dr["PRECIO_UNITARIO"].ToString());
                string estado = dr["ESTADO"].ToString();
                Medicamento medic = new Medicamento();
                medic.id = id;
                medic.NOMBRE_MEDICAMENTO = nombre;
                medic.DESCRIPCION_MEDICAMENTO = descripcion;
                medic.CANTIDAD = cantidad;
                medic.PRESENTACION = presentacion;
                medic.PRECIO_UNITARIO = precio;
                medic.ESTADO = estado;
                listaS.Add(medic);
            }
            return listaS;
        }
        [NonAction]
        public static List<Medicamento> TodosMedicamentos()
        {
            List<Medicamento> listaS = new List<Medicamento>();
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient med = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            DataSet ds = med.lista_medicamentos();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = int.Parse(dr["ID_MEDICAMENTO"].ToString());
                string nombre = dr["NOMBRE_MEDICAMENTO"].ToString();
                string descripcion = dr["DESCRIPCION_MEDICAMENTO"].ToString();
                int cantidad = int.Parse(dr["CANTIDAD"].ToString());
                string presentacion = dr["PRESENTACION"].ToString();
                double precio = double.Parse(dr["PRECIO_UNITARIO"].ToString());
                string estado = dr["ESTADO"].ToString();
                Medicamento medic = new Medicamento();
                medic.id = id;
                medic.NOMBRE_MEDICAMENTO = nombre;
                medic.DESCRIPCION_MEDICAMENTO = descripcion;
                medic.CANTIDAD = cantidad;
                medic.PRESENTACION = presentacion;
                medic.PRECIO_UNITARIO = precio;
                medic.ESTADO = estado;
                listaS.Add(medic);
            }
            return listaS;
        }
        // GET: Medicamentos
        public ActionResult Index(int? i, string BuscarTipo)
        {
            SistemaClinico.SistemaClinicoSoapWS.ClinicaWebServiceSoapClient swEnf = new SistemaClinico.SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            List<SelectListItem> listatipo = new List<SelectListItem>();
            listatipo.Add(new SelectListItem
            {
                Text = "Todos",
                Value = ""
            });
            listatipo.Add(new SelectListItem
            {
                Text = "Líquido",
                Value = "LIQUIDO"
            });
            listatipo.Add(new SelectListItem
            {
                Text = "Tableta",
                Value = "TABLETA"
            });
            listatipo.Add(new SelectListItem
            {
                Text = "Píldora",
                Value = "PILDORA"
            });
            listatipo.Add(new SelectListItem
            {
                Text = "Inyectable",
                Value = "INYECTABLE"
            });
            listatipo.Add(new SelectListItem
            {
                Text = "Tópico",
                Value = "TOPICO"
            });

            var Medicamento = from e in MedtList()
                                  //orderby e.nombre
                              select e;
            if (!String.IsNullOrEmpty(BuscarTipo))
            {
                Medicamento = Medicamento.Where(c => c.PRESENTACION.ToLower().Contains(BuscarTipo.ToLower()));
            }
            ViewData["listaTipo"] = listatipo;

            return View(Medicamento.ToPagedList(i ?? 1, 3));
        }

        // GET: Medicamentos/Details/5
        public ActionResult Details(int id)
        {
            List<Medicamento> Medi = MedtList();

            var me = Medi.Single(m => m.id == id);
            return View(me);
            //return View();
        }

        // GET: Medicamentos/Create
        public ActionResult Create()
        {
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
            ViewData["listaEstado"] = listaEstados;

            //Para la lista de presentacion 

            List<SelectListItem> listaPresentacion = new List<SelectListItem>();
            listaPresentacion.Add(new SelectListItem
            {
                Text = "Líquido",
                Value = "LIQUIDO"
            });
            listaPresentacion.Add(new SelectListItem
            {
                Text = "Tableta",
                Value = "TABLETA"
            });
            listaPresentacion.Add(new SelectListItem
            {
                Text = "Píldora",
                Value = "PILDORA"
            });
            listaPresentacion.Add(new SelectListItem
            {
                Text = "Inyectable",
                Value = "INYECTABLE"
            });
            listaPresentacion.Add(new SelectListItem
            {
                Text = "Tópico",
                Value = "TOPICO"
            });
            ViewData["listaPresentacion"] = listaPresentacion;


            return View();
        }

        // POST: Medicamentos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            //try
            //{
                // TODO: Add insert logic here

                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient swMed = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                Medicamento nuevoMed = new Medicamento();
                nuevoMed.NOMBRE_MEDICAMENTO = collection["NOMBRE_MEDICAMENTO"];
                nuevoMed.DESCRIPCION_MEDICAMENTO = collection["DESCRIPCION_MEDICAMENTO"];
                nuevoMed.CANTIDAD = int.Parse(collection["CANTIDAD"]);
                nuevoMed.PRESENTACION = collection["PRESENTACION"];
                nuevoMed.PRECIO_UNITARIO = double.Parse(collection["PRECIO_UNITARIO"]);
                nuevoMed.ESTADO = collection["ESTADO"];
                swMed.Insert_Medicamento(nuevoMed.NOMBRE_MEDICAMENTO, nuevoMed.DESCRIPCION_MEDICAMENTO, nuevoMed.CANTIDAD, nuevoMed.PRESENTACION, nuevoMed.PRECIO_UNITARIO, nuevoMed.ESTADO);
               
            //}
            //catch
            //{
            //    return RedirectToAction("Index");
            //}
            return RedirectToActionPermanent("Index");
        }

        // GET: Medicamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            List<Medicamento> sintList = TodosMedicamentos();
            if (id.HasValue)
            {
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
                ViewData["listaEstado"] = listaEstados;

                //Para la lista de presentacion 

                List<SelectListItem> listaPresentacion = new List<SelectListItem>();
                listaPresentacion.Add(new SelectListItem
                {
                    Text = "Líquido",
                    Value = "LIQUIDO"
                });
                listaPresentacion.Add(new SelectListItem
                {
                    Text = "Tableta",
                    Value = "TABLETA"
                });
                listaPresentacion.Add(new SelectListItem
                {
                    Text = "Píldora",
                    Value = "PILDORA"
                });
                listaPresentacion.Add(new SelectListItem
                {
                    Text = "Inyectable",
                    Value = "INYECTABLE"
                });
                listaPresentacion.Add(new SelectListItem
                {
                    Text = "Tópico",
                    Value = "TOPICO"
                });
                ViewData["listaPresentacion"] = listaPresentacion;

                var sint = sintList.Single(m => m.id == id);
                return View(sint);
            }
            return View();
        }

        // POST: Medicamentos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient updateSintoma = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();

            try
            {
                // TODO: Add update logic here
                List<Medicamento> MedList = MedtList();
                var med = MedList.Single(m => m.id == id);
                if (TryUpdateModel(med))
                {
                    updateSintoma.actualizar_medicamento(med.id,med.NOMBRE_MEDICAMENTO, med.DESCRIPCION_MEDICAMENTO, med.CANTIDAD, med.PRESENTACION, med.PRECIO_UNITARIO, med.ESTADO);
                    return RedirectToAction("Index");
                }
                return View(med);
            }
            catch
            {
                return View();
            }
        }

        // GET: Medicamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            List<Medicamento> MedList = MedtList();
            if (id.HasValue)
            {
                var sint = MedList.Single(m => m.id == id);
                return View(sint);
            }
            return View();
        }

        // POST: Medicamentos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                SistemaClinicoSoapWS.ClinicaWebServiceSoapClient Med = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                List<Medicamento> MedList = MedtList();
                var Medica = MedList.Single(m => m.id == id);
                Medicamento nuevoMed = new Models.Medicamento();
                nuevoMed.NOMBRE_MEDICAMENTO = Medica.NOMBRE_MEDICAMENTO.ToString();
                nuevoMed.DESCRIPCION_MEDICAMENTO = Medica.DESCRIPCION_MEDICAMENTO.ToString();
                nuevoMed.CANTIDAD = int.Parse(Medica.CANTIDAD.ToString());
                nuevoMed.PRESENTACION = Medica.PRESENTACION.ToString();
                nuevoMed.PRECIO_UNITARIO = double.Parse(Medica.PRECIO_UNITARIO.ToString());
                nuevoMed.ESTADO = Medica.ESTADO.ToString();
                Med.eliminar_medicamento(id);
                if (TryUpdateModel(Medica))
                {
                    Med.eliminar_medicamento(Medica.id);
                    return RedirectToAction("Index");
                }
                return View(Medica);
            }
            catch
            {
                return View();
            }
        }
    }
}
