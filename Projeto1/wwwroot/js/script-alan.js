$(document).scroll(function () { rodape()});
$(window).resize(function(){ rodape()});

function rodape(){    
    var janela = $(window).height();
    var doc = $(document).height();
    console.log(janela+" x "+doc);
    
    if( doc > janela){
       $("footer > nav").removeClass("fixed-bottom");
       console.log("doc é maior");
    } else {
       $("footer > nav").addClass("fixed-bottom");
       console.log("janela é maior");
    }
}

$(document).ready(function(){
    $('#termo_busca').keyup(function(){
        // $("#cabradapeste").dropdown('toggle');
        pesquisar_cliente();
    });
});

function pesquisar_cliente(){
    $.ajax({
        type: 'GET',
        url:  '/api/Clientes',
        data: {
            Pesquisa: $("#termo_busca").val()
        },
        success: function(data) 
        {
          listaCollapse(data);
        }
      });
}

function listaCollapse(clientes){
    
    var linhas = "";
    var vazio = '<label class="dropdown-item">Nenhum resultado</label>'
    
    $.each(clientes, function (x, cliente) {
        linhas = linhas + '<button class="dropdown-item" type="button">'+cliente.nome+'</button>';
    });

    if(linhas == "")
        $("#cabradapeste > div").html(vazio);
    else
        $("#cabradapeste > div").html(linhas);
      
}