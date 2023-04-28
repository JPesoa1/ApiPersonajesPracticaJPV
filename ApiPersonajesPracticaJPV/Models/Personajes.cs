﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPersonajesPracticaJPV.Models
{
    [Table("PERSONAJES")]
    public class Personajes
    {
        [Key]
        [Column("IDPERSONAJE")]
        public int IdPersoanje { get; set; }

        [Column("PERSONAJE")]
        public string Nombre { get; set; }

        [Column("IMAGEN")]
        public string Imagen { get; set; }

        [Column("IDSERIE")]
        public int IdSerie{ get; set; }
    }
}
