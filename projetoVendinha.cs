using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using static System.Console;

namespace crud_JSON
{
  public class JsonCrud  

{
    public void DetalhesdoUsuario(string arquivoJson)
    {
        var json = File.ReadAllText(arquivoJson);
        try
        {
            var jObject = JObject.Parse(json);

            if (jObject! = null){

                 JArray arrayClientes = (JArray)jObject["clientes"];
                 if (arrayClientes != null){

                     WriteLine("Clientes");

                     foreach (var item in arrayClientes){

                         WriteLine("\tNome:" + item["nomeCliente"].ToString());
                         WriteLine("\tCPF:" + item["cpfCliente"]);
                         WriteLine("\tDescricao:" +item["descricaoCliente"].ToString());
                         WriteLine("\tSituacao:" +item["situacaoCliente"].ToString());
                         WriteLine("\tDivida:" + item["dividaCliente"]);

            


                    }
                 }
             }
         
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    public void AdicionarCliente(string arquivoJson){
         var novoClienteMembro =  "{ 'nomecliente': " + nomeCliente + ", 'cpfcliente': '" + cpfCliente + "''descricaoCliente': '" 
        + descricaoCliente + "' 'dividacliente': '" + dividaCliente + "'}";

        try{
             var json = File.ReadAllText(arquivoJson);
                    var jsonObj = JObject.Parse(json);
             var arrayClientes = jsonObj.GetValue("clientes") as JArray;
             var novoCliente = JObject.Parse(novoClienteMembro);
                    arrayClientes.Add(novoCliente);

                     jsonObj["clientes"] = arrayClientes;
                    string novoJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, 
Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(arquivoJson, novoJsonResult);
                }
                catch (Exception ex)
                {
                    WriteLine("Erro ao adicionar : " + ex.Message.ToString());
                }

        }

        public void DeletarCliente(string arquivoJson)
            {
                var json = File.ReadAllText(arquivoJson);
                try
                {
                    var jObject = JObject.Parse(json);
                    JArray arrayCliente = (JArray)jObject["clientes"];
                     var nomeCliente = Convert.ToInt32(Console.ReadLine());
                    if (nomeCliente > 0)
                    {
                        var nomeCliente = string.Empty;
                        var clienteADeletar = arrayCliente.FirstOrDefault(obj => 
obj["nomecliente"].Value<int>() == nomeCliente);
                        arrayCliente.Remove(clienteADeletar);
                        string saida = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, 
Newtonsoft.Json.Formatting.Indented);
                        File.WriteAllText(arquivoJson, saida);
                    } 
                 else
                    {
                        Write("O nome do cliente é inválido, tente novamente!");
                        AtualizarCliente(arquivoJson);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

        public void AtualizarCliente(string arquivoJson)
            {
                string json = File.ReadAllText(arquivoJson);
                try
                {
                    var jObject = JObject.Parse(json);
                    JArray arrayClientes = (JArray)jObject["clientes"];
                    var nomeCliente = Convert.ToInt32(Console.ReadLine());
                    if (nomeCliente > 0)
                    {
                        var nomeCliente = Convert.ToString(Console.ReadLine());
                        foreach (var cliente in arrayClientes.Where(obj => 
                                           obj["nomecliente"].Value<int>() == nomeCliente))
                        {
                                  cliente["clientenome"] = !string.IsNullOrEmpty(nomeCliente) ? nomeCliente : "";
                        }
                        jObject["cliente"] = arrayClientes;
                        string saida = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, 
Newtonsoft.Json.Formatting.Indented);
                        File.WriteAllText(arquivoJson, saida);
                    }
                    else
                    {
                       Write("O nome do cliente não é válido, tente novamente!");
                       AtualizarCliente(arquivoJson);
                    }
                }
                catch (Exception ex)
                {
                    WriteLine("Erro de Atualização : " + ex.Message.ToString());
                }
            }











    }
}