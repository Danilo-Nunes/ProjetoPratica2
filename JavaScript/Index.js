
            var not =0;

            if(not == 0)
            {
                $("number").hide();
            }
            else if(not < 10)
            {
                $("number").html(not);
            }
            else
            {
                $("number").html(not)
                $("number").css('padding-right', '5px');
                $("number").css('padding-left', '5px');
            }
            


            function IrPraUsu()
            {
                if(sessionStorage.getItem("User") != null || localStorage.getItem("User") != null)
                    location.href='Usuario.html';
                else
                    location.href='Cadastro.html';
            }