using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//REFERENCIAS
using LF_repaso_DSWI_rq.Models;

namespace LF_repaso_DSWI_rq.Controllers
{
    public class ValuesController : ApiController
    {
        //INSTANCIA DE LA BD
        Negocios2017Entities2 bd = new Negocios2017Entities2();
        
        // GET api/values
        public IEnumerable<tb_clientes> Get()
        {
            return bd.tb_clientes.ToList();
        }

        // GET api/values/5
        public tb_clientes Get(string id)
        {
            return bd.tb_clientes.Where(c=> c.IdCliente == id).FirstOrDefault();
        }

        public IEnumerable<tb_paises> GetPaises()
        {
            return bd.tb_paises.ToList();
        }

        // POST api/values
        public void Post(tb_clientes reg)
        {
            try
            {
                tb_clientes obj = new tb_clientes();
                obj.IdCliente = reg.IdCliente;
                obj.NombreCia = reg.NombreCia;
                obj.Direccion = reg.Direccion;
                obj.idpais = reg.idpais;
                obj.Telefono = reg.Telefono;


                bd.tb_clientes.Add(reg);
                bd.SaveChanges();
            }
            catch(Exception) { }
        }

        // PUT api/values/5
        public void Put(tb_clientes reg)
        {
            bd.Entry(reg).State = System.Data.Entity.EntityState.Modified;
            bd.SaveChanges();
        }

        // DELETE api/values/5
        public void Delete(string id)
        {
            tb_clientes obj = Get(id); //Es el metodo que retorna un registro de cliente Get(id)
            bd.tb_clientes.Remove(obj); // Elimina el registro
            bd.SaveChanges();           // la BD guarda los cambios
        }
    }
}
