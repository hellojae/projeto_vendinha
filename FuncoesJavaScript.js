<!DOCTYPE html>
    <html lang = "pt-br">
        <head>
        <meta charset="UTF-8">
        </head>

<body>
    <script>
            
            function createDividaTemplate({ id, nome, cpf, descricao, valor, situacao }) {
    return 
     <td>${id}</td>;
     <td>${nome}</td>;
     <td>${descricao}</td>;
     <td>${valor}</td>;
     <td>${situacao}</td>;

     <td>
     <button type="button" class="btn btn-success btn-sm" onclick="quitarDivida(${id})">Quitar</button>
     <button type="button" class="btn btn-danger btn-sm" onclick="excluirDivida(${id})">Excluir</button>
 </td>;

}

cliente = ["id","nome","cpf","descricao","valor","situacao"];

    function listarDividas() {
    
    console.log(item);
} 

    cliente.forEach(listarDividas);


    function adicionarDivida(e) {
        cliente.push({id:"", nome:"", cpf: "", descricao:"", valor:"",situacao:""});
        createDividaTemplate();
        
       

}
    function quitarDivida(){
        var Quitar = $(this).parent().parent();
        tdQuitar.html ("<input type='text' id='txtQuitar' value='"+tdQuitar.html()+"'/>");
        
        $(".btnQuitar").bind("click", Quitar);


    }

    function excluirDivida(id) {
        document.querySelectorAll("#clienteContainer .remover").forEach((el, i)=>{
            el.addEventListener("click", ()=>{
                cliente.splice(i, 1);  	
            createDividaTemplate();
          });
        });
      }
     </script>
    </body>
</html>
