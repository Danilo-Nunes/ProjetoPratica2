package bd.dbos;

public class Filme implements Cloneable
{
    private int    codigo;
    private String nome;
    private String sinopse;
    private String genero;
    private int    duracao;
    private String trailer;
 
    public void setCodigo (int codigo) throws Exception
    {
        if (codigo <= 0)
            throw new Exception ("Codigo invalido");

        this.codigo = codigo;
    }   

    public void setNome (String nome) throws Exception
    {
        if (nome==null || nome.equals(""))
            throw new Exception ("Nome nao fornecido");

        this.nome = nome;
    }

    public void setSinopse (String sinopse) throws Exception
    {
        this.sinopse = sinopse;
    }
    
    public void setgenero (String genero) throws Exception
    {       
        if (gebero.equals("") || genero == null)
            throw new Exception ("sinopse invalida");

        this.genero = genero;
    }

    
    public void setDuracao (int duracao) throws Exception
    {
        if (duracao <= 0)
            throw new Exception ("duracao invalida");

        this.duracao = duracao;
    }

    public void setTrailer (String trailer) throws Exception
    {
        this.trailer = trailer;
    }

    public int getCodigo ()
    {
        return this.codigo;
    }

    public String getNome ()
    {
        return this.nome;
    }

    public String getSinopse ()
    {
        return this.sinopse;
    }
    
    public String getGenero ()
    {
        return this.genero;
    }

    public Integer getduracao ()
    {
        return this.duracao;
    }

    public String getTrailer ()
    {
        return this.trailer;
    }

    public Filme (int codigo, String nome, String sinopse, String genero, int duracao, String trailer) throws Exception
    {
        this.setCodigo (codigo);
        this.setNome   (nome);
        this.setSinopse(sinopse);
        this.setGenero (genero);
        this.setDuracao(duracao);
        this.setTrailer(trailer);
    }

    public String toString ()
    {
        String ret="";

        ret+="Codigo: "+this.codigo+"\n";
        ret+="Nome..: "+this.nome  +"\n";
        ret+="Sinopse.: "+this.sinopse + "\n";
        ret +="Genero: "+this.genero+"\n";
        ret +="Duracao: "+this.duracao+"\n";
        ret +="Trailer: "+this.trailer;

        return ret;
    }

    public boolean equals (Object obj)
    {
        if (this==obj)
            return true;

        if (obj==null)
            return false;

        if (!(obj instanceof Filme))
            return false;

        Filme fil = (Filme)obj;

        if (this.codigo!=fil.codigo)
            return false;

        if (this.nome.equals(fil.nome))
            return false;

        if (this.sinopse!=fil.sinopse)
            return false;
        
        if (this.genero.equals(fil.genero))
            return false;

        if (this.duracao!=fil.duracao)
            return false;

        if (this.trailer!=fil.trailer)
            return false;

        return true;
    }

    public int hashCode ()
    {
        int ret=666;

        ret = 7*ret + new Integer(this.codigo).hashCode();
        ret = 7*ret + this.nome.hashCode();
        ret = 7*ret + this.sinopse.hashCode();
        ret = 7*ret + this.genero.hashCode();
        ret = 7*ret + new Integer(this.duracao).hashCode();
        ret = 7*ret + this.trailer.hashCode();

        return ret;
    }


    public Filme (Filme modelo) throws Exception
    {
        this.codigo = modelo.codigo; // nao clono, pq nao eh objeto
        this.nome   = modelo.nome;   // nao clono, pq nao eh clonavel
        this.sinopse  = modelo.sinopse;  // nao clono, pq nao eh objeto
        this.genero  = modelo.genero;  // nao clono, pq nao eh objeto
        this.duracao  = modelo.duracao;  // nao clono, pq nao eh objeto
        this.trailer  = modelo.trailer;  // nao clono, pq nao eh objeto
    }

    public Object clone ()
    {
        Filme ret=null;

        try
        {
            ret = new Filme (this);
        }
        catch (Exception erro)
        {} // nao trato, pq this nunca � null e construtor de
           // copia da excecao qdo seu parametro for null

        return ret;

}
