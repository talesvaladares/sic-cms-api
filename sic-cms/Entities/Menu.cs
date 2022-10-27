using System.Collections.Generic;

namespace sic_cms.Entities {
    public class Menu {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? FaImage { get; set; }
        public string? Image { get; set; }
        public string? CodigoRecurso { get; set; }
        public int? MenuPaiId { get; set; }
        public string? Rota { get; set; }
        public string? Sistema { get; set; }
        public int? Ordem { get; set; }
       

    }
}
