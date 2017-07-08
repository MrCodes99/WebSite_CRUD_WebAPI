using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//REFERENCIA
using LF_repaso_DSWI_rq.Models;

namespace LF_repaso_DSWI_rq.Controllers
{
    public class HomeController : Controller
    {
        // Instancia de los metodos 
        ValuesController bd = new ValuesController();

        int numreg = 10;
        public ActionResult Index(int? pag = 0)
    {   
            //RECUPERO LA CANTIDAD DE REGISTROS Y ALMACENO EL NUMERO DE REGISTRO
            int c = bd.Get().Count(); // listado() es el metodo del List de la tabla que te pidan

            ViewBag.numreg = c % numreg != 0 ? c / numreg + 1 : c / numreg;

            //DEFINIR LA PAGINA ACTUAL, EL reg DE INICIO Y reg FINAL
            int pagact = (int)pag;
            int reginicio = pagact * numreg;
            int regfin = reginicio + numreg;

            //VARIABLE QUE ALMACENARA LOS CLIENTES PARA LA PAGINACION
            List<tb_clientes> lista = new List<tb_clientes>();
            for (int i = reginicio; i < regfin; i++)
            {
                if (i == c)
                    break; //SI i ES IGUAL A NUMERO DE reg SALIR
                lista.Add(bd.Get().ToList()[i]);
            }

            return View(lista);
        }

        public ActionResult Create()
        {
            ViewBag.paises = new SelectList(bd.GetPaises(), "idpais", "nombrepais");

            return View(new tb_clientes());
        }
            
        [HttpPost]
        public ActionResult Create(tb_clientes reg)
        {   
            if(!ModelState.IsValid)
            {
                return View(reg);
            }

            bd.Post(reg);
            return RedirectToAction("Index");
        }   
            
        public ActionResult Details(string id)
        {
            return View(bd.Get(id));
        }

        public ActionResult Edit(string id)
        {
            tb_clientes reg = bd.Get(id);

            ViewBag.paises = new SelectList(bd.GetPaises(), "idpais", "nombrepais", reg.idpais);

            return View(reg);
        }

        [HttpPost]
        public ActionResult Edit(tb_clientes reg)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.paises = new SelectList(bd.GetPaises(), "idpais", "nombrepais", reg.idpais);
                return View(reg);
            }
            bd.Put(reg);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            bd.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
