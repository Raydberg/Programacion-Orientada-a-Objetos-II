using System;
using System.ComponentModel.DataAnnotations;

namespace Transactions_ADO.NET.Models
{
    public class Cliente
    {
        //Required: Hace que este dato sea obligatorio introducirlo
        [Required]
        //'pattern' valida el código de cliente , ErrorMessage tira un mensaje en caso de error
        [RegularExpression("C[0-9]{4}", ErrorMessage = "Formato del Código es Incorrecto: C####")]
        //que comience con C[que sólo admita números del 0-9]{que se deba ingresar obligatoriamente 4 números}
        [Display(Name = "Código")]
        public string cod_cli { get; set; }

        //----------------------------------------------------------------------------------------------------
        /*RegularExpression: Valida que se pueda ingresar sólo
         * letras en mayúsculas y minusculas; y espacios en blanco*/
        [Required]
        [RegularExpression("[a-zA-Z ]+")]

        //[StringLength(maximumLength: 3, MinimumLength = 20)]
        [Display(Name = "Nombres del cliente")]
        public string nom_cli { get; set; }

        //-----------------------------------------------------------------------------------------------------
        //
        [RegularExpression("9[0-9]{8}")]
        /*valida que comience con 9[que sólo admita números del 0-9]
         *{que se deba ingresar obligatoriamente 8 números más}*/
        public string tel_cli { get; set; }

        //----------------------------------------------------------------------------------------------------
        //DataType: valida un determinado tipo de dato (en este caso que sea un email)
        [DataType(DataType.EmailAddress)] public string cor_cli { get; set; }

        //----------------------------------------------------------------------------------------------------
        //StringLength: valida una cantidad mínima y máxima de caracteres a introducir
        [StringLength(50, MinimumLength = 10)] public string dir_cli { get; set; }

        //----------------------------------------------------------------------------------------------------
        //Range: valida que sólo se pueda ingresar una cantidad en ese rango específicado (min, max)        
        [Range(500, 6000)] public int cred_cli { get; set; }

        //----------------------------------------------------------------------------------------------------
        //DisplayFormat: permite que se use el formato de fecha cuando estamos en 'modo de edición'
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //el '0' corresponde a la variable fec_nac e yyyy-MM-dd le dice a MVC que trataremos a la fecha en ese formato
        public DateTime fec_nac { get; set; }

        //----------------------------------------------------------------------------------------------------
        //
        [Required] public int cod_dist { get; set; }

        //----------------------------------------------------------------------------------------------------
        //al campo que no se le pone ninguna restricción, no es obligatorio ingresarlo en la vista        
        public string eli_cli { get; set; }
        //eli_cli quiere decir cliente eliminado
    }
}
