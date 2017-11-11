using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace convertizzle.Models
{
    /// <summary>
    /// This class describes an account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// The ApiKey of the account
        /// </summary>
        public string ApiKey { get; set;}

        /// <summary>
        /// The Email of the user of this account
        /// </summary>
        [Key]
        public string Email { get; set; }

        /// <summary>
        /// The credits available
        /// </summary>
        public int Credits { get; set;}

        /// <summary>
        /// The list of conversion done by this account
        /// </summary>
        public virtual ICollection<Conversion> Conversions { get; set; }

    }
}