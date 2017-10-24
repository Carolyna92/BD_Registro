using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_Registro
{
    public class Datos_BD
    {
        int matricula;
        string nombre;
        string apellidos;
        string direccion;
        string telefono;
        int carrera;
        int semestre;
        string correo;
        string gh;

        [MaxLength(8), PrimaryKey, Unique]
        public int Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }
        [MaxLength(50)]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        [MaxLength(50)]
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        [MaxLength(150)]
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        [MaxLength(10)]
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        [MaxLength(3)]
        public int Carrera
        {
            get { return carrera; }
            set { carrera = value; }
        }
        [MaxLength(3)]
        public int Semestre
        {
            get { return semestre; }
            set { semestre = value; }
        }
        [MaxLength(50)]
        public string Email
        {
            get { return correo; }
            set { correo = value; }
        }
        [MaxLength(50)]
        public string Git_Hub
        {
            get { return gh; }
            set { gh = value; }
        }
    }
}
