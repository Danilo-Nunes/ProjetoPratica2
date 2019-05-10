package bd.dbos;

public class Pessoa implements Cloneable
{
    private int    codigo;
    private String nome;
    private int    cep;
    private String complemento;
    private int    numero;
 
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

    public void setCep (int cep) throws Exception
    {
        if (cep <= 0)
            throw new Exception ("Cep invalido");

        this.cep = cep;
    }
    
    public void setComplemento (String complemento) throws Exception
    {       
        this.complemento = complemento;
    }

    
    public void setNumero (int numero) throws Exception
    {
        if (numero <= 0)
            throw new Exception ("Numero invalido");

        this.numero = numero;
    }


    public int getCodigo ()
    {
        return this.codigo;
    }

    public String getNome ()
    {
        return this.nome;
    }

    public float getCep ()
    {
        return this.cep;
    }
    
    public String getComplemento ()
    {
        return this.complemento;
    }

    public float getNumero ()
    {
        return this.numero;
    }

    public Pessoa (int codigo, String nome, int cep, String complemento, int numero) throws Exception
    {
        this.setCodigo (codigo);
        this.setNome   (nome);
        this.setCep  (cep);
        this.setComplemento   (complemento);
        this.setNumero  (numero);
    }

    public String toString ()
    {
        String ret="";

        ret+="Codigo: "+this.codigo+"\n";
        ret+="Nome..: "+this.nome  +"\n";
        ret+="Cep.: "+this.cep + "\n";
        ret +="Complemento: "+this.complemento+"\n";
        ret +="Numero: "+this.numero+"\n";

        return ret;
    }

    public boolean equals (Object obj)
    {
        if (this==obj)
            return true;

        if (obj==null)
            return false;

        if (!(obj instanceof Pessoa))
            return false;

        Pessoa pes = (Pessoa)obj;

        if (this.codigo!=pes.codigo)
            return false;

        if (this.nome.equals(pes.nome))
            return false;

        if (this.cep!=pes.cep)
            return false;
        
        if (this.complemento.equals(pes.complemento))
            return false;

        if (this.numero!=pes.numero)
            return false;

        return true;
    }

    public int hashCode ()
    {
        int ret=666;

        ret = 7*ret + new Integer(this.codigo).hashCode();
        ret = 7*ret + this.nome.hashCode();
        ret = 7*ret + new Integer(this.cep).hashCode();
        ret = 7*ret + new String(this.complemento).hashCode();
        ret = 7*ret + new Integer(this.numero).hashCode();

        return ret;
    }


    public Pessoa (Pessoa modelo) throws Exception
    {
        this.codigo = modelo.codigo; // nao clono, pq nao eh objeto
        this.nome   = modelo.nome;   // nao clono, pq nao eh clonavel
        this.cep  = modelo.cep;  // nao clono, pq nao eh objeto
        this.complemento  = modelo.complemento;  // nao clono, pq nao eh objeto
        this.numero  = modelo.numero;  // nao clono, pq nao eh objeto
    }

    public Object clone ()
    {
        Pessoa ret=null;

        try
        {
            ret = new Pessoa (this);
        }
        catch (Exception erro)
        {} // nao trato, pq this nunca é null e construtor de
           // copia da excecao qdo seu parametro for null

        return ret;

}
