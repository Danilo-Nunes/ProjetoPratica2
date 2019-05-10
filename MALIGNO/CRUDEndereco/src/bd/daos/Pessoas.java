package bd.daos;

import java.sql.SQLException;

import bd.BDSQLServer;
import bd.core.MeuResultSet;
import bd.dbos.Livro;

public class Pessoas 
{
	public static boolean cadastrado (int codigo) throws Exception
    {
        boolean retorno = false;

        try
        {
            String sql;

            sql = "SELECT * " +
                  "FROM PESSOAS " +
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

    public static void incluir (Pessoa pessoa) throws Exception
    {
        if (pessoa==null)
            throw new Exception ("pessoa nao fornecida");

        try
        {
            String sql;

            sql = "INSERT INTO PESSOAS " +
                  "(CODIGO,NOME,CEP, COMPLEMENTO, NUMERO) " +
                  "VALUES " +
                  "(?,?,?)";

            BDSQLServer.COMANDO.prepareStatement (sql);

            BDSQLServer.COMANDO.setInt    (1, pessoa.getCodigo ());
            BDSQLServer.COMANDO.setString (2, pessoa.getNome ());
            BDSQLServer.COMANDO.setInt  (3, pessoa.getCep ());
            BDSQLServer.COMANDO.setString (4, pessoa.getComplemento ());
            BDSQLServer.COMANDO.setInt  (5, pessoa.getNumero ());

            BDSQLServer.COMANDO.executeUpdate ();
            BDSQLServer.COMANDO.commit        ();
        }
        catch (SQLException erro)
        {
            throw new Exception ("Erro ao inserir pessoa");
        }
    }

    public static void excluir (int codigo) throws Exception
    {
        if (!cadastrado (codigo))
            throw new Exception ("Nao cadastrado");

        try
        {
            String sql;

            sql = "DELETE FROM PESSOAS " +
                  "WHERE CODIGO=?";

            BDSQLServer.COMANDO.prepareStatement (sql);

            BDSQLServer.COMANDO.setInt (1, codigo);

            BDSQLServer.COMANDO.executeUpdate ();
            BDSQLServer.COMANDO.commit        ();        }
        catch (SQLException erro)
        {
            throw new Exception ("Erro ao excluir pessoa");
        }
    }

    public static void alterar (Pessoa pessoa) throws Exception
    {
        if (pessoa==null)
            throw new Exception ("Pessoa nao fornecido");

        if (!cadastrado (pessoa.getCodigo()))
            throw new Exception ("Nao cadastrado");

        try
        {
            String sql;

            sql = "UPDATE PESSOAS " +
                  "SET NOME=? " +
                  "SET PRECO=? " +
                  "SET COMPLEMENTO=? " +
                  "SET NUMERO=? " +
                  "WHERE CODIGO = ?";

            BDSQLServer.COMANDO.prepareStatement (sql);

            BDSQLServer.COMANDO.setString (1, pessoa.getNome ());
            BDSQLServer.COMANDO.setInt  (2, pessoa.getCep ());
            BDSQLServer.COMANDO.setString (3, pessoa.getComplemento ());
            BDSQLServer.COMANDO.setInt  (4, pessoa.getNumero ());
            BDSQLServer.COMANDO.setInt    (5, pessoa.getCodigo ());

            BDSQLServer.COMANDO.executeUpdate ();
            BDSQLServer.COMANDO.commit        ();
        }
        catch (SQLException erro)
        {
            throw new Exception ("Erro ao atualizar dados de pessoa");
        }
    }

    public static Pessoa getPessoa (int codigo) throws Exception
    {
        Pessoa pessoa = null;

        try
        {
            String sql;

            sql = "SELECT * " +
                  "FROM PESSOAS " +
                  "WHERE CODIGO = ?";

            BDSQLServer.COMANDO.prepareStatement (sql);

            BDSQLServer.COMANDO.setInt (1, codigo);

            MeuResultSet resultado = (MeuResultSet)BDSQLServer.COMANDO.executeQuery ();

            if (!resultado.first())
                throw new Exception ("Nao cadastrado");

            pessoa = new Pessoa (resultado.getInt   ("CODIGO"),
                               resultado.getString("NOME"),
                               resultado.getFloat ("CEP"),
                               resultado.getString("COMPLEMENTO"),
                               resultado.getFloat ("NUMERO"));
        }
        catch (SQLException erro)
        {
            throw new Exception ("Erro ao procurar pessoa");
        }

        return pessoa;
    }

    public static MeuResultSet getPessoas () throws Exception
    {
        MeuResultSet resultado = null;

        try
        {
            String sql;

            sql = "SELECT * " +
                  "FROM PESSOAS";

            BDSQLServer.COMANDO.prepareStatement (sql);

            resultado = (MeuResultSet)BDSQLServer.COMANDO.executeQuery ();
        }
        catch (SQLException erro)
        {
            throw new Exception ("Erro ao recuperar pessoas");
        }

        return resultado;
    }
}
