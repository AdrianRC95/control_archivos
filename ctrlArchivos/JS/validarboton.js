
     function Habilitar(){
 
         var txt1 = document.getElementById("TextBox1").value;
         var txt2 = document.getElementById("TextBox2").value;
         var boton = document.getElementById("Button1");
 
         if(txt1 == "" && txt2 == "")
             boton.setAttribute("disabled", "disabled");

         else
             boton.removeAttribute('disabled');
     }
