//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class JoueurPartie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JoueurPartie()
        {
            this.EnPartie = true;
            this.CartesMain = new HashSet<Carte>();
            this.DesMain = new HashSet<De>();
        }
    
        public int Id { get; set; }
        public int JoueurId { get; set; }
        public int OrdreJoueur { get; set; }
        public int PartieId { get; set; }
        public bool EnPartie { get; set; }
    
        public virtual Joueur Joueur { get; set; }
        public virtual Partie Partie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Carte> CartesMain { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<De> DesMain { get; set; }
    }
}
