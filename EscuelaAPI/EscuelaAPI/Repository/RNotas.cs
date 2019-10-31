using EscuelaAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EscuelaAPI.Repository
{
    public class RNotas : IRepository<notas>
    {

        /// <summary>
        /// Aca elimino un dato si existe 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool delete(int id)
        {
            using (var db = new dbmodels())
            {
                db.Configuration.ProxyCreationEnabled = false;
                var dato = db.notas.Find(id);
                try
                {
                    db.notas.Remove(dato);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {

                    Debug.Print(e.Message);
                    return false;
                }
            }
        }

        //devuelvo todas las notas
        public IEnumerable<notas> getAll()
        {
            using (var db = new dbmodels())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.notas.ToList();
            }
        }


        /// <summary>
        /// Retorno una nota segun se mando a pedir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public notas getById(int id)
        {
            using (var db = new dbmodels())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.notas.Find(id);
            }
        }

        /// <summary>
        /// Intento agregar  a la base de datos el objeto recibido y se calcula el promedio
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool post(notas item)
        {
            using (var db = new dbmodels())
            {

                try
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    item = this.calcularPromedioEstado(item);
                    db.notas.Add(item);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {

                    Debug.Print(e.Message);
                    return false;
                }
            }
        }
        /// <summary>
        /// Aca programa el objeto que vuelva a guardarse y cambie sus valores de la actualizacion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool put(int id, notas item)
        {
            using (var db = new dbmodels())
            {
                db.Configuration.ProxyCreationEnabled = false;
                var dato = db.notas.Find(id);
                if (dato == null)
                {
                    return false;
                }
                try
                {
                    dato.nota1 = item.nota1;
                    dato.nota2 = item.nota2;
                    dato.nota3 = item.nota3;
                    item = this.calcularPromedioEstado(item);
                    dato.estado = item.estado;
                    dato.promedio = item.promedio;

                    db.Entry(dato).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {

                    Debug.Print(e.Message);
                    return false;
                }
            }
        }

        public notas calcularPromedioEstado(notas item)
        {

            float? num1 = item.nota1.HasValue ? item.nota1 : 0;
            float? num2 = item.nota2.HasValue ? item.nota2 : 0;
            float? num3 = item.nota3.HasValue ? item.nota3 : 0;

            item.promedio = (num1 + num2 + num3) / 3;
            item.estado = item.promedio >= 6 ? "Aprobado" : "Reprobado";
            return item;
        }
    }
}