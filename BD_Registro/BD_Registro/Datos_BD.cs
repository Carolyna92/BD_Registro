using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace BD_Registro
{
    public class Datos_BD
    {
        string id;
        int matricula;
        string nombre;
        string apellidos;
        string direccion;
        string telefono;
        int carrera;
        int semestre;
        string correo;
        string gh;
        bool deleted;

        //[MaxLength(8), PrimaryKey, Unique]
        [JsonProperty(PropertyName ="id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        [JsonProperty(PropertyName = "matricula")]
        public int Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }
        [JsonProperty(PropertyName = "nombre")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        [JsonProperty(PropertyName = "apellidos")]
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        [JsonProperty(PropertyName = "direccion")]
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        [JsonProperty(PropertyName = "telefono")]
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        [JsonProperty(PropertyName = "carrera")]
        public int Carrera
        {
            get { return carrera; }
            set { carrera = value; }
        }
        [JsonProperty(PropertyName = "semestre")]
        public int Semestre
        {
            get { return semestre; }
            set { semestre = value; }
        }
        [JsonProperty(PropertyName = "correo")]
        public string Email
        {
            get { return correo; }
            set { correo = value; }
        }
        [JsonProperty(PropertyName = "gh")]
        public string Git_Hub
        {
            get { return gh; }
            set { gh = value; }
        }

        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
