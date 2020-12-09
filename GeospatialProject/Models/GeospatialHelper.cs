﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GeospatialProject.Models
{
    public class GeospatialHelper
    {

        public static string CreateRectangleWKT(string Shape)
        {
            try
            {
                string WKT = "";
                var Datos = Shape.Split(',');

                double d1 = Convert.ToDouble(Datos[0]);
                double d2 = Convert.ToDouble(Datos[1]);
                double d3 = Convert.ToDouble(Datos[2]);
                double d4 = Convert.ToDouble(Datos[3]);
                int SRID = 4326;
                
                string connectionString = ConfigurationManager.ConnectionStrings["Geospatial"].ToString(); 
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);
                conn.Open();
                
                string Transact = "SELECT ST_AsText(ST_MakeEnvelope(@d1, @d2, @d3, @d4, @sr))";

                using (NpgsqlCommand cmd = new NpgsqlCommand(Transact, conn))
                {
                    cmd.Parameters.AddWithValue("@d1", d1);
                    cmd.Parameters.AddWithValue("@d2", d2);
                    cmd.Parameters.AddWithValue("@d3", d3);
                    cmd.Parameters.AddWithValue("@d4", d4);
                    cmd.Parameters.AddWithValue("@sr", SRID);
                    NpgsqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        WKT = dr[0].ToString();
                    }
                }

                conn.Close();
                return WKT;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static List<City> GetInformationByPolygon(string NewPolygon)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Geospatial"].ToString(); 
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);
                conn.Open();
                
                List<City> Information = new List<City>();
                
                string Transact = "SELECT * FROM geospatial.city WHERE ST_Intersects('SRID=4326;" + NewPolygon + "', geom)";
                
                using (NpgsqlCommand cmd = new NpgsqlCommand(Transact, conn))
                {
                    NpgsqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        City c = new City();
                        c.Id = Convert.ToInt32(dr[0].ToString());
                        c.Name = dr[1].ToString();
                        c.Lat = dr.IsDBNull(2) ? 0f : Convert.ToSingle(dr[2].ToString());
                        c.Lng = dr.IsDBNull(3) ? 0f : Convert.ToSingle(dr[3].ToString());
                        Information.Add(c);
                    }
                }

                conn.Close();
                return Information;

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static List<Supermarket> GetInformationByPolygonSupermarket(string NewPolygon)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Geospatial"].ToString();
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);
                conn.Open();

                List<Supermarket> Information = new List<Supermarket>();

                string Transact = "SELECT Nombre, idMunicipio FROM geospatial.supermercado WHERE ST_Intersects('SRID=4326;" + NewPolygon + "', geom)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(Transact, conn))
                {
                    NpgsqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Supermarket c = new Supermarket();
                        c.Nombre = dr[0].ToString();
                        c.idMunicipio = Convert.ToInt32(dr[1].ToString());
                        Information.Add(c);
                    }
                }

                conn.Close();
                return Information;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<City> GetAllCities()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Geospatial"].ToString();
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);
                conn.Open();

                List<City> Information = new List<City>();

                string Transact = "SELECT * FROM geospatial.city";

                using (NpgsqlCommand cmd = new NpgsqlCommand(Transact, conn))
                {
                    NpgsqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        City c = new City();
                        c.Id = Convert.ToInt32(dr[0].ToString());
                        c.Name = dr[1].ToString();
                        c.Lat = dr.IsDBNull(2) ? 0f : Convert.ToSingle(dr[2].ToString());
                        c.Lng = dr.IsDBNull(3) ? 0f : Convert.ToSingle(dr[3].ToString());
                        Information.Add(c);
                    }
                }

                conn.Close();
                return Information;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<Supermarket> GetAllSupermarkets()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Geospatial"].ToString();
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);
                conn.Open();

                List<Supermarket> Information = new List<Supermarket>();

                string Transact = "SELECT Nombre, idMunicipio FROM geospatial.supermercado";

                using (NpgsqlCommand cmd = new NpgsqlCommand(Transact, conn))
                {
                    NpgsqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Supermarket c = new Supermarket();
                        c.Nombre = dr[0].ToString();
                        c.idMunicipio = Convert.ToInt32(dr[1].ToString());
                        
                        Information.Add(c);
                    }
                }

                conn.Close();
                return Information;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<Sismo> GetAllSismos()
        {
            List<Sismo> Information = new List<Sismo>();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Geospatial"].ToString();
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);
                conn.Open();

                
                string Transact = "SELECT * FROM geospatial.allsismos";

                using (NpgsqlCommand cmd = new NpgsqlCommand(Transact, conn))
                {
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Sismo s = new Sismo();
                        s.magnitud = Convert.ToDouble(dr[0].ToString());
                        s.profundidad = Convert.ToDouble(dr[1].ToString());
                        s.departamento = dr[2].ToString();
                        s.anio = Convert.ToInt32(dr[3].ToString());

                        Information.Add(s);
                    }

                }

                conn.Close();
                return Information;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<Sismo> GetInformationByPolygonSismo(string NewPolygon)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Geospatial"].ToString();
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);
                conn.Open();

                List<Sismo> Information = new List<Sismo>();

                string Transact = "SELECT * FROM geospatial.allsismo WHERE ST_Intersects('SRID=4326;" + NewPolygon + "', geom)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(Transact, conn))
                {
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Sismo s = new Sismo();
                        s.magnitud = Convert.ToDouble(dr[0].ToString());
                        s.profundidad = Convert.ToDouble(dr[1].ToString());
                        s.departamento = dr[2].ToString();
                        s.anio = Convert.ToInt32(dr[3].ToString());

                        Information.Add(s);
                    }
                }

                conn.Close();
                return Information;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}