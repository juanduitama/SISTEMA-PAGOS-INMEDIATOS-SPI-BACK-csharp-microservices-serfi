using SPI_Enrollment_Service.model;
using System.ComponentModel.DataAnnotations;

namespace Models.openSearchModel
{
    public class OSDefinitive
    {
        [Required]
        public string? rqUID { get; set; }
        
        public AcctInfo acctInfo { get; set; }
        
        public CustInfo custInfo { get; set; }
        
        public Key key { get; set; }
        
        public VaultInsc vaultInsc { get; set; }

        [Required]
        public DateTime effDtCreate { get; set; }
        
        public DateTime? effDtModify { get; set; }
    }
}
