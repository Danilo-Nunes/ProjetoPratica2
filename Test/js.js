var menu = false;
            $(".menuIcon").click(function(){
                if(!menu){
                    $(".aba").css("margin-left", "-10");
                    $("#menu").attr('src', 'img/exit.png');
                    menu = true;
                }
                else
                {
                    $(".aba").css("margin-left", "-1000");
                    $("#menu").attr('src', 'img/menu.png'); 
                    menu = false;
                }
            })