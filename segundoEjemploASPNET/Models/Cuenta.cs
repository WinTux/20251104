using System.ComponentModel.DataAnnotations;

namespace segundoEjemploASPNET.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Descripcion { get; set; }
        public bool Disponible { get; set; }
        public string Genero { get; set; } // "M" o "F"
        public List<string> Lenguajes { get; set; } // "Len01", "Len02", "Len03"
        public string Cargo { get; set; } // "Car01", "Car02", "Car03"

    }
}

namespace ejemplo.validacion {
    public class Cuenta {
        [Required(ErrorMessage ="Es necesario ingresar un nombre de usuario!!")]
        [MinLength(3,ErrorMessage = "Un nombre de usuario debe tener al menos 3 letras!!")]
        [MaxLength(10,ErrorMessage = "Un nombre de usuario debe tener a lo mucho 10 letras!!")]
        public string Usuario { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})",ErrorMessage ="El password debe contar con al menos una letra minúscula, una mayúscula, un dígito y un caracter especial (@#$%)")]
        public string Password { get; set; }
        [Range(18, 99)]
        [Required]
        public int Edad { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [Url]
        public string sitioWeb { get; set; }
    }
}


/* EXPRESIONES REGULARES
 
Uso de + y * en expresiones regulares
+ : uno o más
* : cero o más
    A+ : una o más A
    A* : cero o más A
    (AB)+ : una o más repeticiones de AB: AB, ABAB, ABABAB, ...; error: A, AAB, B, ...
    (AB)* : cero o más repeticiones de AB: "", AB, ABAB, ABABAB, ...; error: A, AAB, B, ...
    A(BC)+D : A seguido de una o más repeticiones de BC seguido de D: ABCD, ABCBCD, ABCBCBCD, ...; error: ABD, AB, ACD, AD, ...

Uso de ? en expresiones regulares
? : cero o una
    A? : cero o una A: "", A
    (AB)? : cero o una repetición de AB: "", AB; error: A, B, AAB, ...
    A(BC)?D : A seguido de cero o una repetición de BC seguido de D: AD, ABCD; error: ABD, AB, ACD, ...

Uso de {n,m} en expresiones regulares
{n,m} : al menos n y como máximo m
    A{2,4} : al menos 2 y como máximo 4 A: AA, AAA, AAAA; error: A, AAAAA, ...
    (AB){1,3} : al menos 1 y como máximo 3 repeticiones de AB: AB, ABAB, ABABAB; error: "", A, B, ABABABAB, ...
    A(BC){2,4}D : A seguido de al menos 2 y como máximo 4 repeticiones de BC seguido de D: ABCBCD, ABCBCBCD, ABCBCBCBCD; error: ABD, ABCD, AD, ...

Uso de ^ y $ en expresiones regulares
^ : inicio de la cadena
$ : fin de la cadena
    ^A : cadena que comienza con A: A, AB, ABC, ...; error: BA, BCA, ...
    A$ : cadena que termina con A: A, BA, CBA, ...; error: AB, ABC, ...
    ^A$ : cadena que es exactamente A: A; error: "", AA, AB, BA, ...
    ^(AB)+$ : cadena que es una o más repeticiones de AB: AB, ABAB, ABABAB, ...; error: "", A, B, AAB, ABA, ...

Ejemplo:
 [ARTJU]{4}: cuatro letras, cada una de las cuales puede ser A, R, T, J o U.
 [A-JM-Z]+: una o más letras, cada una de las cuales puede ser A, B, C, D, E, F, G, H, I, J, M, N, O, P, Q, R, S, T, U, V, W, X, Y o Z.


ejemplo placa:

 1234ABC, 1234BGT4, RTX453, 1RTS, 5434AB
 
ejemplo numero celular:

40981234, 309891, 70981234

ejemplo email:

abc@efg a@b.c @ab. a.b.c_g@d.e.f

ejemplo sitio web:

www.ejemplo.com, http://ejemplo.com, https://www.ejemplo.com, www.ejemplo.co.uk

 */