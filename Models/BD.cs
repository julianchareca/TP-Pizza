using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
namespace Pizzas.API.Models{
public class BD{
    private static string _connectionString = @"Server=A-PHZ2-CIDI-023dot ;DataBase=DAI-Pizzas;Trusted_Connection=True";
    public static List<Pizzas> ObtenerPizzas()
    {
        List<Pizzas> lista = new List<Pizzas>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            lista = connection.Query<Pizzas>("SELECT * FROM Pizzas").AsList();
        }
        return lista;
    }

    public static Pizzas ObtenerPizzas(int id)
    {
        Pizzas? Pizzas = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            Pizzas = connection.QueryFirstOrDefault<Pizzas>("SELECT * FROM Pizzas WHERE Id = @pId", new { pId = id });
        }
        return Pizzas;
    }

    public static void InsertarPizzas(Pizzas p)
    {
        string sql = "INSERT INTO Pizzas VALUES (@pNombre, @pLibreGluten, @pImporte, @pDescripcion)";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(sql, new { pNombre = p.Nombre, pLibreGluten = p.LibreGluten, pImporte = p.Importe, pDescripcion = p.Descripcion });
        }
    }
public static int UpdateById(Pizzas pizza) {

string sqlQuery;

int intRowsAffected = 0;

sqlQuery = "UPDATE Pizzas SET ";

sqlQuery += " Nombre = @nombre, ";

sqlQuery += " LibreGluten = @libreGluten, ";

sqlQuery += " Importe = @importe, ";

sqlQuery += " Descripcion = @descripcion ";

sqlQuery += "WHERE Id = @idPizza";

using (var db = new SqlConnection(_connectionString)) {

intRowsAffected = db.Execute(sqlQuery, new {

idPizza = pizza.Id,

nombre = pizza.Nombre,

libreGluten = pizza.LibreGluten,

importe = pizza.Importe,

descripcion = pizza.Descripcion

}

);

}

return intRowsAffected;

}
    
    public static void EliminarPizzas(int id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute("DELETE FROM Pizzas WHERE Id = @pId", new { pId = id });
        }
    }
    }
}