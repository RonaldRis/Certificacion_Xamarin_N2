using EscuelaAPI.Models;
using EscuelaAPI.Repository;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EscuelaAPI.Controllers
{
    public class notasController : ApiController
    {
        private readonly RNotas r = new RNotas();

        /// <summary>
        /// Retorno todas las notas que existen en la base de datos
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage getall()
        {
            return Request.CreateResponse(HttpStatusCode.OK, r.getAll());
        }


        /// <summary>
        /// Retorno el elemento seleccionado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage getbyId(int id)
        {
            var dato = r.getById(id);
            if (dato == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Datos no encontrados");
            }
            return Request.CreateResponse(HttpStatusCode.OK, dato);
        }

        /// <summary>
        /// Si se reciben datos, entonces vengo y los guardo en la base de datos
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public HttpResponseMessage post(notas item)
        {
            if (item == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Datos no válidos");

            }
            if (r.post(item))
            {
                return Request.CreateResponse(HttpStatusCode.Created, "Datos guardados");
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "No es posible guardar datos en estos momentos");
        }

        /// <summary>
        /// Elimino el dato de la base de datos en caso que exista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage delete(int id)
        {
            if (r.getById(id)==null)
            {
            return Request.CreateResponse(HttpStatusCode.OK, "El dato ya ha sido eliminado o no existe en la base de datos, por favor actualice la pantalla donde se encuentra");
            }
            if (r.delete(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "El dato ha sido eliminado");

            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "No es posible eliminar datos en estos momentos");
        }

        /// <summary>
        /// Actualizo los datos del controllador, ademas valido si existe el registro a acatualizar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public HttpResponseMessage put(int id, notas item)
        {
            if (r.getById(id) == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotImplemented, "El dato a modificar no existe");
            }
            if (r.put(id,item))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "El dato ha sido actualizado");
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "No es posible actualizar datos en estos momentos");
        }


    }
}
