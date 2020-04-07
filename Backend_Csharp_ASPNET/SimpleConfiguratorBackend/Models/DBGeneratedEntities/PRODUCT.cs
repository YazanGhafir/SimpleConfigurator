namespace SimpleConfiguratorBackend
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PRODUCT")]
    public partial class PRODUCT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OBJECT_ID { get; set; }

        [StringLength(50)]
        public string NAME { get; set; }

    }
}
