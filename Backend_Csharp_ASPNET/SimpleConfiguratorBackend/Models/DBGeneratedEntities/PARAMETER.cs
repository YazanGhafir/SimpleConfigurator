namespace SimpleConfiguratorBackend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PARAMETER")]
    public partial class PARAMETER 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OBJECT_ID { get; set; }

        public int PRODUCT_ID { get; set; }

        [StringLength(50)]
        public string NAME { get; set; }

    }
}
