using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
namespace TP6_Elecciones.Models;

public static class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=Elecciones2023;Trusted_Connection=True;";

    public static void AgregarCandidato(Candidato can)
    {
        string SQL = "INSERT INTO Candidato(IdPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion) VALUES ( @pIdPartido, @pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pPostulacion)";
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            DB.Execute(SQL, new {pIdPartido = can.IdPartido, pApellido = can.Apellido, pNombre = can.Nombre, pFechaNacimiento = can.FechaNacimiento, pFoto = can.Foto, pPostulacion = can.Postulacion});
        }
    }
    public static void EliminarCandidato(int id)
    {
        string SQL = "Delete from Candidato where IdCandidato = @idcand";
         using (SqlConnection DB = new SqlConnection(_connectionString))
         {
           DB.Execute(SQL, new {idcand = id});
         }
    }
    public static Partido VerInfoPartido(int IdPar)
    {
        Partido infoPart;
        using (SqlConnection DB = new SqlConnection(_connectionString)){
        string SQL = "select * from Partido where IdPartido = @pIdPar";
            infoPart = DB.QueryFirstOrDefault<Partido>(SQL, new {pIdPar = IdPar});
        }
        return infoPart;
    }
    public static Candidato VerInfoCandidato(int idCand)
    {
        Candidato infoCand;
        using (SqlConnection DB = new SqlConnection(_connectionString)){
        string SQL = "select * from Candidato where IdCandidato = @pidCand";
        infoCand = DB.QueryFirstOrDefault<Candidato>(SQL, new { pidCand = idCand });
        }
        return infoCand;
    }
    public static List<Partido> ListarPartidos()
    {
        List<Partido> listadoPartidos = new List<Partido>();
        using (SqlConnection DB = new SqlConnection(_connectionString)){
        string SQL = "select * from Partido";
        listadoPartidos = DB.Query<Partido>(SQL).ToList();
        }
        return listadoPartidos;
    }
    public static List<Candidato> ListarCandidatos(int idPartido)
    {
        List<Candidato> listadoCandidatos = new List<Candidato>();
        using (SqlConnection DB = new SqlConnection(_connectionString)){
        string SQL = "SELECT * FROM Candidato WHERE IdPartido = @pIdPartido";
        listadoCandidatos = DB.Query<Candidato>(SQL, new{pIdPartido = idPartido}).ToList();
        }
        return listadoCandidatos;
    }
}