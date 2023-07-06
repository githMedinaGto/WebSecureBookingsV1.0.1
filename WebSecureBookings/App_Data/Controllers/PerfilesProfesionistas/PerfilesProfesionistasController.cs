﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSecureBookings.App_Data.Models;

namespace WebSecureBookings
{
    public class PerfilesProfesionistasController
    {
        [HttpGet]
        public ResponseModel<List<UsuarioModel>> GetProfesionistas()
        {

            try
            {
                using (var dbContext = new DB_WSBEntities())
                {
                    var lst = (from d in dbContext.tUsuario
                               join m in dbContext.tMunicipio on d.idMunicipio equals m.idMunicipio into municipioGroup
                               from m in municipioGroup.DefaultIfEmpty()
                               join e in dbContext.tEstado on m.idMunicipio equals e.idMunicipio into estadoGroup
                               from e in estadoGroup.DefaultIfEmpty()
                               select new
                               {
                                   Usuario = d,
                                   Municipio = m != null ? m.sMunicipio : null,
                                   Estado = e != null ? e.sEstado : null
                               }).ToList();

                    var usuarios = lst.Select(item => new UsuarioModel
                    {
                        idUsuario = item.Usuario.idUsuario,
                        sNombre = item.Usuario.sNombre,
                        sApellidoP = item.Usuario.sApellidoP,
                        sApellidoM = item.Usuario.sApellidoM,
                        sProfecion = item.Usuario.sProfecion,
                        sAreaProfesion = item.Usuario.sAreaProfesion,
                        stelefono = item.Usuario.stelefono,
                        sCorreo = item.Usuario.sCorreo,
                        idMunicipio = (int)item.Usuario.idMunicipio,
                        sColonia = item.Usuario.sColonia,
                        sCalle = item.Usuario.sCalle,
                        sMunicipio = item.Municipio,
                        sEstado = item.Estado
                    }).ToList();

                    return new ResponseModel<List<UsuarioModel>>
                    {
                        StatusCode = 200,
                        Message = "Datos obtenidos correctamente",
                        Data = usuarios
                    };
                }



            }
            catch (Exception ex)
            {
                // Manejo de errores específicos y retorno de la respuesta personalizada
                if (ex is SqlException)
                {
                    // Error específico de SQL
                    return new ResponseModel<List<UsuarioModel>>
                    {
                        StatusCode = 500,
                        Message = "Error en la base de datos: " + ex.Message,
                        Data = null
                    };
                }
                else
                {
                    // Otros errores
                    return new ResponseModel<List<UsuarioModel>>
                    {
                        StatusCode = 404,
                        Message = "No se pudo obtener los datos de la base de datos: " + ex.Message,
                        Data = null
                    };
                }
            }
        }

        [HttpGet]
        public ResponseModel<List<string>> GetProfesiones()
        {

            try
            {
                using (var dbContext = new DB_WSBEntities())
                {
                    var profesiones = (from d in dbContext.tUsuario
                                       select d.sProfecion).Distinct().ToList();

                    return new ResponseModel<List<string>>
                    {
                        StatusCode = 200,
                        Message = "Datos obtenidos correctamente",
                        Data = profesiones
                    };
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores específicos y retorno de la respuesta personalizada
                if (ex is SqlException)
                {
                    // Error específico de SQL
                    return new ResponseModel<List<string>>
                    {
                        StatusCode = 500,
                        Message = "Error en la base de datos: " + ex.Message,
                        Data = null
                    };
                }
                else
                {
                    // Otros errores
                    return new ResponseModel<List<string>>
                    {
                        StatusCode = 404,
                        Message = "No se pudo obtener los datos de la base de datos: " + ex.Message,
                        Data = null
                    };
                }
            }
        }

        [HttpGet]
        public ResponseModel<List<EstadoModel>> GetCiudades()
        {

            try
            {
                using (var dbContext = new DB_WSBEntities())
                {
                    var lst = (from d in dbContext.tEstado
                               select new EstadoModel
                               {
                                   idEstado = d.idEstado,
                                   sEstado = d.sEstado,
                                   idMunicipio = (int)d.idMunicipio
                               }).ToList();

                    return new ResponseModel<List<EstadoModel>>
                    {
                        StatusCode = 200,
                        Message = "Datos obtenidos correctamente",
                        Data = lst
                    };
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores específicos y retorno de la respuesta personalizada
                if (ex is SqlException)
                {
                    // Error específico de SQL
                    return new ResponseModel<List<EstadoModel>>
                    {
                        StatusCode = 500,
                        Message = "Error en la base de datos: " + ex.Message,
                        Data = null
                    };
                }
                else
                {
                    // Otros errores
                    return new ResponseModel<List<EstadoModel>>
                    {
                        StatusCode = 404,
                        Message = "No se pudo obtener los datos de la base de datos: " + ex.Message,
                        Data = null
                    };
                }
            }
        }

        [HttpGet]
        public ResponseModel<List<UsuarioModel>> GetProfesionistasFiltro(string sProfesion, int iEstado)
        {
            try
            {
                using (var dbContext = new DB_WSBEntities())
                {
                    
                    var lst = (from d in dbContext.tUsuario
                               join m in dbContext.tMunicipio on d.idMunicipio equals m.idMunicipio into municipioGroup
                               from m in municipioGroup.DefaultIfEmpty()
                               join e in dbContext.tEstado on m.idMunicipio equals e.idMunicipio into estadoGroup
                               from e in estadoGroup.DefaultIfEmpty()
                               where e.idEstado == iEstado || d.sProfecion == sProfesion // Aplicar el filtro
                               select new
                               {
                                   Usuario = d,
                                   Municipio = m != null ? m.sMunicipio : null,
                                   Estado = e != null ? e.sEstado : null
                               }).ToList();

                    var usuarios = lst.Select(item => new UsuarioModel
                    {
                        idUsuario = item.Usuario.idUsuario,
                        sNombre = item.Usuario.sNombre,
                        sApellidoP = item.Usuario.sApellidoP,
                        sApellidoM = item.Usuario.sApellidoM,
                        sProfecion = item.Usuario.sProfecion,
                        sAreaProfesion = item.Usuario.sAreaProfesion,
                        stelefono = item.Usuario.stelefono,
                        sCorreo = item.Usuario.sCorreo,
                        idMunicipio = (int)item.Usuario.idMunicipio,
                        sColonia = item.Usuario.sColonia,
                        sCalle = item.Usuario.sCalle,
                        sMunicipio = item.Municipio,
                        sEstado = item.Estado
                    }).ToList();

                    return new ResponseModel<List<UsuarioModel>>
                    {
                        StatusCode = 200,
                        Message = "Datos obtenidos correctamente",
                        Data = usuarios
                    };
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return new ResponseModel<List<UsuarioModel>>
                {
                    StatusCode = 500,
                    Message = "Error al obtener los datos: " + ex.Message,
                    Data = null
                };
            }
        }

    }
}