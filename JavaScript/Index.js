
            


            function IrPraUsu()
            {
                if(sessionStorage.getItem("User") != null || localStorage.getItem("User") != null)
                    location.href='Usuario.html';
                else
                    location.href='Cadastro.html';
            }