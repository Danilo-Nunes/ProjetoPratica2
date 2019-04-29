/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package bd.dao;
import java.sql.SQLException;
import bd.BDSQLServer;
import bd.core.MeuResultSet;
import br.metodista.modelo.Filme;
import java.util.ArrayList;

/**
 *
 * @author u18203
 */
public class Filmes {
    public static boolean cadastrado (int codigo) throws Exception
    {
        boolean retorno = false;

        try
        {
            String sql;

            sql = "SELECT * " +
                  "FROM Filmes " +
                  "WHERE CODIGO = ?";

            BDSQLServer.COMANDO.prepareStatement (sql);

            BDSQLServer.COMANDO.setInt (1, codigo);

            MeuResultSet resultado = (MeuResultSet)BDSQLServer.COMANDO.executeQuery ();

            retorno = resultado.first(); // pode-se usar resultado.last() ou resultado.next() ou resultado.previous() ou resultado.absotule(numeroDaLinha)

            /* // ou, se preferirmos,

            String sql;

            sql = "SELECT COUNT(*) AS QUANTOS " +
                  "FROM LIVROS " +
                  "WHERE CODIGO = ?";

            BDSQLServer.COMANDO.prepareStatement (sql);

            BDSQLServer.COMANDO.setInt (1, codigo);

            MeuResultSet resultado = (MeuResultSet)BDSQLServer.COMANDO.executeQuery ();

            resultado.first();

            retorno = resultado.getInt("QUANTOS") != 0;

            */
        }
        catch (SQLException erro)
        {
            throw new Exception ("Erro ao procurar pessoa");
        }

        return retorno;
    }

    public static void incluir (Filme filme) throws Exception
    {
        if (filme==null)
            throw new Exception ("filme nao fornecido");

        try
        {
            String sql;

            sql = "INSERT INTO Filmes " +
                  "(NOME, SINOPSE, GENERO, DURACAO, TRAILER) " +
                  "VALUES " +
                  "( ?, ?, ?, ?, ?)";

            BDSQLServer.COMANDO.prepareStatement (sql);

            //BDSQLServer.COMANDO.setInt    (1, pessoa.getCodigo ());
            BDSQLServer.COMANDO.setString (1, filme.getNome ());
            BDSQLServer.COMANDO.setString  (2, filme.getSinopse ());
            BDSQLServer.COMANDO.setString (3, filme.getGenero ());
            BDSQLServer.COMANDO.setInt  (4, filme.getDuracao());
            BDSQLServer.COMANDO.setString  (5, filme.getTrailer ());

            BDSQLServer.COMANDO.executeUpdate ();
            BDSQLServer.COMANDO.commit        ();
        }
        catch (SQLException erro)
        {
            throw new Exception ("Erro ao inserir filme");
        }
    }

    public static void excluir (int codigo) throws Exception
    {
        if (!cadastrado (codigo))
            throw new Exception ("Nao cadastrado");

        try
        {
            String sql;

            sql = "DELETE FROM Filmes " +
                  "WHERE CODIGO=?";

            BDSQLServer.COMANDO.prepareStatement (sql);

            BDSQLServer.COMANDO.setInt (1, codigo);

            BDSQLServer.COMANDO.executeUpdate ();
            BDSQLServer.COMANDO.commit        ();        }
        catch (SQLException erro)
        {
            throw new Exception ("Erro ao excluir filme");
        }
    }

    public static void alterar (Filme filme) throws Exception
    {
        if (filme==null)
            throw new Exception ("Filme nao fornecido");

        if (!cadastrado (filme.getCodigo()))
            throw new Exception ("Nao cadastrado");

        try
        {
            String sql;

            sql = "UPDATE Filmes " +
                  "SET NOME=? " +
                  "SET SINOPSE=? " +
                  "SET GENERO=? " +
                  "SET DURACAO=? " +
                  "SET TRAILER=? " +
                  "WHERE CODIGO = ?";

            BDSQLServer.COMANDO.prepareStatement (sql);

            BDSQLServer.COMANDO.setString (1, filme.getNome ());
            BDSQLServer.COMANDO.setString  (2, filme.getSinopse ());
            BDSQLServer.COMANDO.setString (3, filme.getGenero ());
            BDSQLServer.COMANDO.setInt  (4, filme.getDuracao ());
            BDSQLServer.COMANDO.setString  (5, filme.getTrailer ());

            BDSQLServer.COMANDO.executeUpdate ();
            BDSQLServer.COMANDO.commit        ();
        }
        catch (SQLException erro)
        {
            throw new Exception ("Erro ao atualizar dados do filme");
        }
    }

    public static Filme getFilme (int codigo) throws Exception
    {
        Filme filme = null;

        try
        {
            String sql;

            sql = "SELECT * " +
                  "FROM FILMES " +
                  "WHERE CODIGO = ?";

            BDSQLServer.COMANDO.prepareStatement (sql);

            BDSQLServer.COMANDO.setInt (1, codigo);

            MeuResultSet resultado = (MeuResultSet)BDSQLServer.COMANDO.executeQuery ();

            if (!resultado.first())
                throw new Exception ("Nao cadastrado");

            filme = new Filme (resultado.getInt    ("CODIGO"),
                               resultado.getString ("NOME"),
                               resultado.getString ("SINOPSE"),
                               resultado.getString ("GENERO"),
                               resultado.getInt    ("DURACAO"),
                               resultado.getString ("TRAILER"));
        }
        catch (SQLException erro)
        {
            throw new Exception ("Erro ao procurar filme");
        }

        return filme;
    }

    public static ArrayList<Filme> getFilmes () throws Exception
    {
        MeuResultSet resultado = null;
        ArrayList<Filme> filmes = null;
        
        try
        {
            String sql;

            sql = "SELECT * " +
                  "FROM Filmes";

            BDSQLServer.COMANDO.prepareStatement (sql);

            resultado = (MeuResultSet)BDSQLServer.COMANDO.executeQuery ();
            System.out.println(resultado);
            
            filmes = new ArrayList<Filme>();
                while (!resultado.isLast())
                {
                   resultado.next();
                   filmes.add(new Filme(resultado.getInt("id"), resultado.getString("nome"), resultado.getString("sinopse"), resultado.getString("genero"), resultado.getInt("duracao"), resultado.getString("trailer")));
                }
        }
        catch (SQLException erro)
        {
            erro.printStackTrace();
        }

        return filmes;
    }
}
