using EscuelaAPP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaAPP.Services
{
    public static class APIrest
    {
        #region Atributos y propiedades
        private static HttpClient client;
        private static string controller = "notas";
        #endregion

        /// <summary>
        /// Inicializo los datos del cliente para facilidad de uso en los metodos
        /// </summary>
        static APIrest()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://www.testingris.somee.com/api/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicacion/json"));
        }

        /// <summary>
        /// Hacer un post al API
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static async Task<bool> post(notas item)
        {
            try
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                var content = new StringContent(json,Encoding.UTF8,"application/json");
                var response = await client.PostAsync(controller,content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return false;
            }
        }


        /// <summary>
        /// OBTIENE TODAS LAS NOTAS DEL API
        /// </summary>
        /// <returns></returns>
        public static async Task<List<notas>> getAll()
        {
            try
            {
                var response = await client.GetAsync(controller);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<notas>>(response.Content.ReadAsStringAsync().Result);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return new List<notas>();
            }
        }


        /// <summary>
        /// OBTIENE UNA NOTA SEGUN EL ID del bloque de notas desde el API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<notas> getbyId(int id)
        {
            try
            {
                var response = await client.GetAsync(controller + "/" + id.ToString());
                return Newtonsoft.Json.JsonConvert.DeserializeObject<notas>(response.Content.ReadAsStringAsync().Result);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return new notas();
            }
        }


        /// <summary>
        /// ELIMINA EL OBJETO EN LA BASE DE DATOS POR MEDIO DEL API segun el ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<bool> delete(int id)
        {
            try
            {
                var response = await client.DeleteAsync(controller+"/"+id.ToString());
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return false;
            }
        }


        /// <summary>
        /// ACTUALIZA EL OBJETO EN EL API
        /// </summary>
        /// <param name="id">nota</param>
        /// <param name="item">nota</param>
        /// <returns></returns>
        public static async Task<bool> put(int id,notas item)
        {
            try
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                var content = new StringContent(json,Encoding.UTF8,"application/json");
                var response = await client.PutAsync(controller + "/" + id.ToString(), content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return false;
            }
        }


    }
}
