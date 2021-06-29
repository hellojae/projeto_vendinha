using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Task;
using System.Data; 


namespace Cliente{

  public Cliente(){
  }
  
  public Cliente (int id)
  {
  Id = id;
  }
  
  public Cliente (int id, string nome, int cpf, string descricao, float valor){
  Id= id;
  Nome = nome;
  Cpf = cpf;
  Descricao = descricao;
  Valor = valor;
  }
  
  public int Id {get; set;}
  public string Nome {get; set;}
  public int Cpf {get; set;}
  public string Descricao {get; set;}
  public float Valor {get; set;}
  
  }
  
