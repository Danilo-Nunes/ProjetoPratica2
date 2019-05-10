
import bd.daos.Pessoas;
import bd.dbos.Pessoa;

public class Program
{
	//http://www.vogella.com/tutorials/JavaRegularExpressions/article.html

	public static void main(String[] args) 
	{
		try 
		{
			Pessoas.incluir(new Pessoa(1, "Capit�es da Areia", 20));
		} catch (Exception e) 
		{}
	}

}
