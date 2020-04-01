namespace SimpleConfiguratorBackend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PARAMETER_VALUE 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OBJECT_ID { get; set; }

        public int PARAMETER_ID { get; set; }

        [StringLength(50)]
        public string NAME { get; set; }

    }
}
