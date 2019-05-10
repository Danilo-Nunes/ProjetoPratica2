/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.metodista.servicos;

import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.core.MediaType;//
import com.google.gson.Gson;//
import br.metodista.modelo.*;
import java.util.ArrayList;
import bd.dao.Filmes;
import javax.ws.rs.PathParam;

/**
 *
 * @author u18203
 */
@Path("filmes")
public class FilmesResource {
    private static ArrayList<Filme> filmes; 
    
    /**
     * Creates a new instance of FilmesResource
     */
    public FilmesResource() throws Exception
    { 
        this.filmes = Filmes.getFilmes();               
    } 
    
    @Context // contexto, uma porrada de biblioteca, usamos o contexto, todas as operações são deles, a instancia é o contexto
    private UriInfo context; // uri = url, pega o path e essas merda ai    

    /**
     * Retrieves representation of an instance of br.metodista.servicos.FilmesResource
     * @return an instance of java.lang.String
     */
    @GET
    @Produces("application/json") // json é todas as porras que vc tem no banco
    public String getJson() {
        //TODO return proper representation object
        Gson gson = new Gson(); // get son
        return gson.toJson(filmes);
    }

    /**
     * PUT method for updating or creating an instance of FilmesResource
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_JSON)
    public void putJson(String content) {
    }
    
    @GET
    @Path("{filmeId}") // um padrão, todos devem seguir assim  
    @Produces("application/json")
    public String getFilme(@PathParam("filmeId") String filmeId) // parâmetro vem a ser interpretado como uma String
    {
        for(Filme f : filmes) 
        { 
            if(f.getCodigo() == Long.valueOf(filmeId)) // pode ser um código grande
            { 
                Gson gson = new Gson(); 
                return gson.toJson(f); // json vem em string
            } 
        } 
        return ""; 
    }
}
