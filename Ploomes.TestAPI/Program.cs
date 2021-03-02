using System;
using System.Net;

namespace Ploomes.TestAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    private static void EnviaRequisicaoPost()
    {
        //Requisição Get
        var requisicaoWeb = WebRequest.CreateHttp("https://localhost:44343/api/VendedorHistorico");
        requisicaoWeb.Method = "Post";
        requisicaoWeb.ContentType = "application/json";

        using (var resposta = requisicaoWeb.GetResponse())
        {
            var streamDados = resposta.GetResponseStream();
            StreamReader reader = new StreamReader(streamDados);
            object objResponse = reader.ReadToEnd();
            Console.WriteLine(objResponse.ToString());
            Console.ReadLine();
            streamDados.Close();
            resposta.Close();
        }
    }
}
