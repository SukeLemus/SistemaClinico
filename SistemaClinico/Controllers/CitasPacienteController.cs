﻿using SistemaClinico.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaClinico.Controllers
{
    public class CitasPacienteController : Controller
    {
        //GET TODO LOS PACIENTES
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


        // GET: CitasPaciente
        public ActionResult Index()
        {
            return View();
        }

        // GET: CitasPaciente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CitasPaciente/Create
        public ActionResult Create(int? id2)
        {
            //Lista de turnos de cita (AM o PM)
            List<SelectListItem> listaTurno = new List<SelectListItem>();
            listaTurno.Add(new SelectListItem
            {
                Text = "Matutino",
                Value = "Matutino"
            });
            listaTurno.Add(new SelectListItem
            {
                Text = "Vespertino",
                Value = "Vespertino"
            });
            ViewData["listaTurno"]= listaTurno;

            // lista de tipo de cita(consulta, emergencia)
            List<SelectListItem> listaTipo = new List<SelectListItem>();
            listaTipo.Add(new SelectListItem
            {
                Text = "Consulta médica",
                Value = "Consulta médica"
            });
            listaTipo.Add(new SelectListItem
            {
                Text = "Control",
                Value = "Control"
            });
            listaTipo.Add(new SelectListItem
            {
                Text = "Emergencia",
                Value = "Emergencia"
            });
            ViewData["listaTipo"] = listaTipo;
            //LISTA AREA
            SistemaClinicoSoapWS.ClinicaWebServiceSoapClient depaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
            var selectList = new List<SelectListItem>();
            DataSet ds = depaWS.ListaAreas();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string id = dr["ID_AREA"].ToString();
                string nombre_area = dr["NOMBRE_AREA"].ToString();

                selectList.Add(new SelectListItem
                {
                    Value = id,
                    Text = nombre_area,
                });
            }
            ViewData["ListaNombreAreas"] = selectList;
            //LISTA DEPARTAMENTO
            var selectList2 = new List<SelectListItem>();
            DataSet ds2 = depaWS.ListaDepa();

            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                string id = dr["ID_DEPARTAMENTO"].ToString();
                string nombre_dpto = dr["NOMBRE_DEPARTAMENTO"].ToString();

                selectList2.Add(new SelectListItem
                {
                    Value = id,
                    Text = nombre_dpto,
                });
            }
            ViewData["ListaNombreDeptos"] = selectList2;

            //obteniendo datos paciente
            List<RegistroPacienteUsuario> PaList = TodosUsuarios();
            if (id2.HasValue)
            {
                var p = PaList.Single(m => m.id == id2);
                string nombre_paciente = p.NOMBRE;
            string telefono = p.TELEFONO;
            string correo = p.CORREO;
                ViewData["NOMBRE"] = nombre_paciente;
                ViewData["TELEFONO"] = telefono;
                ViewData["CORREO"] = correo;
                //return View(p);
            }
            return View();
        }

        // POST: CitasPaciente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (Session["Rol"] != null && Session["Rol"].Equals(1))
            {
                try
                {
                    SistemaClinicoSoapWS.ClinicaWebServiceSoapClient depaWS = new SistemaClinicoSoapWS.ClinicaWebServiceSoapClient();
                    CitasPaciente nuevacita = new Models.CitasPaciente();
                    nuevacita.ID_PACIENTE = int.Parse(Session["id"].ToString());
                    nuevacita.FECHA = collection["FECHA"];
                    nuevacita.HORA = "00:00";
                    nuevacita.TURNO = collection["TURNO"];
                    nuevacita.TIPO_CITA = collection["TIPO_CITA"];
                    nuevacita.ID_DEPARTAMENTO = int.Parse(collection["ID_DEPARTAMENTO"].ToString());
                    nuevacita.DESCRIPCION = collection["DESCRIPCION"];
                    nuevacita.ESTADO = "PENDIENTE";

                    depaWS.InsertCita(nuevacita.ID_PACIENTE, nuevacita.FECHA, nuevacita.HORA, nuevacita.TURNO, nuevacita.TIPO_CITA, nuevacita.ID_DEPARTAMENTO, nuevacita.DESCRIPCION, nuevacita.ESTADO);
                   
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
            return RedirectToAction("Index", "Home");
        }

        // GET: CitasPaciente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CitasPaciente/Edit/5
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

        // GET: CitasPaciente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CitasPaciente/Delete/5
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
