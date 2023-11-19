using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

public class TimeMiddlware
{
    //permite invocar al próximo Moddleware
    readonly RequestDelegate next;

    //creamos el constructor
    public TimeMiddlware (RequestDelegate nextRequest)
    {
        next = nextRequest;
    }

    //este método si o si tiene que estar porque allí ingresa la información del request

    public async Task Invoke(HttpContext context)
    {
         //verificamos si entre los parámetros que recibimos del request existe uno que tenga una clave igual a time
         if (context.Request.Query.Any(p=>p.Key == "time"))
         {
            //respuesta
            await context.Response.WriteAsync(DateTime.Now.ToShortDateString());
            return;
         }

        await next(context);

       
    }
    
}

//creamos un método que permite usar este middleware del program o strartup
public static class TimeMiddlwareExtension
{
    public static IApplicationBuilder UseTimeMiddleware (this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TimeMiddlware>();
    }
}