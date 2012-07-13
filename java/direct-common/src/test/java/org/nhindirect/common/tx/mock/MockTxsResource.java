package org.nhindirect.common.tx.mock;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;

import javax.ws.rs.Consumes;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.Response.Status;

import org.codehaus.enunciate.jaxrs.TypeHint;
import org.nhindirect.common.tx.model.Tx;
import org.springframework.stereotype.Component;

import com.google.inject.Singleton;


@Component
@Path("txs/")
@Singleton
public class MockTxsResource
{
	protected Collection<Tx> txs = new ArrayList<Tx>();
	

    @TypeHint(Tx.class)  
    @POST
    @Consumes(MediaType.APPLICATION_JSON)  
    public Response addTx(Tx tx)
    {
    	
    	txs.add(tx);
    	
		return Response.status(Status.CREATED).build();
    }

    public void clearTxState()
    {
    	txs.clear();
    }

    public Collection<Tx> getTxs()
    {
    	return Collections.unmodifiableCollection(txs);
    }
}

